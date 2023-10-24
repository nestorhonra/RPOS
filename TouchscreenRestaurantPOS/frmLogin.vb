Imports System.Data.SqlClient
Imports System.IO
Public Class frmLogin
    Dim frm As New frmOption
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Dim Img As Image
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where Password=@d1 and Active='Yes' and UserType in('Admin','Cashier')"
            cmd.Parameters.AddWithValue("@d1", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                UserID.Text = rdr.GetValue(0)
                If Encrypt(Password.Text).Trim = rdr.GetValue(1).trim Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
                    cmd.Parameters.AddWithValue("@d3", UserID.Text)
                    cmd.Parameters.AddWithValue("@d4", Encrypt(Password.Text))
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        UserType.Text = rdr.GetValue(0).ToString.Trim
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If

                    If (UserType.Text = "Admin") Then
                        frm.lblUser.Text = UserID.Text
                        frm.lblUserType.Text = UserType.Text
                        frm.btnBackOffice.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frm.Show()
                    Else
                        frmFrontOffice.lblUser.Text = UserID.Text
                        frmFrontOffice.lblUserType.Text = UserType.Text
                        frmFrontOffice.Show()
                        Me.Hide()
                    End If
                End If
            Else
                Password.PasswordChar = ""
                Password.Text = "ENTER PIN"
            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub


    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Panel1.Anchor = AnchorStyles.None
        Panel2.Width = Me.Width
        Call Getdata()
        'Password.Text = Decrypt("MDcyOA==")
        MsgBox(Decrypt("QkZFQkZCRkYwMDBBMDY1Mw==").ToString)
    End Sub

    Private Sub frmLogin_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN), Logo,RTRIM(BaseCurrency),RTRIM(CurrencyCode) from Hotel", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read Then

                Dim data As Byte() = DirectCast(rdr(8), Byte())
                Dim ms As New MemoryStream(data)
                Img = Image.FromStream(ms)
                PictureBox1.Image = Img
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        s = Password.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        Password.Text = x
        x = ""
    End Sub
    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA1_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseHover
        btnTA1.BackColor = Color.LightSeaGreen
        btnTA1.ForeColor = Color.White
    End Sub

    Private Sub btnTA1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseLeave
        btnTA1.BackColor = Color.White
        btnTA1.ForeColor = Color.Black
    End Sub

    Private Sub btnTA0_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA0.MouseHover
        btnTA0.BackColor = Color.LightSeaGreen
        btnTA0.ForeColor = Color.White
    End Sub

    Private Sub btnTA0_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA0.MouseLeave
        btnTA0.BackColor = Color.White
        btnTA0.ForeColor = Color.Black
    End Sub

    Private Sub btnTA2_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA2.MouseHover
        btnTA2.BackColor = Color.LightSeaGreen
        btnTA2.ForeColor = Color.White
    End Sub

    Private Sub btnTA2_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA2.MouseLeave
        btnTA2.BackColor = Color.White
        btnTA2.ForeColor = Color.Black
    End Sub

    Private Sub btnTA3_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA3.MouseHover
        btnTA3.BackColor = Color.LightSeaGreen
        btnTA3.ForeColor = Color.White
    End Sub

    Private Sub btnTA3_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA3.MouseLeave
        btnTA3.BackColor = Color.White
        btnTA3.ForeColor = Color.Black
    End Sub

    Private Sub btnTA4_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA4.MouseHover
        btnTA4.BackColor = Color.LightSeaGreen
        btnTA4.ForeColor = Color.White
    End Sub

    Private Sub btnTA4_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA4.MouseLeave
        btnTA4.BackColor = Color.White
        btnTA4.ForeColor = Color.Black
    End Sub

    Private Sub btnTA5_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA5.MouseHover
        btnTA5.BackColor = Color.LightSeaGreen
        btnTA5.ForeColor = Color.White
    End Sub

    Private Sub btnTA5_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA5.MouseLeave
        btnTA5.BackColor = Color.White
        btnTA5.ForeColor = Color.Black
    End Sub

    Private Sub btnTA6_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA6.MouseHover
        btnTA6.BackColor = Color.LightSeaGreen
        btnTA6.ForeColor = Color.White
    End Sub

    Private Sub btnTA6_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA6.MouseLeave
        btnTA6.BackColor = Color.White
        btnTA6.ForeColor = Color.Black
    End Sub

    Private Sub btnTA7_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA7.MouseHover
        btnTA7.BackColor = Color.LightSeaGreen
        btnTA7.ForeColor = Color.White
    End Sub

    Private Sub btnTA7_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA7.MouseLeave
        btnTA7.BackColor = Color.White
        btnTA7.ForeColor = Color.Black
    End Sub

    Private Sub btnTA8_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA8.MouseHover
        btnTA8.BackColor = Color.LightSeaGreen
        btnTA8.ForeColor = Color.White
    End Sub

    Private Sub btnTA8_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA8.MouseLeave
        btnTA8.BackColor = Color.White
        btnTA8.ForeColor = Color.Black
    End Sub

    Private Sub btnTA9_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA9.MouseHover
        btnTA9.BackColor = Color.LightSeaGreen
        btnTA9.ForeColor = Color.White
    End Sub

    Private Sub btnTA9_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA9.MouseLeave
        btnTA9.BackColor = Color.White
        btnTA9.ForeColor = Color.Black
    End Sub

    Private Sub btnX_MouseHover(sender As Object, e As System.EventArgs) Handles btnX.MouseHover
        btnX.BackColor = Color.LightSeaGreen
        btnX.ForeColor = Color.White
    End Sub

    Private Sub btnX_MouseLeave(sender As Object, e As System.EventArgs) Handles btnX.MouseLeave
        btnX.BackColor = Color.White
        btnX.ForeColor = Color.Black
    End Sub

 

    Private Sub OK_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseHover
        btnLogin.BackColor = Color.Yellow

    End Sub

    Private Sub OK_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.Transparent
    End Sub

    Private Sub Cancel_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnCancel.MouseHover
        btnCancel.BackColor = Color.Red
    End Sub

    Private Sub Cancel_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.Transparent
    End Sub

    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.NumPad0
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(0)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(0)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad1
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(1)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(1)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad2
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(2)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(2)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad3
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(3)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(3)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad4
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(4)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(4)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad5
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(5)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(5)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad6
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(6)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(6)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad7
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(7)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(7)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad8
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(8)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(8)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.NumPad9
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(9)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(9)
                    sign_Indicator = 0
                End If
                fl = True

            Case Keys.D0
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(0)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(0)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D1
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(1)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(1)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D2
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(2)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(2)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D3
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(3)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(3)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D4
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(4)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(4)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D5
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(5)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(5)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D6
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(6)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(6)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D7
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(7)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(7)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D8
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(8)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(8)
                    sign_Indicator = 0
                End If
                fl = True
            Case Keys.D9
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                Password.PasswordChar = "•"
                If sign_Indicator = 0 Then
                    Password.Text = Password.Text + Convert.ToString(9)
                ElseIf sign_Indicator = 1 Then
                    Password.Text = Convert.ToString(9)
                    sign_Indicator = 0
                End If
                fl = True

            Case Keys.Delete
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                s = Password.Text
                Dim l As Integer = s.Length
                For i As Integer = 0 To l - 2
                    x += s(i)
                Next
                Password.Text = x
                x = ""
            Case Keys.Back
                If Password.Text = "ENTER PIN" Then
                    Password.Text = ""
                End If
                s = Password.Text
                Dim l As Integer = s.Length
                For i As Integer = 0 To l - 2
                    x += s(i)
                Next
                Password.Text = x
                x = ""
            Case Keys.Enter
                btnLogin.PerformClick()
        End Select
    End Sub
End Class
