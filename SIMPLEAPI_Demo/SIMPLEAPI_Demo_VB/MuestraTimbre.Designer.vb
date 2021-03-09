<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MuestraTimbre
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
        Me.botonValidar = New System.Windows.Forms.Button()
        Me.botonCargarDTE = New System.Windows.Forms.Button()
        Me.pictureBoxTimbre = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBoxTimbre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'botonValidar
        '
        Me.botonValidar.Location = New System.Drawing.Point(334, 18)
        Me.botonValidar.Name = "botonValidar"
        Me.botonValidar.Size = New System.Drawing.Size(105, 23)
        Me.botonValidar.TabIndex = 7
        Me.botonValidar.Text = "Validar Timbre"
        Me.botonValidar.UseVisualStyleBackColor = True
        '
        'botonCargarDTE
        '
        Me.botonCargarDTE.Location = New System.Drawing.Point(253, 18)
        Me.botonCargarDTE.Name = "botonCargarDTE"
        Me.botonCargarDTE.Size = New System.Drawing.Size(75, 23)
        Me.botonCargarDTE.TabIndex = 6
        Me.botonCargarDTE.Text = "Cargar DTE"
        Me.botonCargarDTE.UseVisualStyleBackColor = True
        '
        'pictureBoxTimbre
        '
        Me.pictureBoxTimbre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictureBoxTimbre.Location = New System.Drawing.Point(29, 64)
        Me.pictureBoxTimbre.Name = "pictureBoxTimbre"
        Me.pictureBoxTimbre.Size = New System.Drawing.Size(414, 170)
        Me.pictureBoxTimbre.TabIndex = 5
        Me.pictureBoxTimbre.TabStop = False
        '
        'MuestraTimbre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 273)
        Me.Controls.Add(Me.botonValidar)
        Me.Controls.Add(Me.botonCargarDTE)
        Me.Controls.Add(Me.pictureBoxTimbre)
        Me.Name = "MuestraTimbre"
        Me.Text = "MuestraTimbre"
        CType(Me.pictureBoxTimbre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents botonValidar As Button
    Private WithEvents botonCargarDTE As Button
    Private WithEvents pictureBoxTimbre As PictureBox
End Class
