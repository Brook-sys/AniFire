Imports JikanDotNet
Imports System.Net
Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private fcon As New FirebaseConfig() With
        {
        .AuthSecret = "",
        .BasePath = ""
        }

    Private client As IFirebaseClient
    Dim Jikans As IJikan = New Jikan()
    Dim NumeroAnime = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Try
            client = New FireSharp.FirebaseClient(fcon)
            Atualizar(sender)
        Catch
            MsgBox("Possiveis Causas: " & vbNewLine & vbNewLine & "Sem Internet;" & vbNewLine & vbNewLine & "A conta FireBase que o programa está Utilizando não está disponivel, por algum dos motivos seguintes:" & vbNewLine & "- Má configuração de Conexão;" & vbNewLine & "- Chave e/ou Endereço errados", MsgBoxStyle.Critical, "ERROR!!")
            Me.Close()
        End Try
    End Sub

    Async Sub PegarAnime(ByVal id As Long)
        Dim Oanime As Anime
        Try
            Oanime = Await Jikans.GetAnime(id)
        Catch ex As Exception
            Exit Sub
        End Try

        txtboxNome.Text = Oanime.Title
        txtboxIDAnime.Text = Oanime.MalId
        txtboxGeneros.Clear()
        For Each genero In Oanime.Genres
            txtboxGeneros.AppendText(genero.Name.Replace(" ", "_"))
            If genero IsNot Oanime.Genres.Last Then
                txtboxGeneros.AppendText(",")
            End If
        Next
        txtboxNotaMAL.Text = Oanime.Score
        picboxThumb.ImageLocation = Oanime.ImageURL
        txtboxThumb.Text = Oanime.ImageURL
        txtboxAnoLancamento.Text = Oanime.Aired.From.Value.Year
        txtboxStudios.Clear()
        For Each studio In Oanime.Studios
            txtboxStudios.AppendText(studio.Name)
            If studio IsNot Oanime.Studios.Last Then
                txtboxStudios.AppendText(",")
            End If
        Next
        txtboxSinopse.Text = Oanime.Synopsis
        Atualizar(btnScrap)
    End Sub

    Private Sub btnScrap_Click(sender As Object, e As EventArgs) Handles btnScrap.Click
        If Not txtboxidMAL.Text = "" Then
            Do
                Try
                    PegarAnime(txtboxidMAL.Text)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If
    End Sub

    Private Sub txtboxidMAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtboxidMAL.KeyPress, txtboxVersionBuild.KeyPress, txtboxVersionMajor.KeyPress, txtboxVersionMinor.KeyPress, txtboxVersionRevision.KeyPress
        If Char.IsDigit(e.KeyChar) Then
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtboxidMAL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxidMAL.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not txtboxidMAL.Text = "" Then
                Do
                    Try
                        PegarAnime(txtboxidMAL.Text)
                        Exit Do
                    Catch ex As Exception
                        If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Do
                        End If
                    End Try
                Loop
            End If
        End If
    End Sub

    Function PegarOPeED(ByVal OPseEDs As ICollection(Of String), ByVal episodio As Long)

        For Each op In OPseEDs
            If op.Contains("(eps ") Then

                Dim EpisodiosOpening As String = op.Split("(eps").Last.Split(")")(0).Replace("eps", "")
                Dim Openingnome = op.Split("(eps")(0)
                If op.Split("(eps").Count = 3 Then
                    Openingnome = op.Split("(eps")(0) & op.Split("(eps")(1)
                End If
                If EpisodiosOpening.Contains("-") Then
                    If EpisodiosOpening.Contains(",") Then

                        For Each esp In EpisodiosOpening.Split(", ")
                            Dim n1ev As Short = esp.Split("-")(0)

                            If Not String.IsNullOrEmpty(esp.Split("-")(1)) Then
                                Dim n2ev As Short = esp.Split("-")(1)
                                For num1 = n1ev To n2ev
                                    If num1 = episodio Then
                                        Return Openingnome
                                    End If
                                Next
                            Else
                                Return Openingnome
                            End If
                        Next
                    Else
                        Dim n1e As Short = EpisodiosOpening.Split("-")(0)
                        If Not String.IsNullOrEmpty(EpisodiosOpening.Split("-")(1)) Then
                            Dim n2e As Short = EpisodiosOpening.Split("-")(1)
                            For num1 = n1e To n2e
                                If num1 = episodio Then
                                    Return Openingnome
                                End If
                            Next
                        Else
                            Return Openingnome
                        End If
                    End If


                ElseIf EpisodiosOpening.Contains(",") Then
                    For Each esp In EpisodiosOpening.Split(",")
                        If esp = episodio Then
                            Return Openingnome
                        End If
                    Next
                End If
            ElseIf op.Contains("(ep ") Then
                Dim EpisodiosOpening As String = op.Split("(ep").Last.Split(")")(0).Replace("ep", "")
                Dim Openingnome = op.Split("(ep")(0)
                If op.Split("(ep").Count = 3 Then
                    Openingnome = op.Split("(ep")(0) & op.Split("(ep")(1)
                End If
                If EpisodiosOpening = episodio Then
                    Return Openingnome
                End If
            Else
                Return op
            End If

        Next
        Return "Nothing"
    End Function

    Async Sub btnAddAnime_Click(sender As Object, e As EventArgs) Handles btnAddAnime.Click
        Do
            Try
                Dim ANIME As New Animesa
                ANIME.Nome = txtboxNome.Text
                ANIME.Id = txtboxIDAnime.Text
                ANIME.Generos = txtboxGeneros.Text
                ANIME.NotaMAL = txtboxNotaMAL.Text
                ANIME.Thumb_Url = txtboxThumb.Text
                ANIME.Ano_Lancamento = txtboxAnoLancamento.Text
                ANIME.Studios = txtboxStudios.Text
                ANIME.Sinopse = txtboxSinopse.Text
                ANIME.Thumb_Ep = txtboxepthumb.Text
                Dim upanime = client.Set("Animes/" & ANIME.Id.ToString, ANIME)

                Dim generos = ANIME.Generos.Split(",")
                Dim cgeneros = client.Get("Generos")
                Dim cgen As JObject = cgeneros.ResultAs(Of JObject)
                For Each genero In generos
                    Dim GeneroExiste As Boolean = False
                    For Each cgene In cgen
                        If cgene.Key = genero Then
                            GeneroExiste = True
                            Dim AnimeJaNesseGenero As Boolean = False
                            Dim gek = client.Get("Generos/" & genero & "/Animes")
                            Dim GenEps As JObject = gek.ResultAs(Of JObject)
                            Try
                                For Each animeingenero In GenEps
                                    If animeingenero.Value("AnimeId") = ANIME.Id.ToString Then
                                        AnimeJaNesseGenero = True
                                        Exit For
                                    End If
                                Next
                            Catch ex As Exception

                            End Try


                            If Not AnimeJaNesseGenero Then
                                Dim animegen As New AnimeGeneroa
                                Dim generoAtualizar As New GeneroaAtualizar
                                Dim contanime = client.Get("Generos/" & genero).ResultAs(Of JObject).SelectToken("Count").ToString
                                generoAtualizar.Count = Conversion.Int(contanime) + 1
                                Dim atualizaGen = client.Update("Generos/" & genero, generoAtualizar)
                                animegen.AnimeId = ANIME.Id
                                Dim upanimegen = client.Set("Generos/" & genero & "/Animes/" & animegen.AnimeId.ToString, animegen)
                            End If
                            Exit For
                        End If
                    Next
                    If Not GeneroExiste Then
                        Dim gene As New Generoa
                        gene.Count = 1
                        gene.Name = genero
                        Dim upgen = client.Set("Generos/" & genero, gene)
                        Dim animegen As New AnimeGeneroa
                        animegen.AnimeId = ANIME.Id
                        Dim upanimegen = client.Set("Generos/" & genero & "/Animes/" & animegen.AnimeId.ToString, animegen)
                    End If
                Next

                Dim anim As Anime = Await Jikans.GetAnime(ANIME.Id)
                Dim conteps = anim.Episodes
                Dim eps As AnimeEpisodes
                eps = Await Jikans.GetAnimeEpisodes(ANIME.Id)

                For i = 1 To eps.EpisodesLastPage
                    eps = Await Jikans.GetAnimeEpisodes(ANIME.Id, i)
                    For Each ep In eps.EpisodeCollection
                        Dim episod As New episodioa
                        episod.AnimeID = ANIME.Id
                        episod.Numero = ep.Id
                        episod.Nome = ep.Title
                        episod.Opening = PegarOPeED(anim.OpeningTheme, episod.Numero)
                        episod.Ending = PegarOPeED(anim.EndingTheme, episod.Numero)
                        Dim upepisodio = client.Set("Episodios/" & ANIME.Id & "_" & episod.Numero, episod)
                    Next
                    Threading.Thread.Sleep(500)
                Next
                Atualizar(sender)
                MsgBox("Anime Adicionado com Sucesso!!")
                Exit Do
            Catch ex As Exception
                If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Do
                End If
            End Try
        Loop
    End Sub

    Sub Atualizar(sender As Object)

        Dim animes = client.Get("Animes")
        Dim canim As JObject = animes.ResultAs(Of JObject)
        If sender Is listboxAnimeEpisodios Then

            Dim episodios = client.Get("Episodios")
            Dim cepi As JObject = episodios.ResultAs(Of JObject)
            listboxEpisodios.Items.Clear()
            For Each item In cepi

                If item.Value("AnimeID").ToString = NumeroAnime Then
                    listboxEpisodios.Items.Add(item.Value("AnimeID").ToString & "_" & item.Value("Numero").ToString)
                End If
            Next
            Dim arr(listboxEpisodios.Items.Count - 1) As Integer
            Dim i As Integer = 0
            For Each item In cepi
                If item.Value("AnimeID").ToString = NumeroAnime Then
                    arr(i) = item.Value("Numero").ToString
                    i = i + 1
                End If
            Next
            listboxEpisodios.Items.Clear()
            Array.Sort(arr)
            For Each it In arr
                listboxEpisodios.Items.Add(NumeroAnime & "_" & it.ToString)
            Next
        ElseIf sender Is listboxEpisodios Then
            Dim episodios = client.Get("Episodios")
            Dim cepi As JObject = episodios.ResultAs(Of JObject)
            Dim ss = cepi.SelectToken(listboxEpisodios.SelectedItem.ToString)
            TextBox9.Text = ss.SelectToken("AnimeID").ToString
            TextBox8.Text = ss.SelectToken("Ending").ToString
            TextBox2.Text = ss.SelectToken("Nome").ToString
            TextBox3.Text = ss.SelectToken("Numero").ToString
            TextBox7.Text = ss.SelectToken("Opening").ToString
            TextBox4.Text = ss.SelectToken("Thumb_Url").ToString
            TextBox6.Text = ss.SelectToken("Video_Url").ToString
            PictureBox1.ImageLocation = ss.SelectToken("Thumb_Url").ToString
        ElseIf sender Is listboxAnimes1 Then
            Dim ss = canim.SelectToken(listboxAnimes1.SelectedItem.ToString.Split("|")(1).Replace(" ", ""))
            txtboxAnoLancamento.Text = ss.SelectToken("Ano_Lancamento")
            txtboxGeneros.Text = ss.SelectToken("Generos")
            txtboxIDAnime.Text = ss.SelectToken("Id")
            txtboxNome.Text = ss.SelectToken("Nome")
            txtboxNotaMAL.Text = ss.SelectToken("NotaMAL")
            txtboxSinopse.Text = ss.SelectToken("Sinopse")
            txtboxStudios.Text = ss.SelectToken("Studios")
            txtboxThumb.Text = ss.SelectToken("Thumb_Url")
            picboxThumb.ImageLocation = ss.SelectToken("Thumb_Url")
            txtboxepthumb.Text = ss.SelectToken("Thumb_Ep")
        ElseIf sender Is listboxGeneros Then
            Dim genros = client.Get("Generos")
            Dim cgenros As JObject = genros.ResultAs(Of JObject)
            Dim ss = cgenros.SelectToken(listboxGeneros.SelectedItem.ToString)
            TextBox11.Text = ss.SelectToken("Name").ToString
            TextBox5.Text = ss.SelectToken("Count").ToString
            TextBox1.Text = ss.SelectToken("Nome_PtBr").ToString
            TextBox10.Text = ss.SelectToken("Thumb_Url").ToString
            PictureBox3.ImageLocation = ss.SelectToken("Thumb_Url").ToString
            listboxAnimesGenero.Items.Clear()
            Dim gek = client.Get("Generos/" & listboxGeneros.SelectedItem.ToString & "/Animes")
            Dim GenEps As JObject = gek.ResultAs(Of JObject)
            For Each item In GenEps
                listboxAnimesGenero.Items.Add(item.Value("AnimeId").ToString)
            Next
        ElseIf sender Is Me Or sender Is btnDeletarAnime Or sender Is btnAddAnime Then
            listboxAnimes1.Items.Clear()
            listboxAnimeEpisodios.Items.Clear()
            listboxGeneros.Items.Clear()
            For Each item In canim
                listboxAnimeEpisodios.Items.Add(item.Value("Nome").ToString & " | " & item.Value("Id").ToString)
                listboxAnimes1.Items.Add(item.Value("Nome").ToString & " | " & item.Value("Id").ToString)
            Next
            Dim genros = client.Get("Generos")
            Dim cgenros As JObject = genros.ResultAs(Of JObject)
            For Each item In cgenros
                listboxGeneros.Items.Add(item.Value("Name").ToString)
            Next
            listboxEpisodiosHome.Items.Clear()
            Dim epshome = client.Get("EpisodiosHome")
            Dim cepshome As JObject = epshome.ResultAs(Of JObject)
            For Each ep In cepshome
                listboxEpisodiosHome.Items.Add(ep.Value("id").ToString)
            Next
            Dim SobreDados As JObject = client.Get("SobreDados").ResultAs(Of JObject)
            txtboxEmail.Text = SobreDados.SelectToken("Email").ToString
            txtboxYoutube.Text = SobreDados.SelectToken("Youtube").ToString()
            txtboxInstagram.Text = SobreDados.SelectToken("Instagram").ToString()
            txtboxVersionMajor.Text = SobreDados.SelectToken("Version").ToString.Split(".")(0)
            txtboxVersionMinor.Text = SobreDados.SelectToken("Version").ToString.Split(".")(1)
            txtboxVersionBuild.Text = SobreDados.SelectToken("Version").ToString.Split(".")(2)
            txtboxVersionRevision.Text = SobreDados.SelectToken("Version").ToString.Split(".")(3)
            txtboxDownload.Text = SobreDados.SelectToken("DownloadUltimaVersao").ToString
            txtboxBoasVindas.Text = SobreDados.SelectToken("BoasVindas").ToString
            chkboxBoasVindas.Checked = Convert.ToBoolean(SobreDados.SelectToken("MostrarBoasVindas").ToString)
        End If
        If sender Is listboxAnimes1 Or sender Is btnAddAnime Or sender Is btnDeletarAnime Or sender Is btnScrap Then
            Dim ExisteAnime As Boolean = False
            For Each item In canim
                If item.Value("Id").ToString = txtboxIDAnime.Text Then
                    ExisteAnime = True
                    Exit For
                End If
            Next
            If ExisteAnime Then
                btnAddAnime.Visible = False
                btnDeletarAnime.Visible = True
                btnAtualizarAnime.Visible = True
            ElseIf Not ExisteAnime Then
                btnAddAnime.Visible = True
                btnAtualizarAnime.Visible = False
                btnDeletarAnime.Visible = False
            End If
        End If


    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxAnimeEpisodios.SelectedIndexChanged
        If Not listboxAnimeEpisodios.SelectedItem = "" Then
            Do
                Try
                    NumeroAnime = listboxAnimeEpisodios.SelectedItem.ToString.Split("|")(1).Replace(" ", "")
                    Atualizar(sender)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxEpisodios.SelectedIndexChanged
        If Not listboxEpisodios.SelectedItem.ToString = "" Then
            Do
                Try
                    Atualizar(sender)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxAnimes1.SelectedIndexChanged
        If Not listboxAnimes1.SelectedItem = "" Then
            Do
                Try
                    Atualizar(sender)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If
    End Sub

    Async Sub btnDeletarAnime_Click(sender As Object, e As EventArgs) Handles btnDeletarAnime.Click

        Dim ms As MsgBoxResult = MsgBox("Você tem certeza que deseja Excluir este anime? ", MsgBoxStyle.YesNo, "Caixa de Confirmação")
        If ms = DialogResult.Yes Then
            Do
                Try
                    Dim eps As AnimeEpisodes = Await Jikans.GetAnimeEpisodes(txtboxIDAnime.Text, 1)
                    For i = 1 To eps.EpisodesLastPage
                        eps = Await Jikans.GetAnimeEpisodes(txtboxIDAnime.Text, i)
                        For Each ep In eps.EpisodeCollection
                            Try
                                Dim delep = client.Delete("Episodios/" & txtboxIDAnime.Text & "_" & ep.Id)
                            Catch ex As Exception
                            End Try
                        Next
                    Next
                    Dim generos = txtboxGeneros.Text.Split(",")
                    For Each genero In generos
                        Try
                            Dim delanimeingen = client.Delete("Generos/" & genero & "/Animes/" & txtboxIDAnime.Text)
                            Dim generoAtualizar As New GeneroaAtualizar
                            Dim contanime = client.Get("Generos/" & genero).ResultAs(Of JObject).SelectToken("Count").ToString
                            generoAtualizar.Count = Conversion.Int(contanime) - 1
                            Dim atualizaGen = client.Update("Generos/" & genero, generoAtualizar)
                        Catch ex As Exception
                        End Try
                    Next
                    Dim delanime = client.Delete("Animes/" & txtboxIDAnime.Text)
                    MsgBox("Anime Excluido com Sucesso")
                    txtboxNome.Clear()
                    txtboxIDAnime.Clear()
                    txtboxGeneros.Clear()
                    txtboxNotaMAL.Clear()
                    txtboxThumb.Clear()
                    txtboxAnoLancamento.Clear()
                    txtboxStudios.Clear()
                    txtboxSinopse.Clear()
                    picboxThumb.ImageLocation = ""
                    Atualizar(sender)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SobDados As New SDados
        SobDados.Email = txtboxEmail.Text
        SobDados.Youtube = txtboxYoutube.Text
        SobDados.Instagram = txtboxInstagram.Text
        SobDados.Version = txtboxVersionMajor.Text & "." & txtboxVersionMinor.Text & "." & txtboxVersionBuild.Text & "." & txtboxVersionRevision.Text
        SobDados.DownloadUltimaVersao = txtboxDownload.Text
        SobDados.MostrarBoasVindas = chkboxBoasVindas.Checked
        SobDados.BoasVindas = txtboxBoasVindas.Text
        Dim AtualizaEmail = client.Update("SobreDados", SobDados)
        MsgBox("Informações Atualizadas com Sucesso")
    End Sub

    Async Sub btnAtualizarAnime_Click(sender As Object, e As EventArgs) Handles btnAtualizarAnime.Click
        Do
            Try
                Dim ANIME As New Animesa
                ANIME.Nome = txtboxNome.Text
                ANIME.Id = txtboxIDAnime.Text
                ANIME.Generos = txtboxGeneros.Text.Replace(" ", "_")
                ANIME.NotaMAL = txtboxNotaMAL.Text
                ANIME.Thumb_Url = txtboxThumb.Text
                ANIME.Ano_Lancamento = txtboxAnoLancamento.Text
                ANIME.Studios = txtboxStudios.Text
                ANIME.Sinopse = txtboxSinopse.Text
                ANIME.Thumb_Ep = txtboxepthumb.Text
                Dim upanime = client.Update("Animes/" & ANIME.Id.ToString, ANIME)

                Dim generos = ANIME.Generos.Split(",")
                Dim cgeneros = client.Get("Generos")
                Dim cgen As JObject = cgeneros.ResultAs(Of JObject)
                For Each genero In generos
                    Dim GeneroExiste As Boolean = False
                    For Each cgene In cgen
                        If cgene.Key = genero Then
                            GeneroExiste = True
                            Dim AnimeJaNesseGenero As Boolean = False
                            Dim gek = client.Get("Generos/" & genero & "/Animes")
                            Dim GenEps As JObject = gek.ResultAs(Of JObject)
                            Try
                                For Each animeingenero In GenEps
                                    If animeingenero.Value("AnimeId") = ANIME.Id.ToString Then
                                        AnimeJaNesseGenero = True
                                        Exit For
                                        REM
                                    End If
                                Next
                            Catch ex As Exception

                            End Try

                            If Not AnimeJaNesseGenero Then
                                Dim animegen As New AnimeGeneroa
                                Dim generoAtualizar As New GeneroaAtualizar
                                Dim contanime = client.Get("Generos/" & genero).ResultAs(Of JObject).SelectToken("Count").ToString
                                generoAtualizar.Count = Conversion.Int(contanime) + 1
                                Dim atualizaGen = client.Update("Generos/" & genero, generoAtualizar)
                                animegen.AnimeId = ANIME.Id
                                Dim upanimegen = client.Set("Generos/" & genero & "/Animes/" & animegen.AnimeId.ToString, animegen)
                            End If
                            Exit For
                        End If
                    Next
                    If Not GeneroExiste Then
                        Dim gene As New Generoa
                        gene.Count = 1
                        gene.Name = genero
                        Dim upgen = client.Set("Generos/" & genero, gene)
                        Dim animegen As New AnimeGeneroa
                        animegen.AnimeId = ANIME.Id
                        Dim upanimegen = client.Set("Generos/" & genero & "/Animes/" & animegen.AnimeId.ToString, animegen)
                    End If
                Next

                Dim anim As Anime = Await Jikans.GetAnime(ANIME.Id)
                Dim eps As AnimeEpisodes = Await Jikans.GetAnimeEpisodes(ANIME.Id, 1)
                Dim episodios = client.Get("Episodios")
                Dim cepi As JObject = episodios.ResultAs(Of JObject)
                For i = 1 To eps.EpisodesLastPage
                    eps = Await Jikans.GetAnimeEpisodes(ANIME.Id, i)
                    For Each ep In eps.EpisodeCollection
                        Dim epexiste As Boolean = False
                        For Each item In cepi
                            If item.Key = ANIME.Id & "_" & ep.Id Then
                                epexiste = True
                                Exit For
                            End If
                        Next
                        If epexiste Then
                            Continue For
                        End If
                        Dim episod As New episodioa
                        episod.AnimeID = ANIME.Id
                        episod.Numero = ep.Id
                        episod.Nome = ep.Title
                        episod.Opening = PegarOPeED(anim.OpeningTheme, episod.Numero)
                        episod.Ending = PegarOPeED(anim.EndingTheme, episod.Numero)
                        Dim upepisodio = client.Set("Episodios/" & ANIME.Id & "_" & episod.Numero, episod)
                    Next
                    Threading.Thread.Sleep(500)
                Next
                MsgBox("Anime Atualizado com Sucesso!!")
                Exit Do
            Catch ex As Exception
                If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Do
                End If
            End Try
        Loop
    End Sub

    Private Sub btnAtualizarEpisodio_Click(sender As Object, e As EventArgs) Handles btnAtualizarEpisodio.Click
        Do
            Try
                Dim EPISODIO As New episodioa
                EPISODIO.AnimeID = TextBox9.Text
                EPISODIO.Numero = TextBox3.Text
                EPISODIO.Nome = TextBox2.Text
                EPISODIO.Opening = TextBox7.Text
                EPISODIO.Ending = TextBox8.Text
                EPISODIO.Video_Url = TextBox6.Text
                EPISODIO.Thumb_Url = TextBox4.Text
                Dim upepisodio = client.Update("Episodios/" & EPISODIO.AnimeID & "_" & EPISODIO.Numero, EPISODIO)
                PictureBox1.ImageLocation = EPISODIO.Thumb_Url
                If chkboxMsgBoxEp.Checked Then
                    MsgBox("Episodio Atualizado com Sucesso!!")
                End If
                Exit Do
            Catch ex As Exception
                If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Do
                End If
            End Try
        Loop
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxGeneros.SelectedIndexChanged
        If Not listboxGeneros.SelectedItem.ToString = "" Then
            Do
                Try
                    Atualizar(sender)
                    Exit Do
                Catch ex As Exception
                    If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Do
                    End If
                End Try
            Loop
        End If
    End Sub

    Private Sub btnAtualizarGenero_Click(sender As Object, e As EventArgs) Handles btnAtualizarGenero.Click
        Do
            Try
                Dim gene As New Generoa
                gene.Name = TextBox11.Text
                gene.Count = TextBox5.Text
                gene.Nome_PtBr = TextBox1.Text
                gene.Thumb_Url = TextBox10.Text
                Dim upgene = client.Update("Generos/" & gene.Name, gene)
                PictureBox3.ImageLocation = gene.Thumb_Url
                If chkboxMsgBoxGenero.Checked Then
                    MsgBox("Gênero Atualizado com Sucesso!!")
                End If
                Exit Do
            Catch ex As Exception
                If MsgBox("Erro, Tentar novamente?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Do
                End If
            End Try
        Loop
    End Sub

    Private Sub btnAtualizarEPhome_Click(sender As Object, e As EventArgs) Handles btnAtualizarEPhome.Click

    End Sub
    Dim stadus As Boolean = False
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim op As New OpenFileDialog
        If op.ShowDialog = DialogResult.OK Then
            stadus = True
            Dim arq = op.FileName
            Dim arqtxt As New StreamReader(arq)
            Dim txt() = Split(arqtxt.ReadToEnd, vbCrLf)
            ProgressBar1.Maximum = txt.Length
            For Each Linha In txt
                ProgressBar1.Visible = True
                ProgressBar1.Value = Array.IndexOf(txt, Linha)
                Dim NumEP = Linha.Split("|")(0).Replace("Episodio ", "")

                If listboxEpisodios.Items.Contains(NumeroAnime & "_" & NumEP) Then

                    listboxEpisodios.SetSelected(listboxEpisodios.FindString(NumeroAnime & "_" & NumEP), True)
                    Dim episodios = client.Get("Episodios")
                    Dim cepi As JObject = episodios.ResultAs(Of JObject)
                    Dim ss = cepi.SelectToken(listboxEpisodios.SelectedItem.ToString)
                    Dim Ep As New episodioa
                    Ep.AnimeID = ss.SelectToken("AnimeID").ToString
                    Ep.Ending = ss.SelectToken("Ending").ToString
                    Ep.Numero = ss.SelectToken("Numero").ToString
                    Ep.Opening = ss.SelectToken("Opening").ToString

                    If rdioVideoThumb.Checked Then
                        Dim UrlVideo = Linha.Split("|")(1)
                        Dim urlThumb
                        Dim temThumb = True
                        Try
                            urlThumb = Linha.Split("|")(2)
                        Catch ex As Exception
                            temThumb = False
                            urlThumb = ""
                        End Try
                        Ep.Nome = ss.SelectToken("Nome").ToString
                        If UrlVideo = ss.SelectToken("Video_Url").ToString And urlThumb = ss.SelectToken("Thumb_Url").ToString Then
                            Continue For
                        Else
                            If temThumb Then
                                Ep.Thumb_Url = urlThumb
                            Else
                                Ep.Thumb_Url = ss.SelectToken("Thumb_Url").ToString
                            End If
                            Ep.Video_Url = UrlVideo
                        End If
                    ElseIf rdioname.Checked Then
                        Dim Namee = Linha.Split("|")(1)
                        If Namee = ss.SelectToken("Nome").ToString Then
                            Continue For
                        Else
                            Ep.Nome = Namee
                            Ep.Video_Url = ss.SelectToken("Video_Url").ToString
                            Ep.Thumb_Url = ss.SelectToken("Thumb_Url").ToString
                        End If

                    End If
                        Label37.Text = "Episodio Atual: " & Ep.Numero
                    Dim setepp = client.Set("Episodios/" & NumeroAnime & "_" & NumEP, Ep)

                End If
            Next
            MsgBox("Pronto")
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
        End If

    End Sub
End Class
