Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing

Public Class frmPOS
    Dim rowIndex As Integer
    Dim table As New DataTable("table")
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Public is_edit As Boolean = False
    Dim s, x As String
    Dim srvTax, srvChrge, srvVat As Double
    Dim StoreName As String = ""
    Dim StoreAddress As String = ""
    Dim Img As Image
    Public TransNo As String = ""
    Dim TransDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
    Dim TINNo As String = ""
    Dim SNNo As String = ""
    Dim MIDNo As String = ""
    Dim is_en As Boolean = False
    'for item sales | untuk item penjualan
    Public dtItem As DataTable
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat

    'declaring printing format class
    Dim c As New PrintingFormat

    'for subtotal & qty total
    Dim dblSubtotal As Double = 0
    Dim dblQty As Double = 0
    Dim dblPayment As Double = 50000
    Dim FocusText As TextBox

    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblType.Text = ""
        lblTypeID.Text = ""
        txtTableNo.Text = ""
        txtTicketNo.Text = ""
        txtQty.Text = ""
        lblTotal.Text = ""
        lblTotalBill.Text = ""
        txtBillNo.Text = ""
        txtPaymentMode.Text = ""
        lblID.Text = ""
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtGrandTot.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        pnlPayment.Hide()
        is_edit = False
        Call Getdata()
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
            End If
        End If

    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN), ReceiptLogo, isEnabled from Hotel", con)
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
            End If
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

    Public Sub GetOrders(ByVal ids As String)
        If ids <> "" Then
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim cl As String = "SELECT TOP 1 * FROM RestaurantPOS_OrderInfoKOT where TableNo=@d1 AND isPaid=0 ORDER BY ID DESC"
                cmd = New SqlCommand(cl)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", ids)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    lblID.Text = toNumber(rdr(0))
                    txtTicketNo.Text = rdr(1).ToString
                    txtTableNo.Text = rdr(4).ToString
                    lblTotal.Text = toMoney(rdr(3).ToString)
                    lblType.Text = rdr(8).ToString
                    lblTypeID.Text = changeOneZeroValue(rdr(9))
                    'MsgBox(rdr(9) & " " & ids)
                    Call GetOrderList(toNumber(rdr(0)).ToString)
                End If
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GetOrderList(ByVal ids As Integer)
        If ids > 0 Then
            dgw.Rows.Clear()
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = "SELECT * from RestaurantPOS_OrderedProductKOT where TicketID = '" & ids & "'"
                cmd = New SqlCommand(cmdText1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                FlowLayoutPanel2.Controls.Clear()
                Do While (rdr.Read())
                    dgw.Rows.Add(rdr(2), rdr(3), rdr(4), rdr(15), toNumber(rdr(0)), toNumber(rdr(5)), toNumber(rdr(6)), toNumber(rdr(7)), toNumber(rdr(8)), toNumber(rdr(9)), toNumber(rdr(10)), toNumber(rdr(11)), toNumber(rdr(12)), toNumber(rdr(13)), toNumber(rdr(14)))
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
                Dim btn As New Button
                btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Flat
                btn.Width = 93
                btn.Height = 50
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel2.Controls.Add(btn)
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
            Try
                For i As Integer = 0 To dgw.Rows.Count - 1
                    totalamt += toNumber(dgw.Rows(i).Cells(14).Value.ToString)
                Next
                lblTotal.Text = toMoney(totalamt)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            lblTotal.Text = "0.00"
        End If
    End Sub

    Private Sub ComputeTotalBill()
        If dgwList.Rows.Count > 0 Then
            Dim totalamt As Double = 0
            Try
                For i As Integer = 0 To dgwList.Rows.Count - 1
                    totalamt += toNumber(dgwList.Rows(i).Cells(9).Value.ToString)
                Next
                lblTotalBill.Text = toMoney(totalamt)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            lblTotalBill.Text = "0.00"
        End If
    End Sub

    Private Sub Data_Load()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("Itemname", Type.GetType("System.String"))
            .Add("Qty", Type.GetType("System.String"))
            .Add("Price", Type.GetType("System.String"))
        End With
        If dgw.Rows.Count > 0 Then
            Dim ItemRow As DataRow
            For i As Integer = 0 To dgw.Rows.Count - 1
                ItemRow = dtItem.NewRow()
                ItemRow("Itemname") = dgw.Rows(i).Cells(0).Value.ToString
                ItemRow("Qty") = dgw.Rows(i).Cells(2).Value.ToString
                ItemRow("Price") = dgw.Rows(i).Cells(14).Value.ToString
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

    Private Sub chkBill_CheckedChanged(sender As Object, e As EventArgs)
        Dim chkbill As CheckBox = DirectCast(sender, CheckBox)
        If chkbill.Checked = True Then
            If Trim(chkbill.Text) <> "" Then
                Try
                    Dim ticketID As Integer = 0
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select ID from RestaurantPOS_OrderInfoKOT WHERE TableNo=@d1 and isPaid=0"
                    cmd = New SqlCommand(sql)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", chkbill.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then
                        If Not rdr Is Nothing Then
                            ticketID = toNumber(rdr(0).ToString)
                            rdr.Close()
                            If ticketID > 0 Then
                                Dim sqldet As String = "Select * from RestaurantPOS_OrderedProductKOT WHERE TicketID=@d1"
                                cmd = New SqlCommand(sqldet)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", ticketID)
                                rdr = cmd.ExecuteReader()
                                Do While (rdr.Read())
                                    dgwList.Rows.Add(toNumber(rdr(0)), Trim(rdr(2)), toNumber(rdr(3)), toNumber(rdr(4)), toNumber(rdr(5)), toNumber(rdr(12)), toNumber(rdr(13)), toNumber(rdr(6)), toNumber(rdr(7)), toNumber(rdr(14)), chkbill.Text)
                                Loop

                            End If
                        End If
                    Else
                        ticketID = 0
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        Else
            If dgwList.Rows.Count > 0 Then
                Dim rowcount As Integer = Me.dgwList.RowCount - 1
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
        Call ComputeTotalBill()
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Call FillMenus(btn.Text)
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
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select * from Dish WHERE DishName=@d1"
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
                btnUpdate.Enabled = True
                btnChgTable.Enabled = True
            Else
                If toNumber(lblTypeID.Text) = 0 And toNumber(lblID.Text) > 0 Then
                    If MsgBox("Are you sure you want to change this order type to dine-in?", vbQuestion + vbYesNo, "Confirm") = vbYes Then
                        Try
                            lblTypeID.Text = "1"
                            lblType.Text = "Dine-In"
                            lblType.ForeColor = Color.SeaGreen
                            btnSave.Text = "Save + Print"
                            btnUpdate.Enabled = True
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
                btnUpdate.Enabled = False
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
                            btnUpdate.Enabled = False
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
                    Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
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
            lblTotal.Text = "0.00"
            lblTotalBill.Text = "0.00"
            txtPaymentMode.Text = ""
            txtBillNo.Text = ""
            dgw.Rows.Clear()
            is_edit = False
            FlowLayoutPanel1.Controls.Clear()
            FlowLayoutPanel2.Controls.Clear()
        Else
            If MsgBox("Are you sure you want to cancel this order?", vbQuestion + vbYesNo, "Confirmation") = vbYes Then
                txtQty.Text = ""
                txtTableNo.Text = ""
                txtTicketNo.Text = ""
                lblType.Text = ""
                lblTypeID.Text = ""
                lblID.Text = ""
                lblTotal.Text = "0.00"
                lblTotalBill.Text = "0.00"
                dgw.Rows.Clear()
                is_edit = False
                FlowLayoutPanel1.Controls.Clear()
                FlowLayoutPanel2.Controls.Clear()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgw.Rows.Count > 0 Then
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
                    Dim st As String = "updated the item '" & dgw.SelectedCells.Item(0).Value & "' add quantity"
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

    Private Sub btnLess_Click(sender As Object, e As EventArgs) Handles btnLess.Click
        If dgw.Rows.Count > 0 Then
            If Val(dgw.SelectedCells.Item(2).Value) > 1 Then
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
                        Dim st As String = "updated the item '" & dgw.SelectedCells.Item(0).Value & "' less quantity"
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
                            'Insert function
                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb As String = "insert into Kitchen(KitchenName,Printer,IsEnabled) VALUES (@d1,@d2,@d3)"
                                cmd = New SqlCommand(cb)
                                cmd.Connection = con
                                'cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
                                'cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
                                'cmd.Parameters.AddWithValue("@d3", st2)
                                cmd.ExecuteReader()
                                con.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                            End Try
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

                    End If
                End If
            Else
                'Take-out
                If Trim(txtTicketNo.Text) = "" Then
                    MsgBox("Please create new ticket to settle this order list.", vbInformation + vbOKOnly, "Error ticket no")
                    Exit Sub
                Else
                    txtDiscPer.Text = ""
                    txtDiscAmt.Text = ""
                    txtDiscPer.ReadOnly = False
                    txtCash.ReadOnly = False
                    txtGrandTot.Text = toMoney(lblTotal.Text)
                    lblGrandTotal.Text = toMoney(lblTotal.Text)
                    txtCash.Text = ""
                    pnlPayment.BringToFront()
                    object_center(Me, pnlPayment)
                    pnlPayment.Show()
                    TabControl1.Enabled = False
                    txtCash.SelectionStart = 0
                    txtCash.SelectionLength = Len(txtCash.Text)
                    txtCash.SelectAll()
                End If

            End If
        End If
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Data_Load()

        Printer.NewPrint()

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
        Printer.Print(TransNo) ' Transaction No | Nomor transaksi
        Printer.Print(TransDate) ' Trans Date | Tanggal transaksi

        Printer.Print(" ") 'spacing
        Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
        arrWidth = {100, 40, 70, 70} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.TopRight, c.TopRight, c.TopRight} 'array alignment 

        'column header split by ; | nama kolom dipisah dengan ;
        Printer.Print("Item;Qty;Price;Subtotal", arrWidth, arrFormat)
        Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("----------------------------------------") 'line

        dblSubtotal = 0
        dblQty = 0
        'looping item sales | loop item penjualan
        For r = 0 To dtItem.Rows.Count - 1
            Printer.Print(dtItem.Rows(r).Item("Itemname") & ";" & dtItem.Rows(r).Item("Qty") & ";" &
                      toMoney(dtItem.Rows(r).Item("Price")) & ";" &
                      toMoney(dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price")), arrWidth, arrFormat)
            dblQty = dblQty + CSng(dtItem.Rows(r).Item("Qty"))
            dblSubtotal = dblSubtotal + (dtItem.Rows(r).Item("Qty") * dtItem.Rows(r).Item("Price"))
        Next

        Printer.Print("----------------------------------------")
        arrWidth = {130, 150} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.MidRight} 'array alignment 
        Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
        Printer.Print("Total;" & toMoney(dblSubtotal), arrWidth, arrFormat)
        Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("Payment;" & toMoney(txtCash.Text), arrWidth, arrFormat)
        Printer.Print("----------------------------------------")
        Printer.SetFont("Courier New", 9, FontStyle.Bold) 'Setting Font
        Printer.Print("Change;" & toMoney(txtCash.Text - dblSubtotal), arrWidth, arrFormat)
        Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        Printer.Print(" ")
        Printer.Print("Item Qty;" & dblQty, arrWidth, arrFormat)

        'Release the job for actual printing
        Printer.DoPrint()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtGrandTot.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        pnlPayment.SendToBack()
        pnlPayment.Hide()
        TabControl1.Enabled = True
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
            GetBilling()
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
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
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

#Region "Billing Buttons"

    Private Sub btnSettleBill_Click(sender As Object, e As EventArgs) Handles btnSettleBill.Click
        If dgwList.Rows.Count > 0 Then
            txtDiscPer.Text = ""
            txtDiscAmt.Text = ""
            txtDiscPer.ReadOnly = False
            txtCash.ReadOnly = False
            txtGrandTot.Text = toMoney(lblTotalBill.Text)
            lblGrandTotal.Text = toMoney(lblTotalBill.Text)
            txtCash.Text = ""
            pnlPayment.BringToFront()
            object_center(Me, pnlPayment)
            pnlPayment.Show()
            TabControl1.Enabled = False
            txtCash.SelectionStart = 0
            txtCash.SelectionLength = Len(txtCash.Text)
            txtCash.SelectAll()

        End If
    End Sub

    Private Sub btnNewBill_Click(sender As Object, e As EventArgs) Handles btnNewBill.Click
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
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGetDataBill_Click(sender As Object, e As EventArgs) Handles btnGetDataBill.Click

    End Sub

    Private Sub btnCancelBill_Click(sender As Object, e As EventArgs) Handles btnCancelBill.Click

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

    End Sub

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click

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
                Dim grnd As Double = toNumber(toNumber(lblGrandTotal.Text) - toNumber(txtDiscAmt.Text))
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
                txtDiscAmt.Text = ""
                txtGrandTot.Text = toMoney(lblGrandTotal.Text)
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
                txtChange.Text = toMoney(toNumber(txtCash.Text) - Val(toNumber(txtGrandTot.Text) - toNumber(txtDiscAmt.Text)))
            Else
                txtChange.Text = ""
            End If

        End If
    End Sub

    Private Sub txtCash_GotFocus(sender As Object, e As EventArgs) Handles txtCash.GotFocus
        txtCash.SelectionStart = 0
        txtCash.SelectionLength = Len(txtCash.Text)
        txtCash.SelectAll()
        FocusText = txtCash
    End Sub

#End Region

End Class