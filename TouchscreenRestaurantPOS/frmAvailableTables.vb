Imports System.Data.SqlClient
Public Class frmAvailableTables
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmAvailableTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AvailableTables()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Sub AvailableTables()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor from R_Table where BkColor=@d1 and Status='Activate'"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", Color.LightGreen.ToArgb())
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel1.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 180
                btn.Height = 80
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel1.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        AvailableTables()
    End Sub

End Class