<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFrontOffice
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFrontOffice))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOS = New System.Windows.Forms.Button()
        Me.btnTicket = New System.Windows.Forms.Button()
        Me.btnWorkPeriodRep = New System.Windows.Forms.Button()
        Me.btnPOSRep = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 49)
        Me.Panel1.TabIndex = 30
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.LightSeaGreen
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUser.Location = New System.Drawing.Point(360, 13)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(151, 29)
        Me.lblUser.TabIndex = 73
        Me.lblUser.Text = "User"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(225, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 29)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "User Account :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.NavajoWhite
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Front Office"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 16.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.lblDateTime.Location = New System.Drawing.Point(5, 53)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(109, 30)
        Me.lblDateTime.TabIndex = 3
        Me.lblDateTime.Text = "DateTime"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.RestaurantPOS3.My.Resources.Resources.Button_Delete_icon1
        Me.btnCancel.Location = New System.Drawing.Point(570, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(52, 49)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWorkPeriod)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPOS)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnTicket)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWorkPeriodRep)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPOSRep)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnLogout)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 86)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(622, 415)
        Me.FlowLayoutPanel1.TabIndex = 32
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWorkPeriod.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriod.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriod.Image = Global.RestaurantPOS3.My.Resources.Resources.Calendar22_icon
        Me.btnWorkPeriod.Location = New System.Drawing.Point(3, 3)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(200, 200)
        Me.btnWorkPeriod.TabIndex = 2
        Me.btnWorkPeriod.Text = "Work Period"
        Me.btnWorkPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOS
        '
        Me.btnPOS.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPOS.FlatAppearance.BorderSize = 0
        Me.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOS.ForeColor = System.Drawing.Color.White
        Me.btnPOS.Image = Global.RestaurantPOS3.My.Resources.Resources.cash_machine
        Me.btnPOS.Location = New System.Drawing.Point(209, 3)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(200, 200)
        Me.btnPOS.TabIndex = 3
        Me.btnPOS.Text = "POS"
        Me.btnPOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPOS.UseVisualStyleBackColor = False
        '
        'btnTicket
        '
        Me.btnTicket.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnTicket.FlatAppearance.BorderSize = 0
        Me.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicket.ForeColor = System.Drawing.Color.White
        Me.btnTicket.Image = Global.RestaurantPOS3.My.Resources.Resources.Tickets_icon
        Me.btnTicket.Location = New System.Drawing.Point(415, 3)
        Me.btnTicket.Name = "btnTicket"
        Me.btnTicket.Size = New System.Drawing.Size(200, 200)
        Me.btnTicket.TabIndex = 4
        Me.btnTicket.Text = "Tickets"
        Me.btnTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTicket.UseVisualStyleBackColor = False
        '
        'btnWorkPeriodRep
        '
        Me.btnWorkPeriodRep.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWorkPeriodRep.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriodRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriodRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriodRep.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriodRep.Image = Global.RestaurantPOS3.My.Resources.Resources.report_icon
        Me.btnWorkPeriodRep.Location = New System.Drawing.Point(3, 209)
        Me.btnWorkPeriodRep.Name = "btnWorkPeriodRep"
        Me.btnWorkPeriodRep.Size = New System.Drawing.Size(200, 200)
        Me.btnWorkPeriodRep.TabIndex = 5
        Me.btnWorkPeriodRep.Text = "Work Period Report"
        Me.btnWorkPeriodRep.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriodRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWorkPeriodRep.UseVisualStyleBackColor = False
        '
        'btnPOSRep
        '
        Me.btnPOSRep.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPOSRep.FlatAppearance.BorderSize = 0
        Me.btnPOSRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSRep.ForeColor = System.Drawing.Color.White
        Me.btnPOSRep.Image = Global.RestaurantPOS3.My.Resources.Resources.product_sales_report_icon
        Me.btnPOSRep.Location = New System.Drawing.Point(209, 209)
        Me.btnPOSRep.Name = "btnPOSRep"
        Me.btnPOSRep.Size = New System.Drawing.Size(200, 200)
        Me.btnPOSRep.TabIndex = 6
        Me.btnPOSRep.Text = "POS Report"
        Me.btnPOSRep.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPOSRep.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Image = Global.RestaurantPOS3.My.Resources.Resources.Log_Out_icon
        Me.btnLogout.Location = New System.Drawing.Point(415, 209)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(200, 200)
        Me.btnLogout.TabIndex = 7
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'lblUserType
        '
        Me.lblUserType.BackColor = System.Drawing.Color.White
        Me.lblUserType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUserType.Location = New System.Drawing.Point(461, 52)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(151, 29)
        Me.lblUserType.TabIndex = 74
        Me.lblUserType.Text = "User"
        Me.lblUserType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUserType.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'frmFrontOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(621, 501)
        Me.Controls.Add(Me.lblUserType)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFrontOffice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnWorkPeriod As Button
    Friend WithEvents btnPOS As Button
    Friend WithEvents btnTicket As Button
    Friend WithEvents btnWorkPeriodRep As Button
    Friend WithEvents btnPOSRep As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblUserType As Label
    Friend WithEvents Timer1 As Timer
End Class
