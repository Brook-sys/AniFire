Public Class Botao
    Inherits System.Windows.Forms.UserControl
    Friend WithEvents txtbox As System.Windows.Forms.Button
    Public ativo As Boolean = False
    Public Event clique(ByVal sender, ByVal e)

    Property actived() As Boolean
        Get
            Return ativo
        End Get
        Set(value As Boolean)
            ativo = value
        End Set
    End Property
    Property text() As String
        Get
            Return Button1.Text
            Return Button1.Name
        End Get
        Set(value As String)
            Button1.Text = value
            Button1.Name = value
        End Set
    End Property
    Property backcolor() As Color
        Get
            Return Button1.BackColor
        End Get
        Set(value As Color)
            Button1.BackColor = value

        End Set
    End Property
    Property forecolor() As Color
        Get
            Return Button1.ForeColor
        End Get
        Set(value As Color)
            Button1.ForeColor = value
        End Set
    End Property
    Property barcolor() As Color
        Get
            Return PictureBox1.BackColor
        End Get
        Set(value As Color)
            PictureBox1.BackColor = value
        End Set
    End Property

    Private Sub EntradaDoMouse(sender As Object, e As EventArgs) Handles Button1.MouseEnter, PictureBox1.MouseEnter
        If ativo = False Then
            Button1.BackColor = Color.FromArgb(76, 166, 79)
            Button1.ForeColor = Color.White
            PictureBox1.BackColor = Color.FromArgb(50, 108, 52)


        End If
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave, PictureBox1.MouseLeave
        If ativo = False Then
            Button1.BackColor = Color.FromArgb(51, 51, 51)
            Button1.ForeColor = Color.FromArgb(214, 214, 214)
            PictureBox1.BackColor = Color.FromArgb(33, 33, 33)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent clique(Me, e)
    End Sub
End Class
