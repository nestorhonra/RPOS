Imports System.Data.SqlClient

Public Class frmRecipeRecord

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select R_ID,RTRIM(RecipeName),RTRIM(DishName),RTRIM(Category),FixedCost,RTRIM(Description) from Recipe,Dish where Dish.DishName=Recipe.Dish order by RecipeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
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
        txtRecipeName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmRecipe.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmRecipe.txtID.Text = dr.Cells(0).Value.ToString()
                frmRecipe.txtRecipeName.Text = dr.Cells(1).Value.ToString()
                frmRecipe.cmbItemName.Text = dr.Cells(2).Value.ToString()
                frmRecipe.txtCategory.Text = dr.Cells(3).Value.ToString()
                frmRecipe.txtFixedCost.Text = dr.Cells(4).Value.ToString()
                frmRecipe.txtDescription.Text = dr.Cells(5).Value.ToString()
                frmRecipe.btnSave.Enabled = False
                frmRecipe.btnUpdate.Enabled = True
                frmRecipe.btnDelete.Enabled = True
                frmRecipe.btnPrint.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select (PID),RTRIM(ProductName),Quantity,RTRIM(Recipe_Join.Unit) from Product,Recipe,Recipe_Join where Product.PID=Recipe_Join.ProductID and Recipe.R_ID=Recipe_Join.RecipeID and R_ID=" & dr.Cells(0).Value & " order by ProductName"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRecipe.dgw.Rows.Clear()
                While (rdr.Read() = True)
                    frmRecipe.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
                End While
                con.Close()
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

    Private Sub txtRecipeName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRecipeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select R_ID,RTRIM(RecipeName),RTRIM(DishName),RTRIM(Category),FixedCost,RTRIM(Description) from Recipe,Dish where Dish.DishName=Recipe.Dish and RecipeName like '%" & txtRecipeName.Text & "%' order by RecipeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

