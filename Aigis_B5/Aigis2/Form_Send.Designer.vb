<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Send
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel_List = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_Count = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Renban = New System.Windows.Forms.TextBox()
        Me.RadioButton_Karimi = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Psetsu = New System.Windows.Forms.RadioButton()
        Me.Button_Renban = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Renf = New System.Windows.Forms.TextBox()
        Me.TextBox_Rens = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(1113, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "送信確定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel_List
        '
        Me.Panel_List.AutoScroll = True
        Me.Panel_List.AutoScrollMargin = New System.Drawing.Size(10, 10)
        Me.Panel_List.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel_List.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_List.Location = New System.Drawing.Point(33, 50)
        Me.Panel_List.Name = "Panel_List"
        Me.Panel_List.Size = New System.Drawing.Size(827, 400)
        Me.Panel_List.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(293, 35)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(18, 102)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(293, 35)
        Me.ProgressBar2.TabIndex = 3
        Me.ProgressBar2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(714, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "※修正できます。内容に間違いが無ければ「送信確定」を押して下さい。　「保存」→修正を保存　「削除」キューから削除"
        '
        'Label_Count
        '
        Me.Label_Count.AutoSize = True
        Me.Label_Count.Font = New System.Drawing.Font("Meiryo UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Count.Location = New System.Drawing.Point(907, 225)
        Me.Label_Count.Name = "Label_Count"
        Me.Label_Count.Size = New System.Drawing.Size(48, 24)
        Me.Label_Count.TabIndex = 5
        Me.Label_Count.Text = "全件"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(213, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "番から"
        '
        'TextBox_Renban
        '
        Me.TextBox_Renban.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_Renban.Location = New System.Drawing.Point(162, 69)
        Me.TextBox_Renban.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Renban.Name = "TextBox_Renban"
        Me.TextBox_Renban.Size = New System.Drawing.Size(45, 24)
        Me.TextBox_Renban.TabIndex = 96
        Me.TextBox_Renban.Text = "1"
        '
        'RadioButton_Karimi
        '
        Me.RadioButton_Karimi.AutoSize = True
        Me.RadioButton_Karimi.Checked = True
        Me.RadioButton_Karimi.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton_Karimi.Location = New System.Drawing.Point(103, 34)
        Me.RadioButton_Karimi.Name = "RadioButton_Karimi"
        Me.RadioButton_Karimi.Size = New System.Drawing.Size(86, 23)
        Me.RadioButton_Karimi.TabIndex = 98
        Me.RadioButton_Karimi.TabStop = True
        Me.RadioButton_Karimi.Text = "仮見出し"
        Me.RadioButton_Karimi.UseVisualStyleBackColor = True
        '
        'RadioButton_Psetsu
        '
        Me.RadioButton_Psetsu.AutoSize = True
        Me.RadioButton_Psetsu.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RadioButton_Psetsu.Location = New System.Drawing.Point(198, 34)
        Me.RadioButton_Psetsu.Name = "RadioButton_Psetsu"
        Me.RadioButton_Psetsu.Size = New System.Drawing.Size(60, 23)
        Me.RadioButton_Psetsu.TabIndex = 99
        Me.RadioButton_Psetsu.Text = "Ｐ説"
        Me.RadioButton_Psetsu.UseVisualStyleBackColor = True
        '
        'Button_Renban
        '
        Me.Button_Renban.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Renban.Location = New System.Drawing.Point(174, 100)
        Me.Button_Renban.Name = "Button_Renban"
        Me.Button_Renban.Size = New System.Drawing.Size(100, 31)
        Me.Button_Renban.TabIndex = 100
        Me.Button_Renban.Text = "連番付与"
        Me.Button_Renban.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "個別進捗(/)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 19)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "全体進捗(/)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox_Renf)
        Me.GroupBox1.Controls.Add(Me.TextBox_Rens)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Karimi)
        Me.GroupBox1.Controls.Add(Me.Button_Renban)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Psetsu)
        Me.GroupBox1.Controls.Add(Me.TextBox_Renban)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(881, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 153)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "連番オプション"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 19)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "連番位置："
        '
        'TextBox_Renf
        '
        Me.TextBox_Renf.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_Renf.Location = New System.Drawing.Point(87, 69)
        Me.TextBox_Renf.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Renf.Name = "TextBox_Renf"
        Me.TextBox_Renf.Size = New System.Drawing.Size(45, 24)
        Me.TextBox_Renf.TabIndex = 102
        Me.TextBox_Renf.Text = "＞"
        Me.TextBox_Renf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox_Rens
        '
        Me.TextBox_Rens.Font = New System.Drawing.Font("Meiryo UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_Rens.Location = New System.Drawing.Point(18, 69)
        Me.TextBox_Rens.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_Rens.Name = "TextBox_Rens"
        Me.TextBox_Rens.Size = New System.Drawing.Size(45, 24)
        Me.TextBox_Rens.TabIndex = 101
        Me.TextBox_Rens.Text = "＜"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ProgressBar2)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Location = New System.Drawing.Point(881, 286)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 164)
        Me.Panel1.TabIndex = 106
        '
        'Form_Send
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 495)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel_List)
        Me.Controls.Add(Me.Label_Count)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form_Send"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aigis2 - 送信画面"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Panel_List As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_Count As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Renban As TextBox
    Friend WithEvents RadioButton_Karimi As RadioButton
    Friend WithEvents RadioButton_Psetsu As RadioButton
    Friend WithEvents Button_Renban As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Renf As TextBox
    Friend WithEvents TextBox_Rens As TextBox
    Friend WithEvents Panel1 As Panel
End Class
