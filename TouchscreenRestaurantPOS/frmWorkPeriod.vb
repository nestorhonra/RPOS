Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmWorkPeriod
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

 
    Private Sub btnStartWP_Click(sender As System.Object, e As System.EventArgs) Handles btnStartWP.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update WorkPeriodStart set Status='Inactive'"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into WorkPeriodStart(WPStart,Status) VALUES (@d1,'Active')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            frmCustomDialog1.ShowDialog()
            GetData()
            FillDataGridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT ID,WPStart from WorkPeriodStart where Status='Active'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblTotalWorkTime.Visible = True
                lblTotalWT.Visible = True
                lblWorkPeriodDate.Visible = True
                lblWPDate.Visible = True
                txtID.Text = rdr.GetValue(0)
                lblWorkPeriodDate.Text = rdr.GetDateTime(1).ToString("dd/MM/yyyy hh:mm:ss tt")
                btnStartWP.Enabled = False
            Else
                lblTotalWorkTime.Visible = False
                lblTotalWT.Visible = False
                lblWorkPeriodDate.Visible = False
                lblWPDate.Visible = False
                btnStartWP.Enabled = True
                btnEndWP.Enabled = False
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmWorkPeriod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
        FillDataGridview()
        dgw.ClearSelection()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "SELECT WPStart from WorkPeriodStart where Status='Active'"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            Dim startDate As DateTime = DateTime.Now
            Dim endDate As DateTime = rdr.GetDateTime(0)
            Dim timeSpan As TimeSpan = startDate.Subtract(endDate)
            Dim difDays As Integer = timeSpan.Days
            Dim difHr As Integer = timeSpan.Hours
            Dim difMin As Integer = timeSpan.Minutes
            If difDays > 0 And difHr > 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr = 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr > 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr = 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr > 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr > 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr = 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr = 0 And difMin >= 0 Then
                If difMin <= 1 Then
                    lblTotalWorkTime.Text = difMin & " " & "Minute"
                Else
                    lblTotalWorkTime.Text = difMin & " " & "Minutes"
                End If
            End If
            If difDays = 0 And difHr > 0 And difMin >= 0 Then
                If difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difHr <= 1 And difMin >= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                End If
            End If
            If difDays > 0 And difHr >= 0 And difMin >= 0 Then
                If difDays <= 1 And difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                ElseIf difDays > 1 And difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difDays <= 1 And difHr <= 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difDays <= 1 And difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr <= 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difDays <= 1 And difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                End If
            End If
        End If
        con.Close()
    End Sub
    Sub FillDataGridview()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from WorkPeriodStart"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                dgw.Enabled = False
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT WPStart,WPEnd from WorkPeriodStart left join WorkPeriodEnd On WorkperiodStart.ID=WorkPeriodEnd.ID  order by WPStart", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1))
            End While
            con.Close()
            dgw.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEndWP_Click(sender As System.Object, e As System.EventArgs) Handles btnEndWP.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from RestaurantPOS_OrderInfoKOT WHERE isPaid = 0"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog4.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into WorkPeriodEnd(ID,WPEnd) VALUES (" & Val(txtID.Text) & ",@d1)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update WorkPeriodStart set Status='Inactive'"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            frmCustomDialog2.ShowDialog()
            GetData()
            FillDataGridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class