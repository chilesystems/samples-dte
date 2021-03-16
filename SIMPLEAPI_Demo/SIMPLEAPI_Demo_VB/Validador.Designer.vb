<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Validador
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
        Me.textDocumento = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.textResultado = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.comboTipo = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.botonBuscar = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textDocumento
        '
        Me.textDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.textDocumento.Location = New System.Drawing.Point(96, 108)
        Me.textDocumento.Name = "textDocumento"
        Me.textDocumento.ReadOnly = True
        Me.textDocumento.Size = New System.Drawing.Size(303, 20)
        Me.textDocumento.TabIndex = 43
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(25, 111)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(65, 13)
        Me.label4.TabIndex = 42
        Me.label4.Text = "Documento:"
        '
        'textResultado
        '
        Me.textResultado.BackColor = System.Drawing.SystemColors.Info
        Me.textResultado.Location = New System.Drawing.Point(96, 134)
        Me.textResultado.Multiline = True
        Me.textResultado.Name = "textResultado"
        Me.textResultado.ReadOnly = True
        Me.textResultado.Size = New System.Drawing.Size(303, 201)
        Me.textResultado.TabIndex = 41
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(25, 137)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 40
        Me.label1.Text = "Resultado:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.comboTipo)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.botonBuscar)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.txtFilePath)
        Me.groupBox1.Location = New System.Drawing.Point(23, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(376, 90)
        Me.groupBox1.TabIndex = 39
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Lectura"
        '
        'comboTipo
        '
        Me.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboTipo.FormattingEnabled = True
        Me.comboTipo.Items.AddRange(New Object() {"DTE", "SOBREENVIO", "ENVIOBOLETA", "IECV", "CONSUMOFOLIOS", "LIBROBOLETA"})
        Me.comboTipo.Location = New System.Drawing.Point(79, 56)
        Me.comboTipo.Name = "comboTipo"
        Me.comboTipo.Size = New System.Drawing.Size(131, 21)
        Me.comboTipo.TabIndex = 5
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 56)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(31, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Tipo:"
        '
        'botonBuscar
        '
        Me.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonBuscar.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.View
        Me.botonBuscar.Location = New System.Drawing.Point(341, 27)
        Me.botonBuscar.Name = "botonBuscar"
        Me.botonBuscar.Size = New System.Drawing.Size(29, 20)
        Me.botonBuscar.TabIndex = 2
        Me.botonBuscar.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(15, 30)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(33, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Ruta:"
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(79, 27)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(256, 20)
        Me.txtFilePath.TabIndex = 0
        '
        'Validador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 377)
        Me.Controls.Add(Me.textDocumento)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.textResultado)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Validador"
        Me.Text = "Validador"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents textDocumento As TextBox
    Private WithEvents label4 As Label
    Private WithEvents textResultado As TextBox
    Private WithEvents label1 As Label
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents comboTipo As ComboBox
    Private WithEvents label3 As Label
    Private WithEvents botonBuscar As Button
    Private WithEvents label2 As Label
    Private WithEvents txtFilePath As TextBox
End Class
