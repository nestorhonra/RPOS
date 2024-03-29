﻿Imports System.Data.SqlClient
Public Class frmTable

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub Reset()
        txtTableNo.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnActivate_Deactivate.Enabled = False
        btnActivate_Deactivate.Text = "Activate/Deactivate"
        txtTableNo.Focus()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTableNo.Text = "" Then
            MessageBox.Show("Please enter table no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTableNo.Focus()
            Return
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select TableNo from R_Table where TableNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Table No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtTableNo.Text = ""
                txtTableNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into R_Table(TableNo,Status,bkColor) VALUES (@d1,'Activate',@d2)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new table '" & txtTableNo.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtTableNo.Text = "" Then
            MessageBox.Show("Please enter table no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTableNo.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update R_Table set TableNo=@d1,BkColor=@d3 where TableNo=@d2"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtTable.Text)
            cmd.Parameters.AddWithValue("@d3", Color.LightGreen.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the table '" & txtTableNo.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl6 As String = "select R_Table.TableNo from RestaurantPOS_OrderedProductBillKOT,R_Table where RestaurantPOS_OrderedProductBillKOT.TableNo=R_Table.TableNo and R_Table.TableNo=@d1"
            cmd = New SqlCommand(cl6)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "select R_Table.TableNo from RestaurantPOS_OrderInfoKOT,R_Table where RestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo and R_Table.TableNo=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl3 As String = "select R_Table.TableNo from TempRestaurantPOS_OrderInfoKOT,R_Table where TempRestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo and R_Table.TableNo=@d1"
            cmd = New SqlCommand(cl3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from R_Table where TableNo=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtTable.Text)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the table '" & txtTableNo.Text & "'"
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
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you really want to delete this record?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtTable.Text = dr.Cells(0).Value.ToString()
                txtTableNo.Text = dr.Cells(0).Value.ToString()
                txtStatus.Text = dr.Cells(1).Value.ToString()
                If dr.Cells(1).Value = "Activate" Then
                    btnActivate_Deactivate.Text = "Deactivate"
                    btnActivate_Deactivate.Enabled = True
                End If
                If dr.Cells(1).Value = "Deactivate" Then
                    btnActivate_Deactivate.Text = "Activate"
                    btnActivate_Deactivate.Enabled = True
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
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
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(TableNo),RTRIM(Status) from R_Table order by TableNo", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmTableNo_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub btnDeactivate_Click(sender As System.Object, e As System.EventArgs) Handles btnActivate_Deactivate.Click
        If txtTableNo.Text = "" Then
            MessageBox.Show("Please enter table no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTableNo.Focus()
            Return
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cl3 As String = "select R_Table.TableNo from TempRestaurantPOS_OrderInfoKOT,R_Table where TempRestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo and R_Table.TableNo=@d1"
            cmd = New SqlCommand(cl3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to deactivate..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            If btnActivate_Deactivate.Text = "Activate" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update R_Table set TableNo=@d1,Status='Activate' where TableNo=@d2"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
                cmd.Parameters.AddWithValue("@d2", txtTable.Text)
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "activated the table '" & txtTableNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully activated", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnActivate_Deactivate.Enabled = False
                Getdata()
                Reset()
            End If
            If btnActivate_Deactivate.Text = "Deactivate" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update R_Table set TableNo=@d1,Status='Deactivate' where TableNo=@d2"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
                cmd.Parameters.AddWithValue("@d2", txtTable.Text)
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "deactivated the table '" & txtTableNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deactivated", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnActivate_Deactivate.Enabled = False
                Getdata()
                Reset()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class
