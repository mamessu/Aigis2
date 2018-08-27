Imports System.IO
Imports System.Text
Imports System.Net
Imports Newtonsoft.Json
Public Class Form_Send

    Dim curdirPath As String = System.IO.Path.GetDirectoryName _
        (System.Reflection.Assembly.GetExecutingAssembly().Location) ' カレントディレクトリの取得

    'JsonItem Class = Aigis内の書誌をまとめたJsonクラス
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

    'JsonOut Class = MIRAI出力時の書誌をまとめたJsonクラス
    Public Class JsonOut
        Public Property karimidashi1 As Dictionary(Of String, String) '仮見出し
        Public Property photographer As Dictionary(Of String, String) '撮影者
        Public Property photoLocation As Dictionary(Of String, String) '撮影場所
        Public Property photoCaption As Dictionary(Of String, String) '写真説明
        Public Property dontUseFlg1 As Dictionary(Of String(), String()) '紙利用制限
        Public Property osusume As Dictionary(Of String, String) 'オススメ
    End Class

    'コントロール配列のフィールドを作成
    Private Panels() As System.Windows.Forms.Panel
    Private PictureBoxs() As System.Windows.Forms.PictureBox
    Private TextBox_Karimi() As System.Windows.Forms.TextBox
    Private TextBox_Syukkoyotei() As System.Windows.Forms.TextBox
    Private Textbox_Psetsu() As System.Windows.Forms.RichTextBox
    Private Button_Remove() As System.Windows.Forms.Button
    Private Button_Overwright() As System.Windows.Forms.Button
    Private Button_Recommend() As System.Windows.Forms.Button
    Private CheckBox_Shimen() As System.Windows.Forms.CheckBox
    Private CheckBox_Web() As System.Windows.Forms.CheckBox
    Private CheckBox_Viewer() As System.Windows.Forms.CheckBox
    Private CheckBox_Gaihan() As System.Windows.Forms.CheckBox
    Private Filepath() As String
    Private Capsion1() As String
    Private Capsion2() As String
    Public Sub Panelon()
        Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        'ボタンコントロール配列の作成
        Panels = New System.Windows.Forms.Panel(Count - 1) {}
        PictureBoxs = New System.Windows.Forms.PictureBox(Count - 1) {}
        TextBox_Karimi = New System.Windows.Forms.TextBox(Count - 1) {}
        TextBox_Syukkoyotei = New System.Windows.Forms.TextBox(Count - 1) {}
        Textbox_Psetsu = New System.Windows.Forms.RichTextBox(Count - 1) {}
        Button_Remove = New System.Windows.Forms.Button(Count - 1) {}
        Button_Overwright = New System.Windows.Forms.Button(Count - 1) {}
        Button_Recommend = New System.Windows.Forms.Button(Count - 1) {}
        CheckBox_Shimen = New System.Windows.Forms.CheckBox(Count - 1) {}
        CheckBox_Web = New System.Windows.Forms.CheckBox(Count - 1) {}
        CheckBox_Viewer = New System.Windows.Forms.CheckBox(Count - 1) {}
        CheckBox_Gaihan = New System.Windows.Forms.CheckBox(Count - 1) {}
        Filepath = New String(Count - 1) {}
        Capsion1 = New String(Count - 1) {}
        Capsion2 = New String(Count - 1) {}
        Dim NameArray As String()
        Dim i As Integer
        For i = 0 To Count - 1
            'インスタンス作成            
            Panels(i) = New System.Windows.Forms.Panel
            PictureBoxs(i) = New System.Windows.Forms.PictureBox
            TextBox_Karimi(i) = New System.Windows.Forms.TextBox
            TextBox_Syukkoyotei(i) = New System.Windows.Forms.TextBox
            Textbox_Psetsu(i) = New System.Windows.Forms.RichTextBox
            Button_Remove(i) = New System.Windows.Forms.Button
            Button_Overwright(i) = New System.Windows.Forms.Button
            Button_Recommend(i) = New System.Windows.Forms.Button
            CheckBox_Shimen(i) = New System.Windows.Forms.CheckBox
            CheckBox_Web(i) = New System.Windows.Forms.CheckBox
            CheckBox_Viewer(i) = New System.Windows.Forms.CheckBox
            CheckBox_Gaihan(i) = New System.Windows.Forms.CheckBox
            NameArray = Split(Form_Default.ListBox_Queue.Items(i), "　［ファイルパス］")
            'jsonから書誌の読み出し
            Dim jpgfile As String = NameArray(1)
            Dim filename As String = System.IO.Path.GetFileName(jpgfile)
            Dim filenamewithout As String = System.IO.Path.GetFileNameWithoutExtension(jpgfile)
            Dim dire As String = System.IO.Path.GetDirectoryName(jpgfile)
            Dim enc As Encoding = Encoding.UTF8
            Dim jsonstr As String = ""
            Dim jsonfilepath As String = dire & "\" & filenamewithout & ".json"
            Using sr As New System.IO.StreamReader(jsonfilepath, enc)
                jsonstr = sr.ReadToEnd()
            End Using
            Dim jsonobj As Object = JsonConvert.DeserializeObject(jsonstr)
            'ピクチャーボックスのプロパティ設定
            Panels(i).Controls.Add(PictureBoxs(i))
            PictureBoxs(i).BackColor = Color.FromKnownColor(KnownColor.ControlDark)
            PictureBoxs(i).Name = "PictureBoxs" + i.ToString()
            PictureBoxs(i).Size = New Size(120, 120)
            PictureBoxs(i).Location = New Point(25, 25)
            'listview表示用サムネイルの作成
            Dim canvas As New Bitmap(120, 120)
            Dim image As New Bitmap(jpgfile)
            Dim jpgwith As Integer = image.Width
            Dim jpgheight As Integer = image.Height
            Dim maginwith As Integer
            Dim maginheight As Integer
            If jpgwith > jpgheight Then
                jpgheight = 120 * jpgheight / jpgwith
                jpgwith = 120
                maginwith = 0
                maginheight = (120 - jpgheight) / 2
            Else
                jpgwith = 120 * jpgwith / jpgheight
                jpgheight = 120
                maginwith = (120 - jpgwith) / 2
                maginheight = 0
            End If
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.DrawImage(image, maginwith, maginheight, jpgwith, jpgheight)
            PictureBoxs(i).Image = canvas
            image.Dispose()
            '仮見出しのプロパティ設定
            Panels(i).Controls.Add(TextBox_Karimi(i))
            TextBox_Karimi(i).BackColor = Color.FromKnownColor(KnownColor.White)
            TextBox_Karimi(i).Name = "TaxtBox_Karimi" + i.ToString()
            TextBox_Karimi(i).Multiline = False
            TextBox_Karimi(i).Size = New Size(180, 25)
            TextBox_Karimi(i).Location = New Point(160, 25)
            TextBox_Karimi(i).Text = jsonobj("karimidashi")
            '出稿予定のプロパティ設定
            Panels(i).Controls.Add(TextBox_Syukkoyotei(i))
            TextBox_Syukkoyotei(i).BackColor = Color.FromKnownColor(KnownColor.White)
            TextBox_Syukkoyotei(i).Name = "TaxtBox_Syukkoyotei" + i.ToString()
            TextBox_Syukkoyotei(i).Multiline = False
            TextBox_Syukkoyotei(i).Size = New Size(100, 25)
            TextBox_Syukkoyotei(i).Location = New Point(360, 25)
            TextBox_Syukkoyotei(i).Text = jsonobj("syukkoyotei")
            'Ｐ説のプロパティ設定
            Panels(i).Controls.Add(Textbox_Psetsu(i))
            Textbox_Psetsu(i).BackColor = Color.FromKnownColor(KnownColor.White)
            Textbox_Psetsu(i).Name = "TaxtBox_Psetsu" + i.ToString()
            Textbox_Psetsu(i).Multiline = True
            Textbox_Psetsu(i).Size = New Size(300, 70)
            Textbox_Psetsu(i).Location = New Point(160, 52)
            Capsion1(i) = jsonobj("capsion1")
            Capsion2(i) = jsonobj("capsion2")
            Textbox_Psetsu(i).AppendText(jsonobj("capsion1"))
            Textbox_Psetsu(i).AppendText(jsonobj("capsion2"))
            Dim Length As String = jsonobj("capsion2").ToString.Length
            Textbox_Psetsu(i).Select(Textbox_Psetsu(i).TextLength - Length, Length + 1)
            Textbox_Psetsu(i).SelectionBackColor = Color.FromKnownColor(KnownColor.ControlLight)
            Textbox_Psetsu(i).SelectionProtected = True
            'イベントハンドラに関連付け
            AddHandler Me.Textbox_Psetsu(i).TextChanged, AddressOf Me.Textbox_Psetsu_TextChanged
            '削除ボタンのプロパティ設定
            Panels(i).Controls.Add(Button_Remove(i))
            Button_Remove(i).Name = "Button_Remove" + i.ToString()
            Button_Remove(i).Text = "削除"
            Button_Remove(i).Size = New Size(50, 25)
            Button_Remove(i).Location = New Point(480, 95)
            'イベントハンドラに関連付け
            AddHandler Me.Button_Remove(i).Click, AddressOf Me.Button_Remove_Click
            '上書きボタンのプロパティ設定
            Panels(i).Controls.Add(Button_Overwright(i))
            Button_Overwright(i).Name = "Button_Overwright" + i.ToString()
            Button_Overwright(i).Text = "保存"
            Button_Overwright(i).Size = New Size(50, 25)
            Button_Overwright(i).Location = New Point(480, 55)
            'イベントハンドラに関連付け
            AddHandler Me.Button_Overwright(i).Click, AddressOf Me.Button_Overwright_Click
            'オススメボタンのプロパティ設定
            Panels(i).Controls.Add(Button_Recommend(i))
            Button_Recommend(i).Name = "Button_Recommend" + i.ToString()
            Button_Recommend(i).Size = New Size(30, 30)
            Button_Recommend(i).Location = New Point(485, 20)
            Button_Recommend(i).FlatStyle = FlatStyle.Flat
            Button_Recommend(i).FlatAppearance.BorderSize = "0"
            If jsonobj("recommendFlag") = 0 Then
                Button_Recommend(i).BackgroundImage = System.Drawing.Image.FromFile(curdirPath & "\data\Icon\whitestar.png")
                Button_Recommend(i).BackgroundImageLayout = ImageLayout.Stretch
            Else
                Button_Recommend(i).BackgroundImage = System.Drawing.Image.FromFile(curdirPath & "\data\Icon\yellowstar.png")
                Button_Recommend(i).BackgroundImageLayout = ImageLayout.Zoom
            End If
            'イベントハンドラに関連付け
            AddHandler Me.Button_Recommend(i).Click, AddressOf Me.Button_Recommend_Click
            '新聞利用可のプロパティ設定
            Panels(i).Controls.Add(CheckBox_Shimen(i))
            CheckBox_Shimen(i).Name = "CheckBox_Shimen" + i.ToString()
            CheckBox_Shimen(i).Text = "紙面不可"
            CheckBox_Shimen(i).Size = New Size(110, 25)
            CheckBox_Shimen(i).Location = New Point(130, 125)
            CheckBox_Shimen(i).RightToLeft = RightToLeft.Yes
            If jsonobj("dontUseTyp").ToString.Contains("01") Then
                CheckBox_Shimen(i).Checked = True
            End If
            'Web利用可のプロパティ設定
            Panels(i).Controls.Add(CheckBox_Web(i))
            CheckBox_Web(i).Name = "CheckBox_Web" + i.ToString()
            CheckBox_Web(i).Text = "Web不可"
            CheckBox_Web(i).Size = New Size(110, 25)
            CheckBox_Web(i).Location = New Point(220, 125)
            CheckBox_Web(i).RightToLeft = RightToLeft.Yes
            If jsonobj("dontUseTyp").ToString.Contains("02") Then
                CheckBox_Web(i).Checked = True
            End If
            'Viewer利用可のプロパティ設定
            Panels(i).Controls.Add(CheckBox_Viewer(i))
            CheckBox_Viewer(i).Name = "CheckBox_Viewer" + i.ToString()
            CheckBox_Viewer(i).Text = "Viewer不可"
            CheckBox_Viewer(i).Size = New Size(110, 25)
            CheckBox_Viewer(i).Location = New Point(325, 125)
            CheckBox_Viewer(i).RightToLeft = RightToLeft.Yes
            If jsonobj("dontUseTyp").ToString.Contains("03") Then
                CheckBox_Viewer(i).Checked = True
            End If
            '外販利用可のプロパティ設定
            Panels(i).Controls.Add(CheckBox_Gaihan(i))
            CheckBox_Gaihan(i).Name = "CheckBox_Gaihan" + i.ToString()
            CheckBox_Gaihan(i).Text = "外販不可"
            CheckBox_Gaihan(i).Size = New Size(110, 25)
            CheckBox_Gaihan(i).Location = New Point(420, 125)
            CheckBox_Gaihan(i).RightToLeft = RightToLeft.Yes
            If jsonobj("dontUseTyp").ToString.Contains("04") Then
                CheckBox_Gaihan(i).Checked = True
            End If
            'パネルのプロパティ設定
            Panel_List.Controls.Add(Panels(i))
            Panels(i).BorderStyle = BorderStyle.FixedSingle
            Panels(i).BackColor = Color.FromKnownColor(KnownColor.ControlLight)
            Panels(i).Name = "Panels" + i.ToString()
            Panels(i).Size = New Size(550, 170)
            Panels(i).Location = New Point(10, 180 * (i) + 10)
            'ファイルパスの格納
            Filepath(i) = jpgfile
            '全体件数の表示
            Label_Count.Text = "全" & Count & "件"
        Next i
    End Sub

    'フォームのLoadイベントハンドラ
    Private Sub Form1_Load(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles MyBase.Load
        Panelon()
        Form_Default.Enabled = False
        Form_Kobetsu.Enabled = False
    End Sub

    'フォームのClosedイベントハンドラ
    Private Sub Form1_Closed(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles MyBase.Closed
        Form_Default.Enabled = True
        Form_Kobetsu.Enabled = True
    End Sub

    '「送信」ボタン押下時
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '認証APIを叩く→JWTの取得
        Dim auth_url As String = "http://dev-front-ex-499365898.ap-northeast-1.elb.amazonaws.com/ccs-service/system/aegis/hoge/auth/system/"
        Dim auth_req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(auth_url)
        'Headerの指定
        auth_req.Method = "POST"
        auth_req.ContentType = "application/json"
        'Bodyの記載(JSONファイルの中身をBodyに転記)
        Dim auth_jsonFilepath As String = curdirPath & "\setting\auth.json"
        Dim auth_body As String
        Using auth_sr1 As New System.IO.StreamReader(auth_jsonFilepath, Encoding.UTF8)
            auth_body = auth_sr1.ReadToEnd()
        End Using
        'RequestStreamにBodyを書き込む
        Dim auth_reqbody As Byte() = Encoding.ASCII.GetBytes(auth_body)
        Dim auth_reqStream As System.IO.Stream = auth_req.GetRequestStream()
        auth_reqStream.Write(auth_reqbody, 0, auth_reqbody.Length)
        auth_reqStream.Close()
        'WebResponseからJWTを取得
        Dim auth_res As System.Net.HttpWebResponse = auth_req.GetResponse()
        Dim JWT As String = auth_res.Headers.Get("newauthorization")
        'ステータス等を取得するために使用（未使用だが今後のため）
        Dim auth_resStream As System.IO.Stream = auth_res.GetResponseStream()
        Dim auth_sr2 As New System.IO.StreamReader(auth_resStream, Encoding.UTF8)
        auth_sr2.Close()
        'MsgBox(JWT)

        'Search(JWT)

        Upload(JWT)

        ''20180619
        'Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        'Dim i As Integer
        'For i = 1 To Count
        '    Dim NameArray As String() = Split(Form_Default.ListBox_Queue.Items(i　-1), "　［ファイルパス］")
        '    Dim imageFilePath As String = NameArray(1)
        '    Dim direPath As String = System.IO.Path.GetDirectoryName(imageFilePath)
        '    Dim imageFilePathwithout As String = System.IO.Path.GetFileNameWithoutExtension(imageFilePath)
        '    Dim jsonFilepath As String = direPath & "\" & imageFilePathwithout & ".json"
        '    Dim jsonStr As String
        '    Dim enc As Encoding = Encoding.UTF8
        '    'ファイルからJson文字列を読み込む
        '    Using sr As New System.IO.StreamReader(jsonFilepath, enc)
        '        jsonStr = sr.ReadToEnd()
        '        'MsgBox(jsonStr)
        '    End Using
        '    'Json文字列をJson形式データに復元する
        '    Dim jsonObj As Object = JsonConvert.DeserializeObject(jsonStr)
        '    Dim Status As String = jsonObj("status")
        '    Dim Timeflag As String = jsonObj("timeFlag")
        '    Dim Mainichiflag As String = jsonObj("daihyoFlag")
        '    Dim Photographer As String = jsonObj("photographer")
        '    Dim Phototime1 As String = jsonObj("phototime1")
        '    Dim Phototime2 As String = jsonObj("phototime2")
        '    Dim Photoplace As String = jsonObj("photoplace")
        '    Dim Registtime As String = jsonObj("registtime")
        '    My.Computer.FileSystem.DeleteFile(jsonFilepath)
        '    Dim hairetsu As New List(Of String)
        '    If CheckBox_Shimen(i).Checked = True Then
        '        hairetsu.Add("01")
        '    End If
        '    If CheckBox_Web(i).Checked = True Then
        '        hairetsu.Add("02")
        '    End If
        '    If CheckBox_Viewer(i).Checked = True Then
        '        hairetsu.Add("03")
        '    End If
        '    If CheckBox_Gaihan(i).Checked = True Then
        '        hairetsu.Add("04")
        '    End If
        '    Dim dontUseTyp(hairetsu.Count - 1) As String
        '    If hairetsu.Count <> 0 Then
        '        Dim j As Integer
        '        For j = 0 To hairetsu.Count - 1
        '            dontUseTyp(j) = hairetsu(j)
        '        Next j
        '        MsgBox(dontUseTyp)
        '    End If
        '    Dim recommendFlug As Integer
        '    If Button_Recommend(i).BackgroundImageLayout = ImageLayout.Stretch Then
        '        recommendFlug = 0
        '    Else
        '        recommendFlug = 1
        '    End If
        '    'json書誌の設定をし、保存する
        '    Dim data = New JsonItem With
        '                {
        '                .karimidashi = TextBox_Karimi(i).Text,
        '                .status = "済",
        '                .capsion1 = Capsion1(i),
        '                .capsion2 = Capsion2(i),
        '                .timeFlag = Timeflag,
        '                .daihyoFlag = Mainichiflag,
        '                .dontUseTyp = dontUseTyp,
        '                .syukkoyotei = TextBox_Syukkoyotei(i).Text,
        '                .photographer = Photographer,
        '                .phototime1 = Phototime1,
        '                .phototime2 = Phototime2,
        '                .photoplace = Photoplace,
        '                .registtime = Registtime,
        '                .recommendFlag = recommendFlug
        '                }
        '    Dim JsonFile As System.IO.StreamWriter
        '    JsonFile = New System.IO.StreamWriter(jsonFilepath, True, System.Text.Encoding.UTF8)
        '    JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        '    JsonFile.Close()
        '    Panels(i).BackColor = Color.FromKnownColor(KnownColor.Blue)
        'Next i
        'Form_Default.ListBox_Queue.Items.Clear()
        'Form_Default.LibraryReload()

        ''送信条件が整っているか確認する（本番想定でインターネット接続を確認しています）
        'If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = False Then
        '    MsgBox("インターネットに接続されていません。")
        '    Exit Sub
        'End If
        ''送信するファイルのパス（＝選択されたもの）
        'Dim fileName(Count) As String

        ''----------------------------
        ''-----ここからWebAPI接続-----
        ''----------------------------
        ''-----------------------------------------
        ''----multipart/form-dataを使用する場合----
        ''-----------------------------------------
        'Dim i As Integer
        ''以下をループして複数送信する。（＝複数リクエスト）
        'For i = 1 To Count
        '    fileName(i) = System.IO.Path.GetFileName(Filepath(i))
        '    '送信先のURL
        '    Dim url As String = "http://localhost:8080/api/file/upload"
        '    '文字コード
        '    Dim enc As System.Text.Encoding =
        '        System.Text.Encoding.GetEncoding("UTF-8")
        '    'boundary文字列の指定
        '    Dim boundary As String = System.Environment.TickCount.ToString()
        '    'WebRequestの作成
        '    Dim req As System.Net.HttpWebRequest =
        '        CType(System.Net.WebRequest.Create(url),
        '            System.Net.HttpWebRequest)
        '    'MethodにPOSTを指定
        '    req.Method = "POST"
        '    'ContentTypeを設定
        '    req.ContentType = "multipart/form-data; boundary=" + boundary
        '    'Bodyの上部、下部を作成し、バイト型配列に変換（※改行コードの場所、数を間違えるとエラーになる）
        '    Dim postData(Count) As String
        '    postData(i) = "--" + boundary + vbCrLf +
        '    "Content-Disposition: form-data; name=""file""; filename=""" + fileName(i) + """" + vbCrLf + vbCrLf
        '    Dim startData() As Byte = enc.GetBytes(postData(i))
        '    postData(i) = vbCrLf + "--" + boundary + "--" + vbCrLf
        '    Dim endData() As Byte = enc.GetBytes(postData(i))
        '    '送信するファイルをバイト型配列に変換
        '    Dim fs As New System.IO.FileStream(
        '        Filepath(i),
        '        System.IO.FileMode.Open,
        '        System.IO.FileAccess.Read)
        '    Dim br As New BinaryReader(fs)
        '    Dim sendData() As Byte = br.ReadBytes(CType(fs.Length, Integer))
        '    br.Close()
        '    fs.Close()
        '    'POST送信するデータの長さを指定
        '    req.ContentLength = startData.Length + sendData.Length + endData.Length
        '    'データをPOST送信するためのStreamを取得
        '    Dim reqStream As System.IO.Stream = req.GetRequestStream()
        '    '送信するデータを順番に書き込む
        '    reqStream.Write(startData, 0, startData.Length)
        '    reqStream.Write(sendData, 0, sendData.Length)
        '    reqStream.Write(endData, 0, endData.Length)
        '    reqStream.Close()
        '    'サーバーからの応答を受信するためのWebResponseを取得
        '    Dim res As System.Net.HttpWebResponse =
        '        CType(req.GetResponse(), System.Net.HttpWebResponse)
        '    '応答データを受信するためのStreamを取得
        '    Dim resStream As System.IO.Stream = res.GetResponseStream()
        '    '受信して表示（表示しない＝不要）
        '    Dim sr As New System.IO.StreamReader(resStream, enc)
        '    Console.WriteLine(sr.ReadToEnd())
        '    '閉じる
        '    sr.Close()
        'Next i



        '正常終了時
        'MsgBox(Count & "件の送信が完了しました（現状はステータスが変わるだけです。）")
    End Sub

    '認証APIを叩く→JWTの取得
    Private Sub Auth()
        Dim auth_url As String = "http://dev-front-ex-499365898.ap-northeast-1.elb.amazonaws.com/ccs-service/system/aegis/hoge/auth/system/"
        Dim auth_req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(auth_url)
        'Headerの指定
        auth_req.Method = "POST"
        auth_req.ContentType = "application/json"
        'Bodyの記載(JSONファイルの中身をBodyに転記)
        Dim auth_jsonFilepath As String = curdirPath & "\setting\auth.json"
        Dim auth_body As String
        Using auth_sr1 As New System.IO.StreamReader(auth_jsonFilepath, Encoding.UTF8)
            auth_body = auth_sr1.ReadToEnd()
        End Using
        'RequestStreamにBodyを書き込む
        Dim auth_reqbody As Byte() = Encoding.ASCII.GetBytes(auth_body)
        Dim auth_reqStream As System.IO.Stream = auth_req.GetRequestStream()
        auth_reqStream.Write(auth_reqbody, 0, auth_reqbody.Length)
        auth_reqStream.Close()
        'WebResponseからJWTを取得
        Dim auth_res As System.Net.HttpWebResponse = auth_req.GetResponse()
        Dim JWT As String = auth_res.Headers.Get("newauthorization")
        'ステータス等を取得するために使用（未使用だが今後のため）
        Dim auth_resStream As System.IO.Stream = auth_res.GetResponseStream()
        Dim auth_sr2 As New System.IO.StreamReader(auth_resStream, Encoding.UTF8)
        auth_sr2.Close()
        MsgBox(JWT)
    End Sub

    '出稿予定検索APIを叩く→itemGroupIdの取得
    Private Sub Search(ByVal JWT As String)
        Dim search_url As String = "http://dev-front-ex-499365898.ap-northeast-1.elb.amazonaws.com/ccs-service/api/ccs-client/hoge/fetch/rel-resv-list"
        Dim search_req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(search_url)
        'Headerの指定
        search_req.Method = "POST"
        search_req.ContentType = "application/json"
        search_req.Headers.Add("Authorization", "Bearer " & JWT)
        'Bodyの記載(JSONファイルの中身をBodyに転記)
        Dim search_jsonFilepath As String = curdirPath & "\setting\seach.json"
        Dim search_body As String
        Using search_sr1 As New System.IO.StreamReader(search_jsonFilepath, Encoding.UTF8)
            search_body = search_sr1.ReadToEnd()
        End Using
        'RequestStreamにBodyを書き込む
        Dim search_reqbody As Byte() = Encoding.ASCII.GetBytes(search_body)
        Dim search_reqStream As System.IO.Stream = search_req.GetRequestStream()
        search_reqStream.Write(search_reqbody, 0, search_reqbody.Length)
        search_reqStream.Close()
        'WebResponseからitemGroupIdを取得
        Dim search_res As System.Net.HttpWebResponse = search_req.GetResponse()
        Dim search_resStream As System.IO.Stream = search_res.GetResponseStream()
        Dim search_sr2 As New System.IO.StreamReader(search_resStream, Encoding.UTF8)
        Dim search_jsonstr As String = search_sr2.ReadToEnd
        Dim search_jsonobj As Object = JsonConvert.DeserializeObject(search_jsonstr)
        If search_jsonobj("replyParameter")("pagingModel")("totalHits") = 0 Then
            MsgBox("出稿予定が存在しません")
        Else
            Dim itemGroupID As String = search_jsonobj("replyParameter")("relResvItemGroupListModel")(0)("itemGroupId")
            search_sr2.Close()
            MsgBox(itemGroupID)
        End If
    End Sub

    'アップロードAPIを叩く→画像ファイルのアップロード及びuploadFilePathを取得
    Private Sub Upload(ByVal JWT As String)
        ProgressBar2.Visible = True
        ProgressBar2.Minimum = 0
        ProgressBar2.Value = 0
        ProgressBar2.Maximum = Filepath.Count
        ProgressBar2.Update()
        For i = 0 To Filepath.Count - 1
            Dim UP_url As String = "http://dev-front-ex-499365898.ap-northeast-1.elb.amazonaws.com/ccs-service/api/ccs-client/testfunc/upload/file-storage"
            Dim UP_req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(UP_url)
            'Headerの指定
            UP_req.Method = "POST"
            UP_req.Headers.Add("Authorization", "Bearer " & JWT)
            Dim boundary As String = System.Environment.TickCount.ToString()
            UP_req.ContentType = "multipart/form-data; boundary=" & boundary
            'Bodyの上部、下部を作成し、バイト型配列に変換（※改行コードの場所、数を間違えるとエラーになる）
            Dim UP_fileName As String = System.IO.Path.GetFileName(Filepath(i))
            Dim upperData As String
            upperData = "--" + boundary + vbCrLf +
                "Content-Disposition: form-data; name=uploadFile; filename=" + UP_fileName + vbCrLf + vbCrLf
            Dim startData As Byte() = Encoding.ASCII.GetBytes(upperData)
            Dim underData As String
            underData = vbCrLf + "--" + boundary + "--" + vbCrLf
            Dim endData As Byte() = Encoding.ASCII.GetBytes(underData)
            '送信するファイルをバイト型配列に変換
            Dim UP_fs As New System.IO.FileStream(
                Filepath(i),
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read)
            Dim UP_br As New BinaryReader(UP_fs)
            Dim sendData() As Byte = UP_br.ReadBytes(CType(UP_fs.Length, Integer))
            UP_br.Close()
            UP_fs.Close()
            'POST送信するデータの長さを指定
            UP_req.ContentLength = startData.Length + sendData.Length + endData.Length
            'ProgressBar1.Minimum = 0
            'ProgressBar1.Value = 0
            'ProgressBar1.Maximum = UP_req.ContentLength
            '送信するデータを順番にRequestStreamに書き込む
            Dim UP_reqStream As System.IO.Stream = UP_req.GetRequestStream()
            UP_reqStream.Write(startData, 0, startData.Length)
            UP_reqStream.Write(sendData, 0, sendData.Length)
            UP_reqStream.Write(endData, 0, endData.Length)
            UP_reqStream.Close()
            'WebResponseからuploadFilePathを取得
            Dim UP_res As System.Net.HttpWebResponse = UP_req.GetResponse()
            Dim UP_resStream As System.IO.Stream = UP_res.GetResponseStream()
            Dim UP_sr2 As New System.IO.StreamReader(UP_resStream, Encoding.UTF8)
            Dim UP_jsonstr As String = UP_sr2.ReadToEnd
            Dim UP_jsonobj As Object = JsonConvert.DeserializeObject(UP_jsonstr)
            Dim uploadFilePath As String = UP_jsonobj("replyParameter")("uploadFilePath")
            UP_sr2.Close()
            Panels(i).BackColor = Color.Blue
            Panels(i).Update()
            ProgressBar2.Value = ProgressBar2.Value + 1
            ProgressBar2.Update()
        Next i
        ProgressBar2.Visible = False
        MsgBox("送信を完了しました")
    End Sub

    '連番付与
    Private Sub Button_Renban_Click(sender As Object, e As EventArgs) Handles Button_Renban.Click
        Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        Dim Renban As Integer = TextBox_Renban.Text
        Dim harf As String
        Dim i As Integer
        For i = 0 To Count - 1
            harf = Renban + i
            harf = StrConv(harf, VbStrConv.Wide)
            If RadioButton_Karimi.Checked = True Then
                TextBox_Karimi(i).Text = TextBox_Rens.Text & harf & TextBox_Renf.Text & TextBox_Karimi(i).Text
            ElseIf RadioButton_Psetsu.Checked = True Then
                Textbox_Psetsu(i).Text = TextBox_Rens.Text & harf & TextBox_Renf.Text & Textbox_Psetsu(i).Text
                Dim Length As String = Capsion2(i).Length
                Capsion1(i) = Textbox_Psetsu(i).Text.Substring(0, Textbox_Psetsu(i).TextLength - Length)
                Textbox_Psetsu(i).Select(Capsion1(i).Length, Length)
                Textbox_Psetsu(i).SelectionBackColor = Color.FromKnownColor(KnownColor.ControlLight)
                Textbox_Psetsu(i).SelectionProtected = True
                Textbox_Psetsu(i).Select(0, 0)
            End If
        Next i
    End Sub

    Private Sub Textbox_Psetsu_TextChanged(sender As Object, e As EventArgs)
        Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        Dim Point As Integer
        Dim i As Integer
        For i = 0 To Count - 1
            If Textbox_Psetsu(i).Equals(sender) Then
                Point = i
            End If
        Next i
        Dim Length As String = Capsion2(Point).Length
        Capsion1(Point) = Textbox_Psetsu(Point).Text.Substring(0, Textbox_Psetsu(Point).TextLength - Length)
        'テキストを最初まで消しても書けるように
        Textbox_Psetsu(Point).SelectionBackColor = Color.FromKnownColor(KnownColor.White)
        Textbox_Psetsu(Point).SelectionProtected = False
    End Sub

    '「削除」ボタン押下時
    Private Sub Button_Remove_Click(sender As Object, e As EventArgs)
        Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        Dim Point As Integer
        Dim i As Integer
        For i = 0 To Count - 1
            If Button_Remove(i).Equals(sender) Then
                Point = i
            End If
        Next i
        Dim NameArray As String() = Split(Form_Default.ListBox_Queue.Items(Point), "　［ファイルパス］")
        Dim Allcount As Integer = Form_Default.ListView_Library.Items.Count
        Dim j As Integer
        For j = 0 To Allcount - 1
            If Form_Default.ListView_Library.Items(j).ImageKey = NameArray(1) Then
                Form_Default.ListView_Library.Items(j).BackColor = Color.FromKnownColor(KnownColor.Window)
            End If
        Next j
        Form_Default.ListBox_Queue.Items.Remove(Form_Default.ListBox_Queue.Items(Point))
        Panel_List.Controls.Clear()
        Panelon()
    End Sub

    '上書きボタン押下時
    Private Sub Button_Overwright_Click(sender As Object, e As EventArgs)
        Dim Count As Integer = Form_Default.ListBox_Queue.Items.Count
        Dim Point As Integer
        Dim i As Integer
        For i = 0 To Count - 1
            If Button_Overwright(i).Equals(sender) Then
                Point = i
            End If
        Next i
        Dim NameArray As String() = Split(Form_Default.ListBox_Queue.Items(Point), "　［ファイルパス］")
        Dim imageFilePath As String = NameArray(1)
        Dim direPath As String = System.IO.Path.GetDirectoryName(imageFilePath)
        Dim imageFilePathwithout As String = System.IO.Path.GetFileNameWithoutExtension(imageFilePath)
        Dim jsonFilepath As String = direPath & "\" & imageFilePathwithout & ".json"
        Dim jsonStr As String
        Dim enc As Encoding = Encoding.UTF8
        'ファイルからJson文字列を読み込む
        Using sr As New System.IO.StreamReader(jsonFilepath, enc)
            jsonStr = sr.ReadToEnd()
            'MsgBox(jsonStr)
        End Using
        'Json文字列をJson形式データに復元する
        Dim jsonObj As Object = JsonConvert.DeserializeObject(jsonStr)
        Dim Status As String = jsonObj("status")
        Dim Timeflag As String = jsonObj("timeflag")
        Dim Mainichiflag As String = jsonObj("mainichiflag")
        Dim Photographer As String = jsonObj("photographer")
        Dim Phototime1 As String = jsonObj("phototime1")
        Dim Phototime2 As String = jsonObj("phototime2")
        Dim Photoplace As String = jsonObj("photoplace")
        Dim Registtime As String = jsonObj("registtime")
        My.Computer.FileSystem.DeleteFile(jsonFilepath)
        Dim hairetsu As New List(Of String)
        If CheckBox_Shimen(Point).Checked = True Then
            hairetsu.Add("01")
        End If
        If CheckBox_Web(Point).Checked = True Then
            hairetsu.Add("02")
        End If
        If CheckBox_Viewer(Point).Checked = True Then
            hairetsu.Add("03")
        End If
        If CheckBox_Gaihan(Point).Checked = True Then
            hairetsu.Add("04")
        End If
        Dim dontUseTyp(hairetsu.Count - 1) As String
        If hairetsu.Count <> 0 Then
            Dim j As Integer
            For j = 0 To hairetsu.Count - 1
                dontUseTyp(j) = hairetsu(j)
            Next j
        End If
        Dim recommendFlug As Integer
        If Button_Recommend(Point).BackgroundImageLayout = ImageLayout.Stretch Then
            recommendFlug = 0
        Else
            recommendFlug = 1
        End If
        'json書誌の設定をし、保存する
        Dim data = New JsonItem With
                        {
                        .karimidashi = TextBox_Karimi(Point).Text,
                        .status = "未",
                        .capsion1 = Capsion1(Point),
                        .capsion2 = Capsion2(Point),
                        .timeFlag = Timeflag,
                        .daihyoFlag = Mainichiflag,
                        .dontUseTyp = dontUseTyp,
                        .syukkoyotei = TextBox_Syukkoyotei(Point).Text,
                        .photographer = Photographer,
                        .phototime1 = Phototime1,
                        .phototime2 = Phototime2,
                        .photoplace = Photoplace,
                        .registtime = Registtime,
                        .recommendFlag = recommendFlug
                        }
        Dim JsonFile As System.IO.StreamWriter
        JsonFile = New System.IO.StreamWriter(jsonFilepath, True, System.Text.Encoding.UTF8)
        JsonFile.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented))
        JsonFile.Close()
    End Sub

    'オススメボタン押下時
    Private Sub Button_Recommend_Click(sender As Object, e As EventArgs)
        If sender.BackgroundImageLayout = ImageLayout.Stretch Then
            sender.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\yellowstar.png")
            sender.BackgroundImageLayout = ImageLayout.Zoom
        Else
            sender.BackgroundImage = Image.FromFile(curdirPath & "\data\Icon\whitestar.png")
            sender.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class