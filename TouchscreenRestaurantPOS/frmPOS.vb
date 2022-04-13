Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing

Public Class frmPOS
    Dim rowIndex As Integer
    Dim table As New DataTable("table")
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Public is_edit As Boolean = False
    Dim s, x As String
    Dim srvTax, srvChrge, srvVat, srvSC As Double
    Dim StoreName As String = ""
    Dim StoreAddress As String = ""
    Dim Img As Image
    Public TransNo As String = ""
    Dim TransDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
    Dim TINNo As String = ""
    Dim SNNo As String = ""
    Dim MIDNo As String = ""
    Dim CurCode As String = ""
    Dim is_en As Boolean = False
    'for item sales | untuk item penjualan
    Public dtItem As DataTable
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat
    Dim PosTicketPrntr As String = ""
    Dim PosInvPrntr As String = ""
    Dim c As New PrintingFormat
    Public wal_tag As Boolean
    Dim dblSubTotVat As Double = 0
    Dim dblSubtotal As Double = 0
    Dim dblQty As Double = 0
    Dim dblPayment As Double = 0
    Dim dblVatTot As Double = 0
    Dim dblDiscTot As Double = 0
    Dim dblSCTot As Double = 0
    Dim dblSCDisc As Double = 0
    Dim FocusText As TextBox
    Dim tableTag As String = ""
    Dim ticketTag As String = ""
    Dim cateTag As String = ""
    Dim splitTag As Boolean = False
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClearAll()
        Call Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select TOP 1 * from OtherSetting ORDER BY ID ASC"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                If Not rdr Is Nothing Then
                    srvVat = toNumber(rdr(4).ToString)
                    srvTax = toNumber(rdr(5).ToString)
                    srvChrge = toNumber(rdr(6).ToString)
                    srvSC = toNumber(rdr("SeniorDiscount").ToString)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAll()
        lblType.Text = ""
        lblTypeID.Text = ""
        lblTotal.Text = ""
        lblTotalBill.Text = ""
        lblGrandTotal.Text = ""
        lblPayID.Text = ""
        lblRefNo.Text = ""
        lblSubTotal.Text = ""
        lblSCName.Text = ""
        lblBookID.Text = ""
        lblRoomNo.Text = ""
        lblGuestName.Text = ""
        lblID.Text = ""
        lblIDRecall.Text = ""
        lblID.Text = ""
        lblSplitTotal.Text = ""

        txtSCDiscPer.Text = ""
        txtSCAmount.Text = ""
        txtOSCANo.Text = ""
        txtTableNo.Text = ""
        txtTicketNo.Text = ""
        txtQty.Text = ""
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtGrandTot.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        txtBillNo.Text = ""
        txtPaymentMode.Text = ""

        chkSC.Checked = False
        txtOSCANo.ReadOnly = True
        txtOSCANo.BackColor = Color.WhiteSmoke
        txtSCDiscPer.ReadOnly = True
        txtSCDiscPer.BackColor = Color.WhiteSmoke
        txtSCAmount.ReadOnly = True
        txtSCAmount.BackColor = Color.WhiteSmoke

        ticketTag = ""
        tableTag = ""
        cateTag = ""

        dblDiscTot = 0
        dblPayment = 0
        dblQty = 0
        dblSCDisc = 0
        dblSCTot = 0
        dblSubtotal = 0
        dblSubTotVat = 0
        dblVatTot = 0
        is_edit = False
        wal_tag = False
        splitTag = False
        pnlPayment.SendToBack()
        pnlPayment.Hide()
        dgwList.Rows.Clear()
        dgw.Rows.Clear()
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
        is_edit = False
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel2.Controls.Clear()
        FlowLayoutPanel3.Controls.Clear()
        btnSave.Enabled = False

    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN), ReceiptLogo, isEnabled, CurrencyCode from Hotel", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read Then
                StoreName = rdr(1).ToString
                StoreAddress = rdr(2).ToString
                Dim data As Byte() = DirectCast(rdr(8), Byte())
                Dim ms As New MemoryStream(data)
                Img = Image.FromStream(ms)
                TINNo = "VAT REG TIN:" & rdr(5).ToString
                SNNo = "SERIAL NO:" & rdr(6).ToString
                MIDNo = "MIN:" & rdr(7).ToString
                is_en = rdr(9)
                CurCode = rdr(10).ToString
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * FROM PosPrinterSetting", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read
                If rdr(2).ToString = "Ticket Printer" Then
                    If rdr(3) = "Yes" Then
                        PosTicketPrntr = Trim(rdr(1).ToString)
                    Else
                        PosTicketPrntr = ""
                    End If
                ElseIf rdr(2).ToString = "Invoice Printer" Then
                    If rdr(3) = "Yes" Then
                        PosInvPrntr = Trim(rdr(1).ToString)
                    Else
                        PosInvPrntr = ""
                    End If
                End If
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                dgw.Focus()
            Case Keys.Down
                dgw.Focus()
        End Select
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub AutoSizeRow()
        dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowMode.AllCells
    End Sub

    Public Sub GetOrders(ByVal ids As String, ByVal tagf As Integer)
        If ids <> "" Then
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim cl As String = ""
                If tagf > 0 Then
                    cl = "SELECT TOP 1 * FROM TempRestaurantPOS_OrderInfoKOT where TableNo=@d1 AND isPaid=0 ORDER BY ID DESC"
                Else
                    cl = "SELECT TOP 1 * FROM RestaurantPOS_OrderInfoKOT where TableNo=@d1 AND isPaid=0 ORDER BY ID DESC"
                End If

                cmd = New SqlCommand(cl)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", ids)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    If tagf > 0 Then
                        lblIDRecall.Text = toNumber(rdr(0))
                        txtTicketNo.Text = ""
                        txtTableNo.Text = ""
                    Else
                        lblID.Text = toNumber(rdr(0))
                        txtTicketNo.Text = rdr(1).ToString
                        txtTableNo.Text = rdr(4).ToString
                    End If


                    lblTotal.Text = toMoney(rdr(3).ToString)
                    lblType.Text = rdr(8).ToString
                    lblTypeID.Text = changeOneZeroValue(rdr(9))
                    'MsgBox(rdr(9) & " " & ids)
                    Call GetOrderList(toNumber(rdr(0)).ToString, tagf)
                End If
                con.Close()
                If tagf > 0 Then
                    Try
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_OrderInfoKOT"
                        cmd = New SqlCommand(ct)
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()

                        If rdr.Read() Then
                            txtTicketNo.Text = Format(rdr(0).ToString + 1, "000000")
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GetOrderList(ByVal ids As Integer, ByVal tagf As Integer)
        If ids > 0 Then
            dgw.Rows.Clear()
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = ""
                If tagf > 0 Then
                    cmdText1 = "SELECT * from TempRestaurantPOS_OrderedProductKOT where TicketID = '" & ids & "'"
                Else
                    cmdText1 = "SELECT * from RestaurantPOS_OrderedProductKOT where TicketID = '" & ids & "' AND isPaid=0"
                End If
                cmd = New SqlCommand(cmdText1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                FlowLayoutPanel2.Controls.Clear()
                Do While (rdr.Read())
                    dgw.Rows.Add(Trim(rdr(2).ToString), toMoney(rdr(3).ToString), rdr(4), Trim(rdr(15).ToString), toNumber(rdr(0)), toNumber(rdr(5)), toNumber(rdr(6)), toNumber(rdr(7)), toNumber(rdr(8)), toNumber(rdr(9)), toNumber(rdr(10)), toNumber(rdr(11)), toNumber(rdr(12)), toNumber(rdr(13)), toNumber(rdr(14)), Trim(rdr(16).ToString))
                Loop
                con.Close()
                Call FillCategory()
                Call ComputeTotal()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FillMenus(ByVal categ As String)
        If categ <> "" Then
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT * from Dish where Category = '" & categ & "'"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel2.Controls.Clear()
            Do While (rdr.Read())
                Dim img As New PictureBox
                Dim btn As New Button
                Dim flp As New FlowLayoutPanel
                btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
                If Not IsDBNull(rdr.GetValue(6)) Then
                    Dim data1 As Byte() = DirectCast(rdr.GetValue(6), Byte())
                    Dim ms1 As New MemoryStream(data1)
                    img.Image = Image.FromStream(ms1)
                End If
                ' btn.BackgroundImageLayout = ImageLayout.Zoom
                btn.TextImageRelation = TextImageRelation.ImageAboveText
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Flat
                btn.UseVisualStyleBackColor = True
                btn.FlatAppearance.BorderSize = 0
                btn.FlatAppearance.BorderColor = btnColor
                img.Width = 100
                img.Height = 100
                img.SizeMode = PictureBoxSizeMode.StretchImage
                btn.Width = 100
                btn.Height = 45
                flp.BorderStyle = BorderStyle.FixedSingle
                flp.Width = 107
                flp.Height = 157
                flp.BackColor = btnColor
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel2.Controls.Add(flp)
                flp.Controls.Add(img)
                flp.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnAddMenu_Click
            Loop
            con.Close()
        End If
    End Sub

    Private Sub FillCategory()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT * from Category"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel1.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Flat
            btn.Width = 100
            btn.Height = 50
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.btnCategory_Click
        Loop
        con.Close()
    End Sub

    Private Sub ComputeTotal()
        If dgw.Rows.Count > 0 Then
            Dim totalamt As Double = 0
            Dim totalnoVat As Double = 0
            Try
                For i As Integer = 0 To dgw.Rows.Count - 1
                    totalamt += toNumber(dgw.Rows(i).Cells(14).Value.ToString)
                    totalnoVat += toNumber(dgw.Rows(i).Cells(5).Value.ToString)
                Next
                lblTotal.Text = toMoney(totalamt)
                dblSubTotVat = toMoney(totalnoVat)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            lblTotal.Text = "0.00"
            dblSubTotVat = 0
        End If
    End Sub

    Private Sub ComputeTotalBill()
        If dgwList.Rows.Count > 0 Then
            Dim totalamt As Double = 0
            Dim totalnoVat As Double = 0
            Try
                For i As Integer = 0 To dgwList.Rows.Count - 1
                    totalamt += toNumber(dgwList.Rows(i).Cells(9).Value.ToString)
                    totalnoVat += toNumber(dgwList.Rows(i).Cells(4).Value.ToString)
                Next
                lblTotalBill.Text = toMoney(totalamt)
                dblSubTotVat = toMoney(totalnoVat)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            lblTotalBill.Text = "0.00"
            dblSubTotVat = 0
        End If
    End Sub

    Private Sub ComputeSplitBill()
        If dgw2.Rows.Count > 0 Then
            Dim totalamt As Double = 0
            Dim totalnoVat As Double = 0
            Try
                For i As Integer = 0 To dgw2.Rows.Count - 1
                    totalamt += toNumber(dgw2.Rows(i).Cells(9).Value.ToString)
                    totalnoVat += toNumber(dgw2.Rows(i).Cells(4).Value.ToString)
                Next
                lblSplitTotal.Text = toMoney(totalamt)
                lblTotalBill.Text = toMoney(totalamt)
                dblSubTotVat = toMoney(totalnoVat)
                lblGrandTotal.Text = toMoney(totalamt)
                txtGrandTot.Text = toMoney(totalamt)
                lblSubTotal.Text = dblSubTotVat
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            lblTotalBill.Text = "0.00"
            dblSubtotal = 0
        End If

    End Sub

    Private Sub Data_Load_Kitchen(ByVal kitc As String)
        dtItem = New DataTable
        With dtItem.Columns
            .Add("Itemname", Type.GetType("System.String"))
            .Add("Qty", Type.GetType("System.String"))
            .Add("Notes", Type.GetType("System.String"))
            .Add("Kitchen", Type.GetType("System.String"))
        End With
        If dgw.Rows.Count > 0 Then
            Dim ItemRow As DataRow
            For i As Integer = 0 To dgw.Rows.Count - 1
                If Trim(dgw.Rows(i).Cells(15).Value.ToString) = kitc Then
                    ItemRow = dtItem.NewRow()
                    ItemRow("Itemname") = Trim(dgw.Rows(i).Cells(0).Value.ToString)
                    ItemRow("Qty") = toNumber(dgw.Rows(i).Cells(2).Value.ToString)
                    ItemRow("Notes") = Trim(dgw.Rows(i).Cells(3).Value.ToString)
                    ItemRow("Kitchen") = Trim(dgw.Rows(i).Cells(15).Value.ToString)
                    dtItem.Rows.Add(ItemRow)
                End If
            Next
        End If
    End Sub

    Private Sub Data_Load()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("Itemname", Type.GetType("System.String"))
            .Add("Qty", Type.GetType("System.String"))
            .Add("Price", Type.GetType("System.String"))
            .Add("VatAmt", Type.GetType("System.String"))
            .Add("DiscAmt", Type.GetType("System.String"))
            .Add("SCAmt", Type.GetType("System.String"))
        End With
        If dgw.Rows.Count > 0 Then
            Dim ItemRow As DataRow
            For i As Integer = 0 To dgw.Rows.Count - 1
                ItemRow = dtItem.NewRow()
                ItemRow("Itemname") = dgw.Rows(i).Cells(0).Value.ToString
                ItemRow("Qty") = dgw.Rows(i).Cells(2).Value.ToString
                ItemRow("Price") = dgw.Rows(i).Cells(14).Value.ToString
                ItemRow("VatAmt") = dgw.Rows(i).Cells(7).Value.ToString
                ItemRow("DiscAmt") = dgw.Rows(i).Cells(13).Value.ToString
                ItemRow("SCAmt") = dgw.Rows(i).Cells(11).Value.ToString
                dtItem.Rows.Add(ItemRow)
            Next
        End If

    End Sub

    Private Sub Data_LoadPayment()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("Itemname", Type.GetType("System.String"))
            .Add("Qty", Type.GetType("System.String"))
            .Add("Price", Type.GetType("System.String"))
            .Add("VatAmt", Type.GetType("System.String"))
            .Add("DiscAmt", Type.GetType("System.String"))
            .Add("SCAmt", Type.GetType("System.String"))
        End With
        If dgwList.Rows.Count > 0 Then
            Dim ItemRow As DataRow
            For i As Integer = 0 To dgwList.Rows.Count - 1
                ItemRow = dtItem.NewRow()
                ItemRow("Itemname") = dgwList.Rows(i).Cells(1).Value.ToString
                ItemRow("Qty") = dgwList.Rows(i).Cells(3).Value.ToString
                ItemRow("Price") = dgwList.Rows(i).Cells(2).Value.ToString
                ItemRow("VatAmt") = dgwList.Rows(i).Cells(8).Value.ToString
                ItemRow("DiscAmt") = dgwList.Rows(i).Cells(6).Value.ToString
                ItemRow("SCAmt") = dgwList.Rows(i).Cells(12).Value.ToString
                dtItem.Rows.Add(ItemRow)
            Next
        End If

    End Sub

    Private Sub Data_LoadPaymentSplit()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("Itemname", Type.GetType("System.String"))
            .Add("Qty", Type.GetType("System.String"))
            .Add("Price", Type.GetType("System.String"))
            .Add("VatAmt", Type.GetType("System.String"))
            .Add("DiscAmt", Type.GetType("System.String"))
            .Add("SCAmt", Type.GetType("System.String"))
        End With
        If dgw2.Rows.Count > 0 Then
            Dim ItemRow As DataRow
            For i As Integer = 0 To dgw2.Rows.Count - 1
                ItemRow = dtItem.NewRow()
                ItemRow("Itemname") = dgw2.Rows(i).Cells(1).Value.ToString
                ItemRow("Qty") = dgw2.Rows(i).Cells(3).Value.ToString
                ItemRow("Price") = dgw2.Rows(i).Cells(2).Value.ToString
                ItemRow("VatAmt") = dgw2.Rows(i).Cells(8).Value.ToString
                ItemRow("DiscAmt") = dgw2.Rows(i).Cells(6).Value.ToString
                ItemRow("SCAmt") = dgw2.Rows(i).Cells(12).Value.ToString
                dtItem.Rows.Add(ItemRow)
            Next
        End If

    End Sub


#Region "Button Nav"

    Private Sub btnMenuUp_Click(sender As Object, e As EventArgs) Handles btnMenuUp.Click
        Dim chnge As Integer = FlowLayoutPanel2.VerticalScroll.Value - FlowLayoutPanel2.VerticalScroll.SmallChange * 100
        FlowLayoutPanel2.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnMenuDown_Click(sender As Object, e As EventArgs) Handles btnMenuDown.Click
        Dim chnge As Integer = FlowLayoutPanel2.VerticalScroll.Value + FlowLayoutPanel2.VerticalScroll.SmallChange * 100
        FlowLayoutPanel2.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnCatUp_Click(sender As Object, e As EventArgs) Handles btnCatUp.Click
        Dim chnge As Integer = FlowLayoutPanel1.VerticalScroll.Value - FlowLayoutPanel1.VerticalScroll.SmallChange * 100
        FlowLayoutPanel1.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnCatDown_Click(sender As Object, e As EventArgs) Handles btnCatDown.Click
        Dim chnge As Integer = FlowLayoutPanel1.VerticalScroll.Value + FlowLayoutPanel1.VerticalScroll.SmallChange * 100
        FlowLayoutPanel1.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If dgw.Rows.Count > 0 Then
            Dim totrow As Integer = dgw.Rows.Count - 1
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If rowIndex > 0 Then
                dgw.Rows(rowIndex - 1).Selected = True
            End If

        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If dgw.Rows.Count > 0 Then
            Dim totrow As Integer = dgw.Rows.Count - 1
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If totrow > rowIndex Then
                dgw.Rows(rowIndex + 1).Selected = True
            End If
        End If
    End Sub

#End Region

#Region "Handlers Buttons"

    Private Sub btnDiscounts_CheckedChanged(sender As Object, e As EventArgs)
        Dim btnDisck As Button = DirectCast(sender, Button)
        txtDiscPer.Text = toNumber(btnDisck.Text)
    End Sub

    Private Sub chkBill_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkbill As CheckBox = DirectCast(sender, CheckBox)
        Dim rowcount As Integer = 0
        If chkbill.Checked = True Then
            If Trim(chkbill.Text) <> "" Then
                Try
                    Dim ticketID As Integer = 0
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select ID from RestaurantPOS_OrderInfoKOT WHERE TableNo=@d1 and isPaid=0"
                    cmd = New SqlCommand(sql)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Trim(chkbill.Text))
                    rdr = cmd.ExecuteReader()
                    If tableTag = "" Then
                        tableTag = Trim(chkbill.Text)
                    Else
                        tableTag = tableTag & ";" & Trim(chkbill.Text)
                    End If
                    If rdr.Read Then
                        If Not rdr Is Nothing Then
                            ticketID = toNumber(rdr(0).ToString)
                            rdr.Close()
                            If ticketID > 0 Then
                                Dim sqldet As String = "Select * from view_RestaurantPOS_OrderedProductSplit WHERE TicketID=@d1 AND isPaid=0"
                                cmd = New SqlCommand(sqldet)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", ticketID)
                                rdr = cmd.ExecuteReader()
                                'If ticketTag = "" Then
                                '    ticketTag = ticketID.ToString
                                'Else
                                '    ticketTag = ticketTag & ";" & ticketID.ToString
                                'End If
                                Do While (rdr.Read())
                                    dgwList.Rows.Add(toNumber(rdr(0)), Trim(rdr(2)), toNumber(rdr(3)), toNumber(rdr(4)) - toNumber(rdr(19).ToString), toNumber(rdr(5)), toNumber(rdr(12)), toNumber(rdr(13)), toNumber(rdr(6)), toNumber(rdr(7)), toNumber(rdr(14)), chkbill.Text, toNumber(rdr(10)), toNumber(rdr(11)), toNumber(rdr(8)), toNumber(rdr(9)), toNumber(ticketID), "0")
                                Loop
                            End If
                        End If
                    Else
                        ticketID = 0
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                If dgwList.Rows.Count > 0 Then
                    rowcount = Me.dgwList.RowCount - 1
                    Dim chkval As String
                    With Me.dgwList
                        For i = rowcount To 0 Step -1
                            chkval = .Rows(i).Cells(3).Value
                            If chkval <= 0 Then
                                .Rows.Remove(.Rows(i))
                            End If
                        Next
                    End With
                End If
            End If
        Else
            If dgwList.Rows.Count > 0 Then
                rowcount = Me.dgwList.RowCount - 1
                Dim chkval As String
                With Me.dgwList
                    For i = rowcount To 0 Step -1
                        chkval = .Rows(i).Cells(10).Value
                        If chkval.Contains(chkbill.Text) Then
                            .Rows.Remove(.Rows(i))
                        End If
                    Next
                End With
            End If
        End If
        If dgwList.Rows.Count > 0 Then


            rowcount = Me.dgwList.RowCount - 1
            Dim tckt_last As String = ""
            Dim tckt_first As String = ""
            ticketTag = dgwList.Rows(0).Cells(15).Value
            tckt_first = dgwList.Rows(0).Cells(15).Value
            With Me.dgwList
                For i As Integer = 0 To dgwList.Rows.Count - 1
                    tckt_last = .Rows(i).Cells(15).Value
                    'MsgBox(tckt_first & " " & tckt_last & " = " & ticketTag)
                    If tckt_first = tckt_last Then
                        tckt_first = tckt_last
                    Else
                        If ticketTag = "" Then
                            ticketTag = tckt_last.ToString
                        Else
                            ticketTag = ticketTag & ";" & tckt_last.ToString
                        End If
                        tckt_first = tckt_last
                    End If
                Next
            End With
        Else
            ticketTag = ""
        End If
        'MsgBox(ticketTag)
        Call ComputeTotalBill()
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        txtQty.Text = ""
        Call FillMenus(btn.Text)
        cateTag = btn.Text
    End Sub

    Private Sub btnTables_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If is_edit = True Then
            If MsgBox("Are you sure you want to transfer this to a different table?", vbQuestion + vbYesNo, "Confirm change") = vbYes Then
                'Update function here.
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update RestaurantPOS_OrderInfoKOT set TableNo=@d2 where TicketNo=@d1 and TableNo=@d3"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Trim(txtTicketNo.Text))
                cmd.Parameters.AddWithValue("@d2", btn.Text)
                cmd.Parameters.AddWithValue("@d3", txtTableNo.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                txtTableNo.Text = btn.Text
            Else
                Exit Sub
            End If
        Else
            txtTableNo.Text = btn.Text
        End If

    End Sub

    Private Sub btnAddMenu_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If Trim(txtTicketNo.Text) <> "" Then
            Try
                If cateTag <> "" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "Select * from Dish WHERE DishName=@d1"
                    cmd = New SqlCommand(sql1)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", cateTag)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then

                    End If
                    rdr.Close()
                    con.Close()

                End If

                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select D.DishName, D.Category, D.Rate, D.Discount, D.BackColor, D.Kitchen, C.VAT, C.ST,C.SC from Dish AS D FULL OUTER JOIN Category AS C ON D.Category = C.CategoryName WHERE D.DishName =@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", btn.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    If Not rdr Is Nothing Then
                        Dim rowId As Integer
                        Dim d_qty As Integer = 0
                        If Trim(txtQty.Text) = "" Then
                            d_qty = 1
                        Else
                            d_qty = Val(txtQty.Text)
                        End If
                        If Not IsDBNull(rdr(6)) Then
                            srvVat = toNumber(rdr(6).ToString)
                        End If
                        If Not IsDBNull(rdr(7)) Then
                            srvTax = toNumber(rdr(7).ToString)
                        End If
                        If Not IsDBNull(rdr(8)) Then
                            srvChrge = toNumber(rdr(8).ToString)
                        End If
                        Dim dishrate As Double = toNumber(rdr(2))
                        Dim amt As Double = toNumber(dishrate * d_qty)
                        Dim disc As Double = toNumber(rdr(3)) / 100
                        Dim discamt As Double = toNumber(amt * disc)
                        Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
                        Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
                        Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))
                        Dim newID As Integer = 0
                        Dim totamt As Double = amt + stamt + scamt + vatamat
                        Dim dishname As String = Trim(rdr(0))
                        Dim kitsec As String = Trim(rdr(5))
                        If toNumber(lblID.Text) > 0 And is_edit = True Then
                            con = New SqlConnection(cs)
                            con.Open()

                            Dim cb As String = "insert into RestaurantPOS_OrderedProductKOT(TicketID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,Notes,Kitchen) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                            cmd = New SqlCommand(cb)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                            cmd.Parameters.AddWithValue("@d2", dishname)
                            cmd.Parameters.AddWithValue("@d3", dishrate)
                            cmd.Parameters.AddWithValue("@d4", d_qty)
                            cmd.Parameters.AddWithValue("@d5", toNumber(amt))
                            cmd.Parameters.AddWithValue("@d6", toNumber(srvVat))
                            cmd.Parameters.AddWithValue("@d7", toNumber(vatamat))
                            cmd.Parameters.AddWithValue("@d8", toNumber(srvTax))
                            cmd.Parameters.AddWithValue("@d9", toNumber(stamt))
                            cmd.Parameters.AddWithValue("@d10", toNumber(srvChrge))
                            cmd.Parameters.AddWithValue("@d11", toNumber(scamt))
                            cmd.Parameters.AddWithValue("@d12", toNumber(disc))
                            cmd.Parameters.AddWithValue("@d13", toNumber(discamt))
                            cmd.Parameters.AddWithValue("@d14", toNumber(totamt))
                            cmd.Parameters.AddWithValue("@d15", Trim(""))
                            cmd.Parameters.AddWithValue("@d16", Trim(kitsec))
                            cmd.ExecuteReader()
                            con.Close()
                            Dim st As String = "added the new item '" & Trim(rdr(0)) & "' to ticket no " & Trim(txtTicketNo.Text)
                            LogFunc(lblUser.Text, st)
                            'MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            con = New SqlConnection(cs)
                            con.Open()
                            Dim sql4 As String = "select TOP 1 OP_ID from RestaurantPOS_OrderedProductKOT where TicketID=@d1 AND Dish=@d2 AND Quantity=@d3 ORDER BY OP_ID DESC"
                            cmd = New SqlCommand(sql4)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", lblID.Text)
                            cmd.Parameters.AddWithValue("@d2", dishname)
                            cmd.Parameters.AddWithValue("@d3", d_qty)
                            rdr = cmd.ExecuteReader()
                            If rdr.Read Then
                                newID = toNumber(rdr(0))
                                If Not rdr Is Nothing Then
                                    rdr.Close()
                                End If
                            End If
                            con.Close()

                            con = New SqlConnection(cs)
                            con.Open()

                            Dim cb1 As String = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = GrandTotal + @d2 WHERE ID=@d1"
                            cmd = New SqlCommand(cb1)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                            cmd.Parameters.AddWithValue("@d2", totamt)
                            cmd.ExecuteReader()
                            con.Close()

                            rowId = dgw.Rows.Add(Trim(dishname), Trim(dishrate), d_qty, "", newID, amt, srvVat, vatamat, srvTax, stamt, srvChrge, scamt, disc, discamt, totamt, kitsec)
                            dgw.CurrentCell = dgw.Rows(rowId).Cells(0)
                            dgw.Focus()

                        ElseIf toNumber(lblID.Text) = 0 And is_edit = False Then
                            rowId = dgw.Rows.Add(Trim(dishname), Trim(dishrate), d_qty, "", newID, amt, srvVat, vatamat, srvTax, stamt, srvChrge, scamt, disc, discamt, totamt, kitsec)
                                dgw.CurrentCell = dgw.Rows(rowId).Cells(0)
                                dgw.Focus()
                                btnSave.Enabled = True
                            End If
                        Else
                            rdr.Close()
                        Exit Sub
                    End If
                    Call ComputeTotal()
                End If
                txtQty.Text = ""
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MsgBox("Please click new ticket to create an orders", vbCritical + vbOKOnly, "Error new order")
            Exit Sub
        End If

    End Sub

