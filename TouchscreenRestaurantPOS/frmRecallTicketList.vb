Imports System.Data.SqlClient
Public Class frmRecallTicketList
    Public frm As String
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmRecallTicketList_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillAvailableTables()
    End Sub

    Sub FillAvailableTables()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT RTRIM(T.TableNo) AS TableNo, T.BkColor, O.GrandTotal FROM TempRestaurantPOS_OrderInfoKOT AS O LEFT JOIN R_Table aS T ON O.TableNo = T.TableNo WHERE isPaid = 0"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        flpTables.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = Color.LightSalmon
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
            frmPOS.GetOrders(btn.Text, 1)
            frmPOS.is_edit = False
            frmPOS.btnSave.Enabled = True
        End If
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        FillAvailableTables()
    End Sub

End Class