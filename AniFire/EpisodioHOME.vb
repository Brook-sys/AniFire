Public Class EpisodioHOME
    Public Event clique(ByVal sender, ByVal e)
    Dim tooltip1 As New ToolTip()
    Dim IdEpisodioMAL As String

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
    Property nomeepisodio() As String
        Get
            Return labelnomeEpisodio.Text
        End Get
        Set(value As String)
            labelnomeEpisodio.Text = value
        End Set
    End Property
    Property numeroepisodio() As String
        Get
            Return labelnumeroepisodio.Text
        End Get
        Set(value As String)
            labelnumeroepisodio.Text = value
        End Set
    End Property
    Property idepisodio() As String
        Get
            Return IdEpisodioMAL
        End Get
        Set(value As String)
            IdEpisodioMAL = value
        End Set
    End Property

    Private Sub Tudo_click(sender As Object, e As EventArgs) Handles picboxThumbnail.Click, labelnomeEpisodio.Click, Barrabaixo.Click, labelnumeroepisodio.Click
        RaiseEvent clique(sender, e)
    End Sub

    Private Sub EpisodioHOME_Load(sender As Object, e As EventArgs) Handles Me.Load

        tooltip1.SetToolTip(picboxThumbnail, nomeepisodio)
        tooltip1.SetToolTip(labelnomeEpisodio, nomeepisodio)
        tooltip1.SetToolTip(labelnumeroepisodio, nomeepisodio)
        tooltip1.SetToolTip(Barrabaixo, nomeepisodio)
    End Sub
End Class