#End Region

#Region "Button Cliked"

    Private Sub btnDinein_Click(sender As Object, e As EventArgs) Handles btnDinein.Click
        If txtTicketNo.Text <> "" Then
            If is_edit = False Then
                lblTypeID.Text = "1"
                lblType.Text = "Dine-In"
                lblType.ForeColor = Color.SeaGreen
                'btnSave.Enabled = True
                btnSave.Text = "Save + Print"
                'btnUpdate.Enabled = True
                btnChgTable.Enabled = True
            Else
                If toNumber(lblTypeID.Text) = 0 And toNumber(lblID.Text) > 0 Then
                    If MsgBox("Are you sure you want to change this order type to dine-in?", vbQuestion + vbYesNo, "Confirm") = vbYes Then
                        Try
                            lblTypeID.Text = "1"
                            lblType.Text = "Dine-In"
                            lblType.ForeColor = Color.SeaGreen
                            btnSave.Text = "Save + Print"
                            'btnUpdate.Enabled = True
                            btnChgTable.Enabled = True
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb As String = "UPDATE RestaurantPOS_OrderInfoKOT set OrderTypeID=@d1,OrderType=@d2 where ID=@d3"
                            cmd = New SqlCommand(cb)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", lblTypeID.Text)
                            cmd.Parameters.AddWithValue("@d2", lblType.Text)
                            cmd.Parameters.AddWithValue("@d3", lblID.Text)
                            cmd.ExecuteReader()
                            con.Close()
                            Dim st As String = "updated the order '" & lblID.Text & "' to Dine-In"
                            LogFunc(lblUser.Text, st)
                            MessageBox.Show("Successfully updated", "Order type Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                    Else
                        Exit Sub
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub btnTakeout_Click(sender As Object, e As EventArgs) Handles btnTakeout.Click
        If txtTicketNo.Text <> "" Then
            If is_edit = False Then
                lblTypeID.Text = "0"
                lblType.Text = "Take-Out"
                lblType.ForeColor = Color.Crimson
                btnSave.Text = "Settle"
                'btnUpdate.Enabled = False
                btnChgTable.Enabled = False
                txtTableNo.Text = ""
            Else
                If toNumber(lblTypeID.Text) = 1 And toNumber(lblID.Text) > 0 Then
                    If MsgBox("Are you sure you want to change this order type to take-out?", vbQuestion + vbYesNo, "Confirm") = vbYes Then
                        Try
                            lblTypeID.Text = "0"
                            lblType.Text = "Take-Out"
                            lblType.ForeColor = Color.Crimson
                            btnSave.Text = "Settle"
                            'btnUpdate.Enabled = False
                            btnChgTable.Enabled = False
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb As String = "UPDATE RestaurantPOS_OrderInfoKOT set OrderTypeID=@d1,OrderType=@d2 where ID=@d3"
                            cmd = New SqlCommand(cb)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", lblTypeID.Text)
                            cmd.Parameters.AddWithValue("@d2", lblType.Text)
                            cmd.Parameters.AddWithValue("@d3", lblID.Text)
                            cmd.ExecuteReader()
                            con.Close()
                            Dim st As String = "updated the order '" & lblID.Text & "' to Take-out"
                            LogFunc(lblUser.Text, st)
                            MessageBox.Show("Successfully updated", "Order type Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                    Else
                        Exit Sub
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub btnNewTicket_Click(sender As Object, e As EventArgs) Handles btnNewTicket.Click
        If toNumber(lblID.Text) > 0 Then
            If MsgBox("Are you sure to create new ticket.", vbQuestion + vbYesNo, "Confirm create ticket") = vbYes Then
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_OrderInfoKOT"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()

                    If rdr.Read() Then
                        txtTicketNo.Text = Format(rdr(0).ToString + 1, "000000")
                        is_edit = False
                        lblTotal.Text = toMoney("0")
                        lblType.Text = ""
                        lblTypeID.Text = ""
                        txtTableNo.Text = ""
                        lblID.Text = ""
                        txtQty.Text = ""
                        dgw.Rows.Clear()
                        Call FillCategory()
                        btnDinein.PerformClick()
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                        Return
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            Else
                Exit Sub
            End If

        Else
            If Trim(txtTicketNo.Text) <> "" And dgw.Rows.Count > 0 Then
                MsgBox("Save the current ticket transaction or hold to create new ticket.", vbCritical + vbOKOnly, "Error create ticket")
                Exit Sub
            ElseIf Trim(txtTicketNo.Text) = "" And dgw.Rows.Count = 0 Then
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_OrderInfoKOT"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()

                    If rdr.Read() Then
                        txtTicketNo.Text = Format(rdr(0).ToString + 1, "000000")
                        is_edit = False
                        lblTotal.Text = toMoney("0")
                        lblType.Text = ""
                        lblTypeID.Text = ""
                        txtTableNo.Text = ""
                        lblID.Text = ""
                        txtQty.Text = ""
                        dgw.Rows.Clear()
                        Call FillCategory()
                        btnDinein.PerformClick()
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                        Return
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End If
    End Sub

    Private Sub btnOpenTicket_Click(sender As Object, e As EventArgs) Handles btnOpenTicket.Click
        If Trim(txtTicketNo.Text) <> "" And dgw.Rows.Count > 0 And toNumber(lblID.Text) = 0 Then
            MsgBox("Save the current ticket transaction or hold to open a ticket.", vbCritical + vbOKOnly, "Error open ticket")
            Exit Sub
        Else
            With frmOpenTicketList
                .frm = "frmPOS"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If is_edit = True Then
            txtQty.Text = ""
            txtTableNo.Text = ""
            txtTicketNo.Text = ""
            lblType.Text = ""
            lblTypeID.Text = ""
            lblID.Text = ""
            lblIDRecall.Text = ""
            lblTotal.Text = ""
            lblPayID.Text = ""
            lblTotalBill.Text = ""
            lblGrandTotal.Text = ""
            txtPaymentMode.Text = ""
            txtBillNo.Text = ""
            ticketTag = ""
            tableTag = ""
            cateTag = ""
            splitTag = False
            dgw.Rows.Clear()
            is_edit = False
            FlowLayoutPanel1.Controls.Clear()
            FlowLayoutPanel2.Controls.Clear()
            FlowLayoutPanel3.Controls.Clear()
            btnSave.Enabled = False
        Else
            If lblID.Text <> "" Or Trim(txtTicketNo.Text) <> "" Then
                If MsgBox("Are you sure you want to cancel this order?", vbQuestion + vbYesNo, "Confirmation") = vbYes Then
                    txtQty.Text = ""
                    txtTableNo.Text = ""
                    txtTicketNo.Text = ""
                    lblType.Text = ""
                    lblTypeID.Text = ""
                    lblID.Text = ""
                    lblIDRecall.Text = ""
                    lblTotal.Text = ""
                    lblTotalBill.Text = ""
                    lblGrandTotal.Text = ""
                    lblPayID.Text = ""
                    dgw.Rows.Clear()
                    is_edit = False
                    FlowLayoutPanel1.Controls.Clear()
                    FlowLayoutPanel2.Controls.Clear()
                    FlowLayoutPanel3.Controls.Clear()
                    btnSave.Enabled = False
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgw.Rows.Count > 0 Then
            srvVat = dgw.SelectedCells.Item(6).Value
            srvTax = dgw.SelectedCells.Item(8).Value
            srvChrge = dgw.SelectedCells.Item(10).Value
            Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
            Dim dishamt As Double = toNumber(dgw.SelectedCells.Item(1).Value)
            Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value) + 1
            Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
            Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
            Dim discrate As Double = toNumber(dgw.SelectedCells.Item(12).Value)
            Dim discamt As Double = toNumber(amt * disc)
            Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
            Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
            Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))
            Dim notes As String = Trim(dgw.SelectedCells.Item(3).Value)
            Dim totamt As Double = amt + stamt + scamt + vatamat
            dgw.SelectedCells.Item(2).Value = toNumber(d_qty)
            dgw.SelectedCells.Item(5).Value = toNumber(amt)
            dgw.SelectedCells.Item(6).Value = toNumber(srvVat)
            dgw.SelectedCells.Item(7).Value = toNumber(vatamat)
            dgw.SelectedCells.Item(8).Value = toNumber(srvTax)
            dgw.SelectedCells.Item(9).Value = toNumber(stamt)
            dgw.SelectedCells.Item(10).Value = toNumber(srvChrge)
            dgw.SelectedCells.Item(11).Value = toNumber(scamt)
            dgw.SelectedCells.Item(12).Value = toNumber(discrate)
            dgw.SelectedCells.Item(13).Value = toNumber(discamt)
            dgw.SelectedCells.Item(14).Value = toNumber(totamt)
            Call ComputeTotal()

            If toNumber(lblID.Text) > 0 Or toNumber(lblIDRecall.Text) > 0 Then
                'Update value qty here
                Try
                    Dim cb As String = ""
                    con = New SqlConnection(cs)
                    con.Open()
                    If toNumber(lblIDRecall.Text) > 0 Then
                        cb = "UPDATE TempRestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                    Else
                        cb = "UPDATE RestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                    End If
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", dishamt)
                    cmd.Parameters.AddWithValue("@d2", d_qty)
                    cmd.Parameters.AddWithValue("@d3", amt)
                    cmd.Parameters.AddWithValue("@d4", srvVat)
                    cmd.Parameters.AddWithValue("@d5", vatamat)
                    cmd.Parameters.AddWithValue("@d6", srvTax)
                    cmd.Parameters.AddWithValue("@d7", stamt)
                    cmd.Parameters.AddWithValue("@d8", srvChrge)
                    cmd.Parameters.AddWithValue("@d9", scamt)
                    cmd.Parameters.AddWithValue("@d10", discrate)
                    cmd.Parameters.AddWithValue("@d11", discamt)
                    cmd.Parameters.AddWithValue("@d12", totamt)
                    cmd.Parameters.AddWithValue("@d13", notes)
                    If toNumber(lblIDRecall.Text) > 0 Then
                        cmd.Parameters.AddWithValue("@d14", toNumber(lblIDRecall.Text))
                    Else
                        cmd.Parameters.AddWithValue("@d14", toNumber(lblID.Text))
                    End If
                    cmd.Parameters.AddWithValue("@d15", OP_ID)
                    cmd.ExecuteReader()
                    con.Close()
                    Dim st As String = "updated the item '" & dgw.SelectedCells.Item(0).Value & "' add quantity"
                    LogFunc(lblUser.Text, st)
                    'MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb1 As String = ""
                    If toNumber(lblIDRecall.Text) > 0 Then
                        cb1 = "UPDATE TempRestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                    Else
                        cb1 = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                    End If
                    cmd = New SqlCommand(cb1)
                    cmd.Connection = con
                    If toNumber(lblIDRecall.Text) > 0 Then
                        cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                    Else
                        cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                    End If
                    cmd.Parameters.AddWithValue("@d2", toNumber(lblTotal.Text))
                    cmd.ExecuteReader()
                    con.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End If
    End Sub

    Private Sub btnLess_Click(sender As Object, e As EventArgs) Handles btnLess.Click
        If dgw.Rows.Count > 0 Then
            If Val(dgw.SelectedCells.Item(2).Value) > 1 Then
                srvVat = dgw.SelectedCells.Item(6).Value
                srvTax = dgw.SelectedCells.Item(8).Value
                srvChrge = dgw.SelectedCells.Item(10).Value
                Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
                Dim dishamt As Double = toNumber(dgw.SelectedCells.Item(1).Value)
                Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value) - 1
                Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
                Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
                Dim discrate As Double = toNumber(dgw.SelectedCells.Item(12).Value)
                Dim discamt As Double = toNumber(amt * disc)
                Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
                Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
                Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))
                Dim notes As String = Trim(dgw.SelectedCells.Item(3).Value)
                Dim totamt As Double = amt + stamt + scamt + vatamat
                dgw.SelectedCells.Item(2).Value = toNumber(d_qty)
                dgw.SelectedCells.Item(5).Value = toNumber(amt)
                dgw.SelectedCells.Item(6).Value = toNumber(srvVat)
                dgw.SelectedCells.Item(7).Value = toNumber(vatamat)
                dgw.SelectedCells.Item(8).Value = toNumber(srvTax)
                dgw.SelectedCells.Item(9).Value = toNumber(stamt)
                dgw.SelectedCells.Item(10).Value = toNumber(srvChrge)
                dgw.SelectedCells.Item(11).Value = toNumber(scamt)
                dgw.SelectedCells.Item(12).Value = toNumber(disc)
                dgw.SelectedCells.Item(13).Value = toNumber(discamt)
                dgw.SelectedCells.Item(14).Value = toNumber(totamt)
                Call ComputeTotal()

                If toNumber(lblID.Text) > 0 Or toNumber(lblIDRecall.Text) > 0 Then
                    'Update value qty here
                    Try
                        Dim cb As String = ""
                        con = New SqlConnection(cs)
                        con.Open()
                        If toNumber(lblIDRecall.Text) > 0 Then
                            cb = "UPDATE TempRestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                        Else
                            cb = "UPDATE RestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                        End If
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", dishamt)
                        cmd.Parameters.AddWithValue("@d2", d_qty)
                        cmd.Parameters.AddWithValue("@d3", amt)
                        cmd.Parameters.AddWithValue("@d4", srvVat)
                        cmd.Parameters.AddWithValue("@d5", vatamat)
                        cmd.Parameters.AddWithValue("@d6", srvTax)
                        cmd.Parameters.AddWithValue("@d7", stamt)
                        cmd.Parameters.AddWithValue("@d8", srvChrge)
                        cmd.Parameters.AddWithValue("@d9", scamt)
                        cmd.Parameters.AddWithValue("@d10", discrate)
                        cmd.Parameters.AddWithValue("@d11", discamt)
                        cmd.Parameters.AddWithValue("@d12", totamt)
                        cmd.Parameters.AddWithValue("@d13", notes)
                        cmd.Parameters.AddWithValue("@d14", toNumber(lblID.Text))
                        cmd.Parameters.AddWithValue("@d15", OP_ID)
                        cmd.ExecuteReader()
                        con.Close()
                        Dim st As String = "updated the item '" & dgw.SelectedCells.Item(0).Value & "' less quantity"
                        LogFunc(lblUser.Text, st)
                        'MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        con = New SqlConnection(cs)
                        con.Open()

                        Dim cb1 As String = ""
                        If toNumber(lblIDRecall.Text) > 0 Then
                            cb1 = "UPDATE TempRestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                        Else
                            cb1 = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                        End If
                        cmd = New SqlCommand(cb1)
                        cmd.Connection = con
                        If toNumber(lblIDRecall.Text) > 0 Then
                            cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                        Else
                            cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                        End If
                        cmd.Parameters.AddWithValue("@d2", toNumber(lblTotal.Text))
                        cmd.ExecuteReader()
                        con.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                End If

            End If

        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If is_edit = True And toNumber(lblID.Text) > 0 Then
                If MsgBox("Are you sure you want to remove this item in current order?", vbQuestion + vbYesNo, "Confirm remove") = vbYes Then
                    'Update value qty here
                    Dim RowsAffected As Integer = 0
                    Dim op_id As Integer = toNumber(dgw.SelectedCells(4).Value.ToString)
                    Dim itemname As String = Trim(dgw.SelectedCells(0).Value.ToString)
                    Dim totamt1 As Double = toNumber(dgw.SelectedCells(14).Value.ToString)

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb1 As String = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = GrandTotal - @d2 WHERE ID=@d1"
                    cmd = New SqlCommand(cb1)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d2", totamt1)
                    cmd.ExecuteReader()
                    con.Close()

                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cq As String = "delete from RestaurantPOS_OrderedProductKOT where OP_ID=@d1 AND TicketID=@d2"
                    cmd = New SqlCommand(cq)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", op_id)
                    cmd.Parameters.AddWithValue("@d2", toNumber(lblID.Text))
                    RowsAffected = cmd.ExecuteNonQuery()
                    If RowsAffected > 0 Then
                        Dim st As String = "deleted the item '" & itemname & "' in ticket " & txtTicketNo.Text
                        LogFunc(lblUser.Text, st)
                        'MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgw.Rows.RemoveAt(rowIndex)
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                Else
                    Exit Sub
                End If
            Else
                dgw.Rows.RemoveAt(rowIndex)
            End If
            Call ComputeTotal()
        End If
    End Sub

    Private Sub btnNotes_Click(sender As Object, e As EventArgs) Handles btnNotes.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmNotes1
                .frm = "frmPOS"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
            Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
            Dim notes As String = Trim(dgw.SelectedCells.Item(3).Value)
            If toNumber(lblID.Text) > 0 And is_edit = True Then
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "UPDATE RestaurantPOS_OrderedProductKOT set Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d13", notes)
                    cmd.Parameters.AddWithValue("@d14", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d15", OP_ID)
                    cmd.ExecuteReader()
                    con.Close()
                    Dim st As String = "updated the notes item '" & dgw.SelectedCells.Item(0).Value & "'"
                    LogFunc(lblUser.Text, st)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End If
    End Sub

    Private Sub btnChgRate_Click(sender As Object, e As EventArgs) Handles btnChgRate.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmCustomDialog13
                .frm = "frmPOS"
                .Label2.Text = "Enter New Amount"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
            Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
            Dim dishamt As Double = toNumber(dgw.SelectedCells.Item(1).Value)
            Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value)
            Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
            Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
            Dim discrate As Double = toNumber(dgw.SelectedCells.Item(12).Value)
            Dim discamt As Double = toNumber(amt * disc)
            Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
            Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
            Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))
            Dim notes As String = Trim(dgw.SelectedCells.Item(3).Value)
            Dim totamt As Double = amt + stamt + scamt + vatamat
            dgw.SelectedCells.Item(2).Value = toNumber(d_qty)
            dgw.SelectedCells.Item(5).Value = toNumber(amt)
            dgw.SelectedCells.Item(6).Value = toNumber(srvVat)
            dgw.SelectedCells.Item(7).Value = toNumber(vatamat)
            dgw.SelectedCells.Item(8).Value = toNumber(srvTax)
            dgw.SelectedCells.Item(9).Value = toNumber(stamt)
            dgw.SelectedCells.Item(10).Value = toNumber(srvChrge)
            dgw.SelectedCells.Item(11).Value = toNumber(scamt)
            dgw.SelectedCells.Item(12).Value = toNumber(disc)
            dgw.SelectedCells.Item(13).Value = toNumber(discamt)
            dgw.SelectedCells.Item(14).Value = toNumber(totamt)
            Call ComputeTotal()
            If toNumber(lblID.Text) > 0 And is_edit = True Then
                'Update value qty here
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "UPDATE RestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", dishamt)
                    cmd.Parameters.AddWithValue("@d2", d_qty)
                    cmd.Parameters.AddWithValue("@d3", amt)
                    cmd.Parameters.AddWithValue("@d4", srvVat)
                    cmd.Parameters.AddWithValue("@d5", vatamat)
                    cmd.Parameters.AddWithValue("@d6", srvTax)
                    cmd.Parameters.AddWithValue("@d7", stamt)
                    cmd.Parameters.AddWithValue("@d8", srvChrge)
                    cmd.Parameters.AddWithValue("@d9", scamt)
                    cmd.Parameters.AddWithValue("@d10", discrate)
                    cmd.Parameters.AddWithValue("@d11", discamt)
                    cmd.Parameters.AddWithValue("@d12", totamt)
                    cmd.Parameters.AddWithValue("@d13", notes)
                    cmd.Parameters.AddWithValue("@d14", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d15", OP_ID)
                    cmd.ExecuteReader()
                    con.Close()
                    Dim st As String = "updated the rate item '" & dgw.SelectedCells.Item(0).Value & "'"
                    LogFunc(lblUser.Text, st)
                    'MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb1 As String = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                    cmd = New SqlCommand(cb1)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d2", toNumber(lblTotal.Text))
                    cmd.ExecuteReader()
                    con.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End If
    End Sub

    Private Sub btnChgQty_Click(sender As Object, e As EventArgs) Handles btnChgQty.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmCustomDialog13
                .frm = "frmPOS1"
                .Label2.Text = "Enter New Quantity"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
            Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
            Dim dishamt As Double = toNumber(dgw.SelectedCells.Item(1).Value)
            Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value)
            Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
            Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
            Dim discrate As Double = toNumber(dgw.SelectedCells.Item(12).Value)
            Dim discamt As Double = toNumber(amt * disc)
            Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
            Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
            Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))
            Dim notes As String = Trim(dgw.SelectedCells.Item(3).Value)
            Dim totamt As Double = amt + stamt + scamt + vatamat
            dgw.SelectedCells.Item(2).Value = toNumber(d_qty)
            dgw.SelectedCells.Item(5).Value = toNumber(amt)
            dgw.SelectedCells.Item(6).Value = toNumber(srvVat)
            dgw.SelectedCells.Item(7).Value = toNumber(vatamat)
            dgw.SelectedCells.Item(8).Value = toNumber(srvTax)
            dgw.SelectedCells.Item(9).Value = toNumber(stamt)
            dgw.SelectedCells.Item(10).Value = toNumber(srvChrge)
            dgw.SelectedCells.Item(11).Value = toNumber(scamt)
            dgw.SelectedCells.Item(12).Value = toNumber(disc)
            dgw.SelectedCells.Item(13).Value = toNumber(discamt)
            dgw.SelectedCells.Item(14).Value = toNumber(totamt)
            Call ComputeTotal()
            If toNumber(lblID.Text) > 0 And is_edit = True Then
                'Update value qty here
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "UPDATE RestaurantPOS_OrderedProductKOT set Rate=@d1,Quantity=@d2,Amount=@d3,VATPer=@d4,VATAmount=@d5,STPer=@d6,STAmount=@d7,SCPer=@d8,SCAmount=@d9,DiscountPer=@d10,DiscountAmount=@d11,TotalAmount=@d12,Notes=@d13 WHERE TicketID=@d14 AND OP_ID=@d15"
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", dishamt)
                    cmd.Parameters.AddWithValue("@d2", d_qty)
                    cmd.Parameters.AddWithValue("@d3", amt)
                    cmd.Parameters.AddWithValue("@d4", srvVat)
                    cmd.Parameters.AddWithValue("@d5", vatamat)
                    cmd.Parameters.AddWithValue("@d6", srvTax)
                    cmd.Parameters.AddWithValue("@d7", stamt)
                    cmd.Parameters.AddWithValue("@d8", srvChrge)
                    cmd.Parameters.AddWithValue("@d9", scamt)
                    cmd.Parameters.AddWithValue("@d10", discrate)
                    cmd.Parameters.AddWithValue("@d11", discamt)
                    cmd.Parameters.AddWithValue("@d12", totamt)
                    cmd.Parameters.AddWithValue("@d13", notes)
                    cmd.Parameters.AddWithValue("@d14", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d15", OP_ID)
                    cmd.ExecuteReader()
                    con.Close()
                    Dim st As String = "updated the quantity item '" & dgw.SelectedCells.Item(0).Value & "'"
                    LogFunc(lblUser.Text, st)
                    'MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    con = New SqlConnection(cs)
                    con.Open()

                    Dim cb1 As String = "UPDATE RestaurantPOS_OrderInfoKOT SET GrandTotal = @d2 WHERE ID=@d1"
                    cmd = New SqlCommand(cb1)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                    cmd.Parameters.AddWithValue("@d2", toNumber(lblTotal.Text))
                    cmd.ExecuteReader()
                    con.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End If
    End Sub

    Private Sub btnChgTable_Click(sender As Object, e As EventArgs) Handles btnChgTable.Click
        With frmTablesList
            .frm = "frmPOS"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        If is_edit = False Then
            If txtTicketNo.Text <> "" Then
                If txtTableNo.Text <> "" Then
                    If dgw.Rows.Count > 0 Then
                        If MsgBox("Are you sure you want to temporary hold this order list?", vbQuestion + vbYesNo, "Confirm hold") = vbYes Then
                            If toNumber(lblIDRecall.Text) > 0 Then
                                'Update function
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim cb As String = "Update TempRestaurantPOS_OrderInfoKOT SET TicketNo=@d1,BillDate=@d2,GrandTotal=@d3,TableNo=@d4,Operator=@d5,GroupName=@d6,TicketNote=@d7,OrderType=@d8,OrderTypeID=@d9,isPaid=@d10 WHERE ID=@d11"
                                    cmd = New SqlCommand(cb)
                                    cmd.Connection = con
                                    cmd.Parameters.AddWithValue("@d1", Trim(txtTicketNo.Text))
                                    cmd.Parameters.AddWithValue("@d2", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                                    cmd.Parameters.AddWithValue("@d3", toNumber(lblTotal.Text))
                                    cmd.Parameters.AddWithValue("@d4", Trim(txtTableNo.Text))
                                    cmd.Parameters.AddWithValue("@d5", Trim(lblUser.Text))
                                    cmd.Parameters.AddWithValue("@d6", "")
                                    cmd.Parameters.AddWithValue("@d7", "")
                                    cmd.Parameters.AddWithValue("@d8", Trim(lblType.Text))
                                    cmd.Parameters.AddWithValue("@d9", toNumber(lblTypeID.Text))
                                    cmd.Parameters.AddWithValue("@d10", toNumber("0"))
                                    cmd.Parameters.AddWithValue("@d11", toNumber(lblIDRecall.Text))
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    Dim st As String = "Update Hold order of '" & txtTicketNo.Text & "' with TableNo " & txtTableNo.Text
                                    LogFunc(lblUser.Text, st)
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                    Exit Sub
                                End Try
                                For i As Integer = 0 To dgw.Rows.Count - 1
                                    Dim OP_ID As Integer = toNumber(dgw.Rows(i).Cells(4).Value.ToString)
                                    If OP_ID > 0 Then
                                        'Update Tran
                                        Try
                                            con = New SqlConnection(cs)
                                            con.Open()
                                            Dim cb As String = "UPDATE TempRestaurantPOS_OrderedProductKOT SET TicketID=@d1,Dish=@d2,Rate=@d3,Quantity=@d4,Amount=@d5,VATPer=@d6,VATAmount=@d7,STPer=@d8,STAmount=@d9,SCPer=@d10,SCAmount=@d11,DiscountPer=@d12,DiscountAmount=@d13,TotalAmount=@d14,Notes=@d15,Kitchen=@d16 WHERE OP_ID=@d17"
                                            cmd = New SqlCommand(cb)
                                            cmd.Connection = con
                                            cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                                            cmd.Parameters.AddWithValue("@d2", dgw.Rows(i).Cells(0).Value.ToString)
                                            cmd.Parameters.AddWithValue("@d3", toNumber(dgw.Rows(i).Cells(1).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d4", toNumber(dgw.Rows(i).Cells(2).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d5", toNumber(dgw.Rows(i).Cells(5).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d6", toNumber(dgw.Rows(i).Cells(6).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d7", toNumber(dgw.Rows(i).Cells(7).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d8", toNumber(dgw.Rows(i).Cells(8).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d9", toNumber(dgw.Rows(i).Cells(9).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d10", toNumber(dgw.Rows(i).Cells(10).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d11", toNumber(dgw.Rows(i).Cells(11).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d12", toNumber(dgw.Rows(i).Cells(12).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d13", toNumber(dgw.Rows(i).Cells(13).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d14", toNumber(dgw.Rows(i).Cells(14).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d15", dgw.Rows(i).Cells(3).Value.ToString)
                                            cmd.Parameters.AddWithValue("@d16", dgw.Rows(i).Cells(15).Value.ToString)
                                            cmd.Parameters.AddWithValue("@d17", toNumber(OP_ID))
                                            cmd.ExecuteNonQuery()
                                        Catch ex As Exception
                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                            Exit Sub
                                        End Try
                                    Else
                                        'Add Tran
                                        Try
                                            con = New SqlConnection(cs)
                                            con.Open()
                                            Dim cb As String = "insert into TempRestaurantPOS_OrderedProductKOT (TicketID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,Notes,Kitchen) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                                            cmd = New SqlCommand(cb)
                                            cmd.Connection = con
                                            cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                                            cmd.Parameters.AddWithValue("@d2", dgw.Rows(i).Cells(0).Value.ToString)
                                            cmd.Parameters.AddWithValue("@d3", toNumber(dgw.Rows(i).Cells(1).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d4", toNumber(dgw.Rows(i).Cells(2).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d5", toNumber(dgw.Rows(i).Cells(5).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d6", toNumber(dgw.Rows(i).Cells(6).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d7", toNumber(dgw.Rows(i).Cells(7).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d8", toNumber(dgw.Rows(i).Cells(8).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d9", toNumber(dgw.Rows(i).Cells(9).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d10", toNumber(dgw.Rows(i).Cells(10).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d11", toNumber(dgw.Rows(i).Cells(11).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d12", toNumber(dgw.Rows(i).Cells(12).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d13", toNumber(dgw.Rows(i).Cells(13).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d14", toNumber(dgw.Rows(i).Cells(14).Value.ToString))
                                            cmd.Parameters.AddWithValue("@d15", dgw.Rows(i).Cells(3).Value.ToString)
                                            cmd.Parameters.AddWithValue("@d16", dgw.Rows(i).Cells(15).Value.ToString)
                                            cmd.ExecuteNonQuery()
                                        Catch ex As Exception
                                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                            Exit Sub
                                        End Try
                                    End If
                                Next
                                txtQty.Text = ""
                                txtTableNo.Text = ""
                                txtTicketNo.Text = ""
                                lblType.Text = ""
                                lblTypeID.Text = ""
                                lblID.Text = ""
                                lblTotal.Text = ""
                                lblTotalBill.Text = ""
                                lblGrandTotal.Text = ""
                                lblPayID.Text = ""
                                dgw.Rows.Clear()
                                is_edit = False
                                FlowLayoutPanel1.Controls.Clear()
                                FlowLayoutPanel2.Controls.Clear()
                                FlowLayoutPanel3.Controls.Clear()
                                btnSave.Enabled = False
                            Else
                                'Insert function
                                Dim newID As Integer = 0
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim ct As String = "select MAX(ID) AS ID from TempRestaurantPOS_OrderInfoKOT"
                                    cmd = New SqlCommand(ct)
                                    cmd.Connection = con
                                    rdr = cmd.ExecuteReader()
                                    If rdr.Read() Then
                                        txtTicketNo.Text = Format(toNumber(rdr(0).ToString) + 1, "000000")
                                        If (rdr IsNot Nothing) Then
                                            rdr.Close()
                                        End If
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                    Exit Sub
                                End Try
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim cb As String = "insert into TempRestaurantPOS_OrderInfoKOT (TicketNo,BillDate,GrandTotal,TableNo,Operator,GroupName,TicketNote,OrderType,OrderTypeID,isPaid) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)"
                                    cmd = New SqlCommand(cb)
                                    cmd.Connection = con
                                    cmd.Parameters.AddWithValue("@d1", Trim(txtTicketNo.Text))
                                    cmd.Parameters.AddWithValue("@d2", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                                    cmd.Parameters.AddWithValue("@d3", toNumber(lblTotal.Text))
                                    cmd.Parameters.AddWithValue("@d4", Trim(txtTableNo.Text))
                                    cmd.Parameters.AddWithValue("@d5", Trim(lblUser.Text))
                                    cmd.Parameters.AddWithValue("@d6", "")
                                    cmd.Parameters.AddWithValue("@d7", "")
                                    cmd.Parameters.AddWithValue("@d8", Trim(lblType.Text))
                                    cmd.Parameters.AddWithValue("@d9", toNumber(lblTypeID.Text))
                                    cmd.Parameters.AddWithValue("@d10", toNumber("0"))
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    Dim st As String = "Hold order of '" & txtTicketNo.Text & "' with TableNo " & txtTableNo.Text
                                    LogFunc(lblUser.Text, st)
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                    Exit Sub
                                End Try
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim ct As String = "select MAX(ID) AS ID from TempRestaurantPOS_OrderInfoKOT "
                                    cmd = New SqlCommand(ct)
                                    cmd.Connection = con
                                    rdr = cmd.ExecuteReader()
                                    If rdr.Read() Then
                                        newID = toNumber(rdr(0).ToString)
                                        If (rdr IsNot Nothing) Then
                                            rdr.Close()
                                        End If
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                    Exit Sub
                                End Try
                                For i As Integer = 0 To dgw.Rows.Count - 1
                                    Try
                                        con = New SqlConnection(cs)
                                        con.Open()
                                        Dim cb As String = "insert into TempRestaurantPOS_OrderedProductKOT (TicketID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,Notes,Kitchen) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                                        cmd = New SqlCommand(cb)
                                        cmd.Connection = con
                                        cmd.Parameters.AddWithValue("@d1", toNumber(newID))
                                        cmd.Parameters.AddWithValue("@d2", dgw.Rows(i).Cells(0).Value.ToString)
                                        cmd.Parameters.AddWithValue("@d3", toNumber(dgw.Rows(i).Cells(1).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d4", toNumber(dgw.Rows(i).Cells(2).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d5", toNumber(dgw.Rows(i).Cells(5).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d6", toNumber(dgw.Rows(i).Cells(6).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d7", toNumber(dgw.Rows(i).Cells(7).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d8", toNumber(dgw.Rows(i).Cells(8).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d9", toNumber(dgw.Rows(i).Cells(9).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d10", toNumber(dgw.Rows(i).Cells(10).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d11", toNumber(dgw.Rows(i).Cells(11).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d12", toNumber(dgw.Rows(i).Cells(12).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d13", toNumber(dgw.Rows(i).Cells(13).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d14", toNumber(dgw.Rows(i).Cells(14).Value.ToString))
                                        cmd.Parameters.AddWithValue("@d15", dgw.Rows(i).Cells(3).Value.ToString)
                                        cmd.Parameters.AddWithValue("@d16", dgw.Rows(i).Cells(15).Value.ToString)
                                        cmd.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                        Exit Sub
                                    End Try
                                Next
                                txtQty.Text = ""
                                txtTableNo.Text = ""
                                txtTicketNo.Text = ""
                                lblType.Text = ""
                                lblTypeID.Text = ""
                                lblID.Text = ""
                                lblTotal.Text = ""
                                lblTotalBill.Text = ""
                                lblGrandTotal.Text = ""
                                lblPayID.Text = ""
                                dgw.Rows.Clear()
                                is_edit = False
                                FlowLayoutPanel1.Controls.Clear()
                                FlowLayoutPanel2.Controls.Clear()
                                FlowLayoutPanel3.Controls.Clear()
                                btnSave.Enabled = False
                            End If

                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Please select table no to hold the orders", vbInformation + vbOKOnly, "Error hold")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub btnRecall_Click(sender As Object, e As EventArgs) Handles btnRecall.Click
        If toNumber(lblID.Text) > 0 Then

        Else
            If Trim(txtTicketNo.Text) <> "" And dgw.Rows.Count > 0 Then
                MsgBox("Save the current ticket transaction or hold to recall hold ticket.", vbCritical + vbOKOnly, "Error recall ticket")
                Exit Sub
            ElseIf Trim(txtTicketNo.Text) = "" And dgw.Rows.Count = 0 Then
                With frmRecallTicketList
                    .frm = "frmPOS"
                    .ShowDialog()
                End With
            End If
        End If
    End Sub

#End Region

#Region "Number Buttons"

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtQty.Text = txtQty.Text + Convert.ToString(0)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtQty.Text = txtQty.Text + Convert.ToString(1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtQty.Text = txtQty.Text + Convert.ToString(2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtQty.Text = txtQty.Text + Convert.ToString(3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtQty.Text = txtQty.Text + Convert.ToString(4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtQty.Text = txtQty.Text + Convert.ToString(5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtQty.Text = txtQty.Text + Convert.ToString(6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtQty.Text = txtQty.Text + Convert.ToString(7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtQty.Text = txtQty.Text + Convert.ToString(8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtQty.Text = txtQty.Text + Convert.ToString(9)
    End Sub

    Private Sub btnP1_Click(sender As Object, e As EventArgs) Handles btnP1.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(1)
        End If
    End Sub

    Private Sub btnP2_Click(sender As Object, e As EventArgs) Handles btnP2.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(2)
        End If
    End Sub

    Private Sub btnP3_Click(sender As Object, e As EventArgs) Handles btnP3.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(3)
        End If
    End Sub

    Private Sub btnP4_Click(sender As Object, e As EventArgs) Handles btnP4.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(4)
        End If
    End Sub

    Private Sub btnP5_Click(sender As Object, e As EventArgs) Handles btnP5.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(5)
        End If
    End Sub

    Private Sub btnP6_Click(sender As Object, e As EventArgs) Handles btnP6.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(6)
        End If
    End Sub

    Private Sub btnP7_Click(sender As Object, e As EventArgs) Handles btnP7.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(7)
        End If
    End Sub

    Private Sub btnP8_Click(sender As Object, e As EventArgs) Handles btnP8.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(8)
        End If
    End Sub

    Private Sub btnP9_Click(sender As Object, e As EventArgs) Handles btnP9.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(9)
        End If
    End Sub

    Private Sub btnP0_Click(sender As Object, e As EventArgs) Handles btnP0.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(0)
        End If
    End Sub

    Private Sub btnPX_Click(sender As Object, e As EventArgs) Handles btnPX.Click
        s = FocusText.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        FocusText.Text = x
        x = ""
    End Sub

    Private Sub btnPDot_Click(sender As Object, e As EventArgs) Handles btnPDot.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(".")
        End If
    End Sub

#End Region

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dgw.Rows.Count > 0 Then
            Dim RowsAffected As Integer = 0
            If toNumber(lblTypeID.Text) > 0 Then
                'Dine In
                If Trim(txtTableNo.Text) = "" Then
                    MsgBox("Please select table to save this order list.", vbInformation + vbOKOnly, "Error table no")
                    Exit Sub
                ElseIf Trim(txtTicketNo.Text) = "" Then
                    MsgBox("Please create new ticket to save this order list.", vbInformation + vbOKOnly, "Error ticket no")
                    Exit Sub
                Else
                    If is_edit = False And toNumber(lblID.Text) = 0 Then
                        'New save order
                        Dim newID As Integer = 0
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_OrderInfoKOT"
                            cmd = New SqlCommand(ct)
                            cmd.Connection = con
                            rdr = cmd.ExecuteReader()
                            If rdr.Read() Then
                                txtTicketNo.Text = Format(toNumber(rdr(0).ToString) + 1, "000000")
                                If (rdr IsNot Nothing) Then
                                    rdr.Close()
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb As String = "insert into RestaurantPOS_OrderInfoKOT (TicketNo,BillDate,GrandTotal,TableNo,Operator,GroupName,TicketNote,OrderType,OrderTypeID,isPaid) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)"
                            cmd = New SqlCommand(cb)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", Trim(txtTicketNo.Text))
                            cmd.Parameters.AddWithValue("@d2", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                            cmd.Parameters.AddWithValue("@d3", toNumber(lblTotal.Text))
                            cmd.Parameters.AddWithValue("@d4", Trim(txtTableNo.Text))
                            cmd.Parameters.AddWithValue("@d5", Trim(lblUser.Text))
                            cmd.Parameters.AddWithValue("@d6", "")
                            cmd.Parameters.AddWithValue("@d7", "")
                            cmd.Parameters.AddWithValue("@d8", Trim(lblType.Text))
                            cmd.Parameters.AddWithValue("@d9", toNumber(lblTypeID.Text))
                            cmd.Parameters.AddWithValue("@d10", toNumber("0"))
                            cmd.ExecuteNonQuery()
                            con.Close()
                            Dim st As String = "Save new order of '" & txtTicketNo.Text & "' with TableNo " & txtTableNo.Text
                            LogFunc(lblUser.Text, st)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_OrderInfoKOT "
                            cmd = New SqlCommand(ct)
                            cmd.Connection = con
                            rdr = cmd.ExecuteReader()
                            If rdr.Read() Then
                                newID = toNumber(rdr(0).ToString)
                                If (rdr IsNot Nothing) Then
                                    rdr.Close()
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                        For i As Integer = 0 To dgw.Rows.Count - 1
                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb As String = "insert into RestaurantPOS_OrderedProductKOT (TicketID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,Notes,Kitchen,isPaid) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
                                cmd = New SqlCommand(cb)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", toNumber(newID))
                                cmd.Parameters.AddWithValue("@d2", dgw.Rows(i).Cells(0).Value.ToString)
                                cmd.Parameters.AddWithValue("@d3", dgw.Rows(i).Cells(1).Value.ToString)
                                cmd.Parameters.AddWithValue("@d4", dgw.Rows(i).Cells(2).Value.ToString)
                                cmd.Parameters.AddWithValue("@d5", dgw.Rows(i).Cells(5).Value.ToString)
                                cmd.Parameters.AddWithValue("@d6", dgw.Rows(i).Cells(6).Value.ToString)
                                cmd.Parameters.AddWithValue("@d7", dgw.Rows(i).Cells(7).Value.ToString)
                                cmd.Parameters.AddWithValue("@d8", dgw.Rows(i).Cells(8).Value.ToString)
                                cmd.Parameters.AddWithValue("@d9", dgw.Rows(i).Cells(9).Value.ToString)
                                cmd.Parameters.AddWithValue("@d10", dgw.Rows(i).Cells(10).Value.ToString)
                                cmd.Parameters.AddWithValue("@d11", dgw.Rows(i).Cells(11).Value.ToString)
                                cmd.Parameters.AddWithValue("@d12", dgw.Rows(i).Cells(12).Value.ToString)
                                cmd.Parameters.AddWithValue("@d13", dgw.Rows(i).Cells(13).Value.ToString)
                                cmd.Parameters.AddWithValue("@d14", dgw.Rows(i).Cells(14).Value.ToString)
                                cmd.Parameters.AddWithValue("@d15", dgw.Rows(i).Cells(3).Value.ToString)
                                cmd.Parameters.AddWithValue("@d16", dgw.Rows(i).Cells(15).Value.ToString)
                                cmd.Parameters.AddWithValue("@d17", toNumber("0"))
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                            End Try
                        Next
                        If toNumber(lblIDRecall.Text) > 0 Then
                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cq As String = "delete from TempRestaurantPOS_OrderedProductKOT where TicketID=@d1"
                                cmd = New SqlCommand(cq)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                                RowsAffected = cmd.ExecuteNonQuery()
                                If con.State = ConnectionState.Open Then
                                    con.Close()
                                End If
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cq1 As String = "delete from TempRestaurantPOS_OrderInfoKOT where ID=@d1"
                                cmd = New SqlCommand(cq1)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", toNumber(lblIDRecall.Text))
                                RowsAffected = cmd.ExecuteNonQuery()
                                If con.State = ConnectionState.Open Then
                                    con.Close()
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                            End Try
                        End If
                        Try
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim sql4 As String = "SELECT R.Kitchen, K.Printer,K.IsEnabled FROM RestaurantPOS_OrderedProductKOT AS R INNER JOIN Kitchen AS K ON R.Kitchen = K.Kitchenname WHERE TicketID=@d1 Group By R.Kitchen, K.Printer, K.IsEnabled"
                            cmd = New SqlCommand(sql4)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", toNumber(newID))
                            rdr = cmd.ExecuteReader()
                            While (rdr.Read() = True)
                                Dim kitc As String = Trim(rdr(0).ToString)
                                Dim kitPrint As String = Trim(rdr(1).ToString)
                                Dim kitTag As String = Trim(rdr(2).ToString)
                                If kitTag = "Yes" Then
                                    '=========Print Kitchen=========
                                    Data_Load_Kitchen(kitc)
                                    Printer.NewPrint(kitPrint)
                                    Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
                                    Printer.Print("TicketNo: " & Trim(txtTicketNo.Text)) ' Transaction No | Nomor transaksi
                                    Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                                    Printer.Print("Date: " & TransDate) ' Trans Date | Tanggal transaksi
                                    Printer.Print("Cashier: " & lblUser.Text) 'spacing
                                    Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
                                    Printer.Print("Table No: " & txtTableNo.Text) 'spacing
                                    Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                                    arrWidth = {130, 50, 100} 'array for column width | array untuk lebar kolom
                                    arrFormat = {c.MidLeft, c.TopRight, c.TopLeft} 'array alignment 

                                    'column header split by ; | nama kolom dipisah dengan ;
                                    Printer.Print("Item;Qty;Notes", arrWidth, arrFormat)
                                    Printer.SetFont("Courier New", 18, FontStyle.Regular) 'Setting Font
                                    Printer.Print("----------------------------------------") 'line
                                    'looping item sales | loop item penjualan
                                    For r = 0 To dtItem.Rows.Count - 1
                                        Printer.Print(dtItem.Rows(r).Item("Itemname") & ";" & dtItem.Rows(r).Item("Qty") & ";" &
                                          Trim(dtItem.Rows(r).Item("Notes")), arrWidth, arrFormat)
                                    Next
                                    Printer.Print("----------------------------------------")
                                    'Release the job for actual printing
                                    Printer.DoPrint()
                                End If
                            End While

                            If Not rdr Is Nothing Then
                                rdr.Close()
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try

                        Call ClearAll()
                    Else
                        MsgBox("Order list is already been saved", vbInformation + vbOKOnly, "Order saved")
                    End If
                End If
            Else
                'Take-out
                If Trim(txtTicketNo.Text) = "" Then
                    MsgBox("Please create new ticket to settle this order list.", vbInformation + vbOKOnly, "Error ticket no")
                    Exit Sub
                Else
                    Try
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
                        cmd = New SqlCommand(ct)
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()

                        If rdr.Read() Then
                            txtBillNo.Text = Format(rdr(0).ToString + 1, "000000")
                            lblGrandTotal.Text = ""
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                    lblPayID.Text = "1"
                    lblSubTotal.Text = ""
                    chkSC.Checked = False
                    txtSCAmount.Text = ""
                    txtSCDiscPer.Text = ""
                    txtOSCANo.Text = ""
                    lblSCName.Text = ""
                    lblRefNo.Text = ""
                    lblBookID.Text = ""
                    lblRoomNo.Text = ""
                    lblGuestName.Text = ""
                    txtDiscPer.Text = ""
                    txtDiscAmt.Text = ""
                    txtDiscPer.ReadOnly = False
                    txtCash.ReadOnly = False
                    txtGrandTot.Text = toMoney(lblTotal.Text)
                    lblGrandTotal.Text = toMoney(lblTotal.Text)
                    lblSubTotal.Text = dblSubTotVat
                    txtCash.Text = ""
                    pnlPayment.Size = New Size(700, 656)
                    dgw1.Enabled = False
                    dgw2.Enabled = False
                    lblSplitTotal.Text = ""
                    btnSplitClear.Enabled = False
                    pnlPayment.BringToFront()
                    object_center(Me, pnlPayment)
                    pnlPayment.Show()
                    GetDiscounts()
                    TabControl1.Enabled = False
                    txtCash.SelectionStart = 0
                    txtCash.SelectionLength = Len(txtCash.Text)
                    txtCash.SelectAll()
                    txtCash.Focus()

                End If

            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If is_edit = True And toNumber(lblID.Text) > 0 Then
            If dgw.Rows.Count > 0 Then

            End If
        End If
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        'Data_Load()

        'Printer.NewPrint()

        'If is_en = True Then
        '    Printer.Print(Img, 300, 80)
        'End If

        ''Setting Font
        'Printer.SetFont("Courier New", 9, FontStyle.Bold)
        'Printer.Print(StoreName, {300}, {c.MidCenter}) 'Store Name | Nama Toko

        ''Setting Font
        'Printer.SetFont("Courier New", 8, FontStyle.Regular)
        'Printer.Print(StoreAddress & ";", {300}, 0) 'Store Address | Alamat Toko

        ''spacing
        'Printer.Print(TINNo, {300}, {c.MidCenter})
        'Printer.Print(SNNo, {300}, {c.MidCenter})
        'Printer.Print(MIDNo, {300}, {c.MidCenter})

        'Printer.Print(" ") 'spacing
        'Printer.Print(TransNo) ' Transaction No | Nomor transaksi
        'Printer.Print(TransDate) ' Trans Date | Tanggal transaksi

        'Printer.Print(" ") 'spacing
        'Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
        'arrWidth = {100, 40, 70, 70} 'array for column width | array untuk lebar kolom
        'arrFormat = {c.MidLeft, c.TopRight, c.TopRight, c.TopRight} 'array alignment 

        ''column header split by ; | nama kolom dipisah dengan ;
        'Printer.Print("Item;Qty;Price;Subtotal", arrWidth, arrFormat)
        'Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        'Printer.Print("----------------------------------------") 'line

        'dblSubtotal = 0
        'dblQty = 0
        ''looping item sales | loop item penjualan
        'For r = 0 To dtItem.Rows.Count - 1
        '    Printer.Print(dtItem.Rows(r).Item("Itemname") & ";" & dtItem.Rows(r).Item("Qty") & ";" &
        '              toMoney(dtItem.Rows(r).Item("Price")) & ";" &
        '              toMoney(dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price")), arrWidth, arrFormat)
        '    dblQty = dblQty + CSng(dtItem.Rows(r).Item("Qty"))
        '    dblSubtotal = dblSubtotal + (dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price"))
        'Next

        'Printer.Print("----------------------------------------")
        'arrWidth = {130, 150} 'array for column width | array untuk lebar kolom
        'arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
        'Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
        'Printer.Print("Total;" & toMoney(dblSubtotal), arrWidth, arrFormat)
        'Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        'Printer.Print("Payment;" & toMoney(txtCash.Text), arrWidth, arrFormat)
        'Printer.Print("----------------------------------------")
        'Printer.SetFont("Courier New", 9, FontStyle.Bold) 'Setting Font
        'Printer.Print("Change;" & toMoney(txtCash.Text - dblSubtotal), arrWidth, arrFormat)
        'Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        'Printer.Print(" ")
        'Printer.Print("Item Qty;" & dblQty, arrWidth, arrFormat)

        ''Release the job for actual printing
        'Printer.DoPrint()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        chkSC.Checked = False
        txtSCAmount.Text = ""
        txtSCDiscPer.Text = ""
        txtOSCANo.Text = ""
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtGrandTot.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        pnlPayment.SendToBack()
        pnlPayment.Hide()
        TabControl1.Enabled = True
        wal_tag = False
        lblPayID.Text = ""
        lblGrandTotal.Text = ""
        lblSubTotal.Text = ""
        lblRefNo.Text = ""
        lblSCName.Text = ""
        lblBookID.Text = ""
        lblRoomNo.Text = ""
        lblGuestName.Text = ""
        For i As Integer = 0 To dgwList.Rows.Count - 1
            dgwList.Rows(i).Cells(16).Value = "0"
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        s = txtQty.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtQty.Text = x
        x = ""
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim selTab As Integer = toNumber(TabControl1.SelectedIndex.ToString)
        If selTab = 1 Then
            dgwList.Rows.Clear()
            txtPaymentMode.Text = ""
            txtBillNo.Text = ""
            lblTotalBill.Text = ""
            FlowLayoutPanel3.Controls.Clear()
            tableTag = ""
            ticketTag = ""
            splitTag = False
            wal_tag = False
        ElseIf selTab = 0 Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub GetBilling()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT TableNo, TicketNo, GrandTotal from RestaurantPOS_OrderInfoKOT WHERE isPaid=0"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel3.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New CheckBox
            btn.Text = Trim(rdr.GetValue(0)) '& Environment.NewLine & rdr.GetValue(2)
            btn.AutoSize = True
            'btn.TextAlign = ContentAlignment.MiddleCenter
            'Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
            'btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Standard
            'btn.Width = 50
            'btn.Height = 25
            btn.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'UserButtons.Add(btn)
            FlowLayoutPanel3.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.chkBill_CheckedChanged
        Loop
        con.Close()
    End Sub

    Private Sub GetDiscounts()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Discount from Discounts WHERE Active='YES'"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel4.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = Trim(rdr.GetValue(0)) '& Environment.NewLine & rdr.GetValue(2)
                'btn.AutoSize = True
                btn.TextAlign = ContentAlignment.MiddleCenter
                'Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.ForeColor = Color.White
                btn.BackColor = Color.Crimson
                btn.FlatStyle = FlatStyle.Standard
                btn.Width = 120
                btn.Height = 50
                btn.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'UserButtons.Add(btn)
                FlowLayoutPanel4.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnDiscounts_CheckedChanged
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

#Region "Billing Buttons"

    Private Sub btnSettleBill_Click(sender As Object, e As EventArgs) Handles btnSettleBill.Click
        If Trim(txtBillNo.Text) <> "" Then
            If dgwList.Rows.Count > 0 Then
                For i As Integer = 0 To dgwList.Rows.Count - 1
                    dgwList.Rows(i).Cells(16).Value = "1"
                Next
                lblPayID.Text = "0"
                lblSubTotal.Text = ""
                chkSC.Checked = False
                txtSCDiscPer.Text = ""
                txtSCAmount.Text = ""
                lblSCName.Text = ""
                lblRefNo.Text = ""
                lblBookID.Text = ""
                lblRoomNo.Text = ""
                lblGuestName.Text = ""
                txtOSCANo.Text = ""
                txtDiscPer.Text = ""
                txtDiscAmt.Text = ""
                txtDiscPer.ReadOnly = False
                txtCash.ReadOnly = False
                txtGrandTot.Text = toMoney(lblTotalBill.Text)
                lblGrandTotal.Text = toMoney(lblTotalBill.Text)
                lblSubTotal.Text = dblSubTotVat
                txtCash.Text = ""
                pnlPayment.Size = New Size(700, 656)
                dgw1.Enabled = False
                dgw2.Enabled = False
                lblSplitTotal.Text = ""
                btnSplitClear.Enabled = False
                'pnlPayment.Size = New Size(1070, 656)
                pnlPayment.BringToFront()
                object_center(Me, pnlPayment)
                pnlPayment.Show()
                GetDiscounts()
                TabControl1.Enabled = False
                txtCash.SelectionStart = 0
                txtCash.SelectionLength = Len(txtCash.Text)
                txtCash.SelectAll()
                txtCash.Focus()
            End If
        Else
            MsgBox("Please create a new bill to settle payment.", vbInformation + vbOKOnly, "Error bill number")
            Exit Sub
        End If

    End Sub

    Private Sub btnNewBill_Click(sender As Object, e As EventArgs) Handles btnNewBill.Click
        If Trim(txtBillNo.Text) <> "" And dgwList.Rows.Count > 0 Then
            If MsgBox("Are you sure you want to create a new bill and cancel this selection?", vbQuestion + vbYesNo, "Confirm action") = vbYes Then
                dgwList.Rows.Clear()
                ticketTag = ""
                tableTag = ""
                splitTag = False
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()

                    If rdr.Read() Then
                        txtBillNo.Text = Format(rdr(0).ToString + 1, "000000")
                        lblGrandTotal.Text = ""
                        Call GetBilling()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            Else
                Exit Sub
            End If
        Else
            dgwList.Rows.Clear()
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()

                If rdr.Read() Then
                    txtBillNo.Text = Format(rdr(0).ToString + 1, "000000")
                    lblGrandTotal.Text = ""
                    Call GetBilling()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If


    End Sub

    Private Sub btnSplitBill_Click(sender As Object, e As EventArgs) Handles btnSplitBill.Click
        If Trim(txtBillNo.Text) <> "" Then
            If dgwList.Rows.Count > 0 Then
                splitTag = True
                lblSplitTotal.Text = ""
                lblPayID.Text = "0"
                lblSubTotal.Text = ""
                chkSC.Checked = False
                txtSCDiscPer.Text = ""
                txtSCAmount.Text = ""
                txtOSCANo.Text = ""
                txtDiscPer.Text = ""
                txtDiscAmt.Text = ""
                txtDiscPer.ReadOnly = False
                txtCash.ReadOnly = False
                txtGrandTot.Text = toMoney(lblTotalBill.Text)
                lblGrandTotal.Text = toMoney(lblTotalBill.Text)
                lblSubTotal.Text = dblSubTotVat
                txtCash.Text = ""
                dgw1.Enabled = True
                dgw2.Enabled = True
                btnSplitClear.Enabled = True
                pnlPayment.Size = New Size(1070, 656)
                pnlPayment.BringToFront()
                object_center(Me, pnlPayment)
                pnlPayment.Show()
                GetDiscounts()
                TabControl1.Enabled = False
                txtCash.SelectionStart = 0
                txtCash.SelectionLength = Len(txtCash.Text)
                txtCash.SelectAll()
                txtCash.Focus()

                Dim targetRows = New List(Of DataGridViewRow)

                For Each sourceRow As DataGridViewRow In dgwList.Rows

                    If (Not sourceRow.IsNewRow) Then

                        Dim targetRow = CType(sourceRow.Clone(), DataGridViewRow)


                        For Each cell As DataGridViewCell In sourceRow.Cells
                            targetRow.Cells(cell.ColumnIndex).Value = cell.Value
                        Next

                        targetRows.Add(targetRow)

                    End If

                Next

                'Clear target columns and then clone all source columns.

                dgw1.Columns.Clear()
                dgw2.Rows.Clear()

                For Each column As DataGridViewColumn In dgwList.Columns
                    dgw1.Columns.Add(CType(column.Clone(), DataGridViewColumn))
                Next

                'It's recommended to use the AddRange method (if available)
                'when adding multiple items to a collection.

                dgw1.Rows.AddRange(targetRows.ToArray())

            End If
        Else
            MsgBox("Please create a new bill and select table to settle payment.", vbInformation + vbOKOnly, "Error bill number")
            Exit Sub
        End If

    End Sub

    Public Sub AddSplitItems(ByVal srows As Integer, ByVal nqty As Integer, sqty As Integer)
        Dim subtot As Double = 0
        If srows >= 0 Then

            Dim row As New DataGridViewRow()

            row = DirectCast(dgw1.Rows(srows).Clone(), DataGridViewRow)
            Dim intColIndex As Integer = 0
            For Each cell As DataGridViewCell In dgw1.Rows(srows).Cells
                row.Cells(intColIndex).Value = cell.Value
                intColIndex += 1
            Next
            dgw2.Rows.Add(row)
            Dim nwrow As Integer = dgw2.Rows.Count - 1
            'MsgBox(nwrow)
            dgw1.Rows(srows).Cells(3).Value = sqty
            dgw2.Rows(nwrow).Cells(3).Value = nqty
            If sqty = 0 Then
                dgwList.Rows(srows).Cells(16).Value = "1"
            End If
            'For Each roe As DataGridViewRow In dgw1.Rows
            '    If roe.Cells(3).Value = 0 Then
            '        dgw1.Rows.RemoveAt(roe.Index)
            '    Else

            '    End If
            'Next

            Call ComputeSplitBill()
        End If
    End Sub

    Private Sub btnCancelBill_Click(sender As Object, e As EventArgs) Handles btnCancelBill.Click
        pnlPayment.SendToBack()
        pnlPayment.Hide()
        txtBillNo.Text = ""
        txtPaymentMode.Text = ""
        lblGrandTotal.Text = ""
        FlowLayoutPanel3.Controls.Clear()
        TabControl1.Enabled = True
        dgwList.Rows.Clear()
    End Sub

#End Region

#Region "Payment Buttons"

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        txtPaymentMode.Text = "Cash"
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        txtPaymentMode.Text = "Card"
    End Sub

    Private Sub btnWallet_Click(sender As Object, e As EventArgs) Handles btnWallet.Click
        With frmWalletList
            .frm = "frmPOS"
            .ShowDialog()
        End With
        If wal_tag = True Then
            With frmCustomDialog13
                .frm = "frmPOS2"
                .Label2.Text = "Enter Reference Number"
                .btnKeyboard.Visible = True
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click
        With frmGuestLists
            .ShowDialog()
        End With
    End Sub

    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        If Trim(txtPaymentMode.Text) = "" Then
            MsgBox("Please select a payment mode to settle payment.", vbInformation + vbOKOnly, "Error payment mode")
            Exit Sub
        ElseIf Trim(txtBillNo.Text) = "" Then
            MsgBox("Please create a new bill to settle payment.", vbInformation + vbOKOnly, "Error bill number")
            Exit Sub
        ElseIf chkSC.Checked = True And (Trim(txtOSCANo.Text) = "" Or Trim(lblSCName.Text) = "") Then
            MsgBox("Please enter SC/PWD details to settle payment.", vbInformation + vbOKOnly, "Error OSCA ID number or name")
            Exit Sub

        Else
            If toNumber(txtGrandTot.Text) <= toNumber(txtCash.Text) Then
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()

                    If rdr.Read() Then
                        txtBillNo.Text = Format(rdr(0).ToString + 1, "000000")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
                TransNo = txtBillNo.Text

                If splitTag = True Then
                    Data_LoadPaymentSplit()
                Else
                    'Save and print function
                    If toNumber(lblPayID.Text) > 0 Then
                        'Take-out payment
                        Data_Load()
                    Else
                        'Dine-in billing
                        Data_LoadPayment()
                    End If
                End If

                TransDate = Format(Now, "yyyy-MM-dd HH:mm:ss")
                Try
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "insert into RestaurantPOS_BillingInfoKOT (BillNo,BillDate,KOTDiscountPer,GrandTotal,Cash,Change,Operator,PaymentMode,ExchangeRate,CurrencyCode,DiscountReason,TableNo,RefNo,OSCANo,SCDiscAmt,SCPer,DiscAmount) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Trim(txtBillNo.Text))
                    cmd.Parameters.AddWithValue("@d2", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@d3", toNumber(txtDiscPer.Text))
                    cmd.Parameters.AddWithValue("@d4", toNumber(txtGrandTot.Text))
                    cmd.Parameters.AddWithValue("@d5", toNumber(txtCash.Text))
                    cmd.Parameters.AddWithValue("@d6", toNumber(txtChange.Text))
                    cmd.Parameters.AddWithValue("@d7", lblUser.Text)
                    cmd.Parameters.AddWithValue("@d8", Trim(txtPaymentMode.Text))
                    cmd.Parameters.AddWithValue("@d9", toNumber("1.00"))
                    cmd.Parameters.AddWithValue("@d10", CurCode)
                    cmd.Parameters.AddWithValue("@d11", "")
                    cmd.Parameters.AddWithValue("@d12", tableTag)
                    cmd.Parameters.AddWithValue("@d13", Trim(lblRefNo.Text))
                    cmd.Parameters.AddWithValue("@d14", Trim(txtOSCANo.Text))
                    cmd.Parameters.AddWithValue("@d15", toNumber(txtSCAmount.Text))
                    cmd.Parameters.AddWithValue("@d16", toNumber(txtSCDiscPer.Text))
                    cmd.Parameters.AddWithValue("@d17", toNumber(txtDiscAmt.Text))
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Dim st As String = "Payment made of '" & ticketTag & "' with TableNo " & tableTag
                    LogFunc(lblUser.Text, st)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
                If splitTag = True Then
                    If dgw2.Rows.Count > 0 Then
                        Dim opid As Integer = 0
                        Dim spqty As Integer = 0
                        Dim tkid As Integer = 0
                        For i As Integer = 0 To dgw2.Rows.Count - 1
                            opid = toNumber(dgw2.Rows(i).Cells(0).Value)
                            spqty = toNumber(dgw2.Rows(i).Cells(3).Value)
                            tkid = toNumber(dgw2.Rows(i).Cells(15).Value)

                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb3 As String = "INSERT INTO RestaurantPOS_OrderedProductSplit (OP_ID,TicketID,Qty) VALUES(@d1,@d2,@d3)"
                                cmd = New SqlCommand(cb3)
                                cmd.Parameters.AddWithValue("@d1", opid)
                                cmd.Parameters.AddWithValue("@d2", toNumber(tkid))
                                cmd.Parameters.AddWithValue("@d3", toNumber(spqty))
                                cmd.Connection = con
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                            End Try
                        Next
                        For x As Integer = 0 To dgwList.Rows.Count - 1
                            Dim opd As Integer = toNumber(dgwList.Rows(x).Cells(0).Value)
                            Dim upd_tag As Integer = toNumber(dgwList.Rows(x).Cells(16).Value)
                            If upd_tag > 0 And opd > 0 Then
                                Try
                                    con.Open()
                                    Dim cb3 As String = "UPDATE RestaurantPOS_OrderedProductKOT SET isPaid=1 WHERE OP_ID=@d1"
                                    cmd = New SqlCommand(cb3)
                                    cmd.Parameters.AddWithValue("@d1", opd)
                                    cmd.Connection = con
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                End Try
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim cb3 As String = "INSERT INTO RestaurantPOS_OrderedProductBillKOT (BillID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,TableNo) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                                    cmd = New SqlCommand(cb3)
                                    cmd.Parameters.AddWithValue("@d1", Trim(txtBillNo.Text))
                                    cmd.Parameters.AddWithValue("@d2", Trim(dgwList.Rows(x).Cells(1).Value))
                                    cmd.Parameters.AddWithValue("@d3", toNumber(dgwList.Rows(x).Cells(2).Value))
                                    cmd.Parameters.AddWithValue("@d4", toNumber(dgwList.Rows(x).Cells(3).Value))
                                    cmd.Parameters.AddWithValue("@d5", toNumber(dgwList.Rows(x).Cells(4).Value))
                                    cmd.Parameters.AddWithValue("@d6", toNumber(dgwList.Rows(x).Cells(7).Value))
                                    cmd.Parameters.AddWithValue("@d7", toNumber(dgwList.Rows(x).Cells(8).Value))
                                    cmd.Parameters.AddWithValue("@d8", toNumber(dgwList.Rows(x).Cells(13).Value))
                                    cmd.Parameters.AddWithValue("@d9", toNumber(dgwList.Rows(x).Cells(14).Value))
                                    cmd.Parameters.AddWithValue("@d10", toNumber(dgwList.Rows(x).Cells(11).Value))
                                    cmd.Parameters.AddWithValue("@d11", toNumber(dgwList.Rows(x).Cells(12).Value))
                                    cmd.Parameters.AddWithValue("@d12", toNumber(dgwList.Rows(x).Cells(5).Value))
                                    cmd.Parameters.AddWithValue("@d13", toNumber(dgwList.Rows(x).Cells(6).Value))
                                    cmd.Parameters.AddWithValue("@d14", toNumber(dgwList.Rows(x).Cells(9).Value))
                                    cmd.Parameters.AddWithValue("@d15", Trim(dgwList.Rows(x).Cells(10).Value))
                                    cmd.Connection = con
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                End Try
                            End If
                        Next
                    End If
                Else

                End If

                If ticketTag <> "" Then
                    Dim tktparts As String() = ticketTag.Split(New Char() {";"c})
                    Dim tktpart As String
                    For Each tktpart In tktparts
                        Try
                            'MsgBox(tktpart)
                            If splitTag = False Then
                                Try
                                    con.Open()
                                    Dim cb3 As String = "UPDATE RestaurantPOS_OrderedProductKOT SET isPaid=1 WHERE TicketID=@d1"
                                    cmd = New SqlCommand(cb3)
                                    cmd.Parameters.AddWithValue("@d1", toNumber(tktpart))
                                    cmd.Connection = con
                                    cmd.ExecuteNonQuery()
                                    'MsgBox("UPDATE RestaurantPOS_OrderedProductKOT SET isPaid=1 WHERE TicketID=@d1")
                                    con.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                End Try
                            End If
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cl3 As String = "select * from RestaurantPOS_OrderedProductKOT where isPaid=0 AND TicketID=@d1"
                            cmd = New SqlCommand(cl3)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", toNumber(tktpart))
                            rdr = cmd.ExecuteReader()
                            If rdr.Read Then
                                'MsgBox("REad")
                                If Not rdr Is Nothing Then
                                    rdr.Close()
                                End If
                            Else
                                'MsgBox("Else")
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim cb3 As String = "update RestaurantPOS_OrderInfoKOT set isPaid=1, BillDate=@d1, BillNo=@d3 where ID=@d2"
                                    cmd = New SqlCommand(cb3)
                                    cmd.Parameters.AddWithValue("@d1", CDate(TransDate))
                                    cmd.Parameters.AddWithValue("@d2", toNumber(tktpart))
                                    cmd.Parameters.AddWithValue("@d3", Trim(txtBillNo.Text))
                                    cmd.Connection = con
                                    cmd.ExecuteNonQuery()
                                    'MsgBox("update RestaurantPOS_OrderInfoKOT set isPaid=1, BillDate=@d1, BillNo=@d3 where ID= " & toNumber(tktpart))
                                    con.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                End Try
                                Try
                                    con = New SqlConnection(cs)
                                    con.Open()
                                    Dim cb3 As String = "update RestaurantPOS_OrderedProductKOT set isPaid=1 where TicketID=@d2"
                                    cmd = New SqlCommand(cb3)

                                    cmd.Parameters.AddWithValue("@d2", toNumber(tktpart))
                                    cmd.Connection = con
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                End Try
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        End Try
                    Next
                End If
                If toNumber(lblBookID.Text) > 0 Then
                    Try
                        con = New SqlConnection(cs)
                        con.Open()
                        MsgBox("Insert room service")
                        Dim cb3 As String = "INSERT INTO hotel_guest_charges (booking_id,description,price,paid,date_created) VALUES(@d1,@d2,@d3,@d4,@d5)"
                        cmd = New SqlCommand(cb3)
                        cmd.Parameters.AddWithValue("@d1", toNumber(lblBookID.Text))
                        cmd.Parameters.AddWithValue("@d2", "Food Orders :" & txtBillNo.Text)
                        cmd.Parameters.AddWithValue("@d3", toNumber(txtGrandTot.Text))
                        cmd.Parameters.AddWithValue("@d4", toNumber("0"))
                        cmd.Parameters.AddWithValue("@d5", CDate(TransDate))
                        cmd.Connection = con
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                End If


                Printer.NewPrint(PosTicketPrntr)

                If is_en = True Then
                    Printer.Print(Img, 300, 80)
                End If

                'Setting Font
                Printer.SetFont("Courier New", 9, FontStyle.Bold)
                Printer.Print(StoreName, {300}, {c.MidCenter}) 'Store Name | Nama Toko

                'Setting Font
                Printer.SetFont("Courier New", 8, FontStyle.Regular)
                Printer.Print(StoreAddress & ";", {300}, 0) 'Store Address | Alamat Toko

                'spacing
                Printer.Print(TINNo, {300}, {c.MidCenter})
                Printer.Print(SNNo, {300}, {c.MidCenter})
                Printer.Print(MIDNo, {300}, {c.MidCenter})

                Printer.Print(" ") 'spacing
                Printer.Print("Bill No: " & TransNo) ' Transaction No | Nomor transaksi
                Printer.Print("Date: " & TransDate) ' Trans Date | Tanggal transaksi
                Printer.Print("Cashier: " & lblUser.Text) 'spacing
                Printer.Print("Payment Mode: " & txtPaymentMode.Text) 'spacing
                Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
                arrWidth = {100, 40, 70, 70} 'array for column width | array untuk lebar kolom
                arrFormat = {c.MidLeft, c.TopRight, c.TopRight, c.TopRight} 'array alignment 

                'column header split by ; | nama kolom dipisah dengan ;
                Printer.Print("Item;Qty;Price;Subtotal", arrWidth, arrFormat)
                Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                Printer.Print("----------------------------------------") 'line

                dblSubtotal = 0
                dblQty = 0
                dblDiscTot = 0
                dblVatTot = 0
                'looping item sales | loop item penjualan
                For r = 0 To dtItem.Rows.Count - 1
                    Printer.Print(dtItem.Rows(r).Item("Itemname") & ";" & dtItem.Rows(r).Item("Qty") & ";" &
                              toMoney(dtItem.Rows(r).Item("Price")) & ";" &
                              toMoney(dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price")), arrWidth, arrFormat)
                    dblQty = dblQty + CSng(dtItem.Rows(r).Item("Qty"))
                    dblVatTot = dblVatTot + CSng(dtItem.Rows(r).Item("VatAmt"))
                    dblDiscTot = dblDiscTot + CSng(dtItem.Rows(r).Item("DiscAmt"))
                    dblSCTot = dblSCTot + CSng(dtItem.Rows(r).Item("SCAmt"))
                    dblSubtotal = dblSubtotal + (dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price"))
                Next

                Printer.Print("----------------------------------------")
                arrWidth = {130, 150} 'array for column width | array untuk lebar kolom
                arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
                Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
                Printer.Print("Sub-total;" & toMoney(dblSubtotal), arrWidth, arrFormat)
                Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                Printer.Print("Discount;" & toMoney(dblDiscTot + toNumber(txtDiscAmt.Text)), arrWidth, arrFormat)
                Printer.Print("Service Charge;" & toMoney(dblSCTot), arrWidth, arrFormat)
                Printer.Print("VAT Amount;" & toMoney(dblVatTot), arrWidth, arrFormat)
                Printer.SetFont("Courier New", 9, FontStyle.Bold) 'Setting Font
                Printer.Print("Total;" & toMoney(txtGrandTot.Text), arrWidth, arrFormat)
                Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                Printer.Print("Payment;" & toMoney(txtCash.Text), arrWidth, arrFormat)
                Printer.Print("----------------------------------------")
                Printer.SetFont("Courier New", 10, FontStyle.Bold) 'Setting Font
                Printer.Print("Change;" & toMoney(txtChange.Text), arrWidth, arrFormat)
                Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
                Printer.Print(" ")
                Printer.Print("Item Qty;" & dblQty, arrWidth, arrFormat)

                If chkSC.Checked = True Then
                    Printer.Print("OSCA/PWD ID;" & Trim(txtOSCANo.Text), arrWidth, arrFormat)
                    Printer.Print("Name;" & Trim(lblSCName.Text), arrWidth, arrFormat)
                    Printer.Print("Signature;" & "____________________", arrWidth, arrFormat)
                End If

                'Release the job for actual printing
                Printer.DoPrint()
                pnlPayment.SendToBack()
                pnlPayment.Hide()
                chkSC.Checked = False
                txtSCDiscPer.Text = ""
                txtSCAmount.Text = ""
                txtOSCANo.Text = ""
                txtBillNo.Text = ""
                txtPaymentMode.Text = ""
                lblSplitTotal.Text = ""
                lblPayID.Text = ""
                lblGrandTotal.Text = ""
                lblTotalBill.Text = ""
                lblRefNo.Text = ""
                lblSCName.Text = ""
                lblBookID.Text = ""
                lblRoomNo.Text = ""
                lblGuestName.Text = ""
                txtGrandTot.Text = ""
                txtCash.Text = ""
                txtChange.Text = ""
                txtDiscAmt.Text = ""
                txtDiscPer.Text = ""
                FlowLayoutPanel3.Controls.Clear()
                TabControl1.Enabled = True
                dgwList.Rows.Clear()
                dgw1.Rows.Clear()
                dgw2.Rows.Clear()
                tableTag = ""
                ticketTag = ""
                splitTag = False

            Else
                MsgBox("Payment is not suffice to settle the bill." & vbNewLine & "Please re-enter amount", vbCritical + vbOKOnly, "Payment not enough")
                Exit Sub
            End If
        End If

    End Sub

#End Region

#Region "KeyEvents Focus"

    Private Sub txtDiscPer_GotFocus(sender As Object, e As EventArgs) Handles txtDiscPer.GotFocus
        FocusText = txtDiscPer
    End Sub

    Private Sub txtDiscAmt_GotFocus(sender As Object, e As EventArgs) Handles txtDiscAmt.GotFocus
        FocusText = Nothing
    End Sub

    Private Sub txtGrandTot_GotFocus(sender As Object, e As EventArgs) Handles txtGrandTot.GotFocus
        FocusText = Nothing
    End Sub

    Private Sub txtChange_GotFocus(sender As Object, e As EventArgs) Handles txtChange.GotFocus
        FocusText = Nothing
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As Object, e As EventArgs) Handles txtDiscPer.TextChanged
        If toNumber(txtGrandTot.Text) >= 0 Then
            If Val(txtDiscPer.Text) > 0 Then
                Dim dicper As Double = toNumber(txtDiscPer.Text) / 100
                Dim dschk As Double = toNumber(toNumber(lblGrandTotal.Text) * dicper)
                If dschk <= toNumber(lblGrandTotal.Text) Then
                    txtDiscAmt.Text = toMoney(dschk)
                End If
                Dim grnd As Double = toNumber(toNumber(lblGrandTotal.Text) - toNumber(txtDiscAmt.Text) - toNumber(txtSCAmount.Text))
                If toNumber(grnd) < 0 Then

                Else
                    txtGrandTot.Text = toMoney(grnd)
                End If
                If Trim(txtCash.Text) <> "" Then
                    txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text)))
                Else
                    txtChange.Text = ""
                End If
            Else
                txtDiscPer.Text = "0"
                txtDiscAmt.Text = "0"
                txtGrandTot.Text = toMoney(lblGrandTotal.Text) - toNumber(txtSCAmount.Text) - toNumber(txtDiscAmt.Text)
                If Trim(txtCash.Text) <> "" Then
                    txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text)))
                Else
                    txtChange.Text = ""
                End If
            End If
        Else

        End If
    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        If toNumber(txtGrandTot.Text) >= 0 Then
            If Trim(txtCash.Text) <> "" Then
                txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text)))
            Else
                txtChange.Text = ""
            End If

        End If
    End Sub

    Private Sub txtSCDishPer_TextChanged(sender As Object, e As EventArgs) Handles txtSCDiscPer.TextChanged
        If toNumber(txtGrandTot.Text) >= 0 Then
            If Val(txtSCDiscPer.Text) > 0 Then
                Dim dicper As Double = toNumber(txtSCDiscPer.Text) / 100
                Dim dschk As Double = toNumber(toNumber(lblSubTotal.Text) * dicper)
                If dschk <= toNumber(lblSubTotal.Text) Then
                    txtSCAmount.Text = toMoney(dschk)
                End If
                Dim grnd As Double = toNumber(toNumber(lblGrandTotal.Text) - toNumber(txtSCAmount.Text) - toNumber(txtDiscAmt.Text))
                If toNumber(grnd) < 0 Then

                Else
                    txtGrandTot.Text = toMoney(grnd)
                End If
                If Trim(txtCash.Text) <> "" Then
                    txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text)))
                Else
                    txtChange.Text = ""
                End If
            Else
                txtSCDiscPer.Text = "0"
                txtSCAmount.Text = "0"
                txtGrandTot.Text = toMoney(lblGrandTotal.Text) - toNumber(txtSCAmount.Text) - toNumber(txtDiscAmt.Text)
                If Trim(txtCash.Text) <> "" Then
                    txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text)))
                Else
                    txtChange.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub

    Private Sub CheckButton1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSC.CheckedChanged
        If chkSC.Checked = True Then
            txtOSCANo.ReadOnly = False
            txtOSCANo.BackColor = Color.White
            txtSCDiscPer.ReadOnly = False
            txtSCDiscPer.BackColor = Color.White
            txtSCAmount.ReadOnly = True
            txtSCDiscPer.Text = toNumber(srvSC)
            txtOSCANo.Focus()
        Else
            txtOSCANo.Text = ""
            txtOSCANo.ReadOnly = True
            txtOSCANo.BackColor = Color.WhiteSmoke
            txtSCDiscPer.Text = ""
            txtSCDiscPer.ReadOnly = True
            txtSCDiscPer.BackColor = Color.WhiteSmoke
            txtSCAmount.ReadOnly = True
            txtSCAmount.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub txtCash_GotFocus(sender As Object, e As EventArgs) Handles txtCash.GotFocus
        txtCash.SelectionStart = 0
        txtCash.SelectionLength = Len(txtCash.Text)
        txtCash.SelectAll()
        FocusText = txtCash
    End Sub

    Private Sub btnSplitAdd_Click(sender As Object, e As EventArgs) Handles btnSplitAdd.Click
        If dgw1.Rows.Count > 0 Then
            Dim selrow As Integer = dgw1.SelectedCells(0).OwningRow.Index
            Dim selqty As Integer = toNumber(dgw1.Rows(selrow).Cells(3).Value.ToString)
            If selqty > 0 Then
                With frmCustomDialog14
                    .lblSelrow.Text = selrow
                    .lblQty.Text = selqty
                    .ShowDialog()
                End With
            Else
                MsgBox("Please select item with right quantity to split.", vbInformation + vbOKOnly, "Error quantity")
            End If

        End If
    End Sub

    Private Sub btnSplitClear_Click(sender As Object, e As EventArgs) Handles btnSplitClear.Click
        'lblSplitTotal.Text = ""
        For i As Integer = 0 To dgwList.Rows.Count - 1
            dgwList.Rows(i).Cells(16).Value = "0"
        Next

        Call ComputeTotalBill()
        If dgwList.Rows.Count > 0 Then
            splitTag = True
            lblSplitTotal.Text = ""
            lblPayID.Text = "0"
            lblSubTotal.Text = ""
            chkSC.Checked = False
            txtSCDiscPer.Text = ""
            txtSCAmount.Text = ""
            txtOSCANo.Text = ""
            txtDiscPer.Text = ""
            txtDiscAmt.Text = ""
            txtDiscPer.ReadOnly = False
            txtCash.ReadOnly = False
            txtGrandTot.Text = toMoney(lblTotalBill.Text)
            lblGrandTotal.Text = toMoney(lblTotalBill.Text)
            lblSubTotal.Text = dblSubTotVat
            txtCash.Text = ""
            dgw1.Enabled = True
            dgw2.Enabled = True
            btnSplitClear.Enabled = True
            pnlPayment.Size = New Size(1070, 656)
            pnlPayment.BringToFront()
            object_center(Me, pnlPayment)
            pnlPayment.Show()
            GetDiscounts()
            TabControl1.Enabled = False
            txtCash.SelectionStart = 0
            txtCash.SelectionLength = Len(txtCash.Text)
            txtCash.SelectAll()
            txtCash.Focus()

            Dim targetRows = New List(Of DataGridViewRow)

            For Each sourceRow As DataGridViewRow In dgwList.Rows

                If (Not sourceRow.IsNewRow) Then

                    Dim targetRow = CType(sourceRow.Clone(), DataGridViewRow)


                    For Each cell As DataGridViewCell In sourceRow.Cells
                        targetRow.Cells(cell.ColumnIndex).Value = cell.Value
                    Next

                    targetRows.Add(targetRow)

                End If

            Next

            'Clear target columns and then clone all source columns.

            dgw1.Columns.Clear()
            dgw2.Rows.Clear()

            For Each column As DataGridViewColumn In dgwList.Columns
                dgw1.Columns.Add(CType(column.Clone(), DataGridViewColumn))
            Next

            'It's recommended to use the AddRange method (if available)
            'when adding multiple items to a collection.

            dgw1.Rows.AddRange(targetRows.ToArray())

        End If
    End Sub

    Private Sub txtDiscPer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscPer.KeyPress
        Dim validChars As String = "0123456789."
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSCDiscPer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSCDiscPer.KeyPress
        Dim validChars As String = "0123456789."
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        Dim validChars As String = "0123456789."
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOSCANo_LostFocus(sender As Object, e As EventArgs) Handles txtOSCANo.Leave
        If Trim(txtOSCANo.Text) <> "" Then
            With frmCustomDialog13
                .frm = "frmPOS3"
                .Label2.Text = "Enter SC/PWD Name"
                .btnKeyboard.Visible = True
                .ShowDialog()
            End With
        End If
    End Sub

#End Region

End Class