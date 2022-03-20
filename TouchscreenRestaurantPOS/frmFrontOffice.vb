Public Class frmFrontOffice


    Private Sub frmFrontOffice_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        With frmPOS
            .lblUser.Text = Me.lblUser.Text
            .lblUserType.Text = Me.lblUserType.Text
            .Show()
        End With

    End Sub

    Private Sub btnWorkPeriod_Click(sender As Object, e As EventArgs) Handles btnWorkPeriod.Click
        With frmWorkPeriod
            .Show()
        End With
    End Sub

    Private Sub btnTicket_Click(sender As Object, e As EventArgs) Handles btnTicket.Click

    End Sub

    Private Sub btnWorkPeriodRep_Click(sender As Object, e As EventArgs) Handles btnWorkPeriodRep.Click
        With frmWorkPeriodReport
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPOSRep_Click(sender As Object, e As EventArgs) Handles btnPOSRep.Click
        With frmRestaurantPOSReport
            .Show()
        End With
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
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
                Me.Close()
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If (lblUserType.Text = "Admin") Then
            frmOption.lblUser.Text = lblUser.Text
            frmOption.lblUserType.Text = lblUserType.Text
            frmOption.btnBackOffice.Enabled = True
            frmOption.Show()
            Me.Dispose()
            Me.Close()
        Else
            frmLogin.Password.Text = ""
            frmLogin.Show()
            Me.Close()
        End If
    End Sub
End Class