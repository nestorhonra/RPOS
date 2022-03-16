Imports System.Data.SqlClient
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

    Private Sub GetData()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor,Sum(TempRestaurantPOS_OrderInfoKOT.GrandTotal) from R_Table left Join TempRestaurantPOS_OrderInfoKOT on R_Table.TableNo=TempRestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel2.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Popup
            btn.Width = 180
            btn.Height = 80
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'UserButtons.Add(btn)
            FlowLayoutPanel2.Controls.Add(btn)
            ' AddHandler btn.Click, AddressOf Me.Button2_Click
        Loop
        con.Close()

    End Sub
End Class