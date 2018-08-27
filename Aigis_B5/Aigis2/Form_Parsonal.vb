Imports System
Imports System.IO
Imports System.Text
Imports Shell32
Imports Newtonsoft.Json
Public Class Form_Parsonal
    Dim strCurrentDir As String = System.IO.Path.GetDirectoryName _
        (System.Reflection.Assembly.GetExecutingAssembly().Location) ' カレントディレクトリの取得
    'JsonItem Class = Aigis内の書誌をまとめたJsonクラス
    Public Class JsonShoshi
        Public Property Syainid As String '社員番号
        Public Property Syainmei As String '社員名
        Public Property Password As String 'パスワード
        Public Property Teamlabel As String 'チームラベル
        Public Property app As String '外部アプリパス
        Public Property Monitor As String '外部アプリパス
    End Class

    'フォーム起動時（ListViewの更新、画像倍率候補の追加、並び順候補の追加、デフォルトの読み込み）
    Private Sub FormParsonalLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim jsonhinagata As String = strCurrentDir & "\setting\setsuzoku.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        TextBox_Syainid.Text = jsonobj("Syainid")
        TextBox_Syainmei.Text = jsonobj("Syainmei")
        TextBox_Password.Text = jsonobj("Password")
        TextBox_Teamlabel.Text = jsonobj("Teamlabel")
        TextBox_App.Text = jsonobj("app")
        TextBox_Monitor.Text = jsonobj("Monitor")
        Form_Default.Enabled = False
        Form_Kobetsu.Enabled = False
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles MyBase.Closed
        Form_Default.Enabled = True
        Form_Kobetsu.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("チームラベル検索を行うボタンです。応援等や異動（東写真部→大写真部などを想定）でチームラベルが変更時に使用")
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        'json書誌の設定をし、保存する
        Dim data = New JsonShoshi With
        {
    .Syainid = TextBox_Syainid.Text,
    .Syainmei = TextBox_Syainmei.Text,
    .Password = TextBox_Password.Text,
    .Teamlabel = TextBox_Teamlabel.Text,
    .app = TextBox_App.Text,
    .Monitor = TextBox_Monitor.Text
        }
        Dim jsonFilepath As String = strCurrentDir & "\setting\setsuzoku.json"
        My.Computer.FileSystem.DeleteFile(jsonFilepath)
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(jsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
        MsgBox("保存しました")
        Me.Close()
        Form_Default.LoginUser()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox_Password.PasswordChar = "●" Then
            TextBox_Password.PasswordChar = ""
        Else
            TextBox_Password.PasswordChar = "●"
        End If
    End Sub

    Private Sub Button_Sarch_Click(sender As Object, e As EventArgs) Handles Button_Sarch.Click
        Dim OpenFileDialog1 As New OpenFileDialog()
        OpenFileDialog1.Title = "連携するアプリを選択"
        'ファイル選択ダイアログの設定
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "すべてのファイル|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = False
        Dim originalFilePath As String
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            originalFilePath = OpenFileDialog1.FileName
            TextBox_App.Text = originalFilePath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New FolderBrowserDialog
        'OpenFileDialog1. = "監視先フォルダを選択"
        ''ファイル選択ダイアログの設定
        'OpenFileDialog1.InitialDirectory = "C:\"
        'OpenFileDialog1.FileName = ""
        'OpenFileDialog1.Filter = "すべてのファイル|*.*"
        'OpenFileDialog1.FilterIndex = 1
        'OpenFileDialog1.RestoreDirectory = True
        'OpenFileDialog1.Multiselect = False
        Dim originalFilePath As String
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            originalFilePath = OpenFileDialog1.SelectedPath
            TextBox_Monitor.Text = originalFilePath

        End If
    End Sub
End Class