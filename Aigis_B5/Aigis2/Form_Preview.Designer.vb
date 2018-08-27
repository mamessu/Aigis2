<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Preview
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel_Oya = New System.Windows.Forms.Panel()
        Me.Panel_Syoshi = New System.Windows.Forms.Panel()
        Me.Button_Recommend = New System.Windows.Forms.Button()
        Me.GroupBox_a = New System.Windows.Forms.GroupBox()
        Me.CheckBox_Viewer = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Gaihan = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Shimen = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Web = New System.Windows.Forms.CheckBox()
        Me.TextBox_Maxsize = New System.Windows.Forms.TextBox()
        Me.CheckBox_Jikoku = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Mainichi = New System.Windows.Forms.CheckBox()
        Me.BtnSizeChange = New System.Windows.Forms.Button()
        Me.ComboBox_Satsueibasyo = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Syukkoyotei = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_yoko = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox_CapP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_Karimi = New System.Windows.Forms.TextBox()
        Me.ComboBox_Satsueisya = New System.Windows.Forms.ComboBox()
        Me.TextBox_CapHN = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox_Satsueijikoku = New System.Windows.Forms.TextBox()
        Me.Label_tate = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label_filesize = New System.Windows.Forms.Label()
        Me.Button_Queue = New System.Windows.Forms.Button()
        Me.Button_Hozon = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.Label_Select1 = New System.Windows.Forms.Label()
        Me.Label_Bar1 = New System.Windows.Forms.Label()
        Me.Label_Total1 = New System.Windows.Forms.Label()
        Me.Button_Before = New System.Windows.Forms.Button()
        Me.Button_After = New System.Windows.Forms.Button()
        Me.Button_Kirikae = New System.Windows.Forms.Button()
        Me.Label_Gide = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel_Oya.SuspendLayout()
        Me.Panel_Syoshi.SuspendLayout()
        Me.GroupBox_a.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Panel_Oya)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(13, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(849, 459)
        Me.Panel1.TabIndex = 7
        '
        'Panel_Oya
        '
        Me.Panel_Oya.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_Oya.Controls.Add(Me.Panel_Syoshi)
        Me.Panel_Oya.Controls.Add(Me.Button_Queue)
        Me.Panel_Oya.Controls.Add(Me.Button_Hozon)
        Me.Panel_Oya.Location = New System.Drawing.Point(296, 23)
        Me.Panel_Oya.Name = "Panel_Oya"
        Me.Panel_Oya.Size = New System.Drawing.Size(480, 380)
        Me.Panel_Oya.TabIndex = 95
        Me.Panel_Oya.Visible = False
        '
        'Panel_Syoshi
        '
        Me.Panel_Syoshi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel_Syoshi.Controls.Add(Me.Button_Recommend)
        Me.Panel_Syoshi.Controls.Add(Me.GroupBox_a)
        Me.Panel_Syoshi.Controls.Add(Me.TextBox_Maxsize)
        Me.Panel_Syoshi.Controls.Add(Me.CheckBox_Jikoku)
        Me.Panel_Syoshi.Controls.Add(Me.CheckBox_Mainichi)
        Me.Panel_Syoshi.Controls.Add(Me.BtnSizeChange)
        Me.Panel_Syoshi.Controls.Add(Me.ComboBox_Satsueibasyo)
        Me.Panel_Syoshi.Controls.Add(Me.ComboBox_Syukkoyotei)
        Me.Panel_Syoshi.Controls.Add(Me.Label6)
        Me.Panel_Syoshi.Controls.Add(Me.Label2)
        Me.Panel_Syoshi.Controls.Add(Me.Label_yoko)
        Me.Panel_Syoshi.Controls.Add(Me.Label14)
        Me.Panel_Syoshi.Controls.Add(Me.TextBox_CapP)
        Me.Panel_Syoshi.Controls.Add(Me.Label11)
        Me.Panel_Syoshi.Controls.Add(Me.Label7)
        Me.Panel_Syoshi.Controls.Add(Me.TextBox_Karimi)
        Me.Panel_Syoshi.Controls.Add(Me.ComboBox_Satsueisya)
        Me.Panel_Syoshi.Controls.Add(Me.TextBox_CapHN)
        Me.Panel_Syoshi.Controls.Add(Me.Label12)
        Me.Panel_Syoshi.Controls.Add(Me.TextBox_Satsueijikoku)
        Me.Panel_Syoshi.Controls.Add(Me.Label_tate)
        Me.Panel_Syoshi.Controls.Add(Me.Label13)
        Me.Panel_Syoshi.Controls.Add(Me.Label_filesize)
        Me.Panel_Syoshi.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Syoshi.Name = "Panel_Syoshi"
        Me.Panel_Syoshi.Size = New System.Drawing.Size(480, 340)
        Me.Panel_Syoshi.TabIndex = 88
        '
        'Button_Recommend
        '
        Me.Button_Recommend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button_Recommend.BackgroundImage = Global.Aigis2.My.Resources.Resources.whitestar
        Me.Button_Recommend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Recommend.FlatAppearance.BorderSize = 0
        Me.Button_Recommend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Recommend.Location = New System.Drawing.Point(439, 10)
        Me.Button_Recommend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Recommend.Name = "Button_Recommend"
        Me.Button_Recommend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Recommend.Size = New System.Drawing.Size(30, 30)
        Me.Button_Recommend.TabIndex = 112
        Me.Button_Recommend.UseVisualStyleBackColor = True
        '
        'GroupBox_a
        '
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Viewer)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Gaihan)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Shimen)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Web)
        Me.GroupBox_a.Location = New System.Drawing.Point(275, 182)
        Me.GroupBox_a.Name = "GroupBox_a"
        Me.GroupBox_a.Size = New System.Drawing.Size(186, 78)
        Me.GroupBox_a.TabIndex = 115
        Me.GroupBox_a.TabStop = False
        Me.GroupBox_a.Text = "利用制限"
        '
        'CheckBox_Viewer
        '
        Me.CheckBox_Viewer.AutoSize = True
        Me.CheckBox_Viewer.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox_Viewer.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Viewer.Location = New System.Drawing.Point(7, 49)
        Me.CheckBox_Viewer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Viewer.Name = "CheckBox_Viewer"
        Me.CheckBox_Viewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Viewer.Size = New System.Drawing.Size(86, 17)
        Me.CheckBox_Viewer.TabIndex = 115
        Me.CheckBox_Viewer.Text = "Viewer不可"
        Me.CheckBox_Viewer.UseVisualStyleBackColor = True
        '
        'CheckBox_Gaihan
        '
        Me.CheckBox_Gaihan.AutoSize = True
        Me.CheckBox_Gaihan.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Gaihan.Location = New System.Drawing.Point(92, 48)
        Me.CheckBox_Gaihan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Gaihan.Name = "CheckBox_Gaihan"
        Me.CheckBox_Gaihan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Gaihan.Size = New System.Drawing.Size(89, 19)
        Me.CheckBox_Gaihan.TabIndex = 114
        Me.CheckBox_Gaihan.Text = "外販不可"
        Me.CheckBox_Gaihan.UseVisualStyleBackColor = True
        '
        'CheckBox_Shimen
        '
        Me.CheckBox_Shimen.AutoSize = True
        Me.CheckBox_Shimen.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Shimen.Location = New System.Drawing.Point(4, 22)
        Me.CheckBox_Shimen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Shimen.Name = "CheckBox_Shimen"
        Me.CheckBox_Shimen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Shimen.Size = New System.Drawing.Size(89, 19)
        Me.CheckBox_Shimen.TabIndex = 112
        Me.CheckBox_Shimen.Text = "紙面不可"
        Me.CheckBox_Shimen.UseVisualStyleBackColor = True
        '
        'CheckBox_Web
        '
        Me.CheckBox_Web.AutoSize = True
        Me.CheckBox_Web.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Web.Location = New System.Drawing.Point(96, 23)
        Me.CheckBox_Web.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Web.Name = "CheckBox_Web"
        Me.CheckBox_Web.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Web.Size = New System.Drawing.Size(85, 19)
        Me.CheckBox_Web.TabIndex = 113
        Me.CheckBox_Web.Text = "Web不可"
        Me.CheckBox_Web.UseVisualStyleBackColor = True
        '
        'TextBox_Maxsize
        '
        Me.TextBox_Maxsize.Location = New System.Drawing.Point(374, 267)
        Me.TextBox_Maxsize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Maxsize.Name = "TextBox_Maxsize"
        Me.TextBox_Maxsize.Size = New System.Drawing.Size(86, 22)
        Me.TextBox_Maxsize.TabIndex = 91
        '
        'CheckBox_Jikoku
        '
        Me.CheckBox_Jikoku.AutoSize = True
        Me.CheckBox_Jikoku.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Jikoku.Location = New System.Drawing.Point(277, 159)
        Me.CheckBox_Jikoku.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Jikoku.Name = "CheckBox_Jikoku"
        Me.CheckBox_Jikoku.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Jikoku.Size = New System.Drawing.Size(89, 19)
        Me.CheckBox_Jikoku.TabIndex = 90
        Me.CheckBox_Jikoku.Text = "簡易日時"
        Me.CheckBox_Jikoku.UseVisualStyleBackColor = True
        '
        'CheckBox_Mainichi
        '
        Me.CheckBox_Mainichi.AutoSize = True
        Me.CheckBox_Mainichi.ForeColor = System.Drawing.Color.Black
        Me.CheckBox_Mainichi.Location = New System.Drawing.Point(369, 159)
        Me.CheckBox_Mainichi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Mainichi.Name = "CheckBox_Mainichi"
        Me.CheckBox_Mainichi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Mainichi.Size = New System.Drawing.Size(89, 19)
        Me.CheckBox_Mainichi.TabIndex = 89
        Me.CheckBox_Mainichi.Text = "代表撮影"
        Me.CheckBox_Mainichi.UseVisualStyleBackColor = True
        '
        'BtnSizeChange
        '
        Me.BtnSizeChange.ForeColor = System.Drawing.Color.Black
        Me.BtnSizeChange.Location = New System.Drawing.Point(294, 262)
        Me.BtnSizeChange.Name = "BtnSizeChange"
        Me.BtnSizeChange.Size = New System.Drawing.Size(72, 30)
        Me.BtnSizeChange.TabIndex = 94
        Me.BtnSizeChange.Text = "リサイズ"
        Me.BtnSizeChange.UseVisualStyleBackColor = True
        '
        'ComboBox_Satsueibasyo
        '
        Me.ComboBox_Satsueibasyo.FormattingEnabled = True
        Me.ComboBox_Satsueibasyo.Location = New System.Drawing.Point(122, 230)
        Me.ComboBox_Satsueibasyo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Satsueibasyo.Name = "ComboBox_Satsueibasyo"
        Me.ComboBox_Satsueibasyo.Size = New System.Drawing.Size(145, 23)
        Me.ComboBox_Satsueibasyo.TabIndex = 88
        '
        'ComboBox_Syukkoyotei
        '
        Me.ComboBox_Syukkoyotei.FormattingEnabled = True
        Me.ComboBox_Syukkoyotei.Location = New System.Drawing.Point(122, 157)
        Me.ComboBox_Syukkoyotei.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Syukkoyotei.Name = "ComboBox_Syukkoyotei"
        Me.ComboBox_Syukkoyotei.Size = New System.Drawing.Size(145, 23)
        Me.ComboBox_Syukkoyotei.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 38)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Ｐ説" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（本文）"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "文書名"
        '
        'Label_yoko
        '
        Me.Label_yoko.AutoSize = True
        Me.Label_yoko.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_yoko.ForeColor = System.Drawing.Color.Black
        Me.Label_yoko.Location = New System.Drawing.Point(362, 304)
        Me.Label_yoko.Name = "Label_yoko"
        Me.Label_yoko.Size = New System.Drawing.Size(39, 19)
        Me.Label_yoko.TabIndex = 85
        Me.Label_yoko.Text = "横："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(1, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 38)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Ｐ説" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（人＋日時）"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_CapP
        '
        Me.TextBox_CapP.Location = New System.Drawing.Point(122, 48)
        Me.TextBox_CapP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_CapP.Multiline = True
        Me.TextBox_CapP.Name = "TextBox_CapP"
        Me.TextBox_CapP.Size = New System.Drawing.Size(338, 66)
        Me.TextBox_CapP.TabIndex = 53
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(22, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 19)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "撮影者"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "出稿予定"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_Karimi
        '
        Me.TextBox_Karimi.Location = New System.Drawing.Point(122, 15)
        Me.TextBox_Karimi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Karimi.Name = "TextBox_Karimi"
        Me.TextBox_Karimi.Size = New System.Drawing.Size(311, 22)
        Me.TextBox_Karimi.TabIndex = 50
        '
        'ComboBox_Satsueisya
        '
        Me.ComboBox_Satsueisya.FormattingEnabled = True
        Me.ComboBox_Satsueisya.Location = New System.Drawing.Point(122, 195)
        Me.ComboBox_Satsueisya.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Satsueisya.Name = "ComboBox_Satsueisya"
        Me.ComboBox_Satsueisya.Size = New System.Drawing.Size(145, 23)
        Me.ComboBox_Satsueisya.TabIndex = 64
        '
        'TextBox_CapHN
        '
        Me.TextBox_CapHN.Location = New System.Drawing.Point(122, 122)
        Me.TextBox_CapHN.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_CapHN.Name = "TextBox_CapHN"
        Me.TextBox_CapHN.ReadOnly = True
        Me.TextBox_CapHN.Size = New System.Drawing.Size(338, 22)
        Me.TextBox_CapHN.TabIndex = 72
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(17, 265)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 19)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "撮影時刻"
        '
        'TextBox_Satsueijikoku
        '
        Me.TextBox_Satsueijikoku.Location = New System.Drawing.Point(122, 265)
        Me.TextBox_Satsueijikoku.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Satsueijikoku.Name = "TextBox_Satsueijikoku"
        Me.TextBox_Satsueijikoku.ReadOnly = True
        Me.TextBox_Satsueijikoku.Size = New System.Drawing.Size(145, 22)
        Me.TextBox_Satsueijikoku.TabIndex = 66
        '
        'Label_tate
        '
        Me.Label_tate.AutoSize = True
        Me.Label_tate.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_tate.ForeColor = System.Drawing.Color.Black
        Me.Label_tate.Location = New System.Drawing.Point(279, 304)
        Me.Label_tate.Name = "Label_tate"
        Me.Label_tate.Size = New System.Drawing.Size(39, 19)
        Me.Label_tate.TabIndex = 85
        Me.Label_tate.Text = "縦："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(17, 230)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 19)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "撮影場所"
        '
        'Label_filesize
        '
        Me.Label_filesize.AutoSize = True
        Me.Label_filesize.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_filesize.ForeColor = System.Drawing.Color.Black
        Me.Label_filesize.Location = New System.Drawing.Point(118, 304)
        Me.Label_filesize.Name = "Label_filesize"
        Me.Label_filesize.Size = New System.Drawing.Size(101, 19)
        Me.Label_filesize.TabIndex = 85
        Me.Label_filesize.Text = "ファイルサイズ："
        '
        'Button_Queue
        '
        Me.Button_Queue.BackColor = System.Drawing.Color.Yellow
        Me.Button_Queue.ForeColor = System.Drawing.Color.Black
        Me.Button_Queue.Location = New System.Drawing.Point(243, 346)
        Me.Button_Queue.Name = "Button_Queue"
        Me.Button_Queue.Size = New System.Drawing.Size(110, 30)
        Me.Button_Queue.TabIndex = 94
        Me.Button_Queue.Text = "キューに登録"
        Me.Button_Queue.UseVisualStyleBackColor = False
        '
        'Button_Hozon
        '
        Me.Button_Hozon.BackColor = System.Drawing.Color.Pink
        Me.Button_Hozon.ForeColor = System.Drawing.Color.Black
        Me.Button_Hozon.Location = New System.Drawing.Point(369, 346)
        Me.Button_Hozon.Name = "Button_Hozon"
        Me.Button_Hozon.Size = New System.Drawing.Size(111, 30)
        Me.Button_Hozon.TabIndex = 89
        Me.Button_Hozon.Text = "上書き保存"
        Me.Button_Hozon.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(46, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(194, 126)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.ForeColor = System.Drawing.Color.Yellow
        Me.Label_Status.Location = New System.Drawing.Point(10, 15)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(67, 15)
        Me.Label_Status.TabIndex = 9
        Me.Label_Status.Text = "通常表示"
        '
        'Label_Select1
        '
        Me.Label_Select1.AutoSize = True
        Me.Label_Select1.Location = New System.Drawing.Point(0, 70)
        Me.Label_Select1.Name = "Label_Select1"
        Me.Label_Select1.Size = New System.Drawing.Size(15, 15)
        Me.Label_Select1.TabIndex = 10
        Me.Label_Select1.Text = "1"
        '
        'Label_Bar1
        '
        Me.Label_Bar1.AutoSize = True
        Me.Label_Bar1.Location = New System.Drawing.Point(20, 70)
        Me.Label_Bar1.Name = "Label_Bar1"
        Me.Label_Bar1.Size = New System.Drawing.Size(15, 15)
        Me.Label_Bar1.TabIndex = 11
        Me.Label_Bar1.Text = "/"
        '
        'Label_Total1
        '
        Me.Label_Total1.AutoSize = True
        Me.Label_Total1.Location = New System.Drawing.Point(40, 70)
        Me.Label_Total1.Name = "Label_Total1"
        Me.Label_Total1.Size = New System.Drawing.Size(15, 15)
        Me.Label_Total1.TabIndex = 12
        Me.Label_Total1.Text = "1"
        '
        'Button_Before
        '
        Me.Button_Before.BackColor = System.Drawing.Color.White
        Me.Button_Before.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Before.ForeColor = System.Drawing.Color.Black
        Me.Button_Before.Location = New System.Drawing.Point(12, 475)
        Me.Button_Before.Name = "Button_Before"
        Me.Button_Before.Size = New System.Drawing.Size(50, 25)
        Me.Button_Before.TabIndex = 90
        Me.Button_Before.Text = "←"
        Me.Button_Before.UseVisualStyleBackColor = False
        '
        'Button_After
        '
        Me.Button_After.BackColor = System.Drawing.Color.White
        Me.Button_After.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_After.ForeColor = System.Drawing.Color.Black
        Me.Button_After.Location = New System.Drawing.Point(815, 475)
        Me.Button_After.Name = "Button_After"
        Me.Button_After.Size = New System.Drawing.Size(50, 25)
        Me.Button_After.TabIndex = 91
        Me.Button_After.Text = "→"
        Me.Button_After.UseVisualStyleBackColor = False
        '
        'Button_Kirikae
        '
        Me.Button_Kirikae.BackColor = System.Drawing.Color.White
        Me.Button_Kirikae.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Kirikae.ForeColor = System.Drawing.Color.Black
        Me.Button_Kirikae.Location = New System.Drawing.Point(750, 15)
        Me.Button_Kirikae.Name = "Button_Kirikae"
        Me.Button_Kirikae.Size = New System.Drawing.Size(75, 25)
        Me.Button_Kirikae.TabIndex = 92
        Me.Button_Kirikae.Text = "表示切替"
        Me.Button_Kirikae.UseVisualStyleBackColor = False
        '
        'Label_Gide
        '
        Me.Label_Gide.AutoSize = True
        Me.Label_Gide.Location = New System.Drawing.Point(83, 15)
        Me.Label_Gide.Name = "Label_Gide"
        Me.Label_Gide.Size = New System.Drawing.Size(176, 30)
        Me.Label_Gide.TabIndex = 93
        Me.Label_Gide.Text = "「ダブルクリック」閉じる" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "「右クリック」拡大／元に戻す"
        '
        'Form_Preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(874, 527)
        Me.Controls.Add(Me.Label_Gide)
        Me.Controls.Add(Me.Button_Kirikae)
        Me.Controls.Add(Me.Button_After)
        Me.Controls.Add(Me.Button_Before)
        Me.Controls.Add(Me.Label_Total1)
        Me.Controls.Add(Me.Label_Bar1)
        Me.Controls.Add(Me.Label_Select1)
        Me.Controls.Add(Me.Label_Status)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Red
        Me.Name = "Form_Preview"
        Me.Text = "Form_Preview"
        Me.Panel1.ResumeLayout(False)
        Me.Panel_Oya.ResumeLayout(False)
        Me.Panel_Syoshi.ResumeLayout(False)
        Me.Panel_Syoshi.PerformLayout()
        Me.GroupBox_a.ResumeLayout(False)
        Me.GroupBox_a.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_Status As Label
    Friend WithEvents Label_Select1 As Label
    Friend WithEvents Label_Bar1 As Label
    Friend WithEvents Label_Total1 As Label
    Friend WithEvents Panel_Syoshi As Panel
    Friend WithEvents CheckBox_Jikoku As CheckBox
    Friend WithEvents CheckBox_Mainichi As CheckBox
    Friend WithEvents ComboBox_Satsueibasyo As ComboBox
    Friend WithEvents ComboBox_Syukkoyotei As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label_yoko As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox_CapP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox_Karimi As TextBox
    Friend WithEvents ComboBox_Satsueisya As ComboBox
    Friend WithEvents TextBox_CapHN As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox_Satsueijikoku As TextBox
    Friend WithEvents Label_tate As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label_filesize As Label
    Friend WithEvents Button_Hozon As Button
    Friend WithEvents Button_Before As Button
    Friend WithEvents Button_After As Button
    Friend WithEvents Button_Kirikae As Button
    Friend WithEvents Label_Gide As Label
    Friend WithEvents BtnSizeChange As Button
    Friend WithEvents TextBox_Maxsize As TextBox
    Friend WithEvents Button_Queue As Button
    Friend WithEvents Panel_Oya As Panel
    Friend WithEvents GroupBox_a As GroupBox
    Friend WithEvents CheckBox_Shimen As CheckBox
    Friend WithEvents CheckBox_Web As CheckBox
    Friend WithEvents Button_Recommend As Button
    Friend WithEvents CheckBox_Viewer As CheckBox
    Friend WithEvents CheckBox_Gaihan As CheckBox
End Class
