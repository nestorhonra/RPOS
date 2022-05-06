Public Class frmTableRoom
    Public str As String
    Private Sub frmTableRoom_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnTable_Click(sender As Object, e As EventArgs) Handles btnTable.Click
        With frmTablesList
            .frm = "frmPOS"
            .ShowDialog()
        End With
        Me.Close()
    End Sub

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        With frmTablesList
            .frm = "frmRoom"
            .ShowDialog()
        End With
        Me.Close()
    End Sub
End Class