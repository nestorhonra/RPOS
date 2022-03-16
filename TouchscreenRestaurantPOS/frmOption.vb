
Public Class frmOption

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to logout?", vbQuestion + vbYesNo, "Confirm close") = vbYes Then
            If (lblUserType.Text = "Admin") Then
                Dim st As String = "Successfully logged out"
                LogFunc(lblUser.Text, st)
                frmLogin.Password.Text = ""
                frmLogin.Show()
                'Me.Dispose()
                Me.Close()
            End If
        Else
            Exit Sub
        End If
    End Sub
    Private Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\RestaurantPOS3", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\RestaurantPOS3", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 14 Then
            Return False
        End If
        Return True
    End Function
    Private Sub frmOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BackColor = Color.Coral
        TransparencyKey = BackColor
        Dim result As Boolean = HandleRegistry()
        If result = False Then 'something went wrong
            MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software call us at +919827858191", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If
    End Sub

    Private Sub btnBackOffice_Click(sender As Object, e As EventArgs) Handles btnBackOffice.Click
        With frmBackOffice
            .lblUser.Text = Me.lblUser.Text
            .lblUserType.Text = Me.lblUserType.Text
            .Show()
        End With
        Me.Close()
    End Sub

    Private Sub btnFrontOffice_Click(sender As Object, e As EventArgs) Handles btnFrontOffice.Click
        With frmFrontOffice
            .lblUser.Text = Me.lblUser.Text
            .lblUserType.Text = Me.lblUserType.Text
            .Show()
        End With
        Me.Close()
    End Sub
End Class