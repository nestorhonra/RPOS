Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.IO

Public Class frmPrint

    Dim StoreName As String = ""
    Dim StoreAddress As String = ""
    Dim Img As Image
    Public TransNo As String = ""
    Dim TransDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
    Dim TINNo As String = ""
    Dim SNNo As String = ""
    Dim MIDNo As String = ""
    'for item sales | untuk item penjualan
    Public dtItem As DataTable
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat

    'declaring printing format class
    Dim c As New PrintingFormat

    'for subtotal & qty total
    Dim dblSubtotal As Double = 0
    Dim dblQty As Double = 0
    Dim dblPayment As Double = 50000
    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Getdata()

    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN), Logo,RTRIM(BaseCurrency),RTRIM(CurrencyCode) from Hotel", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read Then
                StoreName = rdr(1).ToString
                StoreAddress = rdr(2).ToString
                Dim data As Byte() = DirectCast(rdr(8), Byte())
                Dim ms As New MemoryStream(data)
                Img = Image.FromStream(ms)
                TINNo = "VAT REG TIN:" & rdr(5).ToString
                SNNo = "SERIAL NO:" & rdr(6).ToString
                MIDNo = "MIN:" & rdr(7).ToString
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Data_Load()
        dtItem = New DataTable
        With dtItem.Columns
            .Add("itemname", Type.GetType("System.String"))
            .Add("qty", Type.GetType("System.String"))
            .Add("price", Type.GetType("System.String"))
        End With

        Dim ItemRow As DataRow

        ItemRow = dtItem.NewRow()
        ItemRow("itemname") = "Taro Snack"
        ItemRow("qty") = "1"
        ItemRow("price") = "5000"
        dtItem.Rows.Add(ItemRow)

        ItemRow = dtItem.NewRow()
        ItemRow("itemname") = "Kopi Ice"
        ItemRow("qty") = "2"
        ItemRow("price") = "7000"
        dtItem.Rows.Add(ItemRow)

        ItemRow = dtItem.NewRow()
        ItemRow("itemname") = "Lolipop"
        ItemRow("qty") = "5"
        ItemRow("price") = "1000"
        dtItem.Rows.Add(ItemRow)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Data_Load()

        Printer.NewPrint()

        Printer.Print(Img, 250, 80)

        'Setting Font
        Printer.SetFont("Courier New", 9, FontStyle.Bold)
        Printer.Print(StoreName, {250}, {c.MidCenter}) 'Store Name | Nama Toko

        'Setting Font
        Printer.SetFont("Courier New", 7, FontStyle.Regular)
        Printer.Print(StoreAddress & ";", {250}, 0) 'Store Address | Alamat Toko

        'spacing
        Printer.Print(TINNo, {250}, {c.MidCenter})
        Printer.Print(SNNo, {250}, {c.MidCenter})
        Printer.Print(MIDNo, {250}, {c.MidCenter})

        Printer.Print(" ") 'spacing
        Printer.Print(TransNo) ' Transaction No | Nomor transaksi
        Printer.Print(TransDate) ' Trans Date | Tanggal transaksi

        Printer.Print(" ") 'spacing
        Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
        arrWidth = {90, 40, 50, 70} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.MidRight, c.MidRight, c.MidRight} 'array alignment 

        'column header split by ; | nama kolom dipisah dengan ;
        Printer.Print("item;qty;price;subtotal", arrWidth, arrFormat)
        Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
        Printer.Print("------------------------------------") 'line

        dblSubtotal = 0
        dblQty = 0
        'looping item sales | loop item penjualan
        For r = 0 To dtItem.Rows.Count - 1
            Printer.Print(dtItem.Rows(r).Item("itemname") & ";" & dtItem.Rows(r).Item("qty") & ";" &
                      dtItem.Rows(r).Item("price") & ";" &
                      (dtItem.Rows(r).Item("qty") * dtItem.Rows(r).Item("price")), arrWidth, arrFormat)
            dblQty = dblQty + CSng(dtItem.Rows(r).Item("qty"))
            dblSubtotal = dblSubtotal + (dtItem.Rows(r).Item("qty") * dtItem.Rows(r).Item("price"))
        Next

        Printer.Print("------------------------------------")
        arrWidth = {130, 120} 'array for column width | array untuk lebar kolom
        arrFormat = {c.MidLeft, c.MidRight} 'array alignment 

        Printer.Print("Total;" & dblSubtotal, arrWidth, arrFormat)
        Printer.Print("Payment;" & dblPayment, arrWidth, arrFormat)
        Printer.Print("------------------------------------")
        Printer.Print("Change;" & dblPayment - dblSubtotal, arrWidth, arrFormat)
        Printer.Print(" ")
        Printer.Print("Item Qty;" & dblQty, arrWidth, arrFormat)

        'Release the job for actual printing
        Printer.DoPrint()

    End Sub

End Class