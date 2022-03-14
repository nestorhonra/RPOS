Imports System.Data.SqlClient
Public Class frmChangePassword
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim RowsAffected As Integer = 0
            If Len(Trim(UserID.Text)) = 0 Then
                MessageBox.Show("Please enter user id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UserID.Focus()
                Exit Sub
            End If
            If Len(Trim(OldPassword.Text)) = 0 Then
                MessageBox.Show("Please enter old pin", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                OldPassword.Focus()
                Exit Sub
            End If
            If Len(Trim(NewPassword.Text)) = 0 Then
                MessageBox.Show("Please enter new pin", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                NewPassword.Focus()
                Exit Sub
            End If
            If Len(Trim(ConfirmPassword.Text)) = 0 Then
                MessageBox.Show("Please confirm new pin", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ConfirmPassword.Focus()
                Exit Sub
            End If
            If NewPassword.Text <> ConfirmPassword.Text Then
                MessageBox.Show("PIN do not match", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                NewPassword.Text = ""
                OldPassword.Text = ""
                ConfirmPassword.Text = ""
                OldPassword.Focus()
                Exit Sub
            ElseIf OldPassword.Text = NewPassword.Text Then
                MessageBox.Show("PIN is same..Re-enter new pin", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                NewPassword.Text = ""
                ConfirmPassword.Text = ""
                NewPassword.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select password from registration where Password=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", Encrypt(NewPassword.Text))
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("PIN is already in use for other user", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                NewPassword.Text = ""
                ConfirmPassword.Text = ""
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim co As String = "update Registration set password =@d1 where userid=@d2 and password =@d3"
            cmd = New SqlCommand(co)
            cmd.Parameters.AddWithValue("@d1", Encrypt(NewPassword.Text))
            cmd.Parameters.AddWithValue("@d2", UserID.Text)
            cmd.Parameters.AddWithValue("@d3", Encrypt(OldPassword.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "Successfully changed the pin"
                LogFunc(UserID.Text, st)
                frmCustomDialog5.ShowDialog()
                Me.Hide()
                frmLogin.Show()
                frmLogin.UserID.Text = ""
                frmLogin.Password.PasswordChar = ""
                frmLogin.Password.Text = "ENTER PIN"
                frmLogin.UserID.Focus()
            Else

                MessageBox.Show("invalid user name or pin", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UserID.Text = ""
                NewPassword.Text = ""
                OldPassword.Text = ""
                ConfirmPassword.Text = ""
                UserID.Focus()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub OSKeyboard()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub
    Private Sub frmChangePassword1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub

    Private Sub frmChangePassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Panel1.Anchor = AnchorStyles.None
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.PasswordChar = ""
        frmLogin.Password.Text = "ENTER PIN"
        frmLogin.UserID.Focus()
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        OSKeyboard()
    End Sub

    Private Sub OldPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles OldPassword.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NewPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NewPassword.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ConfirmPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ConfirmPassword.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub OldPassword_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OldPassword.Validating
        If OldPassword.Text.Length < 4 Then
            MessageBox.Show("Old PIN must be of 4 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OldPassword.Text = ""
            OldPassword.Focus()
            Exit Sub
        End If
        If OldPassword.Text.Length > 4 Then
            MessageBox.Show("Only 4 digits pin is allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OldPassword.Text = ""
            OldPassword.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub NewPassword_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NewPassword.Validating
        If NewPassword.Text.Length < 4 Then
            MessageBox.Show("New PIN must be of 4 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            NewPassword.Text = ""
            NewPassword.Focus()
            Exit Sub
        End If
        If NewPassword.Text.Length > 4 Then
            MessageBox.Show("Only 4 digits pin is allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            NewPassword.Text = ""
            NewPassword.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub ConfirmPassword_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConfirmPassword.Validating
        If ConfirmPassword.Text.Length < 4 Then
            MessageBox.Show("Confirm PIN must be of 4 digits", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ConfirmPassword.Text = ""
            ConfirmPassword.Focus()
            Exit Sub
        End If
        If ConfirmPassword.Text.Length > 4 Then
            MessageBox.Show("Only 4 digits pin is allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ConfirmPassword.Text = ""
            ConfirmPassword.Focus()
            Exit Sub
        End If
    End Sub
   
End Class