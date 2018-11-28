Imports System.Data
Imports MySql.Data.MySqlClient
Public Class Form4
    Dim waktu, lama As Integer
    Dim byr, Tbyr, jb As Integer
    Dim jp, j, m As Integer

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.ShowDialog()
    End Sub


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        jp = Val(TextBox4.Text)
        j = Val(TextBox5.Text)
        m = Val(TextBox6.Text)
        waktu = DateDiff(DateInterval.Minute, DateTimePicker1.Value, DateTimePicker2.Value)
        Button4.Enabled = True
        If waktu < 61 Then
            jb = jp
        Else
            lama = (waktu / 60) + 0.5 - 1
            jb = (lama * j) + jp
        End If
        If jb > m Then
            jb = m
        End If
        Label2.Text = waktu
        TextBox1.Text = jb
        Label12.Text = Format(Val(TextBox1.Text), "Rp#,#")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Tbyr = Val(TextBox1.Text)
        byr = Val(TextBox2.Text)
        Button1.Enabled = True
        If byr < Tbyr Then
            MsgBox("Pembayaran Kurang")
        Else
            TextBox3.Text = byr - Tbyr
            Label17.Text = Format(Val(TextBox3.Text), "Rp#,#")
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ParkirMasukToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Dim simpan As String = "INSERT INTO parkir_keluar(Kode_Nota,No_Plat,Jenis_Kendaraan,Waktu_Masuk,Waktu_Keluar,Jumlah_Bayar,Bayar,Kembali)" _
            & "VALUES('" & Label9.Text & "','" & Label15.Text & "','" & Label14.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm") & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        Call simpandata(simpan)
        Dim hapus As String = "Delete From daftar_nota where Kode = '" & Label9.Text & "'"
        Call hapusdata(hapus)
        Label9.Text = "0"
        Label15.Text = ""
        Label14.Text = ""
        Label6.Text = "00/00/000 00:00:00"
        Label10.Text = "00/00/000 00:00:00"
        Label12.Text = "Rp"
        Label17.Text = "Rp"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class