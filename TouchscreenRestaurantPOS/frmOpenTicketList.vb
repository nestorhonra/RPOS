Imports System.Data.SqlClient
Public Class frmOpenTicketList
    Public frm As String
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmOpenTicketList_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillAvailableTables()
    End Sub

    Sub FillAvailableTables()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = ""
        'MsgBox(frm)
        If frm = "frmPOS" Then
            cmdText1 = "SELECT RTRIM(T.TableNo) AS TableNo, T.BkColor, O.GrandTotal FROM RestaurantPOS_OrderInfoKOT AS O LEFT JOIN R_Table aS T ON O.TableNo = T.TableNo WHERE isPaid = 0"
        ElseIf frm = "frmPOSC" Then
            cmdText1 = "SELECT RTRIM(T.TableNo) AS TableNo, T.BkColor, O.GrandTotal FROM RestaurantPOS_OrderInfoKOT AS O LEFT JOIN R_Table aS T ON O.TableNo = T.TableNo WHERE isPaid = 0"
        ElseIf frm = "frmPOST" Then
            cmdText1 = " SELECT R.TableNo, R.BkColor, (SELECT GrandTotal FROM RestaurantPOS_OrderInfoKOT AS O WHERE R.TableNo = O.TableNo AND O.isPaid = 0) AS GrandTotal FROM R_Table AS R WHERE R.Status = 'Activate'"
        End If
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        flpTables.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color
            'MsgBox(Val(rdr.GetValue(1)))
            If frm = "frmPOS" Then
                btnColor = Color.FromArgb(Val(rdr.GetValue(1)))
            ElseIf frm = "frmPOST" Then
                If toNumber(rdr.GetValue(2).ToString) > 0 Then
                    btnColor = Color.LightSalmon
                Else
                    btnColor = Color.FromArgb(Val(rdr.GetValue(1)))
                End If
            ElseIf frm = "frmPOSC" Then
                btnColor = Color.LightSalmon
            End If
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
            frmPOS.GetOrders(btn.Text, 0)
            frmPOS.is_edit = True
            frmPOS.btnSave.Enabled = False
        ElseIf frm = "frmPOSC" Then
            frmPOS.txtTableNo.Text = btn.Text
            frmPOS.GetOrders(btn.Text, 0)
            frmPOS.is_edit = True
            frmPOS.btnSave.Enabled = False
        ElseIf frm = "frmPOST" Then

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