Imports System.Data.SqlClient
Imports System.IO

Public Class frmWallet
    Private Sub frmWallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(Wallet), Logo, Active from Wallets", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Reset()

        PictureBox1.Image = My.Resources.hotel_icon
        chkIsEnabled.Checked = False
        txtHotelName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter wallet name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        Else

            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select wallet from Wallets WHERE Wallet=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Record Already Exists" & vbCrLf & "please update the wallet info", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into Wallets(Wallet,Logo,Active) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
                cmd.Parameters.AddWithValue("@d3", changeOneZeroValue(chkIsEnabled.CheckState))
                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(PictureBox1.Image)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@d2", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                con.Close()
                Dim st As String = "added the wallet '" & txtHotelName.Text & "' info"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully saved", "Wallet Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                Getdata()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter restaurant name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        Else
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update Wallets set Wallet=@d1, Logo=@d2, Active=@d3 where ID=" & txtID.Text & ""
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
                Dim ms As New MemoryStream()
                Dim bmpImage As New Bitmap(PictureBox1.Image)
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@d2", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.Parameters.AddWithValue("@d3", changeOneZeroValue(chkIsEnabled.CheckState))
                cmd.ExecuteNonQuery()
                con.Close()
                Dim st As String = "updated the wallet '" & txtHotelName.Text & "' info"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully updated", "Wallet Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnUpdate.Enabled = False
                Getdata()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If
    End Sub
    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtHotelName.Text = dr.Cells(1).Value.ToString()

                Dim data As Byte() = DirectCast(dr.Cells(2).Value, Byte())
                Dim ms As New MemoryStream(data)
                Me.PictureBox1.Image = Image.FromStream(ms)


                chkIsEnabled.Checked = dr.Cells(3).Value
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
            Dim cq As String = "delete from Wallets where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the wallet '" & txtHotelName.Text & "' info"
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

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
End Class