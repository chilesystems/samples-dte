namespace SIMPLEAPI_Demo
{
    partial class ConfiguracionSistema
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericNResolucion = new System.Windows.Forms.NumericUpDown();
            this.dateFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboCertificados = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textRutCertificado = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.botonGuardarActividad = new System.Windows.Forms.Button();
            this.gridResultados = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.textNumeroActividad = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.textComuna = new System.Windows.Forms.TextBox();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.textRutEmpresa = new System.Windows.Forms.TextBox();
            this.textGiro = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textDireccionEmpresa = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.botonAgregarProducto = new System.Windows.Forms.Button();
            this.gridProductos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.textNombreProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAPIKey = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNResolucion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericNResolucion);
            this.groupBox2.Controls.Add(this.dateFechaResolucion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 78);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resolución";
            // 
            // numericNResolucion
            // 
            this.numericNResolucion.Location = new System.Drawing.Point(118, 20);
            this.numericNResolucion.Name = "numericNResolucion";
            this.numericNResolucion.Size = new System.Drawing.Size(48, 20);
            this.numericNResolucion.TabIndex = 35;
            // 
            // dateFechaResolucion
            // 
            this.dateFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaResolucion.Location = new System.Drawing.Point(118, 45);
            this.dateFechaResolucion.Name = "dateFechaResolucion";
            this.dateFechaResolucion.Size = new System.Drawing.Size(112, 20);
            this.dateFechaResolucion.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "N° Resolución:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Fecha Resolución:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboCertificados);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textRutCertificado);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 78);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Certificado";
            // 
            // comboCertificados
            // 
            this.comboCertificados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCertificados.FormattingEnabled = true;
            this.comboCertificados.Location = new System.Drawing.Point(118, 45);
            this.comboCertificados.Name = "comboCertificados";
            this.comboCertificados.Size = new System.Drawing.Size(226, 21);
            this.comboCertificados.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "RUT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nombre Descriptivo:";
            // 
            // textRutCertificado
            // 
            this.textRutCertificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textRutCertificado.Location = new System.Drawing.Point(118, 19);
            this.textRutCertificado.Name = "textRutCertificado";
            this.textRutCertificado.Size = new System.Drawing.Size(112, 20);
            this.textRutCertificado.TabIndex = 33;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.botonGuardarActividad);
            this.groupBox12.Controls.Add(this.gridResultados);
            this.groupBox12.Controls.Add(this.textNumeroActividad);
            this.groupBox12.Controls.Add(this.label17);
            this.groupBox12.Location = new System.Drawing.Point(685, 17);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(205, 187);
            this.groupBox12.TabIndex = 9;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Actividades Económicas";
            // 
            // botonGuardarActividad
            // 
            this.botonGuardarActividad.Image = global::SIMPLEAPI_Demo.Properties.Resources.Agregar1;
            this.botonGuardarActividad.Location = new System.Drawing.Point(164, 22);
            this.botonGuardarActividad.Name = "botonGuardarActividad";
            this.botonGuardarActividad.Size = new System.Drawing.Size(31, 23);
            this.botonGuardarActividad.TabIndex = 6;
            this.botonGuardarActividad.UseVisualStyleBackColor = true;
            this.botonGuardarActividad.Click += new System.EventHandler(this.botonGuardarActividad_Click);
            // 
            // gridResultados
            // 
            this.gridResultados.AllowUserToAddRows = false;
            this.gridResultados.AllowUserToDeleteRows = false;
            this.gridResultados.AllowUserToResizeColumns = false;
            this.gridResultados.AllowUserToResizeRows = false;
            this.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Eliminar});
            this.gridResultados.Location = new System.Drawing.Point(11, 52);
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.ReadOnly = true;
            this.gridResultados.RowHeadersWidth = 25;
            this.gridResultados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridResultados.Size = new System.Drawing.Size(184, 129);
            this.gridResultados.TabIndex = 5;
            this.gridResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResultados_CellContentClick);
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Codigo";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::SIMPLEAPI_Demo.Properties.Resources.Eliminar;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 35;
            // 
            // textNumeroActividad
            // 
            this.textNumeroActividad.Location = new System.Drawing.Point(61, 23);
            this.textNumeroActividad.Name = "textNumeroActividad";
            this.textNumeroActividad.Size = new System.Drawing.Size(97, 20);
            this.textNumeroActividad.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Número:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label61);
            this.groupBox3.Controls.Add(this.label56);
            this.groupBox3.Controls.Add(this.textComuna);
            this.groupBox3.Controls.Add(this.textRazonSocial);
            this.groupBox3.Controls.Add(this.label57);
            this.groupBox3.Controls.Add(this.textRutEmpresa);
            this.groupBox3.Controls.Add(this.textGiro);
            this.groupBox3.Controls.Add(this.label55);
            this.groupBox3.Controls.Add(this.textDireccionEmpresa);
            this.groupBox3.Controls.Add(this.label54);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 151);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Empresa";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(9, 100);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(49, 13);
            this.label61.TabIndex = 44;
            this.label61.Text = "Comuna:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(9, 22);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(33, 13);
            this.label56.TabIndex = 32;
            this.label56.Text = "RUT:";
            // 
            // textComuna
            // 
            this.textComuna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textComuna.Location = new System.Drawing.Point(118, 97);
            this.textComuna.Name = "textComuna";
            this.textComuna.Size = new System.Drawing.Size(87, 20);
            this.textComuna.TabIndex = 30;
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(118, 45);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(226, 20);
            this.textRazonSocial.TabIndex = 10;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 48);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(73, 13);
            this.label57.TabIndex = 30;
            this.label57.Text = "Razón Social:";
            // 
            // textRutEmpresa
            // 
            this.textRutEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textRutEmpresa.Location = new System.Drawing.Point(118, 19);
            this.textRutEmpresa.Name = "textRutEmpresa";
            this.textRutEmpresa.Size = new System.Drawing.Size(87, 20);
            this.textRutEmpresa.TabIndex = 0;
            // 
            // textGiro
            // 
            this.textGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textGiro.Location = new System.Drawing.Point(118, 71);
            this.textGiro.Name = "textGiro";
            this.textGiro.Size = new System.Drawing.Size(226, 20);
            this.textGiro.TabIndex = 20;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(9, 74);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(78, 13);
            this.label55.TabIndex = 34;
            this.label55.Text = "Giro Comercial:";
            // 
            // textDireccionEmpresa
            // 
            this.textDireccionEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDireccionEmpresa.Location = new System.Drawing.Point(118, 123);
            this.textDireccionEmpresa.Name = "textDireccionEmpresa";
            this.textDireccionEmpresa.Size = new System.Drawing.Size(226, 20);
            this.textDireccionEmpresa.TabIndex = 40;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(9, 126);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(55, 13);
            this.label54.TabIndex = 36;
            this.label54.Text = "Dirección:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::SIMPLEAPI_Demo.Properties.Resources.Eliminar;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Image = global::SIMPLEAPI_Demo.Properties.Resources.Guardar;
            this.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonGuardar.Location = new System.Drawing.Point(811, 291);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(79, 33);
            this.botonGuardar.TabIndex = 10;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.botonAgregarProducto);
            this.groupBox4.Controls.Add(this.gridProductos);
            this.groupBox4.Controls.Add(this.textNombreProducto);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(370, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(309, 314);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Productos de Simulación";
            // 
            // botonAgregarProducto
            // 
            this.botonAgregarProducto.Image = global::SIMPLEAPI_Demo.Properties.Resources.Agregar1;
            this.botonAgregarProducto.Location = new System.Drawing.Point(272, 21);
            this.botonAgregarProducto.Name = "botonAgregarProducto";
            this.botonAgregarProducto.Size = new System.Drawing.Size(31, 23);
            this.botonAgregarProducto.TabIndex = 6;
            this.botonAgregarProducto.UseVisualStyleBackColor = true;
            this.botonAgregarProducto.Click += new System.EventHandler(this.botonAgregarProducto_Click);
            // 
            // gridProductos
            // 
            this.gridProductos.AllowUserToAddRows = false;
            this.gridProductos.AllowUserToDeleteRows = false;
            this.gridProductos.AllowUserToResizeColumns = false;
            this.gridProductos.AllowUserToResizeRows = false;
            this.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn2});
            this.gridProductos.Location = new System.Drawing.Point(11, 52);
            this.gridProductos.Name = "gridProductos";
            this.gridProductos.ReadOnly = true;
            this.gridProductos.RowHeadersWidth = 25;
            this.gridProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProductos.Size = new System.Drawing.Size(292, 256);
            this.gridProductos.TabIndex = 5;
            this.gridProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProductos_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 205;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::SIMPLEAPI_Demo.Properties.Resources.Eliminar;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 35;
            // 
            // textNombreProducto
            // 
            this.textNombreProducto.Location = new System.Drawing.Point(61, 23);
            this.textNombreProducto.Name = "textNombreProducto";
            this.textNombreProducto.Size = new System.Drawing.Size(205, 20);
            this.textNombreProducto.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(682, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "API Key:";
            // 
            // textAPIKey
            // 
            this.textAPIKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textAPIKey.Location = new System.Drawing.Point(736, 214);
            this.textAPIKey.Name = "textAPIKey";
            this.textAPIKey.Size = new System.Drawing.Size(154, 20);
            this.textAPIKey.TabIndex = 33;
            // 
            // ConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 336);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textAPIKey);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracionSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNResolucion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericNResolucion;
        private System.Windows.Forms.DateTimePicker dateFechaResolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboCertificados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRutCertificado;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button botonGuardarActividad;
        private System.Windows.Forms.DataGridView gridResultados;
        private System.Windows.Forms.TextBox textNumeroActividad;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox textComuna;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox textRutEmpresa;
        private System.Windows.Forms.TextBox textGiro;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox textDireccionEmpresa;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button botonAgregarProducto;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.TextBox textNombreProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAPIKey;
    }
}