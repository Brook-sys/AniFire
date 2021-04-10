Public Class episodioa
    Public Property AnimeID() As Long = 0
    Public Property Ending() As String = ""
    Public Property Nome() As String = ""
    Public Property Numero() As Long = 0
    Public Property Opening() As String = ""
    Public Property Thumb_Url() As String = ""
    Public Property Video_Url() As String = ""
End Class
Public Class Animesa
    Public Property Ano_Lancamento() As Long = 0
    Public Property Generos() As String = ""
    Public Property Id() As Long = 0
    Public Property Nome() As String = ""
    Public Property NotaMAL() As Double = 0
    Public Property Sinopse() As String = ""
    Public Property Studios() As String = ""
    Public Property Thumb_Url() As String = ""
    Public Property Thumb_Ep() As String = ""
End Class
Public Class root
    Public Property episodios As List(Of episodioa)
    Public Property animes As List(Of Animesa)
End Class
Public Class Generoa
    Public Property Count() As Long = 0
    Public Property Name() As String = ""
    Public Property Nome_PtBr() As String = ""
    Public Property Thumb_Url() As String = ""
End Class
Public Class GeneroaAtualizar
    Public Property Count() As Long = 0
End Class
Public Class AnimeGeneroa
    Public Property AnimeId() As Long = 0
End Class
Public Class SDados
    Public Property Email() As String = ""
    Public Property Youtube() As String = ""
    Public Property Instagram() As String = ""
    Public Property Version() As String = ""
    Public Property DownloadUltimaVersao() As String = ""
    Public Property MostrarBoasVindas() As Boolean = False
    Public Property BoasVindas() As String = ""
End Class
