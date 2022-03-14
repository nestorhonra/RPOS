Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class frmEmployeeRegistration
    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Dim st1 As String
    Sub Reset()
        txtEmployeeID.Text = ""
        txtEmployeeName.Text = ""
        txtCity.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtEmail.Text = ""
        dtpDateOfJoining.Text = Today
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkActive.Checked = True
        btnSave.Enabled = True
        Picture.Image = My.Resources.photo
        auto()
        txtEmployeeName.Focus()
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
            txtEmployeeID.Text = "EMP-" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
            txtEmployeeID.Text = "EMP-" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Len(Trim(txtEmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        Try
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into employeeregistration(Empid,employeeid,employeename,address,City,contactno,email,dateofjoining,photo,Active) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,'" & st1 & "')"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtEmployeeID.Text)
            cmd.Parameters.AddWithValue("@d2", txtEmployeeName.Text)
            cmd.Parameters.AddWithValue("@d3", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d4", txtCity.Text)
            cmd.Parameters.AddWithValue("@d5", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d6", txtEmail.Text)
            cmd.Parameters.AddWithValue("@d7", dtpDateOfJoining.Value.Date)
            Dim ms3 As New MemoryStream()
            Dim bmpImage3 As New Bitmap(Picture.Image)
            bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data3 As Byte() = ms3.GetBuffer()
            Dim p3 As New SqlParameter("@d8", SqlDbType.Image)
            p3.Value = data3
            cmd.Parameters.Add(p3)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the new delivery person '" & txtEmployeeName.Text & "' having ID='" & txtEmployeeID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub BStartCapture_Click(sender As System.Object, e As System.EventArgs) Handles BStartCapture.Click
        frmCamera.ShowDialog()
        If TempFileNames2.Length > 0 Then
            Picture.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            IsImageChanged = True
        End If
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
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select EmployeeRegistration.EmpID from EmployeeRegistration,RestaurantPOS_BillingInfoHD where EmployeeRegistration.EmpID=RestaurantPOS_BillingInfoHD.Employee_ID and EmployeeRegistration.EmpID=@d1"
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
            Dim cq As String = "delete from EmployeeRegistration where EmpID=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the record of employee '" & txtEmployeeName.Text & "' having ID '" & txtEmployeeID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtEmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        Try
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update employeeregistration set employeeid=@d1,employeename=@d2,address=@d4,City=@d5,contactno=@d6,email=@d7,dateofjoining=@d11,photo=@d14,Active='" & st1 & "' where Empid=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtEmployeeID.Text)
            cmd.Parameters.AddWithValue("@d2", txtEmployeeName.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", txtCity.Text)
            cmd.Parameters.AddWithValue("@d6", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtEmail.Text)
            cmd.Parameters.AddWithValue("@d11", dtpDateOfJoining.Value.Date)
            Dim ms3 As New MemoryStream()
            Dim bmpImage3 As New Bitmap(Picture.Image)
            bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data3 As Byte() = ms3.GetBuffer()
            Dim p3 As New SqlParameter("@d14", SqlDbType.Image)
            p3.Value = data3
            cmd.Parameters.Add(p3)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the record of employee '" & txtEmployeeName.Text & "' having ID '" & txtEmployeeID.Text & "'"""
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmEmployeesRecord.lblSet.Text = "Employee"
        frmEmployeesRecord.Reset()
        frmEmployeesRecord.ShowDialog()
    End Sub

End Class
