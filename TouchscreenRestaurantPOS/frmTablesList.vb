Imports System.Data.SqlClient
Public Class frmTablesList
    Public frm As String
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Sub FillAvailableTables()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor,Sum(TempRestaurantPOS_OrderInfoKOT.GrandTotal) from R_Table left Join TempRestaurantPOS_OrderInfoKOT on R_Table.TableNo=TempRestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        flpTables.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Popup
            btn.Width = 180
            btn.Height = 80
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            flpTables.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.Button2_Click
        Loop
        con.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If frm = "frmPOS" Then
            frmPOS.txtTableNo.Text = btn.Text
        End If
        Me.Close()
    End Sub
    Private Sub frmTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillAvailableTables()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        FillAvailableTables()
    End Sub
End Class