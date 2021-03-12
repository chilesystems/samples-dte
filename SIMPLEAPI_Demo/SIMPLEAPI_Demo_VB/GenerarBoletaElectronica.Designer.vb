<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarBoletaElectronica
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.numericFolio = New System.Windows.Forms.NumericUpDown()
        Me.label5 = New System.Windows.Forms.Label()
        Me.botonGenerar = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.checkUnidad = New System.Windows.Forms.CheckBox()
        Me.numericPrecio = New System.Windows.Forms.NumericUpDown()
        Me.label4 = New System.Windows.Forms.Label()
        Me.botonAgregarLinea = New System.Windows.Forms.Button()
        Me.checkAfecto = New System.Windows.Forms.CheckBox()
        Me.numericCantidad = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New System.Windows.Forms.Label()
        Me.textNombre = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.gridResultados = New System.Windows.Forms.DataGridView()
        Me.gridNombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridCantidadProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridAfecto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.umedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridEliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.numericCasoPrueba = New System.Windows.Forms.NumericUpDown()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.numericFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        CType(Me.numericPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.gridResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericCasoPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numericFolio
        '
        Me.numericFolio.Location = New System.Drawing.Point(205, 14)
        Me.numericFolio.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numericFolio.Name = "numericFolio"
        Me.numericFolio.Size = New System.Drawing.Size(45, 20)
        Me.numericFolio.TabIndex = 20
        Me.numericFolio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(167, 17)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(32, 13)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Folio:"
        '
        'botonGenerar
        '
        Me.botonGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.botonGenerar.Location = New System.Drawing.Point(478, 278)
        Me.botonGenerar.Name = "botonGenerar"
        Me.botonGenerar.Size = New System.Drawing.Size(120, 38)
        Me.botonGenerar.TabIndex = 18
        Me.botonGenerar.Text = "Generar boleta"
        Me.botonGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.botonGenerar.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.checkUnidad)
        Me.groupBox2.Controls.Add(Me.numericPrecio)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.botonAgregarLinea)
        Me.groupBox2.Controls.Add(Me.checkAfecto)
        Me.groupBox2.Controls.Add(Me.numericCantidad)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.textNombre)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(21, 40)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(577, 59)
        Me.groupBox2.TabIndex = 17
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Nuevo Producto"
        '
        'checkUnidad
        '
        Me.checkUnidad.AutoSize = True
        Me.checkUnidad.Location = New System.Drawing.Point(462, 27)
        Me.checkUnidad.Name = "checkUnidad"
        Me.checkUnidad.Size = New System.Drawing.Size(60, 17)
        Me.checkUnidad.TabIndex = 16
        Me.checkUnidad.Text = "Unidad"
        Me.checkUnidad.UseVisualStyleBackColor = True
        '
        'numericPrecio
        '
        Me.numericPrecio.Location = New System.Drawing.Point(338, 26)
        Me.numericPrecio.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numericPrecio.Name = "numericPrecio"
        Me.numericPrecio.Size = New System.Drawing.Size(55, 20)
        Me.numericPrecio.TabIndex = 9
        Me.numericPrecio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(293, 28)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(40, 13)
        Me.label4.TabIndex = 8
        Me.label4.Text = "Precio:"
        '
        'botonAgregarLinea
        '
        Me.botonAgregarLinea.Location = New System.Drawing.Point(532, 19)
        Me.botonAgregarLinea.Name = "botonAgregarLinea"
        Me.botonAgregarLinea.Size = New System.Drawing.Size(39, 30)
        Me.botonAgregarLinea.TabIndex = 15
        Me.botonAgregarLinea.Text = " + "
        Me.botonAgregarLinea.UseVisualStyleBackColor = True
        '
        'checkAfecto
        '
        Me.checkAfecto.AutoSize = True
        Me.checkAfecto.Checked = True
        Me.checkAfecto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkAfecto.Location = New System.Drawing.Point(399, 27)
        Me.checkAfecto.Name = "checkAfecto"
        Me.checkAfecto.Size = New System.Drawing.Size(57, 17)
        Me.checkAfecto.TabIndex = 12
        Me.checkAfecto.Text = "Afecto"
        Me.checkAfecto.UseVisualStyleBackColor = True
        '
        'numericCantidad
        '
        Me.numericCantidad.DecimalPlaces = 1
        Me.numericCantidad.Location = New System.Drawing.Point(242, 25)
        Me.numericCantidad.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numericCantidad.Name = "numericCantidad"
        Me.numericCantidad.Size = New System.Drawing.Size(45, 20)
        Me.numericCantidad.TabIndex = 5
        Me.numericCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(184, 28)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(52, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Cantidad:"
        '
        'textNombre
        '
        Me.textNombre.Location = New System.Drawing.Point(59, 25)
        Me.textNombre.Name = "textNombre"
        Me.textNombre.Size = New System.Drawing.Size(119, 20)
        Me.textNombre.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(47, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Nombre:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.gridResultados)
        Me.groupBox1.Location = New System.Drawing.Point(21, 105)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(577, 170)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Productos"
        '
        'gridResultados
        '
        Me.gridResultados.AllowUserToAddRows = False
        Me.gridResultados.AllowUserToDeleteRows = False
        Me.gridResultados.AllowUserToResizeColumns = False
        Me.gridResultados.AllowUserToResizeRows = False
        Me.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridResultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gridNombreProducto, Me.gridCantidadProducto, Me.gridPrecio, Me.gridTotal, Me.gridAfecto, Me.umedida, Me.gridEliminar})
        Me.gridResultados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResultados.Location = New System.Drawing.Point(3, 16)
        Me.gridResultados.Name = "gridResultados"
        Me.gridResultados.ReadOnly = True
        Me.gridResultados.RowHeadersWidth = 25
        Me.gridResultados.Size = New System.Drawing.Size(571, 151)
        Me.gridResultados.TabIndex = 0
        '
        'gridNombreProducto
        '
        Me.gridNombreProducto.DataPropertyName = "Nombre"
        Me.gridNombreProducto.HeaderText = "Nombre"
        Me.gridNombreProducto.Name = "gridNombreProducto"
        Me.gridNombreProducto.ReadOnly = True
        Me.gridNombreProducto.Width = 200
        '
        'gridCantidadProducto
        '
        Me.gridCantidadProducto.DataPropertyName = "Cantidad"
        DataGridViewCellStyle10.Format = "N1"
        Me.gridCantidadProducto.DefaultCellStyle = DataGridViewCellStyle10
        Me.gridCantidadProducto.HeaderText = "Cantidad"
        Me.gridCantidadProducto.Name = "gridCantidadProducto"
        Me.gridCantidadProducto.ReadOnly = True
        Me.gridCantidadProducto.Width = 55
        '
        'gridPrecio
        '
        Me.gridPrecio.DataPropertyName = "Precio"
        DataGridViewCellStyle11.Format = "N0"
        Me.gridPrecio.DefaultCellStyle = DataGridViewCellStyle11
        Me.gridPrecio.HeaderText = "Precio"
        Me.gridPrecio.Name = "gridPrecio"
        Me.gridPrecio.ReadOnly = True
        Me.gridPrecio.Width = 65
        '
        'gridTotal
        '
        Me.gridTotal.DataPropertyName = "Total"
        DataGridViewCellStyle12.Format = "N0"
        Me.gridTotal.DefaultCellStyle = DataGridViewCellStyle12
        Me.gridTotal.HeaderText = "Total"
        Me.gridTotal.Name = "gridTotal"
        Me.gridTotal.ReadOnly = True
        Me.gridTotal.Width = 70
        '
        'gridAfecto
        '
        Me.gridAfecto.DataPropertyName = "Afecto"
        Me.gridAfecto.HeaderText = "Afecto"
        Me.gridAfecto.Name = "gridAfecto"
        Me.gridAfecto.ReadOnly = True
        Me.gridAfecto.Width = 45
        '
        'umedida
        '
        Me.umedida.DataPropertyName = "UnidadMedida"
        Me.umedida.HeaderText = "Unidad"
        Me.umedida.Name = "umedida"
        Me.umedida.ReadOnly = True
        Me.umedida.Width = 45
        '
        'gridEliminar
        '
        Me.gridEliminar.HeaderText = "Elim."
        Me.gridEliminar.Name = "gridEliminar"
        Me.gridEliminar.ReadOnly = True
        Me.gridEliminar.Width = 40
        '
        'numericCasoPrueba
        '
        Me.numericCasoPrueba.Location = New System.Drawing.Point(116, 14)
        Me.numericCasoPrueba.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numericCasoPrueba.Name = "numericCasoPrueba"
        Me.numericCasoPrueba.Size = New System.Drawing.Size(45, 20)
        Me.numericCasoPrueba.TabIndex = 15
        Me.numericCasoPrueba.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(25, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(85, 13)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Caso de prueba:"
        '
        'GenerarBoletaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 340)
        Me.Controls.Add(Me.numericFolio)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.botonGenerar)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.numericCasoPrueba)
        Me.Controls.Add(Me.label1)
        Me.Name = "GenerarBoletaElectronica"
        Me.Text = "GenerarBoletaElectronica"
        CType(Me.numericFolio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.numericPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        CType(Me.gridResultados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericCasoPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents numericFolio As NumericUpDown
    Private WithEvents label5 As Label
    Private WithEvents botonGenerar As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents checkUnidad As CheckBox
    Private WithEvents numericPrecio As NumericUpDown
    Private WithEvents label4 As Label
    Private WithEvents botonAgregarLinea As Button
    Private WithEvents checkAfecto As CheckBox
    Private WithEvents numericCantidad As NumericUpDown
    Private WithEvents label3 As Label
    Private WithEvents textNombre As TextBox
    Private WithEvents label2 As Label
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents gridResultados As DataGridView
    Private WithEvents gridNombreProducto As DataGridViewTextBoxColumn
    Private WithEvents gridCantidadProducto As DataGridViewTextBoxColumn
    Private WithEvents gridPrecio As DataGridViewTextBoxColumn
    Private WithEvents gridTotal As DataGridViewTextBoxColumn
    Private WithEvents gridAfecto As DataGridViewCheckBoxColumn
    Private WithEvents umedida As DataGridViewTextBoxColumn
    Private WithEvents gridEliminar As DataGridViewImageColumn
    Private WithEvents numericCasoPrueba As NumericUpDown
    Private WithEvents label1 As Label
End Class
