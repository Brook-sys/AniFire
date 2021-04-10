<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formRelatarErro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtboxEp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtboxAnime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtboxErro = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtboxEmail = New System.Windows.Forms.TextBox()
        Me.lblasteristico1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Episodio:"
        '
        'txtboxEp
        '
        Me.txtboxEp.Location = New System.Drawing.Point(117, 56)
        Me.txtboxEp.Margin = New System.Windows.Forms.Padding(6)
        Me.txtboxEp.Name = "txtboxEp"
        Me.txtboxEp.Size = New System.Drawing.Size(218, 31)
        Me.txtboxEp.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Anime:"
        '
        'txtboxAnime
        '
        Me.txtboxAnime.Location = New System.Drawing.Point(117, 13)
        Me.txtboxAnime.Margin = New System.Windows.Forms.Padding(6)
        Me.txtboxAnime.Name = "txtboxAnime"
        Me.txtboxAnime.Size = New System.Drawing.Size(218, 31)
        Me.txtboxAnime.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Se puder descreva o Erro:"
        '
        'txtboxErro
        '
        Me.txtboxErro.Location = New System.Drawing.Point(25, 130)
        Me.txtboxErro.Margin = New System.Windows.Forms.Padding(6)
        Me.txtboxErro.Multiline = True
        Me.txtboxErro.Name = "txtboxErro"
        Me.txtboxErro.Size = New System.Drawing.Size(310, 91)
        Me.txtboxErro.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.AutoSize = True
        Me.btnEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Location = New System.Drawing.Point(132, 305)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(96, 38)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 231)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Email para contato:"
        '
        'txtboxEmail
        '
        Me.txtboxEmail.Location = New System.Drawing.Point(25, 263)
        Me.txtboxEmail.Margin = New System.Windows.Forms.Padding(6)
        Me.txtboxEmail.Name = "txtboxEmail"
        Me.txtboxEmail.Size = New System.Drawing.Size(310, 31)
        Me.txtboxEmail.TabIndex = 1
        '
        'lblasteristico1
        '
        Me.lblasteristico1.AutoSize = True
        Me.lblasteristico1.ForeColor = System.Drawing.Color.Red
        Me.lblasteristico1.Location = New System.Drawing.Point(3, 231)
        Me.lblasteristico1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblasteristico1.Name = "lblasteristico1"
        Me.lblasteristico1.Size = New System.Drawing.Size(24, 26)
        Me.lblasteristico1.TabIndex = 0
        Me.lblasteristico1.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(3, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "*"
        '
        'formRelatarErro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(364, 353)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtboxAnime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtboxErro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtboxEmail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtboxEp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblasteristico1)
        Me.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(380, 392)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(380, 392)
        Me.Name = "formRelatarErro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Relatar Erro"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtboxEp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtboxAnime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtboxErro As TextBox
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtboxEmail As TextBox
    Friend WithEvents lblasteristico1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
