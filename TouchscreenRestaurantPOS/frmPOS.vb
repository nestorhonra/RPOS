Public Class frmPOS
    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure to close/logout?", vbQuestion + vbYesNo, "Confirm close") = vbYes Then
            If (lblUserType.Text = "Admin") Then
                frmOption.lblUser.Text = lblUser.Text
                frmOption.lblUserType.Text = lblUserType.Text
                frmOption.btnBackOffice.Enabled = True
                frmOption.Show()
                Me.Dispose()
                Me.Close()
            Else
                Dim st As String = "Successfully logged out"
                LogFunc(lblUser.Text, st)
                frmLogin.Password.Text = ""
                frmLogin.Show()
                Me.Dispose()
                Me.Close()
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub
End Class