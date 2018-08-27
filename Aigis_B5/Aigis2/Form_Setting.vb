Imports System.Console
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization
Imports Newtonsoft.Json.Linq
Public Class Form_Setting
    ' カレントディレクトリの取得
    Dim currentdir As String = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location)
    Public Class jsonSetting
        Public Property hinagatadefo As Dictionary(Of String, String)
        Public Property hinagata1 As Dictionary(Of String, String)
        Public Property hinagata2 As Dictionary(Of String, String)
        Public Property hinagata3 As Dictionary(Of String, String)
        Public Property hinagata4 As Dictionary(Of String, String)
        Public Property hinagata5 As Dictionary(Of String, String)
        Public Property photographer As Dictionary(Of String, String)
        Public Property photoplace As Dictionary(Of String, String)
        Public Property syukkoyotei As Dictionary(Of String, String)
    End Class

    'フォーム起動時にsetting.jsonから設定を読み込む
    Private Sub FormSetting_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim jsonhinagata As String = currentdir & "\setting\setting.json"
        Dim enc As Encoding = Encoding.UTF8
        Dim jsonstr As String = ""
        Dim jsonfilepath As String = jsonhinagata
        Using sr As New System.IO.StreamReader(jsonfilepath, enc)
            jsonstr = sr.ReadToEnd()
        End Using
        Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
        '雛形の読込
        TextBox_Hinakarimidefo.Text = jsonobj("hinagatadefo")("karimidashi")
        TextBox_Hinakarimi1.Text = jsonobj("hinagata1")("karimidashi")
        TextBox_Hinakarimi2.Text = jsonobj("hinagata2")("karimidashi")
        TextBox_Hinakarimi3.Text = jsonobj("hinagata3")("karimidashi")
        TextBox_Hinakarimi4.Text = jsonobj("hinagata4")("karimidashi")
        TextBox_Hinakarimi5.Text = jsonobj("hinagata5")("karimidashi")
        TextBox_Hinacaptiondefo.Text = jsonobj("hinagatadefo")("karimidashi")
        TextBox_Hinacaption1.Text = jsonobj("hinagata1")("caption")
        TextBox_Hinacaption2.Text = jsonobj("hinagata2")("caption")
        TextBox_Hinacaption3.Text = jsonobj("hinagata3")("caption")
        TextBox_Hinacaption4.Text = jsonobj("hinagata4")("caption")
        TextBox_Hinacaption5.Text = jsonobj("hinagata5")("caption")
        ''撮影者の読込
        TextBox_Photographer1.Text = jsonobj("photographer")("photographer1")
        TextBox_Photographer2.Text = jsonobj("photographer")("photographer2")
        TextBox_Photographer3.Text = jsonobj("photographer")("photographer3")
        TextBox_Photographer4.Text = jsonobj("photographer")("photographer4")
        '撮影場所の読込
        TextBox_Photoplace1.Text = jsonobj("photoplace")("photoplace1")
        TextBox_Photoplace2.Text = jsonobj("photoplace")("photoplace2")
        TextBox_Photoplace3.Text = jsonobj("photoplace")("photoplace3")
        TextBox_Photoplace4.Text = jsonobj("photoplace")("photoplace4")
        '出稿予定の読込
        TextBox_Syukkoyotei1.Text = jsonobj("syukkoyotei")("syukkoyotei1")
        TextBox_Syukkoyotei2.Text = jsonobj("syukkoyotei")("syukkoyotei2")
        TextBox_Syukkoyotei3.Text = jsonobj("syukkoyotei")("syukkoyotei3")
        TextBox_Syukkoyotei4.Text = jsonobj("syukkoyotei")("syukkoyotei4")
        Form_Default.Enabled = False
        Form_Kobetsu.Enabled = False
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles MyBase.Closed
        Form_Default.Enabled = True
        Form_Kobetsu.Enabled = True
    End Sub

    Private Sub Button_OK_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("変更を保存しますか？",
                                                     "質問",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button1)
        '「いいえ」を選択時何もしない
        If result = DialogResult.No Then
            Exit Sub
        End If
        '雛形の書き込み--ここから--
        Dim jsonhinagata As String = currentdir & "\setting\setting.json"
        'json書誌の設定をし、保存する
        Dim data = New jsonSetting With
                        {
                         .hinagatadefo = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimidefo.Text},
                         {"caption", TextBox_Hinacaptiondefo.Text}
                         },
                         .hinagata1 = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimi1.Text},
                         {"caption", TextBox_Hinacaption1.Text}
                         },
                         .hinagata2 = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimi2.Text},
                         {"caption", TextBox_Hinacaption2.Text}
                         },
                         .hinagata3 = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimi3.Text},
                         {"caption", TextBox_Hinacaption3.Text}
                         },
                         .hinagata4 = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimi4.Text},
                         {"caption", TextBox_Hinacaption4.Text}
                         },
                         .hinagata5 = New Dictionary(Of String, String) From
                         {
                         {"karimidashi", TextBox_Hinakarimi5.Text},
                         {"caption", TextBox_Hinacaption5.Text}
                         },
                         .photographer = New Dictionary(Of String, String) From
                         {
                         {"photographer1", TextBox_Photographer1.Text},
                         {"photographer2", TextBox_Photographer2.Text},
                         {"photographer3", TextBox_Photographer3.Text},
                         {"photographer4", TextBox_Photographer4.Text}
                         },
                         .photoplace = New Dictionary(Of String, String) From
                         {
                         {"photoplace1", TextBox_Photoplace1.Text},
                         {"photoplace2", TextBox_Photoplace2.Text},
                         {"photoplace3", TextBox_Photoplace3.Text},
                         {"photoplace4", TextBox_Photoplace4.Text}
                         },
                         .syukkoyotei = New Dictionary(Of String, String) From
                         {
                         {"syukkoyotei1", TextBox_Syukkoyotei1.Text},
                         {"syukkoyotei2", TextBox_Syukkoyotei2.Text},
                         {"syukkoyotei3", TextBox_Syukkoyotei3.Text},
                         {"syukkoyotei4", TextBox_Syukkoyotei4.Text}
                         }
                        }
        My.Computer.FileSystem.DeleteFile(jsonhinagata)
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(jsonhinagata, True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
        MsgBox("変更を保存しました")
        Form_Default.ListUpdate()
        Me.Close()
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

End Class