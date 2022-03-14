Imports System.Data.SqlClient

Imports System.IO

Public Class frmPurchaseRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, DiscountPer, Discount, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Purchase" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmPurchase.Reset()
                    frmPurchase.Show()
                    Me.Hide()
                    frmPurchase.txtST_ID.Text = dr.Cells(0).Value.ToString()
                    frmPurchase.txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmPurchase.dtpDate.Text = dr.Cells(2).Value.ToString()
                    frmPurchase.cmbPurchaseType.Text = dr.Cells(3).Value.ToString()
                    frmPurchase.txtSup_ID.Text = dr.Cells(4).Value.ToString()
                    frmPurchase.txtSupplierID.Text = dr.Cells(5).Value.ToString()
                    frmPurchase.txtSupplierName.Text = dr.Cells(6).Value.ToString()
                    frmPurchase.txtSubTotal.Text = dr.Cells(7).Value.ToString()
                    frmPurchase.txtDiscPer.Text = dr.Cells(8).Value.ToString()
                    frmPurchase.txtDisc.Text = dr.Cells(9).Value.ToString()
                    frmPurchase.txtFreightCharges.Text = dr.Cells(10).Value.ToString()
                    frmPurchase.txtOtherCharges.Text = dr.Cells(11).Value.ToString()
                    frmPurchase.txtPreviousDue.Text = dr.Cells(12).Value.ToString()
                    frmPurchase.txtTotal.Text = dr.Cells(13).Value.ToString()
                    frmPurchase.txtRoundOff.Text = dr.Cells(14).Value.ToString()
                    frmPurchase.txtGrandTotal.Text = dr.Cells(15).Value.ToString()
                    frmPurchase.txtTotalPaid.Text = dr.Cells(16).Value.ToString()
                    frmPurchase.txtBalance.Text = dr.Cells(17).Value.ToString()
                    frmPurchase.txtRemarks.Text = dr.Cells(18).Value.ToString()
                    frmPurchase.btnSave.Enabled = False
                    frmPurchase.DataGridView1.Enabled = True
                    frmPurchase.btnAdd.Enabled = False
                    frmPurchase.btnRemove.Enabled = False
                    frmPurchase.lblSet.Text = "Not Allowed"
                    frmPurchase.pnlCalc.Enabled = False
                    frmPurchase.GetSupplierBalance1()
                    frmPurchase.btnDelete.Enabled = True
                    frmPurchase.GetSupplierInfo()
                    frmPurchase.btnSelection.Enabled = False
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT PID, RTRIM(Productname),RTRIM(Warehouse),Qty,Purchase_Join.Price,TotalAmount,RTRIM(HasExpiryDate),RTRIM(ExpiryDate) from Purchase,Purchase_Join,Product where Purchase.ST_ID=Purchase_Join.PurchaseID and Purchase_Join.ProductID=Product.PID and ST_ID=" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmPurchase.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmPurchase.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
                    End While
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()
        txtSupplierName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        Getdata()
    End Sub



    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, DiscountPer, Discount, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID  and [Name] like '%" & txtSupplierName.Text & "%' order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, DiscountPer, Discount, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID  and [Date] between @d1 and @d2 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
