Imports System.Data.SqlClient
Public Class frmStockTransfer
    Sub FillStore()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbKitchen.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbKitchen.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        dtpDate.Value = Today
        txtAvailableQty.Text = ""
        txtExpiryDate.Text = ""
        txtProductName.Text = ""
        txtSearchByProductName.Text = ""
        cmbKitchen.SelectedIndex = -1
        txtTransferQty.Text = ""
        txtWarehouse.Text = ""
        dgw.Rows.Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnPrint.Enabled = False
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        lblUnit.Visible = False
        lblQty.Text = ""
        lblSet.Text = ""
        Getdata()
        auto()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM StockTransfer ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtID.Text = GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            If Len(Trim(cmbKitchen.Text)) = 0 Then
                MessageBox.Show("Please select store", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbKitchen.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgw.Rows
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT qty from Temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3", con)
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    lblQty.Text = ds.Tables(0).Rows(0)("Qty")
                    If Val(row.Cells(4).Value) > Val(lblQty.Text) Then
                        MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of Product name '" & row.Cells(2).Value & "' from Warehouse '" & row.Cells(0).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                con.Close()
            Next
            For Each row As DataGridViewRow In dgw.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into StockTransfer(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into StockTransfer_Join(StockTransferID,Warehouse,ProductID,ExpiryDate,Qty) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next

            LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtID.Text & "'")
            MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            Getdata()
            btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you really want to delete this record?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            For Each row As DataGridViewRow In dgw.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from StockTransfer where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LogFunc(lblUser.Text, "Deleted the Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductName),RTRIM(Unit),RTRIM(ExpiryDate),Qty from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Qty > 0 order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        FillStore()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtWarehouse.Text = dr.Cells(0).Value.ToString()
                txtProductID.Text = dr.Cells(1).Value.ToString()
                txtProductName.Text = dr.Cells(2).Value.ToString()
                lblUnit.Visible = True
                lblUnit.Text = dr.Cells(3).Value.ToString()
                txtExpiryDate.Text = dr.Cells(4).Value.ToString()
                txtAvailableQty.Text = dr.Cells(5).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
    Sub Clear()
        txtWarehouse.Text = ""
        txtProductName.Text = ""
        txtProductID.Text = ""
        txtExpiryDate.Text = ""
        txtAvailableQty.Text = ""
        txtTransferQty.Text = ""
        btnRemove.Enabled = False
        lblUnit.Visible = False
    End Sub

    Private Sub btnRemoveFromGridOS_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If dgw.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgw.SelectedRows
                    dgw.Rows.Remove(row)
                Next
                btnRemove.Enabled = False
                Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddOS_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtWarehouse.Text = "" Then
                MessageBox.Show("Please retrieve warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtWarehouse.Focus()
                Exit Sub
            End If
            If txtTransferQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtTransferQty.Text) = 0 Then
                MessageBox.Show("Transferred quantity must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtAvailableQty.Text) < Val(txtTransferQty.Text) Then
                MessageBox.Show("Transferred quantity must be less than available quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If txtExpiryDate.Text <> "" Then
                For Each row As DataGridViewRow In dgw.Rows
                    If txtWarehouse.Text = row.Cells(0).Value And txtProductID.Text = Val(row.Cells(1).Value) And txtExpiryDate.Text = row.Cells(3).Value Then
                        row.Cells(0).Value = txtWarehouse.Text
                        row.Cells(1).Value = Val(txtProductID.Text)
                        row.Cells(2).Value = txtProductName.Text
                        row.Cells(3).Value = txtExpiryDate.Text
                        row.Cells(4).Value += Val(txtTransferQty.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
            End If
            If txtExpiryDate.Text = "" Then
                For Each row As DataGridViewRow In dgw.Rows
                    If txtWarehouse.Text = row.Cells(0).Value And txtProductID.Text = Val(row.Cells(1).Value) And txtExpiryDate.Text = "" Then
                        row.Cells(0).Value = txtWarehouse.Text
                        row.Cells(1).Value = Val(txtProductID.Text)
                        row.Cells(2).Value = txtProductName.Text
                        row.Cells(3).Value = txtExpiryDate.Text
                        row.Cells(4).Value += Val(txtTransferQty.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
            End If
            dgw.Rows.Add(txtWarehouse.Text, Val(txtProductID.Text), txtProductName.Text, txtExpiryDate.Text, Val(txtTransferQty.Text))
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearchByProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductName),RTRIM(Unit),RTRIM(ExpiryDate),Qty from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Productname like '%" & txtSearchByProductName.Text & "%' and Qty > 0 order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTransferQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTransferQty.Text
            Dim selectionStart = Me.txtTransferQty.SelectionStart
            Dim selectionLength = Me.txtTransferQty.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmStockTransferRecord.Reset()
        frmStockTransferRecord.ShowDialog()
    End Sub

    Private Sub dgw_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        If dgw.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptStockTransferInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT StockTransfer.ST_ID, StockTransfer.Date, StockTransfer.Kitchen, StockTransfer_Join.STJ_ID, StockTransfer_Join.StockTransferID, StockTransfer_Join.Warehouse, StockTransfer_Join.ProductID,StockTransfer_Join.ExpiryDate, StockTransfer_Join.Qty, Product.PID, Product.ProductCode, Product.ProductName, Product.Category, Product.Description, Product.Unit, Product.Price, Product.ReorderPoint FROM StockTransfer INNER JOIN StockTransfer_Join ON StockTransfer.ST_ID = StockTransfer_Join.StockTransferID INNER JOIN Product ON StockTransfer_Join.ProductID = Product.PID where ST_ID=" & Val(txtID.Text) & " order by StockTransfer.Date"
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
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
