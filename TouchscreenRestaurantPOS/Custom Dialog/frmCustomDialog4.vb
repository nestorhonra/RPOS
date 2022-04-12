Public Class frmCustomDialog4
    Public str As String
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub frmCustomDialog4_Load(sender As Object, e As EventArgs) Handles Me.Load
        If str <> "" Then
            Label2.Text = str
        End If
    End Sub
End Class