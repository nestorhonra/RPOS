﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnCatUp = New System.Windows.Forms.Button()
        Me.btnCatDown = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnMenuDown = New System.Windows.Forms.Button()
        Me.btnMenuUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1067, 39)
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
        Me.lblDateTime.Location = New System.Drawing.Point(700, 4)
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
        Me.TabControl1.Size = New System.Drawing.Size(1067, 672)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCatUp)
        Me.TabPage1.Controls.Add(Me.btnCatDown)
        Me.TabPage1.Controls.Add(Me.txtQty)
        Me.TabPage1.Controls.Add(Me.btnClear)
        Me.TabPage1.Controls.Add(Me.btn0)
        Me.TabPage1.Controls.Add(Me.btn9)
        Me.TabPage1.Controls.Add(Me.btn8)
        Me.TabPage1.Controls.Add(Me.btn7)
        Me.TabPage1.Controls.Add(Me.btn6)
        Me.TabPage1.Controls.Add(Me.btn5)
        Me.TabPage1.Controls.Add(Me.btn4)
        Me.TabPage1.Controls.Add(Me.btn3)
        Me.TabPage1.Controls.Add(Me.btn2)
        Me.TabPage1.Controls.Add(Me.btn1)
        Me.TabPage1.Controls.Add(Me.btnMenuDown)
        Me.TabPage1.Controls.Add(Me.btnMenuUp)
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1059, 638)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Orders"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.White
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(502, 5)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(160, 35)
        Me.txtQty.TabIndex = 97
        Me.txtQty.Text = "99"
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.Crimson
        Me.btn0.FlatAppearance.BorderSize = 0
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.ForeColor = System.Drawing.Color.White
        Me.btn0.Location = New System.Drawing.Point(1004, 45)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(50, 43)
        Me.btn0.TabIndex = 95
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.Crimson
        Me.btn9.FlatAppearance.BorderSize = 0
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.ForeColor = System.Drawing.Color.White
        Me.btn9.Location = New System.Drawing.Point(948, 45)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 43)
        Me.btn9.TabIndex = 94
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.Crimson
        Me.btn8.FlatAppearance.BorderSize = 0
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.ForeColor = System.Drawing.Color.White
        Me.btn8.Location = New System.Drawing.Point(892, 45)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 43)
        Me.btn8.TabIndex = 93
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.Crimson
        Me.btn7.FlatAppearance.BorderSize = 0
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.ForeColor = System.Drawing.Color.White
        Me.btn7.Location = New System.Drawing.Point(836, 45)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 43)
        Me.btn7.TabIndex = 92
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.Crimson
        Me.btn6.FlatAppearance.BorderSize = 0
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.ForeColor = System.Drawing.Color.White
        Me.btn6.Location = New System.Drawing.Point(780, 45)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 43)
        Me.btn6.TabIndex = 91
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.Crimson
        Me.btn5.FlatAppearance.BorderSize = 0
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.ForeColor = System.Drawing.Color.White
        Me.btn5.Location = New System.Drawing.Point(724, 45)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 43)
        Me.btn5.TabIndex = 90
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.Crimson
        Me.btn4.FlatAppearance.BorderSize = 0
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.ForeColor = System.Drawing.Color.White
        Me.btn4.Location = New System.Drawing.Point(668, 45)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 43)
        Me.btn4.TabIndex = 89
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.Crimson
        Me.btn3.FlatAppearance.BorderSize = 0
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.ForeColor = System.Drawing.Color.White
        Me.btn3.Location = New System.Drawing.Point(612, 45)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 43)
        Me.btn3.TabIndex = 88
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Crimson
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(556, 45)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 43)
        Me.btn2.TabIndex = 87
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Crimson
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.Location = New System.Drawing.Point(500, 45)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 43)
        Me.btn1.TabIndex = 86
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(498, 94)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(558, 544)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(386, 62)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(110, 576)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblID)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.Label5)
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
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(381, 650)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.dgw)
        Me.Panel3.Location = New System.Drawing.Point(101, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(277, 446)
        Me.Panel3.TabIndex = 84
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
        Me.dgw.ColumnHeadersHeight = 20
        Me.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15})
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.White
        Me.dgw.Location = New System.Drawing.Point(0, 0)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgw.RowHeadersVisible = False
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.MediumTurquoise
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgw.RowTemplate.Height = 18
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(277, 446)
        Me.dgw.TabIndex = 5
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblTotal.Location = New System.Drawing.Point(212, 506)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(163, 24)
        Me.lblTotal.TabIndex = 83
        Me.lblTotal.Text = "200.45"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(101, 509)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 20)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Total Amount :"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.lblType.ForeColor = System.Drawing.Color.DarkOrange
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
        Me.btnGetData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
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
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.btnChgTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChgTable.BackColor = System.Drawing.Color.Orange
        Me.btnChgTable.FlatAppearance.BorderSize = 0
        Me.btnChgTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChgTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChgTable.ForeColor = System.Drawing.Color.Black
        Me.btnChgTable.Location = New System.Drawing.Point(191, 584)
        Me.btnChgTable.Name = "btnChgTable"
        Me.btnChgTable.Size = New System.Drawing.Size(90, 45)
        Me.btnChgTable.TabIndex = 16
        Me.btnChgTable.Text = "Select Table"
        Me.btnChgTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnChgTable.UseVisualStyleBackColor = False
        '
        'btnHold
        '
        Me.btnHold.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.btnRecall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.TabPage2.Size = New System.Drawing.Size(1059, 638)
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
        Me.TabPage3.Size = New System.Drawing.Size(1059, 638)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Take-out"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnCatUp
        '
        Me.btnCatUp.BackColor = System.Drawing.Color.Honeydew
        Me.btnCatUp.FlatAppearance.BorderSize = 0
        Me.btnCatUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatUp.ForeColor = System.Drawing.Color.White
        Me.btnCatUp.Image = Global.RestaurantPOS3.My.Resources.Resources.Previous_32x32
        Me.btnCatUp.Location = New System.Drawing.Point(450, 18)
        Me.btnCatUp.Name = "btnCatUp"
        Me.btnCatUp.Size = New System.Drawing.Size(40, 37)
        Me.btnCatUp.TabIndex = 99
        Me.btnCatUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCatUp.UseVisualStyleBackColor = False
        '
        'btnCatDown
        '
        Me.btnCatDown.BackColor = System.Drawing.Color.Honeydew
        Me.btnCatDown.FlatAppearance.BorderSize = 0
        Me.btnCatDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatDown.ForeColor = System.Drawing.Color.White
        Me.btnCatDown.Image = Global.RestaurantPOS3.My.Resources.Resources.Next_32x32
        Me.btnCatDown.Location = New System.Drawing.Point(393, 18)
        Me.btnCatDown.Name = "btnCatDown"
        Me.btnCatDown.Size = New System.Drawing.Size(40, 37)
        Me.btnCatDown.TabIndex = 98
        Me.btnCatDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCatDown.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Honeydew
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Image = Global.RestaurantPOS3.My.Resources.Resources.Reload_icon
        Me.btnClear.Location = New System.Drawing.Point(668, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(106, 37)
        Me.btnClear.TabIndex = 96
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnMenuDown
        '
        Me.btnMenuDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuDown.BackColor = System.Drawing.Color.Honeydew
        Me.btnMenuDown.FlatAppearance.BorderSize = 0
        Me.btnMenuDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenuDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuDown.ForeColor = System.Drawing.Color.Black
        Me.btnMenuDown.Image = Global.RestaurantPOS3.My.Resources.Resources.Next_32x32
        Me.btnMenuDown.Location = New System.Drawing.Point(958, 3)
        Me.btnMenuDown.Name = "btnMenuDown"
        Me.btnMenuDown.Size = New System.Drawing.Size(40, 37)
        Me.btnMenuDown.TabIndex = 85
        Me.btnMenuDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMenuDown.UseVisualStyleBackColor = False
        '
        'btnMenuUp
        '
        Me.btnMenuUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuUp.BackColor = System.Drawing.Color.Honeydew
        Me.btnMenuUp.FlatAppearance.BorderSize = 0
        Me.btnMenuUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenuUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuUp.ForeColor = System.Drawing.Color.Black
        Me.btnMenuUp.Image = Global.RestaurantPOS3.My.Resources.Resources.Previous_32x32
        Me.btnMenuUp.Location = New System.Drawing.Point(1012, 3)
        Me.btnMenuUp.Name = "btnMenuUp"
        Me.btnMenuUp.Size = New System.Drawing.Size(40, 37)
        Me.btnMenuUp.TabIndex = 84
        Me.btnMenuUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMenuUp.UseVisualStyleBackColor = False
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
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Black
        Me.lblID.Location = New System.Drawing.Point(205, 10)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(12, 13)
        Me.lblID.TabIndex = 85
        Me.lblID.Text = "1"
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Item Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 130
        '
        'Column2
        '
        Me.Column2.HeaderText = "Rate"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Notes"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.HeaderText = "ID"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Amt"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "VatPer"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "VatAmt"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "STPer"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "STAmt"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "SCPer"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "SCAmt"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "DiscPer"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "DiscAmt"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "TotAmt"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1067, 711)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
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
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgw As DataGridView
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
    Friend WithEvents btnMenuDown As Button
    Friend WithEvents btnMenuUp As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btnCatUp As Button
    Friend WithEvents btnCatDown As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblID As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
End Class
