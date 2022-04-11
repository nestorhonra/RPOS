Imports System.Data.SqlClient
Imports System.IO

Public Class frmWalletList
    Public frm As String
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmWalletList_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillAvailableTables()
    End Sub

    Sub FillAvailableTables()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT * FROM Wallets WHERE Active=1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpTables.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button

                btn.Text = rdr.GetValue(1) '& Environment.NewLine & rdr.GetValue(2)
                If Not IsDBNull(rdr.GetValue(2)) Then
                    Dim data1 As Byte() = DirectCast(rdr.GetValue(2), Byte())
                    Dim ms1 As New MemoryStream(data1)
                    btn.Image = Image.FromStream(ms1)
                End If

                btn.TextImageRelation = TextImageRelation.ImageAboveText
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 150
                btn.Height = 180
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpTables.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        If frm = "frmPOS" Then
            frmPOS.txtPaymentMode.Text = btn.Text
            frmPOS.wal_tag = True
        ElseIf frm = "frmSplitBill" Then
            frmSplitBill.txtPaymentMode.Text = btn.Text
            frmSplitBill.wal_tag = True
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