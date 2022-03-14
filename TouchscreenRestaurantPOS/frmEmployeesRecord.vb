Imports System.Data.SqlClient

Imports System.IO

Public Class frmEmployeesRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select EmpID,RTRIM(EmployeeID),RTRIM(EmployeeName),RTRIM(Address),RTRIM(City),RTRIM(ContactNo),RTRIM(Email),DateofJoining,RTRIM(Active) from EmployeeRegistration order by EmployeeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtEmployeeName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Employee" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmEmployeeRegistration.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmEmployeeRegistration.txtID.Text = dr.Cells(0).Value.ToString()
                    frmEmployeeRegistration.txtEmployeeID.Text = dr.Cells(1).Value.ToString()
                    frmEmployeeRegistration.txtEmployeeName.Text = dr.Cells(2).Value.ToString()
                    frmEmployeeRegistration.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmEmployeeRegistration.txtCity.Text = dr.Cells(4).Value.ToString()
                    frmEmployeeRegistration.txtContactNo.Text = dr.Cells(5).Value.ToString()
                    frmEmployeeRegistration.txtEmail.Text = dr.Cells(6).Value.ToString()
                    frmEmployeeRegistration.dtpDateOfJoining.Text = dr.Cells(7).Value.ToString()
                    If dr.Cells(8).Value.ToString() = "Yes" Then
                        frmEmployeeRegistration.chkActive.Checked = True
                    Else
                        frmEmployeeRegistration.chkActive.Checked = False
                    End If
                    frmEmployeeRegistration.btnUpdate.Enabled = True
                    frmEmployeeRegistration.btnDelete.Enabled = True
                    frmEmployeeRegistration.btnSave.Enabled = False
                    frmEmployeeRegistration.txtEmployeeName.Focus()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT Photo from EmployeeRegistration where EmployeeRegistration.EmployeeID='" & dr.Cells(1).Value & "'", con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    While (rdr.Read() = True)
                        Dim data As Byte() = DirectCast(rdr(0), Byte())
                        Dim ms As New MemoryStream(data)
                        frmEmployeeRegistration.Picture.Image = Image.FromStream(ms)
                    End While
                    con.Close()
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub txtEmployeeName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmployeeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select EmpID,RTRIM(EmployeeID),RTRIM(EmployeeName),RTRIM(Address),RTRIM(City),RTRIM(ContactNo),RTRIM(Email),DateofJoining,RTRIM(Active) from EmployeeRegistration where Employeename like '%" & txtEmployeeName.Text & "%' order by EmployeeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub
End Class
