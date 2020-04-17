Imports System.Data.OleDb
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Close'
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'back
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form Load
        Dim con As OleDbConnection = New OleDbConnection
        Dim adapter As New OleDbDataAdapter
        Dim data As New DataTable
        Dim source As New BindingSource
        Try
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\AttendanceDemo.accdb"
            con.Open()

            Dim query As String
            query = "Select * from AttendanceDemo"

            Dim command As OleDbCommand = New OleDbCommand(query, con)
            adapter.SelectCommand = command
            adapter.Fill(data)
            source.DataSource = data

            DataGridView1.DataSource = source
            adapter.Update(data)

            command.ExecuteNonQuery()

            command.Dispose()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Show'
        Dim present_count As Integer = 0
        Dim absent_count As Integer = 0

        For index As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(index).Cells(2).Value = "Present" Then
                present_count += 1
            ElseIf DataGridView1.Rows(index).Cells(2).Value = "Absent" Then
                absent_count += 1
            End If
        Next
        TextBox1.Text = "Total Number of Present : " & present_count & Environment.NewLine &
                        "Total Number of Absent : " & absent_count
    End Sub
End Class