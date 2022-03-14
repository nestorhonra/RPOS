Imports System.Data.SqlClient

Public Class frmAccountingReport
    Dim a As Decimal
    Dim d, b, c As String
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker3.Value = Today
        cmbSupplierName.Text = ""
    End Sub
    Sub fillSupplier()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT RTRIM(Name) FROM Supplier", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbSupplierName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbSupplierName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchaseDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select * from Purchase where Date Between @d2 and @d3 and PurchaseType='Credit'"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID,Date,InvoiceNo,Name,SubTotal,Discount,FreightCharges,OtherCharges,PreviousDue,GrandTotal from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID and PurchaseType='Credit' order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("PurchaseDayBook.xml")
            Dim rpt As New rptPurchaseDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralLedger.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 order by Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GeneralLedger.xml")
            Dim rpt As New rptGeneralLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupplierLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnSupplierLedger.Click
        Try
            If Len(Trim(cmbSupplierName.Text)) = 0 Then
                MessageBox.Show("Please Select Supplier Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSupplierName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from SupplierLedgerBook where PartyID=@d3 and Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from SupplierLedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("SupplierLedger.xml")
            Dim rpt As New rptSupplierLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker3.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("p3", txtSupplierID.Text)
            rpt.SetParameterValue("p4", cmbSupplierName.Text)
            rpt.SetParameterValue("p5", d)
            rpt.SetParameterValue("p6", b)
            rpt.SetParameterValue("p7", c)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTrialBalance_Click(sender As System.Object, e As System.EventArgs) Handles btnTrialBalance.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Name,CASE WHEN (Sum(Debit)-Sum(Credit))<= 0 THEN 0 ELSE (Sum(Debit)-Sum(Credit)) END AS Debit,CASE WHEN (Sum(Credit)-Sum(Debit))<= 0 THEN 0 ELSE (Sum(Credit)-Sum(debit)) END AS Credit from LedgerBook where Date >=@d1 and Date < @d2 Group By Name order by Name", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("TrialBalanceAccounting.xml")
            Dim rpt As New rptTrialBalance
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from Purchase where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptPurchase 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Supplier.ID, Supplier.SupplierID, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Purchase.ST_ID, Purchase.InvoiceNo,Purchase.Date,Purchase.Supplier_ID, Purchase.PurchaseType, Purchase.SubTotal, Purchase.DiscountPer, Purchase.Discount, Purchase.PreviousDue, Purchase.FreightCharges, Purchase.OtherCharges, Purchase.Total, Purchase.RoundOff, Purchase.GrandTotal, Purchase.TotalPayment, Purchase.PaymentDue, Purchase_Join.SP_ID, Purchase_Join.PurchaseID, Purchase_Join.ProductID, Purchase_Join.Qty, Purchase_Join.HasExpiryDate,ExpiryDate, Purchase_Join.Price, Purchase_Join.TotalAmount, Product.PID, Product.ProductCode,Product.Unit, Product.ProductName, Product.Category,Product.Description FROM Supplier INNER JOIN Purchase ON Supplier.ID = Purchase.Supplier_ID INNER JOIN Purchase_Join ON Purchase.ST_ID = Purchase_Join.PurchaseID INNER JOIN Product ON Purchase_Join.ProductID = Product.PID where Purchase.date between @d1 and @d2 order by Purchase.Date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Supplier")
            myDA.Fill(myDS, "Purchase")
            myDA.Fill(myDS, "Purchase_Join")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPayment_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnVouchers_Click(sender As System.Object, e As System.EventArgs) Handles btnVouchers.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from Voucher where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptExpenses 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where date between @d1 and @d2 order by date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Voucher")
            myDA.Fill(myDS, "Voucher_OtherDetails")
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select ISNULL(sum(GrandTotal),0) from Voucher where Date between @d1 and @d2"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSupplierName.SelectedIndexChanged
        Try
            d = ""
            b = ""
            c = ""
            txtSupplierID.Text = ""
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(SupplierID),RTRIM(Address),RTRIM(City),RTRIM(ContactNo) FROM Supplier WHERE Name=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbSupplierName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtSupplierID.Text = rdr.GetValue(0)
                d = rdr.GetValue(1)
                b = rdr.GetValue(2)
                c = rdr.GetValue(3)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnGeneralDaybook_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date between @d1 and @d2 order by LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GeneralDayBook.xml")
            Dim rpt As New rptGeneralDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAccountingReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillSupplier()
    End Sub

    Private Sub btnMenuItems_Click(sender As System.Object, e As System.EventArgs) Handles btnMenuItems.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptMenuItems 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Category.CategoryName, Category.VAT, Category.ST, Dish.DishName, Dish.Category, Dish.Rate, Dish.Discount FROM Category INNER JOIN Dish ON Category.CategoryName = Dish.Category order by Category.CategoryName,DishName"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Category")
            myDA.Fill(myDS, "Dish")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCreditors_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditors.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Supplier.SupplierID, Supplier.Name, Supplier.City, Supplier.ContactNo,Pur.SP-Pay.SPay FROM Supplier LEFT OUTER JOIN(Select Supplier_ID,IsNULL(Sum(PaymentDue)-Sum(PreviousDue),0) as SP from Purchase group by Supplier_ID) Pur ON Supplier.ID = Pur.Supplier_ID Inner JOIN (Select SupplierID,IsNULL(Sum(Amount),0) as SPay from Payment group by SupplierID) Pay ON Supplier.ID = Pay.SupplierID where Pur.SP-Pay.SPay > 0  ORDER BY Supplier.Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Creditors.xml")
            Dim rpt As New rptCreditors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStockIN_Click(sender As System.Object, e As System.EventArgs) Handles btnStockIN.Click
        frmStockInRecord.Reset()
        frmStockInRecord.ShowDialog()
    End Sub

    Private Sub btnStockOut_Click(sender As System.Object, e As System.EventArgs) Handles btnStockOut.Click
        frmStockOUTRecord.Reset()
        frmStockOUTRecord.ShowDialog()
    End Sub

    Private Sub btnLowStock_Click(sender As System.Object, e As System.EventArgs) Handles btnLowStock.Click
        frmLowStockRecord.Reset()
        frmLowStockRecord.ShowDialog()
    End Sub

    Private Sub btnExpiredProducts_Click(sender As System.Object, e As System.EventArgs) Handles btnExpiredProducts.Click
        frmExpiredProductsRecord.Reset()
        frmExpiredProductsRecord.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from StockTransfer where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptStockTransfer 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT StockTransfer.ST_ID, StockTransfer.Date, StockTransfer.kitchen, StockTransfer_Join.STJ_ID, StockTransfer_Join.StockTransferID, StockTransfer_Join.Warehouse, StockTransfer_Join.ProductID,StockTransfer_Join.ExpiryDate, StockTransfer_Join.Qty, Product.PID, Product.ProductCode, Product.ProductName, Product.Category, Product.Description, Product.Unit, Product.Price, Product.ReorderPoint FROM StockTransfer INNER JOIN StockTransfer_Join ON StockTransfer.ST_ID = StockTransfer_Join.StockTransferID INNER JOIN Product ON StockTransfer_Join.ProductID = Product.PID where StockTransfer.date between @d1 and @d2 order by StockTransfer.Date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "StockTransfer")
            myDA.Fill(myDS, "StockTransfer_Join")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStoreStockIN_Click(sender As System.Object, e As System.EventArgs) Handles btnStoreStockIN.Click
        frmStockIn_StoreRecord.Reset()
        frmStockIn_StoreRecord.ShowDialog()
    End Sub

    Private Sub btnStoreStockOUT_Click(sender As System.Object, e As System.EventArgs) Handles btnStoreStockOUT.Click
        frmStockOUT_StoreRecord.Reset()
        frmStockOUT_StoreRecord.ShowDialog()
    End Sub
End Class
