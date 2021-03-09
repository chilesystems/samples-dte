<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionSistema
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
        Me.label6 = New System.Windows.Forms.Label()
        Me.textAPIKey = New System.Windows.Forms.TextBox()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.botonAgregarProducto = New System.Windows.Forms.Button()
        Me.gridProductos = New System.Windows.Forms.DataGridView()
        Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.textNombreProducto = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.numericNResolucion = New System.Windows.Forms.NumericUpDown()
        Me.dateFechaResolucion = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.comboCertificados = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.textRutCertificado = New System.Windows.Forms.TextBox()
        Me.botonGuardar = New System.Windows.Forms.Button()
        Me.groupBox12 = New System.Windows.Forms.GroupBox()
        Me.botonGuardarActividad = New System.Windows.Forms.Button()
        Me.gridResultados = New System.Windows.Forms.DataGridView()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.textNumeroActividad = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.label61 = New System.Windows.Forms.Label()
        Me.label56 = New System.Windows.Forms.Label()
        Me.textComuna = New System.Windows.Forms.TextBox()
        Me.textRazonSocial = New System.Windows.Forms.TextBox()
        Me.label57 = New System.Windows.Forms.Label()
        Me.textRutEmpresa = New System.Windows.Forms.TextBox()
        Me.textGiro = New System.Windows.Forms.TextBox()
        Me.label55 = New System.Windows.Forms.Label()
        Me.textDireccionEmpresa = New System.Windows.Forms.TextBox()
        Me.label54 = New System.Windows.Forms.Label()
        Me.groupBox4.SuspendLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        CType(Me.numericNResolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox12.SuspendLayout()
        CType(Me.gridResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(704, 244)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(48, 13)
        Me.label6.TabIndex = 42
        Me.label6.Text = "API Key:"
        '
        'textAPIKey
        '
        Me.textAPIKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textAPIKey.Location = New System.Drawing.Point(758, 241)
        Me.textAPIKey.Name = "textAPIKey"
        Me.textAPIKey.Size = New System.Drawing.Size(154, 20)
        Me.textAPIKey.TabIndex = 41
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.botonAgregarProducto)
        Me.groupBox4.Controls.Add(Me.gridProductos)
        Me.groupBox4.Controls.Add(Me.textNombreProducto)
        Me.groupBox4.Controls.Add(Me.label5)
        Me.groupBox4.Location = New System.Drawing.Point(392, 44)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(309, 314)
        Me.groupBox4.TabIndex = 40
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Productos de Simulación"
        '
        'botonAgregarProducto
        '
        Me.botonAgregarProducto.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.Agregar1
        Me.botonAgregarProducto.Location = New System.Drawing.Point(272, 21)
        Me.botonAgregarProducto.Name = "botonAgregarProducto"
        Me.botonAgregarProducto.Size = New System.Drawing.Size(31, 23)
        Me.botonAgregarProducto.TabIndex = 6
        Me.botonAgregarProducto.UseVisualStyleBackColor = True
        '
        'gridProductos
        '
        Me.gridProductos.AllowUserToAddRows = False
        Me.gridProductos.AllowUserToDeleteRows = False
        Me.gridProductos.AllowUserToResizeColumns = False
        Me.gridProductos.AllowUserToResizeRows = False
        Me.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn1, Me.dataGridViewImageColumn2})
        Me.gridProductos.Location = New System.Drawing.Point(11, 52)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.ReadOnly = True
        Me.gridProductos.RowHeadersWidth = 25
        Me.gridProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridProductos.Size = New System.Drawing.Size(292, 256)
        Me.gridProductos.TabIndex = 5
        '
        'dataGridViewTextBoxColumn1
        '
        Me.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre"
        Me.dataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
        Me.dataGridViewTextBoxColumn1.ReadOnly = True
        Me.dataGridViewTextBoxColumn1.Width = 205
        '
        'dataGridViewImageColumn2
        '
        Me.dataGridViewImageColumn2.HeaderText = ""
        Me.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2"
        Me.dataGridViewImageColumn2.ReadOnly = True
        Me.dataGridViewImageColumn2.Width = 35
        '
        'textNombreProducto
        '
        Me.textNombreProducto.Location = New System.Drawing.Point(61, 23)
        Me.textNombreProducto.Name = "textNombreProducto"
        Me.textNombreProducto.Size = New System.Drawing.Size(205, 20)
        Me.textNombreProducto.TabIndex = 3
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(8, 27)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(47, 13)
        Me.label5.TabIndex = 2
        Me.label5.Text = "Nombre:"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.numericNResolucion)
        Me.groupBox2.Controls.Add(Me.dateFechaResolucion)
        Me.groupBox2.Controls.Add(Me.label1)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Location = New System.Drawing.Point(34, 280)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(352, 78)
        Me.groupBox2.TabIndex = 39
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Resolución"
        '
        'numericNResolucion
        '
        Me.numericNResolucion.Location = New System.Drawing.Point(118, 20)
        Me.numericNResolucion.Name = "numericNResolucion"
        Me.numericNResolucion.Size = New System.Drawing.Size(48, 20)
        Me.numericNResolucion.TabIndex = 35
        '
        'dateFechaResolucion
        '
        Me.dateFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFechaResolucion.Location = New System.Drawing.Point(118, 45)
        Me.dateFechaResolucion.Name = "dateFechaResolucion"
        Me.dateFechaResolucion.Size = New System.Drawing.Size(112, 20)
        Me.dateFechaResolucion.TabIndex = 34
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(78, 13)
        Me.label1.TabIndex = 32
        Me.label1.Text = "N° Resolución:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(9, 48)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(96, 13)
        Me.label4.TabIndex = 30
        Me.label4.Text = "Fecha Resolución:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.comboCertificados)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.textRutCertificado)
        Me.groupBox1.Location = New System.Drawing.Point(34, 196)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(352, 78)
        Me.groupBox1.TabIndex = 36
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos Certificado"
        '
        'comboCertificados
        '
        Me.comboCertificados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboCertificados.FormattingEnabled = True
        Me.comboCertificados.Location = New System.Drawing.Point(118, 45)
        Me.comboCertificados.Name = "comboCertificados"
        Me.comboCertificados.Size = New System.Drawing.Size(226, 21)
        Me.comboCertificados.TabIndex = 34
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 22)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(33, 13)
        Me.label2.TabIndex = 32
        Me.label2.Text = "RUT:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(9, 48)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(103, 13)
        Me.label3.TabIndex = 30
        Me.label3.Text = "Nombre Descriptivo:"
        '
        'textRutCertificado
        '
        Me.textRutCertificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textRutCertificado.Location = New System.Drawing.Point(118, 19)
        Me.textRutCertificado.Name = "textRutCertificado"
        Me.textRutCertificado.Size = New System.Drawing.Size(112, 20)
        Me.textRutCertificado.TabIndex = 33
        '
        'botonGuardar
        '
        Me.botonGuardar.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.Guardar
        Me.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.botonGuardar.Location = New System.Drawing.Point(833, 318)
        Me.botonGuardar.Name = "botonGuardar"
        Me.botonGuardar.Size = New System.Drawing.Size(79, 33)
        Me.botonGuardar.TabIndex = 38
        Me.botonGuardar.Text = "Guardar"
        Me.botonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.botonGuardar.UseVisualStyleBackColor = True
        '
        'groupBox12
        '
        Me.groupBox12.Controls.Add(Me.botonGuardarActividad)
        Me.groupBox12.Controls.Add(Me.gridResultados)
        Me.groupBox12.Controls.Add(Me.textNumeroActividad)
        Me.groupBox12.Controls.Add(Me.label17)
        Me.groupBox12.Location = New System.Drawing.Point(707, 44)
        Me.groupBox12.Name = "groupBox12"
        Me.groupBox12.Size = New System.Drawing.Size(205, 187)
        Me.groupBox12.TabIndex = 37
        Me.groupBox12.TabStop = False
        Me.groupBox12.Text = "Actividades Económicas"
        '
        'botonGuardarActividad
        '
        Me.botonGuardarActividad.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.Agregar1
        Me.botonGuardarActividad.Location = New System.Drawing.Point(164, 22)
        Me.botonGuardarActividad.Name = "botonGuardarActividad"
        Me.botonGuardarActividad.Size = New System.Drawing.Size(31, 23)
        Me.botonGuardarActividad.TabIndex = 6
        Me.botonGuardarActividad.UseVisualStyleBackColor = True
        '
        'gridResultados
        '
        Me.gridResultados.AllowUserToAddRows = False
        Me.gridResultados.AllowUserToDeleteRows = False
        Me.gridResultados.AllowUserToResizeColumns = False
        Me.gridResultados.AllowUserToResizeRows = False
        Me.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridResultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.Eliminar})
        Me.gridResultados.Location = New System.Drawing.Point(11, 52)
        Me.gridResultados.Name = "gridResultados"
        Me.gridResultados.ReadOnly = True
        Me.gridResultados.RowHeadersWidth = 25
        Me.gridResultados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridResultados.Size = New System.Drawing.Size(184, 129)
        Me.gridResultados.TabIndex = 5
        '
        'Numero
        '
        Me.Numero.DataPropertyName = "Codigo"
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        Me.Eliminar.Width = 35
        '
        'textNumeroActividad
        '
        Me.textNumeroActividad.Location = New System.Drawing.Point(61, 23)
        Me.textNumeroActividad.Name = "textNumeroActividad"
        Me.textNumeroActividad.Size = New System.Drawing.Size(97, 20)
        Me.textNumeroActividad.TabIndex = 3
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(8, 27)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(47, 13)
        Me.label17.TabIndex = 2
        Me.label17.Text = "Número:"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label61)
        Me.groupBox3.Controls.Add(Me.label56)
        Me.groupBox3.Controls.Add(Me.textComuna)
        Me.groupBox3.Controls.Add(Me.textRazonSocial)
        Me.groupBox3.Controls.Add(Me.label57)
        Me.groupBox3.Controls.Add(Me.textRutEmpresa)
        Me.groupBox3.Controls.Add(Me.textGiro)
        Me.groupBox3.Controls.Add(Me.label55)
        Me.groupBox3.Controls.Add(Me.textDireccionEmpresa)
        Me.groupBox3.Controls.Add(Me.label54)
        Me.groupBox3.Location = New System.Drawing.Point(34, 39)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(352, 151)
        Me.groupBox3.TabIndex = 35
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Datos Empresa"
        '
        'label61
        '
        Me.label61.AutoSize = True
        Me.label61.Location = New System.Drawing.Point(9, 100)
        Me.label61.Name = "label61"
        Me.label61.Size = New System.Drawing.Size(49, 13)
        Me.label61.TabIndex = 44
        Me.label61.Text = "Comuna:"
        '
        'label56
        '
        Me.label56.AutoSize = True
        Me.label56.Location = New System.Drawing.Point(9, 22)
        Me.label56.Name = "label56"
        Me.label56.Size = New System.Drawing.Size(33, 13)
        Me.label56.TabIndex = 32
        Me.label56.Text = "RUT:"
        '
        'textComuna
        '
        Me.textComuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textComuna.Location = New System.Drawing.Point(118, 97)
        Me.textComuna.Name = "textComuna"
        Me.textComuna.Size = New System.Drawing.Size(87, 20)
        Me.textComuna.TabIndex = 30
        '
        'textRazonSocial
        '
        Me.textRazonSocial.Location = New System.Drawing.Point(118, 45)
        Me.textRazonSocial.Name = "textRazonSocial"
        Me.textRazonSocial.Size = New System.Drawing.Size(226, 20)
        Me.textRazonSocial.TabIndex = 10
        '
        'label57
        '
        Me.label57.AutoSize = True
        Me.label57.Location = New System.Drawing.Point(9, 48)
        Me.label57.Name = "label57"
        Me.label57.Size = New System.Drawing.Size(73, 13)
        Me.label57.TabIndex = 30
        Me.label57.Text = "Razón Social:"
        '
        'textRutEmpresa
        '
        Me.textRutEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textRutEmpresa.Location = New System.Drawing.Point(118, 19)
        Me.textRutEmpresa.Name = "textRutEmpresa"
        Me.textRutEmpresa.Size = New System.Drawing.Size(87, 20)
        Me.textRutEmpresa.TabIndex = 0
        '
        'textGiro
        '
        Me.textGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textGiro.Location = New System.Drawing.Point(118, 71)
        Me.textGiro.Name = "textGiro"
        Me.textGiro.Size = New System.Drawing.Size(226, 20)
        Me.textGiro.TabIndex = 20
        '
        'label55
        '
        Me.label55.AutoSize = True
        Me.label55.Location = New System.Drawing.Point(9, 74)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(78, 13)
        Me.label55.TabIndex = 34
        Me.label55.Text = "Giro Comercial:"
        '
        'textDireccionEmpresa
        '
        Me.textDireccionEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDireccionEmpresa.Location = New System.Drawing.Point(118, 123)
        Me.textDireccionEmpresa.Name = "textDireccionEmpresa"
        Me.textDireccionEmpresa.Size = New System.Drawing.Size(226, 20)
        Me.textDireccionEmpresa.TabIndex = 40
        '
        'label54
        '
        Me.label54.AutoSize = True
        Me.label54.Location = New System.Drawing.Point(9, 126)
        Me.label54.Name = "label54"
        Me.label54.Size = New System.Drawing.Size(55, 13)
        Me.label54.TabIndex = 36
        Me.label54.Text = "Dirección:"
        '
        'ConfiguracionSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 396)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.textAPIKey)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.botonGuardar)
        Me.Controls.Add(Me.groupBox12)
        Me.Controls.Add(Me.groupBox3)
        Me.Name = "ConfiguracionSistema"
        Me.Text = "Configuración"
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.numericNResolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox12.ResumeLayout(False)
        Me.groupBox12.PerformLayout()
        CType(Me.gridResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents label6 As Label
    Private WithEvents textAPIKey As TextBox
    Private WithEvents groupBox4 As GroupBox
    Private WithEvents botonAgregarProducto As Button
    Private WithEvents gridProductos As DataGridView
    Private WithEvents dataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Private WithEvents dataGridViewImageColumn2 As DataGridViewImageColumn
    Private WithEvents textNombreProducto As TextBox
    Private WithEvents label5 As Label
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents numericNResolucion As NumericUpDown
    Private WithEvents dateFechaResolucion As DateTimePicker
    Private WithEvents label1 As Label
    Private WithEvents label4 As Label
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents comboCertificados As ComboBox
    Private WithEvents label2 As Label
    Private WithEvents label3 As Label
    Private WithEvents textRutCertificado As TextBox
    Private WithEvents botonGuardar As Button
    Private WithEvents groupBox12 As GroupBox
    Private WithEvents botonGuardarActividad As Button
    Private WithEvents gridResultados As DataGridView
    Private WithEvents Numero As DataGridViewTextBoxColumn
    Private WithEvents Eliminar As DataGridViewImageColumn
    Private WithEvents textNumeroActividad As TextBox
    Private WithEvents label17 As Label
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents label61 As Label
    Private WithEvents label56 As Label
    Private WithEvents textComuna As TextBox
    Private WithEvents textRazonSocial As TextBox
    Private WithEvents label57 As Label
    Private WithEvents textRutEmpresa As TextBox
    Private WithEvents textGiro As TextBox
    Private WithEvents label55 As Label
    Private WithEvents textDireccionEmpresa As TextBox
    Private WithEvents label54 As Label
End Class
