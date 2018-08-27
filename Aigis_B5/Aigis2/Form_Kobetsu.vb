'20180504 Kubo プロトタイプ完成
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports Newtonsoft.Json
Public Class Form_Kobetsu

    '共有変数の宣言
    Private curdirPath As String = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location) 'カレントディレクトリパス
    Private photoTime1 As String '撮影時刻候補１に使用する変数
    Private photoTime2 As String '撮影時刻候補２に使用する変数

    'JsonItemクラス = アプリで表示する書誌を宣言したクラス
    Public Class JsonItem
        Public Property karimidashi As String '仮見出し
        Public Property status As String 'ステータス
        Public Property capsion1 As String 'キャプション（Ｐ説）
        Public Property capsion2 As String 'キャプション（人＋日時）
        Public Property timeFlag As String '時刻フラグ
        Public Property daihyoFlag As String '代表フラグ
        Public Property dontUseTyp As String() '利用禁止
        Public Property syukkoyotei As String '送信先出稿予定
        Public Property photographer As String '撮影者
        Public Property phototime1 As String '撮影時刻１
        Public Property phototime2 As String '撮影時刻２
        Public Property photoplace As String '撮影場所
        Public Property registtime As String '登録時刻
        Public Property recommendFlag As String 'オススメフラグ
    End Class

    'フォーム起動時
    Private Sub FormDefault_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Form_Default.Show()
        ListUpdate()
        '以下、FSViewerから起動時（「画像選択」ボタン押下時とほぼ同じ）
        If System.Environment.GetCommandLineArgs.Count = 2 Then
            Dim imagePath As String = System.Environment.GetCommandLineArgs(1)
            If System.IO.File.Exists(imagePath.ToString) = True Then
                'プレビュー画像の表示
                Dim pxcelSize As Integer = PictureBox_Main.Height
                Dim canvas As New Bitmap(pxcelSize, pxcelSize)
                Dim image As New Bitmap(imagePath)
                Dim jpgWith As Integer = image.Width
                Dim jpgHeight As Integer = image.Height
                Dim maginWith As Integer
                Dim maginHeight As Integer
                If jpgWith > jpgHeight Then
                    jpgHeight = pxcelSize * jpgHeight / jpgWith
                    jpgWith = pxcelSize
                    maginWith = 0
                    maginHeight = (pxcelSize - jpgHeight) / 2
                Else
                    jpgWith = pxcelSize * jpgWith / jpgHeight
                    jpgHeight = pxcelSize
                    maginWith = (pxcelSize - jpgWith) / 2
                    maginHeight = 0
                End If
                Dim g As Graphics = Graphics.FromImage(canvas)
                g.DrawImage(image, maginWith, maginHeight, jpgWith, jpgHeight)
                image.Dispose()
                PictureBox_Main.Image = canvas
                Dim fileName As String = System.IO.Path.GetFileName(imagePath)
                TextBox_GazoPass.Text = curdirPath & "\data\Temp\" & fileName
                My.Computer.FileSystem.CopyFile(imagePath, TextBox_GazoPass.Text, True)
                'Exifから撮影日時の取得
                Dim exifDate As String = "null"
                Dim imgFile As String = imagePath
                Dim bmp As New System.Drawing.Bitmap(imgFile)
                Dim item As System.Drawing.Imaging.PropertyItem
                For Each item In bmp.PropertyItems
                    If item.Type = 2 Then
                        Dim val As String = System.Text.Encoding.ASCII.GetString(item.Value)
                        val = val.Trim(New Char() {ControlChars.NullChar})
                        If item.Id = 36867 Then
                            exifDate = val
                        End If
                    Else
                        If item.Id = 36867 Then
                            exifDate = item.Len
                        End If
                    End If
                Next item
                exifDate = Replace(exifDate, ":", "/", 1, 1, CompareMethod.Binary)
                exifDate = Replace(exifDate, ":", "/", 1, 1, CompareMethod.Binary)
                Dim dtBirth As DateTime = DateTime.Parse(exifDate)
                photoTime1 = dtBirth.ToString("yyyy年M月dd日tth時m分")
                photoTime2 = dtBirth.ToString("yyyy年M月dd日")
                bmp.Dispose()
                'ファイルサイズを取得
                Dim fileinfo As New System.IO.FileInfo(imagePath)
                Dim filesize As String
                If fileinfo.Length > 1000000 Then
                    filesize = Format((fileinfo.Length / 1024 / 1024), "#.#0")
                Else
                    filesize = Format((fileinfo.Length / 1024 / 1024), "0.#0")
                End If
                ' 画像の幅と高さの取得その２
                Dim imageh, imagew As Integer
                Dim fs As System.IO.FileStream
                fs = New System.IO.FileStream(imagePath, IO.FileMode.Open, IO.FileAccess.Read)
                imageh = System.Drawing.Image.FromStream(fs).Height
                imagew = System.Drawing.Image.FromStream(fs).Width
                fs.Close()
                Label_Filesize.Text = "ファイルサイズ：" & filesize & "MB"
                Label_Tate.Text = "縦：" & imageh
                Label_Yoko.Text = "横：" & imagew
                TextBox_Satsueijikoku.Text = photoTime1
                If CheckBox_Daihyo.Checked = True Then
                    If CheckBox_Jikoku.Checked = True Then
                        TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影（代表撮影）"
                    Else
                        TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影（代表撮影）"
                    End If
                Else
                    If CheckBox_Jikoku.Checked = True Then
                        TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影"
                    Else
                        TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影"
                    End If
                End If
            End If
        End If
    End Sub

    'setting.jsonから各リストのItemを反映、デフォルト書誌の反映
    Private Sub ListUpdate()
        Dim jsonFilepath As String = curdirPath & "\setting\setting.json", jsonstr As String
        Using sr As New System.IO.StreamReader(jsonFilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        '撮影者リストの反映
        ComboBox_Photographer.Items.Clear()
        ComboBox_Photographer.Items.AddRange({jsonobj("photographer")("photographer1"), jsonobj("photographer")("photographer2"),
                                           jsonobj("photographer")("photographer3"), jsonobj("photographer")("photographer4")})
        ComboBox_Photographer.Text = ComboBox_Photographer.Items.Item(0)
        '撮影場所リストの反映
        ComboBox_Photoplace.Items.Clear()
        ComboBox_Photoplace.Items.AddRange({jsonobj("photoplace")("photoplace1"), jsonobj("photoplace")("photoplace2"),
                                           jsonobj("photoplace")("photoplace3"), jsonobj("photoplace")("photoplace4")})
        ComboBox_Photoplace.Text = ComboBox_Photoplace.Items.Item(0)
        '出稿予定リストの反映
        ComboBox_Syukkoyotei.Items.Clear()
        ComboBox_Syukkoyotei.Items.AddRange({jsonobj("syukkoyotei")("syukkoyotei1"), jsonobj("syukkoyotei")("syukkoyotei2"),
                                            jsonobj("syukkoyotei")("syukkoyotei3"), jsonobj("syukkoyotei")("syukkoyotei4")})
        ComboBox_Syukkoyotei.Text = ComboBox_Syukkoyotei.Items.Item(0)
        'デフォルト書誌の反映
        TextBox_Karimidashi.Text = jsonobj("hinagatadefo")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagatadefo")("karimidashi")
    End Sub

    '書誌クリア（後段で呼び出す）
    Public Sub ClearShoshi()
        TextBox_Karimidashi.Text = ""
        TextBox_Caption1.Text = ""
        TextBox_Caption2.Text = ""
    End Sub

    ' 「画像選択」ボタン押下時
    Private Sub SelectGazo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SelectGazo.Click
        ProgressBar_Loading.Visible = True
        Label_Loading.Visible = True
        My.Computer.FileSystem.CreateDirectory(curdirPath & "\data\Temp\")
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Title = "取り込む画像を選択"
        'ファイル選択ダイアログの設定
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "jpegファイル(*.jpg)|*.jpg|すべてのファイル|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = False
        Dim originalFilePath As String
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
            ProgressBar_Loading.Visible = False
            Label_Loading.Visible = False
            Exit Sub
        End If
        originalFilePath = OpenFileDialog1.FileName
        If System.IO.File.Exists(originalFilePath.ToString) = True Then
            'プレビュー画像の表示
            Dim size As Integer = PictureBox_Main.Height
            Dim canvas As New Bitmap(size, size)
            Dim image As New Bitmap(originalFilePath)
            Dim jpgwith As Integer = image.Width
            Dim jpgheight As Integer = image.Height
            Dim maginwith As Integer
            Dim maginheight As Integer
            If jpgwith > jpgheight Then
                jpgheight = size * jpgheight / jpgwith
                jpgwith = size
                maginwith = 0
                maginheight = (size - jpgheight) / 2
            Else
                jpgwith = size * jpgwith / jpgheight
                jpgheight = size
                maginwith = (size - jpgwith) / 2
                maginheight = 0
            End If
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
            image.Dispose()
            PictureBox_Main.Image = canvas
            TextBox_GazoPass.Text = originalFilePath
            Dim filename As String = System.IO.Path.GetFileName(originalFilePath)
            TextBox_GazoPass.Text = curdirPath & "\data\Temp\" & filename
            My.Computer.FileSystem.CopyFile(originalFilePath, TextBox_GazoPass.Text, True)
            '＝＝＝Exifから撮影日時の取得ここから(厄介)＝＝＝
            Dim exifdate As String = "null"
            Dim imgFile As String = originalFilePath
            Dim bmp As New System.Drawing.Bitmap(imgFile)
            'Exif情報を列挙する
            Dim item As System.Drawing.Imaging.PropertyItem
            For Each item In bmp.PropertyItems
                'データの型を判断し、ASCII文字の場合は、文字列に変換してから撮影日時のみ取得する
                If item.Type = 2 Then
                    Dim val As String = System.Text.Encoding.ASCII.GetString(item.Value)
                    val = val.Trim(New Char() {ControlChars.NullChar})
                    If item.Id = 36867 Then
                        exifdate = val
                    End If
                Else
                    If item.Id = 36867 Then
                        exifdate = item.Len
                    End If
                End If
            Next item
            exifdate = Replace(exifdate, ":", "/", 1, 1, CompareMethod.Binary)
            exifdate = Replace(exifdate, ":", "/", 1, 1, CompareMethod.Binary)
            Dim dtBirth As DateTime = DateTime.Parse(exifdate)
            photoTime1 = dtBirth.ToString("yyyy年M月dd日tth時m分")
            photoTime2 = dtBirth.ToString("yyyy年M月dd日")
            bmp.Dispose()
            '＝＝＝Exifから撮影日時の取得ここまで(厄介)＝＝＝
            'ファイルサイズを取得
            Dim fileinfo As New System.IO.FileInfo(TextBox_GazoPass.Text)
            Dim filesize As String
            'Dim filesize As Long = fileinfo.Length / 1000
            If fileinfo.Length > 1000000 Then
                filesize = Format((fileinfo.Length / 1024 / 1024), "#.#0")
            Else
                filesize = Format((fileinfo.Length / 1024 / 1024), "0.#0")
            End If
            ' 画像の幅と高さの取得その２
            Dim imageh, imagew As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(TextBox_GazoPass.Text, IO.FileMode.Open, IO.FileAccess.Read)
            imageh = System.Drawing.Image.FromStream(fs).Height
            imagew = System.Drawing.Image.FromStream(fs).Width
            fs.Close()
            Label_Filesize.Text = "ファイルサイズ：" & filesize & "MB"
            Label_Tate.Text = "縦：" & imageh
            Label_Yoko.Text = "横：" & imagew
            TextBox_Satsueijikoku.Text = photoTime1
            If CheckBox_Daihyo.Checked = True Then
                If CheckBox_Jikoku.Checked = True Then
                    TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影（代表撮影）"
                Else
                    TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影（代表撮影）"
                End If
            Else
                If CheckBox_Jikoku.Checked = True Then
                    TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影"
                Else
                    TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影"
                End If
            End If
        End If
        ProgressBar_Loading.Visible = False
        Label_Loading.Visible = False
    End Sub

    '「ファイル」→「ライブラリ」押下時
    Private Sub Liverary_Open(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ライブラリToolStripMenuItem.Click
        Form_Default.Show()
    End Sub

    '「ファイル」→「終了」押下時
    Private Sub Exit_Form(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    '「設定」→「雛形設定」押下時
    Private Sub HinaSetting(sender As Object, e As EventArgs) Handles 雛形設定ToolStripMenuItem1.Click
        Form_Setting.Show()
    End Sub

    '「設定」→「接続設定」押下時
    Private Sub SetsuzokuSetting(sender As Object, e As EventArgs) Handles 接続設定ToolStripMenuItem.Click
        Form_Parsonal.Show()
    End Sub

    '「雛形１」ボタンにカーソル被せで内容をポップアップ
    Private Sub Hina1Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina1.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Hina1, jsonobj("hinagata1")("karimidashi") & vbCrLf & jsonobj("hinagata1")("caption"))
    End Sub

    '「雛形１」ボタン押下時
    Private Sub Hina1Click(sender As Object, e As EventArgs) Handles Button_Hina1.Click
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimidashi.Text = jsonobj("hinagata1")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagata1")("caption")
    End Sub

    '「雛形２」ボタンにカーソル被せで内容をポップアップ
    Private Sub Hina2Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina2.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Hina2, jsonobj("hinagata2")("karimidashi") & vbCrLf & jsonobj("hinagata2")("caption"))
    End Sub

    '「雛形２」ボタン押下時
    Private Sub Hina2Click(sender As Object, e As EventArgs) Handles Button_Hina2.Click
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimidashi.Text = jsonobj("hinagata2")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagata2")("caption")
    End Sub

    '「雛形３」ボタンにカーソル被せで内容をポップアップ
    Private Sub Hina3Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina3.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Hina3, jsonobj("hinagata3")("karimidashi") & vbCrLf & jsonobj("hinagata3")("caption"))
    End Sub

    '「雛形３」ボタン押下時
    Private Sub Hina3Click(sender As Object, e As EventArgs) Handles Button_Hina3.Click
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimidashi.Text = jsonobj("hinagata3")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagata3")("caption")
    End Sub

    '「雛形４」ボタンにカーソル被せで内容をポップアップ
    Private Sub Hina4Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina4.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Hina4, jsonobj("hinagata4")("karimidashi") & vbCrLf & jsonobj("hinagata4")("caption"))
    End Sub

    '「雛形４」ボタン押下時
    Private Sub Hina4Click(sender As Object, e As EventArgs) Handles Button_Hina4.Click
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimidashi.Text = jsonobj("hinagata4")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagata4")("caption")
    End Sub

    '「雛形５」ボタンにカーソル被せで内容をポップアップ
    Private Sub Hina5Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina5.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Hina5, jsonobj("hinagata5")("karimidashi") & vbCrLf & jsonobj("hinagata5")("caption"))
    End Sub

    '「雛形５」ボタン押下時
    Private Sub Hina5Click(sender As Object, e As EventArgs) Handles Button_Hina5.Click
        Dim jsonhinagata As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimidashi.Text = jsonobj("hinagata5")("karimidashi")
        TextBox_Caption1.Text = jsonobj("hinagata5")("caption")
    End Sub

    '「オススメ」ボタン押下時
    Private Sub Recommend(sender As Object, e As EventArgs) Handles Button_Recommend.Click
        If Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch Then
            Button_Recommend.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\yellowstar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Zoom
        Else
            Button_Recommend.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\whitestar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    '「撮影者」変更時
    Private Sub Photographer_Change(sender As Object, e As EventArgs) Handles ComboBox_Photographer.TextChanged
        Dim jikoku As String
        If CheckBox_Jikoku.Checked = True Then
            jikoku = photoTime2
        Else
            jikoku = photoTime1
        End If
        If CheckBox_Daihyo.Checked = True Then
            TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Photographer.Text & "撮影（代表撮影）"
        Else
            TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Photographer.Text & "撮影"
        End If
    End Sub

    '「撮影場所」変更時
    Private Sub Photoplace_Change(sender As Object, e As EventArgs) Handles ComboBox_Photoplace.TextChanged
        Dim jikoku As String
        If CheckBox_Jikoku.Checked = True Then
            jikoku = photoTime2
        Else
            jikoku = photoTime1
        End If
        If CheckBox_Daihyo.Checked = True Then
            TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Photographer.Text & "撮影（代表撮影）"
        Else
            TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Photographer.Text & "撮影"
        End If
    End Sub

    '「簡易日時」チェック時
    Private Sub Jikoku_Checke(sender As Object, e As EventArgs) Handles CheckBox_Jikoku.CheckedChanged
        If CheckBox_Daihyo.Checked = True Then
            If CheckBox_Jikoku.Checked = True Then
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影（代表撮影）"
            Else
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影（代表撮影）"
            End If
        Else
            If CheckBox_Jikoku.Checked = True Then
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影"
            Else
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影"
            End If
        End If
    End Sub

    '「代表写真」チェック時
    Private Sub Daihyo_Checke(sender As Object, e As EventArgs) Handles CheckBox_Daihyo.CheckedChanged
        If CheckBox_Jikoku.Checked = True Then
            If CheckBox_Daihyo.Checked = True Then
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影（代表撮影）"
            Else
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Photographer.Text & "撮影"
            End If
        Else
            If CheckBox_Daihyo.Checked = True Then
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影（代表撮影）"
            Else
                TextBox_Caption2.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Photographer.Text & "撮影"
            End If
        End If
    End Sub

    'TextBox_Maxsizeの入力を半角数字に制限
    Private Sub TextBoxMaxsize_KeyPress(sender As Object,
 e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Maxsize.KeyPress
        '0～9と、バックスペース以外の時は、イベントをキャンセルする
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso
 e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    '「リサイズ」ボタン押下時
    Private Sub ResizeJikko(sender As Object, e As EventArgs) Handles Button_Resize.Click
        If TextBox_Maxsize.Text = "" Then
            MsgBox("サイズを指定して下さい")
            Exit Sub
        ElseIf TextBox_GazoPass.Text = "" Then
            MsgBox("画像を読み込んで下さい")
            Exit Sub
        End If
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("リサイズしますか？（元画像は保持されます）",
                                                         "リサイズ",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button1)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
        Dim Filepath As String = TextBox_GazoPass.Text
        ' 画像の幅と高さの取得
        Dim imageh, imagew As Integer
        Dim fs As System.Drawing.Image = System.Drawing.Image.FromFile(Filepath)
        imageh = fs.Height
        imagew = fs.Width
        fs.Dispose()
        If imagew > imageh Then
            imageh = TextBox_Maxsize.Text * imageh / imagew
            imagew = TextBox_Maxsize.Text
        Else
            imagew = TextBox_Maxsize.Text * imagew / imageh
            imageh = TextBox_Maxsize.Text
        End If
        Dim image As New Bitmap(Filepath)
        Dim dpi As Integer = image.HorizontalResolution
        Dim canvas As New Bitmap(imagew, imageh)
        canvas.SetResolution(dpi, dpi)
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawImage(image, 0, 0, imagew, imageh)
        image.Dispose()
        'サムネイルの保存
        My.Computer.FileSystem.DeleteFile(Filepath)
        'PNG形式で保存する
        canvas.Save(Filepath, System.Drawing.Imaging.ImageFormat.Jpeg)
        canvas.Dispose()
        Label_Tate.Text = "縦：" & imageh
        Label_Yoko.Text = "横：" & imagew

        'プレビュー画像の表示
        Dim size As Integer = PictureBox_Main.Height
        Dim canvas2 As New Bitmap(size, size)
        Dim image2 As New Bitmap(TextBox_GazoPass.Text)
        Dim jpgwith As Integer = image2.Width
        Dim jpgheight As Integer = image2.Height
        Dim maginwith As Integer
        Dim maginheight As Integer
        If jpgwith > jpgheight Then
            jpgheight = size * jpgheight / jpgwith
            jpgwith = size
            maginwith = 0
            maginheight = (size - jpgheight) / 2
        Else
            jpgwith = size * jpgwith / jpgheight
            jpgheight = size
            maginwith = (size - jpgwith) / 2
            maginheight = 0
        End If
        Dim g2 As Graphics = Graphics.FromImage(canvas2)
        g2.DrawImage(image2, maginwith, maginheight, jpgwith, jpgheight)
        image2.Dispose()
        PictureBox_Main.Image = canvas2

    End Sub

    '「送信」ボタン押下時
    Private Sub Button_Soshin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Soshin.Click

        '送信条件が整っているか確認する（本番想定でインターネット接続を確認しています）
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = False Then
            MsgBox("ネットワークに接続されていません。")
            Exit Sub
        End If

        If TextBox_GazoPass.Text = "" Then
            MsgBox("画像を読み込んで下さい")
            Exit Sub
        End If

        '必要書誌のチェック（今後に向け）
        'If TextBox_Karimi.Text = "" Or TextBox_Cap.Text = "" Or TextBox_P.Text = "" Then
        '   MsgBox("必須項目が空白です")
        '   Exit Sub
        'End If

        '----------------------------
        '-----ここからWebAPI接続-----
        '----------------------------

        '-------------------------------------------------------------------
        '-----（参考）WebClientを使用する場合＝こちらでも疎通できました-----
        '-------------------------------------------------------------------

        ''送信するファイルのパス
        'Dim filePath As String = TextBox_GazoPass.Text

        ''送信先のURL
        'Dim url As String = "http://localhost:8080/api/file/upload"
        'Dim wc As New System.Net.WebClient

        ''データを送信し、また受信する
        'Dim resData As Byte() = wc.UploadFile(url, filePath)

        ''受信したデータを表示する
        'Dim resText As String = System.Text.Encoding.UTF8.GetString(resData)
        'Console.WriteLine(resText)


        '-----------------------------------------
        '----multipart/form-dataを使用する場合----
        '-----------------------------------------

        ''送信するファイルのパス
        'Dim filePath As String = TextBox_GazoPass.Text
        'Dim fileName As String = System.IO.Path.GetFileName(filePath)

        ''送信先のURL
        'Dim url As String = "http://localhost:8080/api/file/upload"

        ''文字コードの指定
        'Dim enc As System.Text.Encoding =
        '    System.Text.Encoding.GetEncoding("UTF-8")

        ''boundary文字列の指定
        'Dim boundary As String = System.Environment.TickCount.ToString()

        ''WebRequestの作成
        'Dim req As System.Net.HttpWebRequest =
        '    CType(System.Net.WebRequest.Create(url),
        '        System.Net.HttpWebRequest)

        ''MethodにPOSTを指定
        'req.Method = "POST"

        ''ContentTypeを設定
        'req.ContentType = "multipart/form-data; boundary=" + boundary

        ''リクエストの上部、下部を作成し、バイト型配列に変換（※改行コードの場所、数を間違えるとエラーになる）
        'Dim postData As String =
        '    "--" + boundary + vbCrLf +
        '    "Content-Disposition: form-data; name=""file""; filename=""" + fileName + """" + vbCrLf + vbCrLf
        'Dim startData As Byte() = enc.GetBytes(postData)
        'postData = vbCrLf + "--" + boundary + "--" + vbCrLf
        'Dim endData As Byte() = enc.GetBytes(postData)

        ''送信するファイルをバイト型配列に変換
        'Dim fs As New System.IO.FileStream(
        '    filePath,
        '    System.IO.FileMode.Open,
        '    System.IO.FileAccess.Read)
        'Dim br As New BinaryReader(fs)
        'Dim sendData As Byte() = br.ReadBytes(CType(fs.Length, Integer))

        'br.Close()
        'fs.Close()

        ''POST送信するデータの長さを指定
        'req.ContentLength = startData.Length + sendData.Length + endData.Length

        ''データをPOST送信するためのStreamを取得
        'Dim reqStream As System.IO.Stream = req.GetRequestStream()

        ''送信するデータを順番に書き込む
        'reqStream.Write(startData, 0, startData.Length)
        'reqStream.Write(sendData, 0, sendData.Length)
        'reqStream.Write(endData, 0, endData.Length)
        'reqStream.Close()

        ''サーバーからの応答を受信するためのWebResponseを取得
        'Dim res As System.Net.HttpWebResponse =
        '    CType(req.GetResponse(), System.Net.HttpWebResponse)

        ''応答データを受信するためのStreamを取得
        'Dim resStream As System.IO.Stream = res.GetResponseStream()

        ''受信して表示（表示しない＝不要？）
        'Dim sr As New System.IO.StreamReader(resStream, enc)
        'Console.WriteLine(sr.ReadToEnd())

        ''閉じる
        'sr.Close()

        '登録時刻
        Dim torokudate As DateTime = System.DateTime.Now
        Dim torokufolder As String = torokudate.ToString("yyyyMMddHHmmss")
        Dim torokusyoshi As String = torokudate.ToString("yyyy年M月d日tth時m分s秒")
        'ファイルサイズを取得
        Dim filename As String = System.IO.Path.GetFileName(TextBox_GazoPass.Text)
        Dim filenamewithout As String = System.IO.Path.GetFileNameWithoutExtension(TextBox_GazoPass.Text)
        Dim fileinfo As New System.IO.FileInfo(TextBox_GazoPass.Text)
        Dim filesize As String
        'Dim filesize As Long = fileinfo.Length / 1000
        If fileinfo.Length > 1000000 Then
            filesize = Format((fileinfo.Length / 1024 / 1024), "#.#0")
        Else
            filesize = Format((fileinfo.Length / 1024 / 1024), "0.#0")
        End If
        ' 画像の幅と高さの取得その２
        Dim imageh, imagew As Integer
        Dim fs As System.IO.FileStream
        ' Specify a valid picture file path on your computer.
        fs = New System.IO.FileStream(TextBox_GazoPass.Text, IO.FileMode.Open, IO.FileAccess.Read)
        imageh = System.Drawing.Image.FromStream(fs).Height
        imagew = System.Drawing.Image.FromStream(fs).Width
        fs.Close()
        Dim jikokuhlag As String = "False"
        If CheckBox_Jikoku.Checked = True Then
            jikokuhlag = "True"
        End If
        Dim mainichiflag As String = "False"
        If CheckBox_Daihyo.Checked = True Then
            mainichiflag = "True"
        End If
        Dim hairetsu As New List(Of String)
        If CheckBox_Shimen.Checked = True Then
            hairetsu.Add("01")
        End If
        If CheckBox_Web.Checked = True Then
            hairetsu.Add("02")
        End If
        If CheckBox_Viewer.Checked = True Then
            hairetsu.Add("03")
        End If
        If CheckBox_Gaihan.Checked = True Then
            hairetsu.Add("04")
        End If
        Dim dontUseTyp(hairetsu.Count - 1) As String
        If hairetsu.Count = 0 Then
            dontUseTyp = {""}
        Else
            Dim j As Integer
            For j = 0 To hairetsu.Count - 1
                dontUseTyp(j) = hairetsu(j)
            Next j
        End If
        Dim recommendFlug As Integer
        If Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch Then
            recommendFlug = 0
        Else
            recommendFlug = 1
        End If
        'json書誌の設定をし、保存する
        Dim data = New JsonItem With
                {
                .karimidashi = TextBox_Karimidashi.Text,
                .status = "済",
                .capsion1 = TextBox_Caption1.Text,
                .capsion2 = TextBox_Caption2.Text,
                .timeFlag = jikokuhlag,
                .daihyoFlag = mainichiflag,
.dontUseTyp = dontUseTyp,
                .syukkoyotei = ComboBox_Syukkoyotei.Text,
                .photographer = ComboBox_Photographer.Text,
                .phototime1 = photoTime1,
                .phototime2 = photoTime2,
                .photoplace = ComboBox_Photoplace.Text,
                .registtime = torokusyoshi,
                .recommendFlag = recommendFlug
                }
        Dim JsonFile As System.IO.StreamWriter
        My.Computer.FileSystem.CreateDirectory(curdirPath & "\data\Library\" & torokufolder)
        My.Computer.FileSystem.CopyFile(TextBox_GazoPass.Text, curdirPath & "\data\Library\" & torokufolder & "\" & filename, True)
        JsonFile = New System.IO.StreamWriter(curdirPath & "\data\Library\" & torokufolder & "\" & filenamewithout & ".json", True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()

        'サムネイルの作成
        Dim size As Integer = 250
        Dim canvas As New Bitmap(size, size)
        Dim image As New Bitmap(TextBox_GazoPass.Text)
        Dim jpgwith As Integer = image.Width
        Dim jpgheight As Integer = image.Height
        Dim maginwith As Integer
        Dim maginheight As Integer
        If jpgwith > jpgheight Then
            jpgheight = size * jpgheight / jpgwith
            jpgwith = size
            maginwith = 0
            maginheight = (size - jpgheight) / 2
        Else
            jpgwith = size * jpgwith / jpgheight
            jpgheight = size
            maginwith = (size - jpgwith) / 2
            maginheight = 0
        End If
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
        image.Dispose()
        'サムネイルの保存
        My.Computer.FileSystem.CreateDirectory(curdirPath & "\data\Library\" & torokufolder)
        canvas.Save(curdirPath & "\data\Library\" & torokufolder & "\thum" & filename)

        System.IO.File.Delete(TextBox_GazoPass.Text)
        Form_Default.ListViewReload(Form_Default.ListView_Library, curdirPath & "\data\Library\")
        Me.Close()

        MsgBox("送信が完了しました")

    End Sub

    '「外部アプリ」ボタン押下時
    Private Sub App(sender As Object, e As EventArgs) Handles Button_App.Click
        If TextBox_GazoPass.Text = "" Then
            MsgBox("画像が選択されていません")
            Exit Sub
        End If
        Dim jsonhinagata As String = curdirPath & "\setting\setsuzoku.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        'ProcessStartInfoオブジェクトを作成する
        Dim psi As New System.Diagnostics.Process()
        '起動するファイルのパスを指定する
        psi.StartInfo.FileName = jsonobj("app")
        'コマンドライン引数を指定する
        psi.StartInfo.Arguments = TextBox_GazoPass.Text
        'アプリケーションを起動する
        psi.Start()
        psi.WaitForExit()
        'プレビュー画像の表示
        Dim size As Integer = PictureBox_Main.Height
        Dim canvas As New Bitmap(size, size)
        Dim image As New Bitmap(TextBox_GazoPass.Text)
        Dim jpgwith As Integer = image.Width
        Dim jpgheight As Integer = image.Height
        Dim maginwith As Integer
        Dim maginheight As Integer
        If jpgwith > jpgheight Then
            jpgheight = size * jpgheight / jpgwith
            jpgwith = size
            maginwith = 0
            maginheight = (size - jpgheight) / 2
        Else
            jpgwith = size * jpgwith / jpgheight
            jpgheight = size
            maginwith = (size - jpgwith) / 2
            maginheight = 0
        End If
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
        image.Dispose()
        PictureBox_Main.Image = canvas
    End Sub

    '「前回書誌」ボタン被せ時
    Private Sub Button_Before_over(sender As Object, e As EventArgs) Handles Button_Before.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\zenkai.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Before, jsonobj("karimidashi") & vbCrLf & jsonobj("capsion1"))
    End Sub

    '「前回書誌」ボタン押下時
    Private Sub Button_Before_Click(sender As Object, e As EventArgs) Handles Button_Before.Click
        Dim strJsoncopy As String = curdirPath & "\setting\zenkai.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim strJsonstr As String = ""
        Dim strJsonFilepath As String = strJsoncopy
        Using sr As New System.IO.StreamReader(strJsonFilepath, enc)
            strJsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(strJsonstr)
        TextBox_Karimidashi.Text = jsonobj("karimidashi")
        TextBox_Caption1.Text = jsonobj("capsion1")
    End Sub

    '「コピー」実行時
    Private Sub CopyShoshi(sender As Object, e As EventArgs) Handles Button_Copy.Click
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("書誌（仮見出し、キャプション（Ｐ説））をコピーしますか？",
                                                         "質問",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button1)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
        Dim strJsonFilepath As String = curdirPath & "\setting\copy.json"
        My.Computer.FileSystem.DeleteFile(strJsonFilepath)
        'json書誌の設定をし、保存する
        Dim data = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimidashi.Text,
                    .capsion1 = TextBox_Caption1.Text
                    }
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(strJsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
        MsgBox("コピーしました（次回コピー時まで保持）")
    End Sub

    '「貼り付け」ボタン被せ時
    Private Sub PastShoshiPoopapp(sender As Object, e As EventArgs) Handles Button_Peast.MouseHover
        Dim jsonhinagata As String = curdirPath & "\setting\copy.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Peast, jsonobj("karimidashi") & vbCrLf & jsonobj("capsion1"))
    End Sub

    '「貼り付け」実行時
    Private Sub PastShoshi(sender As Object, e As EventArgs) Handles Button_Peast.Click
        Dim strJsoncopy As String = curdirPath & "\setting\copy.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim strJsonstr As String = ""
        Dim strJsonFilepath As String = strJsoncopy
        Using sr As New System.IO.StreamReader(strJsonFilepath, enc)
            strJsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(strJsonstr)
        TextBox_Karimidashi.Text = jsonobj("karimidashi")
        TextBox_Caption1.Text = jsonobj("capsion1")
    End Sub

    '「登録」ボタン押下時
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Toroku.Click
        'メッセージボックスを表示する 
        If TextBox_GazoPass.Text = "" Then
            MsgBox("画像を読み込んで下さい")
            Exit Sub
        End If
        '登録処理
        Form_Default.ResistPicture(TextBox_GazoPass.Text)
        Form_Default.Show()
        System.IO.Directory.Delete(curdirPath & "\data\Temp\", True)
        Form_Default.ListViewReload(Form_Default.ListView_Library, curdirPath & "\data\Library\")
        Me.Close()
    End Sub

    'キー操作の一覧
    Private Sub FormPreview_KeyAction(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles Button_SelectGazo.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.D1
                Button_Hina1.PerformClick()
            Case Keys.D2
                Button_Hina2.PerformClick()
            Case Keys.D3
                Button_Hina3.PerformClick()
            Case Keys.D4
                Button_Hina4.PerformClick()
            Case Keys.D5
                Button_Hina5.PerformClick()
            Case Keys.R
                Button_Soshin.PerformClick()
            Case Keys.A
                Button_App.PerformClick()
            Case Keys.Z
                Button_Before.PerformClick()
            Case Keys.C
                Button_Copy.PerformClick()
            Case Keys.V
                Button_Peast.PerformClick()
            Case Keys.S
                Button_Toroku.PerformClick()
        End Select
    End Sub
End Class
