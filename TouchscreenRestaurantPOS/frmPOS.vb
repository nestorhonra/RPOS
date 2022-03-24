Imports System.Data.SqlClient
Public Class frmPOS
    Dim rowIndex As Integer
    Dim table As New DataTable("table")
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Public is_edit As Boolean = False
    Dim s, x As String
    Dim srvTax, srvChrge, srvVat As Double
    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblType.Text = ""
        lblTypeID.Text = ""
        txtTableNo.Text = ""
        txtTicketNo.Text = ""
        txtQty.Text = ""
        lblTotal.Text = ""
        lblID.Text = ""
        is_edit = False
        'Call FillCategory()
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
                    lblTypeID.Text = toNumber(rdr(9))
                    Call GetOrderList(toNumber(rdr(0)))
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
                        Dim amt As Double = toNumber(rdr(2) * d_qty)
                        Dim disc As Double = toNumber(rdr(3)) / 100
                        Dim discamt As Double = toNumber(amt * disc)
                        Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
                        Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
                        Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))

                        Dim totamt As Double = amt + stamt + scamt + vatamat

                        rowId = dgw.Rows.Add(Trim(rdr(0)), Trim(rdr(2)), d_qty, "", "0", amt, srvVat, vatamat, srvTax, stamt, srvChrge, scamt, disc, discamt, totamt)
                        dgw.CurrentCell = dgw.Rows(rowId).Cells(0)
                        dgw.Focus()

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
        If is_edit = False Then

        Else

        End If
    End Sub

#End Region

#Region "Button Cliked"

    Private Sub btnDinein_Click(sender As Object, e As EventArgs) Handles btnDinein.Click
        If txtTicketNo.Text <> "" Then
            lblTypeID.Text = "1"
            lblType.Text = "Dine-In"
            lblType.ForeColor = Color.SeaGreen
        End If
    End Sub

    Private Sub btnTakeout_Click(sender As Object, e As EventArgs) Handles btnTakeout.Click
        If txtTicketNo.Text <> "" Then
            lblTypeID.Text = "0"
            lblType.Text = "Take-Out"
            lblType.ForeColor = Color.Crimson
        End If
    End Sub

    Private Sub btnNewTicket_Click(sender As Object, e As EventArgs) Handles btnNewTicket.Click
        If txtTicketNo.Text <> "" Then
            MsgBox("Save the current ticket transaction or hold to create new ticket.", vbCritical + vbOKOnly, "Error create ticket")
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
                    txtTicketNo.Text = Format(rdr(0).ToString + 1, "000000")
                    is_edit = False
                    lblTotal.Text = toMoney("0")
                    lblType.Text = ""
                    lblTypeID.Text = ""
                    txtTableNo.Text=  ""
                    txtQty.Text = ""
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
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgw.Rows.Count > 0 Then
            Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
            Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value) + 1
            Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
            Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
            Dim discamt As Double = toNumber(amt * disc)
            Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
            Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
            Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))

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

            If is_edit = True Then
                'Update value qty here

            End If
        End If
    End Sub

    Private Sub btnLess_Click(sender As Object, e As EventArgs) Handles btnLess.Click
        If dgw.Rows.Count > 0 Then
            If Val(dgw.SelectedCells.Item(2).Value) > 1 Then
                Dim OP_ID As Integer = toNumber(dgw.SelectedCells.Item(4).Value)
                Dim d_qty As Integer = Val(dgw.SelectedCells.Item(2).Value) - 1
                Dim amt As Double = toNumber(dgw.SelectedCells.Item(1).Value * d_qty)
                Dim disc As Double = toNumber(dgw.SelectedCells.Item(12).Value) / 100
                Dim discamt As Double = toNumber(amt * disc)
                Dim stamt As Double = Val(toNumber(amt - discamt) * (srvTax / 100))
                Dim scamt As Double = Val(toNumber(amt - discamt) * (srvChrge / 100))
                Dim vatamat As Double = Val(toNumber(amt - discamt) * (srvVat / 100))

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

                If is_edit = True Then
                    'Update value qty here
                End If

            End If

        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If is_edit = True Then
                If MsgBox("Are you sure you want to remove this item in current order?", vbQuestion + vbYesNo, "Confirm remove") = vbYes Then
                    'Update value qty here
                    Dim RowsAffected As Integer = 0
                    Dim op_id As Integer = toNumber(dgw.SelectedCells(4).Value.ToString)
                    Dim itemname As String = Trim(dgw.SelectedCells(0).Value.ToString)
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cq As String = "delete from RestaurantPOS_OrderedProductKOT where OP_ID=@d1 AND TicketID=@d2"
                    cmd = New SqlCommand(cq)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", op_id)
                    cmd.Parameters.AddWithValue("@d2", toNumber(lblID.Text))
                    RowsAffected = cmd.ExecuteNonQuery()
                    If RowsAffected > 0 Then
                        Dim st As String = "deleted the item '" & itemname & "'"
                        LogFunc(lblUser.Text, st)
                        MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgw.Rows.RemoveAt(rowIndex)
                    Else
                        MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Call ComputeTotal()
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
            Call ComputeTotal()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If is_edit = True Then

        Else
            If MsgBox("Are you sure you want to cancel this order?", vbQuestion + vbYesNo, "Confirmation") = vbYes Then
                txtQty.Text = ""
                txtTableNo.Text = ""
                txtTicketNo.Text = ""
                lblType.Text = ""
                lblTypeID.Text = ""
                dgw.Rows.Clear()
                is_edit = False
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnChgTable_Click(sender As Object, e As EventArgs) Handles btnChgTable.Click
        With frmTablesList
            .frm = "frmPOS"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnOpenTicket_Click(sender As Object, e As EventArgs) Handles btnOpenTicket.Click
        If is_edit = False Then
            With frmOpenTicketList
                .frm = "frmPOS"
                .ShowDialog()
            End With
        End If
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
            btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            'Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
            'btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Flat
            btn.Width = 100
            btn.Height = 50
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'UserButtons.Add(btn)
            FlowLayoutPanel3.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.btnCategory_Click
        Loop
        con.Close()
    End Sub

End Class