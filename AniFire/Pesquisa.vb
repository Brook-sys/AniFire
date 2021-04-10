Public Class Pesquisa


    Inherits System.Windows.Forms.UserControl
    Friend WithEvents txtbox As System.Windows.Forms.TextBox
    Public Event TeclaBaixo(ByVal sender, ByVal e)
    Property texto() As String
        Get
            Return txtboxPesquisa.Text
        End Get
        Set(value As String)
            txtboxPesquisa.Text = value
            If txtboxPesquisa.Text = "" Then
                txtPesquisar.Visible = True
                IconeLupa.Visible = True
                IconCancelar.Visible = False
            End If
        End Set
    End Property

    Private Sub EscreverTexto_GotFocus(sender As Object, e As EventArgs) Handles txtboxPesquisa.GotFocus, txtPesquisar.Click, IconeLupa.Click, Me.Click
        IconCancelar.Visible = True
        txtPesquisar.Visible = False
        IconeLupa.Visible = False
        txtboxPesquisa.Focus()
    End Sub

    Private Sub TextBoxTexto_LostFocus(sender As Object, e As EventArgs) Handles txtboxPesquisa.LostFocus
        If txtboxPesquisa.Text = "" Then
            txtPesquisar.Visible = True
            IconeLupa.Visible = True
            IconCancelar.Visible = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles IconCancelar.Click
        txtboxPesquisa.Text = ""
        If Not txtboxPesquisa.Focused Then
            TextBoxTexto_LostFocus(sender, e)
        End If
    End Sub

    Private Sub Pesquisa_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        IconCancelar.Location = New Point(Me.Size.Width - 25, IconCancelar.Location.Y)
        txtboxPesquisa.Size = New Size(IconCancelar.Location.X - 10 - txtboxPesquisa.Location.X, txtboxPesquisa.Height)
    End Sub

    Private Sub TextBoxTexto_TextChanged(sender As Object, e As EventArgs) Handles txtboxPesquisa.TextChanged
        If Not txtboxPesquisa.Text = "" Then
            IconCancelar.Visible = True
            txtPesquisar.Visible = False
            IconeLupa.Visible = False

        End If
    End Sub

    Private Sub TextBoxTexto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxPesquisa.KeyDown
        RaiseEvent TeclaBaixo(Me, e)
    End Sub

End Class
