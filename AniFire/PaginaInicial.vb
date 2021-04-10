Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports Newtonsoft.Json.Linq
Imports AxWMPLib
Imports System.ComponentModel
Imports System.Threading

Public Class PaginaInicial
    Dim Thr As Thread
    Dim Atualizado As Boolean
    Dim Email As String
    Dim CanalYoutube As String
    Dim PerfilInstagram As String
    Dim VersionAtual As String
    Dim DownloadNovaVersao As String
    Dim wb As New WebClient()
    Dim imgs As New ImageList()
    Dim btnPaginaAberta As Object

    Dim HEpisodiosHOME As Decimal = -1
    Dim VEpisodiosHOME As Decimal = 0
    Dim CEpisodiosHOME As Decimal = 0

    Dim HAnime As Decimal = -1
    Dim VAnime As Decimal = 0
    Dim CAnime As Decimal = 0

    Dim HAnimeSearch As Decimal
    Dim VAnimeSearch As Decimal
    Dim CAnimeSearch As Decimal

    Dim HGenero As Decimal = -1
    Dim VGenero As Decimal = 0
    Dim CGenero As Decimal = 0

    Dim HAnimeGenero As Decimal = -1
    Dim VAnimeGenero As Decimal = 0
    Dim CAnimeGenero As Decimal = 0

    Dim oanimea As New Animesa
    Dim oepisodioa As New episodioa

    Dim indexx As Integer
    Dim Volume As Integer
    Dim Tamanho As Integer
    Dim MostrarVolume As Boolean
    Public LinkEpisodio As String
    Public NumeroEpisodio As Decimal
    Public NomeEpisodio As Decimal
    Dim Selecao As Boolean = False
    Dim SelecaoVolume As Boolean = False
    Dim LinhaAssistido As Pen
    Dim LinhaFalta As Pen
    Dim LinhaSom As Pen
    Dim CursorVideo As Brush
    Dim ANCHOCURSOR As Integer = 5
    Dim ALTOCURSOR As Integer = 20
    Dim VALOR As Integer
    Dim Total As Integer

    Private fcon As New FirebaseConfig() With
        {
        .AuthSecret = "",
        .BasePath = ""
        }

    Private client As IFirebaseClient
    Dim Animes As JObject
    Dim Generos As JObject
    Dim EpsHome As JObject
    Dim Episodios As JObject
    Dim SobreDados As JObject
    Dim EPdHome As Boolean = False
    Dim ListAnimes As List(Of Animesa) = New List(Of Animesa)
    Dim ListEps As List(Of episodioa) = New List(Of episodioa)

    Sub acoesbtn(sender As Object, e As EventArgs)
        Dim Pesquisa = False
        Dim pgnAberta As Object
        painelAnimesHOME.Visible = False
        painelEpisodiosHOME.Visible = False
        painelGeneros.Visible = False
        painelSobre.Visible = False
        painelAnimeGenero.Visible = False
        painelPesquisa.Visible = False
        btnPaginaAberta.BackColor = Color.FromArgb(51, 51, 51)
        btnPaginaAberta.ForeColor = Color.FromArgb(214, 214, 214)
        btnPaginaAberta.barcolor = Color.FromArgb(33, 33, 33)
        btnPaginaAberta.actived = False

        If sender Is BotaoHOME Or sender Is Me Then
            btnPaginaAberta = BotaoHOME
            pgnAberta = painelEpisodiosHOME
        ElseIf sender Is BotaoANIMES Then
            btnPaginaAberta = BotaoANIMES
            pgnAberta = painelAnimesHOME
        ElseIf sender Is BotaoGENEROS Then
            btnPaginaAberta = BotaoGENEROS
            pgnAberta = painelGeneros
        ElseIf sender Is BotaoSOBRE Then
            btnPaginaAberta = BotaoSOBRE
            pgnAberta = painelSobre
        ElseIf sender Is Pesquisa1 Then
            pgnAberta = painelPesquisa
            Pesquisa = True
        ElseIf sender.name.contains("Genero") Then
            pgnAberta = painelAnimeGenero
        End If
        EstruturaPaginaInicial.Controls.Add(pgnAberta)
        EstruturaPaginaInicial.SetColumn(pgnAberta, 1)
        EstruturaPaginaInicial.SetRow(pgnAberta, 2)
        EstruturaPaginaInicial.SetColumnSpan(pgnAberta, EstruturaPaginaInicial.ColumnCount - 1)
        pgnAberta.Dock = DockStyle.Fill
        pgnAberta.Visible = True
        If Not Pesquisa Then
            btnPaginaAberta.actived = True
            btnPaginaAberta.backcolor = Color.FromArgb(51, 51, 51)
            btnPaginaAberta.forecolor = Color.White
            btnPaginaAberta.barcolor = Color.FromArgb(76, 166, 79)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Do
            Try
                client = New FireSharp.FirebaseClient(fcon)
                EpsHome = client.Get("EpisodiosHome").ResultAs(Of JObject)
                Episodios = client.Get("Episodios").ResultAs(Of JObject)
                Animes = client.Get("Animes").ResultAs(Of JObject)
                Episodios = client.Get("Episodios").ResultAs(Of JObject)
                Generos = client.Get("Generos").ResultAs(Of JObject)
                SobreDados = client.Get("SobreDados").ResultAs(Of JObject)
                Exit Do
            Catch
                If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo, "Erro fatal") = MsgBoxResult.No Then
                    Me.Close()
                    Exit Sub
                End If
            End Try
        Loop
        btnPaginaAberta = BotaoHOME
        BotaoHOME.actived = True
        painelEpisodiosHOME.Visible = True
        acoesbtn(sender, e)
        EstruturaPaginaInicial.Dock = DockStyle.Fill
        EstruturaPaginaInicial.Visible = True

        For Each EpHome In EpsHome
            Dim animeEep = EpHome.Value("ep").ToString
            Dim OEpi As New episodioa
            OEpi.AnimeID = CLng(Episodios.SelectToken(animeEep).SelectToken("AnimeID").ToString)
            OEpi.Ending = Episodios.SelectToken(animeEep).SelectToken("Ending").ToString
            OEpi.Nome = Episodios.SelectToken(animeEep).SelectToken("Nome").ToString
            OEpi.Numero = CLng(Episodios.SelectToken(animeEep).SelectToken("Numero").ToString)
            OEpi.Opening = Episodios.SelectToken(animeEep).SelectToken("Opening").ToString
            OEpi.Thumb_Url = Episodios.SelectToken(animeEep).SelectToken("Thumb_Url").ToString
            OEpi.Video_Url = Episodios.SelectToken(animeEep).SelectToken("Video_Url").ToString
            CriarEpisodioHOME(OEpi)
        Next

        For Each Animeaa In Animes
            Dim OANIME As New Animesa
            OANIME.Ano_Lancamento = CLng(Animeaa.Value("Ano_Lancamento").ToString)
            OANIME.Id = CLng(Animeaa.Value("Id").ToString)
            OANIME.Generos = Animeaa.Value("Generos").ToString
            OANIME.Nome = Animeaa.Value("Nome").ToString
            OANIME.NotaMAL = CDbl(Animeaa.Value("NotaMAL").ToString)
            OANIME.Sinopse = Animeaa.Value("Sinopse").ToString
            OANIME.Studios = Animeaa.Value("Studios").ToString
            OANIME.Thumb_Url = Animeaa.Value("Thumb_Url").ToString
            OANIME.Thumb_Ep = Animeaa.Value("Thumb_Ep").ToString
            ListAnimes.Add(OANIME)
            criaranime(OANIME)
        Next
        For Each generoaa In Generos
            Dim OGENERo As New Generoa
            OGENERo.Count = CLng(generoaa.Value("Count").ToString)
            OGENERo.Name = generoaa.Value("Name").ToString
            OGENERo.Nome_PtBr = generoaa.Value("Nome_PtBr").ToString
            OGENERo.Thumb_Url = generoaa.Value("Thumb_Url").ToString
            criargenero(OGENERo)
        Next
        Email = SobreDados.SelectToken("Email")
        CanalYoutube = SobreDados.SelectToken("Youtube")
        PerfilInstagram = SobreDados.SelectToken("Instagram")
        VersionAtual = SobreDados.SelectToken("Version").ToString
        DownloadNovaVersao = SobreDados.SelectToken("DownloadUltimaVersao").ToString
        Dim MostrarBoasVindas As Boolean = Convert.ToBoolean(SobreDados.SelectToken("MostrarBoasVindas").ToString)

        Dim majorv As Integer = VersionAtual.Split(".")(0)
        Dim minorv As Integer = VersionAtual.Split(".")(1)
        Dim buildv As Integer = VersionAtual.Split(".")(2)
        Dim revisionv As Integer = VersionAtual.Split(".")(3)
        If majorv > My.Application.Info.Version.Major Then
            Atualizado = False

        ElseIf minorv > My.Application.Info.Version.Minor Then
            Atualizado = False

        ElseIf buildv > My.Application.Info.Version.Build Then
            Atualizado = False

        ElseIf revisionv > My.Application.Info.Version.Revision Then
            Atualizado = False

        Else
            Atualizado = True
        End If
        If Not Atualizado Then
            lblNovaVersao.Visible = True
            lblNovaVersao.Text = majorv & "." & minorv & "(Build " & buildv & "." & revisionv & ") Já Disponivel"

        ElseIf Atualizado Then
            lblBaixarNovaVersao.Cursor = Cursors.Arrow
            lblBaixarNovaVersao.Text = "Programa Atualizado"
        End If
        lblEmail.Text = "Email: " & Email
        With My.Application.Info.Version
            lblVersion.Text = "Versão " & .Major & "." & .Minor & " (Build " & .Build & "." & .Revision & ")"
        End With
        If MostrarBoasVindas Then
            Dim BoasVindas As String = SobreDados.SelectToken("BoasVindas").ToString
            MsgBox(BoasVindas)
        End If

    End Sub

    Private Sub BotoesPagina_clique(sender As Object, e As EventArgs) Handles BotaoHOME.clique, BotaoANIMES.clique, BotaoGENEROS.clique, BotaoSOBRE.clique
        acoesbtn(sender, e)
    End Sub

    Sub CriarEpisodioHOME(ByVal ep As episodioa)
        HEpisodiosHOME = HEpisodiosHOME + 1
        CEpisodiosHOME = CEpisodiosHOME + 1
        Dim ANimen As JToken = Animes.SelectToken(ep.AnimeID)
        Dim Oanime As New Animesa
        Oanime.Ano_Lancamento = CLng(ANimen.SelectToken("Ano_Lancamento").ToString)
        Oanime.Id = CLng(ANimen.SelectToken("Id").ToString)
        Oanime.Generos = ANimen.SelectToken("Generos").ToString
        Oanime.Nome = ANimen.SelectToken("Nome").ToString
        Oanime.NotaMAL = CDbl(ANimen.SelectToken("NotaMAL").ToString)
        Oanime.Sinopse = ANimen.SelectToken("Sinopse").ToString
        Oanime.Studios = ANimen.SelectToken("Studios").ToString
        Oanime.Thumb_Url = ANimen.SelectToken("Thumb_Url").ToString
        Dim ephome As New EpisodioHOME
        With ephome
            .Size = New Size(205, 156)
            .Location = New Point(HEpisodiosHOME * (ephome.Size.Width + 10), VEpisodiosHOME * (ephome.Size.Height + 10))
            .numeroepisodio = ep.Numero
            .imagemlocal = ep.Thumb_Url
            .nomeepisodio = Oanime.Nome & " Episodio " & ep.Numero
            .Name = "EpisodioHome" & CEpisodiosHOME
            .Tag = ep
        End With
        Dim rgx1 As String = "https://.*\.blogger\.com/video\.g\?token=.*"
        Dim mm1 As Match = Regex.Match(ep.Video_Url, rgx1, RegexOptions.IgnoreCase)
        If mm1.Success And ep.Thumb_Url = "0" Then
            ephome.imagemlocal = PickThumbEVideo(ep.Video_Url, True)
        End If
        AddHandler ephome.clique, Sub()
                                      EstruturaPaginaInicial.Visible = False
                                      oanimea = Oanime
                                      oepisodioa = ep
                                      Dim eps As JToken = Episodios.SelectToken(ep.AnimeID & "_" & ep.Numero)
                                      lblNomeEpisodio.Text = "Nome: " & eps.SelectToken("Nome").ToString
                                      lblOpeningEpisodio.Text = "Opening: " & eps.SelectToken("Opening").ToString
                                      lblEndingEpisodio.Text = "Ending: " & eps.SelectToken("Ending").ToString
                                      picboxInfoEpisodio.Tag = eps.SelectToken("Numero").ToString
                                      Me.Text = oanimea.Nome & " - Episodio " & ep.Numero
                                      lblTituloEpisodio.Text = oanimea.Nome & " - Episodio " & ep.Numero
                                      Dim ListaEpisodios As List(Of episodioa) = New List(Of episodioa)
                                      For Each item In Episodios
                                          If item.Value("AnimeID").ToString = oanimea.Id Then
                                              If item.Value("Numero").ToString = ep.Numero.ToString Then
                                                  ListaEpisodios.Add(ep)
                                              Else
                                                  Dim epss As New episodioa
                                                  epss.Ending = item.Value("Ending").ToString
                                                  epss.Nome = item.Value("Nome").ToString
                                                  epss.Numero = item.Value("Numero").ToString
                                                  epss.Opening = item.Value("Opening").ToString
                                                  epss.Thumb_Url = item.Value("Thumb_Url").ToString
                                                  epss.Video_Url = item.Value("Video_Url").ToString
                                                  ListaEpisodios.Add(epss)
                                              End If

                                          End If
                                      Next
                                      ListaEpisodios.Sort(Function(x, y) x.Numero.CompareTo(y.Numero))
                                      ListEps.Clear()
                                      For Each epsas In ListaEpisodios
                                          ListEps.Add(epsas)
                                      Next
                                      picboxProximoEP.Visible = True
                                      picboxEpAnterior.Visible = True
                                      If ListEps.IndexOf(oepisodioa) = 0 Then
                                          picboxEpAnterior.Visible = False
                                      ElseIf ListEps.IndexOf(oepisodioa) = ListEps.Count - 1 Then
                                          picboxProximoEP.Visible = False
                                      End If
                                      LinhaAssistido = New Pen(Color.Red, 5)
                                      LinhaSom = New Pen(Color.White, 5)
                                      LinhaFalta = New Pen(Color.DarkGray, 5)
                                      Tamanho = picboxBarraVolume.Width / 2
                                      Desenhar()
                                      DesenharVolume()
                                      TimerMostrarVolume.Enabled = True
                                      TimerVideo.Enabled = True
                                      painelAnime.Visible = False
                                      painelAssistirEpisodio.Visible = True
                                      painelAssistirEpisodio.Dock = DockStyle.Fill
                                      Dim rgx As String = "https://.*\.blogger\.com/video\.g\?token=.*"
                                      Dim mm As Match = Regex.Match(ep.Video_Url, rgx, RegexOptions.IgnoreCase)
                                      If mm.Success Then
                                          PlayerEpisodio.URL = PickThumbEVideo(ep.Video_Url)
                                      Else
                                          PlayerEpisodio.URL = ep.Video_Url
                                      End If
                                      PaginaInicial_Resize(Nothing, EventArgs.Empty)
                                      EPdHome = True
                                  End Sub
        If HEpisodiosHOME = 2 Then
            VEpisodiosHOME = VEpisodiosHOME + 1
            HEpisodiosHOME = -1
        End If
        painelEpisodiosHOME.Controls.Add(ephome)
    End Sub

    Sub criaranime(ByVal oAnime As Animesa)
        HAnime = HAnime + 1
        CAnime = CAnime + 1
        Dim anime As New Animes
        With anime
            .Size = New Size(151, 262)
            .Location = New Point(HAnime * (anime.Size.Width + 10), VAnime * (anime.Size.Height + 10))
            .imagemlocal = oAnime.Thumb_Url
            .nomeanime = oAnime.Nome
            .idanime = oAnime.Id
            .Name = "Anime" & CAnime
            .Tag = oAnime
        End With
        AddHandler anime.clique, Sub()
                                     oanimea = oAnime
                                     EstruturaPaginaInicial.Visible = False
                                     painelAnime.Visible = True
                                     painelAnime.Dock = DockStyle.Fill
                                     listviewEpisodios.Items.Clear()
                                     imgs.Images.Clear()
                                     Me.Text = oAnime.Nome
                                     Label1.Text = oAnime.Ano_Lancamento
                                     Label2.Text = "       " & oAnime.NotaMAL
                                     Label3.Text = "Studios: " & oAnime.Studios
                                     Label4.Text = "Generos: " & oAnime.Generos.Replace(",", ", ").Replace("_", " ")
                                     labelSinopseAnime.Text = oAnime.Sinopse
                                     labelTituloAnime.Text = oAnime.Nome
                                     thumbAnime.ImageLocation = oAnime.Thumb_Url
                                     Dim ListaEpisodios As List(Of episodioa) = New List(Of episodioa)
                                     For Each item In Episodios
                                         If item.Value("AnimeID").ToString = oAnime.Id Then
                                             Dim ep As New episodioa
                                             ep.Ending = item.Value("Ending").ToString
                                             ep.Nome = item.Value("Nome").ToString
                                             ep.Numero = item.Value("Numero").ToString
                                             ep.Opening = item.Value("Opening").ToString
                                             ep.Thumb_Url = item.Value("Thumb_Url").ToString
                                             ep.Video_Url = item.Value("Video_Url").ToString
                                             ListaEpisodios.Add(ep)

                                         End If
                                     Next
                                     ListaEpisodios.Sort(Function(x, y) x.Numero.CompareTo(y.Numero))
                                     ListEps.Clear()
                                     For Each EP In ListaEpisodios
                                         ListEps.Add(EP)
                                     Next
                                     Thr = New Thread(AddressOf js)
                                     Thr.Start()
                                 End Sub
        If HAnime = 3 Then
            VAnime = VAnime + 1
            HAnime = -1
        End If
        painelAnimesHOME.Controls.Add(anime)
    End Sub

    Sub criaranimeSearch(ByVal oAnime As Animesa)
        HAnimeSearch = HAnimeSearch + 1
        CAnimeSearch = CAnimeSearch + 1
        Dim anime As New Animes
        With anime
            .Size = New Size(151, 262)
            .Location = New Point(HAnimeSearch * (anime.Size.Width + 10), VAnimeSearch * (anime.Size.Height + 10))
            .imagemlocal = oAnime.Thumb_Url
            .nomeanime = oAnime.Nome
            .idanime = oAnime.Id
            .Name = "Anime" & CAnime
            .Tag = oAnime
        End With
        AddHandler anime.clique, Sub()
                                     ListEps.Clear()
                                     oanimea = oAnime
                                     EstruturaPaginaInicial.Visible = False
                                     painelAnime.Visible = True
                                     painelAnime.Dock = DockStyle.Fill
                                     listviewEpisodios.Items.Clear()
                                     imgs.Images.Clear()
                                     Me.Text = oAnime.Nome
                                     Label1.Text = oAnime.Ano_Lancamento
                                     Label2.Text = "       " & oAnime.NotaMAL
                                     Label3.Text = "Studios: " & oAnime.Studios
                                     Label4.Text = "Generos: " & oAnime.Generos.Replace(",", ", ").Replace("_", " ")
                                     labelSinopseAnime.Text = oAnime.Sinopse
                                     labelTituloAnime.Text = oAnime.Nome
                                     thumbAnime.ImageLocation = oAnime.Thumb_Url


                                     Dim arra As New ArrayList
                                     For Each item In Episodios

                                         If item.Value("AnimeID").ToString = oAnime.Id Then
                                             arra.Add(item.Value("Numero").ToString)
                                         End If
                                     Next
                                     Dim arr(arra.Count - 1) As Integer
                                     Dim i As Integer = 0
                                     For Each item In Episodios
                                         If item.Value("AnimeID").ToString = oAnime.Id Then
                                             arr(i) = item.Value("Numero").ToString
                                             i = i + 1
                                         End If
                                     Next
                                     Array.Sort(arr)
                                     For Each it In arr
                                         For Each item In Episodios
                                             If item.Value("AnimeID").ToString = oAnime.Id Then
                                                 If item.Value("Numero").ToString = it.ToString Then
                                                     Dim ep As New episodioa
                                                     ep.Ending = item.Value("Ending").ToString
                                                     ep.Nome = item.Value("Nome").ToString
                                                     ep.Numero = item.Value("Numero").ToString
                                                     ep.Opening = item.Value("Opening").ToString
                                                     ep.Thumb_Url = item.Value("Thumb_Url").ToString
                                                     ep.Video_Url = item.Value("Video_Url").ToString
                                                     ListEps.Add(ep)

                                                 End If
                                             End If
                                         Next
                                     Next
                                     Thr = New Thread(AddressOf js)
                                     Thr.Start()
                                 End Sub
        If HAnimeSearch = 3 Then
            VAnimeSearch = VAnimeSearch + 1
            HAnimeSearch = -1
        End If
        painelPesquisa.Controls.Add(anime)
    End Sub

    Sub criaranimeGenero(ByVal oAnime As Animesa)
        HAnimeGenero = HAnimeGenero + 1
        CAnimeGenero = CAnimeGenero + 1
        Dim anime As New Animes
        With anime
            .Size = New Size(151, 262)
            .Location = New Point(HAnimeGenero * (anime.Size.Width + 10), VAnimeGenero * (anime.Size.Height + 10) + 43)
            .imagemlocal = oAnime.Thumb_Url
            .nomeanime = oAnime.Nome
            .idanime = oAnime.Id
            .Name = "Anime" & CAnime
            .Tag = oAnime
        End With
        AddHandler anime.clique, Sub()

                                     oanimea = oAnime
                                     EstruturaPaginaInicial.Visible = False
                                     painelAnime.Visible = True
                                     painelAnime.Dock = DockStyle.Fill
                                     listviewEpisodios.Items.Clear()
                                     imgs.Images.Clear()
                                     Me.Text = oAnime.Nome
                                     Label1.Text = oAnime.Ano_Lancamento
                                     Label2.Text = "       " & oAnime.NotaMAL
                                     Label3.Text = "Studios: " & oAnime.Studios
                                     Label4.Text = "Generos: " & oAnime.Generos.Replace(",", ", ").Replace("_", " ")
                                     labelSinopseAnime.Text = oAnime.Sinopse
                                     labelTituloAnime.Text = oAnime.Nome
                                     thumbAnime.ImageLocation = oAnime.Thumb_Url


                                     Dim arra As New ArrayList
                                     For Each item In Episodios

                                         If item.Value("AnimeID").ToString = oAnime.Id Then
                                             arra.Add(item.Value("Numero").ToString)
                                         End If
                                     Next
                                     Dim arr(arra.Count - 1) As Integer
                                     Dim i As Integer = 0
                                     For Each item In Episodios
                                         If item.Value("AnimeID").ToString = oAnime.Id Then
                                             arr(i) = item.Value("Numero").ToString
                                             i = i + 1
                                         End If
                                     Next
                                     Array.Sort(arr)
                                     ListEps.Clear()
                                     For Each it In arr
                                         For Each item In Episodios
                                             If item.Value("AnimeID").ToString = oAnime.Id Then
                                                 If item.Value("Numero").ToString = it.ToString Then
                                                     Dim ep As New episodioa
                                                     ep.Ending = item.Value("Ending").ToString
                                                     ep.Nome = item.Value("Nome").ToString
                                                     ep.Numero = item.Value("Numero").ToString
                                                     ep.Opening = item.Value("Opening").ToString
                                                     ep.Thumb_Url = item.Value("Thumb_Url").ToString
                                                     ep.Video_Url = item.Value("Video_Url").ToString
                                                     ListEps.Add(ep)

                                                 End If
                                             End If
                                         Next
                                     Next
                                     Thr = New Thread(AddressOf js)
                                     Thr.Start()
                                 End Sub
        If HAnimeGenero = 3 Then
            VAnimeGenero = VAnimeGenero + 1
            HAnimeGenero = -1
        End If
        painelAnimeGenero.Controls.Add(anime)
    End Sub

    Sub criargenero(ByVal gen As Generoa)
        HGenero = HGenero + 1
        CGenero = CGenero + 1
        Dim genero As New generos
        With genero
            .Size = New Size(205, 156)
            .Location = New Point(HGenero * (genero.Size.Width + 10), VGenero * (genero.Size.Height + 10))
            .imagemlocal = gen.Thumb_Url
            .nomegenero = gen.Nome_PtBr
            .Idgenero = gen.Name
            .Name = "Genero" & CGenero
        End With
        AddHandler genero.clique, Sub()

                                      Try
                                          CAnimeGenero = 0
                                          VAnimeGenero = 0
                                          HAnimeGenero = -1
                                          painelAnimeGenero.Controls.Clear()
                                          Dim ListGeneros As List(Of Animesa) = ListAnimes.FindAll(Function(a As Animesa) a.Generos.Contains(gen.Name))
                                          If ListGeneros IsNot Nothing AndAlso ListGeneros.Count = 0 Then
                                              acoesbtn(Me, EventArgs.Empty)
                                          Else
                                              lblTituloGenero.Text = gen.Nome_PtBr
                                              painelAnimeGenero.Controls.Add(lblTituloGenero)
                                              painelAnimeGenero.Controls.Add(picboxVoltarGenero)
                                              For Each anim In ListGeneros
                                                  criaranimeGenero(anim)
                                              Next
                                              acoesbtn(genero, EventArgs.Empty)
                                          End If

                                      Catch ex As Exception
                                          acoesbtn(Me, EventArgs.Empty)
                                      End Try
                                  End Sub
        If HGenero = 2 Then
            VGenero = VGenero + 1
            HGenero = -1
        End If
        painelGeneros.Controls.Add(genero)
    End Sub
    Dim imss As Image = My.Resources.ImageFailLoad205x116
    Sub criarepisodioanime(ByVal Ep As episodioa, ByVal Imagem As Image)

        imgs.ImageSize = New Size(105, 60)
        Dim img As Image
        Dim wc As New WebClient()
        Dim item As New ListViewItem
        item.Name = Ep.Numero
        Dim rgx As String = "https://.*\.blogger\.com/video\.g\?token=.*"
        Dim mm As Match = Regex.Match(Ep.Video_Url, rgx, RegexOptions.IgnoreCase)
        Try
            If mm.Success And Ep.Thumb_Url = "0" Then
                Dim bytes As Byte() = wc.DownloadData(PickThumbEVideo(Ep.Video_Url, True))
                Dim ms As New MemoryStream(bytes)
                img = Image.FromStream(ms)
                Exit Try
            ElseIf Not Ep.Thumb_Url = "" Then
                Dim bytes As Byte() = wc.DownloadData(Ep.Thumb_Url)
                Dim ms As New MemoryStream(bytes)
                img = Image.FromStream(ms)
            ElseIf Ep.Thumb_Url = "" And Imagem IsNot Nothing Then
                img = Imagem
            Else
                img = My.Resources.ImageFailLoad205x116
            End If
        Catch ex As Exception
            img = My.Resources.ImageFailLoad205x116
        End Try
        item.Text = "  Episodio " & Ep.Numero & " - " & Ep.Nome
        imgs.Images.Add(Ep.AnimeID & "_" & Ep.Numero, img)
        item.ImageIndex = imgs.Images.IndexOfKey(Ep.AnimeID & "_" & Ep.Numero)
        listviewEpisodios.Items.Add(item)
        listviewEpisodios.SmallImageList = imgs
    End Sub

    Private Sub listviewEpisodios_MouseClick(sender As Object, e As MouseEventArgs) Handles listviewEpisodios.MouseClick
        Dim numep = listviewEpisodios.SelectedItems(0).Name
        oepisodioa = ListEps.Find(Function(a As episodioa) a.Numero = numep)
        lblNomeEpisodio.Text = "Nome: " & oepisodioa.Nome
        lblOpeningEpisodio.Text = "Opening: " & oepisodioa.Opening
        lblEndingEpisodio.Text = "Ending: " & oepisodioa.Ending
        picboxInfoEpisodio.Tag = numep
        picboxProximoEP.Visible = True
        picboxEpAnterior.Visible = True

        If ListEps.IndexOf(oepisodioa) = 0 Then
            picboxEpAnterior.Visible = False
        ElseIf ListEps.IndexOf(oepisodioa) = ListEps.Count - 1 Then
            picboxProximoEP.Visible = False
        End If
        Me.Text = oanimea.Nome & " - Episodio " & numep
        lblTituloEpisodio.Text = oanimea.Nome & " - Episodio " & numep

        LinhaAssistido = New Pen(Color.Red, 5)
        LinhaSom = New Pen(Color.White, 5)
        LinhaFalta = New Pen(Color.DarkGray, 5)
        Tamanho = picboxBarraVolume.Width / 2
        Desenhar()
        DesenharVolume()
        TimerMostrarVolume.Enabled = True
        TimerVideo.Enabled = True

        painelAnime.Visible = False
        painelAssistirEpisodio.Visible = True
        painelAssistirEpisodio.Dock = DockStyle.Fill
        Dim Video As String = oepisodioa.Video_Url
        Dim rgx As String = "https://.*\.blogger\.com/video\.g\?token=.*"
        Dim mm As Match = Regex.Match(Video, rgx, RegexOptions.IgnoreCase)
        If mm.Success Then
            PlayerEpisodio.URL = PickThumbEVideo(Video)
        Else
            PlayerEpisodio.URL = Video
        End If
        PaginaInicial_Resize(Nothing, EventArgs.Empty)

    End Sub

    Function PickThumbEVideo(ByVal link As String, Optional TrueISThumbFalseISVideo As Boolean = False)
        Try
            Dim ss As String = wb.DownloadString(link)
            Dim rgx As String = "{.*}]}"
            Dim mm As Match = Regex.Match(ss, rgx, RegexOptions.IgnoreCase)
            Dim job As JObject
            If mm.Success Then
                job = JObject.Parse(mm.Value)
                If TrueISThumbFalseISVideo Then
                    Return job.SelectToken("thumbnail").ToString
                ElseIf Not TrueISThumbFalseISVideo Then
                    Return job.SelectTokens("streams").First.First.SelectToken("play_url")
                End If
            Else
                Return "Nothing"
            End If
        Catch ex As Exception
            Return "Nothing"
        End Try

    End Function

    Private Sub btnVoltarDeAnime_Click(sender As Object, e As EventArgs) Handles btnVoltarDeAnime.Click
        Me.Text = "Pagina Inicial"
        painelAnime.Visible = False
        EstruturaPaginaInicial.Visible = True
        Thr.Abort()
    End Sub

    Private Sub btnVoltarDeEpisodio_Click(sender As Object, e As EventArgs) Handles btnVoltarDeEpisodio.Click
        painelAnime.Visible = True
        painelAnime.Dock = DockStyle.Fill
        painelAssistirEpisodio.Visible = False
        Me.Text = oanimea.Nome
        PlayerEpisodio.URL = ""
        PlayerEpisodio.Refresh()
        PlayerEpisodio.Ctlcontrols.stop()
        TimerMostrarVolume.Enabled = False
        TimerVideo.Enabled = False
        PaginaInicial_Resize(Nothing, EventArgs.Empty)
        Me.MaximumSize = New Size(691, 9999)
        Me.WindowState = FormWindowState.Normal
        If EPdHome Then
            EstruturaPaginaInicial.Visible = False
            painelAnime.Visible = True
            painelAnime.Dock = DockStyle.Fill
            listviewEpisodios.Items.Clear()
            imgs.Images.Clear()
            Me.Text = oanimea.Nome
            Label1.Text = oanimea.Ano_Lancamento
            Label2.Text = "       " & oanimea.NotaMAL
            Label3.Text = "Studios: " & oanimea.Studios
            Label4.Text = "Generos: " & oanimea.Generos.Replace(",", ", ").Replace("_", " ")
            labelSinopseAnime.Text = oanimea.Sinopse
            labelTituloAnime.Text = oanimea.Nome
            thumbAnime.ImageLocation = oanimea.Thumb_Url
            Dim ListaEpisodios As List(Of episodioa) = New List(Of episodioa)
            For Each item In Episodios
                If item.Value("AnimeID").ToString = oanimea.Id Then
                    Dim ep As New episodioa
                    ep.Ending = item.Value("Ending").ToString
                    ep.Nome = item.Value("Nome").ToString
                    ep.Numero = item.Value("Numero").ToString
                    ep.Opening = item.Value("Opening").ToString
                    ep.Thumb_Url = item.Value("Thumb_Url").ToString
                    ep.Video_Url = item.Value("Video_Url").ToString
                    ListaEpisodios.Add(ep)
                    ListaEpisodios.Sort(Function(x, y) x.Numero.CompareTo(y.Numero))
                    ListEps.Clear()
                    For Each ep In ListaEpisodios
                        ListEps.Add(ep)
                    Next

                    EPdHome = False

                End If
            Next
            Thr = New Thread(AddressOf js)
            Thr.Start()
        End If


    End Sub

    Private Sub btnInfoEpisodio_Click(sender As Object, e As EventArgs) Handles picboxInfoEpisodio.Click
        If panelInfoAnime.Visible Then
            panelInfoAnime.Visible = False
        ElseIf Not panelInfoAnime.Visible Then
            panelInfoAnime.Visible = True
        End If
    End Sub

    Public Sub Desenhar()
        picboxBarraVideo.Refresh()
        Dim BM As Bitmap = New Bitmap(picboxBarraVideo.Width, picboxBarraVideo.Height)
        Dim Desenho As Graphics = Graphics.FromImage(BM)
        Desenho.DrawLine(LinhaAssistido, 0, CInt(picboxBarraVideo.Height / 2), Total, CInt(picboxBarraVideo.Height / 2))
        Desenho.DrawLine(LinhaFalta, Total, CInt(picboxBarraVideo.Height / 2), picboxBarraVideo.Width, CInt(picboxBarraVideo.Height / 2))
        picboxBarraVideo.Image = BM
    End Sub

    Public Sub DesenharVolume()
        picboxBarraVolume.Refresh()
        Dim BM As Bitmap = New Bitmap(picboxBarraVolume.Width, picboxBarraVolume.Height)
        Dim Desenho As Graphics = Graphics.FromImage(BM)
        Desenho.DrawLine(LinhaSom, 0, CInt(picboxBarraVolume.Height / 2), Tamanho, CInt(picboxBarraVolume.Height / 2))
        Desenho.DrawLine(LinhaFalta, Tamanho, CInt(picboxBarraVolume.Height / 2), picboxBarraVolume.Width, CInt(picboxBarraVolume.Height / 2))
        picboxBarraVolume.Image = BM
    End Sub

    Private Sub PictureBoxIconVolume_MouseEnter(sender As Object, e As EventArgs) Handles picboxVolume.MouseEnter
        MostrarVolume = True
    End Sub

    Private Sub PictureBoxIconVolume_MouseLeave(sender As Object, e As EventArgs) Handles picboxVolume.MouseLeave
        MostrarVolume = False
    End Sub

    Private Sub PictureBoxBarraVolume_MouseEnter(sender As Object, e As EventArgs) Handles picboxBarraVolume.MouseEnter
        MostrarVolume = True
    End Sub

    Private Sub PictureBoxBarraVolume_MouseLeave(sender As Object, e As EventArgs) Handles picboxBarraVolume.MouseLeave
        MostrarVolume = False
    End Sub

    Private Sub TimerMostrarVolume_Tick(sender As Object, e As EventArgs) Handles TimerMostrarVolume.Tick
        If MostrarVolume = False Then
            picboxBarraVolume.Location = New Point(-100, -28)
            lblTempoRestante.Location = New Point(picboxVolume.Location.X + picboxVolume.Width + 5, picboxVolume.Location.Y + 6)
        ElseIf MostrarVolume = True Then
            picboxBarraVolume.Location = New Point(picboxVolume.Location.X + picboxVolume.Width, picboxVolume.Location.Y + 10)
            lblTempoRestante.Location = New Point(picboxBarraVolume.Location.X + picboxBarraVolume.Width + 15, picboxVolume.Location.Y + 6)
        End If
    End Sub
    Dim Mudo As Boolean
    Private Sub PictureBoxIconVolume_Click(sender As Object, e As EventArgs) Handles picboxVolume.Click

        If Mudo = False Then
            picboxVolume.Image = My.Resources.Volume_Mudo
            Mudo = True
            Tamanho = 0
            Volume = 0
            PlayerEpisodio.settings.volume = Volume
            DesenharVolume()
        ElseIf Mudo = True Then
            picboxVolume.Image = My.Resources.Volume_Medio
            Mudo = False
            Tamanho = picboxBarraVolume.Width / 2
            Volume = 50
            PlayerEpisodio.settings.volume = Volume
            DesenharVolume()
        End If
    End Sub

    Private Sub PictureBoxBarraVolume_MouseMove(sender As Object, e As MouseEventArgs) Handles picboxBarraVolume.MouseMove
        Tamanho = e.X
        If SelecaoVolume = True Then
            If Tamanho < 0 Or Tamanho = 0 Then
                Tamanho = 0
                picboxVolume.Image = My.Resources.Volume_Mudo
                Mudo = True
            ElseIf Tamanho < picboxBarraVolume.Width / 2 / 2 And Tamanho > 0 Then
                picboxVolume.Image = My.Resources.Volume
                Mudo = False
            ElseIf Tamanho < picboxBarraVolume.Width / 2 And Tamanho > picboxBarraVolume.Width / 2 / 2 Then
                picboxVolume.Image = My.Resources.Volume_Baixo
                Mudo = False
            ElseIf Tamanho < picboxBarraVolume.Width / 2 + picboxBarraVolume.Width / 2 / 2 And Tamanho > picboxBarraVolume.Width / 2 Then
                picboxVolume.Image = My.Resources.Volume_Medio
                Mudo = False
            End If
            Volume = Tamanho * 100 / picboxBarraVolume.Width
            PlayerEpisodio.settings.volume = Volume
            DesenharVolume()
        End If
    End Sub

    Private Sub PictureBoxBarraVolume_MouseUp(sender As Object, e As MouseEventArgs) Handles picboxBarraVolume.MouseUp
        Volume = Tamanho * 100 / picboxBarraVolume.Width
        PlayerEpisodio.settings.volume = Volume
        SelecaoVolume = False
        DesenharVolume()
    End Sub

    Private Sub PictureBoxBarraVolume_MouseDown(sender As Object, e As MouseEventArgs) Handles picboxBarraVolume.MouseDown
        SelecaoVolume = True
    End Sub

    Private Sub PlayerEpisodio_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles PlayerEpisodio.PlayStateChange
        Try
            TimerVideo.Start()
            If PlayerEpisodio.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                picboxPlayPause.Image = My.Resources.Resources.pause
            Else
                picboxPlayPause.Image = My.Resources.Resources.Icon_Play
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picboxBarraVideo.MouseDown
        Selecao = True
        TimerVideo.Enabled = False
    End Sub

    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles picboxBarraVideo.MouseMove
        Total = e.X
        If Selecao = True Then
            picboxBarraVideo.Refresh()
            If Total < ANCHOCURSOR Then
                Total = ANCHOCURSOR
            End If
            If Total > picboxBarraVideo.Width - ANCHOCURSOR Then
                Total = picboxBarraVideo.Width
            End If
            Desenhar()
        End If
    End Sub

    Private Sub picboxBarraVideo_MouseUp(sender As Object, e As MouseEventArgs) Handles picboxBarraVideo.MouseUp
        VALOR = PlayerEpisodio.currentMedia.duration / picboxBarraVideo.Width * Total
        PlayerEpisodio.Ctlcontrols.currentPosition = VALOR
        Selecao = False
        TimerVideo.Enabled = True
    End Sub

    Private Sub TimerVideo_Tick(sender As Object, e As EventArgs) Handles TimerVideo.Tick
        If PlayerEpisodio.URL = "" Then
            TimerVideo.Stop()
            Total = 0
            lblTempoRestante.Text = "00:00/00:00"
            Desenhar()
            lblErro.Visible = True
            If MsgBox("Não há Video disponivel para este Episodio. Gostaria de reportar este erro?", MsgBoxStyle.YesNo, "Erro") = MsgBoxResult.Yes Then
                PlayerEpisodio.Ctlcontrols.pause()
                formRelatarErro.Anime = oanimea.Nome
                formRelatarErro.Erro = "Não há video disponivel para o Episodio"
                formRelatarErro.Ep = oepisodioa.Numero
                formRelatarErro.Show()
            End If

        Else
            lblErro.Visible = False
            Try
                VALOR = picboxBarraVideo.Width / PlayerEpisodio.currentMedia.duration * PlayerEpisodio.Ctlcontrols.currentPosition
                Total = VALOR
                Desenhar()
                lblTempoRestante.Text = Format(TimeSerial(0, 0, PlayerEpisodio.Ctlcontrols.currentPosition), "mm:ss") & "/" & Format(TimeSerial(0, 0, PlayerEpisodio.currentMedia.duration), "mm:ss")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub picboxPlayPause_Click(sender As Object, e As EventArgs) Handles picboxPlayPause.Click
        If PlayerEpisodio.URL = "" Then
            TimerVideo_Tick(Nothing, EventArgs.Empty)
        Else
            If PlayerEpisodio.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                PlayerEpisodio.Ctlcontrols.pause()
            Else
                PlayerEpisodio.Ctlcontrols.play()
            End If
        End If


    End Sub

    Private Sub BotoesPagina_clique(sender As Object, e As Object) Handles BotaoSOBRE.clique, BotaoHOME.clique, BotaoGENEROS.clique, BotaoANIMES.clique

    End Sub

    Private Sub picboxEpAnterior_Click(sender As Object, e As EventArgs) Handles picboxEpAnterior.Click

        oepisodioa = ListEps.Find(Function(a As episodioa) a.Numero = oepisodioa.Numero - 1)
        Dim numep = oepisodioa.Numero
        lblNomeEpisodio.Text = "Nome: " & oepisodioa.Nome
        lblOpeningEpisodio.Text = "Opening: " & oepisodioa.Opening
        lblEndingEpisodio.Text = "Ending: " & oepisodioa.Ending
        picboxInfoEpisodio.Tag = numep
        picboxProximoEP.Visible = True
        picboxEpAnterior.Visible = True
        If ListEps.IndexOf(oepisodioa) = 0 Then
            picboxEpAnterior.Visible = False
        ElseIf ListEps.IndexOf(oepisodioa) = ListEps.Count - 1 Then
            picboxProximoEP.Visible = False
        End If
        Me.Text = oanimea.Nome & " - Episodio " & numep
        lblTituloEpisodio.Text = oanimea.Nome & " - Episodio " & numep
        Dim Video As String = oepisodioa.Video_Url
        Dim rgx As String = "https://.*\.blogger\.com/video\.g\?token=.*"
        Dim mm As Match = Regex.Match(Video, rgx, RegexOptions.IgnoreCase)
        If mm.Success Then
            PlayerEpisodio.URL = PickThumbEVideo(Video)
        Else
            PlayerEpisodio.URL = Video
        End If
        TimerVideo.Start()
    End Sub

    Private Sub picboxProximoEP_Click(sender As Object, e As EventArgs) Handles picboxProximoEP.Click

        oepisodioa = ListEps.Find(Function(a As episodioa) a.Numero = oepisodioa.Numero + 1)
        Dim numep = oepisodioa.Numero
        lblNomeEpisodio.Text = "Nome: " & oepisodioa.Nome
        lblOpeningEpisodio.Text = "Opening: " & oepisodioa.Opening
        lblEndingEpisodio.Text = "Ending: " & oepisodioa.Ending
        picboxInfoEpisodio.Tag = numep
        picboxProximoEP.Visible = True
        picboxEpAnterior.Visible = True
        If ListEps.IndexOf(oepisodioa) = 0 Then
            picboxEpAnterior.Visible = False
        ElseIf ListEps.IndexOf(oepisodioa) = ListEps.Count - 1 Then
            picboxProximoEP.Visible = False
        End If
        Me.Text = oanimea.Nome & " - Episodio " & numep
        lblTituloEpisodio.Text = oanimea.Nome & " - Episodio " & numep
        Dim Video As String = oepisodioa.Video_Url
        Dim rgx As String = "https://.*\.blogger\.com/video\.g\?token=.*"
        Dim mm As Match = Regex.Match(Video, rgx, RegexOptions.IgnoreCase)
        If mm.Success Then
            PlayerEpisodio.URL = PickThumbEVideo(Video)
        Else
            PlayerEpisodio.URL = Video
        End If
        TimerVideo.Start()
    End Sub

    Private Sub PlayerEpisodio_MediaError(sender As Object, e As _WMPOCXEvents_MediaErrorEvent) Handles PlayerEpisodio.MediaError
        MsgBox("Erro ao reproduzir o video", MsgBoxStyle.Critical, "Erro")
    End Sub

    Private Sub picboxRandomAnime_Click(sender As Object, e As EventArgs) Handles picboxRandomAnime.Click

        Dim Random As New Random
        Dim max = painelAnimesHOME.Controls.OfType(Of Animes).Count
        Dim Num = Random.Next(0, max - 1)
        Dim ANIME As Animesa = painelAnimesHOME.Controls.Item(Num).Tag
        oanimea = ANIME
        EstruturaPaginaInicial.Visible = False
        painelAnime.Visible = True
        painelAnime.Dock = DockStyle.Fill
        listviewEpisodios.Items.Clear()
        imgs.Images.Clear()
        Me.Text = ANIME.Nome
        Label1.Text = ANIME.Ano_Lancamento
        Label2.Text = "       " & ANIME.NotaMAL
        Label3.Text = "Studios: " & ANIME.Studios
        Label4.Text = "Generos: " & ANIME.Generos.Replace(",", ", ").Replace("_", " ")
        labelSinopseAnime.Text = ANIME.Sinopse
        labelTituloAnime.Text = ANIME.Nome
        thumbAnime.ImageLocation = ANIME.Thumb_Url


        Dim arra As New ArrayList
        For Each item In Episodios

            If item.Value("AnimeID").ToString = ANIME.Id Then
                arra.Add(item.Value("Numero").ToString)
            End If
        Next
        Dim arr(arra.Count - 1) As Integer
        Dim i As Integer = 0
        For Each item In Episodios
            If item.Value("AnimeID").ToString = ANIME.Id Then
                arr(i) = item.Value("Numero").ToString
                i = i + 1
            End If
        Next
        Array.Sort(arr)
        ListEps.Clear()
        For Each it In arr
            For Each item In Episodios
                If item.Value("AnimeID").ToString = ANIME.Id Then
                    If item.Value("Numero").ToString = it.ToString Then
                        Dim ep As New episodioa
                        ep.Ending = item.Value("Ending").ToString
                        ep.Nome = item.Value("Nome").ToString
                        ep.Numero = item.Value("Numero").ToString
                        ep.Opening = item.Value("Opening").ToString
                        ep.Thumb_Url = item.Value("Thumb_Url").ToString
                        ep.Video_Url = item.Value("Video_Url").ToString
                        ListEps.Add(ep)
                    End If
                End If
            Next
        Next
        Thr = New Thread(AddressOf js)
        Thr.Start()
    End Sub

    Private Sub Pesquisa1_TeclaBaixo(sender As Object, e As Object) Handles Pesquisa1.TeclaBaixo
        If e.KeyCode = Keys.Enter Then

            If Not Pesquisa1.texto = "" Then
                Try
                    CAnimeSearch = 0
                    VAnimeSearch = 0
                    HAnimeSearch = -1
                    painelPesquisa.Controls.Clear()
                    Dim ListPesquisando As List(Of Animesa) = ListAnimes.FindAll(Function(a As Animesa) a.Nome.ToLower.Contains(Pesquisa1.texto.ToLower))
                    If ListPesquisando IsNot Nothing AndAlso ListPesquisando.Count = 0 Then
                        acoesbtn(Me, e)
                    Else
                        For Each anim In ListPesquisando
                            criaranimeSearch(anim)
                        Next
                        acoesbtn(sender, e)
                    End If
                Catch ex As Exception
                    acoesbtn(Me, e)
                End Try

            End If
        End If
    End Sub

    Private Sub picboxVoltarGenero_Click(sender As Object, e As EventArgs) Handles picboxVoltarGenero.Click
        painelAnimeGenero.Visible = False
        acoesbtn(BotaoGENEROS, EventArgs.Empty)
    End Sub

    Private Sub PaginaInicial_Resize(sender As Object, e As EventArgs) Handles Me.Resize


        If Me.WindowState = FormWindowState.Maximized Then
            Me.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right
            Me.FormBorderStyle = FormBorderStyle.None
            Me.ControlBox = False

        ElseIf Me.WindowState = FormWindowState.Normal Then
            If Not painelAssistirEpisodio.Visible Then
                Me.MaximumSize = New Size(691, 9999)
            Else
                Me.MaximumSize = New Size(9999, 9999)
            End If
            Me.FormBorderStyle = FormBorderStyle.Sizable
            Me.ControlBox = True
        End If
    End Sub

    Private Sub TimerFullScreen_Tick(sender As Object, e As EventArgs) Handles TimerFullScreen.Tick
        If Not Debugs Then
            Debugs = True
            PlayerEpisodio.BringToFront()
            PlayerEpisodio.Dock = DockStyle.Fill
            TimerFullScreen.Interval = 1000
        ElseIf Debugs Then
            TimerFullScreen.Interval = 4000
            Debugs = False
            TimerFullScreen.Stop()
        End If



    End Sub
    Dim Debugs As Boolean = False
    Private Sub playerEpisodio_MouseMoveEvent(sender As Object, e As _WMPOCXEvents_MouseMoveEvent) Handles PlayerEpisodio.MouseMoveEvent
        If Debugs Then
        Else
            TimerFullScreen.Stop()
            PlayerEpisodio.SendToBack()
            PlayerEpisodio.Dock = DockStyle.None
            PlayerEpisodio.Location = New Point(0, 36)
            PlayerEpisodio.Size = New Size(painelAssistirEpisodio.Width, painelAssistirEpisodio.Height - 81)
            TimerFullScreen.Start()
        End If
    End Sub

    Private Sub picboxFullScreen_Click(sender As Object, e As EventArgs) Handles picboxFullScreen.Click
        If Me.WindowState = FormWindowState.Normal Then

            Me.WindowState = FormWindowState.Maximized
            picboxFullScreen.Image = My.Resources.IconBackFullScreen
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.Anchor = AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top
            Me.WindowState = FormWindowState.Normal
            picboxFullScreen.Image = My.Resources.IconFullScreen
        End If


    End Sub

    Private Sub btnVoltarDeEpisodio_MouseMove(sender As Object, e As MouseEventArgs) Handles btnVoltarDeEpisodio.MouseMove, lblTituloEpisodio.MouseMove, painelAssistirEpisodio.MouseMove, picboxBarraVideo.MouseMove, picboxPlayPause.MouseMove, picboxVolume.MouseMove, picboxBarraVolume.MouseMove, lblTempoRestante.MouseMove, picboxInfoEpisodio.MouseMove, picboxEpAnterior.MouseMove, picboxProximoEP.MouseMove, picboxFullScreen.MouseMove
        If Debugs Then
        Else
            TimerFullScreen.Stop()
            PlayerEpisodio.SendToBack()
            PlayerEpisodio.Dock = DockStyle.None
            PlayerEpisodio.Location = New Point(0, 36)
            PlayerEpisodio.Size = New Size(painelAssistirEpisodio.Width, painelAssistirEpisodio.Height - 81)
            TimerFullScreen.Start()
        End If
    End Sub

    Private Sub BtnYoutube_Click(sender As Object, e As EventArgs) Handles BtnYoutube.Click
        Process.Start(CanalYoutube)
    End Sub

    Private Sub BtnInstagram_Click(sender As Object, e As EventArgs) Handles BtnInstagram.Click
        Process.Start(PerfilInstagram)
    End Sub

    Private Sub lblBaixarNovaVersao_Click(sender As Object, e As EventArgs) Handles lblBaixarNovaVersao.Click
        If Not Atualizado Then
            Process.Start(DownloadNovaVersao)
        End If
    End Sub

    Private Sub picboxRelatarErroEpisodio_Click(sender As Object, e As EventArgs) Handles picboxRelatarErroEpisodio.Click
        PlayerEpisodio.Ctlcontrols.pause()
        formRelatarErro.Anime = oanimea.Nome
        formRelatarErro.Ep = oepisodioa.Numero
        formRelatarErro.Show()
    End Sub


    Private Sub PlayerEpisodio_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles PlayerEpisodio.ClickEvent
        If PlayerEpisodio.URL = "" Then

        Else
            If PlayerEpisodio.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                PlayerEpisodio.Ctlcontrols.pause()
            Else
                PlayerEpisodio.Ctlcontrols.play()
            End If
        End If
    End Sub

    Private Sub js()
        Dim Imgss As Image
        If Not oanimea.Thumb_Ep = "" Then
            Dim wc As New WebClient()
            Dim bytes As Byte() = wc.DownloadData(oanimea.Thumb_Ep)
            Dim ms As New MemoryStream(bytes)
            Imgss = Image.FromStream(ms)
        End If

        For Each ep In ListEps
            criarepisodioanime(ep, Imgss)
        Next
    End Sub
End Class
