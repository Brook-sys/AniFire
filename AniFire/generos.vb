Public Class generos
    Public Event clique(ByVal sender, ByVal e)
    Dim tooltip1 As New ToolTip()
    Dim Id As String

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
    Property nomegenero() As String
        Get
            Return labelnomegenero.Text
        End Get
        Set(value As String)
            labelnomegenero.Text = value
        End Set
    End Property
    Property Idgenero() As String
        Get
            Return Id
        End Get
        Set(value As String)
            Id = value
        End Set
    End Property

    Private Sub Tudo_click(sender As Object, e As EventArgs) Handles picboxThumbnail.Click, labelnomegenero.Click, Barrabaixo.Click
        RaiseEvent clique(sender, e)
    End Sub

    Private Sub EpisodioHOME_Load(sender As Object, e As EventArgs) Handles Me.Load

        tooltip1.SetToolTip(picboxThumbnail, nomegenero)
        tooltip1.SetToolTip(labelnomegenero, nomegenero)
        tooltip1.SetToolTip(Barrabaixo, nomegenero)
    End Sub
End Class
