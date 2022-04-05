Imports System.Data.SqlClient
Imports System.IO
Public Class frmItem
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillKitchen()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Kitchenname) FROM Kitchen order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbKitchen.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbKitchen.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbCategory.SelectedIndex = -1
        cmbKitchen.SelectedIndex = -1
        txtDiscount.Text = "0.00"
        txtRate.Text = ""
        txtSearchByDish.Text = ""
        txtItemName.Text = ""
        txtItemName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnUIColor.BackColor = Color.Gainsboro
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtItemName.Text)) = 0 Then
            MessageBox.Show("Please enter item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbKitchen.Text)) = 0 Then
            MessageBox.Show("Please select kitchen/section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbKitchen.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRate.Text)) = 0 Then
            MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRate.Focus()
            Exit Sub
        End If
        If txtDiscount.Text = "" Then
            MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscount.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select DishName from Dish where DishName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Item Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemName.Text = ""
                txtItemName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into Dish(DishName,Category,Rate,Discount,BackColor,Kitchen) VALUES (@d1,@d2," & txtRate.Text & "," & txtDiscount.Text & ",@d3,@d4)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d3", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d4", cmbKitchen.Text)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d8", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new item '" & txtItemName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtItemName.Text = ""
            txtDish.Text = ""
            Getdata()
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
            con = New SqlConnection(cs)
            con.Open()
            Dim sql4 As String = "select Dish.Dishname from Stock_Store_Join,Dish where Stock_Store_Join.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql4)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Store Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql3 As String = "select Dish.Dishname from Recipe,Dish where Recipe.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Recipe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql12 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillEB,Dish where RestaurantPOS_OrderedProductBillEB.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql12)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql11 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillHD,Dish where RestaurantPOS_OrderedProductBillHD.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql11)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillTA,Dish where RestaurantPOS_OrderedProductBillTA.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl6 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillKOT,Dish where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(cl6)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "select Dish.DishName from RestaurantPOS_OrderedProductKOT,Dish where RestaurantPOS_OrderedProductKOT.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl3 As String = "select Dish.DishName from TempRestaurantPOS_OrderedProductKOT,Dish where TempRestaurantPOS_OrderedProductKOT.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(cl3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Dish where DishName=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the item '" & txtItemName.Text & "'"
                LogFunc(lblUser.Text, st)
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtItemName.Text)) = 0 Then
                MessageBox.Show("Please enter item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtItemName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCategory.Text)) = 0 Then
                MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCategory.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbKitchen.Text)) = 0 Then
                MessageBox.Show("Please select kitchen/section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbKitchen.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRate.Focus()
                Exit Sub
            End If
            If txtDiscount.Text = "" Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscount.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Dish set DishName=@d1,Category=@d2,Rate=" & txtRate.Text & ",Discount=" & txtDiscount.Text & ",BackColor=@d4,Kitchen=@d5 where DishName=@d3"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d3", txtDish.Text)
            cmd.Parameters.AddWithValue("@d4", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d5", cmbKitchen.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the item '" & txtItemName.Text & "' details"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),RTRIM(Kitchen), RTRIM(Rate),RTRIM(Discount),BackColor from Dish order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
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

    Private Sub frmDish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillCombo()
        fillKitchen()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtItemName.Text = dr.Cells(0).Value.ToString()
                txtDish.Text = dr.Cells(0).Value.ToString()
                cmbCategory.Text = dr.Cells(1).Value.ToString()
                cmbKitchen.Text = dr.Cells(2).Value.ToString()
                txtRate.Text = dr.Cells(3).Value.ToString()
                txtDiscount.Text = dr.Cells(4).Value.ToString()
                Dim btnColor As Color = Color.FromArgb(dr.Cells(5).Value)
                btnUIColor.BackColor = btnColor
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRate.Text
            Dim selectionStart = Me.txtRate.SelectionStart
            Dim selectionLength = Me.txtRate.SelectionLength

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

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchByDish.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),RTRIM(Kitchen), RTRIM(Rate),RTRIM(Discount),BackColor from Dish where DishName like '%" & txtSearchByDish.Text & "%' order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscount.Text
            Dim selectionStart = Me.txtDiscount.SelectionStart
            Dim selectionLength = Me.txtDiscount.SelectionLength

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

    Private Sub btnAddCategory_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCategory.Click
        frmCategory.lblSet.Text = "Auto Refresh"
        frmCategory.Reset()
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            ' Show the color dialog.
            Dim result As DialogResult = ColorDialog1.ShowDialog()
            ' See if user pressed ok.
            If result = DialogResult.OK Then
                ' Set form background to the selected color.
                Me.btnUIColor.BackColor = ColorDialog1.Color
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class
