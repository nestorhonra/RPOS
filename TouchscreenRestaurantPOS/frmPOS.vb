Imports System.Data.SqlClient
Public Class frmPOS
    Dim rowIndex As Integer
    Dim table As New DataTable("table")
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim is_edit As Boolean = False
    Private Sub frmPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblType.Text = ""
        lblTypeID.Text = ""
        txtTableNo.Text = ""
        txtTicketNo.Text = ""
        is_edit = False
        Call FillTables()
        Call FillCategory()

        'table.Columns.Add("First Name", Type.GetType("System.String"))
        'table.Columns.Add("Last Name", Type.GetType("System.String"))
        'table.Columns.Add("Age", Type.GetType("System.Int32"))
        'table.Columns.Add("Id", Type.GetType("System.Int32"))

        '' add rows to dataTable
        'table.Rows.Add("AA", "AA", 21, 1)
        'table.Rows.Add("BB", "BB", 33, 2)
        'table.Rows.Add("CC", "CC", 53, 3)
        'table.Rows.Add("DD", "DD", 19, 4)
        'table.Rows.Add("EE", "EE", 36, 5)
        'table.Rows.Add("FF", "FF", 63, 6)
        'table.Rows.Add("HH", "HH", 70.7)
        'table.Rows.Add("KK", "KK", 80.8)
        'table.Rows.Add("GG", "GG", 90, 9)
        'table.Rows.Add("MM", "MM", 100, 10)

        'dgw.DataSource = table
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub GetData()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor,Sum(TempRestaurantPOS_OrderInfoKOT.GrandTotal) from R_Table left Join TempRestaurantPOS_OrderInfoKOT on R_Table.TableNo=TempRestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel2.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Flat
            btn.Width = 93
            btn.Height = 50
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            FlowLayoutPanel3.Controls.Add(btn)
            ' AddHandler btn.Click, AddressOf Me.Button2_Click
        Loop
        con.Close()

    End Sub

    Private Sub FillTables()
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT distinct RTRIM(R_Table.TableNo),BkColor,Sum(TempRestaurantPOS_OrderInfoKOT.GrandTotal) from R_Table left Join TempRestaurantPOS_OrderInfoKOT on R_Table.TableNo=TempRestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        FlowLayoutPanel3.Controls.Clear()
        Do While (rdr.Read())
            Dim btn As New Button
            btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
            btn.TextAlign = ContentAlignment.MiddleCenter
            Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
            btn.BackColor = btnColor
            btn.FlatStyle = FlatStyle.Flat
            btn.Width = 93
            btn.Height = 50
            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            UserButtons.Add(btn)
            FlowLayoutPanel3.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Me.btnTables_Click
        Loop
        con.Close()
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
                btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(4)))
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Flat
                btn.Width = 93
                btn.Height = 50
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel2.Controls.Add(btn)
                ' AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Else
            MsgBox("")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnTableUp.Click
        Dim chnge As Integer = FlowLayoutPanel3.VerticalScroll.Value - FlowLayoutPanel3.VerticalScroll.SmallChange * 30
        FlowLayoutPanel3.AutoScrollPosition = New Point(0, chnge)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTableDown.Click
        Dim chnge As Integer = FlowLayoutPanel3.VerticalScroll.Value + FlowLayoutPanel3.VerticalScroll.SmallChange * 30
        FlowLayoutPanel3.AutoScrollPosition = New Point(0, chnge)
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
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            'create a new row
            Dim row As DataRow
            row = table.NewRow()

            ' add data to the row 

            row(0) = dgw.Rows(rowIndex).Cells(0).Value.ToString()
            row(1) = dgw.Rows(rowIndex).Cells(1).Value.ToString()
            row(2) = Integer.Parse(dgw.Rows(rowIndex).Cells(2).Value.ToString())
            row(3) = Integer.Parse(dgw.Rows(rowIndex).Cells(3).Value.ToString())

            If rowIndex > 0 Then
                ' remove the selected row
                table.Rows.RemoveAt(rowIndex)

                ' insert the new row at a new position
                table.Rows.InsertAt(row, rowIndex - 1)
                dgw.ClearSelection()

                dgw.Rows(rowIndex - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If dgw.Rows.Count > 0 Then
            rowIndex = dgw.SelectedCells(0).OwningRow.Index
            Dim row As DataRow
            row = table.NewRow()

            row(0) = dgw.Rows(rowIndex).Cells(0).Value.ToString()
            row(1) = dgw.Rows(rowIndex).Cells(1).Value.ToString()
            row(2) = Integer.Parse(dgw.Rows(rowIndex).Cells(2).Value.ToString())
            row(3) = Integer.Parse(dgw.Rows(rowIndex).Cells(3).Value.ToString())


            If rowIndex < dgw.Rows.Count - 2 Then
                table.Rows.RemoveAt(rowIndex)

                table.Rows.InsertAt(row, rowIndex + 1)
                dgw.ClearSelection()

                dgw.Rows(rowIndex + 1).Selected = True
            End If
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
                Dim cb As String = "Update RestaurantPOS_BillingInfoKOT set Table=@d2 where TicketNo=@d1 and Table=@d3"
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

    Private Sub btnChgTable_Click(sender As Object, e As EventArgs) Handles btnChgTable.Click
        is_edit = True
    End Sub
End Class