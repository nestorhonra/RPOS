Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing
Public Class frmSplitBill
    Dim FocusText As TextBox
    Dim rowIndex As Integer
    Dim s, x As String
    Public wal_tag As Boolean


    Private Sub frmSplitBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub GetDiscounts()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Discount from Discounts WHERE Active='YES'"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel4.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = Trim(rdr.GetValue(0)) '& Environment.NewLine & rdr.GetValue(2)
                'btn.AutoSize = True
                btn.TextAlign = ContentAlignment.MiddleCenter
                'Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.ForeColor = Color.White
                btn.BackColor = Color.Crimson
                btn.FlatStyle = FlatStyle.Standard
                btn.Width = 120
                btn.Height = 50
                btn.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                'UserButtons.Add(btn)
                FlowLayoutPanel4.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnDiscounts_CheckedChanged
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If dgw.Rows.Count > 0 Then
            Dim totrow As Integer = dgw.Rows.Count - 1
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If rowIndex > 0 Then
                dgw.Rows(rowIndex - 1).Selected = True
            End If

        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If dgw.Rows.Count > 0 Then
            Dim totrow As Integer = dgw.Rows.Count - 1
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If totrow > rowIndex Then
                dgw.Rows(rowIndex + 1).Selected = True
            End If
        End If
    End Sub

    Private Sub btnDiscounts_CheckedChanged(sender As Object, e As EventArgs)
        Dim btnDisck As Button = DirectCast(sender, Button)
        txtDiscPer.Text = toNumber(btnDisck.Text)
    End Sub

#Region "Number Buttons"

    Private Sub btnP1_Click(sender As Object, e As EventArgs) Handles btnP1.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(1)
        End If
    End Sub

    Private Sub btnP2_Click(sender As Object, e As EventArgs) Handles btnP2.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(2)
        End If
    End Sub

    Private Sub btnP3_Click(sender As Object, e As EventArgs) Handles btnP3.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(3)
        End If
    End Sub

    Private Sub btnP4_Click(sender As Object, e As EventArgs) Handles btnP4.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(4)
        End If
    End Sub

    Private Sub btnP5_Click(sender As Object, e As EventArgs) Handles btnP5.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(5)
        End If
    End Sub

    Private Sub btnP6_Click(sender As Object, e As EventArgs) Handles btnP6.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(6)
        End If
    End Sub

    Private Sub btnP7_Click(sender As Object, e As EventArgs) Handles btnP7.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(7)
        End If
    End Sub

    Private Sub btnP8_Click(sender As Object, e As EventArgs) Handles btnP8.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(8)
        End If
    End Sub

    Private Sub btnP9_Click(sender As Object, e As EventArgs) Handles btnP9.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(9)
        End If
    End Sub

    Private Sub btnP0_Click(sender As Object, e As EventArgs) Handles btnP0.Click
        If FocusText IsNot Nothing Then
            FocusText.Text = FocusText.Text + Convert.ToString(0)
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
            FocusText.Text = FocusText.Text + Convert.ToString(".")
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        chkSC.Checked = False
        txtSCAmount.Text = ""
        txtSCDiscPer.Text = ""
        txtOSCANo.Text = ""
        txtDiscPer.Text = ""
        txtDiscAmt.Text = ""
        txtGrandTot.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        wal_tag = False
        lblPayID.Text = ""
        lblGrandTotal.Text = ""
        lblSubTotal.Text = ""
        lblRefNo.Text = ""
        lblSCName.Text = ""
        lblBookID.Text = ""
        lblRoomNo.Text = ""
        lblGuestName.Text = ""
    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        txtPaymentMode.Text = "Cash"
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        txtPaymentMode.Text = "Card"
    End Sub

    Private Sub btnWallet_Click(sender As Object, e As EventArgs) Handles btnWallet.Click
        With frmWalletList
            .frm = "frmSplitBill"
            .ShowDialog()
        End With
        If wal_tag = True Then
            With frmCustomDialog13
                .frm = "frmSplitBill"
                .Label2.Text = "Enter Reference Number"
                .btnKeyboard.Visible = True
                .ShowDialog()
            End With
        End If
    End Sub

End Class