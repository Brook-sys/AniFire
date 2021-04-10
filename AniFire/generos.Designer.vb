<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class generos
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
        Me.Barrabaixo = New System.Windows.Forms.PictureBox()
        Me.picboxThumbnail = New System.Windows.Forms.PictureBox()
        Me.labelnomegenero = New System.Windows.Forms.Label()
        CType(Me.Barrabaixo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Barrabaixo
        '
        Me.Barrabaixo.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Barrabaixo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Barrabaixo.Location = New System.Drawing.Point(0, 153)
        Me.Barrabaixo.Name = "Barrabaixo"
        Me.Barrabaixo.Size = New System.Drawing.Size(205, 3)
        Me.Barrabaixo.TabIndex = 14
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
        Me.picboxThumbnail.TabIndex = 12
        Me.picboxThumbnail.TabStop = False
        '
        'labelnomegenero
        '
        Me.labelnomegenero.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.labelnomegenero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelnomegenero.Font = New System.Drawing.Font("Franklin Gothic Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelnomegenero.ForeColor = System.Drawing.Color.White
        Me.labelnomegenero.Location = New System.Drawing.Point(0, 116)
        Me.labelnomegenero.Name = "labelnomegenero"
        Me.labelnomegenero.Size = New System.Drawing.Size(205, 37)
        Me.labelnomegenero.TabIndex = 13
        Me.labelnomegenero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'generos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Controls.Add(Me.Barrabaixo)
        Me.Controls.Add(Me.picboxThumbnail)
        Me.Controls.Add(Me.labelnomegenero)
        Me.Name = "generos"
        Me.Size = New System.Drawing.Size(205, 156)
        CType(Me.Barrabaixo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Barrabaixo As PictureBox
    Friend WithEvents picboxThumbnail As PictureBox
    Friend WithEvents labelnomegenero As Label
End Class
