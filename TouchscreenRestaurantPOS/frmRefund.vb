Imports System.Data.SqlClient
Public Class frmRefund
    Dim is_new As Boolean = False
    Dim dateformat As String = "MM/dd/yyyy hh:mm tt"
    Private Sub frmRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtBillDate.Format = DateFormat.LongDate.ToString()
        dtBillDate.Value = CDate(Now().ToString(dateformat))
        Call CommandPass(True, False, True, False, False)
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

    Private Sub CommandPass(iNew As Boolean, iSave As Boolean, iSearch As Boolean, iDelete As Boolean, iCancel As Boolean)
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
        txtQty.Text = ""
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
        dgwList.Rows.Clear()
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

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        With frmRestaurantPOSKOTFinalBillRecord
            .frm = "frmRefund"
            .ShowDialog()
        End With
    End Sub
End Class