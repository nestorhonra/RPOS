<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblDateTime)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblUserType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(871, 39)
        Me.Panel1.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.LightSeaGreen
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUser.Location = New System.Drawing.Point(300, 5)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(151, 29)
        Me.lblUser.TabIndex = 71
        Me.lblUser.Text = "User"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(165, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 29)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "User Account :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 15.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDateTime.Location = New System.Drawing.Point(551, 4)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDateTime.Size = New System.Drawing.Size(105, 30)
        Me.lblDateTime.TabIndex = 69
        Me.lblDateTime.Text = "DateTime"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Restaurant POS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'lblUserType
        '
        Me.lblUserType.BackColor = System.Drawing.Color.LightSeaGreen
        Me.lblUserType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUserType.Location = New System.Drawing.Point(455, 5)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(91, 29)
        Me.lblUserType.TabIndex = 72
        Me.lblUserType.Text = "User"
        Me.lblUserType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(871, 442)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblUserType As Label
End Class
