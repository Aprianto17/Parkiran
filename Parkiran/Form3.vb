Imports MySql.Data.MySqlClient
Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isigrib()
    End Sub

    Sub isigrib()
        Dim query As String = "SELECT * FROM daftar_nota"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Refresh()
        End If
    End Sub

    Sub seleksi()
        Dim strtext As String = "SELECT * FROM daftar_nota WHERE Kode like '%" & TextBox1.Text & "%'"
        Using cmd As New MySqlCommand(strtext, konek)
            Using adapter As New MySqlDataAdapter(cmd)
                Using DataSet As New DataSet()
                    adapter.Fill(DataSet)
                    DataGridView1.DataSource = DataSet.Tables(0)
                    DataGridView1.ReadOnly = True
                End Using
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call seleksi()
    End Sub



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.RowCount > 0 Then
            Dim baris As Integer
            'Dim waktu1 As String
            With DataGridView1
                baris = .CurrentRow.Index
                TextBox2.Text = .Item(0, baris).Value
                TextBox4.Text = .Item(1, baris).Value
                TextBox5.Text = .Item(2, baris).Value
                TextBox6.Text = .Item(3, baris).Value
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New MySqlCommand("SELECT tarif_parkir.jenis,tarif_parkir.jam_pertama,tarif_parkir.jam_brikut,tarif_parkir.max FROM tarif_parkir WHERE jenis = @id", konek)
        cmd.Parameters.Add("@id", MySqlDbType.String).Value = TextBox5.Text
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        If TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data belum dipilih")
        Else
            Form4.Button2.Enabled = True
            Form4.Label9.Text = TextBox2.Text
            Form4.Label15.Text = TextBox4.Text
            Form4.Label14.Text = TextBox5.Text
            Form4.Label6.Text = TextBox6.Text
            Form4.Label10.Text = Format(Now, "M/d/yyyy HH:mm:00")

            Form4.DateTimePicker1.Text = TextBox6.Text
            Form4.DateTimePicker2.Text = Form4.Label10.Text


            If table.Rows.Count() > 0 Then
                Form4.TextBox4.Text = table.Rows(0)(1).ToString()
                Form4.TextBox5.Text = table.Rows(0)(2).ToString()
                Form4.TextBox6.Text = table.Rows(0)(3).ToString()
            Else
                MessageBox.Show("data tidak ada")
            End If

            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Me.Close()
        Dim strtext As String = "SELECT * FROM daftar_nota WHERE No_Plat like '%" & TextBox1.Text & "%'"
        Using cmd As New MySqlCommand(strtext, konek)
            Using adapter As New MySqlDataAdapter(cmd)
                Using DataSet As New DataSet()
                    adapter.Fill(DataSet)
                    DataGridView1.DataSource = DataSet.Tables(0)
                    DataGridView1.ReadOnly = True
                End Using
            End Using
        End Using
    End Sub

End Class