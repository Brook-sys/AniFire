Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces
Imports System.ComponentModel

Public Class formRelatarErro
    Public Ep As String
    Public Anime As String
    Public Erro As String
    Private fcon As New FirebaseConfig() With
        {
        .AuthSecret = "IBFRQOq601h4kQrlhPUGpghFdGYjuQvntokfldGf",
        .BasePath = "https://relatosdeerroanifire.firebaseio.com/"
        }
    Private client As IFirebaseClient
    Dim Dat As New Date
    Private Sub formRelatarErro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtboxEp.Text = Ep
        txtboxAnime.Text = Anime
        If Not Erro = "" Then
            txtboxErro.Text = Erro
        End If
        client = New FireSharp.FirebaseClient(fcon)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If txtboxAnime.Text = "" Then
            MsgBox("Informe o Anime.")
        ElseIf txtboxEp.Text = "" Then
            MsgBox("Informe o Episodio.")
        ElseIf txtboxEmail.Text = "" Then
            MsgBox("Por favor informe um Email para contato.")
        Else
            RelatarErro()
        End If
    End Sub
    Sub RelatarErro()
        Dim Err As New Erro
        Err.Ep = txtboxAnime.Text & " - Ep " & txtboxEp.Text
        Err.Erro = txtboxErro.Text
        Err.Data = Date.Now.Day.ToString("00") & "/" & Date.Now.Month.ToString("00") & "/" & Date.Now.Year.ToString & " - " & Date.Now.Hour.ToString("00") & ":" & Date.Now.Minute.ToString("00")
        Dim Numero As Integer
        Dim Gerador As Random = New Random
        Numero = Gerador.Next(1, 99999999)
        client.Set("Erros/" & Numero, Err)
        MsgBox("Erro Relatado com sucesso!! Logo Corrijiremos")
        Me.Close()
    End Sub

    Private Sub formRelatarErro_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class

Public Class Erro
    Public Property Data() As String
    Public Property Erro() As String
    Public Property Ep() As String
End Class