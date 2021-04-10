Public Class Animes
    Public Event clique(ByVal sender, ByVal e)
    Dim tooltip1 As New ToolTip()
    Dim IdAnimeMAL As Int64
    Property imagem() As Image
        Get
            Return picboxThumbnail.Image
        End Get
        Set(value As Image)
            picboxThumbnail.Image = value
        End Set
    End Property
    Property imagemlocal() As String
        Get
            Return picboxThumbnail.ImageLocation
        End Get
        Set(value As String)
            picboxThumbnail.ImageLocation = value
            If value = "" Then
                picboxThumbnail.Image = picboxThumbnail.ErrorImage
            End If
        End Set
    End Property
    Property nomeanime() As String
        Get
            Return lblNomeAnime.Text
        End Get
        Set(value As String)
            lblNomeAnime.Text = value
        End Set
    End Property
    Property idanime() As Int64
        Get
            Return IdAnimeMAL
        End Get
        Set(value As Int64)
            IdAnimeMAL = value
        End Set
    End Property
    Private Sub Tudo_click(sender As Object, e As EventArgs) Handles picboxThumbnail.Click, lblNomeAnime.Click, BarraBaixo.Click
        RaiseEvent clique(sender, e)
    End Sub

    Private Sub Animes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tooltip1.SetToolTip(picboxThumbnail, nomeanime)
        tooltip1.SetToolTip(lblNomeAnime, nomeanime)
        tooltip1.SetToolTip(BarraBaixo, nomeanime)
    End Sub
End Class
