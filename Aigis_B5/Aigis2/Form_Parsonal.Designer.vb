<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Parsonal
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox_Syainid = New System.Windows.Forms.TextBox()
        Me.TextBox_Syainmei = New System.Windows.Forms.TextBox()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox_Teamlabel = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_App = New System.Windows.Forms.TextBox()
        Me.Button_Sarch = New System.Windows.Forms.Button()
        Me.TextBox_Monitor = New System.Windows.Forms.TextBox()
        Me.Label_Kanshi = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "社員番号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "名前"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "パスワード"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "チームラベル"
        '
        'Button_OK
        '
        Me.Button_OK.Location = New System.Drawing.Point(377, 302)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(95, 25)
        Me.Button_OK.TabIndex = 5
        Me.Button_OK.Text = "ＯＫ"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(499, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 25)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "キャンセル"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox_Syainid
        '
        Me.TextBox_Syainid.Location = New System.Drawing.Point(119, 20)
        Me.TextBox_Syainid.Name = "TextBox_Syainid"
        Me.TextBox_Syainid.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_Syainid.TabIndex = 7
        '
        'TextBox_Syainmei
        '
        Me.TextBox_Syainmei.Location = New System.Drawing.Point(119, 53)
        Me.TextBox_Syainmei.Name = "TextBox_Syainmei"
        Me.TextBox_Syainmei.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_Syainmei.TabIndex = 8
        '
        'TextBox_Password
        '
        Me.TextBox_Password.Location = New System.Drawing.Point(119, 84)
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TextBox_Password.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_Password.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(435, 80)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 29)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "表示切替"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox_Teamlabel
        '
        Me.TextBox_Teamlabel.Location = New System.Drawing.Point(119, 120)
        Me.TextBox_Teamlabel.Name = "TextBox_Teamlabel"
        Me.TextBox_Teamlabel.ReadOnly = True
        Me.TextBox_Teamlabel.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_Teamlabel.TabIndex = 11
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(435, 116)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(84, 29)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "検索"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "個人設定項目"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TextBox_Syainid)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.TextBox_Teamlabel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBox_Password)
        Me.Panel1.Controls.Add(Me.TextBox_Syainmei)
        Me.Panel1.Location = New System.Drawing.Point(53, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 162)
        Me.Panel1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "外部アプリ連携"
        '
        'TextBox_App
        '
        Me.TextBox_App.Location = New System.Drawing.Point(172, 211)
        Me.TextBox_App.Name = "TextBox_App"
        Me.TextBox_App.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_App.TabIndex = 13
        '
        'Button_Sarch
        '
        Me.Button_Sarch.Location = New System.Drawing.Point(488, 207)
        Me.Button_Sarch.Name = "Button_Sarch"
        Me.Button_Sarch.Size = New System.Drawing.Size(84, 29)
        Me.Button_Sarch.TabIndex = 13
        Me.Button_Sarch.Text = "・・・"
        Me.Button_Sarch.UseVisualStyleBackColor = True
        '
        'TextBox_Monitor
        '
        Me.TextBox_Monitor.Location = New System.Drawing.Point(172, 254)
        Me.TextBox_Monitor.Name = "TextBox_Monitor"
        Me.TextBox_Monitor.Size = New System.Drawing.Size(275, 22)
        Me.TextBox_Monitor.TabIndex = 16
        '
        'Label_Kanshi
        '
        Me.Label_Kanshi.AutoSize = True
        Me.Label_Kanshi.Location = New System.Drawing.Point(61, 258)
        Me.Label_Kanshi.Name = "Label_Kanshi"
        Me.Label_Kanshi.Size = New System.Drawing.Size(80, 15)
        Me.Label_Kanshi.TabIndex = 17
        Me.Label_Kanshi.Text = "監視フォルダ"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(488, 251)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 29)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "・・・"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form_Parsonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 340)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_Monitor)
        Me.Controls.Add(Me.Label_Kanshi)
        Me.Controls.Add(Me.Button_Sarch)
        Me.Controls.Add(Me.TextBox_App)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button_OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form_Parsonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aigis2 - 接続設定"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button_OK As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox_Syainid As TextBox
    Friend WithEvents TextBox_Syainmei As TextBox
    Friend WithEvents TextBox_Password As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox_Teamlabel As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_App As TextBox
    Friend WithEvents Button_Sarch As Button
    Friend WithEvents TextBox_Monitor As TextBox
    Friend WithEvents Label_Kanshi As Label
    Friend WithEvents Button1 As Button
End Class
