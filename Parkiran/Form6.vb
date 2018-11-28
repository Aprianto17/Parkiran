Imports MySql.Data.MySqlClient

Public Class Form6
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.RowCount > 0 Then
            Dim baris As Integer
            With DataGridView1
                baris = .CurrentRow.Index
                Label14.Text = .Item(0, baris).Value
                TextBox1.Text = .Item(1, baris).Value
                TextBox2.Text = .Item(2, baris).Value
                TextBox3.Text = .Item(3, baris).Value
            End With
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isigrib()
    End Sub
    Sub isigrib()
        Dim query As String = "SELECT * FROM tarif_parkir"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Refresh()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Data Kosong")
        Else
            Dim edit As String = "Update tarif_parkir set jam_pertama = " & TextBox1.Text & ",jam_brikut = " & TextBox2.Text & ", max = '" & TextBox3.Text & "' where Jenis = '" & Label14.Text & "'"
            Call editdata(edit)
            Call isigrib()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If
    End Sub
End Class