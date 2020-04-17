Imports System.Data.OleDb
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Add'
        Dim con As OleDbConnection = New OleDbConnection
        Try
            'To Connect the Database
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\AttendanceDemo.accdb"
            con.Open()

            Dim query As String
            query = "Insert into AttendanceDemo values (" + TextBox1.Text + ",'" + TextBox2.Text + "','" + ComboBox1.Text + "')"

            Dim command As OleDbCommand = New OleDbCommand(query, con)
            command.ExecuteNonQuery()
            command.Dispose()

            MsgBox("Added Successfully" & Environment.NewLine & "Id : " + TextBox1.Text & Environment.NewLine & "Status : " + ComboBox1.Text)
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Show'
        Me.Hide()
        Form2.Show()
    End Sub
End Class
