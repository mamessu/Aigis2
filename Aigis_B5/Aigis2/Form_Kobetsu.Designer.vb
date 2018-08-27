<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Kobetsu
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ライブラリToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.送信者設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.雛形設定ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.接続設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_SelectGazo = New System.Windows.Forms.Button()
        Me.TextBox_GazoPass = New System.Windows.Forms.TextBox()
        Me.TextBox_Karimidashi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_Filesize = New System.Windows.Forms.Label()
        Me.Label_Yoko = New System.Windows.Forms.Label()
        Me.Label_Tate = New System.Windows.Forms.Label()
        Me.TextBox_Caption1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox_Photographer = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox_Satsueijikoku = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox_Caption2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button_Recommend = New System.Windows.Forms.Button()
        Me.GroupBox_a = New System.Windows.Forms.GroupBox()
        Me.CheckBox_Gaihan = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Shimen = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Viewer = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Web = New System.Windows.Forms.CheckBox()
        Me.TextBox_Maxsize = New System.Windows.Forms.TextBox()
        Me.CheckBox_Daihyo = New System.Windows.Forms.CheckBox()
        Me.Button_Resize = New System.Windows.Forms.Button()
        Me.CheckBox_Jikoku = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Syukkoyotei = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Photoplace = New System.Windows.Forms.ComboBox()
        Me.Button_Hina1 = New System.Windows.Forms.Button()
        Me.Button_Hina2 = New System.Windows.Forms.Button()
        Me.Button_Hina3 = New System.Windows.Forms.Button()
        Me.Button_Hina4 = New System.Windows.Forms.Button()
        Me.Button_Hina5 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_Toroku = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button_App = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button_Soshin = New System.Windows.Forms.Button()
        Me.Button_Peast = New System.Windows.Forms.Button()
        Me.Button_Copy = New System.Windows.Forms.Button()
        Me.Button_Before = New System.Windows.Forms.Button()
        Me.PictureBox_Main = New System.Windows.Forms.PictureBox()
        Me.Label_Loading = New System.Windows.Forms.Label()
        Me.ProgressBar_Loading = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox_a.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.送信者設定ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 3, 0, 3)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1082, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ライブラリToolStripMenuItem, Me.終了ToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(82, 27)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        'ライブラリToolStripMenuItem
        '
        Me.ライブラリToolStripMenuItem.Name = "ライブラリToolStripMenuItem"
        Me.ライブラリToolStripMenuItem.Size = New System.Drawing.Size(191, 28)
        Me.ライブラリToolStripMenuItem.Text = "ライブラリ起動"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(191, 28)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '送信者設定ToolStripMenuItem
        '
        Me.送信者設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.雛形設定ToolStripMenuItem1, Me.接続設定ToolStripMenuItem})
        Me.送信者設定ToolStripMenuItem.Name = "送信者設定ToolStripMenuItem"
        Me.送信者設定ToolStripMenuItem.Size = New System.Drawing.Size(52, 27)
        Me.送信者設定ToolStripMenuItem.Text = "設定"
        '
        '雛形設定ToolStripMenuItem1
        '
        Me.雛形設定ToolStripMenuItem1.Name = "雛形設定ToolStripMenuItem1"
        Me.雛形設定ToolStripMenuItem1.Size = New System.Drawing.Size(146, 28)
        Me.雛形設定ToolStripMenuItem1.Text = "雛形設定"
        '
        '接続設定ToolStripMenuItem
        '
        Me.接続設定ToolStripMenuItem.Name = "接続設定ToolStripMenuItem"
        Me.接続設定ToolStripMenuItem.Size = New System.Drawing.Size(146, 28)
        Me.接続設定ToolStripMenuItem.Text = "接続設定"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 512)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "画像ファイル"
        '
        'Button_SelectGazo
        '
        Me.Button_SelectGazo.Location = New System.Drawing.Point(109, 509)
        Me.Button_SelectGazo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_SelectGazo.Name = "Button_SelectGazo"
        Me.Button_SelectGazo.Size = New System.Drawing.Size(36, 25)
        Me.Button_SelectGazo.TabIndex = 3
        Me.Button_SelectGazo.Text = "…"
        Me.Button_SelectGazo.UseVisualStyleBackColor = True
        '
        'TextBox_GazoPass
        '
        Me.TextBox_GazoPass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox_GazoPass.Location = New System.Drawing.Point(154, 509)
        Me.TextBox_GazoPass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_GazoPass.Name = "TextBox_GazoPass"
        Me.TextBox_GazoPass.ReadOnly = True
        Me.TextBox_GazoPass.Size = New System.Drawing.Size(322, 27)
        Me.TextBox_GazoPass.TabIndex = 4
        '
        'TextBox_Karimidashi
        '
        Me.TextBox_Karimidashi.Location = New System.Drawing.Point(112, 14)
        Me.TextBox_Karimidashi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Karimidashi.Name = "TextBox_Karimidashi"
        Me.TextBox_Karimidashi.Size = New System.Drawing.Size(388, 27)
        Me.TextBox_Karimidashi.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "文書名"
        '
        'Label_Filesize
        '
        Me.Label_Filesize.AutoSize = True
        Me.Label_Filesize.Location = New System.Drawing.Point(108, 330)
        Me.Label_Filesize.Name = "Label_Filesize"
        Me.Label_Filesize.Size = New System.Drawing.Size(101, 19)
        Me.Label_Filesize.TabIndex = 16
        Me.Label_Filesize.Text = "ファイルサイズ："
        '
        'Label_Yoko
        '
        Me.Label_Yoko.AutoSize = True
        Me.Label_Yoko.Location = New System.Drawing.Point(431, 330)
        Me.Label_Yoko.Name = "Label_Yoko"
        Me.Label_Yoko.Size = New System.Drawing.Size(39, 19)
        Me.Label_Yoko.TabIndex = 17
        Me.Label_Yoko.Text = "横："
        '
        'Label_Tate
        '
        Me.Label_Tate.AutoSize = True
        Me.Label_Tate.Location = New System.Drawing.Point(348, 330)
        Me.Label_Tate.Name = "Label_Tate"
        Me.Label_Tate.Size = New System.Drawing.Size(39, 19)
        Me.Label_Tate.TabIndex = 18
        Me.Label_Tate.Text = "縦："
        '
        'TextBox_Caption1
        '
        Me.TextBox_Caption1.Location = New System.Drawing.Point(112, 50)
        Me.TextBox_Caption1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Caption1.Multiline = True
        Me.TextBox_Caption1.Name = "TextBox_Caption1"
        Me.TextBox_Caption1.Size = New System.Drawing.Size(414, 68)
        Me.TextBox_Caption1.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 38)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Ｐ説" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（本文）"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "出稿予定"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(97, 575)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 19)
        Me.Label9.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 214)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 19)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "撮影者"
        '
        'ComboBox_Photographer
        '
        Me.ComboBox_Photographer.FormattingEnabled = True
        Me.ComboBox_Photographer.Location = New System.Drawing.Point(110, 211)
        Me.ComboBox_Photographer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Photographer.Name = "ComboBox_Photographer"
        Me.ComboBox_Photographer.Size = New System.Drawing.Size(220, 27)
        Me.ComboBox_Photographer.TabIndex = 40
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 296)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 19)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "撮影時刻"
        '
        'TextBox_Satsueijikoku
        '
        Me.TextBox_Satsueijikoku.Location = New System.Drawing.Point(110, 293)
        Me.TextBox_Satsueijikoku.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Satsueijikoku.Name = "TextBox_Satsueijikoku"
        Me.TextBox_Satsueijikoku.Size = New System.Drawing.Size(220, 27)
        Me.TextBox_Satsueijikoku.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 19)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "撮影場所"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(-3, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 38)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Ｐ説" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "（人＋日時）"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_Caption2
        '
        Me.TextBox_Caption2.Location = New System.Drawing.Point(111, 129)
        Me.TextBox_Caption2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Caption2.Name = "TextBox_Caption2"
        Me.TextBox_Caption2.ReadOnly = True
        Me.TextBox_Caption2.Size = New System.Drawing.Size(415, 27)
        Me.TextBox_Caption2.TabIndex = 48
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button_Recommend)
        Me.Panel1.Controls.Add(Me.GroupBox_a)
        Me.Panel1.Controls.Add(Me.TextBox_Maxsize)
        Me.Panel1.Controls.Add(Me.CheckBox_Daihyo)
        Me.Panel1.Controls.Add(Me.Button_Resize)
        Me.Panel1.Controls.Add(Me.CheckBox_Jikoku)
        Me.Panel1.Controls.Add(Me.ComboBox_Syukkoyotei)
        Me.Panel1.Controls.Add(Me.ComboBox_Photoplace)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.TextBox_Caption2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.TextBox_Satsueijikoku)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label_Filesize)
        Me.Panel1.Controls.Add(Me.Label_Yoko)
        Me.Panel1.Controls.Add(Me.Label_Tate)
        Me.Panel1.Controls.Add(Me.ComboBox_Photographer)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextBox_Caption1)
        Me.Panel1.Controls.Add(Me.TextBox_Karimidashi)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(505, 85)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 365)
        Me.Panel1.TabIndex = 50
        '
        'Button_Recommend
        '
        Me.Button_Recommend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button_Recommend.BackgroundImage = Global.Aigis2.My.Resources.Resources.whitestar
        Me.Button_Recommend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Recommend.FlatAppearance.BorderSize = 0
        Me.Button_Recommend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Recommend.Location = New System.Drawing.Point(506, 11)
        Me.Button_Recommend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Recommend.Name = "Button_Recommend"
        Me.Button_Recommend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Recommend.Size = New System.Drawing.Size(30, 30)
        Me.Button_Recommend.TabIndex = 112
        Me.Button_Recommend.UseVisualStyleBackColor = True
        '
        'GroupBox_a
        '
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Gaihan)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Shimen)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Viewer)
        Me.GroupBox_a.Controls.Add(Me.CheckBox_Web)
        Me.GroupBox_a.Location = New System.Drawing.Point(337, 195)
        Me.GroupBox_a.Name = "GroupBox_a"
        Me.GroupBox_a.Size = New System.Drawing.Size(205, 85)
        Me.GroupBox_a.TabIndex = 115
        Me.GroupBox_a.TabStop = False
        Me.GroupBox_a.Text = "利用制限"
        '
        'CheckBox_Gaihan
        '
        Me.CheckBox_Gaihan.AutoSize = True
        Me.CheckBox_Gaihan.Location = New System.Drawing.Point(107, 54)
        Me.CheckBox_Gaihan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Gaihan.Name = "CheckBox_Gaihan"
        Me.CheckBox_Gaihan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Gaihan.Size = New System.Drawing.Size(91, 23)
        Me.CheckBox_Gaihan.TabIndex = 117
        Me.CheckBox_Gaihan.Text = "外販不可"
        Me.CheckBox_Gaihan.UseVisualStyleBackColor = True
        '
        'CheckBox_Shimen
        '
        Me.CheckBox_Shimen.AutoSize = True
        Me.CheckBox_Shimen.Location = New System.Drawing.Point(8, 27)
        Me.CheckBox_Shimen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Shimen.Name = "CheckBox_Shimen"
        Me.CheckBox_Shimen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Shimen.Size = New System.Drawing.Size(91, 23)
        Me.CheckBox_Shimen.TabIndex = 112
        Me.CheckBox_Shimen.Text = "紙面不可"
        Me.CheckBox_Shimen.UseVisualStyleBackColor = True
        '
        'CheckBox_Viewer
        '
        Me.CheckBox_Viewer.AutoSize = True
        Me.CheckBox_Viewer.Font = New System.Drawing.Font("Meiryo UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox_Viewer.Location = New System.Drawing.Point(6, 57)
        Me.CheckBox_Viewer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Viewer.Name = "CheckBox_Viewer"
        Me.CheckBox_Viewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Viewer.Size = New System.Drawing.Size(93, 19)
        Me.CheckBox_Viewer.TabIndex = 116
        Me.CheckBox_Viewer.Text = "Viewer不可"
        Me.CheckBox_Viewer.UseVisualStyleBackColor = True
        '
        'CheckBox_Web
        '
        Me.CheckBox_Web.AutoSize = True
        Me.CheckBox_Web.Location = New System.Drawing.Point(105, 27)
        Me.CheckBox_Web.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Web.Name = "CheckBox_Web"
        Me.CheckBox_Web.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Web.Size = New System.Drawing.Size(93, 23)
        Me.CheckBox_Web.TabIndex = 113
        Me.CheckBox_Web.Text = "Web不可"
        Me.CheckBox_Web.UseVisualStyleBackColor = True
        '
        'TextBox_Maxsize
        '
        Me.TextBox_Maxsize.Location = New System.Drawing.Point(438, 293)
        Me.TextBox_Maxsize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Maxsize.Name = "TextBox_Maxsize"
        Me.TextBox_Maxsize.Size = New System.Drawing.Size(79, 27)
        Me.TextBox_Maxsize.TabIndex = 59
        '
        'CheckBox_Daihyo
        '
        Me.CheckBox_Daihyo.AutoSize = True
        Me.CheckBox_Daihyo.Location = New System.Drawing.Point(435, 165)
        Me.CheckBox_Daihyo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Daihyo.Name = "CheckBox_Daihyo"
        Me.CheckBox_Daihyo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Daihyo.Size = New System.Drawing.Size(91, 23)
        Me.CheckBox_Daihyo.TabIndex = 53
        Me.CheckBox_Daihyo.Text = "代表撮影"
        Me.CheckBox_Daihyo.UseVisualStyleBackColor = True
        '
        'Button_Resize
        '
        Me.Button_Resize.Location = New System.Drawing.Point(344, 288)
        Me.Button_Resize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Resize.Name = "Button_Resize"
        Me.Button_Resize.Size = New System.Drawing.Size(84, 34)
        Me.Button_Resize.TabIndex = 61
        Me.Button_Resize.Text = "リサイズ"
        Me.ToolTip1.SetToolTip(Me.Button_Resize, "長辺を指定したサイズにリサイズ")
        Me.Button_Resize.UseVisualStyleBackColor = True
        '
        'CheckBox_Jikoku
        '
        Me.CheckBox_Jikoku.AutoSize = True
        Me.CheckBox_Jikoku.Location = New System.Drawing.Point(337, 165)
        Me.CheckBox_Jikoku.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox_Jikoku.Name = "CheckBox_Jikoku"
        Me.CheckBox_Jikoku.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox_Jikoku.Size = New System.Drawing.Size(91, 23)
        Me.CheckBox_Jikoku.TabIndex = 52
        Me.CheckBox_Jikoku.Text = "簡易日時"
        Me.CheckBox_Jikoku.UseVisualStyleBackColor = True
        '
        'ComboBox_Syukkoyotei
        '
        Me.ComboBox_Syukkoyotei.FormattingEnabled = True
        Me.ComboBox_Syukkoyotei.Location = New System.Drawing.Point(111, 169)
        Me.ComboBox_Syukkoyotei.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Syukkoyotei.Name = "ComboBox_Syukkoyotei"
        Me.ComboBox_Syukkoyotei.Size = New System.Drawing.Size(220, 27)
        Me.ComboBox_Syukkoyotei.TabIndex = 51
        '
        'ComboBox_Photoplace
        '
        Me.ComboBox_Photoplace.FormattingEnabled = True
        Me.ComboBox_Photoplace.Location = New System.Drawing.Point(110, 253)
        Me.ComboBox_Photoplace.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Photoplace.Name = "ComboBox_Photoplace"
        Me.ComboBox_Photoplace.Size = New System.Drawing.Size(220, 27)
        Me.ComboBox_Photoplace.TabIndex = 50
        '
        'Button_Hina1
        '
        Me.Button_Hina1.Location = New System.Drawing.Point(505, 43)
        Me.Button_Hina1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Hina1.Name = "Button_Hina1"
        Me.Button_Hina1.Size = New System.Drawing.Size(100, 30)
        Me.Button_Hina1.TabIndex = 52
        Me.Button_Hina1.Text = "雛形１"
        Me.Button_Hina1.UseVisualStyleBackColor = True
        '
        'Button_Hina2
        '
        Me.Button_Hina2.Location = New System.Drawing.Point(617, 43)
        Me.Button_Hina2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Hina2.Name = "Button_Hina2"
        Me.Button_Hina2.Size = New System.Drawing.Size(100, 30)
        Me.Button_Hina2.TabIndex = 53
        Me.Button_Hina2.Text = "雛形２"
        Me.Button_Hina2.UseVisualStyleBackColor = True
        '
        'Button_Hina3
        '
        Me.Button_Hina3.Location = New System.Drawing.Point(729, 43)
        Me.Button_Hina3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Hina3.Name = "Button_Hina3"
        Me.Button_Hina3.Size = New System.Drawing.Size(100, 30)
        Me.Button_Hina3.TabIndex = 54
        Me.Button_Hina3.Text = "雛形３"
        Me.Button_Hina3.UseVisualStyleBackColor = True
        '
        'Button_Hina4
        '
        Me.Button_Hina4.Location = New System.Drawing.Point(841, 43)
        Me.Button_Hina4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Hina4.Name = "Button_Hina4"
        Me.Button_Hina4.Size = New System.Drawing.Size(100, 30)
        Me.Button_Hina4.TabIndex = 55
        Me.Button_Hina4.Text = "雛形４"
        Me.Button_Hina4.UseVisualStyleBackColor = True
        '
        'Button_Hina5
        '
        Me.Button_Hina5.Location = New System.Drawing.Point(955, 43)
        Me.Button_Hina5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Hina5.Name = "Button_Hina5"
        Me.Button_Hina5.Size = New System.Drawing.Size(100, 30)
        Me.Button_Hina5.TabIndex = 56
        Me.Button_Hina5.Text = "雛形５"
        Me.Button_Hina5.UseVisualStyleBackColor = True
        '
        'Button_Toroku
        '
        Me.Button_Toroku.BackColor = System.Drawing.Color.Pink
        Me.Button_Toroku.BackgroundImage = Global.Aigis2.My.Resources.Resources.upload
        Me.Button_Toroku.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_Toroku.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Toroku.Location = New System.Drawing.Point(485, 0)
        Me.Button_Toroku.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Toroku.Name = "Button_Toroku"
        Me.Button_Toroku.Size = New System.Drawing.Size(50, 50)
        Me.Button_Toroku.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.Button_Toroku, "ライブラリに登録")
        Me.Button_Toroku.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "単独送信(r)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(264, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 19)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "前回(z)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(339, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "コピー(c)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(408, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 19)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "貼付(v)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(481, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 19)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "登録(s)"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button_App)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Button_Soshin)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Button_Toroku)
        Me.Panel2.Controls.Add(Me.Button_Peast)
        Me.Panel2.Controls.Add(Me.Button_Copy)
        Me.Panel2.Controls.Add(Me.Button_Before)
        Me.Panel2.Location = New System.Drawing.Point(505, 458)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(549, 77)
        Me.Panel2.TabIndex = 67
        '
        'Button_App
        '
        Me.Button_App.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button_App.BackgroundImage = Global.Aigis2.My.Resources.Resources.app
        Me.Button_App.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_App.Location = New System.Drawing.Point(184, 0)
        Me.Button_App.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_App.Name = "Button_App"
        Me.Button_App.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_App.Size = New System.Drawing.Size(50, 50)
        Me.Button_App.TabIndex = 110
        Me.Button_App.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(180, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 19)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "アプリ(a)"
        '
        'Button_Soshin
        '
        Me.Button_Soshin.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Button_Soshin.BackgroundImage = Global.Aigis2.My.Resources.Resources.send
        Me.Button_Soshin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button_Soshin.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Soshin.Location = New System.Drawing.Point(0, 0)
        Me.Button_Soshin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Soshin.Name = "Button_Soshin"
        Me.Button_Soshin.Size = New System.Drawing.Size(100, 50)
        Me.Button_Soshin.TabIndex = 19
        Me.Button_Soshin.Text = "送信"
        Me.Button_Soshin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Soshin.UseVisualStyleBackColor = False
        '
        'Button_Peast
        '
        Me.Button_Peast.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button_Peast.BackgroundImage = Global.Aigis2.My.Resources.Resources.past
        Me.Button_Peast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_Peast.Location = New System.Drawing.Point(412, 0)
        Me.Button_Peast.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Peast.Name = "Button_Peast"
        Me.Button_Peast.Size = New System.Drawing.Size(50, 50)
        Me.Button_Peast.TabIndex = 57
        Me.Button_Peast.UseVisualStyleBackColor = False
        '
        'Button_Copy
        '
        Me.Button_Copy.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button_Copy.BackgroundImage = Global.Aigis2.My.Resources.Resources.copy
        Me.Button_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_Copy.Location = New System.Drawing.Point(344, 0)
        Me.Button_Copy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Copy.Name = "Button_Copy"
        Me.Button_Copy.Size = New System.Drawing.Size(50, 50)
        Me.Button_Copy.TabIndex = 60
        Me.Button_Copy.UseVisualStyleBackColor = False
        '
        'Button_Before
        '
        Me.Button_Before.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button_Before.BackgroundImage = Global.Aigis2.My.Resources.Resources.restore
        Me.Button_Before.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button_Before.Location = New System.Drawing.Point(267, 0)
        Me.Button_Before.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Before.Name = "Button_Before"
        Me.Button_Before.Size = New System.Drawing.Size(50, 50)
        Me.Button_Before.TabIndex = 58
        Me.Button_Before.UseVisualStyleBackColor = False
        '
        'PictureBox_Main
        '
        Me.PictureBox_Main.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_Main.ErrorImage = Nothing
        Me.PictureBox_Main.Location = New System.Drawing.Point(25, 43)
        Me.PictureBox_Main.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox_Main.Name = "PictureBox_Main"
        Me.PictureBox_Main.Size = New System.Drawing.Size(450, 450)
        Me.PictureBox_Main.TabIndex = 0
        Me.PictureBox_Main.TabStop = False
        '
        'Label_Loading
        '
        Me.Label_Loading.AutoSize = True
        Me.Label_Loading.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label_Loading.Font = New System.Drawing.Font("Meiryo UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Loading.Location = New System.Drawing.Point(48, 231)
        Me.Label_Loading.Name = "Label_Loading"
        Me.Label_Loading.Size = New System.Drawing.Size(132, 22)
        Me.Label_Loading.TabIndex = 119
        Me.Label_Loading.Text = "処理しています..."
        Me.Label_Loading.Visible = False
        '
        'ProgressBar_Loading
        '
        Me.ProgressBar_Loading.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar_Loading.Cursor = System.Windows.Forms.Cursors.Default
        Me.ProgressBar_Loading.Location = New System.Drawing.Point(52, 258)
        Me.ProgressBar_Loading.Name = "ProgressBar_Loading"
        Me.ProgressBar_Loading.Size = New System.Drawing.Size(394, 25)
        Me.ProgressBar_Loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar_Loading.TabIndex = 120
        Me.ProgressBar_Loading.Visible = False
        '
        'Form_Kobetsu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 555)
        Me.Controls.Add(Me.ProgressBar_Loading)
        Me.Controls.Add(Me.Label_Loading)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button_Hina4)
        Me.Controls.Add(Me.Button_Hina5)
        Me.Controls.Add(Me.Button_Hina3)
        Me.Controls.Add(Me.Button_Hina2)
        Me.Controls.Add(Me.Button_Hina1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox_GazoPass)
        Me.Controls.Add(Me.PictureBox_Main)
        Me.Controls.Add(Me.Button_SelectGazo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Form_Kobetsu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aigis2 - 画像追加"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox_a.ResumeLayout(False)
        Me.GroupBox_a.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_Main As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 送信者設定ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_SelectGazo As System.Windows.Forms.Button
    Friend WithEvents 終了ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_GazoPass As System.Windows.Forms.TextBox
    Friend WithEvents 雛形設定ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_Karimidashi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label_Filesize As System.Windows.Forms.Label
    Friend WithEvents Label_Yoko As System.Windows.Forms.Label
    Friend WithEvents Label_Tate As System.Windows.Forms.Label
    Friend WithEvents Button_Soshin As System.Windows.Forms.Button
    Friend WithEvents TextBox_Caption1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ライブラリToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Photographer As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Satsueijikoku As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Caption2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button_Toroku As Button
    Friend WithEvents Button_Hina1 As Button
    Friend WithEvents Button_Hina2 As Button
    Friend WithEvents Button_Hina3 As Button
    Friend WithEvents Button_Hina4 As Button
    Friend WithEvents Button_Hina5 As Button
    Friend WithEvents ComboBox_Syukkoyotei As ComboBox
    Friend WithEvents ComboBox_Photoplace As ComboBox
    Friend WithEvents 接続設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button_Peast As Button
    Friend WithEvents Button_Before As Button
    Friend WithEvents Button_Copy As Button
    Friend WithEvents CheckBox_Daihyo As CheckBox
    Friend WithEvents CheckBox_Jikoku As CheckBox
    Friend WithEvents Button_Resize As Button
    Friend WithEvents TextBox_Maxsize As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button_App As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox_a As GroupBox
    Friend WithEvents CheckBox_Shimen As CheckBox
    Friend WithEvents CheckBox_Web As CheckBox
    Friend WithEvents CheckBox_Gaihan As CheckBox
    Friend WithEvents CheckBox_Viewer As CheckBox
    Friend WithEvents Button_Recommend As Button
    Friend WithEvents Label_Loading As Label
    Friend WithEvents ProgressBar_Loading As ProgressBar
End Class
