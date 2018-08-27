Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Public Class Form_Preview
    Dim curdirPath As String = System.IO.Path.GetDirectoryName _
        (System.Reflection.Assembly.GetExecutingAssembly().Location) ' カレントディレクトリの取得
    'オリジナル画像保存用の変数
    Dim original As Bitmap
    Dim strPhotoTime1 As String '日付候補１の格納場所
    Dim strPhotoTime2 As String '日付候補２の格納場所
    Dim strRegistTime As String '登録時刻の格納場所
    Dim pnt As Point '仮置き

    'jsonData Class = Aigis内の書誌をまとめたJsonクラス
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

    '撮影者リストの作成
    Public Sub PhotographerList()
        ComboBox_Satsueisya.Items.Clear()
        Dim jsonFilepath As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Using sr As New System.IO.StreamReader(jsonFilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ComboBox_Satsueisya.Items.Add(jsonobj("photographer")("photographer1"))
        ComboBox_Satsueisya.Items.Add(jsonobj("photographer")("photographer2"))
        ComboBox_Satsueisya.Items.Add(jsonobj("photographer")("photographer3"))
        ComboBox_Satsueisya.Items.Add(jsonobj("photographer")("photographer4"))
        ComboBox_Satsueisya.Text = ComboBox_Satsueisya.Items.Item(0)
    End Sub

    '撮影場所リストの作成
    Public Sub PhotoplaceList()
        ComboBox_Satsueibasyo.Items.Clear()
        Dim jsonFilepath As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Using sr As New System.IO.StreamReader(jsonFilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ComboBox_Satsueibasyo.Items.Add(jsonobj("photoplace")("photoplace1"))
        ComboBox_Satsueibasyo.Items.Add(jsonobj("photoplace")("photoplace2"))
        ComboBox_Satsueibasyo.Items.Add(jsonobj("photoplace")("photoplace3"))
        ComboBox_Satsueibasyo.Items.Add(jsonobj("photoplace")("photoplace4"))
        ComboBox_Satsueibasyo.Text = ComboBox_Satsueibasyo.Items.Item(0)
    End Sub

    '出稿予定リストの作成
    Public Sub SyukkoyoteiList()
        ComboBox_Syukkoyotei.Items.Clear()
        Dim jsonFilepath As String = curdirPath & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Using sr As New System.IO.StreamReader(jsonFilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ComboBox_Syukkoyotei.Items.Add(jsonobj("syukkoyotei")("syukkoyotei1"))
        ComboBox_Syukkoyotei.Items.Add(jsonobj("syukkoyotei")("syukkoyotei2"))
        ComboBox_Syukkoyotei.Items.Add(jsonobj("syukkoyotei")("syukkoyotei3"))
        ComboBox_Syukkoyotei.Items.Add(jsonobj("syukkoyotei")("syukkoyotei4"))
        ComboBox_Syukkoyotei.Text = ComboBox_Syukkoyotei.Items.Item(0)
    End Sub

    '書誌の表示設定
    Public Sub Shoshichange()
        '＝＝＝Json絡みの設定＝＝＝
        Dim Filename As String
        If Form_Default.TabControl1.SelectedIndex = 0 Then
            Filename = Form_Default.ListView_Library.SelectedItems(0).ImageKey
        ElseIf Form_Default.TabControl1.SelectedIndex = 2 Then
            Filename = Form_Default.ListView_Keepfile.SelectedItems(0).ImageKey
        End If
        Dim Filenamewithout As String = System.IO.Path.GetFileNameWithoutExtension(Filename)
        Dim dire As String = System.IO.Path.GetDirectoryName(Filename)
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonStr As String = ""
        Dim jsonFilePath As String = dire & "\" & Filenamewithout & ".json"
        'ファイルからJson文字列を読み込む
        Using sr As New System.IO.StreamReader(jsonFilePath, enc)
            jsonStr = sr.ReadToEnd()
        End Using
        'Json文字列をJson形式データに復元する
        Dim jsonObj As Object = JsonConvert.DeserializeObject(jsonStr)
        '＝＝＝Json絡みの設定(ここまで)＝＝＝
        TextBox_Karimi.Text = jsonObj("karimidashi")
        TextBox_CapP.Text = jsonObj("capsion1")
        If jsonObj("timeFlag") = "True" Then
            CheckBox_Jikoku.Checked = True
        Else
            CheckBox_Jikoku.Checked = False
        End If
        If jsonObj("daihyoFlag") = "True" Then
            CheckBox_Mainichi.Checked = True
        Else
            CheckBox_Mainichi.Checked = False
        End If
        TextBox_CapHN.Text = jsonObj("capsion2")
        If jsonObj("dontUseTyp").ToString.Contains("01") Then
            CheckBox_Shimen.Checked = True
        End If
        If jsonObj("dontUseTyp").ToString.Contains("02") Then
            CheckBox_Web.Checked = True
        End If
        If jsonObj("dontUseTyp").ToString.Contains("03") Then
            CheckBox_Viewer.Checked = True
        End If
        If jsonObj("dontUseTyp").ToString.Contains("04") Then
            CheckBox_Gaihan.Checked = True
        End If
        'ファイルサイズを取得
        Dim fileinfo As New System.IO.FileInfo(Filename)
        Dim filesize As String
        If fileinfo.Length > 1000000 Then
            filesize = Format((fileinfo.Length / 1024 / 1024), "#.#0")
        Else
            filesize = Format((fileinfo.Length / 1024 / 1024), "0.#0")
        End If
        ' 画像の幅と高さの取得その２
        Dim imageh, imagew As Integer
        Dim fs As System.IO.FileStream
        fs = New System.IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read)
        imageh = System.Drawing.Image.FromStream(fs).Height
        imagew = System.Drawing.Image.FromStream(fs).Width
        fs.Close()
        ComboBox_Syukkoyotei.Text = jsonObj("syukkoyotei")
        ComboBox_Satsueisya.Text = jsonObj("photographer")
        TextBox_Satsueijikoku.Text = jsonObj("phototime1")
        ComboBox_Satsueibasyo.Text = jsonObj("photoplace")
        Label_filesize.Text = "ファイルサイズ：" & filesize & "MB"
        Label_tate.Text = "縦：" & imageh
        Label_yoko.Text = "横：" & imagew
        strPhotoTime1 = jsonObj("phototime1")
        strPhotoTime2 = jsonObj("phototime2")
        strRegistTime = jsonObj("registtime")
        If jsonObj("recommendFlag") = 0 Then
            Button_Recommend.BackgroundImage = System.Drawing.Image.FromFile(curdirPath & "\data\Icon\whitestar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
        Else
            Button_Recommend.BackgroundImage = System.Drawing.Image.FromFile(curdirPath & "\data\Icon\yellowstar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Zoom
        End If
        If Form_Default.TabControl1.SelectedIndex = 0 Then
            If Form_Default.ListView_Library.SelectedItems(0).BackColor = Color.Yellow Then
                Panel_Syoshi.BackColor = Color.Yellow
            Else
                Panel_Syoshi.BackColor = Color.FromKnownColor(KnownColor.ControlLight)
            End If
        ElseIf Form_Default.TabControl1.SelectedIndex = 2 Then
            Panel_Syoshi.BackColor = Color.FromKnownColor(KnownColor.ControlLight)
        End If
    End Sub

    Private Sub Review()
        Shoshichange()
        Dim listview As ListView = Form_Default.ListView_Library
        If Form_Default.TabControl1.SelectedIndex = 2 Then
            listview = Form_Default.ListView_Keepfile
        End If
        Dim tatesize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        Dim yokosize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Panel1.Height = tatesize
        Panel1.Width = yokosize
        Panel1.Location = New Point(0, 0)
        PictureBox1.Height = tatesize
        PictureBox1.Width = yokosize
        PictureBox1.Location = New Point(0, 0)
        Panel_Oya.Location = New Point(yokosize - 500, tatesize - 450)
        Button_Before.Location = New Point(10, tatesize / 2)
        Button_After.Location = New Point(yokosize - 60, tatesize / 2)
        Button_Kirikae.Location = New Point(yokosize - 85, 15)
        Dim canvas As New Bitmap(yokosize, tatesize)
        Dim image As New Bitmap(listview.SelectedItems(0).ImageKey)
        Dim jpgwith As Integer = image.Width
        Dim jpgheight As Integer = image.Height
        Dim maginwith As Integer
        Dim maginheight As Integer
        If jpgwith / jpgheight > yokosize / tatesize Then
            jpgheight = jpgheight * yokosize / jpgwith
            jpgwith = yokosize
            maginwith = 0
            maginheight = (tatesize - jpgheight) / 2
        Else
            jpgwith = jpgwith * tatesize / jpgheight
            jpgheight = tatesize
            maginwith = (yokosize - jpgwith) / 2
            maginheight = 0
        End If
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
        image.Dispose()
        PictureBox1.Image = canvas
        Label_Total1.Text = listview.Items.Count
        Label_Select1.Text = listview.SelectedItems(0).Index + 1
        Dim j As Integer = Label_Select1.Text - 1
        Form_Default.ListView_Library.SelectedItems.Clear()
        Form_Default.ListView_Library.Items(j).Selected = True
    End Sub

    'フォーム起動時の動作
    Private Sub FormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Label_Status.Location = New Point(0, 0)
        Label_Gide.Location = New Point(0, 25)
        PhotographerList()
        PhotoplaceList()
        SyukkoyoteiList()
        Review()
    End Sub

    'マウスのクリック（右クリック）操作設定
    Private Sub MouseControl(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Right And Label_Status.Text = "通常表示" Then
            original = PictureBox1.Image
            Dim canvas As New Bitmap(PictureBox1.Width * 2, PictureBox1.Height * 2)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim img As Bitmap = PictureBox1.Image
            PictureBox1.Width = PictureBox1.Width * 2
            PictureBox1.Height = PictureBox1.Height * 2
            g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
            'Graphicsオブジェクトのリソースを解放する
            g.Dispose()
            'PictureBox1に表示する
            PictureBox1.Image = canvas
            Label_Status.Text = "拡大表示"
            Panel_Oya.Visible = False
            Button_After.Visible = False
            Button_Before.Visible = False
            Button_Kirikae.Visible = False
        ElseIf e.Button = MouseButtons.Right Then
            If Label_Status.Text = "通常表示" Then
                Exit Sub
            End If
            PictureBox1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
            PictureBox1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            PictureBox1.Image = original
            Label_Status.Text = "通常表示"
            Button_After.Visible = True
            Button_Before.Visible = True
            Button_Kirikae.Visible = True
        End If
    End Sub

    'マウスのダブルクリック操作設定
    Public Sub DoubleClickControl(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim i As Integer = Label_Select1.Text - 1
            If Form_Default.TabControl1.SelectedIndex = 0 Then
                Form_Default.ListView_Library.Items(i).Selected = True
            Else
                Form_Default.ListView_Keepfile.Items(i).Selected = True
            End If
            Me.Close()
        End If
    End Sub

    '前画像表示
    Private Sub BeforePhoto(sender As Object, e As EventArgs) Handles Button_Before.Click
        Dim tatesize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        Dim yokosize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim canvas As New Bitmap(yokosize, tatesize)
        Dim No As Integer = Label_Select1.Text - 1
        If No = 0 Then
            No = Label_Total1.Text
        End If
        Dim image As Bitmap
        If Form_Default.TabControl1.SelectedIndex = 0 Then
            image = New Bitmap(Form_Default.ListView_Library.Items(No - 1).ImageKey)
            Form_Default.ListView_Library.SelectedItems.Clear()
            Form_Default.ListView_Library.Items(No - 1).Selected = True
        Else
            image = New Bitmap(Form_Default.ListView_Keepfile.Items(No - 1).ImageKey)
            Form_Default.ListView_Keepfile.SelectedItems.Clear()
            Form_Default.ListView_Keepfile.Items(No - 1).Selected = True
        End If
        Dim jpgwith As Integer = image.Width
            Dim jpgheight As Integer = image.Height
            Dim maginwith As Integer
            Dim maginheight As Integer
            If jpgwith / jpgheight > yokosize / tatesize Then
                jpgheight = jpgheight * yokosize / jpgwith
                jpgwith = yokosize
                maginwith = 0
                maginheight = (tatesize - jpgheight) / 2
            Else
                jpgwith = jpgwith * tatesize / jpgheight
                jpgheight = tatesize
                maginwith = (yokosize - jpgwith) / 2
                maginheight = 0
            End If
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
            image.Dispose()
            PictureBox1.Image = canvas
            Label_Select1.Text = No
        'Index = No - 1
        Shoshichange()
    End Sub

    '後画像表示
    Private Sub AfterPhoto(sender As Object, e As EventArgs) Handles Button_After.Click
        Dim tatesize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        Dim yokosize As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim canvas As New Bitmap(yokosize, tatesize)
        Dim No As Integer = Label_Select1.Text
        If No = Label_Total1.Text Then
            No = 0
        End If
        Dim image As Bitmap
        If Form_Default.TabControl1.SelectedIndex = 0 Then
            image = New Bitmap(Form_Default.ListView_Library.Items(No).ImageKey)
            Form_Default.ListView_Library.SelectedItems.Clear()
            Form_Default.ListView_Library.Items(No).Selected = True
        Else
            image = New Bitmap(Form_Default.ListView_Keepfile.Items(No).ImageKey)
            Form_Default.ListView_Keepfile.SelectedItems.Clear()
            Form_Default.ListView_Keepfile.Items(No).Selected = True
        End If
        Dim jpgwith As Integer = image.Width
        Dim jpgheight As Integer = image.Height
        Dim maginwith As Integer
        Dim maginheight As Integer
        If jpgwith / jpgheight > yokosize / tatesize Then
            jpgheight = jpgheight * yokosize / jpgwith
            jpgwith = yokosize
            maginwith = 0
            maginheight = (tatesize - jpgheight) / 2
        Else
            jpgwith = jpgwith * tatesize / jpgheight
            jpgheight = tatesize
            maginwith = (yokosize - jpgwith) / 2
            maginheight = 0
        End If
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
        image.Dispose()
        PictureBox1.Image = canvas
        Label_Select1.Text = No + 1
        Shoshichange()
    End Sub

    'プレビュー項目の表示切り替え
    Private Sub PreviewCange(sender As Object, e As EventArgs) Handles Button_Kirikae.Click
        If Panel_Oya.Visible = True Then
            Panel_Oya.Visible = False
        Else
            Panel_Oya.Visible = True
        End If
    End Sub

    '上書き保存時
    Private Sub Button_Hozon_Click(sender As Object, e As EventArgs) Handles Button_Hozon.Click
        If Form_Default.TabControl1.SelectedIndex = 0 Then
            '＝＝＝Json絡みの設定＝＝＝
            Dim Filename As String = Form_Default.ListView_Library.SelectedItems(0).ImageKey
            Dim Filenamewithout As String = System.IO.Path.GetFileNameWithoutExtension(Filename)
            Dim dire As String = System.IO.Path.GetDirectoryName(Filename)
            Dim enc As Encoding = Encoding.UTF8
            Dim jsonStr As String = ""
            Dim jsonFilePath As String = dire & "\" & Filenamewithout & ".json"
            ''＝＝＝Json絡みの設定(ここまで)＝＝＝
            My.Computer.FileSystem.DeleteFile(jsonFilePath)
            Dim jikokuhlag As String = "False"
            If CheckBox_Jikoku.Checked = True Then
                jikokuhlag = "True"
            End If
            Dim mainichiflag As String = "False"
            If CheckBox_Mainichi.Checked = True Then
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
            Dim status As String
            If Form_Default.ListView_Library.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
                status = "済"
            Else
                status = "未"
            End If
            'json書誌の設定をし、保存する
            Dim data = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimi.Text,
                    .status = status,
                    .capsion1 = TextBox_CapP.Text,
                    .capsion2 = TextBox_CapHN.Text,
                    .timeFlag = jikokuhlag,
                    .daihyoFlag = mainichiflag,
.dontUseTyp = dontUseTyp,
                    .syukkoyotei = ComboBox_Syukkoyotei.Text,
                    .photographer = ComboBox_Satsueisya.Text,
                    .phototime1 = strPhotoTime1,
                    .phototime2 = strPhotoTime2,
                    .photoplace = ComboBox_Satsueibasyo.Text,
                    .registtime = strRegistTime,
                    .recommendFlag = recommendFlug
                    }
            Dim JsonFile As System.IO.StreamWriter
            JsonFile = New System.IO.StreamWriter(jsonFilePath, True, System.Text.Encoding.UTF8)
            JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
            Form_Default.ListView_Library.SelectedItems(0).Text = status & "/【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & strRegistTime
            JsonFile.Close()
        Else
            '＝＝＝Json絡みの設定＝＝＝
            Dim Filename As String = Form_Default.ListView_Keepfile.SelectedItems(0).ImageKey
            Dim Filenamewithout As String = System.IO.Path.GetFileNameWithoutExtension(Filename)
            Dim dire As String = System.IO.Path.GetDirectoryName(Filename)
            Dim enc As Encoding = Encoding.UTF8
            Dim jsonStr As String = ""
            Dim jsonFilePath As String = dire & "\" & Filenamewithout & ".json"
            ''＝＝＝Json絡みの設定(ここまで)＝＝＝
            My.Computer.FileSystem.DeleteFile(jsonFilePath)
            Dim jikokuhlag As String = "False"
            If CheckBox_Jikoku.Checked = True Then
                jikokuhlag = "True"
            End If
            Dim mainichiflag As String = "False"
            If CheckBox_Mainichi.Checked = True Then
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
            Dim status As String
            If Form_Default.ListView_Library.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
                status = "済"
            Else
                status = "未"
            End If
            'json書誌の設定をし、保存する
            Dim data = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimi.Text,
                    .status = status,
                    .capsion1 = TextBox_CapP.Text,
                    .capsion2 = TextBox_CapHN.Text,
                    .timeFlag = jikokuhlag,
                    .daihyoFlag = mainichiflag,
.dontUseTyp = dontUseTyp,
                    .syukkoyotei = ComboBox_Syukkoyotei.Text,
                    .photographer = ComboBox_Satsueisya.Text,
                    .phototime1 = strPhotoTime1,
                    .phototime2 = strPhotoTime2,
                    .photoplace = ComboBox_Satsueibasyo.Text,
                    .registtime = strRegistTime,
                    .recommendFlag = recommendFlug
                    }
            Dim JsonFile As System.IO.StreamWriter
            JsonFile = New System.IO.StreamWriter(jsonFilePath, True, System.Text.Encoding.UTF8)
            JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
            Form_Default.ListView_Keepfile.SelectedItems(0).Text = status & "/【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & strRegistTime
            JsonFile.Close()
        End If
    End Sub

    Private Sub Button_Queue_Click(sender As Object, e As EventArgs) Handles Button_Queue.Click
        If Form_Default.ListView_Library.SelectedItems(0).BackColor = Color.Yellow Then
            MsgBox("キュー登録されています")
            Exit Sub
        End If
        Form_Default.ListView_Library.SelectedItems(0).BackColor = Color.Yellow
        Form_Default.ListBox_Queue.Items.Add("【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & strRegistTime & "　［ファイルパス］" & Form_Default.ListView_Library.SelectedItems(0).ImageKey)
        Shoshichange()
    End Sub

    '「年月日のみ表示」チェック時
    Private Sub PhototimeCheck(sender As Object, e As EventArgs) Handles CheckBox_Jikoku.CheckedChanged
        If CheckBox_Mainichi.Checked = True Then
            If CheckBox_Jikoku.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime2 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime1 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            End If
        Else
            If CheckBox_Jikoku.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime2 & ComboBox_Satsueisya.Text & "撮影"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime1 & ComboBox_Satsueisya.Text & "撮影"
            End If
        End If
    End Sub

    '「毎日新聞」チェック時
    Private Sub CheckBox_Mainichi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Mainichi.CheckedChanged
        If CheckBox_Jikoku.Checked = True Then
            If CheckBox_Mainichi.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime2 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime2 & ComboBox_Satsueisya.Text & "撮影"
            End If
        Else
            If CheckBox_Mainichi.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime1 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Satsueibasyo.Text & "で、" & strPhotoTime1 & ComboBox_Satsueisya.Text & "撮影"
            End If
        End If
    End Sub

    Private Sub Button_RecommendClick(sender As Object, e As EventArgs) Handles Button_Recommend.Click
        If Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch Then
            Button_Recommend.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\yellowstar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Zoom
        Else
            Button_Recommend.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\whitestar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Private Sub BtnSizeChange_Click(sender As Object, e As EventArgs) Handles BtnSizeChange.Click
        If TextBox_Maxsize.Text = "" Then
            MsgBox("サイズを指定して下さい")
            Exit Sub
        End If
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("リサイズしてよろしいですか？",
                                                         "リサイズ",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button2)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
        Dim Filepath As String = Form_Default.ListView_Library.SelectedItems(0).ImageKey
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
        My.Computer.FileSystem.DeleteFile(Filepath)
        canvas.Save(Filepath, System.Drawing.Imaging.ImageFormat.Jpeg)
        canvas.Dispose()

        'サムネイルの作成
        Dim thamname As String = System.IO.Path.GetFileName(Filepath)
        Dim thamdirepath As String = System.IO.Path.GetDirectoryName(Filepath)
        Dim thamfilepath As String = thamdirepath & "\thum" & thamname
        Dim size As Integer = 250
        Dim canvas2 As New Bitmap(size, size)
        Dim image2 As New Bitmap(Filepath)
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
        'サムネイルの保存
        My.Computer.FileSystem.DeleteFile(thamfilepath)
        canvas2.Save(thamfilepath)
        Review()
    End Sub

    Private Sub FormPreview_KeyAction(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles _
            Button_Before.PreviewKeyDown, Button_After.PreviewKeyDown, Button_Kirikae.PreviewKeyDown, Button_Hozon.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Dim i As Integer = Label_Select1.Text - 1
                If Form_Default.TabControl1.SelectedIndex = 0 Then
                    Form_Default.ListView_Library.Items(i).Selected = True
                Else
                    Form_Default.ListView_Keepfile.Items(i).Selected = True
                End If
                Me.Close()
            Case Keys.Left
                Button_Before.PerformClick()
            Case Keys.Right
                Button_After.PerformClick()
        End Select
    End Sub

End Class