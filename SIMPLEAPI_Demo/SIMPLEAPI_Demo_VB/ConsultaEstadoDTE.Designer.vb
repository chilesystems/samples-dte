<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaEstadoDTE
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
        Me.checkIsBoletaCertificacion = New System.Windows.Forms.CheckBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.textFolio = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.textDVReceptor = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.textRUTReceptor = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.textDVEnvio = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.textDVEmpresa = New System.Windows.Forms.TextBox()
        Me.dateFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.comboTipoDTE = New System.Windows.Forms.ComboBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.textTotal = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.textRUTEnvio = New System.Windows.Forms.TextBox()
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
        Me.groupBox3.Location = New System.Drawing.Point(309, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(353, 300)
        Me.groupBox3.TabIndex = 23
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
        Me.groupBox2.Location = New System.Drawing.Point(15, 250)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(282, 62)
        Me.groupBox2.TabIndex = 22
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
        Me.groupBox1.Controls.Add(Me.checkIsBoletaCertificacion)
        Me.groupBox1.Controls.Add(Me.label10)
        Me.groupBox1.Controls.Add(Me.textFolio)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.textDVReceptor)
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.textRUTReceptor)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.textDVEnvio)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.textDVEmpresa)
        Me.groupBox1.Controls.Add(Me.dateFechaEmision)
        Me.groupBox1.Controls.Add(Me.comboTipoDTE)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.textTotal)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.textRUTEnvio)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.textRUTEmpresa)
        Me.groupBox1.Location = New System.Drawing.Point(21, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(282, 232)
        Me.groupBox1.TabIndex = 21
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos del DTE"
        '
        'checkIsBoletaCertificacion
        '
        Me.checkIsBoletaCertificacion.AutoSize = True
        Me.checkIsBoletaCertificacion.Location = New System.Drawing.Point(51, 206)
        Me.checkIsBoletaCertificacion.Name = "checkIsBoletaCertificacion"
        Me.checkIsBoletaCertificacion.Size = New System.Drawing.Size(225, 17)
        Me.checkIsBoletaCertificacion.TabIndex = 41
        Me.checkIsBoletaCertificacion.Text = "Es una boleta del proceso de Certificación"
        Me.checkIsBoletaCertificacion.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 130)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(32, 13)
        Me.label10.TabIndex = 21
        Me.label10.Text = "Folio:"
        '
        'textFolio
        '
        Me.textFolio.Location = New System.Drawing.Point(117, 127)
        Me.textFolio.Name = "textFolio"
        Me.textFolio.Size = New System.Drawing.Size(112, 20)
        Me.textFolio.TabIndex = 20
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(237, 78)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(10, 13)
        Me.label8.TabIndex = 19
        Me.label8.Text = "-"
        '
        'textDVReceptor
        '
        Me.textDVReceptor.Location = New System.Drawing.Point(253, 75)
        Me.textDVReceptor.Name = "textDVReceptor"
        Me.textDVReceptor.Size = New System.Drawing.Size(23, 20)
        Me.textDVReceptor.TabIndex = 8
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(6, 78)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(80, 13)
        Me.label9.TabIndex = 17
        Me.label9.Text = "RUT Receptor:"
        '
        'textRUTReceptor
        '
        Me.textRUTReceptor.Location = New System.Drawing.Point(117, 75)
        Me.textRUTReceptor.Name = "textRUTReceptor"
        Me.textRUTReceptor.Size = New System.Drawing.Size(112, 20)
        Me.textRUTReceptor.TabIndex = 5
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(237, 52)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(10, 13)
        Me.label7.TabIndex = 15
        Me.label7.Text = "-"
        '
        'textDVEnvio
        '
        Me.textDVEnvio.Enabled = False
        Me.textDVEnvio.Location = New System.Drawing.Point(253, 49)
        Me.textDVEnvio.Name = "textDVEnvio"
        Me.textDVEnvio.ReadOnly = True
        Me.textDVEnvio.Size = New System.Drawing.Size(23, 20)
        Me.textDVEnvio.TabIndex = 14
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
        'dateFechaEmision
        '
        Me.dateFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFechaEmision.Location = New System.Drawing.Point(117, 153)
        Me.dateFechaEmision.Name = "dateFechaEmision"
        Me.dateFechaEmision.Size = New System.Drawing.Size(112, 20)
        Me.dateFechaEmision.TabIndex = 30
        '
        'comboTipoDTE
        '
        Me.comboTipoDTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboTipoDTE.FormattingEnabled = True
        Me.comboTipoDTE.Location = New System.Drawing.Point(117, 179)
        Me.comboTipoDTE.Name = "comboTipoDTE"
        Me.comboTipoDTE.Size = New System.Drawing.Size(159, 21)
        Me.comboTipoDTE.TabIndex = 40
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 156)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(79, 13)
        Me.label5.TabIndex = 9
        Me.label5.Text = "Fecha Emisión:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 104)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(34, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "Total:"
        '
        'textTotal
        '
        Me.textTotal.Location = New System.Drawing.Point(117, 101)
        Me.textTotal.Name = "textTotal"
        Me.textTotal.Size = New System.Drawing.Size(112, 20)
        Me.textTotal.TabIndex = 10
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 182)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(56, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Tipo DTE:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 52)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "RUT Envío:"
        '
        'textRUTEnvio
        '
        Me.textRUTEnvio.Enabled = False
        Me.textRUTEnvio.Location = New System.Drawing.Point(117, 49)
        Me.textRUTEnvio.Name = "textRUTEnvio"
        Me.textRUTEnvio.ReadOnly = True
        Me.textRUTEnvio.Size = New System.Drawing.Size(112, 20)
        Me.textRUTEnvio.TabIndex = 2
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
        'ConsultaEstadoDTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 322)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "ConsultaEstadoDTE"
        Me.Text = "Consulta Estado DTE"
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
    Private WithEvents checkIsBoletaCertificacion As CheckBox
    Private WithEvents label10 As Label
    Private WithEvents textFolio As TextBox
    Private WithEvents label8 As Label
    Private WithEvents textDVReceptor As TextBox
    Private WithEvents label9 As Label
    Private WithEvents textRUTReceptor As TextBox
    Private WithEvents label7 As Label
    Private WithEvents textDVEnvio As TextBox
    Private WithEvents label6 As Label
    Private WithEvents textDVEmpresa As TextBox
    Private WithEvents dateFechaEmision As DateTimePicker
    Private WithEvents comboTipoDTE As ComboBox
    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents textTotal As TextBox
    Private WithEvents label3 As Label
    Private WithEvents label2 As Label
    Private WithEvents textRUTEnvio As TextBox
    Private WithEvents label1 As Label
    Private WithEvents textRUTEmpresa As TextBox
End Class
