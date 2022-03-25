Imports System.Security.Cryptography
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net.Mail

Module ModFunc
    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("http://www.google.com")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objresp As System.Net.WebResponse

        Try
            objresp = objWebReq.GetResponse
            objresp.Close()
            objresp = Nothing
            Return True

        Catch ex As Exception
            objresp = Nothing
            objWebReq = Nothing
            Return False
        End Try
    End Function

    Sub LogFunc(ByVal st1 As String, ByVal st2 As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "insert into Logs(UserID,Date,Operation) VALUES (@d1,@d2,@d3)"
        cmd = New SqlCommand(cb)
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@d1", st1)
        cmd.Parameters.AddWithValue("@d2", System.DateTime.Now)
        cmd.Parameters.AddWithValue("@d3", st2)
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub SMSFunc(ByVal st1 As String, ByVal st2 As String, ByVal st3 As String)
        st3 = st3.Replace("@MobileNo", st1).Replace("@Message", st2)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim myUri As New Uri(st3)
        request = DirectCast(WebRequest.Create(myUri), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
    End Sub
    Public Function Encrypt(password As String) As String
        Dim strmsg As String = String.Empty
        Dim encode As Byte() = New Byte(password.Length - 1) {}
        encode = Encoding.UTF8.GetBytes(password)
        strmsg = Convert.ToBase64String(encode)
        Return strmsg
    End Function

    Public Function Decrypt(encryptpwd As String) As String
        Dim decryptpwd As String = String.Empty
        Dim encodepwd As New UTF8Encoding()
        Dim Decode As Decoder = encodepwd.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(encryptpwd)
        Dim charCount As Integer = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        decryptpwd = New [String](decoded_char)
        Return decryptpwd
    End Function
    Sub RefreshRecord2()
        Dim obj As frmItem = DirectCast(Application.OpenForms("frmDish"), frmItem)
        obj.fillCombo()
    End Sub
   
    Sub ExportExcel(ByVal st As Object)
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = st.RowCount
            colsTotal = st.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = st.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = st.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub
    Sub SupplierLedgerSave(ByVal a As DateTime, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As Decimal, ByVal f As Decimal, ByVal g As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "insert into SupplierLedgerBook(Date, Name, LedgerNo, Label,Debit,Credit,PartyID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
        cmd = New SqlCommand(cb)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Parameters.AddWithValue("@d2", b)
        cmd.Parameters.AddWithValue("@d3", c)
        cmd.Parameters.AddWithValue("@d4", d)
        cmd.Parameters.AddWithValue("@d5", e)
        cmd.Parameters.AddWithValue("@d6", f)
        cmd.Parameters.AddWithValue("@d7", g)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub SupplierLedgerDelete(ByVal a As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cq As String = "delete from SupplierLedgerBook where LedgerNo=@d1"
        cmd = New SqlCommand(cq)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub SupplierLedgerUpdate(ByVal a As DateTime, ByVal b As String, ByVal e As Decimal, ByVal f As Decimal, ByVal g As String, ByVal h As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "Update SupplierLedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4 where LedgerNo=@d5 and Label=@d6"
        cmd = New SqlCommand(cb)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Parameters.AddWithValue("@d2", b)
        cmd.Parameters.AddWithValue("@d3", e)
        cmd.Parameters.AddWithValue("@d4", f)
        cmd.Parameters.AddWithValue("@d5", g)
        cmd.Parameters.AddWithValue("@d6", h)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub LedgerSave(ByVal a As DateTime, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As Decimal, ByVal f As Decimal, ByVal g As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "insert into LedgerBook(Date, Name, LedgerNo, Label,Debit,Credit,PartyID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
        cmd = New SqlCommand(cb)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Parameters.AddWithValue("@d2", b)
        cmd.Parameters.AddWithValue("@d3", c)
        cmd.Parameters.AddWithValue("@d4", d)
        cmd.Parameters.AddWithValue("@d5", e)
        cmd.Parameters.AddWithValue("@d6", f)
        cmd.Parameters.AddWithValue("@d7", g)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub LedgerDelete(ByVal a As String, ByVal b As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cq As String = "delete from LedgerBook where LedgerNo=@d1 and Label=@d2"
        cmd = New SqlCommand(cq)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Parameters.AddWithValue("@d2", b)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub
    Sub LedgerUpdate(ByVal a As DateTime, ByVal b As String, ByVal e As Decimal, ByVal f As Decimal, ByVal g As String, ByVal h As String, ByVal i As String)
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "Update LedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5 where LedgerNo=@d6 and Label=@d7"
        cmd = New SqlCommand(cb)
        cmd.Parameters.AddWithValue("@d1", a)
        cmd.Parameters.AddWithValue("@d2", b)
        cmd.Parameters.AddWithValue("@d3", e)
        cmd.Parameters.AddWithValue("@d4", f)
        cmd.Parameters.AddWithValue("@d5", g)
        cmd.Parameters.AddWithValue("@d6", h)
        cmd.Parameters.AddWithValue("@d7", i)
        cmd.Connection = con
        cmd.ExecuteReader()
        con.Close()
    End Sub

    Public Function toMoney(ByVal srcCurr As String) As String
        toMoney = Format(toNumber(srcCurr), "#,##0.00")
    End Function

    Public Function toNumber(ByVal srcCurrency As String, Optional ByRef RetZeroIfNegative As Boolean = False) As Double
        Dim retValue As Double
        If srcCurrency = "" Then
            toNumber = 0
        Else
            If InStr(1, srcCurrency, ",") > 0 Then
                retValue = Val(Replace(srcCurrency, ",", "", , , CompareMethod.Text))
            Else
                retValue = Val(srcCurrency)
            End If
            If RetZeroIfNegative = True Then
                If retValue < 1 Then retValue = 0
            End If
            toNumber = retValue
            retValue = 0
        End If
    End Function

    Public Function changeOneZeroValue(ByVal srcStr As String) As String
        changeOneZeroValue = "0"
        Select Case srcStr
            Case "Y" : changeOneZeroValue = "1"
            Case "N" : changeOneZeroValue = "0"
            Case "True" : changeOneZeroValue = "1"
            Case "False" : changeOneZeroValue = "0"
            Case "1" : changeOneZeroValue = "1"
            Case "0" : changeOneZeroValue = "0"
        End Select
    End Function

End Module
