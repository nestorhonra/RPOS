Imports System.Data.SqlClient
Public Class frmRefund
    Dim is_new As Boolean = False
    Dim dateformat As String = "MM/dd/yyyy hh:mm tt"
    Dim s_tag As Boolean = False
    Private Sub frmRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtBillDate.Format = DateFormat.LongDate.ToString()
        dtBillDate.Value = CDate(Now().ToString(dateformat))
        Call CommandPass(True, False, False, False, False)
        Call ClearAll()
        Call fillPaymentType()
    End Sub

    Sub fillPaymentType()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT  RTRIM(PaymentType) FROM PaymentType WHERE Active=1 order by PayID", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            dcPayment.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                dcPayment.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Public Sub CommandPass(iNew As Boolean, iSave As Boolean, iSearch As Boolean, iDelete As Boolean, iCancel As Boolean)
        btnNew.Enabled = iNew
        btnSave.Enabled = iSave
        btnSearch.Enabled = iSearch
        btnDelete.Enabled = iDelete
        btnCancel.Enabled = iCancel
    End Sub

    Private Sub ClearAll()
        txtBillNo.Text = ""
        dtBillDate.Value = CDate(Now())
        txtPaymentMode.Text = ""
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtDiscRem.Text = ""
        txtGrandTotal.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        txtTable.Text = ""
        txtOperator.Text = ""
        txtReference.Text = ""
        txtOSCA.Text = ""
        txtSeniorPer.Text = ""
        txtSeniorAmt.Text = ""
        txtTableNo.Text = ""
        txtItemName.Text = ""
        txtRate.Text = ""
        txtReason.Text = ""
        s_tag = True
        txtQty.Text = ""
        s_tag = False
        txtAmount.Text = ""
        txtTotalAmt.Text = ""
        txtVatPer.Text = ""
        txtVatAmt.Text = ""
        txtSCPer.Text = ""
        txtSCAmt.Text = ""
        txtSTPer.Text = ""
        txtSTAmt.Text = ""
        txtDicsPer.Text = ""
        txtDicsAmt.Text = ""
        lblID.Text = ""
        lblOP_ID.Text = ""
        lblQty.Text = ""
        dgwList.Rows.Clear()
        txtQty.ReadOnly = True
        txtReason.ReadOnly = True
    End Sub

    Public Sub GetData(ByVal billID As Integer)
        'MsgBox(billID.ToString)
        If billID > 0 Then
            'lblID.Text = Trim(billID)
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select * from RestaurantPOS_BillingInfoKOT WHERE ID='" & billID & "' order by BillDate"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgwList.Rows.Clear()
                While (rdr.Read() = True)
                    lblID.Text = toNumber(rdr("ID").ToString)
                    txtBillNo.Text = Trim(rdr("BillNo").ToString)
                    dtBillDate.Value = CDate(rdr("BillDate").ToString)
                    txtDiscPer.Text = toNumber(rdr("KOTDiscountPer").ToString)
                    txtGrandTotal.Text = toMoney(rdr("GrandTotal").ToString)
                    txtCash.Text = toMoney(rdr("Cash").ToString)
                    txtChange.Text = toMoney(rdr("Change").ToString)
                    txtOperator.Text = Trim(rdr("Operator").ToString)
                    txtPaymentMode.Text = Trim(rdr("PaymentMode").ToString)
                    txtDiscRem.Text = Trim(rdr("DiscountReason").ToString)
                    txtTable.Text = Trim(rdr("TableNo").ToString)
                    txtReference.Text = Trim(rdr("RefNo").ToString)
                    txtOSCA.Text = Trim(rdr("OSCANo").ToString)
                    txtSeniorAmt.Text = toMoney(rdr("SCDiscAmt").ToString)
                    txtSeniorPer.Text = toNumber(rdr("SCPer").ToString)
                    txtDiscAmt.Text = toMoney(rdr("DiscAmount").ToString)
                End While
                Call GetDataDetails(billID)
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GetDataDetails(ByVal billID As Integer)
        If billID > 0 Then
            dgwList.Rows.Clear()
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select * from RestaurantPOS_OrderedProductBillKOT WHERE BillID='" & billID & "' order by OP_ID"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgwList.Rows.Clear()
                While (rdr.Read() = True)
                    dgwList.Rows.Add(toNumber(rdr("OP_ID").ToString), Trim(rdr("Dish").ToString), toNumber(rdr("Rate").ToString), toNumber(rdr("Quantity").ToString), toNumber(rdr("Amount").ToString), toNumber(rdr("VATPer").ToString), toNumber(rdr("VATAmount").ToString), toNumber(rdr("STPer").ToString), toNumber(rdr("STAmount").ToString), toNumber(rdr("SCPer").ToString), toNumber(rdr("SCAmount").ToString), toNumber(rdr("DiscountPer").ToString), toNumber(rdr("DiscountAmount").ToString), toNumber(rdr("TotalAmount").ToString), Trim(rdr("TableNo").ToString))
                End While
                con.Close()
                Call CommandPass(False, True, False, False, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call ClearAll()
        is_new = True
        Call CommandPass(False, False, True, False, False)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        With frmRestaurantPOSKOTFinalBillRecord
            .frm = "frmRefund"
            .ShowDialog()
        End With
    End Sub

    Private Sub dgwList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwList.CellClick
        If dgwList.Rows.Count > 0 Then
            Dim sr As Integer = dgwList.SelectedCells(0).OwningRow.Index
            lblOP_ID.Text = toNumber(dgwList.Rows(sr).Cells(0).Value.ToString)
            txtItemName.Text = Trim(dgwList.Rows(sr).Cells(1).Value.ToString)
            txtRate.Text = toNumber(dgwList.Rows(sr).Cells(2).Value.ToString)
            lblQty.Text = toNumber(dgwList.Rows(sr).Cells(3).Value.ToString)
            s_tag = True
            txtQty.Text = toNumber(dgwList.Rows(sr).Cells(3).Value.ToString)
            s_tag = False
            txtAmount.Text = toNumber(dgwList.Rows(sr).Cells(4).Value.ToString)
            txtVatPer.Text = toNumber(dgwList.Rows(sr).Cells(5).Value.ToString)
            txtVatAmt.Text = toNumber(dgwList.Rows(sr).Cells(6).Value.ToString)
            txtSTPer.Text = toNumber(dgwList.Rows(sr).Cells(7).Value.ToString)
            txtSTAmt.Text = toNumber(dgwList.Rows(sr).Cells(8).Value.ToString)
            txtSCPer.Text = toNumber(dgwList.Rows(sr).Cells(9).Value.ToString)
            txtSCAmt.Text = toNumber(dgwList.Rows(sr).Cells(10).Value.ToString)
            txtDicsPer.Text = toNumber(dgwList.Rows(sr).Cells(11).Value.ToString)
            txtDicsAmt.Text = toNumber(dgwList.Rows(sr).Cells(12).Value.ToString)
            txtTotalAmt.Text = toNumber(dgwList.Rows(sr).Cells(13).Value.ToString)
            txtTableNo.Text = Trim(dgwList.Rows(sr).Cells(14).Value.ToString)
            txtReason.Text = ""
            txtQty.ReadOnly = False
            txtReason.ReadOnly = False
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Dim validChars As String = "0123456789-"
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        is_new = False
        Call ClearAll()
        Call CommandPass(True, False, False, False, False)
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        If s_tag = False Then
            If Trim(txtQty.Text) <> "" Then
                If toNumber(txtQty.Text) > toNumber(lblQty.Text) Then
                    MsgBox("Item quantity must not more than the billed quantity.", vbCritical + vbOKOnly, "Error quantity")
                    txtQty.Text = ""
                    Exit Sub
                Else
                    Call Recompute()
                End If
            End If
        End If
    End Sub

    Private Sub Recompute()
        Dim dishamt As Double = toNumber(txtRate.Text)
        Dim d_qty As Integer = Val(txtQty.Text)
        Dim amt As Double = toNumber(dishamt * d_qty)
        Dim disc As Double = toNumber(txtDicsPer.Text) / 100
        Dim discrate As Double = toNumber(txtDicsPer.Text)
        Dim discamt As Double = toNumber(amt * disc)
        Dim stamt As Double = Val(toNumber(amt - discamt) * (txtSTPer.Text / 100))
        Dim scamt As Double = Val(toNumber(amt - discamt) * (txtSCPer.Text / 100))
        Dim vatamat As Double = Val(toNumber(amt - discamt) * (txtVatPer.Text / 100))

        Dim totamt As Double = amt + stamt + scamt + vatamat
        'dgwList.SelectedCells.Item(2).Value = toNumber(d_qty)
        txtAmount.Text = toNumber(amt)

        txtVatAmt.Text = toNumber(vatamat)

        txtSTAmt.Text = toNumber(stamt)

        txtSCAmt.Text = toNumber(scamt)

        txtDicsAmt.Text = toNumber(discamt)
        txtTotalAmt.Text = toNumber(totamt)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtTotalAmt.Text) <> "" Then
            If is_new = True Then
                If Trim(txtReason.Text) <> "" Then
                    If toNumber(txtQty.Text) < 0 Then
                        If MsgBox("Are you sure you want to refund this item?" & vbNewLine & "This transaction cannot be revised afterwards.", vbQuestion + vbYesNo, "Confirm refund") = vbYes Then
                            'MsgBox("Insert Here " & lblOP_ID.Text)
                            Try

                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb3 As String = "INSERT INTO RefundItems (BillID,BillNo,BillDate,PaymentMode,Reason,OP_ID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,TableNo,EncodedBy,EntryDate) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
                                cmd = New SqlCommand(cb3)
                                cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                                cmd.Parameters.AddWithValue("@d2", toNumber(txtBillNo.Text))
                                cmd.Parameters.AddWithValue("@d3", CDate(dtBillDate.Value))
                                cmd.Parameters.AddWithValue("@d4", Trim(txtPaymentMode.Text))
                                cmd.Parameters.AddWithValue("@d5", Trim(txtReason.Text))
                                cmd.Parameters.AddWithValue("@d6", toNumber(lblOP_ID.Text))
                                cmd.Parameters.AddWithValue("@d7", Trim(txtItemName.Text))
                                cmd.Parameters.AddWithValue("@d8", toNumber(txtRate.Text))
                                cmd.Parameters.AddWithValue("@d9", toNumber(txtQty.Text))
                                cmd.Parameters.AddWithValue("@d10", toNumber(txtAmount.Text))
                                cmd.Parameters.AddWithValue("@d11", toNumber(txtVatPer.Text))
                                cmd.Parameters.AddWithValue("@d12", toNumber(txtVatAmt.Text))
                                cmd.Parameters.AddWithValue("@d13", toNumber(txtSTPer.Text))
                                cmd.Parameters.AddWithValue("@d14", toNumber(txtSTAmt.Text))
                                cmd.Parameters.AddWithValue("@d15", toNumber(txtSCPer.Text))
                                cmd.Parameters.AddWithValue("@d16", toNumber(txtSCAmt.Text))
                                cmd.Parameters.AddWithValue("@d17", toNumber(txtDicsPer.Text))
                                cmd.Parameters.AddWithValue("@d18", toNumber(txtDicsAmt.Text))
                                cmd.Parameters.AddWithValue("@d19", toNumber(txtTotalAmt.Text))
                                cmd.Parameters.AddWithValue("@d20", Trim(txtTableNo.Text))
                                cmd.Parameters.AddWithValue("@d21", Trim(lblUser.Text))
                                cmd.Parameters.AddWithValue("@d22", CDate(Now()))
                                cmd.Connection = con
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                Exit Sub
                            End Try
                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb3 As String = "INSERT INTO RestaurantPOS_OrderedProductBillKOT (BillID,Dish,Rate,Quantity,Amount,VATPer,VATAmount,STPer,STAmount,SCPer,SCAmount,DiscountPer,DiscountAmount,TotalAmount,TableNo) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                                cmd = New SqlCommand(cb3)
                                cmd.Parameters.AddWithValue("@d1", toNumber(txtBillNo.Text))
                                cmd.Parameters.AddWithValue("@d2", Trim(txtItemName.Text))
                                cmd.Parameters.AddWithValue("@d3", toNumber(txtRate.Text))
                                cmd.Parameters.AddWithValue("@d4", toNumber(txtQty.Text))
                                cmd.Parameters.AddWithValue("@d5", toNumber(txtAmount.Text))
                                cmd.Parameters.AddWithValue("@d6", toNumber(txtVatPer.Text))
                                cmd.Parameters.AddWithValue("@d7", toNumber(txtVatAmt.Text))
                                cmd.Parameters.AddWithValue("@d8", toNumber(txtSTPer.Text))
                                cmd.Parameters.AddWithValue("@d9", toNumber(txtSTAmt.Text))
                                cmd.Parameters.AddWithValue("@d10", toNumber(txtSCPer.Text))
                                cmd.Parameters.AddWithValue("@d11", toNumber(txtSCAmt.Text))
                                cmd.Parameters.AddWithValue("@d12", toNumber(txtDicsPer.Text))
                                cmd.Parameters.AddWithValue("@d13", toNumber(txtDicsAmt.Text))
                                cmd.Parameters.AddWithValue("@d14", toNumber(txtTotalAmt.Text))
                                cmd.Parameters.AddWithValue("@d15", Trim(txtTableNo.Text))
                                cmd.Connection = con
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                Exit Sub
                            End Try
                            Try
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb As String = "UPDATE RestaurantPOS_BillingInfoKOT SET GrandTotal = GrandTotal + @d2,Change = Change - @d2 WHERE ID = @d1"
                                cmd = New SqlCommand(cb)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", toNumber(lblID.Text))
                                cmd.Parameters.AddWithValue("@d2", toNumber(txtTotalAmt.Text))
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                Exit Sub
                            End Try
                            Dim st As String = "Refund made of '" & lblID.Text & "' Item '" & txtItemName.Text & "' with qty '" & txtQty.Text & "' amount '" & txtAmount.Text & "' by : " & lblUser.Text
                            LogFunc(lblUser.Text, st)
                            Call ClearAll()
                            is_new = False
                            dtBillDate.Value = CDate(Now().ToString(dateformat))
                            Call CommandPass(True, False, False, False, False)
                            MsgBox("Refund item is saved.", vbInformation + vbOKOnly, "Refund transaction Success")
                        End If
                    Else
                        MsgBox("Please enter negative quantiy to create refund.", vbCritical + vbOKOnly, "Error negative quantity")
                        txtQty.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("Please enter reason of refund.", vbCritical + vbOKOnly, "Error blank reason")
                    txtReason.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
End Class