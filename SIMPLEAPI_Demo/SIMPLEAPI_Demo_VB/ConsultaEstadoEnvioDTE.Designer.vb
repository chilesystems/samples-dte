<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaEstadoEnvioDTE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.textRespuesta = New System.Windows.Forms.TextBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.radioCertificacion = New System.Windows.Forms.RadioButton()
        Me.radioProduccion = New System.Windows.Forms.RadioButton()
        Me.botonConsultar = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioEnvioDTE = New System.Windows.Forms.RadioButton()
        Me.radioEnvioBoleta = New System.Windows.Forms.RadioButton()
        Me.label10 = New System.Windows.Forms.Label()
        Me.textTrackID = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.textDVEmpresa = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.textRUTEmpresa = New System.Windows.Forms.TextBox()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.textRespuesta)
        Me.groupBox3.Location = New System.Drawing.Point(310, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(353, 300)
        Me.groupBox3.TabIndex = 26
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Resultado"
        '
        'textRespuesta
        '
        Me.textRespuesta.Location = New System.Drawing.Point(6, 23)
        Me.textRespuesta.Multiline = True
        Me.textRespuesta.Name = "textRespuesta"
        Me.textRespuesta.Size = New System.Drawing.Size(341, 271)
        Me.textRespuesta.TabIndex = 19
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.radioCertificacion)
        Me.groupBox2.Controls.Add(Me.radioProduccion)
        Me.groupBox2.Controls.Add(Me.botonConsultar)
        Me.groupBox2.Location = New System.Drawing.Point(22, 123)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(282, 62)
        Me.groupBox2.TabIndex = 25
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Ambiente"
        '
        'radioCertificacion
        '
        Me.radioCertificacion.AutoSize = True
        Me.radioCertificacion.Checked = True
        Me.radioCertificacion.Location = New System.Drawing.Point(9, 28)
        Me.radioCertificacion.Name = "radioCertificacion"
        Me.radioCertificacion.Size = New System.Drawing.Size(83, 17)
        Me.radioCertificacion.TabIndex = 16
        Me.radioCertificacion.TabStop = True
        Me.radioCertificacion.Text = "Certificación"
        Me.radioCertificacion.UseVisualStyleBackColor = True
        '
        'radioProduccion
        '
        Me.radioProduccion.AutoSize = True
        Me.radioProduccion.Location = New System.Drawing.Point(103, 28)
        Me.radioProduccion.Name = "radioProduccion"
        Me.radioProduccion.Size = New System.Drawing.Size(79, 17)
        Me.radioProduccion.TabIndex = 17
        Me.radioProduccion.Text = "Producción"
        Me.radioProduccion.UseVisualStyleBackColor = True
        '
        'botonConsultar
        '
        Me.botonConsultar.Location = New System.Drawing.Point(201, 25)
        Me.botonConsultar.Name = "botonConsultar"
        Me.botonConsultar.Size = New System.Drawing.Size(75, 23)
        Me.botonConsultar.TabIndex = 0
        Me.botonConsultar.Text = "Consultar"
        Me.botonConsultar.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.radioEnvioDTE)
        Me.groupBox1.Controls.Add(Me.radioEnvioBoleta)
        Me.groupBox1.Controls.Add(Me.label10)
        Me.groupBox1.Controls.Add(Me.textTrackID)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.textDVEmpresa)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.textRUTEmpresa)
        Me.groupBox1.Location = New System.Drawing.Point(22, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(282, 105)
        Me.groupBox1.TabIndex = 24
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos del DTE"
        '
        'radioEnvioDTE
        '
        Me.radioEnvioDTE.AutoSize = True
        Me.radioEnvioDTE.Checked = True
        Me.radioEnvioDTE.Location = New System.Drawing.Point(117, 75)
        Me.radioEnvioDTE.Name = "radioEnvioDTE"
        Me.radioEnvioDTE.Size = New System.Drawing.Size(74, 17)
        Me.radioEnvioDTE.TabIndex = 22
        Me.radioEnvioDTE.TabStop = True
        Me.radioEnvioDTE.Text = "EnvioDTE"
        Me.radioEnvioDTE.UseVisualStyleBackColor = True
        '
        'radioEnvioBoleta
        '
        Me.radioEnvioBoleta.AutoSize = True
        Me.radioEnvioBoleta.Location = New System.Drawing.Point(194, 75)
        Me.radioEnvioBoleta.Name = "radioEnvioBoleta"
        Me.radioEnvioBoleta.Size = New System.Drawing.Size(82, 17)
        Me.radioEnvioBoleta.TabIndex = 23
        Me.radioEnvioBoleta.Text = "EnvioBoleta"
        Me.radioEnvioBoleta.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 52)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(49, 13)
        Me.label10.TabIndex = 21
        Me.label10.Text = "TrackID:"
        '
        'textTrackID
        '
        Me.textTrackID.Location = New System.Drawing.Point(117, 49)
        Me.textTrackID.Name = "textTrackID"
        Me.textTrackID.Size = New System.Drawing.Size(112, 20)
        Me.textTrackID.TabIndex = 20
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(237, 26)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(10, 13)
        Me.label6.TabIndex = 13
        Me.label6.Text = "-"
        '
        'textDVEmpresa
        '
        Me.textDVEmpresa.Enabled = False
        Me.textDVEmpresa.Location = New System.Drawing.Point(253, 23)
        Me.textDVEmpresa.Name = "textDVEmpresa"
        Me.textDVEmpresa.ReadOnly = True
        Me.textDVEmpresa.Size = New System.Drawing.Size(23, 20)
        Me.textDVEmpresa.TabIndex = 12
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(77, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "RUT Empresa:"
        '
        'textRUTEmpresa
        '
        Me.textRUTEmpresa.Enabled = False
        Me.textRUTEmpresa.Location = New System.Drawing.Point(117, 23)
        Me.textRUTEmpresa.Name = "textRUTEmpresa"
        Me.textRUTEmpresa.ReadOnly = True
        Me.textRUTEmpresa.Size = New System.Drawing.Size(112, 20)
        Me.textRUTEmpresa.TabIndex = 0
        '
        'ConsultaEstadoEnvioDTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 343)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "ConsultaEstadoEnvioDTE"
        Me.Text = "ConsultaEstadoEnvioDTE"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents groupBox3 As GroupBox
    Private WithEvents textRespuesta As TextBox
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents radioCertificacion As RadioButton
    Private WithEvents radioProduccion As RadioButton
    Private WithEvents botonConsultar As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents radioEnvioDTE As RadioButton
    Private WithEvents radioEnvioBoleta As RadioButton
    Private WithEvents label10 As Label
    Private WithEvents textTrackID As TextBox
    Private WithEvents label6 As Label
    Private WithEvents textDVEmpresa As TextBox
    Private WithEvents label1 As Label
    Private WithEvents textRUTEmpresa As TextBox
End Class
