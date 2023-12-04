Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Main

    Public Sub searchrec(ByRef SQLSTATEMENT As String)
        SQLCONN.ConnectionString = con
        If SQLCONN.State = ConnectionState.Closed Then

            SQLCONN.Open()

            Dim dt As New DataTable
            Dim MyCommand As New MySqlCommand(SQLSTATEMENT, SQLCONN)
            Dim myDataAdapter As New MySqlDataAdapter(SQLSTATEMENT, SQLCONN)
            myDataAdapter.Fill(dt)
            Dim sqlrdr As MySqlDataReader

            sqlrdr = MyCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            While sqlrdr.Read()
                Label8.Text = sqlrdr("id")
                Label6.Text = sqlrdr("Fullname")
                TextBox1.Text = sqlrdr("Fullname")
                TextBox2.Text = sqlrdr("Email")
                TextBox3.Text = sqlrdr("Username")
                TextBox4.Text = sqlrdr("Password")

            End While
        End If
        SQLCONN.Close()
        SQLCONN.Dispose()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLSTATEMENT As String = "UPDATE `user` Set `Fullname`='" & TextBox1.Text & "',`Email`='" & TextBox2.Text & "',`Username` = '" & TextBox3.Text & "', Password ='" & TextBox4.Text & "' WHERE id = '" & Label8.Text & "'"

        save(SQLSTATEMENT)
        MsgBox("Data updated successfuly", vbInformation)
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class