<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EpisodioHOME
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
        Me.labelnomeEpisodio = New System.Windows.Forms.Label()
        Me.labelnumeroepisodio = New System.Windows.Forms.Label()
        Me.Barrabaixo = New System.Windows.Forms.PictureBox()
        Me.picboxThumbnail = New System.Windows.Forms.PictureBox()
        CType(Me.Barrabaixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelnomeEpisodio
        '
        Me.labelnomeEpisodio.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.labelnomeEpisodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelnomeEpisodio.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelnomeEpisodio.ForeColor = System.Drawing.Color.White
        Me.labelnomeEpisodio.Location = New System.Drawing.Point(0, 116)
        Me.labelnomeEpisodio.Name = "labelnomeEpisodio"
        Me.labelnomeEpisodio.Size = New System.Drawing.Size(205, 37)
        Me.labelnomeEpisodio.TabIndex = 9
        '
        'labelnumeroepisodio
        '
        Me.labelnumeroepisodio.AutoSize = True
        Me.labelnumeroepisodio.BackColor = System.Drawing.Color.Red
        Me.labelnumeroepisodio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelnumeroepisodio.Dock = System.Windows.Forms.DockStyle.Right
        Me.labelnumeroepisodio.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelnumeroepisodio.ForeColor = System.Drawing.Color.White
        Me.labelnumeroepisodio.Location = New System.Drawing.Point(205, 0)
        Me.labelnumeroepisodio.Name = "labelnumeroepisodio"
        Me.labelnumeroepisodio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelnumeroepisodio.Size = New System.Drawing.Size(0, 15)
        Me.labelnumeroepisodio.TabIndex = 11
        Me.labelnumeroepisodio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Barrabaixo
        '
        Me.Barrabaixo.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Barrabaixo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Barrabaixo.Location = New System.Drawing.Point(0, 153)
        Me.Barrabaixo.Name = "Barrabaixo"
        Me.Barrabaixo.Size = New System.Drawing.Size(205, 3)
        Me.Barrabaixo.TabIndex = 10
        Me.Barrabaixo.TabStop = False
        '
        'picboxThumbnail
        '
        Me.picboxThumbnail.BackColor = System.Drawing.Color.Black
        Me.picboxThumbnail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picboxThumbnail.ErrorImage = Global.AniFire.My.Resources.Resources.ImageFailLoad205x116
        Me.picboxThumbnail.Location = New System.Drawing.Point(0, 0)
        Me.picboxThumbnail.Name = "picboxThumbnail"
        Me.picboxThumbnail.Size = New System.Drawing.Size(205, 116)
        Me.picboxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxThumbnail.TabIndex = 8
        Me.picboxThumbnail.TabStop = False
        '
        'EpisodioHOME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Controls.Add(Me.labelnumeroepisodio)
        Me.Controls.Add(Me.Barrabaixo)
        Me.Controls.Add(Me.picboxThumbnail)
        Me.Controls.Add(Me.labelnomeEpisodio)
        Me.Name = "EpisodioHOME"
        Me.Size = New System.Drawing.Size(205, 156)
        CType(Me.Barrabaixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Barrabaixo As PictureBox
    Friend WithEvents labelnomeEpisodio As Label
    Friend WithEvents picboxThumbnail As PictureBox
    Friend WithEvents labelnumeroepisodio As Label
End Class
