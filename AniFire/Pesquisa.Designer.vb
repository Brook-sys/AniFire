<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pesquisa
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pesquisa))
        Me.IconeLupa = New System.Windows.Forms.PictureBox()
        Me.Sombra = New System.Windows.Forms.PictureBox()
        Me.txtPesquisar = New System.Windows.Forms.Label()
        Me.txtboxPesquisa = New System.Windows.Forms.TextBox()
        Me.IconCancelar = New System.Windows.Forms.PictureBox()
        CType(Me.IconeLupa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sombra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IconeLupa
        '
        Me.IconeLupa.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.IconeLupa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.IconeLupa.Image = CType(resources.GetObject("IconeLupa.Image"), System.Drawing.Image)
        Me.IconeLupa.Location = New System.Drawing.Point(16, 14)
        Me.IconeLupa.Name = "IconeLupa"
        Me.IconeLupa.Size = New System.Drawing.Size(18, 18)
        Me.IconeLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IconeLupa.TabIndex = 1
        Me.IconeLupa.TabStop = False
        '
        'Sombra
        '
        Me.Sombra.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Sombra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Sombra.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sombra.Location = New System.Drawing.Point(0, 0)
        Me.Sombra.Name = "Sombra"
        Me.Sombra.Size = New System.Drawing.Size(160, 3)
        Me.Sombra.TabIndex = 0
        Me.Sombra.TabStop = False
        '
        'txtPesquisar
        '
        Me.txtPesquisar.AutoSize = True
        Me.txtPesquisar.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtPesquisar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPesquisar.Font = New System.Drawing.Font("Franklin Gothic Medium", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.txtPesquisar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtPesquisar.Location = New System.Drawing.Point(40, 10)
        Me.txtPesquisar.Name = "txtPesquisar"
        Me.txtPesquisar.Size = New System.Drawing.Size(86, 23)
        Me.txtPesquisar.TabIndex = 2
        Me.txtPesquisar.Text = "Pesquisar"
        '
        'txtboxPesquisa
        '
        Me.txtboxPesquisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtboxPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxPesquisa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtboxPesquisa.Font = New System.Drawing.Font("Franklin Gothic Medium", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.txtboxPesquisa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtboxPesquisa.Location = New System.Drawing.Point(20, 13)
        Me.txtboxPesquisa.Name = "txtboxPesquisa"
        Me.txtboxPesquisa.Size = New System.Drawing.Size(110, 21)
        Me.txtboxPesquisa.TabIndex = 3
        '
        'IconCancelar
        '
        Me.IconCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.IconCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IconCancelar.Image = Global.AniFire.My.Resources.Resources.cancel
        Me.IconCancelar.Location = New System.Drawing.Point(135, 16)
        Me.IconCancelar.Name = "IconCancelar"
        Me.IconCancelar.Size = New System.Drawing.Size(16, 16)
        Me.IconCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IconCancelar.TabIndex = 1
        Me.IconCancelar.TabStop = False
        Me.IconCancelar.Visible = False
        '
        'Pesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Controls.Add(Me.txtPesquisar)
        Me.Controls.Add(Me.IconCancelar)
        Me.Controls.Add(Me.IconeLupa)
        Me.Controls.Add(Me.Sombra)
        Me.Controls.Add(Me.txtboxPesquisa)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MinimumSize = New System.Drawing.Size(160, 43)
        Me.Name = "Pesquisa"
        Me.Size = New System.Drawing.Size(160, 43)
        CType(Me.IconeLupa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sombra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Sombra As PictureBox
    Friend WithEvents IconeLupa As PictureBox
    Friend WithEvents txtPesquisar As Label
    Friend WithEvents txtboxPesquisa As TextBox
    Friend WithEvents IconCancelar As PictureBox
End Class
