<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresarTimbraje
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
        Me.textTipoCAF = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.botonGuardar = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.textRango = New System.Windows.Forms.TextBox()
        Me.textFecha = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.botonBuscar = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textTipoCAF
        '
        Me.textTipoCAF.Location = New System.Drawing.Point(66, 97)
        Me.textTipoCAF.Name = "textTipoCAF"
        Me.textTipoCAF.Size = New System.Drawing.Size(307, 20)
        Me.textTipoCAF.TabIndex = 34
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(20, 100)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(31, 13)
        Me.label4.TabIndex = 33
        Me.label4.Text = "Tipo:"
        '
        'botonGuardar
        '
        Me.botonGuardar.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.Guardar_32
        Me.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.botonGuardar.Location = New System.Drawing.Point(282, 149)
        Me.botonGuardar.Name = "botonGuardar"
        Me.botonGuardar.Size = New System.Drawing.Size(91, 37)
        Me.botonGuardar.TabIndex = 32
        Me.botonGuardar.Text = "Guardar"
        Me.botonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.botonGuardar.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(172, 126)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(95, 13)
        Me.label3.TabIndex = 31
        Me.label3.Text = "Rango Autorizado:"
        '
        'textRango
        '
        Me.textRango.Location = New System.Drawing.Point(273, 123)
        Me.textRango.Name = "textRango"
        Me.textRango.Size = New System.Drawing.Size(100, 20)
        Me.textRango.TabIndex = 30
        '
        'textFecha
        '
        Me.textFecha.Location = New System.Drawing.Point(66, 123)
        Me.textFecha.Name = "textFecha"
        Me.textFecha.Size = New System.Drawing.Size(100, 20)
        Me.textFecha.TabIndex = 29
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(20, 126)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(40, 13)
        Me.label2.TabIndex = 28
        Me.label2.Text = "Fecha:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.botonBuscar)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.txtFilePath)
        Me.groupBox1.Location = New System.Drawing.Point(12, 23)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(361, 64)
        Me.groupBox1.TabIndex = 27
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Lectura"
        '
        'botonBuscar
        '
        Me.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonBuscar.Image = Global.SIMPLEAPI_Demo_VB.My.Resources.Resources.View
        Me.botonBuscar.Location = New System.Drawing.Point(326, 27)
        Me.botonBuscar.Name = "botonBuscar"
        Me.botonBuscar.Size = New System.Drawing.Size(29, 20)
        Me.botonBuscar.TabIndex = 2
        Me.botonBuscar.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 30)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Ruta:"
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(54, 27)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(266, 20)
        Me.txtFilePath.TabIndex = 0
        '
        'IngresarTimbraje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 218)
        Me.Controls.Add(Me.textTipoCAF)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.botonGuardar)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.textRango)
        Me.Controls.Add(Me.textFecha)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "IngresarTimbraje"
        Me.Text = "IngresarTimbraje"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents textTipoCAF As TextBox
    Private WithEvents label4 As Label
    Private WithEvents botonGuardar As Button
    Private WithEvents label3 As Label
    Private WithEvents textRango As TextBox
    Private WithEvents textFecha As TextBox
    Private WithEvents label2 As Label
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents botonBuscar As Button
    Private WithEvents label1 As Label
    Private WithEvents txtFilePath As TextBox
End Class
