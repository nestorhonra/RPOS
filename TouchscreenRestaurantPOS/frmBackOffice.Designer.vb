<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackOffice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackOffice))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.btnCategories = New System.Windows.Forms.Button()
        Me.btnKitchen = New System.Windows.Forms.Button()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.btnItemStock = New System.Windows.Forms.Button()
        Me.btnTables = New System.Windows.Forms.Button()
        Me.btnNotes = New System.Windows.Forms.Button()
        Me.btnPrinterSetup = New System.Windows.Forms.Button()
        Me.btnDBSetup = New System.Windows.Forms.Button()
        Me.btnDBBackup = New System.Windows.Forms.Button()
        Me.btnDBRestore = New System.Windows.Forms.Button()
        Me.btnOthers = New System.Windows.Forms.Button()
        Me.btnWHType = New System.Windows.Forms.Button()
        Me.btnWH = New System.Windows.Forms.Button()
        Me.btnProduct = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnStore = New System.Windows.Forms.Button()
        Me.btnSTF = New System.Windows.Forms.Button()
        Me.btnExpenseType = New System.Windows.Forms.Button()
        Me.btnExpense = New System.Windows.Forms.Button()
        Me.btnWallets = New System.Windows.Forms.Button()
        Me.btnRefund = New System.Windows.Forms.Button()
        Me.btnVoucher = New System.Windows.Forms.Button()
        Me.btnDelivery = New System.Windows.Forms.Button()
        Me.btnRecipe = New System.Windows.Forms.Button()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOSRep = New System.Windows.Forms.Button()
        Me.btnAcctgRep = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUserType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(985, 50)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "   POS Settings"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.Black
        Me.lblDateTime.Location = New System.Drawing.Point(2, 51)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(1041, 37)
        Me.lblDateTime.TabIndex = 68
        Me.lblDateTime.Text = "DateTime"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnInfo)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCurrency)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCategories)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnKitchen)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnItems)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnItemStock)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnTables)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnNotes)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPrinterSetup)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDBSetup)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDBBackup)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDBRestore)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnOthers)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWHType)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWH)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnProduct)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSupplier)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPurchase)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPayment)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnStore)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSTF)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnExpenseType)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnExpense)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWallets)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRefund)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnVoucher)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnDelivery)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRecipe)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnWorkPeriod)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPOSRep)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAcctgRep)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRegistration)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnLogs)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAbout)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(2, 91)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1042, 538)
        Me.FlowLayoutPanel1.TabIndex = 69
        '
        'btnInfo
        '
        Me.btnInfo.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnInfo.FlatAppearance.BorderSize = 0
        Me.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfo.ForeColor = System.Drawing.Color.White
        Me.btnInfo.Image = Global.RestaurantPOS3.My.Resources.Resources.Restaurant_icon1
        Me.btnInfo.Location = New System.Drawing.Point(3, 3)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(200, 70)
        Me.btnInfo.TabIndex = 1
        Me.btnInfo.Text = "Restaurant Info"
        Me.btnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnInfo.UseVisualStyleBackColor = False
        '
        'btnCurrency
        '
        Me.btnCurrency.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnCurrency.FlatAppearance.BorderSize = 0
        Me.btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ForeColor = System.Drawing.Color.White
        Me.btnCurrency.Image = Global.RestaurantPOS3.My.Resources.Resources.currency_icon
        Me.btnCurrency.Location = New System.Drawing.Point(209, 3)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(200, 70)
        Me.btnCurrency.TabIndex = 2
        Me.btnCurrency.Text = "Currency Rate"
        Me.btnCurrency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCurrency.UseVisualStyleBackColor = False
        '
        'btnCategories
        '
        Me.btnCategories.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnCategories.FlatAppearance.BorderSize = 0
        Me.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategories.ForeColor = System.Drawing.Color.White
        Me.btnCategories.Image = Global.RestaurantPOS3.My.Resources.Resources.category_icon
        Me.btnCategories.Location = New System.Drawing.Point(415, 3)
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(200, 70)
        Me.btnCategories.TabIndex = 3
        Me.btnCategories.Text = "Categories"
        Me.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCategories.UseVisualStyleBackColor = False
        '
        'btnKitchen
        '
        Me.btnKitchen.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnKitchen.FlatAppearance.BorderSize = 0
        Me.btnKitchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKitchen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKitchen.ForeColor = System.Drawing.Color.White
        Me.btnKitchen.Image = Global.RestaurantPOS3.My.Resources.Resources.Household_Kitchen_icon1
        Me.btnKitchen.Location = New System.Drawing.Point(621, 3)
        Me.btnKitchen.Name = "btnKitchen"
        Me.btnKitchen.Size = New System.Drawing.Size(200, 70)
        Me.btnKitchen.TabIndex = 4
        Me.btnKitchen.Text = "Kitchen/Section"
        Me.btnKitchen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKitchen.UseVisualStyleBackColor = False
        '
        'btnItems
        '
        Me.btnItems.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnItems.FlatAppearance.BorderSize = 0
        Me.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItems.ForeColor = System.Drawing.Color.White
        Me.btnItems.Image = Global.RestaurantPOS3.My.Resources.Resources.dish_2_icon
        Me.btnItems.Location = New System.Drawing.Point(827, 3)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(200, 70)
        Me.btnItems.TabIndex = 5
        Me.btnItems.Text = "Menu Items"
        Me.btnItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnItems.UseVisualStyleBackColor = False
        '
        'btnItemStock
        '
        Me.btnItemStock.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnItemStock.FlatAppearance.BorderSize = 0
        Me.btnItemStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItemStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemStock.ForeColor = System.Drawing.Color.White
        Me.btnItemStock.Image = Global.RestaurantPOS3.My.Resources.Resources.Stocks_icon1
        Me.btnItemStock.Location = New System.Drawing.Point(3, 79)
        Me.btnItemStock.Name = "btnItemStock"
        Me.btnItemStock.Size = New System.Drawing.Size(200, 70)
        Me.btnItemStock.TabIndex = 6
        Me.btnItemStock.Text = "Item Stock"
        Me.btnItemStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnItemStock.UseVisualStyleBackColor = False
        '
        'btnTables
        '
        Me.btnTables.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnTables.FlatAppearance.BorderSize = 0
        Me.btnTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTables.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTables.ForeColor = System.Drawing.Color.White
        Me.btnTables.Image = Global.RestaurantPOS3.My.Resources.Resources.Crafting_Table_icon
        Me.btnTables.Location = New System.Drawing.Point(209, 79)
        Me.btnTables.Name = "btnTables"
        Me.btnTables.Size = New System.Drawing.Size(200, 70)
        Me.btnTables.TabIndex = 7
        Me.btnTables.Text = "Tables"
        Me.btnTables.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTables.UseVisualStyleBackColor = False
        '
        'btnNotes
        '
        Me.btnNotes.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnNotes.FlatAppearance.BorderSize = 0
        Me.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotes.ForeColor = System.Drawing.Color.White
        Me.btnNotes.Image = Global.RestaurantPOS3.My.Resources.Resources.Note_icon
        Me.btnNotes.Location = New System.Drawing.Point(415, 79)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(200, 70)
        Me.btnNotes.TabIndex = 8
        Me.btnNotes.Text = "Notes"
        Me.btnNotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNotes.UseVisualStyleBackColor = False
        '
        'btnPrinterSetup
        '
        Me.btnPrinterSetup.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPrinterSetup.FlatAppearance.BorderSize = 0
        Me.btnPrinterSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrinterSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrinterSetup.ForeColor = System.Drawing.Color.White
        Me.btnPrinterSetup.Image = Global.RestaurantPOS3.My.Resources.Resources.print_icon
        Me.btnPrinterSetup.Location = New System.Drawing.Point(621, 79)
        Me.btnPrinterSetup.Name = "btnPrinterSetup"
        Me.btnPrinterSetup.Size = New System.Drawing.Size(200, 70)
        Me.btnPrinterSetup.TabIndex = 9
        Me.btnPrinterSetup.Text = "Printer Setting"
        Me.btnPrinterSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrinterSetup.UseVisualStyleBackColor = False
        '
        'btnDBSetup
        '
        Me.btnDBSetup.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnDBSetup.FlatAppearance.BorderSize = 0
        Me.btnDBSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBSetup.ForeColor = System.Drawing.Color.White
        Me.btnDBSetup.Image = Global.RestaurantPOS3.My.Resources.Resources.sql_icon
        Me.btnDBSetup.Location = New System.Drawing.Point(827, 79)
        Me.btnDBSetup.Name = "btnDBSetup"
        Me.btnDBSetup.Size = New System.Drawing.Size(200, 70)
        Me.btnDBSetup.TabIndex = 10
        Me.btnDBSetup.Text = "Database Setup"
        Me.btnDBSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDBSetup.UseVisualStyleBackColor = False
        '
        'btnDBBackup
        '
        Me.btnDBBackup.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnDBBackup.FlatAppearance.BorderSize = 0
        Me.btnDBBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBBackup.ForeColor = System.Drawing.Color.White
        Me.btnDBBackup.Image = Global.RestaurantPOS3.My.Resources.Resources.Database_Active_icon
        Me.btnDBBackup.Location = New System.Drawing.Point(3, 155)
        Me.btnDBBackup.Name = "btnDBBackup"
        Me.btnDBBackup.Size = New System.Drawing.Size(200, 70)
        Me.btnDBBackup.TabIndex = 11
        Me.btnDBBackup.Text = "Database Backup"
        Me.btnDBBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDBBackup.UseVisualStyleBackColor = False
        '
        'btnDBRestore
        '
        Me.btnDBRestore.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnDBRestore.FlatAppearance.BorderSize = 0
        Me.btnDBRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBRestore.ForeColor = System.Drawing.Color.White
        Me.btnDBRestore.Image = Global.RestaurantPOS3.My.Resources.Resources.database_check_icon
        Me.btnDBRestore.Location = New System.Drawing.Point(209, 155)
        Me.btnDBRestore.Name = "btnDBRestore"
        Me.btnDBRestore.Size = New System.Drawing.Size(200, 70)
        Me.btnDBRestore.TabIndex = 12
        Me.btnDBRestore.Text = "Database Restore"
        Me.btnDBRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDBRestore.UseVisualStyleBackColor = False
        '
        'btnOthers
        '
        Me.btnOthers.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnOthers.FlatAppearance.BorderSize = 0
        Me.btnOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOthers.ForeColor = System.Drawing.Color.White
        Me.btnOthers.Image = Global.RestaurantPOS3.My.Resources.Resources.Settings_L_icon
        Me.btnOthers.Location = New System.Drawing.Point(415, 155)
        Me.btnOthers.Name = "btnOthers"
        Me.btnOthers.Size = New System.Drawing.Size(200, 70)
        Me.btnOthers.TabIndex = 13
        Me.btnOthers.Text = "Other Settings"
        Me.btnOthers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnOthers.UseVisualStyleBackColor = False
        '
        'btnWHType
        '
        Me.btnWHType.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWHType.FlatAppearance.BorderSize = 0
        Me.btnWHType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWHType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHType.ForeColor = System.Drawing.Color.White
        Me.btnWHType.Image = Global.RestaurantPOS3.My.Resources.Resources.Building_icon
        Me.btnWHType.Location = New System.Drawing.Point(621, 155)
        Me.btnWHType.Name = "btnWHType"
        Me.btnWHType.Size = New System.Drawing.Size(200, 70)
        Me.btnWHType.TabIndex = 14
        Me.btnWHType.Text = "Warehouse Type"
        Me.btnWHType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWHType.UseVisualStyleBackColor = False
        '
        'btnWH
        '
        Me.btnWH.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWH.FlatAppearance.BorderSize = 0
        Me.btnWH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWH.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWH.ForeColor = System.Drawing.Color.White
        Me.btnWH.Image = Global.RestaurantPOS3.My.Resources.Resources.Two_storied_house_icon
        Me.btnWH.Location = New System.Drawing.Point(827, 155)
        Me.btnWH.Name = "btnWH"
        Me.btnWH.Size = New System.Drawing.Size(200, 70)
        Me.btnWH.TabIndex = 15
        Me.btnWH.Text = "Warehouse"
        Me.btnWH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWH.UseVisualStyleBackColor = False
        '
        'btnProduct
        '
        Me.btnProduct.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnProduct.FlatAppearance.BorderSize = 0
        Me.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProduct.ForeColor = System.Drawing.Color.White
        Me.btnProduct.Image = Global.RestaurantPOS3.My.Resources.Resources.product_icon
        Me.btnProduct.Location = New System.Drawing.Point(3, 231)
        Me.btnProduct.Name = "btnProduct"
        Me.btnProduct.Size = New System.Drawing.Size(200, 70)
        Me.btnProduct.TabIndex = 16
        Me.btnProduct.Text = "Product"
        Me.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnProduct.UseVisualStyleBackColor = False
        '
        'btnSupplier
        '
        Me.btnSupplier.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnSupplier.FlatAppearance.BorderSize = 0
        Me.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ForeColor = System.Drawing.Color.White
        Me.btnSupplier.Image = Global.RestaurantPOS3.My.Resources.Resources.icon_cert1
        Me.btnSupplier.Location = New System.Drawing.Point(209, 231)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(200, 70)
        Me.btnSupplier.TabIndex = 17
        Me.btnSupplier.Text = "Supplier"
        Me.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSupplier.UseVisualStyleBackColor = False
        '
        'btnPurchase
        '
        Me.btnPurchase.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPurchase.FlatAppearance.BorderSize = 0
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.ForeColor = System.Drawing.Color.White
        Me.btnPurchase.Image = Global.RestaurantPOS3.My.Resources.Resources.Order_history_icon
        Me.btnPurchase.Location = New System.Drawing.Point(415, 231)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(200, 70)
        Me.btnPurchase.TabIndex = 18
        Me.btnPurchase.Text = "Purchase"
        Me.btnPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPurchase.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPayment.FlatAppearance.BorderSize = 0
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.White
        Me.btnPayment.Image = Global.RestaurantPOS3.My.Resources.Resources.payment_icon
        Me.btnPayment.Location = New System.Drawing.Point(621, 231)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(200, 70)
        Me.btnPayment.TabIndex = 19
        Me.btnPayment.Text = "Payment"
        Me.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnStore
        '
        Me.btnStore.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnStore.FlatAppearance.BorderSize = 0
        Me.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStore.ForeColor = System.Drawing.Color.White
        Me.btnStore.Image = Global.RestaurantPOS3.My.Resources.Resources.shop_icon
        Me.btnStore.Location = New System.Drawing.Point(827, 231)
        Me.btnStore.Name = "btnStore"
        Me.btnStore.Size = New System.Drawing.Size(200, 70)
        Me.btnStore.TabIndex = 20
        Me.btnStore.Text = "Store"
        Me.btnStore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnStore.UseVisualStyleBackColor = False
        '
        'btnSTF
        '
        Me.btnSTF.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnSTF.FlatAppearance.BorderSize = 0
        Me.btnSTF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSTF.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSTF.ForeColor = System.Drawing.Color.White
        Me.btnSTF.Image = Global.RestaurantPOS3.My.Resources.Resources.transfer_icon
        Me.btnSTF.Location = New System.Drawing.Point(3, 307)
        Me.btnSTF.Name = "btnSTF"
        Me.btnSTF.Size = New System.Drawing.Size(200, 70)
        Me.btnSTF.TabIndex = 21
        Me.btnSTF.Text = "Stock Transfer/Issue"
        Me.btnSTF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSTF.UseVisualStyleBackColor = False
        '
        'btnExpenseType
        '
        Me.btnExpenseType.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnExpenseType.FlatAppearance.BorderSize = 0
        Me.btnExpenseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpenseType.ForeColor = System.Drawing.Color.White
        Me.btnExpenseType.Image = Global.RestaurantPOS3.My.Resources.Resources.Money_icon
        Me.btnExpenseType.Location = New System.Drawing.Point(209, 307)
        Me.btnExpenseType.Name = "btnExpenseType"
        Me.btnExpenseType.Size = New System.Drawing.Size(200, 70)
        Me.btnExpenseType.TabIndex = 22
        Me.btnExpenseType.Text = "Expense Type"
        Me.btnExpenseType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExpenseType.UseVisualStyleBackColor = False
        '
        'btnExpense
        '
        Me.btnExpense.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnExpense.FlatAppearance.BorderSize = 0
        Me.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpense.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpense.ForeColor = System.Drawing.Color.White
        Me.btnExpense.Image = Global.RestaurantPOS3.My.Resources.Resources.Money_icon22
        Me.btnExpense.Location = New System.Drawing.Point(415, 307)
        Me.btnExpense.Name = "btnExpense"
        Me.btnExpense.Size = New System.Drawing.Size(200, 70)
        Me.btnExpense.TabIndex = 23
        Me.btnExpense.Text = "Expense"
        Me.btnExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExpense.UseVisualStyleBackColor = False
        '
        'btnWallets
        '
        Me.btnWallets.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWallets.FlatAppearance.BorderSize = 0
        Me.btnWallets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWallets.ForeColor = System.Drawing.Color.White
        Me.btnWallets.Image = Global.RestaurantPOS3.My.Resources.Resources.wallet
        Me.btnWallets.Location = New System.Drawing.Point(621, 307)
        Me.btnWallets.Name = "btnWallets"
        Me.btnWallets.Size = New System.Drawing.Size(200, 70)
        Me.btnWallets.TabIndex = 33
        Me.btnWallets.Text = "Wallets"
        Me.btnWallets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWallets.UseVisualStyleBackColor = False
        '
        'btnRefund
        '
        Me.btnRefund.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnRefund.FlatAppearance.BorderSize = 0
        Me.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefund.ForeColor = System.Drawing.Color.White
        Me.btnRefund.Image = Global.RestaurantPOS3.My.Resources.Resources.refund_32
        Me.btnRefund.Location = New System.Drawing.Point(827, 307)
        Me.btnRefund.Name = "btnRefund"
        Me.btnRefund.Size = New System.Drawing.Size(200, 70)
        Me.btnRefund.TabIndex = 34
        Me.btnRefund.Text = "Refund"
        Me.btnRefund.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRefund.UseVisualStyleBackColor = False
        '
        'btnVoucher
        '
        Me.btnVoucher.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnVoucher.FlatAppearance.BorderSize = 0
        Me.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoucher.ForeColor = System.Drawing.Color.White
        Me.btnVoucher.Image = Global.RestaurantPOS3.My.Resources.Resources.Document_Text_icon
        Me.btnVoucher.Location = New System.Drawing.Point(3, 383)
        Me.btnVoucher.Name = "btnVoucher"
        Me.btnVoucher.Size = New System.Drawing.Size(200, 70)
        Me.btnVoucher.TabIndex = 24
        Me.btnVoucher.Text = "Voucher"
        Me.btnVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnVoucher.UseVisualStyleBackColor = False
        '
        'btnDelivery
        '
        Me.btnDelivery.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnDelivery.FlatAppearance.BorderSize = 0
        Me.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelivery.ForeColor = System.Drawing.Color.White
        Me.btnDelivery.Image = Global.RestaurantPOS3.My.Resources.Resources.Person_Male_Light_icon
        Me.btnDelivery.Location = New System.Drawing.Point(209, 383)
        Me.btnDelivery.Name = "btnDelivery"
        Me.btnDelivery.Size = New System.Drawing.Size(200, 70)
        Me.btnDelivery.TabIndex = 25
        Me.btnDelivery.Text = "Delivery Person"
        Me.btnDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelivery.UseVisualStyleBackColor = False
        '
        'btnRecipe
        '
        Me.btnRecipe.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnRecipe.FlatAppearance.BorderSize = 0
        Me.btnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecipe.ForeColor = System.Drawing.Color.White
        Me.btnRecipe.Image = Global.RestaurantPOS3.My.Resources.Resources.Notebook_Recipe_icon
        Me.btnRecipe.Location = New System.Drawing.Point(415, 383)
        Me.btnRecipe.Name = "btnRecipe"
        Me.btnRecipe.Size = New System.Drawing.Size(200, 70)
        Me.btnRecipe.TabIndex = 26
        Me.btnRecipe.Text = "Recipe"
        Me.btnRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRecipe.UseVisualStyleBackColor = False
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnWorkPeriod.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriod.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriod.Image = Global.RestaurantPOS3.My.Resources.Resources.Order_history_icon
        Me.btnWorkPeriod.Location = New System.Drawing.Point(621, 383)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(200, 70)
        Me.btnWorkPeriod.TabIndex = 27
        Me.btnWorkPeriod.Text = "Work Period Report"
        Me.btnWorkPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOSRep
        '
        Me.btnPOSRep.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnPOSRep.FlatAppearance.BorderSize = 0
        Me.btnPOSRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSRep.ForeColor = System.Drawing.Color.White
        Me.btnPOSRep.Image = Global.RestaurantPOS3.My.Resources.Resources.Reports_icon
        Me.btnPOSRep.Location = New System.Drawing.Point(827, 383)
        Me.btnPOSRep.Name = "btnPOSRep"
        Me.btnPOSRep.Size = New System.Drawing.Size(200, 70)
        Me.btnPOSRep.TabIndex = 28
        Me.btnPOSRep.Text = "POS Report"
        Me.btnPOSRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPOSRep.UseVisualStyleBackColor = False
        '
        'btnAcctgRep
        '
        Me.btnAcctgRep.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnAcctgRep.FlatAppearance.BorderSize = 0
        Me.btnAcctgRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAcctgRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAcctgRep.ForeColor = System.Drawing.Color.White
        Me.btnAcctgRep.Image = Global.RestaurantPOS3.My.Resources.Resources.report_edit_icon
        Me.btnAcctgRep.Location = New System.Drawing.Point(3, 459)
        Me.btnAcctgRep.Name = "btnAcctgRep"
        Me.btnAcctgRep.Size = New System.Drawing.Size(200, 70)
        Me.btnAcctgRep.TabIndex = 29
        Me.btnAcctgRep.Text = "Accounting Report"
        Me.btnAcctgRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAcctgRep.UseVisualStyleBackColor = False
        '
        'btnRegistration
        '
        Me.btnRegistration.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnRegistration.FlatAppearance.BorderSize = 0
        Me.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistration.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistration.ForeColor = System.Drawing.Color.White
        Me.btnRegistration.Image = Global.RestaurantPOS3.My.Resources.Resources.User_Group_icon
        Me.btnRegistration.Location = New System.Drawing.Point(209, 459)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(200, 70)
        Me.btnRegistration.TabIndex = 30
        Me.btnRegistration.Text = "Registration"
        Me.btnRegistration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnLogs.FlatAppearance.BorderSize = 0
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.ForeColor = System.Drawing.Color.White
        Me.btnLogs.Image = Global.RestaurantPOS3.My.Resources.Resources.log_icon
        Me.btnLogs.Location = New System.Drawing.Point(415, 459)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(200, 70)
        Me.btnLogs.TabIndex = 31
        Me.btnLogs.Text = "Logs"
        Me.btnLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.LightSeaGreen
        Me.btnAbout.FlatAppearance.BorderSize = 0
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Image = Global.RestaurantPOS3.My.Resources.Resources.Actions_help_about_icon
        Me.btnAbout.Location = New System.Drawing.Point(621, 459)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(200, 70)
        Me.btnAbout.TabIndex = 32
        Me.btnAbout.Text = "About"
        Me.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUserType, Me.ToolStripStatusLabel2, Me.lblUser, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 720)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 70
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'lblUserType
        '
        Me.lblUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.Image = CType(resources.GetObject("lblUserType.Image"), System.Drawing.Image)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(78, 17)
        Me.lblUserType.Text = "User Type"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel2.Text = ":"
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(70, 17)
        Me.lblUser.Text = "User Name"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(660, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Visible = False
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
        Me.btnCancel.Location = New System.Drawing.Point(991, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(52, 49)
        Me.btnCancel.TabIndex = 67
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmBackOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1045, 632)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmBackOffice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Configuration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnInfo As Button
    Friend WithEvents btnCurrency As Button
    Friend WithEvents btnCategories As Button
    Friend WithEvents btnKitchen As Button
    Friend WithEvents btnItems As Button
    Friend WithEvents btnItemStock As Button
    Friend WithEvents btnTables As Button
    Friend WithEvents btnNotes As Button
    Friend WithEvents btnPrinterSetup As Button
    Friend WithEvents btnDBSetup As Button
    Friend WithEvents btnDBBackup As Button
    Friend WithEvents btnDBRestore As Button
    Friend WithEvents btnOthers As Button
    Friend WithEvents btnWHType As Button
    Friend WithEvents btnWH As Button
    Friend WithEvents btnProduct As Button
    Friend WithEvents btnSupplier As Button
    Friend WithEvents btnPurchase As Button
    Friend WithEvents btnPayment As Button
    Friend WithEvents btnStore As Button
    Friend WithEvents btnSTF As Button
    Friend WithEvents btnExpenseType As Button
    Friend WithEvents btnExpense As Button
    Friend WithEvents btnVoucher As Button
    Friend WithEvents btnDelivery As Button
    Friend WithEvents btnRecipe As Button
    Friend WithEvents btnWorkPeriod As Button
    Friend WithEvents btnPOSRep As Button
    Friend WithEvents btnAcctgRep As Button
    Friend WithEvents btnRegistration As Button
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblUserType As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lblUser As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents btnWallets As Button
    Friend WithEvents btnRefund As Button
End Class
