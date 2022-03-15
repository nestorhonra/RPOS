<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduct
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
        Dim Label11 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProduct))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.chkHasExpiryDate = New System.Windows.Forms.CheckBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.btnRemoveFromGridOS = New System.Windows.Forms.Button()
        Me.btnAddOS = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbWareHouse = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtReorderPoint = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.txtFeatures = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(21, 29)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(32, 13)
        Label11.TabIndex = 305
        Label11.Text = "Qty. :"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.ForeColor = System.Drawing.Color.Black
        Label24.Location = New System.Drawing.Point(21, 22)
        Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(68, 13)
        Label24.TabIndex = 278
        Label24.Text = "Warehouse :"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(21, 87)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(67, 13)
        Label8.TabIndex = 307
        Label8.Text = "Expiry Date :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 395)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.btnRemoveFromGridOS)
        Me.GroupBox1.Controls.Add(Me.btnAddOS)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.cmbWareHouse)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Label24)
        Me.GroupBox1.Location = New System.Drawing.Point(442, 48)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(425, 340)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product Opening Stock Info"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpExpiryDate)
        Me.GroupBox3.Controls.Add(Label8)
        Me.GroupBox3.Controls.Add(Me.chkHasExpiryDate)
        Me.GroupBox3.Controls.Add(Me.txtQty)
        Me.GroupBox3.Controls.Add(Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(281, 123)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opening Stock"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpExpiryDate.Enabled = False
        Me.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiryDate.Location = New System.Drawing.Point(118, 87)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.Size = New System.Drawing.Size(117, 20)
        Me.dtpExpiryDate.TabIndex = 2
        '
        'chkHasExpiryDate
        '
        Me.chkHasExpiryDate.AutoSize = True
        Me.chkHasExpiryDate.Location = New System.Drawing.Point(118, 58)
        Me.chkHasExpiryDate.Name = "chkHasExpiryDate"
        Me.chkHasExpiryDate.Size = New System.Drawing.Size(111, 17)
        Me.chkHasExpiryDate.TabIndex = 1
        Me.chkHasExpiryDate.Text = "Has Expiry Date ?"
        Me.chkHasExpiryDate.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(118, 26)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(105, 20)
        Me.txtQty.TabIndex = 0
        Me.txtQty.Text = "0"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRemoveFromGridOS
        '
        Me.btnRemoveFromGridOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveFromGridOS.Image = CType(resources.GetObject("btnRemoveFromGridOS.Image"), System.Drawing.Image)
        Me.btnRemoveFromGridOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGridOS.Location = New System.Drawing.Point(326, 60)
        Me.btnRemoveFromGridOS.Name = "btnRemoveFromGridOS"
        Me.btnRemoveFromGridOS.Size = New System.Drawing.Size(90, 34)
        Me.btnRemoveFromGridOS.TabIndex = 5
        Me.btnRemoveFromGridOS.Text = "&Remove"
        Me.btnRemoveFromGridOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveFromGridOS.UseVisualStyleBackColor = True
        '
        'btnAddOS
        '
        Me.btnAddOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddOS.Image = CType(resources.GetObject("btnAddOS.Image"), System.Drawing.Image)
        Me.btnAddOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddOS.Location = New System.Drawing.Point(326, 19)
        Me.btnAddOS.Name = "btnAddOS"
        Me.btnAddOS.Size = New System.Drawing.Size(67, 34)
        Me.btnAddOS.TabIndex = 4
        Me.btnAddOS.Text = "&Add"
        Me.btnAddOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddOS.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.ColumnHeadersHeight = 33
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column7, Me.Column4, Me.Column5})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(24, 185)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.RowTemplate.Height = 18
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(383, 146)
        Me.DataGridView1.TabIndex = 3
        '
        'Column2
        '
        Me.Column2.HeaderText = "Warehouse"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column7.HeaderText = "Qty."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column4.HeaderText = "Has Expiry Date ?"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "Expiry Date"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'cmbWareHouse
        '
        Me.cmbWareHouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbWareHouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWareHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWareHouse.FormattingEnabled = True
        Me.cmbWareHouse.Items.AddRange(New Object() {"Hinduism", "Christianity", "Islam", "Buddhism", "Sikhism", "Jainism", "Taoism", "Shinto", "Judaism", "Korean shamanism", "Confucianism", "Caodaism", "Bahá'í Faith", "Cheondoism", "Secular/Nonreligious/Agnostic/Atheist", "African Traditional & Diasporic", "Spiritism", "Zoroastrianism", "Tenrikyo", "Neo-Paganism", "Rastafarianism", "Hoahaoism", "Chinese folk religion", "Tenriism", "Any Other"})
        Me.cmbWareHouse.Location = New System.Drawing.Point(112, 22)
        Me.cmbWareHouse.Name = "cmbWareHouse"
        Me.cmbWareHouse.Size = New System.Drawing.Size(193, 23)
        Me.cmbWareHouse.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(589, 266)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(164, 15)
        Me.Label21.TabIndex = 287
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 23)
        Me.Label22.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGetData)
        Me.GroupBox2.Controls.Add(Me.btnNew)
        Me.GroupBox2.Controls.Add(Me.btnUpdate)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Location = New System.Drawing.Point(873, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(115, 249)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action Button"
        '
        'btnGetData
        '
        Me.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.Image = CType(resources.GetObject("btnGetData.Image"), System.Drawing.Image)
        Me.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetData.Location = New System.Drawing.Point(11, 201)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(92, 37)
        Me.btnGetData.TabIndex = 7
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(11, 18)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(92, 37)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(11, 112)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(92, 37)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(11, 65)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 37)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(11, 159)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(92, 37)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(951, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(39, 36)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtReorderPoint)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.cmbUnit)
        Me.Panel4.Controls.Add(Me.txtID)
        Me.Panel4.Controls.Add(Me.lblUserType)
        Me.Panel4.Controls.Add(Me.txtProductName)
        Me.Panel4.Controls.Add(Me.cmbCategory)
        Me.Panel4.Controls.Add(Me.lblUser)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtProductCode)
        Me.Panel4.Controls.Add(Me.txtFeatures)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtPrice)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(9, 54)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(427, 333)
        Me.Panel4.TabIndex = 0
        '
        'txtReorderPoint
        '
        Me.txtReorderPoint.BackColor = System.Drawing.Color.White
        Me.txtReorderPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReorderPoint.Location = New System.Drawing.Point(125, 299)
        Me.txtReorderPoint.Name = "txtReorderPoint"
        Me.txtReorderPoint.Size = New System.Drawing.Size(111, 21)
        Me.txtReorderPoint.TabIndex = 7
        Me.txtReorderPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 328
        Me.Label4.Text = "Reorder Point :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 327
        Me.Label6.Text = "Unit :"
        '
        'cmbUnit
        '
        Me.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(125, 241)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(173, 23)
        Me.cmbUnit.TabIndex = 5
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(305, -1)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(53, 21)
        Me.txtID.TabIndex = 323
        Me.txtID.Visible = False
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Location = New System.Drawing.Point(320, 11)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(62, 15)
        Me.lblUserType.TabIndex = 313
        Me.lblUserType.Text = "User Type"
        Me.lblUserType.Visible = False
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(125, 41)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(257, 21)
        Me.txtProductName.TabIndex = 1
        '
        'cmbCategory
        '
        Me.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(125, 68)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(173, 23)
        Me.cmbCategory.TabIndex = 2
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(265, 12)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(45, 15)
        Me.lblUser.TabIndex = 12
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Price :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Product Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Product Code :"
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(125, 13)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.Size = New System.Drawing.Size(123, 21)
        Me.txtProductCode.TabIndex = 0
        '
        'txtFeatures
        '
        Me.txtFeatures.BackColor = System.Drawing.Color.White
        Me.txtFeatures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeatures.Location = New System.Drawing.Point(125, 97)
        Me.txtFeatures.Multiline = True
        Me.txtFeatures.Name = "txtFeatures"
        Me.txtFeatures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFeatures.Size = New System.Drawing.Size(286, 138)
        Me.txtFeatures.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Category :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Description :"
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.Color.White
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(125, 270)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(111, 21)
        Me.txtPrice.TabIndex = 6
        Me.txtPrice.Text = "0.00"
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 36)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(397, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Entry"
        '
        'frmProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Orange
        Me.ClientSize = New System.Drawing.Size(1002, 403)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFeatures As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents lblUserType As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtReorderPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkHasExpiryDate As System.Windows.Forms.CheckBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Public WithEvents btnRemoveFromGridOS As System.Windows.Forms.Button
    Public WithEvents btnAddOS As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents cmbWareHouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
