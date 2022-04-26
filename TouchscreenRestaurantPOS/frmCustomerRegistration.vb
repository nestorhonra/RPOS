Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class frmCustomerRegistration
    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Dim st1 As String
    Private Sub frmCustomerRegistration_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call GetData()
        Call CommandPass(True, False, False, False, False)
    End Sub

    Private Sub CommandPass(iNew As Boolean, iSave As Boolean, iUpdate As Boolean, iDelete As Boolean, iCancel As Boolean)
        btnNew.Enabled = iNew
        btnSave.Enabled = iSave
        btnUpdate.Enabled = iUpdate
        btnDelete.Enabled = iDelete
        btnCancel.Enabled = iCancel

    End Sub

    Sub Reset()
        txtID.Text = ""
        txtAccountID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtCredit.Text = ""
        dtpCreated.Text = Today
        dtpBirthDate.Text = Today
        btnNew.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkActive.Checked = False
        btnSave.Enabled = False
        Picture.Image = My.Resources.photo
        'auto()
        txtFirstName.Focus()
    End Sub

    Private Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(AccountNo), RTRIM(FirstName), RTRIM(LastName), RTRIM(Address), RTRIM(BirthDate), RTRIM(ContactNo), RTRIM(Remarks), Status,RTRIM(CreditAmount), Photo, CrtdDate from CustomerInfo", con)
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

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtAccountID.Text = dr.Cells(1).Value.ToString()
                txtFirstName.Text = dr.Cells(2).Value.ToString()
                txtLastName.Text = dr.Cells(3).Value.ToString()
                txtAddress.Text = dr.Cells(4).Value.ToString()
                dtpBirthDate.Value = CDate(dr.Cells(5).Value.ToString())
                txtContactNo.Text = dr.Cells(6).Value.ToString()
                txtRemarks.Text = dr.Cells(7).Value.ToString()
                chkActive.Checked = dr.Cells(8).Value
                Dim data As Byte() = DirectCast(dr.Cells(10).Value, Byte())
                Dim ms As New MemoryStream(data)
                Me.Picture.Image = Image.FromStream(ms)
                txtCredit.Text = dr.Cells(9).Value.ToString()
                dtpCreated.Value = CDate(dr.Cells(11).Value.ToString())
                Call CommandPass(True, False, True, True, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(EmpID) FROM EmployeeRegistration")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtID.Text = Num.ToString
            txtAccountID.Text = "CL-" + Format(Num, "000000").ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
            txtAccountID.Text = "CL-" + Format(Num, "000000").ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub Browse_Click(sender As System.Object, e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(sender As System.Object, e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources.photo
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        'Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call Reset()
        Call CommandPass(True, False, False, False, False)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call CommandPass(True, False, False, False, False)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If toNumber(txtID.Text) > 0 Then

            Call CommandPass(True, False, False, False, False)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If toNumber(txtID.Text) > 0 Then
            Call DeleteRecord()
        End If
    End Sub

    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select CustomerInfo.ID from CustomerInfo,RestaurantPOS_BillingInfoKOT where CustomerInfo.AccountNo=RestaurantPOS_BillingInfoKOT.RefNo and CustomerInfo.ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from CustomerInfo where ID='" & toNumber(txtID.Text) & "'"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the record of '" & txtFirstName.Text & "' '" & txtLastName.Text & "' having ID '" & txtAccountID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                Call CommandPass(True, False, False, False, False)
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                Call CommandPass(True, False, False, False, False)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        Dim validChars As String = "0123456789 "
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCredit.KeyPress
        Dim validChars As String = "0123456789."
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress
        Dim validChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        Dim validChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddress.KeyPress
        Dim validChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz -1234567890"
        e.Handled = Not (validChars.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Convert.ToChar(Keys.Back))
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call Reset()
        auto()
        dgw.Enabled = False
        Call CommandPass(False, True, False, False, True)
    End Sub


End Class