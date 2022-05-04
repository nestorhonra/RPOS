Imports System.Data.SqlClient
Public Class frmCustomerLedger
    Public cid As String
    Private Sub frmCustomerLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub

    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            If cid <> "" Then
                adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillID) FROM CustomerLedger WHERE C_ID = '" & cid & "' order by 1", CN)
            Else
                adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillID) FROM CustomerLedger ORDER by 1", CN)
            End If

            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ""
            If cid <> "" Then
                sql = "SELECT * FROM CustomerLedger WHERE C_ID = '" & cid & "' ORDER BY BillDate DESC"
            Else
                sql = "SELECT * FROM CustomerLedger ORDER BY BillDate DESC"
            End If
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(2), rdr(3), Trim(rdr(6)), toMoney(rdr(4).ToString), toMoney(rdr(5).ToString), Trim(rdr(7).ToString), changeYESNOValue(toNumber(rdr(8).ToString)), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ""
            If cid <> "" Then
                sql = "Select * FROM CustomerLedger WHERE C_ID = '" & cid & "' AND BillDate >=@d1 and BillDate < @d2 order by BillDate"
            Else
                sql = "Select * FROM CustomerLedger WHERE  BillDate >=@d1 and BillDate < @d2 order by BillDate"
            End If
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(2), rdr(3), Trim(rdr(5)), toMoney(rdr(4)), Trim(rdr(6).ToString), changeYESNOValue(toNumber(rdr(7).ToString)), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ""
            If cid <> "" Then
                sql = "Select * FROM CustomerLedger WHERE C_ID = '" & cid & "' AND BillID=@d1 order by BillDate"
            Else
                sql = "Select * FROM CustomerLedger BillID=@d1 order by BillDate"
            End If
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(2), rdr(3), Trim(rdr(5)), toMoney(rdr(4)), Trim(rdr(6).ToString), changeYESNOValue(toNumber(rdr(7).ToString)), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        GetData()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
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

    Private Sub cmbBillNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class