Imports System.Data.SqlClient
Public Class frmGuestLists
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Trim(txtSearchByDish.Text) <> "" Then
            Call LoadGuest(Trim(txtSearchByDish.Text))
        End If
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmGuestLists_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtSearchByDish.Text = ""
        txtDish.Text = ""
        Call LoadGuest("")
    End Sub

    Private Sub LoadGuest(ByVal gurs As String)
        Try
            con = New SqlConnection(cs)
            con.Open()
            If gurs <> "" Then
                cmd = New SqlCommand("SELECT * from view_POS_guests WHERE name LIKE '%" & gurs & "%' order by fromdate", con)
            Else
                cmd = New SqlCommand("SELECT * from view_POS_guests order by fromdate", con)
            End If

            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(8), rdr(0))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)

                txtDish.Text = dr.Cells(0).Value.ToString()
                frmPOS.lblBookID.Text = dr.Cells(6).Value.ToString()
                frmPOS.lblRoomNo.Text = dr.Cells(1).Value.ToString()
                frmPOS.lblGuestName.Text = dr.Cells(0).Value.ToString()
                frmPOS.txtPaymentMode.Text = "Room Service"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSplitAdd_Click(sender As Object, e As EventArgs) Handles btnSplitAdd.Click
        If Trim(txtDish.Text) <> "" Then
            Me.Close()
        Else
            frmPOS.txtPaymentMode.Text = ""
            frmPOS.lblBookID.Text = ""
            frmPOS.lblRoomNo.Text = ""
            frmPOS.lblGuestName.Text = ""
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class