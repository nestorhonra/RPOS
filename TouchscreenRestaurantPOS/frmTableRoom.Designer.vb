<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTableRoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTableRoom))
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnRoom = New System.Windows.Forms.Button()
        Me.btnTable = New System.Windows.Forms.Button()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel7.Controls.Add(Me.btnRoom)
        Me.Panel7.Controls.Add(Me.btnTable)
        Me.Panel7.Location = New System.Drawing.Point(1, 1)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(436, 114)
        Me.Panel7.TabIndex = 75
        '
        'btnRoom
        '
        Me.btnRoom.BackColor = System.Drawing.Color.DarkBlue
        Me.btnRoom.FlatAppearance.BorderSize = 0
        Me.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoom.ForeColor = System.Drawing.Color.White
        Me.btnRoom.Image = Global.RestaurantPOS3.My.Resources.Resources.bed_icon
        Me.btnRoom.Location = New System.Drawing.Point(223, 9)
        Me.btnRoom.Name = "btnRoom"
        Me.btnRoom.Size = New System.Drawing.Size(199, 97)
        Me.btnRoom.TabIndex = 13
        Me.btnRoom.Text = "ROOM"
        Me.btnRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRoom.UseVisualStyleBackColor = False
        '
        'btnTable
        '
        Me.btnTable.BackColor = System.Drawing.Color.DarkGreen
        Me.btnTable.FlatAppearance.BorderSize = 0
        Me.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTable.ForeColor = System.Drawing.Color.White
        Me.btnTable.Image = Global.RestaurantPOS3.My.Resources.Resources.Crafting_Table_icon
        Me.btnTable.Location = New System.Drawing.Point(12, 9)
        Me.btnTable.Name = "btnTable"
        Me.btnTable.Size = New System.Drawing.Size(199, 97)
        Me.btnTable.TabIndex = 12
        Me.btnTable.Text = "TABLE"
        Me.btnTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTable.UseVisualStyleBackColor = False
        '
        'frmTableRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(438, 115)
        Me.Controls.Add(Me.Panel7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTableRoom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Table Room Selection"
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnRoom As Button
    Friend WithEvents btnTable As Button
End Class
