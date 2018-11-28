Imports System.Data
Imports MySql.Data.MySqlClient
Public Class Form2
    Dim j, k As String
    Dim DREADER As MySqlDataReader
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        'DateTimePicker2.CustomFormat = "dd/MM/y"
        Kodeotomatis()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Mobil")
        ComboBox1.Items.Add("Motor")


    End Sub

    Sub Kodeotomatis()
        Call koneksi()
        cmd = New MySqlCommand("Select Kode From parkir_masuk where Kode in(select max(Kode) from parkir_masuk) ", konek)
        DREADER = cmd.ExecuteReader
        DREADER.Read()
        If DREADER.HasRows = 0 Then
            Label8.Text = "00000001"
            DREADER.Close()
        End If
        If Not DREADER.HasRows Then
            Label8.Text = "00000001"
            DREADER.Close()
        Else
            Label8.Text = Val(Microsoft.VisualBasic.Right(DREADER.Item("Kode").ToString, 7)) + 1
            If Len(Label8.Text) = 1 Then
                Label8.Text = "0000000" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 2 Then
                Label8.Text = "000000" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 3 Then
                Label8.Text = "00000" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 4 Then
                Label8.Text = "0000" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 5 Then
                Label8.Text = "000" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 6 Then
                Label8.Text = "00" & Label8.Text & ""
            ElseIf Len(Label8.Text) = 7 Then
                Label8.Text = "0" & Label8.Text & ""
            End If
            DREADER.Close()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = TimeString
        Label7.Text = DateString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Kosong")
        Else
            Dim simpan As String = "INSERT INTO parkir_masuk(Kode,No_Plat,Jenis_Kendaraan,waktu)" _
            & "VALUES('" & Label8.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & Format(Now, "yyyy-MM-dd HH:mm") & "')"
            Call simpandata(simpan)

            Dim simpans As String = "INSERT INTO daftar_nota(Kode,No_Plat,Jenis_Kendaraan,waktu)" _
            & "VALUES('" & Label8.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & Format(Now, "yyyy-MM-dd HH:mm") & "')"
            Call simpandata(simpans)
            Call Kodeotomatis()

            TextBox1.Text = ""
            ComboBox1.Text = ""

            'j = ComboBox1.Text
            'k = Label8.Text
            Form7.nota1.Refresh()
            Form7.ShowDialog()

            'Dim report As New CrystalReport1
            'report.SetParameterValue("Jenis Kendaraan", j)
            'report.SetParameterValue("Kode Nota      ", k)

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ParkirMasukToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ParkirKeluarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form4.Show()
        Me.Close()
    End Sub
End Class