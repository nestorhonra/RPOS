Public Class frmCustomDialog13
    Public frm As String
    Public rowIDs As Integer

    Private Sub frmCustomDialog13_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtAmount.Text = ""
        txtAmount.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If frm = "frmPOS" Then
            frmPOS.dgw.SelectedCells.Item(1).Value = toMoney(txtAmount.Text)
        ElseIf frm = "frmPOS1" Then
            frmPOS.dgw.SelectedCells.Item(2).Value = toNumber(txtAmount.Text)
        End If
        txtAmount.Text = ""
        Me.Close()
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        Dim ValidChars As String = "0123456789."
        e.Handled = Not (ValidChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.PerformClick()
        End If
    End Sub
End Class