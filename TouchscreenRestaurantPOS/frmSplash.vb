Imports System.Data.SqlClient
Public Class frmSplash

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            Label3.Visible = Not Label3.Visible
            
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                If txtActivationID.Text = TextBox1.Text Then
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 20) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 40) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 60) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 80) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmLogin.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
                End If
            Else

                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 20) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 40) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 60) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 80) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer1.Enabled = False
                    Me.Hide()
                End If
            End If
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                If txtActivationID.Text <> TextBox1.Text Then

                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 20) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 40) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 60) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 80) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmActivation.Show()
                        Timer1.Enabled = False
                        Me.Hide()
                    End If
                End If
            Else

                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 20) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 40) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 60) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 80) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer1.Enabled = False
                    Me.Hide()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
            Panel1.Anchor = AnchorStyles.None
            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                Dim i As System.Management.ManagementObject
                Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
                For Each i In searchInfo_Processor.Get()
                    txtHardwareID.Text = i("ProcessorID").ToString
                Next
                Dim st As String = (txtHardwareID.Text)
                TextBox1.Text = Encryption.MakePassword(st, 659)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select RTRIM(ActivationID) from Activation where HardwareID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtActivationID.Text = Decrypt(rdr.GetValue(0))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try
    End Sub
End Class