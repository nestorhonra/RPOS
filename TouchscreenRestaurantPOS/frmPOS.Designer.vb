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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTypeID = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.btnDinein = New System.Windows.Forms.Button()
        Me.btnTakeout = New System.Windows.Forms.Button()
        Me.txtTableNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTicketNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnChgTable = New System.Windows.Forms.Button()
        Me.btnHold = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnRecall = New System.Windows.Forms.Button()
        Me.btnOpenTicket = New System.Windows.Forms.Button()
        Me.btnNewTicket = New System.Windows.Forms.Button()
        Me.btnChgQty = New System.Windows.Forms.Button()
        Me.btnChgRate = New System.Windows.Forms.Button()
        Me.btnNotes = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnLess = New System.Windows.Forms.Button()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsEnabled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1008, 39)
        Me.Panel1.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.LightSeaGreen
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUser.Location = New System.Drawing.Point(302, 5)
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
        Me.Label2.Location = New System.Drawing.Point(160, 5)
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
        Me.lblDateTime.Location = New System.Drawing.Point(641, 4)
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
        'lblUserType
        '
        Me.lblUserType.BackColor = System.Drawing.Color.LightSeaGreen
        Me.lblUserType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.NavajoWhite
        Me.lblUserType.Location = New System.Drawing.Point(459, 5)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(91, 29)
        Me.lblUserType.TabIndex = 72
        Me.lblUserType.Text = "User"
        Me.lblUserType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 39)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 672)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel3)
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1000, 638)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Orders"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(498, 489)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(499, 146)
        Me.FlowLayoutPanel3.TabIndex = 3
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Button21)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button16)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button17)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button18)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button19)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(498, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(499, 461)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button21.FlatAppearance.BorderSize = 0
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.ForeColor = System.Drawing.Color.White
        Me.Button21.Location = New System.Drawing.Point(3, 3)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(93, 50)
        Me.Button21.TabIndex = 32
        Me.Button21.Text = "Change Rate"
        Me.Button21.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button21.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button16.FlatAppearance.BorderSize = 0
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.Color.White
        Me.Button16.Location = New System.Drawing.Point(102, 3)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(93, 50)
        Me.Button16.TabIndex = 33
        Me.Button16.Text = "Change Rate"
        Me.Button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.White
        Me.Button17.Location = New System.Drawing.Point(201, 3)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(93, 50)
        Me.Button17.TabIndex = 34
        Me.Button17.Text = "Change Rate"
        Me.Button17.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button18.FlatAppearance.BorderSize = 0
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.ForeColor = System.Drawing.Color.White
        Me.Button18.Location = New System.Drawing.Point(300, 3)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(93, 50)
        Me.Button18.TabIndex = 35
        Me.Button18.Text = "Change Rate"
        Me.Button18.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button19.FlatAppearance.BorderSize = 0
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button19.ForeColor = System.Drawing.Color.White
        Me.Button19.Location = New System.Drawing.Point(399, 3)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(93, 50)
        Me.Button19.TabIndex = 36
        Me.Button19.Text = "Change Rate"
        Me.Button19.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button19.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button20)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button22)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button23)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button24)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button25)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button26)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button27)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(386, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(110, 635)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button20.FlatAppearance.BorderSize = 0
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.ForeColor = System.Drawing.Color.White
        Me.Button20.Location = New System.Drawing.Point(3, 3)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(100, 50)
        Me.Button20.TabIndex = 25
        Me.Button20.Text = "Change Rate"
        Me.Button20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button20.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button22.FlatAppearance.BorderSize = 0
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.ForeColor = System.Drawing.Color.White
        Me.Button22.Location = New System.Drawing.Point(3, 59)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(100, 50)
        Me.Button22.TabIndex = 26
        Me.Button22.Text = "Change Rate"
        Me.Button22.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button23.FlatAppearance.BorderSize = 0
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.ForeColor = System.Drawing.Color.White
        Me.Button23.Location = New System.Drawing.Point(3, 115)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(100, 50)
        Me.Button23.TabIndex = 27
        Me.Button23.Text = "Change Rate"
        Me.Button23.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button24.FlatAppearance.BorderSize = 0
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.ForeColor = System.Drawing.Color.White
        Me.Button24.Location = New System.Drawing.Point(3, 171)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(100, 50)
        Me.Button24.TabIndex = 28
        Me.Button24.Text = "Change Rate"
        Me.Button24.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button25.FlatAppearance.BorderSize = 0
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.White
        Me.Button25.Location = New System.Drawing.Point(3, 227)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(100, 50)
        Me.Button25.TabIndex = 29
        Me.Button25.Text = "Change Rate"
        Me.Button25.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button26.FlatAppearance.BorderSize = 0
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.ForeColor = System.Drawing.Color.White
        Me.Button26.Location = New System.Drawing.Point(3, 283)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(100, 50)
        Me.Button26.TabIndex = 30
        Me.Button26.Text = "Change Rate"
        Me.Button26.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button27.FlatAppearance.BorderSize = 0
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.White
        Me.Button27.Location = New System.Drawing.Point(3, 339)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(100, 50)
        Me.Button27.TabIndex = 31
        Me.Button27.Text = "Change Rate"
        Me.Button27.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDown)
        Me.Panel2.Controls.Add(Me.btnUp)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.lblTypeID)
        Me.Panel2.Controls.Add(Me.lblType)
        Me.Panel2.Controls.Add(Me.btnDinein)
        Me.Panel2.Controls.Add(Me.btnTakeout)
        Me.Panel2.Controls.Add(Me.txtTableNo)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtTicketNo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnGetData)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnChgTable)
        Me.Panel2.Controls.Add(Me.btnHold)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnRecall)
        Me.Panel2.Controls.Add(Me.btnOpenTicket)
        Me.Panel2.Controls.Add(Me.btnNewTicket)
        Me.Panel2.Controls.Add(Me.btnChgQty)
        Me.Panel2.Controls.Add(Me.btnChgRate)
        Me.Panel2.Controls.Add(Me.btnNotes)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.btnLess)
        Me.Panel2.Controls.Add(Me.dgw)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(383, 650)
        Me.Panel2.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(5, 533)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 45)
        Me.btnCancel.TabIndex = 79
        Me.btnCancel.Text = "Cancel Ticket"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblTypeID
        '
        Me.lblTypeID.AutoSize = True
        Me.lblTypeID.BackColor = System.Drawing.Color.Transparent
        Me.lblTypeID.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeID.ForeColor = System.Drawing.Color.Black
        Me.lblTypeID.Location = New System.Drawing.Point(181, 10)
        Me.lblTypeID.Name = "lblTypeID"
        Me.lblTypeID.Size = New System.Drawing.Size(12, 13)
        Me.lblTypeID.TabIndex = 78
        Me.lblTypeID.Text = "1"
        '
        'lblType
        '
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.Orange
        Me.lblType.Location = New System.Drawing.Point(9, 30)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(112, 25)
        Me.lblType.TabIndex = 77
        Me.lblType.Text = "Take-out"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDinein
        '
        Me.btnDinein.BackColor = System.Drawing.Color.SeaGreen
        Me.btnDinein.FlatAppearance.BorderSize = 0
        Me.btnDinein.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDinein.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDinein.ForeColor = System.Drawing.Color.White
        Me.btnDinein.Location = New System.Drawing.Point(127, 29)
        Me.btnDinein.Name = "btnDinein"
        Me.btnDinein.Size = New System.Drawing.Size(90, 25)
        Me.btnDinein.TabIndex = 76
        Me.btnDinein.Text = "Dine-in"
        Me.btnDinein.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDinein.UseVisualStyleBackColor = False
        '
        'btnTakeout
        '
        Me.btnTakeout.BackColor = System.Drawing.Color.Crimson
        Me.btnTakeout.FlatAppearance.BorderSize = 0
        Me.btnTakeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTakeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTakeout.ForeColor = System.Drawing.Color.White
        Me.btnTakeout.Location = New System.Drawing.Point(232, 29)
        Me.btnTakeout.Name = "btnTakeout"
        Me.btnTakeout.Size = New System.Drawing.Size(90, 25)
        Me.btnTakeout.TabIndex = 75
        Me.btnTakeout.Text = "Take-out"
        Me.btnTakeout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTakeout.UseVisualStyleBackColor = False
        '
        'txtTableNo
        '
        Me.txtTableNo.BackColor = System.Drawing.Color.White
        Me.txtTableNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableNo.Location = New System.Drawing.Point(332, 3)
        Me.txtTableNo.Name = "txtTableNo"
        Me.txtTableNo.ReadOnly = True
        Me.txtTableNo.Size = New System.Drawing.Size(33, 26)
        Me.txtTableNo.TabIndex = 74
        Me.txtTableNo.Text = "99"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(249, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 20)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Table No :"
        '
        'txtTicketNo
        '
        Me.txtTicketNo.BackColor = System.Drawing.Color.White
        Me.txtTicketNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTicketNo.Location = New System.Drawing.Point(90, 6)
        Me.txtTicketNo.Name = "txtTicketNo"
        Me.txtTicketNo.ReadOnly = True
        Me.txtTicketNo.Size = New System.Drawing.Size(86, 21)
        Me.txtTicketNo.TabIndex = 72
        Me.txtTicketNo.Text = "1234567890"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Ticket No :"
        '
        'btnGetData
        '
        Me.btnGetData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGetData.FlatAppearance.BorderSize = 0
        Me.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.ForeColor = System.Drawing.Color.White
        Me.btnGetData.Location = New System.Drawing.Point(5, 584)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(90, 45)
        Me.btnGetData.TabIndex = 20
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGetData.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Magenta
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(98, 584)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(90, 45)
        Me.btnUpdate.TabIndex = 18
        Me.btnUpdate.Text = "Update + Print"
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.MediumBlue
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(98, 533)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 45)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save + Print"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnChgTable
        '
        Me.btnChgTable.BackColor = System.Drawing.Color.Orange
        Me.btnChgTable.FlatAppearance.BorderSize = 0
        Me.btnChgTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChgTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChgTable.ForeColor = System.Drawing.Color.Black
        Me.btnChgTable.Location = New System.Drawing.Point(191, 584)
        Me.btnChgTable.Name = "btnChgTable"
        Me.btnChgTable.Size = New System.Drawing.Size(90, 45)
        Me.btnChgTable.TabIndex = 16
        Me.btnChgTable.Text = "Change Table"
        Me.btnChgTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnChgTable.UseVisualStyleBackColor = False
        '
        'btnHold
        '
        Me.btnHold.BackColor = System.Drawing.Color.OrangeRed
        Me.btnHold.FlatAppearance.BorderSize = 0
        Me.btnHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHold.ForeColor = System.Drawing.Color.White
        Me.btnHold.Location = New System.Drawing.Point(191, 533)
        Me.btnHold.Name = "btnHold"
        Me.btnHold.Size = New System.Drawing.Size(90, 45)
        Me.btnHold.TabIndex = 15
        Me.btnHold.Text = "Hold"
        Me.btnHold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnHold.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.BlueViolet
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(285, 584)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 45)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnRecall
        '
        Me.btnRecall.BackColor = System.Drawing.Color.DarkCyan
        Me.btnRecall.FlatAppearance.BorderSize = 0
        Me.btnRecall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecall.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecall.ForeColor = System.Drawing.Color.White
        Me.btnRecall.Location = New System.Drawing.Point(285, 533)
        Me.btnRecall.Name = "btnRecall"
        Me.btnRecall.Size = New System.Drawing.Size(90, 45)
        Me.btnRecall.TabIndex = 13
        Me.btnRecall.Text = "Recall"
        Me.btnRecall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRecall.UseVisualStyleBackColor = False
        '
        'btnOpenTicket
        '
        Me.btnOpenTicket.BackColor = System.Drawing.Color.Gold
        Me.btnOpenTicket.FlatAppearance.BorderSize = 0
        Me.btnOpenTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenTicket.ForeColor = System.Drawing.Color.Black
        Me.btnOpenTicket.Location = New System.Drawing.Point(5, 470)
        Me.btnOpenTicket.Name = "btnOpenTicket"
        Me.btnOpenTicket.Size = New System.Drawing.Size(90, 45)
        Me.btnOpenTicket.TabIndex = 12
        Me.btnOpenTicket.Text = "Open Ticket"
        Me.btnOpenTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnOpenTicket.UseVisualStyleBackColor = False
        '
        'btnNewTicket
        '
        Me.btnNewTicket.BackColor = System.Drawing.Color.ForestGreen
        Me.btnNewTicket.FlatAppearance.BorderSize = 0
        Me.btnNewTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewTicket.ForeColor = System.Drawing.Color.White
        Me.btnNewTicket.Location = New System.Drawing.Point(5, 419)
        Me.btnNewTicket.Name = "btnNewTicket"
        Me.btnNewTicket.Size = New System.Drawing.Size(90, 45)
        Me.btnNewTicket.TabIndex = 11
        Me.btnNewTicket.Text = "New Ticket"
        Me.btnNewTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNewTicket.UseVisualStyleBackColor = False
        '
        'btnChgQty
        '
        Me.btnChgQty.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnChgQty.FlatAppearance.BorderSize = 0
        Me.btnChgQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChgQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChgQty.ForeColor = System.Drawing.Color.White
        Me.btnChgQty.Location = New System.Drawing.Point(5, 368)
        Me.btnChgQty.Name = "btnChgQty"
        Me.btnChgQty.Size = New System.Drawing.Size(90, 45)
        Me.btnChgQty.TabIndex = 10
        Me.btnChgQty.Text = "Change Qty"
        Me.btnChgQty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnChgQty.UseVisualStyleBackColor = False
        '
        'btnChgRate
        '
        Me.btnChgRate.BackColor = System.Drawing.Color.DarkOrchid
        Me.btnChgRate.FlatAppearance.BorderSize = 0
        Me.btnChgRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChgRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChgRate.ForeColor = System.Drawing.Color.White
        Me.btnChgRate.Location = New System.Drawing.Point(5, 317)
        Me.btnChgRate.Name = "btnChgRate"
        Me.btnChgRate.Size = New System.Drawing.Size(90, 45)
        Me.btnChgRate.TabIndex = 9
        Me.btnChgRate.Text = "Change Rate"
        Me.btnChgRate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnChgRate.UseVisualStyleBackColor = False
        '
        'btnNotes
        '
        Me.btnNotes.BackColor = System.Drawing.Color.DarkCyan
        Me.btnNotes.FlatAppearance.BorderSize = 0
        Me.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotes.ForeColor = System.Drawing.Color.White
        Me.btnNotes.Location = New System.Drawing.Point(5, 266)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(90, 45)
        Me.btnNotes.TabIndex = 8
        Me.btnNotes.Text = "Add Notes"
        Me.btnNotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNotes.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.DarkRed
        Me.btnRemove.FlatAppearance.BorderSize = 0
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(5, 215)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(90, 45)
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnLess
        '
        Me.btnLess.BackColor = System.Drawing.Color.Crimson
        Me.btnLess.FlatAppearance.BorderSize = 0
        Me.btnLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLess.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLess.ForeColor = System.Drawing.Color.White
        Me.btnLess.Location = New System.Drawing.Point(5, 164)
        Me.btnLess.Name = "btnLess"
        Me.btnLess.Size = New System.Drawing.Size(90, 45)
        Me.btnLess.TabIndex = 6
        Me.btnLess.Text = "-"
        Me.btnLess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLess.UseVisualStyleBackColor = False
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.dgw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw.ColumnHeadersHeight = 25
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.IsEnabled, Me.Column1})
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.White
        Me.dgw.Location = New System.Drawing.Point(99, 59)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgw.RowHeadersVisible = False
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumTurquoise
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgw.RowTemplate.Height = 18
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(281, 457)
        Me.dgw.TabIndex = 5
        '
        'Column2
        '
        Me.Column2.HeaderText = "Item Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Rate"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 70
        '
        'IsEnabled
        '
        Me.IsEnabled.HeaderText = "Qty"
        Me.IsEnabled.Name = "IsEnabled"
        Me.IsEnabled.ReadOnly = True
        Me.IsEnabled.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Green
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(5, 113)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 45)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "+"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1000, 638)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bill Out"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1000, 638)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Take-out"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.Color.Honeydew
        Me.btnDown.FlatAppearance.BorderSize = 0
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.ForeColor = System.Drawing.Color.Black
        Me.btnDown.Image = Global.RestaurantPOS3.My.Resources.Resources.Next_32x32
        Me.btnDown.Location = New System.Drawing.Point(55, 59)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(40, 45)
        Me.btnDown.TabIndex = 81
        Me.btnDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnUp
        '
        Me.btnUp.BackColor = System.Drawing.Color.Honeydew
        Me.btnUp.FlatAppearance.BorderSize = 0
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.ForeColor = System.Drawing.Color.Black
        Me.btnUp.Image = Global.RestaurantPOS3.My.Resources.Resources.Previous_32x32
        Me.btnUp.Location = New System.Drawing.Point(5, 59)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(40, 45)
        Me.btnUp.TabIndex = 80
        Me.btnUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1008, 711)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblUserType As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgw As DataGridView
    Friend WithEvents Button21 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents Button25 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents btnGetData As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnChgTable As Button
    Friend WithEvents btnHold As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnRecall As Button
    Friend WithEvents btnOpenTicket As Button
    Friend WithEvents btnNewTicket As Button
    Friend WithEvents btnChgQty As Button
    Friend WithEvents btnChgRate As Button
    Friend WithEvents btnNotes As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnLess As Button
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents IsEnabled As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTypeID As Label
    Friend WithEvents lblType As Label
    Friend WithEvents btnDinein As Button
    Friend WithEvents btnTakeout As Button
    Friend WithEvents txtTableNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTicketNo As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnUp As Button
    Friend WithEvents btnDown As Button
End Class
