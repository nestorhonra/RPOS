<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents UserID As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.UserID = New System.Windows.Forms.TextBox()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnX = New System.Windows.Forms.Button()
        Me.btnTA9 = New System.Windows.Forms.Button()
        Me.btnTA0 = New System.Windows.Forms.Button()
        Me.btnTA8 = New System.Windows.Forms.Button()
        Me.btnTA4 = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnTA6 = New System.Windows.Forms.Button()
        Me.btnTA5 = New System.Windows.Forms.Button()
        Me.btnTA7 = New System.Windows.Forms.Button()
        Me.btnTA3 = New System.Windows.Forms.Button()
        Me.btnTA1 = New System.Windows.Forms.Button()
        Me.btnTA2 = New System.Windows.Forms.Button()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.UserType = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserID
        '
        Me.UserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserID.ForeColor = System.Drawing.Color.DarkViolet
        Me.UserID.Location = New System.Drawing.Point(267, 65)
        Me.UserID.Name = "UserID"
        Me.UserID.Size = New System.Drawing.Size(33, 35)
        Me.UserID.TabIndex = 0
        Me.UserID.Visible = False
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(170, 3)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(134, 37)
        Me.lblDateTime.TabIndex = 14
        Me.lblDateTime.Text = "DateTime"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Controls.Add(Me.Password)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Location = New System.Drawing.Point(286, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(370, 459)
        Me.Panel1.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnX, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA9, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA0, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA8, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA4, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnLogin, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA6, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA5, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA7, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA2, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(15, 54)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(341, 289)
        Me.TableLayoutPanel3.TabIndex = 385
        '
        'btnX
        '
        Me.btnX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.White
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnX.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(3, 219)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(107, 67)
        Me.btnX.TabIndex = 14
        Me.btnX.Text = "x"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'btnTA9
        '
        Me.btnTA9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA9.BackColor = System.Drawing.Color.White
        Me.btnTA9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA9.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA9.Location = New System.Drawing.Point(229, 147)
        Me.btnTA9.Name = "btnTA9"
        Me.btnTA9.Size = New System.Drawing.Size(109, 66)
        Me.btnTA9.TabIndex = 12
        Me.btnTA9.Text = "9"
        Me.btnTA9.UseVisualStyleBackColor = False
        '
        'btnTA0
        '
        Me.btnTA0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA0.BackColor = System.Drawing.Color.White
        Me.btnTA0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA0.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA0.Location = New System.Drawing.Point(116, 219)
        Me.btnTA0.Name = "btnTA0"
        Me.btnTA0.Size = New System.Drawing.Size(107, 67)
        Me.btnTA0.TabIndex = 13
        Me.btnTA0.Text = "0"
        Me.btnTA0.UseVisualStyleBackColor = False
        '
        'btnTA8
        '
        Me.btnTA8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA8.BackColor = System.Drawing.Color.White
        Me.btnTA8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA8.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA8.Location = New System.Drawing.Point(116, 147)
        Me.btnTA8.Name = "btnTA8"
        Me.btnTA8.Size = New System.Drawing.Size(107, 66)
        Me.btnTA8.TabIndex = 11
        Me.btnTA8.Text = "8"
        Me.btnTA8.UseVisualStyleBackColor = False
        '
        'btnTA4
        '
        Me.btnTA4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA4.BackColor = System.Drawing.Color.White
        Me.btnTA4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA4.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA4.Location = New System.Drawing.Point(3, 75)
        Me.btnTA4.Name = "btnTA4"
        Me.btnTA4.Size = New System.Drawing.Size(107, 66)
        Me.btnTA4.TabIndex = 7
        Me.btnTA4.Text = "4"
        Me.btnTA4.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.BackColor = System.Drawing.Color.Transparent
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.Location = New System.Drawing.Point(229, 219)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(109, 67)
        Me.btnLogin.TabIndex = 1
        Me.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnTA6
        '
        Me.btnTA6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA6.BackColor = System.Drawing.Color.White
        Me.btnTA6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA6.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA6.Location = New System.Drawing.Point(229, 75)
        Me.btnTA6.Name = "btnTA6"
        Me.btnTA6.Size = New System.Drawing.Size(109, 66)
        Me.btnTA6.TabIndex = 9
        Me.btnTA6.Text = "6"
        Me.btnTA6.UseVisualStyleBackColor = False
        '
        'btnTA5
        '
        Me.btnTA5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA5.BackColor = System.Drawing.Color.White
        Me.btnTA5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA5.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA5.Location = New System.Drawing.Point(116, 75)
        Me.btnTA5.Name = "btnTA5"
        Me.btnTA5.Size = New System.Drawing.Size(107, 66)
        Me.btnTA5.TabIndex = 8
        Me.btnTA5.Text = "5"
        Me.btnTA5.UseVisualStyleBackColor = False
        '
        'btnTA7
        '
        Me.btnTA7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA7.BackColor = System.Drawing.Color.White
        Me.btnTA7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA7.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA7.Location = New System.Drawing.Point(3, 147)
        Me.btnTA7.Name = "btnTA7"
        Me.btnTA7.Size = New System.Drawing.Size(107, 66)
        Me.btnTA7.TabIndex = 10
        Me.btnTA7.Text = "7"
        Me.btnTA7.UseVisualStyleBackColor = False
        '
        'btnTA3
        '
        Me.btnTA3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA3.BackColor = System.Drawing.Color.White
        Me.btnTA3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA3.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA3.Location = New System.Drawing.Point(229, 3)
        Me.btnTA3.Name = "btnTA3"
        Me.btnTA3.Size = New System.Drawing.Size(109, 66)
        Me.btnTA3.TabIndex = 6
        Me.btnTA3.Text = "3"
        Me.btnTA3.UseVisualStyleBackColor = False
        '
        'btnTA1
        '
        Me.btnTA1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA1.BackColor = System.Drawing.Color.White
        Me.btnTA1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA1.Location = New System.Drawing.Point(3, 3)
        Me.btnTA1.Name = "btnTA1"
        Me.btnTA1.Size = New System.Drawing.Size(107, 66)
        Me.btnTA1.TabIndex = 4
        Me.btnTA1.Text = "1"
        Me.btnTA1.UseVisualStyleBackColor = False
        '
        'btnTA2
        '
        Me.btnTA2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA2.BackColor = System.Drawing.Color.White
        Me.btnTA2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA2.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA2.Location = New System.Drawing.Point(116, 3)
        Me.btnTA2.Name = "btnTA2"
        Me.btnTA2.Size = New System.Drawing.Size(107, 66)
        Me.btnTA2.TabIndex = 5
        Me.btnTA2.Text = "2"
        Me.btnTA2.UseVisualStyleBackColor = False
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.White
        Me.Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.ForeColor = System.Drawing.Color.Black
        Me.Password.Location = New System.Drawing.Point(15, 13)
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Size = New System.Drawing.Size(341, 35)
        Me.Password.TabIndex = 2
        Me.Password.Text = "ENTER PIN"
        Me.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.RestaurantPOS3.My.Resources.Resources.Apps_Dialog_Shutdown_icon
        Me.btnCancel.Location = New System.Drawing.Point(141, 372)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 72)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'UserType
        '
        Me.UserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserType.ForeColor = System.Drawing.Color.DarkViolet
        Me.UserType.Location = New System.Drawing.Point(306, 63)
        Me.UserType.Name = "UserType"
        Me.UserType.Size = New System.Drawing.Size(33, 35)
        Me.UserType.TabIndex = 16
        Me.UserType.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblDateTime)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(760, 46)
        Me.Panel2.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login Form"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RestaurantPOS3.My.Resources.Resources.Restaurant_icon11
        Me.PictureBox1.Location = New System.Drawing.Point(11, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(759, 596)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.UserType)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UserID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents btnTA9 As System.Windows.Forms.Button
    Friend WithEvents btnTA0 As System.Windows.Forms.Button
    Friend WithEvents btnTA8 As System.Windows.Forms.Button
    Friend WithEvents btnTA4 As System.Windows.Forms.Button
    Friend WithEvents btnTA6 As System.Windows.Forms.Button
    Friend WithEvents btnTA5 As System.Windows.Forms.Button
    Friend WithEvents btnTA7 As System.Windows.Forms.Button
    Friend WithEvents btnTA3 As System.Windows.Forms.Button
    Friend WithEvents btnTA1 As System.Windows.Forms.Button
    Friend WithEvents btnTA2 As System.Windows.Forms.Button
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents UserType As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
