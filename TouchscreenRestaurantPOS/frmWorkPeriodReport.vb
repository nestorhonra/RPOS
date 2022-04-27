Imports System.Data.SqlClient
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmWorkPeriodReport
    Dim a, b As Decimal
    Sub Reset()
        cmbWorkPeriodStartTime.SelectedIndex = -1
        cmbWorkPeriodEndTime.Text = ""
        cmbWorkPeriodEndTime.Enabled = False
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Try
            If cmbWorkPeriodStartTime.Text = "" Then
                frmCustomDialog7.ShowDialog()
                cmbWorkPeriodStartTime.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2, adp3, adp4, adp5 As SqlDataAdapter
            Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5 As DataTable
            Dim StartDate As DateTime = DateTime.ParseExact(cmbWorkPeriodStartTime.Text, "MM/dd/yyyy hh:mm:ss tt", Nothing)
            Dim EndDate As DateTime = DateTime.ParseExact(cmbWorkPeriodEndTime.Text, "MM/dd/yyyy hh:mm:ss tt", Nothing)
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate <= @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate <= @d2 union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate <= @d2 Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate <= @d2"
            cmd5 = New SqlCommand(ct)
            cmd5.Parameters.Add("@d1", SqlDbType.DateTime).Value = StartDate
            cmd5.Parameters.Add("@d2", SqlDbType.DateTime).Value = EndDate
            cmd5.Connection = con
            rdr = cmd5.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * from Hotel", con)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT Operator,Sum(GrandTotal) as [GrandTotal] from(Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate <= @d2  Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate <= @d2 Union all Select Operator,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate <= @d2 Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate <= @d2)G  group by Operator order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime).Value = StartDate
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime).Value = EndDate
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("SELECT Category,Sum(TotalAmount) as Total from (Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d3 and BillDate <= @d4 UNION ALL Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d3 and BillDate <= @d4 UNION ALL Select category,(TotalAmount) as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d3 and BillDate <= @d4 Union all Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,Dish, RestaurantPOS_BillingInfoEB where RestaurantPOS_OrderedProductBillEB.Dish=Dish.Dishname and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d3 and BillDate <= @d4)C group by Category order by 1", con)
            cmd2.Parameters.Add("@d3", SqlDbType.DateTime).Value = StartDate
            cmd2.Parameters.Add("@d4", SqlDbType.DateTime).Value = EndDate
            adp2 = New SqlDataAdapter(cmd2)
            cmd3 = New SqlCommand("SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d5 and BillDate <= @d6 Union all Select category,Quantity from RestaurantPOS_OrderedProductBillEB,Dish, RestaurantPOS_BillingInfoEB where RestaurantPOS_OrderedProductBillEB.Dish=Dish.Dishname and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d5 and BillDate <= @d6)C group by Category order by 1", con)
            cmd3.Parameters.Add("@d5", SqlDbType.DateTime).Value = StartDate
            cmd3.Parameters.Add("@d6", SqlDbType.DateTime).Value = EndDate
            adp3 = New SqlDataAdapter(cmd3)
            cmd4 = New SqlCommand("SELECT Dish,Sum(Quantity) as [Quantity],Sum(TotalAmount) as [Amount] from (Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,RestaurantPOS_BillingInfoKOT where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID Union All Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,RestaurantPOS_BillingInfoTA where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID Union All Select Dish,Quantity,TotalAmount as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,RestaurantPOS_BillingInfoHD where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID Union all Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,RestaurantPOS_BillingInfoEB where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID)G  group by Dish order by 1", con)
            cmd4.Parameters.Add("@d7", SqlDbType.DateTime).Value = StartDate
            cmd4.Parameters.Add("@d8", SqlDbType.DateTime).Value = EndDate
            adp4 = New SqlDataAdapter(cmd4)
            cmd6 = New SqlCommand("SELECT PaymentMode,Sum(GrandTotal) as [GrandTotal] from (Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d11 and BillDate <= @d12 Union All Select  PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate <= @d12 Union All Select  PaymentMode,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d11 and BillDate <= @d12 Union all Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d11 and BillDate <= @d12)G  group by PaymentMode order by 1", con)
            cmd6.Parameters.Add("@d11", SqlDbType.DateTime).Value = StartDate
            cmd6.Parameters.Add("@d12", SqlDbType.DateTime).Value = EndDate
            adp5 = New SqlDataAdapter(cmd6)
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select IsNull(Sum(HomeDeliveryCharges),0) from RestaurantPOS_BillingInfoHD where BillDate >=@d9 and BillDate <= @d10"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.Add("@d9", SqlDbType.DateTime).Value = StartDate
            cmd.Parameters.Add("@d10", SqlDbType.DateTime).Value = EndDate
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "select IsNull(Sum(ParcelCharges*ExchangeRate),0) from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate <= @d12"
            cmd = New SqlCommand(ct2)
            cmd.Parameters.Add("@d11", SqlDbType.DateTime).Value = StartDate
            cmd.Parameters.Add("@d12", SqlDbType.DateTime).Value = EndDate
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b = rdr.GetValue(0)
            End If
            con.Close()
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            dtable3 = New DataTable()
            dtable4 = New DataTable()
            dtable5 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            adp3.Fill(dtable3)
            adp4.Fill(dtable4)
            adp5.Fill(dtable5)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.Tables.Add(dtable3)
            ds.Tables.Add(dtable4)
            ds.Tables.Add(dtable5)
            ds.WriteXmlSchema("WorkPeriod.xml")
            Dim rpt As New rptWorkPeriod
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.Subreports(2).SetDataSource(ds)
            rpt.Subreports(3).SetDataSource(ds)
            rpt.Subreports(4).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", StartDate)
            rpt.SetParameterValue("p2", EndDate)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", b)
            rpt.SetParameterValue("p5", a)
            rpt.SetParameterValue("p6", b)
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
    Sub fillWPStart()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText As String = "SELECT WpStart FROM WorkPeriodStart order by Wpstart desc"
            cmd = New SqlCommand(cmdText)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            Me.cmbWorkPeriodStartTime.Items.Clear()
            Do While rdr.Read()
                Dim dt As DateTime = rdr.GetDateTime(0)
                Me.cmbWorkPeriodStartTime.Items.Add(dt.ToString("MM/dd/yyyy hh:mm:ss tt"))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub frmWorkPeriodReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillWPStart()
    End Sub

    Private Sub cmbWorkPeriodStartTime_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbWorkPeriodStartTime.SelectedIndexChanged
        Try
            If cmbWorkPeriodStartTime.Text <> "" Then
                Dim StartDate As DateTime = DateTime.ParseExact(cmbWorkPeriodStartTime.Text, "MM/dd/yyyy hh:mm:ss tt", Nothing)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "SELECT WpEnd FROM WorkPeriodStart,WorkPeriodEnd where WorkPeriodStart.ID=WorkPeriodEnd.ID and WPStart like @d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = StartDate
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    cmbWorkPeriodEndTime.Text = rdr.GetDateTime(0).ToString("MM/dd/yyyy hh:mm:ss tt")
                Else
                    cmbWorkPeriodEndTime.Text = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
