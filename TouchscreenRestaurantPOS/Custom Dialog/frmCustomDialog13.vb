Public Class frmCustomDialog13
    Public frm As String
    Public rowIDs As Integer
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private Sub frmCustomDialog13_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtAmount.Text = ""
        txtAmount.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If frm = "frmPOS" Then
            frmPOS.dgw.SelectedCells.Item(1).Value = toMoney(txtAmount.Text)
        ElseIf frm = "frmPOS1" Then
            frmPOS.dgw.SelectedCells.Item(2).Value = toNumber(txtAmount.Text)
        ElseIf frm = "frmPOS2" Then
            If Trim(txtAmount.Text) <> "" Then
                frmPOS.lblRefNo.Text = Trim(Me.txtAmount.Text)
            Else
                frmPOS.lblRefNo.Text = Trim(Me.txtAmount.Text)
                frmPOS.txtPaymentMode.Text = ""
            End If
        ElseIf frm = "frmSplitBill" Then
            If Trim(txtAmount.Text) <> "" Then
                frmSplitBill.lblRefNo.Text = Trim(Me.txtAmount.Text)
            Else
                frmSplitBill.lblRefNo.Text = Trim(Me.txtAmount.Text)
                frmSplitBill.txtPaymentMode.Text = ""
            End If
        ElseIf frm = "frmPOS3" Then
            If Trim(txtAmount.Text) <> "" Then
                frmPOS.lblSCName.Text = Trim(Me.txtAmount.Text)
            Else
                frmPOS.lblSCName.Text = Trim(Me.txtAmount.Text)
                frmPOS.txtSCDiscPer.Text = ""
                frmPOS.chkSC.Checked = False
                frmPOS.txtSCAmount.Text = ""
                frmPOS.txtOSCANo.Text = ""
            End If
        ElseIf frm = "frmPOS4" Then
            If Trim(txtAmount.Text) <> "" Then
                frmPOS.lblDiscRem.Text = Trim(Me.txtAmount.Text)
            Else
                frmPOS.lblDiscRem.Text = Trim(Me.txtAmount.Text)
                frmPOS.txtDiscPer.Text = ""
                frmPOS.txtDiscAmt.Text = ""
            End If
        End If
        txtAmount.Text = ""
        Me.Close()
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        Dim ValidChars As String = ""
        If frm = "frmPOS2" Or frm = "frmPOS3" Or frm = "frmSplitBill" Or frm = "frmPOS4" Then
            ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.- "
        Else
            ValidChars = "0123456789."
        End If
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

    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub
End Class