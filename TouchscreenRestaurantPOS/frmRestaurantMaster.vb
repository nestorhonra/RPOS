Imports System.Data.SqlClient
Imports System.IO

Public Class frmRestaurantMaster
    Sub Reset()
        txtSTNo.Text = ""
        txtTIN.Text = ""
        txtEmailID.Text = ""
        txtContactNo.Text = ""
        txtHotelName.Text = ""
        txtCIN.Text = ""
        txtAddress.Text = ""
        PictureBox1.Image = My.Resources.hotel_icon
        PictureBox2.Image = My.Resources.hotel_icon
        txtBaseCurrency.Text = ""
        txtCurrencyCode.Text = ""
        txtHotelName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter restaurant name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        End If
        If txtAddress.Text = "" Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmailID.Text = "" Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select count(*) from Hotel Having count(*) >= 1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Record Already Exists" & vbCrLf & "please update the restautant info", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Hotel( HotelName, Address, ContactNo, EmailID, TIN, STNo, CIN, Logo,BaseCurrency,CurrencyCode,ReceiptLogo,isEnabled) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d5", txtTIN.Text)
            cmd.Parameters.AddWithValue("@d6", txtSTNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d9", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d10", txtCurrencyCode.Text)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d8", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            Dim ms1 As New MemoryStream()
            Dim bmpImage1 As New Bitmap(PictureBox2.Image)
            bmpImage1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data1 As Byte() = ms1.GetBuffer()
            Dim p1 As New SqlParameter("@d11", SqlDbType.Image)
            p1.Value = data1
            cmd.Parameters.Add(p1)
            cmd.Parameters.AddWithValue("@d12", changeOneZeroValue(chkIsEnabled.CheckState))
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the restaurant '" & txtHotelName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Restaurant Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter restaurant name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        End If
        If txtAddress.Text = "" Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmailID.Text = "" Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "update RestaurantPOS_BillingInfoEB set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtCcode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update RestaurantPOS_BillingInfoKOT set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtCcode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "update RestaurantPOS_BillingInfoTA set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtCcode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Hotel set HotelName=@d1, Address=@d2, ContactNo=@d3, EmailID=@d4, TIN=@d5, STNo=@d6, CIN=@d7, Logo=@d8,BaseCurrency=@d9,CurrencyCode=@d10, ReceiptLogo=@d11, isEnabled=@d12 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d5", txtTIN.Text)
            cmd.Parameters.AddWithValue("@d6", txtSTNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d9", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d10", txtCurrencyCode.Text)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d8", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            Dim ms1 As New MemoryStream()
            Dim bmpImage1 As New Bitmap(PictureBox2.Image)
            bmpImage1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data1 As Byte() = ms1.GetBuffer()
            Dim p1 As New SqlParameter("@d11", SqlDbType.Image)
            p1.Value = data1
            cmd.Parameters.Add(p1)
            cmd.Parameters.AddWithValue("@d12", changeOneZeroValue(chkIsEnabled.CheckState))
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the restaurant '" & txtHotelName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Restaurant Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN), Logo,RTRIM(BaseCurrency),RTRIM(CurrencyCode), ReceiptLogo, isEnabled from Hotel", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
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

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtHotelName.Text = dr.Cells(1).Value.ToString()
                txtAddress.Text = dr.Cells(2).Value.ToString()
                txtContactNo.Text = dr.Cells(3).Value.ToString()
                txtEmailID.Text = dr.Cells(4).Value.ToString()
                txtTIN.Text = dr.Cells(5).Value.ToString()
                txtSTNo.Text = dr.Cells(6).Value.ToString()
                txtCIN.Text = dr.Cells(7).Value.ToString()
                Dim data As Byte() = DirectCast(dr.Cells(8).Value, Byte())
                Dim ms As New MemoryStream(data)
                Me.PictureBox1.Image = Image.FromStream(ms)
                txtBaseCurrency.Text = dr.Cells(9).Value.ToString()
                txtCurrencyCode.Text = dr.Cells(10).Value.ToString()
                txtcCode.Text = dr.Cells(10).Value.ToString()
                Dim data1 As Byte() = DirectCast(dr.Cells(11).Value, Byte())
                Dim ms1 As New MemoryStream(data1)
                Me.PictureBox2.Image = Image.FromStream(ms1)
                chkIsEnabled.Checked = dr.Cells(12).Value
                btnUpdate.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
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

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
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
            Dim cq As String = "delete from Hotel where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the restaurant '" & txtHotelName.Text & "' info"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            With OpenFileDialog2
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog2.FileName = ""
            If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
                PictureBox2.Image = Image.FromFile(OpenFileDialog2.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub


End Class
