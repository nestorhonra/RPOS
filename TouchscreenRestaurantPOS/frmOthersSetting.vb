Imports System.Data.SqlClient
Public Class frmOthersSetting
    Dim st1, st2, st3, st4, st5 As String
    Sub Reset()
        txtHDCharges.Text = "0.00"
        txtParcelCharges.Text = "0.00"
        txtSTPer.Text = "0.00"
        txtSCPer.Text = "0.00"
        txtVATPer.Text = "0.00"
        txtSeniorDisc.Text = "0.00"
        chkCashDrawer.Checked = False
        chkEB.Checked = False
        chkHD.Checked = False
        chkKG.Checked = False
        chkTA.Checked = False
        txtParcelCharges.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkCashDrawer.Checked = False
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select count(*) from OtherSetting Having count(*) >= 1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Record Already Exists" & vbCrLf & "please update the others setting", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            If chkCashDrawer.Checked = True Then
                st1 = "Enabled"
            Else
                st1 = "Disabled"
            End If
            If chkTA.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            If chkHD.Checked = True Then
                st3 = "Yes"
            Else
                st3 = "No"
            End If
            If chkEB.Checked = True Then
                st4 = "Yes"
            Else
                st4 = "No"
            End If
            If chkKG.Checked = True Then
                st5 = "Yes"
            Else
                st5 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into OtherSetting(ParcelCharges,HomeDeliveryCharges,VAT,ServiceTax,ServiceCharges,CashDrawer,TA,HD,EB,KG,SeniorDiscount) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtParcelCharges.Text))
            cmd.Parameters.AddWithValue("@d2", Val(txtHDCharges.Text))
            cmd.Parameters.AddWithValue("@d3", Val(txtVATPer.Text))
            cmd.Parameters.AddWithValue("@d4", Val(txtSTPer.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtSCPer.Text))
            cmd.Parameters.AddWithValue("@d6", st1)
            cmd.Parameters.AddWithValue("@d7", st2)
            cmd.Parameters.AddWithValue("@d8", st3)
            cmd.Parameters.AddWithValue("@d9", st4)
            cmd.Parameters.AddWithValue("@d10", st5)
            cmd.Parameters.AddWithValue("@d11", Val(txtSeniorDisc.Text))
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the others setting info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you really want to delete this record?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from OtherSetting where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the others setting info"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If chkCashDrawer.Checked = True Then
                st1 = "Enabled"
            Else
                st1 = "Disabled"
            End If
            If chkTA.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            If chkHD.Checked = True Then
                st3 = "Yes"
            Else
                st3 = "No"
            End If
            If chkEB.Checked = True Then
                st4 = "Yes"
            Else
                st4 = "No"
            End If
            If chkKG.Checked = True Then
                st5 = "Yes"
            Else
                st5 = "No"
            End If
            If chkKG.Checked = True Then
                st5 = "Yes"
            Else
                st5 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update OtherSetting set ParcelCharges=@d1,HomeDeliveryCharges=@d2,VAT=@d3,ServiceTax=@d4,ServiceCharges=@d5,CashDrawer=@d6,TA=@d7,HD=@d8,EB=@d9,KG=@d10,SeniorDiscount=@d11 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtParcelCharges.Text))
            cmd.Parameters.AddWithValue("@d2", Val(txtHDCharges.Text))
            cmd.Parameters.AddWithValue("@d3", Val(txtVATPer.Text))
            cmd.Parameters.AddWithValue("@d4", Val(txtSTPer.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtSCPer.Text))
            cmd.Parameters.AddWithValue("@d6", st1)
            cmd.Parameters.AddWithValue("@d7", st2)
            cmd.Parameters.AddWithValue("@d8", st3)
            cmd.Parameters.AddWithValue("@d9", st4)
            cmd.Parameters.AddWithValue("@d10", st5)
            cmd.Parameters.AddWithValue("@d11", Val(txtSeniorDisc.Text))
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the others setting info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID,(ParcelCharges),(HomeDeliveryCharges),ServiceTax,VAT,ServiceCharges,RTRIM(TA),RTRIM(HD),RTRIM(EB),RTRIM(KG),RTRIM(CashDrawer),SeniorDiscount from OtherSetting", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub frmExpense_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtParcelCharges.Text = toNumber(dr.Cells(1).Value.ToString())
                txtID.Text = toNumber(dr.Cells(0).Value.ToString())
                txtHDCharges.Text = toNumber(dr.Cells(2).Value.ToString())
                txtSTPer.Text = toNumber(dr.Cells(3).Value.ToString())
                txtVATPer.Text = toNumber(dr.Cells(4).Value.ToString())
                txtSCPer.Text = toNumber(dr.Cells(5).Value.ToString())
                If dr.Cells(6).Value = "Yes" Then
                    chkTA.Checked = True
                Else
                    chkTA.Checked = False
                End If
                If dr.Cells(7).Value = "Yes" Then
                    chkHD.Checked = True
                Else
                    chkHD.Checked = False
                End If
                If dr.Cells(8).Value = "Yes" Then
                    chkEB.Checked = True
                Else
                    chkEB.Checked = False
                End If
                If dr.Cells(9).Value = "Yes" Then
                    chkKG.Checked = True
                Else
                    chkKG.Checked = False
                End If
                If dr.Cells(10).Value = "Enabled" Then
                    chkCashDrawer.Checked = True
                Else
                    chkCashDrawer.Checked = False
                End If
                txtSeniorDisc.Text = toNumber(dr.Cells(11).Value.ToString())
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtParcelCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtParcelCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtParcelCharges.Text
            Dim selectionStart = Me.txtParcelCharges.SelectionStart
            Dim selectionLength = Me.txtParcelCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtHDCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtHDCharges.Text
            Dim selectionStart = Me.txtHDCharges.SelectionStart
            Dim selectionLength = Me.txtHDCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtSTPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSTPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSTPer.Text
            Dim selectionStart = Me.txtSTPer.SelectionStart
            Dim selectionLength = Me.txtSTPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtVATPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVATPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtVATPer.Text
            Dim selectionStart = Me.txtVATPer.SelectionStart
            Dim selectionLength = Me.txtVATPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtSCPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSCPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSCPer.Text
            Dim selectionStart = Me.txtSCPer.SelectionStart
            Dim selectionLength = Me.txtSCPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtSeniorDisc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeniorDisc.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSTPer.Text
            Dim selectionStart = Me.txtSTPer.SelectionStart
            Dim selectionLength = Me.txtSTPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub frmOthersSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
