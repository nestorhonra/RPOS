Imports System.Data.SqlClient
Public Class frmRegistration
    Dim st1 As String
    Sub Reset()
        txtContactNo.Text = ""
        txtEmailID.Text = ""
        txtName.Text = ""
        txtPassword.Text = ""
        txtPIN.Text = ""
        txtUserID.Text = ""
        cmbUserType.SelectedIndex = -1
        chkActive.Checked = True
        txtUserID.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub DeleteRecord()
        Try
            If txtUserID.Text = "admin" Or txtUserID.Text = "Admin" Then
                MessageBox.Show("Admin account can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql2 As String = "select UserID from RestaurantPOS_BillingInfoEB,Registration where RestaurantPOS_BillingInfoEB.Operator=Registration.UserID and UserID=@d1"
            cmd = New SqlCommand(sql2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select UserID from RestaurantPOS_BillingInfoTA,Registration where RestaurantPOS_BillingInfoTA.Operator=Registration.UserID and UserID=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "select UserID from RestaurantPOS_BillingInfoHD,Registration where RestaurantPOS_BillingInfoHD.Operator=Registration.UserID and UserID=@d1"
            cmd = New SqlCommand(sql1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl4 As String = "select UserID from RestaurantPOS_OrderInfoKOT,Registration where RestaurantPOS_OrderInfoKOT.Operator=Registration.UserID and UserID=@d1"
            cmd = New SqlCommand(cl4)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl5 As String = "select UserID from RestaurantPOS_BillingInfoKOT,Registration where RestaurantPOS_BillingInfoKOT.Operator=Registration.UserID and UserID=@d1"
            cmd = New SqlCommand(cl5)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
       
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Registration where userid='" & txtUserID.Text & "'"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the user '" & txtUserID.Text & "'"
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

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(userid), RTRIM(UserType), RTRIM(Password), RTRIM(Name), RTRIM(EmailID), RTRIM(ContactNo),RTRIM(Active),JoiningDate from Registration order by JoiningDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), Decrypt(rdr(2)), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
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

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtUserID.Text = dr.Cells(0).Value.ToString()
                TextBox1.Text = dr.Cells(0).Value.ToString()
                cmbUserType.Text = dr.Cells(1).Value.ToString()
                txtPassword.Text = (dr.Cells(2).Value.ToString())
                txtPIN.Text = (dr.Cells(2).Value.ToString())
                txtName.Text = dr.Cells(3).Value.ToString()
                txtContactNo.Text = dr.Cells(5).Value.ToString()
                txtEmailID.Text = dr.Cells(4).Value.ToString()
                If dr.Cells(6).Value.ToString() = "Yes" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCheckAvailability_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckAvailability.Click
        If txtUserID.Text = "" Then
            MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserID.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select userid from registration where userid=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("User ID not available", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            Else
                MessageBox.Show("User ID available", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   


    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If txtUserID.Text = "" Then
                MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserID.Focus()
                Return
            End If
            If cmbUserType.Text = "" Then
                MessageBox.Show("Please select user type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbUserType.Focus()
                Return
            End If
            If txtPassword.Text = "" Then
                MessageBox.Show("Please enter pin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If
            If txtName.Text = "" Then
                MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Return
            End If
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            If txtPassword.Text <> txtPIN.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Password from registration where Password=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtPassword.Text))
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("PIN is already in used", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update registration set userid=@d1, usertype=@d2,Password=@d3,name=@d4,contactno=@d5,emailid=@d6,Active=@d8 where userid=@d7"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            cmd.Parameters.AddWithValue("@d2", cmbUserType.Text)
            cmd.Parameters.AddWithValue("@d3", Encrypt(txtPassword.Text.Trim()))
            cmd.Parameters.AddWithValue("@d4", txtName.Text)
            cmd.Parameters.AddWithValue("@d5", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d6", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d7", TextBox1.Text)
            cmd.Parameters.AddWithValue("@d8", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the user '" & txtUserID.Text & "' details"
            LogFunc(txtUserID.Text, st)
            lblUser.Text = txtUserID.Text
            MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you really want to delete this record?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtUserID.Text = "" Then
            MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserID.Focus()
            Return
        End If
        If cmbUserType.Text = "" Then
            MessageBox.Show("Please select user type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUserType.Focus()
            Return
        End If
        If txtPassword.Text = "" Then
            MessageBox.Show("Please enter pin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If txtName.Text = "" Then
            MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select userid from registration where userid=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("user id Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUserID.Text = ""
                txtUserID.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select password from registration where Password=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", Encrypt(txtPassword.Text))
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Pin is already in use for other user", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPassword.Text = ""
                txtPassword.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Registration(userid, UserType, Password, Name, ContactNo, EmailID,JoiningDate,Active) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            cmd.Parameters.AddWithValue("@d2", cmbUserType.Text)
            cmd.Parameters.AddWithValue("@d3", Encrypt(txtPassword.Text.Trim()))
            cmd.Parameters.AddWithValue("@d4", txtName.Text)
            cmd.Parameters.AddWithValue("@d5", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d6", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d7", Now)
            cmd.Parameters.AddWithValue("@d8", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new user '" & txtUserID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub dgw_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgw.CellFormatting
        If (e.ColumnIndex = 2) AndAlso e.Value IsNot Nothing Then
            dgw.Rows(e.RowIndex).Tag = e.Value
            e.Value = New [String]("●"c, e.Value.ToString().Length)
        End If
    End Sub

    Private Sub dgw_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgw.EditingControlShowing
        If dgw.CurrentCell.ColumnIndex = 2 Then
            'select target column
            Dim textBox As TextBox = TryCast(e.Control, TextBox)
            If textBox IsNot Nothing Then
                textBox.UseSystemPasswordChar = True
            End If
        Else
            Dim textBox As TextBox = TryCast(e.Control, TextBox)
            If textBox IsNot Nothing Then
                textBox.UseSystemPasswordChar = False
            End If
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPassword_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating
        If txtPassword.Text.Length < 4 Then
            MessageBox.Show("PIN must be of 4 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Text = ""
            Exit Sub
        End If
        If txtPassword.Text.Length > 4 Then
            MessageBox.Show("Only 4 digits pin is allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class
