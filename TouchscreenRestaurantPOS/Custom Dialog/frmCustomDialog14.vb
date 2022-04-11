Public Class frmCustomDialog14
    Dim FocusText As TextBox
    Dim s, x As String
    Dim s_tag As Boolean = False
    Private Sub frmCustomDialog14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FocusText = Me.txtAmount
        txtAmount.Text = ""
        txtAmount.Focus()
    End Sub

    Private Sub btnP1_Click(sender As Object, e As EventArgs) Handles btnP1.Click
        If FocusText IsNot Nothing Then
            'MsgBox(Val(FocusText.Text + Convert.ToString(1)))
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(1))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(1)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If

        End If
    End Sub

    Private Sub btnP2_Click(sender As Object, e As EventArgs) Handles btnP2.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(2))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(2)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If

    End Sub

    Private Sub btnP3_Click(sender As Object, e As EventArgs) Handles btnP3.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(3))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(3)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnP4_Click(sender As Object, e As EventArgs) Handles btnP4.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(4))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(4)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnP5_Click(sender As Object, e As EventArgs) Handles btnP5.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(5))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(5)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnP6_Click(sender As Object, e As EventArgs) Handles btnP6.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(6))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(6)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnP7_Click(sender As Object, e As EventArgs) Handles btnP7.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(7))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(7)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub


    Private Sub btnP9_Click(sender As Object, e As EventArgs) Handles btnP9.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(9))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(9)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnP0_Click(sender As Object, e As EventArgs) Handles btnP0.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(0))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(0)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub btnPX_Click(sender As Object, e As EventArgs) Handles btnPX.Click
        s = FocusText.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        FocusText.Text = x
        x = ""
    End Sub

    Private Sub btnPDot_Click(sender As Object, e As EventArgs) Handles btnPDot.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = ""
            s_tag = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If s_tag = True Then
            frmPOS.AddSplitItems(toNumber(lblSelrow.Text), toNumber(txtAmount.Text), Val(toNumber(lblQty.Text) - toNumber(txtAmount.Text)))
            Me.Close()
        Else
            MsgBox("Invalid quantity value. Please re-enter or cancel.", vbCritical + vbOKOnly, "Error")
            Exit Sub
        End If

    End Sub

    Private Sub btnP8_Click(sender As Object, e As EventArgs) Handles btnP8.Click
        If FocusText IsNot Nothing Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text + Convert.ToString(8))) = True Then
                FocusText.Text = FocusText.Text + Convert.ToString(8)
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(FocusText.Text))
            End If
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If Trim(txtAmount.Text) <> "" Then
            If checkVal(toNumber(lblQty.Text), Val(FocusText.Text)) = True Then
                s_tag = True
            Else
                MsgBox("Insufficient quantity" & vbNewLine & "Item qty is " & lblQty.Text & " only", vbCritical + vbOKOnly, "Error")
                s_tag = False
                s_tag = checkVal(toNumber(lblQty.Text), Val(txtAmount.Text))
                txtAmount.Text = ""
            End If
        Else
            s_tag = checkVal(toNumber(lblQty.Text), Val(txtAmount.Text))
        End If
    End Sub

    Private Function checkVal(ByVal o_qty As Integer, ByVal n_qty As Integer) As Boolean
        Dim retval As Boolean = False

        If o_qty >= n_qty Then
            retval = True
        ElseIf o_qty < n_qty Then
            retval = False
        End If

        Return retval

    End Function
End Class