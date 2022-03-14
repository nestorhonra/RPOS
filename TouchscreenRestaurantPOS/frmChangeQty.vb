Public Class frmChangeQty
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
      
    End Sub

    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmChangeRate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub


    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If sign_Indicator = 0 Then
            txtQty.Text = txtQty.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtQty.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub


    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        s = txtQty.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtQty.Text = x
        x = ""
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtQty.Text = ""
    End Sub
End Class