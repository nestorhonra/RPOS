Imports System.Data.SqlClient
Public Class frmNotes
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub Getdata()
        Try
            lblSet.Text = ""
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID,RTRIM(Notes) from NotesMaster order by Notes", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1))
            End While
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Reset()
        txtNotes.Text = ""
        lblSet.Text = ""
        btnNew.Enabled = True
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub


    Private Sub dgw_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                lblSet.Text = dr.Cells(0).Value.ToString()
                txtNotes.Text = dr.Cells(1).Value.ToString()
                btnSave.Enabled = False
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        'Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        'Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        'If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
        '    dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        'End If
        'Dim b As Brush = SystemBrushes.ControlText
        'e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmNotes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call Reset()
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(lblSet.Text) = "" Then
            If Len(Trim(txtNotes.Text)) = 0 Then
                MessageBox.Show("Please enter notes to save", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNotes.Focus()
                Exit Sub
            End If
            'Insert function
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Notes from NotesMaster where Notes=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtNotes.Text)
                rdr = cmd.ExecuteReader()

                If rdr.Read() Then
                    MessageBox.Show("Note details Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtNotes.Text = ""
                    txtNotes.Focus()
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If

                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Insert into NotesMaster (Notes) VALUES (@d1)"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtNotes.Text)
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Insert the new notes '" & txtNotes.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                Getdata()
                Reset()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Else
            'Insert function

        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(lblSet.Text)) = 0 Then
                MessageBox.Show("Please select notes to update", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNotes.Focus()
                Exit Sub
            End If
            If Len(Trim(txtNotes.Text)) = 0 Then
                MessageBox.Show("Please enter notes to save", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNotes.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update NotesMaster set Notes=@d1 where ID=@d2"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d2", lblSet.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the notes '" & lblSet.Text & "' details"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Warehouse Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            Getdata()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you really want to delete this record?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) 

    End Sub

    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "delete from NotesMaster where ID=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblSet.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Notes '" & lblSet.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class