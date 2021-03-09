<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.botonConfiguracion = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.radioCertificacion = New System.Windows.Forms.RadioButton()
        Me.radioProduccion = New System.Windows.Forms.RadioButton()
        Me.botonEnviarSii = New System.Windows.Forms.Button()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.botonFacturaCompra = New System.Windows.Forms.Button()
        Me.botonMuestraImpresa = New System.Windows.Forms.Button()
        Me.botonSetPruebas = New System.Windows.Forms.Button()
        Me.botonLibroGuias = New System.Windows.Forms.Button()
        Me.botonSetExportacion2 = New System.Windows.Forms.Button()
        Me.botonIntercambio = New System.Windows.Forms.Button()
        Me.botonCesion = New System.Windows.Forms.Button()
        Me.botonSimulacion = New System.Windows.Forms.Button()
        Me.botonSetExportacion = New System.Windows.Forms.Button()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.botonConsultarEstadoEnvio = New System.Windows.Forms.Button()
        Me.botonGetCertificados = New System.Windows.Forms.Button()
        Me.botonValidador = New System.Windows.Forms.Button()
        Me.botonTimbre = New System.Windows.Forms.Button()
        Me.botonAceptacion = New System.Windows.Forms.Button()
        Me.botonConsultarEstadoDTE = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.botonGenerarRCOFVacio = New System.Windows.Forms.Button()
        Me.botonEnviarAlSIIBoletas_Certificacion = New System.Windows.Forms.Button()
        Me.botonEnviarAlSIIBoletas = New System.Windows.Forms.Button()
        Me.botonGenerarEnvioBoleta = New System.Windows.Forms.Button()
        Me.botonRebajaDocumento = New System.Windows.Forms.Button()
        Me.botonAnularDocumento = New System.Windows.Forms.Button()
        Me.botonGenerarRCOF = New System.Windows.Forms.Button()
        Me.botonGenerarBoleta = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.botonAgregarRef = New System.Windows.Forms.Button()
        Me.botonGenerarEnvio = New System.Windows.Forms.Button()
        Me.botonGenerarDocumento = New System.Windows.Forms.Button()
        Me.botonIngresarTimbraje = New System.Windows.Forms.Button()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'botonConfiguracion
        '
        Me.botonConfiguracion.Location = New System.Drawing.Point(12, 263)
        Me.botonConfiguracion.Name = "botonConfiguracion"
        Me.botonConfiguracion.Size = New System.Drawing.Size(151, 23)
        Me.botonConfiguracion.TabIndex = 26
        Me.botonConfiguracion.Text = "Configuración"
        Me.botonConfiguracion.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.radioCertificacion)
        Me.groupBox4.Controls.Add(Me.radioProduccion)
        Me.groupBox4.Controls.Add(Me.botonEnviarSii)
        Me.groupBox4.Location = New System.Drawing.Point(12, 154)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(163, 103)
        Me.groupBox4.TabIndex = 28
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Envío al SII"
        '
        'radioCertificacion
        '
        Me.radioCertificacion.AutoSize = True
        Me.radioCertificacion.Checked = True
        Me.radioCertificacion.Location = New System.Drawing.Point(16, 25)
        Me.radioCertificacion.Name = "radioCertificacion"
        Me.radioCertificacion.Size = New System.Drawing.Size(83, 17)
        Me.radioCertificacion.TabIndex = 14
        Me.radioCertificacion.TabStop = True
        Me.radioCertificacion.Text = "Certificación"
        Me.radioCertificacion.UseVisualStyleBackColor = True
        '
        'radioProduccion
        '
        Me.radioProduccion.AutoSize = True
        Me.radioProduccion.Location = New System.Drawing.Point(16, 48)
        Me.radioProduccion.Name = "radioProduccion"
        Me.radioProduccion.Size = New System.Drawing.Size(79, 17)
        Me.radioProduccion.TabIndex = 15
        Me.radioProduccion.Text = "Producción"
        Me.radioProduccion.UseVisualStyleBackColor = True
        '
        'botonEnviarSii
        '
        Me.botonEnviarSii.Location = New System.Drawing.Point(5, 70)
        Me.botonEnviarSii.Name = "botonEnviarSii"
        Me.botonEnviarSii.Size = New System.Drawing.Size(151, 23)
        Me.botonEnviarSii.TabIndex = 3
        Me.botonEnviarSii.Text = "Enviar al SII"
        Me.botonEnviarSii.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.botonFacturaCompra)
        Me.groupBox3.Controls.Add(Me.botonMuestraImpresa)
        Me.groupBox3.Controls.Add(Me.botonSetPruebas)
        Me.groupBox3.Controls.Add(Me.botonLibroGuias)
        Me.groupBox3.Controls.Add(Me.botonSetExportacion2)
        Me.groupBox3.Controls.Add(Me.botonIntercambio)
        Me.groupBox3.Controls.Add(Me.botonCesion)
        Me.groupBox3.Controls.Add(Me.botonSimulacion)
        Me.groupBox3.Controls.Add(Me.botonSetExportacion)
        Me.groupBox3.Location = New System.Drawing.Point(181, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(163, 279)
        Me.groupBox3.TabIndex = 27
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Certificación"
        '
        'botonFacturaCompra
        '
        Me.botonFacturaCompra.Location = New System.Drawing.Point(6, 48)
        Me.botonFacturaCompra.Name = "botonFacturaCompra"
        Me.botonFacturaCompra.Size = New System.Drawing.Size(151, 23)
        Me.botonFacturaCompra.TabIndex = 21
        Me.botonFacturaCompra.Text = "Factura de Compra"
        Me.botonFacturaCompra.UseVisualStyleBackColor = True
        '
        'botonMuestraImpresa
        '
        Me.botonMuestraImpresa.Location = New System.Drawing.Point(6, 251)
        Me.botonMuestraImpresa.Name = "botonMuestraImpresa"
        Me.botonMuestraImpresa.Size = New System.Drawing.Size(151, 23)
        Me.botonMuestraImpresa.TabIndex = 19
        Me.botonMuestraImpresa.Text = "Muestra Impresa"
        Me.botonMuestraImpresa.UseVisualStyleBackColor = True
        '
        'botonSetPruebas
        '
        Me.botonSetPruebas.Location = New System.Drawing.Point(6, 19)
        Me.botonSetPruebas.Name = "botonSetPruebas"
        Me.botonSetPruebas.Size = New System.Drawing.Size(151, 23)
        Me.botonSetPruebas.TabIndex = 18
        Me.botonSetPruebas.Text = "SET de Pruebas"
        Me.botonSetPruebas.UseVisualStyleBackColor = True
        '
        'botonLibroGuias
        '
        Me.botonLibroGuias.Location = New System.Drawing.Point(6, 222)
        Me.botonLibroGuias.Name = "botonLibroGuias"
        Me.botonLibroGuias.Size = New System.Drawing.Size(151, 23)
        Me.botonLibroGuias.TabIndex = 18
        Me.botonLibroGuias.Text = "Libro de Guías"
        Me.botonLibroGuias.UseVisualStyleBackColor = True
        '
        'botonSetExportacion2
        '
        Me.botonSetExportacion2.Location = New System.Drawing.Point(6, 192)
        Me.botonSetExportacion2.Name = "botonSetExportacion2"
        Me.botonSetExportacion2.Size = New System.Drawing.Size(151, 23)
        Me.botonSetExportacion2.TabIndex = 20
        Me.botonSetExportacion2.Text = "SET de Exportación (2)"
        Me.botonSetExportacion2.UseVisualStyleBackColor = True
        '
        'botonIntercambio
        '
        Me.botonIntercambio.Location = New System.Drawing.Point(6, 105)
        Me.botonIntercambio.Name = "botonIntercambio"
        Me.botonIntercambio.Size = New System.Drawing.Size(151, 23)
        Me.botonIntercambio.TabIndex = 18
        Me.botonIntercambio.Text = "Intercambio"
        Me.botonIntercambio.UseVisualStyleBackColor = True
        '
        'botonCesion
        '
        Me.botonCesion.Location = New System.Drawing.Point(6, 135)
        Me.botonCesion.Name = "botonCesion"
        Me.botonCesion.Size = New System.Drawing.Size(151, 23)
        Me.botonCesion.TabIndex = 19
        Me.botonCesion.Text = "Cesión de Documentos"
        Me.botonCesion.UseVisualStyleBackColor = True
        '
        'botonSimulacion
        '
        Me.botonSimulacion.Location = New System.Drawing.Point(6, 77)
        Me.botonSimulacion.Name = "botonSimulacion"
        Me.botonSimulacion.Size = New System.Drawing.Size(151, 23)
        Me.botonSimulacion.TabIndex = 10
        Me.botonSimulacion.Text = "Simular N Documentos"
        Me.botonSimulacion.UseVisualStyleBackColor = True
        '
        'botonSetExportacion
        '
        Me.botonSetExportacion.Location = New System.Drawing.Point(6, 164)
        Me.botonSetExportacion.Name = "botonSetExportacion"
        Me.botonSetExportacion.Size = New System.Drawing.Size(151, 23)
        Me.botonSetExportacion.TabIndex = 17
        Me.botonSetExportacion.Text = "SET de Exportación (1)"
        Me.botonSetExportacion.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.botonConsultarEstadoEnvio)
        Me.groupBox5.Controls.Add(Me.botonGetCertificados)
        Me.groupBox5.Controls.Add(Me.botonValidador)
        Me.groupBox5.Controls.Add(Me.botonTimbre)
        Me.groupBox5.Controls.Add(Me.botonAceptacion)
        Me.groupBox5.Controls.Add(Me.botonConsultarEstadoDTE)
        Me.groupBox5.Location = New System.Drawing.Point(519, 12)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(163, 197)
        Me.groupBox5.TabIndex = 25
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Utilidades"
        '
        'botonConsultarEstadoEnvio
        '
        Me.botonConsultarEstadoEnvio.Location = New System.Drawing.Point(6, 48)
        Me.botonConsultarEstadoEnvio.Name = "botonConsultarEstadoEnvio"
        Me.botonConsultarEstadoEnvio.Size = New System.Drawing.Size(151, 23)
        Me.botonConsultarEstadoEnvio.TabIndex = 18
        Me.botonConsultarEstadoEnvio.Text = "Consultar Estado Envío"
        Me.botonConsultarEstadoEnvio.UseVisualStyleBackColor = True
        '
        'botonGetCertificados
        '
        Me.botonGetCertificados.Location = New System.Drawing.Point(6, 164)
        Me.botonGetCertificados.Name = "botonGetCertificados"
        Me.botonGetCertificados.Size = New System.Drawing.Size(151, 23)
        Me.botonGetCertificados.TabIndex = 17
        Me.botonGetCertificados.Text = "Certificados Instalados"
        Me.botonGetCertificados.UseVisualStyleBackColor = True
        '
        'botonValidador
        '
        Me.botonValidador.Location = New System.Drawing.Point(6, 135)
        Me.botonValidador.Name = "botonValidador"
        Me.botonValidador.Size = New System.Drawing.Size(151, 23)
        Me.botonValidador.TabIndex = 17
        Me.botonValidador.Text = "Validador"
        Me.botonValidador.UseVisualStyleBackColor = True
        '
        'botonTimbre
        '
        Me.botonTimbre.Location = New System.Drawing.Point(6, 106)
        Me.botonTimbre.Name = "botonTimbre"
        Me.botonTimbre.Size = New System.Drawing.Size(151, 23)
        Me.botonTimbre.TabIndex = 12
        Me.botonTimbre.Text = "Imagen del Timbre"
        Me.botonTimbre.UseVisualStyleBackColor = True
        '
        'botonAceptacion
        '
        Me.botonAceptacion.Location = New System.Drawing.Point(6, 77)
        Me.botonAceptacion.Name = "botonAceptacion"
        Me.botonAceptacion.Size = New System.Drawing.Size(151, 23)
        Me.botonAceptacion.TabIndex = 3
        Me.botonAceptacion.Text = "Enviar Aceptación/Reclamo"
        Me.botonAceptacion.UseVisualStyleBackColor = True
        '
        'botonConsultarEstadoDTE
        '
        Me.botonConsultarEstadoDTE.Location = New System.Drawing.Point(6, 19)
        Me.botonConsultarEstadoDTE.Name = "botonConsultarEstadoDTE"
        Me.botonConsultarEstadoDTE.Size = New System.Drawing.Size(151, 23)
        Me.botonConsultarEstadoDTE.TabIndex = 1
        Me.botonConsultarEstadoDTE.Text = "Consultar Estado DTE"
        Me.botonConsultarEstadoDTE.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.botonGenerarRCOFVacio)
        Me.groupBox2.Controls.Add(Me.botonEnviarAlSIIBoletas_Certificacion)
        Me.groupBox2.Controls.Add(Me.botonEnviarAlSIIBoletas)
        Me.groupBox2.Controls.Add(Me.botonGenerarEnvioBoleta)
        Me.groupBox2.Controls.Add(Me.botonRebajaDocumento)
        Me.groupBox2.Controls.Add(Me.botonAnularDocumento)
        Me.groupBox2.Controls.Add(Me.botonGenerarRCOF)
        Me.groupBox2.Controls.Add(Me.botonGenerarBoleta)
        Me.groupBox2.Location = New System.Drawing.Point(350, 12)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(163, 279)
        Me.groupBox2.TabIndex = 24
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Boletas Electrónicas"
        '
        'botonGenerarRCOFVacio
        '
        Me.botonGenerarRCOFVacio.Location = New System.Drawing.Point(6, 135)
        Me.botonGenerarRCOFVacio.Name = "botonGenerarRCOFVacio"
        Me.botonGenerarRCOFVacio.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarRCOFVacio.TabIndex = 26
        Me.botonGenerarRCOFVacio.Text = "Generar RCOF Vacío"
        Me.botonGenerarRCOFVacio.UseVisualStyleBackColor = True
        '
        'botonEnviarAlSIIBoletas_Certificacion
        '
        Me.botonEnviarAlSIIBoletas_Certificacion.Location = New System.Drawing.Point(6, 222)
        Me.botonEnviarAlSIIBoletas_Certificacion.Name = "botonEnviarAlSIIBoletas_Certificacion"
        Me.botonEnviarAlSIIBoletas_Certificacion.Size = New System.Drawing.Size(151, 42)
        Me.botonEnviarAlSIIBoletas_Certificacion.TabIndex = 25
        Me.botonEnviarAlSIIBoletas_Certificacion.Text = "Enviar al SII (Certificación de Boletas)"
        Me.botonEnviarAlSIIBoletas_Certificacion.UseVisualStyleBackColor = True
        '
        'botonEnviarAlSIIBoletas
        '
        Me.botonEnviarAlSIIBoletas.Location = New System.Drawing.Point(6, 193)
        Me.botonEnviarAlSIIBoletas.Name = "botonEnviarAlSIIBoletas"
        Me.botonEnviarAlSIIBoletas.Size = New System.Drawing.Size(151, 23)
        Me.botonEnviarAlSIIBoletas.TabIndex = 24
        Me.botonEnviarAlSIIBoletas.Text = "Enviar al SII (Boletas)"
        Me.botonEnviarAlSIIBoletas.UseVisualStyleBackColor = True
        '
        'botonGenerarEnvioBoleta
        '
        Me.botonGenerarEnvioBoleta.Location = New System.Drawing.Point(6, 164)
        Me.botonGenerarEnvioBoleta.Name = "botonGenerarEnvioBoleta"
        Me.botonGenerarEnvioBoleta.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarEnvioBoleta.TabIndex = 5
        Me.botonGenerarEnvioBoleta.Text = "Envío para Boletas"
        Me.botonGenerarEnvioBoleta.UseVisualStyleBackColor = True
        '
        'botonRebajaDocumento
        '
        Me.botonRebajaDocumento.Location = New System.Drawing.Point(6, 77)
        Me.botonRebajaDocumento.Name = "botonRebajaDocumento"
        Me.botonRebajaDocumento.Size = New System.Drawing.Size(151, 23)
        Me.botonRebajaDocumento.TabIndex = 4
        Me.botonRebajaDocumento.Text = "Rebajar Documento (NC)"
        Me.botonRebajaDocumento.UseVisualStyleBackColor = True
        '
        'botonAnularDocumento
        '
        Me.botonAnularDocumento.Location = New System.Drawing.Point(6, 48)
        Me.botonAnularDocumento.Name = "botonAnularDocumento"
        Me.botonAnularDocumento.Size = New System.Drawing.Size(151, 23)
        Me.botonAnularDocumento.TabIndex = 3
        Me.botonAnularDocumento.Text = "Anular Documento (NC)"
        Me.botonAnularDocumento.UseVisualStyleBackColor = True
        '
        'botonGenerarRCOF
        '
        Me.botonGenerarRCOF.Location = New System.Drawing.Point(6, 106)
        Me.botonGenerarRCOF.Name = "botonGenerarRCOF"
        Me.botonGenerarRCOF.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarRCOF.TabIndex = 2
        Me.botonGenerarRCOF.Text = "Generar RCOF"
        Me.botonGenerarRCOF.UseVisualStyleBackColor = True
        '
        'botonGenerarBoleta
        '
        Me.botonGenerarBoleta.Location = New System.Drawing.Point(6, 19)
        Me.botonGenerarBoleta.Name = "botonGenerarBoleta"
        Me.botonGenerarBoleta.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarBoleta.TabIndex = 1
        Me.botonGenerarBoleta.Text = "Generar Documento"
        Me.botonGenerarBoleta.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.botonAgregarRef)
        Me.groupBox1.Controls.Add(Me.botonGenerarEnvio)
        Me.groupBox1.Controls.Add(Me.botonGenerarDocumento)
        Me.groupBox1.Controls.Add(Me.botonIngresarTimbraje)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(163, 136)
        Me.groupBox1.TabIndex = 23
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Básicos"
        '
        'botonAgregarRef
        '
        Me.botonAgregarRef.Location = New System.Drawing.Point(6, 77)
        Me.botonAgregarRef.Name = "botonAgregarRef"
        Me.botonAgregarRef.Size = New System.Drawing.Size(151, 23)
        Me.botonAgregarRef.TabIndex = 4
        Me.botonAgregarRef.Text = "Agregar Referencias"
        Me.botonAgregarRef.UseVisualStyleBackColor = True
        '
        'botonGenerarEnvio
        '
        Me.botonGenerarEnvio.Location = New System.Drawing.Point(6, 106)
        Me.botonGenerarEnvio.Name = "botonGenerarEnvio"
        Me.botonGenerarEnvio.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarEnvio.TabIndex = 2
        Me.botonGenerarEnvio.Text = "Generar sobre de Envío"
        Me.botonGenerarEnvio.UseVisualStyleBackColor = True
        '
        'botonGenerarDocumento
        '
        Me.botonGenerarDocumento.Location = New System.Drawing.Point(6, 48)
        Me.botonGenerarDocumento.Name = "botonGenerarDocumento"
        Me.botonGenerarDocumento.Size = New System.Drawing.Size(151, 23)
        Me.botonGenerarDocumento.TabIndex = 1
        Me.botonGenerarDocumento.Text = "Generar Documento"
        Me.botonGenerarDocumento.UseVisualStyleBackColor = True
        '
        'botonIngresarTimbraje
        '
        Me.botonIngresarTimbraje.Location = New System.Drawing.Point(6, 19)
        Me.botonIngresarTimbraje.Name = "botonIngresarTimbraje"
        Me.botonIngresarTimbraje.Size = New System.Drawing.Size(151, 23)
        Me.botonIngresarTimbraje.TabIndex = 0
        Me.botonIngresarTimbraje.Text = "Ingresar Timbraje CAF"
        Me.botonIngresarTimbraje.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 301)
        Me.Controls.Add(Me.botonConfiguracion)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents botonConfiguracion As Button
    Private WithEvents groupBox4 As GroupBox
    Private WithEvents radioCertificacion As RadioButton
    Private WithEvents radioProduccion As RadioButton
    Private WithEvents botonEnviarSii As Button
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents botonFacturaCompra As Button
    Private WithEvents botonMuestraImpresa As Button
    Private WithEvents botonSetPruebas As Button
    Private WithEvents botonLibroGuias As Button
    Private WithEvents botonSetExportacion2 As Button
    Private WithEvents botonIntercambio As Button
    Private WithEvents botonCesion As Button
    Private WithEvents botonSimulacion As Button
    Private WithEvents botonSetExportacion As Button
    Private WithEvents groupBox5 As GroupBox
    Private WithEvents botonConsultarEstadoEnvio As Button
    Private WithEvents botonGetCertificados As Button
    Private WithEvents botonValidador As Button
    Private WithEvents botonTimbre As Button
    Private WithEvents botonAceptacion As Button
    Private WithEvents botonConsultarEstadoDTE As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents botonGenerarRCOFVacio As Button
    Private WithEvents botonEnviarAlSIIBoletas_Certificacion As Button
    Private WithEvents botonEnviarAlSIIBoletas As Button
    Private WithEvents botonGenerarEnvioBoleta As Button
    Private WithEvents botonRebajaDocumento As Button
    Private WithEvents botonAnularDocumento As Button
    Private WithEvents botonGenerarRCOF As Button
    Private WithEvents botonGenerarBoleta As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents botonAgregarRef As Button
    Private WithEvents botonGenerarEnvio As Button
    Private WithEvents botonGenerarDocumento As Button
    Private WithEvents botonIngresarTimbraje As Button
End Class
