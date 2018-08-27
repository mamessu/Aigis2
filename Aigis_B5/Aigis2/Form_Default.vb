'20180504 Kubo プロトタイプ完成
'jsonデータのシリアライズ、デシリアライズにはJson.net(Newtonsoft.Json)を使用
Imports System
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports Shell32
Imports Newtonsoft.Json

Public Class Form_Default

    'Form_Defaultクラスでの共有変数を宣言
    Private CPath As String = System.IO.Path.GetDirectoryName _
        (System.Reflection.Assembly.GetExecutingAssembly().Location) 'カレントパスを取得
    Private photoTime1 As String
    Private photoTime2 As String
    Private viewSize As Integer
    Friend WithEvents TabPage3 As New TabPage()
    Friend WithEvents ListView_Keepfile As New ListView()

    '並び替えに使用するクラス（各Itemの指定されたカラムを比べ並べ変える）
    Public Class ListViewItemComparer
        Implements IComparer
        Private _column As Integer
        Private _order As SortOrder
        Public Sub New(ByVal col As Integer)
            _column = col
        End Sub
        'xがyより小さいときはマイナスの数、大きいときはプラスの数、
        '同じときは0を返す
        Public Function Compare(ByVal x As Object, ByVal y As Object) _
            As Integer Implements System.Collections.IComparer.Compare
            'ListViewItemの取得
            Dim itemx As ListViewItem = CType(x, ListViewItem)
            Dim itemy As ListViewItem = CType(y, ListViewItem)
            'xとyを文字列として比較する
            Dim result As Integer = 0
            result = String.Compare(itemx.SubItems(_column).Text,
            itemy.SubItems(_column).Text)
            If Form_Default.Button_Soat.Text = "降順" Then
                _order = SortOrder.Descending
            ElseIf Form_Default.Button_Soat.Text = "昇順" Then
                _order = SortOrder.Ascending
            End If
            'MsgBox(result)
            '降順の時は結果を+-逆にする
            If _order = SortOrder.Descending Then
                result = -result
            End If
            '結果を返す
            Return result
        End Function
    End Class

    'JsonItemクラス = アプリで表示する書誌を定義したクラス
    Private Class JsonItem
        Public Property karimidashi As String
        Public Property status As String
        Public Property capsion1 As String
        Public Property capsion2 As String
        Public Property timeFlag As String
        Public Property daihyoFlag As String
        Public Property dontUseTyp As String()
        Public Property syukkoyotei As String
        Public Property photographer As String
        Public Property phototime1 As String
        Public Property phototime2 As String
        Public Property photoplace As String
        Public Property registtime As String
        Public Property recommendFlag As String
    End Class

    'フォーム起動時
    Private Sub FormDefaultLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ListViewReload(ListView_Library, CPath & "\data\Library\")
        KeepfolderReload()
        ListUpdate()
        LoginUser()
        ComboBox_Size.Items.AddRange({"小", "中", "大"})
        ComboBox_Sort.Items.AddRange({"登録時刻", "出稿予定", "仮見出し", "ステータス"})
        Label_ListGazo.Text = (ImageList_Library.Images.Count & "個の画像")
        Label_SelectGazo.Text = "0" & "個を選択中"
    End Sub

    'ListViewの更新(ListView_LibraryとListView_Keepfileの更新)
    Public Sub ListViewReload(ByVal Listview As Object, ByVal Path As String)
        'Listview初期化
        Listview.Clear()
        'サムネイル縦横サイズの指定
        SizeSetting()
        'サムネイル画像をImageListに追加し、ListView_Libraryに並べる
        ImageList_Library = New ImageList
        ImageList_Library.ImageSize = New Size(viewSize, viewSize)
        ImageList_Library.ColorDepth = ColorDepth.Depth16Bit
        Listview.LargeImageList = ImageList_Library
        If Listview.Equals(ListView_Keepfile) Then
            TabPage3.Controls.Add(Listview)
            Listview.Size = New Size(676, 580)
            Listview.Location = New Point(3, 4)
            Listview.HideSelection = False
            Listview.Cursor = System.Windows.Forms.Cursors.Hand
        End If
        For Each jsonFilepath As String In
            System.IO.Directory.GetFiles(Path, "*.json", SearchOption.AllDirectories)
            Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(jsonFilepath),
                parentDirepath As String = System.IO.Path.GetDirectoryName(jsonFilepath),
                imageFilepath As String = parentDirepath & "\" & filename & ".jpg",
                thumFilepath As String = parentDirepath & "\thum" & filename & ".jpg",
                jsonstr As String
            Using sr As New System.IO.StreamReader(jsonFilepath, Encoding.UTF8)
                jsonstr = sr.ReadToEnd()
            End Using
            Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
            Dim listviewText As String = jsonobj("status") & "/【" & jsonobj("syukkoyotei") & "】" & jsonobj("karimidashi") & "/" & jsonobj("registtime")
            Dim canvas As New Bitmap(viewSize, viewSize)
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim img As Image = Image.FromFile(thumFilepath)
            g.DrawImage(img, 0, 0, viewSize, viewSize)
            img.Dispose()
            g.Dispose()
            ImageList_Library.Images.Add(imageFilepath, canvas)
            Dim itemx As New ListViewItem
            itemx.Text = listviewText
            itemx.ImageKey = imageFilepath
            '並べ替えで使用する項目を各カラムに挿入
            itemx.SubItems.Add(jsonobj("status"))
            itemx.SubItems.Add(jsonobj("syukkoyotei"))
            itemx.SubItems.Add(jsonobj("karimidashi"))
            itemx.SubItems.Add(jsonobj("registtime"))
            Listview.Items.Add(itemx)
        Next
        '送稿ステータスとキュー登録の有無により背景色を指定
        For Each listviewItem As ListViewItem In Listview.Items
            If listviewItem.Text.StartsWith("未") Then
                listviewItem.BackColor = Color.FromKnownColor(KnownColor.Window)
            ElseIf listviewItem.Text.StartsWith("済") Then
                listviewItem.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            End If
            Dim count As Integer = ListBox_Queue.Items.Count
            Dim i As Integer
            For i = 0 To count - 1
                Dim NameArray As String() = Split(ListBox_Queue.Items(i), "　［ファイルパス］")
                If listviewItem.ImageKey = NameArray(1) Then
                    listviewItem.BackColor = Color.Yellow
                End If
            Next i
        Next
        Changeitems(Listview)
    End Sub

    'ListView_Keepfolderの更新
    Public Sub KeepfolderReload()
        ListView_Keepfolder.Clear() 'Listview初期化
        SizeSetting() 'サムネイル縦横サイズの指定
        'フォルダアイコンをImageListに追加し、ListView_Libraryに並べる
        ImageList_Keepfolder = New ImageList
        ImageList_Keepfolder.ImageSize = New Size(viewSize, viewSize)
        ImageList_Keepfolder.ColorDepth = ColorDepth.Depth16Bit
        ListView_Keepfolder.LargeImageList = ImageList_Keepfolder
        For Each keepDirepath As String In
                System.IO.Directory.GetDirectories(CPath & "\data\KeepList\", "*", SearchOption.TopDirectoryOnly)
            Dim keepFilename As String = System.IO.Path.GetFileName(keepDirepath)
            Dim canvas As New Bitmap(viewSize, viewSize)
            Dim image As New Bitmap(CPath & "\data\Icon\folder.jpg")
            Dim fileWith As Integer = image.Width
            Dim fileHeight As Integer = image.Height
            Dim maginWith As Integer
            Dim maginHeight As Integer
            If fileWith > fileHeight Then
                fileHeight = viewSize * fileHeight / fileWith
                fileWith = viewSize
                maginWith = 0
                maginHeight = (viewSize - fileHeight) / 2
            Else
                fileWith = viewSize * fileWith / fileHeight
                fileHeight = viewSize
                maginWith = (viewSize - fileWith) / 2
                maginHeight = 0
            End If
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.DrawImage(image, maginWith, maginHeight, fileWith, fileHeight)
            ImageList_Keepfolder.Images.Add(keepDirepath, canvas)
            ListView_Keepfolder.Items.Add(keepFilename, keepDirepath)
            g.Dispose()
            image.Dispose()
        Next
    End Sub

    'ComboBox_Sizeの選択肢によってサムネイル縦横サイズを決定する
    Public Sub SizeSetting()
        If ComboBox_Size.Text = "小" Then
            viewSize = 70
        ElseIf ComboBox_Size.Text = "中" Then
            viewSize = 130
        ElseIf ComboBox_Size.Text = "大" Then
            viewSize = 220
        End If
    End Sub

    'Loadingバーの表示を開始
    Public Sub LoadingStart()
        ProgressBar_Loading.Visible = True
        Label_Loading.Visible = True
    End Sub

    'Loadingバーの表示を終了
    Public Sub LoadingEnd()
        ProgressBar_Loading.Visible = False
        Label_Loading.Visible = False
    End Sub

    '降順、昇順に並べ変える
    Private Sub Button_Soat_Click(sender As Object, e As EventArgs) Handles Button_Soat.Click
        If Button_Soat.Text = "降順" Then
            Button_Soat.Text = "昇順"
        ElseIf Button_Soat.Text = "昇順" Then
            Button_Soat.Text = "降順"
        End If
        If TabControl1.SelectedIndex = 0 Then
            Changeitems(ListView_Library)
        ElseIf TabControl1.SelectedIndex = 2 Then
            Changeitems(ListView_Keepfile)
        End If
    End Sub

    '比べるカラムを選択
    Private Sub Changeitems(seder As Object)
        If ComboBox_Sort.Text = "ステータス" Then
            ListView_Library.ListViewItemSorter =
                New ListViewItemComparer(1)
        ElseIf ComboBox_Sort.Text = "出稿予定" Then
            ListView_Library.ListViewItemSorter =
                New ListViewItemComparer(2)
        ElseIf ComboBox_Sort.Text = "仮見出し" Then
            ListView_Library.ListViewItemSorter =
                New ListViewItemComparer(3)
        ElseIf ComboBox_Sort.Text = "登録時刻" Then
            ListView_Library.ListViewItemSorter =
                New ListViewItemComparer(4)
        End If
    End Sub

    'setting.jsonから各リストのItemを反映、デフォルト書誌の反映
    Public Sub ListUpdate()
        Dim jsonFilepath As String = CPath & "\setting\setting.json", jsonstr As String
        Using sr As New System.IO.StreamReader(jsonFilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        '撮影者リストの反映
        ComboBox_Satsueisya.Items.Clear()
        ComboBox_Satsueisya.Items.AddRange({jsonobj("photographer")("photographer1"), jsonobj("photographer")("photographer2"),
                                           jsonobj("photographer")("photographer3"), jsonobj("photographer")("photographer4")})
        ComboBox_Satsueisya.Text = ComboBox_Satsueisya.Items.Item(0)
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
        TextBox_Karimi.Text = jsonobj("hinagatadefo")("karimidashi")
        TextBox_CapP.Text = jsonobj("hinagatadefo")("karimidashi")
    End Sub

    'setsuzoku.jsonからログインユーザ情報を画面上に反映
    Public Sub LoginUser()
        Dim jsonShoshi As String = CPath & "\setting\setsuzoku.json", jsonstr As String
        Using sr As New System.IO.StreamReader(jsonShoshi, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolStripButton_Teamlabel.Text = jsonobj("Teamlabel")
        ToolStripLabel_Loginuser.Text = jsonobj("Syainid") & " " & jsonobj("Syainmei")
        Dim monitor As String = jsonobj("Monitor")
        If monitor.Length < 40 Then
            ToolStripLabel_Monitor.Text = "監視先フォルダ：" & monitor
        Else
            ToolStripLabel_Monitor.Text = "監視先フォルダ：・・・"
            ToolStripLabel_Monitor.ToolTipText = jsonobj("Monitor")
        End If
    End Sub

    'ListView_LibraryにD&Dする動作をコピーに指定
    Public Sub DragCopy(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListView_Library.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    '書誌クリア
    Public Sub ClearShoshi()
        TextBox_Karimi.Text = ""
        TextBox_CapP.Text = ""
        CheckBox_Jikoku.Checked = False
        CheckBox_Mainichi.Checked = False
        CheckBox_Shimen.Checked = False
        CheckBox_Web.Checked = False
        CheckBox_Viewer.Checked = False
        CheckBox_Gaihan.Checked = False
        TextBox_CapHN.Text = ""
        TextBox_Satsueijikoku.Text = ""
        TextBox_Maxsize.Text = ""
        Label_filesize.Text = "ファイルサイズ："
        Label_tate.Text = "縦："
        Label_yoko.Text = "横："
        Label_SelectGazo.Text = "0個を選択中"
        PictureBox1.Image = Nothing
        Button_Recommend.BackgroundImage = System.Drawing.Image.FromFile(CPath & "\data\Icon\whitestar.png")
        Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    '「更新」ボタン押下時
    Private Sub ReloadButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Reload.Click
        ListViewReload(ListView_Library, CPath & "\data\Library\")
        ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
        KeepfolderReload()
        ClearShoshi()
    End Sub

    'サムネイル縦横サイズ変更時にListViewをリロード
    Private Sub SizeChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Size.SelectedIndexChanged
        ListViewReload(ListView_Library, CPath & "\data\Library\")
        ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
        KeepfolderReload()
        ListView_Library.Select()
    End Sub

    'ライブラリ、保管庫で選択されている画像の書誌を表示
    Private Sub SelectLibraryImage(sender As ListView, ByVal e As System.EventArgs) Handles ListView_Library.SelectedIndexChanged, ListView_Keepfile.SelectedIndexChanged
        Dim count As Integer = sender.SelectedItems.Count
        If count = 0 Then
            ClearShoshi()
            Exit Sub
        End If
        Label_SelectGazo.Text = (count & "個を選択中")
        Dim imageFilepath As String = sender.SelectedItems(0).ImageKey
        Dim imageFilename As String = System.IO.Path.GetFileName(imageFilepath)
        Dim filenameWithout As String = System.IO.Path.GetFileNameWithoutExtension(imageFilepath)
        Dim parentDirepath As String = System.IO.Path.GetDirectoryName(imageFilepath)
        Dim jsonStr As String = ""
        Dim jsonFilePath As String = parentDirepath & "\" & filenameWithout & ".json"
        'ファイルからJson文字列を読み込む
        Using sr As New System.IO.StreamReader(jsonFilePath, Encoding.UTF8)
            jsonStr = sr.ReadToEnd()
        End Using
        'Json文字列をJson形式データに復元する
        Dim jsonObj As Object = JsonConvert.DeserializeObject(jsonStr)
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
        Dim fileinfo As New System.IO.FileInfo(imageFilepath)
        Dim filesize As String
        If fileinfo.Length > 1000000 Then
            filesize = Format((fileinfo.Length / 1024 / 1024), "#.#0")
        Else
            filesize = Format((fileinfo.Length / 1024 / 1024), "0.#0")
        End If

        '画像の幅と高さの取得
        Dim imageh, imagew As Integer
        Dim fs As System.Drawing.Image = System.Drawing.Image.FromFile(imageFilepath)
        imageh = fs.Height
        imagew = fs.Width
        fs.Dispose()

        ComboBox_Syukkoyotei.Text = jsonObj("syukkoyotei")
        ComboBox_Satsueisya.Text = jsonObj("photographer")
        TextBox_Satsueijikoku.Text = jsonObj("phototime1")
        ComboBox_Photoplace.Text = jsonObj("photoplace")
        Label_filesize.Text = "ファイルサイズ：" & filesize & "MB"
        Label_tate.Text = "縦：" & imageh
        Label_yoko.Text = "横：" & imagew
        photoTime1 = jsonObj("phototime1")
        photoTime2 = jsonObj("phototime2")
        sender.SelectedItems(0).SubItems(4).Text = jsonObj("registtime")
        If jsonObj("recommendFlag") = 0 Then
            Button_Recommend.BackgroundImage = System.Drawing.Image.FromFile(CPath & "\data\Icon\whitestar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
        Else
            Button_Recommend.BackgroundImage = System.Drawing.Image.FromFile(CPath & "\data\Icon\yellowstar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Zoom
        End If
        'プレビュー画像の表示
        Dim size As Integer = 250
        Dim canvas As New Bitmap(size, size)
        Dim image As New Bitmap(parentDirepath & "\thum" & imageFilename)
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
        PictureBox1.Image = canvas
    End Sub

    'ライブラリ画像を右クリックでキューに追加
    Public Sub AddQueue(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView_Library.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                ListBox_Queue.SelectedItems.Clear()
            Case MouseButtons.Right
                'キュー登録済みなら抜ける
                If ListView_Library.SelectedItems(0).BackColor = Color.Yellow Then
                    MsgBox("キュー登録されています。")
                    Exit Sub
                    '送信済みステータスなら抜け
                ElseIf ListView_Library.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
                    Dim result As DialogResult = MessageBox.Show("送信済みですがキュー登録しますか？",
                                                             "AIGIS2　確認",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Exclamation,
                                                             MessageBoxDefaultButton.Button2)
                    '「いいえ」を選択時何もしない 
                    If result = DialogResult.No Then
                        Exit Sub
                    End If
                End If
                Dim registTime As String = ListView_Library.SelectedItems(0).SubItems(4).Text
                ListView_Library.SelectedItems(0).BackColor = Color.Yellow
                ListBox_Queue.Items.Add("【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & registTime & "　［ファイルパス］" & ListView_Library.SelectedItems(0).ImageKey)
                ListView_Library.SelectedItems(0).Selected = False
        End Select
    End Sub

    'ライブラリ画像をダブルクリックでプレビュー表示
    Public Sub Preview(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView_Library.MouseDoubleClick
        Select Case e.Button
            Case MouseButtons.Left
                Form_Preview.Show()
        End Select
    End Sub

    '保管庫の日付フォルダーをダブルクリックで保管庫の中身をListviewに表示
    Public Sub OpenKeepfolder(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView_Keepfolder.MouseDoubleClick
        Select Case e.Button
            Case MouseButtons.Left
                If TabControl1.TabPages.Count = 3 Then
                    TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                End If
                Dim imagekey As String = ListView_Keepfolder.SelectedItems(0).ImageKey
                Dim foldername As String = System.IO.Path.GetFileName(imagekey)
                TabPage3.Text = foldername
                ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
                TabControl1.TabPages.Add(TabPage3)
                TabControl1.SelectTab(2)
        End Select
    End Sub

    '保管庫画像をダブルクリック
    Public Sub ListView_Keepfile_DoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView_Keepfile.MouseDoubleClick
        Select Case e.Button
            Case MouseButtons.Left
                Form_Preview.Show()
        End Select
    End Sub

    'Listviewのタブ切り替え時
    Private Sub TabChange(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting

        If TabControl1.SelectedIndex = 0 Then
            ListView_Keepfolder.SelectedItems.Clear()
            ListView_Keepfile.SelectedItems.Clear()
            Button_App.Enabled = True
            Button_SizeChange.Enabled = True
            Button_Rev.Enabled = True
            Button_Rem.Enabled = True
            Button_Move.Enabled = True
            Label_Move.Text = "保管庫へ"
            Label_ListGazo.Text = (ListView_Library.Items.Count & "個の画像")
        ElseIf TabControl1.SelectedIndex = 1 Then
            ListView_Library.SelectedItems.Clear()
            ListView_Keepfile.SelectedItems.Clear()
            Button_App.Enabled = False
            Button_SizeChange.Enabled = False
            Button_Rem.Enabled = True
            Button_Move.Enabled = False
            Label_Move.Text = "ライブラリへ"
            Label_ListGazo.Text = (ListView_Keepfolder.Items.Count & "個の画像")
        ElseIf TabControl1.SelectedIndex = 2 Then
            ListView_Library.SelectedItems.Clear()
            ListView_Keepfolder.SelectedItems.Clear()
            Button_App.Enabled = True
            Button_SizeChange.Enabled = True
            Button_Rem.Enabled = True
            Button_Move.Enabled = True
            Label_Move.Text = "ライブラリへ"
            Label_ListGazo.Text = (ListView_Keepfile.Items.Count & "個の画像")
        End If
    End Sub

    '雛形ボタンにカーソルを被せると内容をポップアップのテンプレ
    Private Sub HinaPoppuappu(sender As Object, name As String)
        Dim jsonhinagata As String = CPath & "\setting\setting.json"
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(sender, jsonobj(name)("karimidashi") & vbCrLf & jsonobj(name)("caption"))
    End Sub

    '雛形ボタン押下時のテンプレ
    Private Sub HinaClick(name As String)
        Dim jsonhinagata As String = CPath & "\setting\setting.json"
        Dim jsonstr As String
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Karimi.Text = jsonobj(name)("karimidashi")
        TextBox_CapP.Text = jsonobj(name)("caption")
    End Sub

    '「雛形１」ボタンにカーソルを被せると内容をポップアップ
    Private Sub Hina1Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina1.MouseHover
        HinaPoppuappu(sender, "hinagata1")
    End Sub

    '「雛形１」ボタン押下時
    Private Sub Hina1Click(sender As Object, e As EventArgs) Handles Button_Hina1.Click
        HinaClick("hinagata1")
    End Sub

    '「雛形２」ボタンにカーソルを被せると内容をポップアップ
    Private Sub Hina2Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina2.MouseHover
        HinaPoppuappu(sender, "hinagata2")
    End Sub

    '「雛形２」ボタン押下時
    Private Sub Hina2Click(sender As Object, e As EventArgs) Handles Button_Hina2.Click
        HinaClick("hinagata2")
    End Sub

    '「雛形３」ボタンにカーソルを被せると内容をポップアップ
    Private Sub Hina3Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina3.MouseHover
        HinaPoppuappu(sender, "hinagata3")
    End Sub

    '「雛形３」ボタン押下時
    Private Sub Hina3Click(sender As Object, e As EventArgs) Handles Button_Hina3.Click
        HinaClick("hinagata3")
    End Sub

    '「雛形４」ボタンにカーソルを被せると内容をポップアップ
    Private Sub Hina4Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina4.MouseHover
        HinaPoppuappu(sender, "hinagata4")
    End Sub

    '「雛形４」ボタン押下時
    Private Sub Hina4Click(sender As Object, e As EventArgs) Handles Button_Hina4.Click
        HinaClick("hinagata4")
    End Sub

    '「雛形５」ボタンにカーソルを被せると内容をポップアップ
    Private Sub Hina5Poppuappu(sender As Object, e As EventArgs) Handles Button_Hina5.MouseHover
        HinaPoppuappu(sender, "hinagata5")
    End Sub

    '「雛形５」ボタン押下時
    Private Sub Hina5Click(sender As Object, e As EventArgs) Handles Button_Hina5.Click
        HinaClick("hinagata5")
    End Sub


    '「複数追加」ボタン押下時の動き
    Private Sub PhotosAddButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Adds.Click
        LoadingStart()
        'ファイル選択ダイアログの設定
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Title = "取り込む画像を選択"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "jpegファイル(*.jpg)|*.jpg|すべてのファイル|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = True
        'ダイアログを閉じた場合プロシージャを抜ける
        If OpenFileDialog1.ShowDialog = DialogResult.Cancel Then
            LoadingEnd()
            Exit Sub
        End If
        '選択した画像のファイルパスを取得し画像登録プロシージャを実行
        Dim orgFilepath() As String = OpenFileDialog1.FileNames
        For Each filepath As String In orgFilepath
            '画像登録プロシージャの実行
            ResistPicture(filepath)
        Next
        OpenFileDialog1.Dispose()
        AfterCare()
        LoadingEnd()
    End Sub

    'D&DされたファイルをImageListに追加
    Private Sub DragDropUpload(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListView_Library.DragDrop
        LoadingStart()
        Dim strFilepath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        For Each filepath As String In strFilepath
            If System.IO.File.Exists(filepath.ToString) = True Then
                ResistPicture(filepath)
            End If
        Next
        AfterCare()
        LoadingEnd()
    End Sub

    'フォルダ監視から画像の追加
    Private Sub watcher_create(ByVal source As System.Object, ByVal e As System.IO.FileSystemEventArgs)
        LoadingStart()
        System.Threading.Thread.Sleep(500)
        Dim filepath1 As String = e.FullPath
        ResistPicture(filepath1)
        AfterCare()
        LoadingEnd()
    End Sub

    '画像登録時の処理
    Public Sub ResistPicture(ByVal orgfile As String)
        Dim strFilename As String = System.IO.Path.GetFileName(orgfile) 'ファイル名のみ取得(拡張子付き)
        Dim strFilenameWithout As String = System.IO.Path.GetFileNameWithoutExtension(orgfile) 'ファイル名のみ取得(拡張子無し)
        '＝＝＝Exifから撮影日時の取得ここから(厄介)＝＝＝
        Dim strExifDate As String = "null"
        Dim bmp As New System.Drawing.Bitmap(orgfile)
        'Exif情報を列挙する
        Dim item As System.Drawing.Imaging.PropertyItem
        For Each item In bmp.PropertyItems
            'データの型を判断し、ASCII文字の場合は、文字列に変換してから撮影日時のみ取得する
            If item.Type = 2 Then
                Dim val As String = System.Text.Encoding.ASCII.GetString(item.Value)
                val = val.Trim(New Char() {ControlChars.NullChar})
                If item.Id = 36867 Then
                    strExifDate = val
                End If
            Else
                If item.Id = 36867 Then
                    strExifDate = item.Len
                End If
            End If
        Next item
        strExifDate = Replace(strExifDate, ":", "/", 1, 1, CompareMethod.Binary)
        strExifDate = Replace(strExifDate, ":", "/", 1, 1, CompareMethod.Binary)
        Dim dtParseDate As DateTime = DateTime.Parse(strExifDate)
        Dim strSatsueiDate1 As String = dtParseDate.ToString("yyyy年M月dd日tth時m分")
        Dim strSatsueiDate2 As String = dtParseDate.ToString("yyyy年M月dd日")
        bmp.Dispose()
        '＝＝＝Exifから撮影日時の取得ここまで(厄介)＝＝＝
        '登録時刻
        Dim registDate As DateTime = System.DateTime.Now
        While System.IO.Directory.Exists(CPath & "\data\Library\" & registDate.ToString("yyyyMMddHHmmss") & "\") = True
            registDate = registDate.AddSeconds(1)
        End While
        Dim registDir As String = registDate.ToString("yyyyMMddHHmmss")
        Dim torokusyoshi As String = registDate.ToString("yyyy年M月d日tth時m分s秒")
        Dim filepath As String = CPath & "\data\Library\" & registDir & "\" & strFilename 'コピー先のファイルパス
        '画像の保存
        My.Computer.FileSystem.CopyFile(orgfile, filepath, True)
        'サムネイル作成
        CreateThumb(ListView_Library, filepath)
        Dim jikokuhlag As String = "False"
        If CheckBox_Jikoku.Checked = True Then
            jikokuhlag = "True"
        End If
        Dim mainichiflag As String = "False"
        If CheckBox_Mainichi.Checked = True Then
            mainichiflag = "True"
        End If
        Dim jikoku As String = strSatsueiDate1
        If CheckBox_Jikoku.Checked = True Then
            jikoku = strSatsueiDate2
        End If
        If CheckBox_Mainichi.Checked = True Then
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
        Else
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影"
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
            .karimidashi = TextBox_Karimi.Text,
            .status = "未",
            .capsion1 = TextBox_CapP.Text,
            .capsion2 = TextBox_CapHN.Text,
            .timeFlag = jikokuhlag,
            .daihyoFlag = mainichiflag,
            .dontUseTyp = dontUseTyp,
            .syukkoyotei = ComboBox_Syukkoyotei.Text,
            .photographer = ComboBox_Satsueisya.Text,
            .phototime1 = strSatsueiDate1,
            .phototime2 = strSatsueiDate2,
            .photoplace = ComboBox_Photoplace.Text,
            .registtime = torokusyoshi,
            .recommendFlag = recommendFlug
            }
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(CPath & "\data\Library\" & registDir & "\" & strFilenameWithout & ".json", True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
    End Sub

    'サムネイルの作成
    Sub CreateThumb(sender As Object, Filepath As String)
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
        canvas2.Save(thamfilepath)
        ListViewReload(sender, System.IO.Path.GetDirectoryName(thamdirepath))
    End Sub

    '登録後後処理
    Sub AfterCare()
        Dim strJsonFilepath As String = CPath & "\setting\zenkai.json"
        My.Computer.FileSystem.DeleteFile(strJsonFilepath)
        'json書誌の設定をし、保存する
        Dim data2 = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimi.Text,
                    .capsion1 = TextBox_CapP.Text
                    }
        Dim JsonFile2 As System.IO.StreamWriter
        JsonFile2 = New System.IO.StreamWriter(strJsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile2.WriteLine(JsonConvert.SerializeObject(data2, Formatting.Indented))
        JsonFile2.Close()
        ListView_Library.Clear()
        'ライブラリの更新
        ListViewReload(ListView_Library, CPath & "\data\Library\")
        Label_ListGazo.Text = (ImageList_Library.Images.Count & "個の画像")
    End Sub

    '「上書き保存」ボタン押下時
    Private Sub OverWright(sender As Object, e As EventArgs) Handles Button_Rev.Click
        Dim selectedItemsCount As Integer
        Dim allItemCount As Integer
        Dim pictureFilePath As String
        Dim fileNameWithout As String
        Dim pictureDirePath As String
        Dim jsonFilePath As String
        If TabControl1.SelectedIndex = 0 Then
            '最後に選択されたものの書誌を取得する。（もっと簡単な方法はないか）
            selectedItemsCount = ListView_Library.SelectedItems.Count
            allItemCount = ListView_Library.Items.Count
            If selectedItemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            '＝＝＝Json絡みの設定＝＝＝
            pictureFilePath = ListView_Library.SelectedItems(0).ImageKey
            fileNameWithout = System.IO.Path.GetFileNameWithoutExtension(pictureFilePath)
            pictureDirePath = System.IO.Path.GetDirectoryName(pictureFilePath)
            jsonFilePath = pictureDirePath & "\" & fileNameWithout & ".json"
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
            Dim status As String
            If ListView_Library.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
                status = "済"
            Else
                status = "未"
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
                            .karimidashi = TextBox_Karimi.Text,
                            .status = status,
                            .capsion1 = TextBox_CapP.Text,
                            .capsion2 = TextBox_CapHN.Text,
                            .timeFlag = jikokuhlag,
                            .daihyoFlag = mainichiflag,
                .dontUseTyp = dontUseTyp,
                            .syukkoyotei = ComboBox_Syukkoyotei.Text,
                            .photographer = ComboBox_Satsueisya.Text,
                            .phototime1 = photoTime1,
                            .phototime2 = photoTime2,
                            .photoplace = ComboBox_Photoplace.Text,
                            .registtime = ListView_Library.SelectedItems(0).SubItems(4).Text,
                            .recommendFlag = recommendFlug
                            }
            Dim JsonFile As System.IO.StreamWriter
            JsonFile = New System.IO.StreamWriter(jsonFilePath, True, System.Text.Encoding.UTF8)
            JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
            JsonFile.Close()
            Dim i As Integer
            For i = 0 To allItemCount - 1
                If pictureFilePath = ListView_Library.Items(i).ImageKey Then
                    ListView_Library.Items(i).Text = status & "/【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & ListView_Library.SelectedItems(0).SubItems(4).Text
                End If
            Next i
        Else
            selectedItemsCount = ListView_Keepfile.SelectedItems.Count
            allItemCount = ListView_Keepfile.Items.Count
            If selectedItemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            '＝＝＝Json絡みの設定＝＝＝
            pictureFilePath = ListView_Keepfile.SelectedItems(0).ImageKey
            fileNameWithout = System.IO.Path.GetFileNameWithoutExtension(pictureFilePath)
            pictureDirePath = System.IO.Path.GetDirectoryName(pictureFilePath)
            jsonFilePath = pictureDirePath & "\" & fileNameWithout & ".json"
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
            Dim status As String
            If ListView_Keepfile.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
                status = "済"
            Else
                status = "未"
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
                            .karimidashi = TextBox_Karimi.Text,
                            .status = status,
                            .capsion1 = TextBox_CapP.Text,
                            .capsion2 = TextBox_CapHN.Text,
                            .timeFlag = jikokuhlag,
                            .daihyoFlag = mainichiflag,
                .dontUseTyp = dontUseTyp,
                            .syukkoyotei = ComboBox_Syukkoyotei.Text,
                            .photographer = ComboBox_Satsueisya.Text,
                            .phototime1 = photoTime1,
                            .phototime2 = photoTime2,
                            .photoplace = ComboBox_Photoplace.Text,
                            .registtime = ListView_Keepfile.SelectedItems(0).SubItems(4).Text,
                            .recommendFlag = recommendFlug
                            }
            Dim JsonFile As System.IO.StreamWriter
            JsonFile = New System.IO.StreamWriter(jsonFilePath, True, System.Text.Encoding.UTF8)
            JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
            JsonFile.Close()
            For i = 0 To allItemCount - 1
                If pictureFilePath = ListView_Keepfile.Items(i).ImageKey Then
                    ListView_Keepfile.Items(i).Text = status & "/【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & ListView_Keepfile.SelectedItems(0).SubItems(4).Text
                End If
            Next i
        End If
        Dim strJsonFilepath As String = CPath & "\setting\zenkai.json"
        My.Computer.FileSystem.DeleteFile(strJsonFilepath)
        'json書誌の設定をし、保存する
        Dim data2 = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimi.Text,
                    .capsion1 = TextBox_CapP.Text
                    }
        Dim JsonFile2 As System.IO.StreamWriter
        JsonFile2 = New System.IO.StreamWriter(strJsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile2.WriteLine(JsonConvert.SerializeObject(data2, Formatting.Indented))
        JsonFile2.Close()
    End Sub

    '「保管庫へ/ライブラリへ」ボタン押下時の動き
    Private Sub MovePhoto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Move.Click
        Dim itemsCount As Integer
        Dim moveDate As String
        If TabControl1.SelectedIndex = 0 Then
            '送信するファイルのパス（＝選択されたもの）
            itemsCount = ListView_Library.SelectedItems.Count
            If itemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            Dim result As DialogResult = MessageBox.Show("保管庫に移動しますか（今日の日付フォルダに入ります）",
                                                     "AIGIS2　確認",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button1)
            '「いいえ」を選択時何もしない 
            If result = DialogResult.No Then
                Exit Sub
            End If
            moveDate = System.DateTime.Now.Date
            moveDate = Replace(moveDate, "/", "", 1, 1, CompareMethod.Binary)
            moveDate = Replace(moveDate, "/", "", 1, 1, CompareMethod.Binary)
            Dim pictureFilePath(itemsCount - 1) As String
            Dim pictureDirePath(itemsCount - 1) As String
            Dim pictureDireName(itemsCount - 1) As String
            Dim i As Integer
            For i = 0 To itemsCount - 1
                If ListView_Library.SelectedItems(i).BackColor = Color.Yellow Then
                    MsgBox(ListView_Library.SelectedItems(i).Text & "　はキュー登録されています。")
                    Continue For
                End If
                pictureFilePath(i) = ListView_Library.SelectedItems(i).ImageKey
                pictureDirePath(i) = System.IO.Path.GetDirectoryName(pictureFilePath(i))
                pictureDireName(i) = System.IO.Path.GetFileName(pictureDirePath(i))
                My.Computer.FileSystem.MoveDirectory(pictureDirePath(i), CPath & "\data\KeepList\" & moveDate & "\" & pictureDireName(i), True)
            Next i
            'ImageListの更新
            ListViewReload(ListView_Library, CPath & "\data\Library\")
            ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
            Label_ListGazo.Text = (ListView_Library.Items.Count & "個の画像")
        ElseIf TabControl1.SelectedIndex = 2 Then
            '送信するファイルのパス（＝選択されたもの）
            itemsCount = ListView_Keepfile.SelectedItems.Count
            If itemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            'メッセージボックスを表示する 
            Dim result As DialogResult = MessageBox.Show("ライブラリに移動しますか",
                                                     "AIGIS2　確認",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button1)
            '「いいえ」を選択時何もしない 
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim pictureFilePath(itemsCount - 1) As String
            Dim pictureDirePath(itemsCount - 1) As String
            Dim pictureDireName(itemsCount - 1) As String
            Dim i As Integer
            For i = 0 To itemsCount - 1
                pictureFilePath(i) = ListView_Keepfile.SelectedItems(i).ImageKey
                pictureDirePath(i) = System.IO.Path.GetDirectoryName(pictureFilePath(i))
                pictureDireName(i) = System.IO.Path.GetFileName(pictureDirePath(i))
                My.Computer.FileSystem.MoveDirectory(pictureDirePath(i), CPath & "\data\Library\" & pictureDireName(i), True)
            Next i
            'ImageListの更新
            ListViewReload(ListView_Library, CPath & "\data\Library\")
            ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
            Label_ListGazo.Text = (ListView_Keepfile.Items.Count & "個の画像")
        End If
        KeepfolderReload()
        ClearShoshi()
    End Sub

    '「削除」ボタン押下時
    Private Sub RemovePhoto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Rem.Click
        'ライブラリタブ時
        If TabControl1.SelectedIndex = 0 Then
            Dim itemsCount As Integer = ListView_Library.SelectedItems.Count
            If itemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            'メッセージボックスを表示する 
            Dim result As DialogResult = MessageBox.Show(itemsCount & "件の画像を削除しますか？",
                                                         "画像削除",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button1)
            '「いいえ」を選択時何もしない
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To itemsCount - 1
                If ListView_Library.SelectedItems(i).BackColor = Color.Yellow Then
                    MsgBox(ListView_Library.SelectedItems(i).Text & "　はキュー登録されています。")
                    Continue For
                End If
                Dim pictureFilePath As String = ListView_Library.SelectedItems(i).ImageKey
                Dim pictureDirePath As String = System.IO.Path.GetDirectoryName(pictureFilePath)
                System.IO.Directory.Delete(pictureDirePath, True)
            Next i
            ListViewReload(ListView_Library, CPath & "\data\Library\")
            Label_ListGazo.Text = (ListView_Library.Items.Count & "個の画像")
        ElseIf TabControl1.SelectedIndex = 1 Then
            Dim foldersCount As Integer = ListView_Keepfolder.SelectedItems.Count
            If foldersCount = 0 Then
                MsgBox("フォルダが選択されていません")
                Exit Sub
            End If
            'メッセージボックスを表示する 
            Dim result As DialogResult = MessageBox.Show(foldersCount & "件のフォルダを削除しますか？",
                                                         "フォルダ削除",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button1)
            '「いいえ」を選択時何もしない
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To foldersCount - 1
                Dim parentDirePath As String = ListView_Keepfolder.SelectedItems(i).ImageKey
                Dim parentDireName As String = System.IO.Path.GetFileName(parentDirePath)
                If TabControl1.TabPages.Count = 3 Then
                    If TabControl1.TabPages(2).Text = parentDireName Then
                        TabControl1.TabPages.Remove(TabControl1.TabPages(2))
                        TabPage3.Text = ""
                    End If
                End If
                System.IO.Directory.Delete(parentDirePath, True)
            Next i
            KeepfolderReload()
            Label_ListGazo.Text = (ListView_Keepfolder.Items.Count & "個の画像")
        ElseIf TabControl1.SelectedIndex = 2 Then
            Dim itemsCount As Integer = ListView_Keepfile.SelectedItems.Count
            If itemsCount = 0 Then
                MsgBox("画像が選択されていません")
                Exit Sub
            End If
            'メッセージボックスを表示する 
            Dim result As DialogResult = MessageBox.Show(itemsCount & "件の画像を削除しますか？",
                                                         "画像削除",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button2)
            '「いいえ」を選択時何もしない
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To itemsCount - 1
                Dim pictureFilePath As String = ListView_Keepfile.SelectedItems(i).ImageKey
                Dim pictureDirePath As String = System.IO.Path.GetDirectoryName(pictureFilePath)
                System.IO.Directory.Delete(pictureDirePath, True)
            Next i
            ListViewReload(ListView_Keepfile, CPath & "\data\KeepList\" & TabPage3.Text)
            Label_ListGazo.Text = (ListView_Keepfile.Items.Count & "個の画像")
        End If
        ClearShoshi()
        MsgBox("画像を削除しました")
    End Sub

    '「送信」押下時
    Private Sub SendPhoto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Send.Click
        Form_Send.Show()
    End Sub

    '「簡易日時」「代表撮影」チェック時
    Private Sub PhototimeCheck(sender As Object, e As EventArgs) Handles CheckBox_Jikoku.CheckedChanged, CheckBox_Mainichi.CheckedChanged
        If CheckBox_Mainichi.Checked = True Then
            If CheckBox_Jikoku.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
            End If
        Else
            If CheckBox_Jikoku.Checked = True Then
                TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime2 & ComboBox_Satsueisya.Text & "撮影"
            Else
                TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & photoTime1 & ComboBox_Satsueisya.Text & "撮影"
            End If
        End If
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
        Dim strJsonFilepath As String = CPath & "\setting\copy.json"
        My.Computer.FileSystem.DeleteFile(strJsonFilepath)
        'json書誌の設定をし、保存する
        Dim data = New JsonItem With
                    {
                    .karimidashi = TextBox_Karimi.Text,
                    .capsion1 = TextBox_CapP.Text
                    }
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(strJsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
        MsgBox("コピーしました（次回コピー時まで保持）")
    End Sub

    '「貼り付け」ボタン被せ時
    Private Sub PastShoshiPoopapp(sender As Object, e As EventArgs) Handles Button_Peast.MouseHover
        Dim jsonhinagata As String = CPath & "\setting\copy.json"
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Peast, jsonobj("karimidashi") & vbCrLf & jsonobj("capsion1"))
    End Sub

    '「貼り付け」実行時
    Private Sub PastShoshi(sender As Object, e As EventArgs) Handles Button_Peast.Click
        Dim strJsoncopy As String = CPath & "\setting\copy.json"
        Dim strJsonstr As String = ""
        Dim strJsonFilepath As String = strJsoncopy
        Using sr As New System.IO.StreamReader(strJsonFilepath, Encoding.UTF8)
            strJsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(strJsonstr)
        TextBox_Karimi.Text = jsonobj("karimidashi")
        TextBox_CapP.Text = jsonobj("capsion1")
    End Sub

    'キューの選択削除
    Private Sub QueueRemove(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox_Queue.SelectedItems.Count = 0 Then
            MsgBox("削除するキューを選択して下さい")
            Exit Sub
        End If
        ListBox_Queue.Items.Remove(ListBox_Queue.SelectedItems(0))
        ListView_Library.SelectedItems.Clear()
        ListViewReload(ListView_Library, CPath & "\data\Library\")
    End Sub

    'キューの全削除
    Private Sub AllQueueRemove(sender As Object, e As EventArgs) Handles Button1.Click
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("キューを全削除しますか？",
                                                         "キュー削除",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Exclamation,
                                                         MessageBoxDefaultButton.Button2)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
        Dim queueCount As Integer = ListBox_Queue.Items.Count
        If queueCount = 0 Then
            MsgBox("キューがありません")
            Exit Sub
        End If
        ListBox_Queue.Items.Clear()
        ListViewReload(ListView_Library, CPath & "\data\Library\")
    End Sub

    '「外部AP」起動時
    Private Sub ShowApp(sender As Object, e As EventArgs) Handles Button_App.Click
        Dim listview As ListView = ListView_Library
        If TabControl1.SelectedIndex = 2 And ListView_Keepfile.SelectedItems.Count <> 0 Then
            listview = ListView_Keepfile
        End If
        If listview.SelectedItems.Count = 0 Then
            MsgBox("画像が選択されていません")
            Exit Sub
        End If
        Dim jsonhinagata As String = CPath & "\setting\setsuzoku.json"
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        Dim psi As New System.Diagnostics.Process()
        '起動するファイルのパスを指定する
        psi.StartInfo.FileName = jsonobj("app")
        'コマンドライン引数を指定する
        psi.StartInfo.Arguments = listview.SelectedItems(0).ImageKey
        Dim index As Integer = listview.SelectedItems(0).Index
        'アプリケーションを起動する
        psi.Start()
        psi.WaitForExit()
        CreateThumb(listview, listview.SelectedItems(0).ImageKey)
        listview.Items(index).Selected = True
    End Sub

    '「撮影者」変更時
    Private Sub PhotograferChange(sender As Object, e As EventArgs) Handles ComboBox_Satsueisya.TextChanged
        Dim jikoku As String
        If CheckBox_Jikoku.Checked = True Then
            jikoku = photoTime2
        Else
            jikoku = photoTime1
        End If
        If CheckBox_Mainichi.Checked = True Then
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
        Else
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影"
        End If
    End Sub

    '「撮影場所」変更時
    Private Sub PhotoplaceChange(sender As Object, e As EventArgs) Handles ComboBox_Photoplace.TextChanged
        Dim jikoku As String
        If CheckBox_Jikoku.Checked = True Then
            jikoku = photoTime2
        Else
            jikoku = photoTime1
        End If
        If CheckBox_Mainichi.Checked = True Then
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影（代表撮影）"
        Else
            TextBox_CapHN.Text = "＝" & ComboBox_Photoplace.Text & "で、" & jikoku & ComboBox_Satsueisya.Text & "撮影"
        End If
    End Sub

    '「リサイズ」ボタン押下時
    Private Sub DoResize(sender As Object, e As EventArgs) Handles Button_SizeChange.Click
        If TextBox_Maxsize.Text = "" Then
            MsgBox("サイズを指定して下さい")
            Exit Sub
        ElseIf ListView_Library.SelectedItems.Count <> 1 Then
            MsgBox("リサイズする画像を一つ選択して下さい")
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
        Dim Filepath As String = ListView_Library.SelectedItems(0).ImageKey
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
        CreateThumb(ListView_Library, Filepath)
    End Sub

    '「画像追加」ボタン押下時
    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        Form_Kobetsu.Show()
        Form_Kobetsu.Activate()
    End Sub

    '「前回書誌」ボタン被せ時
    Private Sub Button_Before_over(sender As Object, e As EventArgs) Handles Button_Before.MouseHover
        Dim jsonhinagata As String = CPath & "\setting\zenkai.json"
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        ToolTip1.SetToolTip(Button_Before, jsonobj("karimidashi") & vbCrLf & jsonobj("capsion1"))
    End Sub

    '「前回書誌」ボタン押下時
    Private Sub Button_Before_Click(sender As Object, e As EventArgs) Handles Button_Before.Click
        Dim strJsoncopy As String = CPath & "\setting\zenkai.json"
        Dim strJsonstr As String = ""
        Dim strJsonFilepath As String = strJsoncopy
        Using sr As New System.IO.StreamReader(strJsonFilepath, Encoding.UTF8)
            strJsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(strJsonstr)
        TextBox_Karimi.Text = jsonobj("karimidashi")
        TextBox_CapP.Text = jsonobj("capsion1")
    End Sub

    '「比較」ボタン押下時
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form_Compare.Show()
    End Sub

    '「オススメ」ボタン押下時
    Private Sub Button_Recommend_Click(sender As Object, e As EventArgs) Handles Button_Recommend.Click
        If Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch Then
            Button_Recommend.BackgroundImage = Image.FromFile(CPath & "\data\Icon\yellowstar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Zoom
        Else
            Button_Recommend.BackgroundImage = Image.FromFile(CPath & "\data\Icon\whitestar.png")
            Button_Recommend.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    'メニューバーの説明
    Private Sub 画像追加ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 画像追加ToolStripMenuItem.Click
        Form_Kobetsu.Show()
        Form_Kobetsu.Activate()
    End Sub

    Private Sub 複数追加ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 複数追加ToolStripMenuItem.Click
        Button_Adds.PerformClick()
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 雛形設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 雛形設定ToolStripMenuItem.Click
        Form_Setting.Show()
    End Sub

    Private Sub 接続設定ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 接続設定ToolStripMenuItem.Click
        Form_Parsonal.Show()
    End Sub

    Private Sub 使い方ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 使い方ToolStripMenuItem.Click
        MsgBox("完成版の使い方ドキュメントを開くようにします。")
    End Sub

    Private Sub バージョン情報ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles バージョン情報ToolStripMenuItem.Click
        MsgBox("★★★★★写真送稿アプリ Ver0.9★★★★★" & vbCrLf &
               "問い合わせ先　東京本社技術センター" & vbCrLf &
               "TEL：03-3212-1176 (内線9710-6560)" & vbCrLf &
               "MAIL：t.it@mainichi.co.jp" & vbCrLf & vbCrLf &
               "---バージョン履歴---" & vbCrLf &
               "2018.06.25 Ver0.9 プロトタイプ")
    End Sub

    'TextBox1のKeyPressイベントハンドラ
    Private Sub TextBoxMaxsize_KeyPress(sender As Object,
                                        e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Maxsize.KeyPress
        '0～9と、バックスペース以外の時は、イベントをキャンセルする
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub ToolStripButton_Teamlabel_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Teamlabel.Click

    End Sub

    'キー操作の一覧
    Private Sub FormPreview_KeyAction(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles _
               ListView_Keepfile.PreviewKeyDown, TabControl1.PreviewKeyDown, ListView_Library.PreviewKeyDown, ListView_Keepfolder.PreviewKeyDown, ListBox_Queue.PreviewKeyDown
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
                Button_Send.PerformClick()
            Case Keys.A
                Button_App.PerformClick()
            Case Keys.Z
                Button_Before.PerformClick()
            Case Keys.C
                Button_Copy.PerformClick()
            Case Keys.V
                Button_Peast.PerformClick()
            Case Keys.S
                Button_Rev.PerformClick()
            Case Keys.Q
                Button_Queue.PerformClick()
            Case Keys.Delete
                Button_Rem.PerformClick()
            Case Keys.Enter
                Form_Preview.Show()
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ショートカットキー一覧ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ショートカットキー一覧ToolStripMenuItem.Click
        MsgBox("ショートカットキー一覧" & vbCrLf &
       "雛形１　　　1" & vbCrLf &
       "雛形２　　　2" & vbCrLf &
       "雛形３　　　3" & vbCrLf &
       "雛形４　　　4" & vbCrLf &
       "雛形５　　　5" & vbCrLf &
       "送信　　　　r" & vbCrLf &
       "アプリ　　　a" & vbCrLf &
       "前回書誌　　z" & vbCrLf &
       "コピー　　　c" & vbCrLf &
       "貼り付け　　v" & vbCrLf &
       "上書き　　　s" & vbCrLf &
       "※入力可能状態の時は" & vbCrLf &
       "ショートカットキーは無効です")
    End Sub

    Private Sub 送信済み一括削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 送信済み一括削除ToolStripMenuItem.Click
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("ライブラリ・保管庫内の送信済み画像を一括削除しますか？（画像は「ファイル」→「ごみ箱」に移動します）",
                                                     "送信済み一括削除",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button2)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub ComboBox_Sort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Sort.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            Changeitems(ListView_Library)
        ElseIf TabControl1.SelectedIndex = 2 Then
            Changeitems(ListView_Keepfile)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Monitor.Click
        If sender.text = "非監視" Then
            sender.Text = "監視中"
            sender.backcolor = Color.Red
            BackgroundWorker1.RunWorkerAsync(100)
            MsgBox("フォルダ監視を開始しました。")
        ElseIf ToolStripButton1.Text = "転送モード" Then
            MsgBox("転送モード中は非監視にできません")
        Else
            sender.text = "非監視"
            sender.backcolor = SystemColors.Info
            '監視を終了
            FileSystemWatcher1.EnableRaisingEvents = False
            FileSystemWatcher1.Dispose()
            FileSystemWatcher1 = Nothing
            MsgBox("フォルダ監視を終了しました。")
        End If
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '監視するディレクトリを指定
        Dim jsonShoshi As String = CPath & "\setting\setsuzoku.json", jsonstr As String
        Using sr As New System.IO.StreamReader(jsonShoshi, Encoding.UTF8)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        FileSystemWatcher1 = New System.IO.FileSystemWatcher
        FileSystemWatcher1.Path = jsonobj("Monitor").ToString
        'FileSystemWatcher1.Path = "C:\test"
        '最終アクセス日時、最終更新日時、ファイル、フォルダ名の変更を監視する
        FileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastAccess Or
        System.IO.NotifyFilters.LastWrite Or
        System.IO.NotifyFilters.FileName Or
        System.IO.NotifyFilters.DirectoryName
        'すべてのファイルを監視
        FileSystemWatcher1.Filter = "*.jpg"
        'UIのスレッドにマーシャリングする
        'コンソールアプリケーションでの使用では必要ない
        FileSystemWatcher1.SynchronizingObject = Me

        'イベントハンドラの追加
        AddHandler FileSystemWatcher1.Created, AddressOf watcher_create

        '監視を開始する
        FileSystemWatcher1.EnableRaisingEvents = True
    End Sub

    Private Sub Button_Queue_Click(sender As Object, e As EventArgs) Handles Button_Queue.Click

        If ListView_Library.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        'キュー登録済みなら抜ける
        If ListView_Library.SelectedItems(0).BackColor = Color.Yellow Then
            MsgBox("キュー登録されています。")
            Exit Sub
            '送信済みステータスなら抜け
        ElseIf ListView_Library.SelectedItems(0).BackColor = Color.FromKnownColor(KnownColor.ActiveCaption) Then
            Dim result As DialogResult = MessageBox.Show("送信済みですがキュー登録しますか？",
                                                             "AIGIS2　確認",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Exclamation,
                                                             MessageBoxDefaultButton.Button2)
            '「いいえ」を選択時何もしない 
            If result = DialogResult.No Then
                Exit Sub
            End If
        End If
        Button_Rev.PerformClick()
        ListView_Library.SelectedItems(0).BackColor = Color.Yellow
        ListBox_Queue.Items.Add("【" & ComboBox_Syukkoyotei.Text & "】" & TextBox_Karimi.Text & "/" & ListView_Library.SelectedItems(0).SubItems(4).Text & "　［ファイルパス］" & ListView_Library.SelectedItems(0).ImageKey)
        ListView_Library.SelectedItems(0).Selected = False
    End Sub

    Private Sub ListBox_Queue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Queue.SelectedIndexChanged
        If sender.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim aaa As String = sender.SelectedItems(0)
        Dim no As Integer = sender.SelectedIndices(0)
        Dim NameArray As String() = Split(aaa, "　［ファイルパス］")
        ListView_Library.SelectedItems.Clear()
        For Each items As ListViewItem In ListView_Library.Items
            If items.ImageKey = NameArray(1) Then
                items.Selected = True
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If sender.text = "送稿モード" Then
            MsgBox("転送モードに切り替えます" & vbCrLf & "※転送モードはライブラリに登録時に即転送されます")
            sender.Text = "転送モード"
            sender.backcolor = Color.Red
            ListView_Library.Items.Clear()
            If TabControl1.TabCount = 3 Then
                TabControl1.TabPages.Remove(TabControl1.TabPages(2))
            End If
            TabControl1.TabPages.Remove(TabControl1.TabPages(1))
            If ToolStripButton_Monitor.Text = "非監視" Then
                ToolStripButton_Monitor.PerformClick()
            End If
            Panel1.Enabled = False
        Else
            sender.text = "送稿モード"
            sender.backcolor = Color.LightCyan
            ListViewReload(ListView_Library, CPath & "\data\Library\")
            Dim TabPage2 As New TabPage()
            TabPage2.Text = "保管庫"
            TabPage2.Controls.Add(ListView_Keepfolder)
            TabControl1.TabPages.Add(TabPage2)
            Panel1.Enabled = True
        End If
    End Sub

    Private Sub RaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListClear_ToolStripMenuItem.Click

    End Sub

End Class