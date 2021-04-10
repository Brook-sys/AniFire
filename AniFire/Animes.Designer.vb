<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Animes
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
        Me.lblNomeAnime = New System.Windows.Forms.Label()
        Me.BarraBaixo = New System.Windows.Forms.PictureBox()
        Me.picboxThumbnail = New System.Windows.Forms.PictureBox()
        CType(Me.BarraBaixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNomeAnime
        '
        Me.lblNomeAnime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNomeAnime.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeAnime.ForeColor = System.Drawing.Color.White
        Me.lblNomeAnime.Location = New System.Drawing.Point(0, 225)
        Me.lblNomeAnime.Name = "lblNomeAnime"
        Me.lblNomeAnime.Size = New System.Drawing.Size(151, 34)
        Me.lblNomeAnime.TabIndex = 1
        Me.lblNomeAnime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraBaixo
        '
        Me.BarraBaixo.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BarraBaixo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BarraBaixo.Location = New System.Drawing.Point(0, 259)
        Me.BarraBaixo.Name = "BarraBaixo"
        Me.BarraBaixo.Size = New System.Drawing.Size(151, 3)
        Me.BarraBaixo.TabIndex = 2
        Me.BarraBaixo.TabStop = False
        '
        'picboxThumbnail
        '
        Me.picboxThumbnail.BackColor = System.Drawing.Color.Black
        Me.picboxThumbnail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picboxThumbnail.ErrorImage = Global.AniFire.My.Resources.Resources.ImageFailLoadAnime
        Me.picboxThumbnail.ImageLocation = ""
        Me.picboxThumbnail.Location = New System.Drawing.Point(0, 0)
        Me.picboxThumbnail.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxThumbnail.Name = "picboxThumbnail"
        Me.picboxThumbnail.Size = New System.Drawing.Size(151, 225)
        Me.picboxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxThumbnail.TabIndex = 0
        Me.picboxThumbnail.TabStop = False
        '
        'Animes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Controls.Add(Me.BarraBaixo)
        Me.Controls.Add(Me.lblNomeAnime)
        Me.Controls.Add(Me.picboxThumbnail)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Animes"
        Me.Size = New System.Drawing.Size(151, 262)
        CType(Me.BarraBaixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picboxThumbnail As PictureBox
    Friend WithEvents lblNomeAnime As Label
    Friend WithEvents BarraBaixo As PictureBox
End Class
