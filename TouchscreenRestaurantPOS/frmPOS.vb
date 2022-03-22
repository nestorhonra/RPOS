Imports System.Data.SqlClient
Public Class frmPOS
    Dim rowIndex As Integer
    Dim table As New DataTable("table")
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim is_edit As Boolean = False
    Dim s, x As String
    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblType.Text = ""
        lblTypeID.Text = ""
        txtTableNo.Text = ""
        txtTicketNo.Text = ""
        txtQty.Text = ""
        is_edit = False
        Call FillCategory()

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub FillMenus(ByVal categ As String)
        If categ <> "" Then
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT * from Dish where Category = '" & categ & "'"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel2.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Flat
                btn.Width = 93
                btn.Height = 50
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel2.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnAddMenu_Click
            Loop
            con.Close()
        End If
    End Sub

    Private Sub FillCategory()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT * from Category"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel1.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) '& Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Flat
            btn.Width = 100
            btn.Height = 50
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.btnCategory_Click
        Loop
        con.Close()
    End Sub

    Private Sub btnDinein_Click(sender As Object, e As EventArgs) Handles btnDinein.Click
        If txtTicketNo.Text <> "" Then
            lblTypeID.Text = "1"
            lblType.Text = "Dine-In"
            lblType.ForeColor = Color.SeaGreen
        End If
    End Sub

    Private Sub btnTakeout_Click(sender As Object, e As EventArgs) Handles btnTakeout.Click
        If txtTicketNo.Text <> "" Then
            lblTypeID.Text = "0"
            lblType.Text = "Take-Out"
            lblType.ForeColor = Color.Crimson
        End If
    End Sub

    Private Sub btnNewTicket_Click(sender As Object, e As EventArgs) Handles btnNewTicket.Click
        If txtTicketNo.Text <> "" Then
            MsgBox("Save the current ticket transaction or hold to create new ticket.", vbCritical + vbOKOnly, "Error create ticket")
            Exit Sub
        Else
            Try
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select MAX(ID) AS ID from RestaurantPOS_BillingInfoKOT"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()

                If rdr.Read() Then
                    txtTicketNo.Text = Format(rdr(0).ToString + 1, "000000")
                    is_edit = False
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If
    End Sub

    Private Sub btnMenuUp_Click(sender As Object, e As EventArgs) Handles btnMenuUp.Click
        Dim chnge As Integer = FlowLayoutPanel2.VerticalScroll.Value - FlowLayoutPanel2.VerticalScroll.SmallChange * 100
        FlowLayoutPanel2.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnMenuDown_Click(sender As Object, e As EventArgs) Handles btnMenuDown.Click
        Dim chnge As Integer = FlowLayoutPanel2.VerticalScroll.Value + FlowLayoutPanel2.VerticalScroll.SmallChange * 100
        FlowLayoutPanel2.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If dgw.Rows.Count > 0 Then
            'rowIndex = dgw.SelectedCells(0).OwningRow.Index
            ''create a new row
            'Dim row As DataRow
            'row = table.NewRow()

            '' add data to the row 

            'row(0) = dgw.Rows(rowIndex).Cells(0).Value.ToString()
            'row(1) = dgw.Rows(rowIndex).Cells(1).Value.ToString()
            'row(2) = Integer.Parse(dgw.Rows(rowIndex).Cells(2).Value.ToString())
            'row(3) = dgw.Rows(rowIndex).Cells(3).Value.ToString()

            'If rowIndex > 0 Then
            '    ' remove the selected row
            '    table.Rows.RemoveAt(rowIndex)

            '    ' insert the new row at a new position
            '    table.Rows.InsertAt(row, rowIndex - 1)
            '    dgw.ClearSelection()

            '    dgw.Rows(rowIndex - 1).Selected = True
            'End If
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If dgw.Rows.Count > 0 Then
            'rowIndex = dgw.SelectedCells(0).OwningRow.Index

            'Dim row As DataRow
            'row = table.NewRow()

            'row(0) = dgw.Rows(rowIndex).Cells(0).Value.ToString()
            'row(1) = dgw.Rows(rowIndex).Cells(1).Value.ToString()
            'row(2) = Integer.Parse(dgw.Rows(rowIndex).Cells(2).Value.ToString())
            'row(3) = dgw.Rows(rowIndex).Cells(3).Value.ToString()


            'If rowIndex < dgw.Rows.Count - 2 Then
            '    table.Rows.RemoveAt(rowIndex)

            '    table.Rows.InsertAt(row, rowIndex + 1)
            '    dgw.ClearSelection()

            '    dgw.Rows(rowIndex + 1).Selected = True
            'End If
        End If
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        'MsgBox(btn.Text)

        Call FillMenus(btn.Text)
    End Sub

    Private Sub btnTables_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        'MsgBox(btn.Text)
        If is_edit = True Then
            If MsgBox("Are you sure you want to transfer this to a different table?", vbQuestion + vbYesNo, "Confirm change") = vbYes Then
                'Update function here.
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update RestaurantPOS_OrderInfoKOT set TableNo=@d2 where TicketNo=@d1 and TableNo=@d3"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Trim(txtTicketNo.Text))
                cmd.Parameters.AddWithValue("@d2", btn.Text)
                cmd.Parameters.AddWithValue("@d3", txtTableNo.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                txtTableNo.Text = btn.Text
            Else
                Exit Sub
            End If
        Else
            txtTableNo.Text = btn.Text
        End If

    End Sub


    Private Sub btnAddMenu_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select * from Dish WHERE DishName=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", btn.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                If Not rdr Is Nothing Then
                    Dim rowId As Integer
                    Dim d_qty As Integer = 0
                    If Trim(txtQty.Text) = "" Then
                        d_qty = 1
                    Else
                        d_qty = Val(txtQty.Text)
                    End If
                    rowId = dgw.Rows.Add(Trim(rdr(0)), Trim(rdr(2)), d_qty, "")
                    dgw.CurrentCell = dgw.Rows(rowId).Cells(0)
                    'table.Rows.Add(Trim(rdr(0)), Trim(rdr(2)), "1", "")
                    dgw.Focus()

                Else
                    rdr.Close()
                    Exit Sub
                End If
            End If
            txtQty.Text = ""
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If is_edit = False Then

        Else

        End If
    End Sub

    Private Sub btnChgTable_Click(sender As Object, e As EventArgs) Handles btnChgTable.Click
        With frmTablesList
            .frm = "frmPOS"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnOpenTicket_Click(sender As Object, e As EventArgs) Handles btnOpenTicket.Click
        If is_edit = False Then
            With frmOpenTicketsRecord
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub frmPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                dgw.Focus()
        End Select
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgw.Rows.Count > 0 Then
            If is_edit = True Then
                'Update value qty here

                dgw.SelectedCells.Item(2).Value = Val(dgw.SelectedCells.Item(2).Value) + 1
            Else
                dgw.SelectedCells.Item(2).Value = Val(dgw.SelectedCells.Item(2).Value) + 1

            End If
        End If
    End Sub

    Private Sub btnLess_Click(sender As Object, e As EventArgs) Handles btnLess.Click
        If dgw.Rows.Count > 0 Then
            If is_edit = True Then
                'Update value qty here
                If Val(dgw.SelectedCells.Item(2).Value) > 1 Then
                    dgw.SelectedCells.Item(2).Value = Val(dgw.SelectedCells.Item(2).Value) - 1
                End If


            Else
                If Val(dgw.SelectedCells.Item(2).Value) > 1 Then
                    dgw.SelectedCells.Item(2).Value = Val(dgw.SelectedCells.Item(2).Value) - 1
                End If
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            If is_edit = True Then
                'Update value qty here


                dgw.Rows.RemoveAt(rowIndex)
            Else
                dgw.Rows.RemoveAt(rowIndex)
            End If
        End If
    End Sub

    Private Sub btnNotes_Click(sender As Object, e As EventArgs) Handles btnNotes.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmNotes1
                .frm = "frmPOS"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnChgRate_Click(sender As Object, e As EventArgs) Handles btnChgRate.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmCustomDialog13
                .frm = "frmPOS"
                .Label2.Text = "Enter New Amount"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnChgQty_Click(sender As Object, e As EventArgs) Handles btnChgQty.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            With frmCustomDialog13
                .frm = "frmPOS1"
                .Label2.Text = "Enter New Quantity"
                .rowIDs = rowIndex
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtQty.Text = txtQty.Text + Convert.ToString(0)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtQty.Text = txtQty.Text + Convert.ToString(1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtQty.Text = txtQty.Text + Convert.ToString(2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtQty.Text = txtQty.Text + Convert.ToString(3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtQty.Text = txtQty.Text + Convert.ToString(4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtQty.Text = txtQty.Text + Convert.ToString(5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtQty.Text = txtQty.Text + Convert.ToString(6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtQty.Text = txtQty.Text + Convert.ToString(7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtQty.Text = txtQty.Text + Convert.ToString(8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtQty.Text = txtQty.Text + Convert.ToString(9)
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        s = txtQty.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtQty.Text = x
        x = ""
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If is_edit = True Then

        Else
            If MsgBox("Are you sure you want to cancel this order?", vbQuestion + vbYesNo, "Confirmation") = vbYes Then
                txtQty.Text = ""
                txtTableNo.Text = ""
                txtTicketNo.Text = ""
                lblType.Text = ""
                lblTypeID.Text = ""
                dgw.Rows.Clear()
                is_edit = False
            Else
                Exit Sub
            End If
        End If
    End Sub
End Class