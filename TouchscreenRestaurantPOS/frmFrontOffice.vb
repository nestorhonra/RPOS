Imports System.Data.SqlClient
Public Class frmFrontOffice


    Private Sub frmFrontOffice_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT WPStart from WorkPeriodStart where Status='Active'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                With frmPOS
                    .lblUser.Text = Me.lblUser.Text
                    .lblUserType.Text = Me.lblUserType.Text
                    .ShowDialog()
                End With
            Else
                frmCustomDialog3.ShowDialog()
                Exit Sub
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnWorkPeriod_Click(sender As Object, e As EventArgs) Handles btnWorkPeriod.Click
        With frmWorkPeriod
            .ShowDialog()
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
            .ShowDialog()
        End With
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim retval = False
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from RestaurantPOS_OrderInfoKOT WHERE isPaid = 0"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                With frmCustomDialog4
                    .str = "There are open orders. " & vbNewLine & "Make sure you settle all the " & vbNewLine & "orders before your shift ends."
                    .ShowDialog()
                End With
                retval = True
            Else
                retval = False
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If retval = True Then
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
        Else
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
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim retval = False
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from RestaurantPOS_OrderInfoKOT WHERE isPaid = 0"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                With frmCustomDialog4
                    .str = "There are open orders. " & vbNewLine & "Make sure you settle all the " & vbNewLine & "orders before your shift ends."
                    .ShowDialog()
                End With
                retval = True
            Else
                retval = False
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If retval = True Then
            If MsgBox("Do you still want to proceed with logout?", vbQuestion + vbYesNo, "Confirm logout") = vbYes Then
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
        Else
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
        End If

    End Sub
End Class