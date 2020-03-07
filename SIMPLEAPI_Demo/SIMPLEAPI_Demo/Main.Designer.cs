namespace SIMPLEAPI_Demo
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.botonLibroGuias = new System.Windows.Forms.Button();
            this.botonGetCertificados = new System.Windows.Forms.Button();
            this.botonValidador = new System.Windows.Forms.Button();
            this.botonTimbre = new System.Windows.Forms.Button();
            this.botonAceptacion = new System.Windows.Forms.Button();
            this.botonSimulacion = new System.Windows.Forms.Button();
            this.botonConsultarEstadoDTE = new System.Windows.Forms.Button();
            this.botonSetExportacion2 = new System.Windows.Forms.Button();
            this.botonSetExportacion = new System.Windows.Forms.Button();
            this.botonCesion = new System.Windows.Forms.Button();
            this.botonIntercambio = new System.Windows.Forms.Button();
            this.botonSetPruebas = new System.Windows.Forms.Button();
            this.radioProduccion = new System.Windows.Forms.RadioButton();
            this.radioCertificacion = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botonGenerarEnvioBoleta = new System.Windows.Forms.Button();
            this.botonRebajaDocumento = new System.Windows.Forms.Button();
            this.botonAnularDocumento = new System.Windows.Forms.Button();
            this.botonGenerarRCOF = new System.Windows.Forms.Button();
            this.botonGenerarBoleta = new System.Windows.Forms.Button();
            this.botonLibroBoletas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonEnviarSii = new System.Windows.Forms.Button();
            this.botonGenerarEnvio = new System.Windows.Forms.Button();
            this.botonGenerarDocumento = new System.Windows.Forms.Button();
            this.botonIngresarTimbraje = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.botonMuestraImpresa = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.botonMuestraImpresa);
            this.groupBox5.Controls.Add(this.botonLibroGuias);
            this.groupBox5.Controls.Add(this.botonGetCertificados);
            this.groupBox5.Controls.Add(this.botonValidador);
            this.groupBox5.Controls.Add(this.botonTimbre);
            this.groupBox5.Controls.Add(this.botonAceptacion);
            this.groupBox5.Controls.Add(this.botonSimulacion);
            this.groupBox5.Controls.Add(this.botonConsultarEstadoDTE);
            this.groupBox5.Location = new System.Drawing.Point(350, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 245);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Utilidades";
            // 
            // botonLibroGuias
            // 
            this.botonLibroGuias.Location = new System.Drawing.Point(6, 193);
            this.botonLibroGuias.Name = "botonLibroGuias";
            this.botonLibroGuias.Size = new System.Drawing.Size(151, 23);
            this.botonLibroGuias.TabIndex = 18;
            this.botonLibroGuias.Text = "Libro de Guías";
            this.botonLibroGuias.UseVisualStyleBackColor = true;
            this.botonLibroGuias.Click += new System.EventHandler(this.botonLibroGuias_Click);
            // 
            // botonGetCertificados
            // 
            this.botonGetCertificados.Location = new System.Drawing.Point(6, 164);
            this.botonGetCertificados.Name = "botonGetCertificados";
            this.botonGetCertificados.Size = new System.Drawing.Size(151, 23);
            this.botonGetCertificados.TabIndex = 17;
            this.botonGetCertificados.Text = "Certificados Instalados";
            this.botonGetCertificados.UseVisualStyleBackColor = true;
            // 
            // botonValidador
            // 
            this.botonValidador.Location = new System.Drawing.Point(6, 135);
            this.botonValidador.Name = "botonValidador";
            this.botonValidador.Size = new System.Drawing.Size(151, 23);
            this.botonValidador.TabIndex = 17;
            this.botonValidador.Text = "Validador";
            this.botonValidador.UseVisualStyleBackColor = true;
            this.botonValidador.Click += new System.EventHandler(this.botonValidador_Click);
            // 
            // botonTimbre
            // 
            this.botonTimbre.Location = new System.Drawing.Point(6, 106);
            this.botonTimbre.Name = "botonTimbre";
            this.botonTimbre.Size = new System.Drawing.Size(151, 23);
            this.botonTimbre.TabIndex = 12;
            this.botonTimbre.Text = "Imagen del Timbre";
            this.botonTimbre.UseVisualStyleBackColor = true;
            this.botonTimbre.Click += new System.EventHandler(this.botonTimbre_Click);
            // 
            // botonAceptacion
            // 
            this.botonAceptacion.Location = new System.Drawing.Point(6, 48);
            this.botonAceptacion.Name = "botonAceptacion";
            this.botonAceptacion.Size = new System.Drawing.Size(151, 23);
            this.botonAceptacion.TabIndex = 3;
            this.botonAceptacion.Text = "Enviar Aceptación/Reclamo";
            this.botonAceptacion.UseVisualStyleBackColor = true;
            this.botonAceptacion.Click += new System.EventHandler(this.botonAceptacion_Click);
            // 
            // botonSimulacion
            // 
            this.botonSimulacion.Location = new System.Drawing.Point(6, 77);
            this.botonSimulacion.Name = "botonSimulacion";
            this.botonSimulacion.Size = new System.Drawing.Size(151, 23);
            this.botonSimulacion.TabIndex = 10;
            this.botonSimulacion.Text = "Simular N Documentos";
            this.botonSimulacion.UseVisualStyleBackColor = true;
            this.botonSimulacion.Click += new System.EventHandler(this.botonSimulacion_Click);
            // 
            // botonConsultarEstadoDTE
            // 
            this.botonConsultarEstadoDTE.Location = new System.Drawing.Point(6, 19);
            this.botonConsultarEstadoDTE.Name = "botonConsultarEstadoDTE";
            this.botonConsultarEstadoDTE.Size = new System.Drawing.Size(151, 23);
            this.botonConsultarEstadoDTE.TabIndex = 1;
            this.botonConsultarEstadoDTE.Text = "Consultar Estado DTE";
            this.botonConsultarEstadoDTE.UseVisualStyleBackColor = true;
            this.botonConsultarEstadoDTE.Click += new System.EventHandler(this.botonConsultarEstadoDTE_Click);
            // 
            // botonSetExportacion2
            // 
            this.botonSetExportacion2.Location = new System.Drawing.Point(5, 251);
            this.botonSetExportacion2.Name = "botonSetExportacion2";
            this.botonSetExportacion2.Size = new System.Drawing.Size(151, 23);
            this.botonSetExportacion2.TabIndex = 20;
            this.botonSetExportacion2.Text = "SET de Exportación (2)";
            this.botonSetExportacion2.UseVisualStyleBackColor = true;
            this.botonSetExportacion2.Click += new System.EventHandler(this.BotonSetExportacion2_Click);
            // 
            // botonSetExportacion
            // 
            this.botonSetExportacion.Location = new System.Drawing.Point(6, 222);
            this.botonSetExportacion.Name = "botonSetExportacion";
            this.botonSetExportacion.Size = new System.Drawing.Size(151, 23);
            this.botonSetExportacion.TabIndex = 17;
            this.botonSetExportacion.Text = "SET de Exportación (1)";
            this.botonSetExportacion.UseVisualStyleBackColor = true;
            this.botonSetExportacion.Click += new System.EventHandler(this.BotonSetExportacion_Click);
            // 
            // botonCesion
            // 
            this.botonCesion.Location = new System.Drawing.Point(6, 193);
            this.botonCesion.Name = "botonCesion";
            this.botonCesion.Size = new System.Drawing.Size(151, 23);
            this.botonCesion.TabIndex = 19;
            this.botonCesion.Text = "Cesión de Documentos";
            this.botonCesion.UseVisualStyleBackColor = true;
            this.botonCesion.Click += new System.EventHandler(this.botonCesion_Click);
            // 
            // botonIntercambio
            // 
            this.botonIntercambio.Location = new System.Drawing.Point(6, 164);
            this.botonIntercambio.Name = "botonIntercambio";
            this.botonIntercambio.Size = new System.Drawing.Size(151, 23);
            this.botonIntercambio.TabIndex = 18;
            this.botonIntercambio.Text = "Intercambio";
            this.botonIntercambio.UseVisualStyleBackColor = true;
            this.botonIntercambio.Click += new System.EventHandler(this.botonIntercambio_Click);
            // 
            // botonSetPruebas
            // 
            this.botonSetPruebas.Location = new System.Drawing.Point(6, 135);
            this.botonSetPruebas.Name = "botonSetPruebas";
            this.botonSetPruebas.Size = new System.Drawing.Size(151, 23);
            this.botonSetPruebas.TabIndex = 18;
            this.botonSetPruebas.Text = "SET de Pruebas";
            this.botonSetPruebas.UseVisualStyleBackColor = true;
            this.botonSetPruebas.Click += new System.EventHandler(this.botonSetPruebas_Click);
            // 
            // radioProduccion
            // 
            this.radioProduccion.AutoSize = true;
            this.radioProduccion.Location = new System.Drawing.Point(434, 263);
            this.radioProduccion.Name = "radioProduccion";
            this.radioProduccion.Size = new System.Drawing.Size(79, 17);
            this.radioProduccion.TabIndex = 15;
            this.radioProduccion.Text = "Producción";
            this.radioProduccion.UseVisualStyleBackColor = true;
            // 
            // radioCertificacion
            // 
            this.radioCertificacion.AutoSize = true;
            this.radioCertificacion.Checked = true;
            this.radioCertificacion.Location = new System.Drawing.Point(345, 263);
            this.radioCertificacion.Name = "radioCertificacion";
            this.radioCertificacion.Size = new System.Drawing.Size(83, 17);
            this.radioCertificacion.TabIndex = 14;
            this.radioCertificacion.TabStop = true;
            this.radioCertificacion.Text = "Certificación";
            this.radioCertificacion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botonGenerarEnvioBoleta);
            this.groupBox2.Controls.Add(this.botonRebajaDocumento);
            this.groupBox2.Controls.Add(this.botonAnularDocumento);
            this.groupBox2.Controls.Add(this.botonGenerarRCOF);
            this.groupBox2.Controls.Add(this.botonGenerarBoleta);
            this.groupBox2.Controls.Add(this.botonLibroBoletas);
            this.groupBox2.Location = new System.Drawing.Point(181, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 197);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Boletas Electrónicas";
            // 
            // botonGenerarEnvioBoleta
            // 
            this.botonGenerarEnvioBoleta.Location = new System.Drawing.Point(6, 164);
            this.botonGenerarEnvioBoleta.Name = "botonGenerarEnvioBoleta";
            this.botonGenerarEnvioBoleta.Size = new System.Drawing.Size(151, 23);
            this.botonGenerarEnvioBoleta.TabIndex = 5;
            this.botonGenerarEnvioBoleta.Text = "Envío para Boletas";
            this.botonGenerarEnvioBoleta.UseVisualStyleBackColor = true;
            this.botonGenerarEnvioBoleta.Click += new System.EventHandler(this.botonGenerarEnvioBoleta_Click);
            // 
            // botonRebajaDocumento
            // 
            this.botonRebajaDocumento.Location = new System.Drawing.Point(6, 77);
            this.botonRebajaDocumento.Name = "botonRebajaDocumento";
            this.botonRebajaDocumento.Size = new System.Drawing.Size(151, 23);
            this.botonRebajaDocumento.TabIndex = 4;
            this.botonRebajaDocumento.Text = "Rebajar Documento";
            this.botonRebajaDocumento.UseVisualStyleBackColor = true;
            this.botonRebajaDocumento.Click += new System.EventHandler(this.botonRebajaDocumento_Click);
            // 
            // botonAnularDocumento
            // 
            this.botonAnularDocumento.Location = new System.Drawing.Point(6, 48);
            this.botonAnularDocumento.Name = "botonAnularDocumento";
            this.botonAnularDocumento.Size = new System.Drawing.Size(151, 23);
            this.botonAnularDocumento.TabIndex = 3;
            this.botonAnularDocumento.Text = "Anular Documento (NC)";
            this.botonAnularDocumento.UseVisualStyleBackColor = true;
            this.botonAnularDocumento.Click += new System.EventHandler(this.botonAnularDocumento_Click);
            // 
            // botonGenerarRCOF
            // 
            this.botonGenerarRCOF.Location = new System.Drawing.Point(6, 106);
            this.botonGenerarRCOF.Name = "botonGenerarRCOF";
            this.botonGenerarRCOF.Size = new System.Drawing.Size(151, 23);
            this.botonGenerarRCOF.TabIndex = 2;
            this.botonGenerarRCOF.Text = "Generar RCOF";
            this.botonGenerarRCOF.UseVisualStyleBackColor = true;
            this.botonGenerarRCOF.Click += new System.EventHandler(this.botonGenerarRCOF_Click);
            // 
            // botonGenerarBoleta
            // 
            this.botonGenerarBoleta.Location = new System.Drawing.Point(6, 19);
            this.botonGenerarBoleta.Name = "botonGenerarBoleta";
            this.botonGenerarBoleta.Size = new System.Drawing.Size(151, 23);
            this.botonGenerarBoleta.TabIndex = 1;
            this.botonGenerarBoleta.Text = "Generar Documento";
            this.botonGenerarBoleta.UseVisualStyleBackColor = true;
            this.botonGenerarBoleta.Click += new System.EventHandler(this.botonGenerarBoleta_Click);
            // 
            // botonLibroBoletas
            // 
            this.botonLibroBoletas.Location = new System.Drawing.Point(6, 135);
            this.botonLibroBoletas.Name = "botonLibroBoletas";
            this.botonLibroBoletas.Size = new System.Drawing.Size(151, 23);
            this.botonLibroBoletas.TabIndex = 2;
            this.botonLibroBoletas.Text = "Libro de Boletas";
            this.botonLibroBoletas.UseVisualStyleBackColor = true;
            this.botonLibroBoletas.Click += new System.EventHandler(this.botonLibroBoletas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonSetExportacion2);
            this.groupBox1.Controls.Add(this.botonSetPruebas);
            this.groupBox1.Controls.Add(this.botonSetExportacion);
            this.groupBox1.Controls.Add(this.botonEnviarSii);
            this.groupBox1.Controls.Add(this.botonCesion);
            this.groupBox1.Controls.Add(this.botonGenerarEnvio);
            this.groupBox1.Controls.Add(this.botonIntercambio);
            this.groupBox1.Controls.Add(this.botonGenerarDocumento);
            this.groupBox1.Controls.Add(this.botonIngresarTimbraje);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 281);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // botonEnviarSii
            // 
            this.botonEnviarSii.Location = new System.Drawing.Point(6, 106);
            this.botonEnviarSii.Name = "botonEnviarSii";
            this.botonEnviarSii.Size = new System.Drawing.Size(151, 23);
            this.botonEnviarSii.TabIndex = 3;
            this.botonEnviarSii.Text = "Enviar al SII";
            this.botonEnviarSii.UseVisualStyleBackColor = true;
            this.botonEnviarSii.Click += new System.EventHandler(this.botonEnviarSii_Click);
            // 
            // botonGenerarEnvio
            // 
            this.botonGenerarEnvio.Location = new System.Drawing.Point(6, 77);
            this.botonGenerarEnvio.Name = "botonGenerarEnvio";
            this.botonGenerarEnvio.Size = new System.Drawing.Size(151, 23);
            this.botonGenerarEnvio.TabIndex = 2;
            this.botonGenerarEnvio.Text = "Generar sobre de Envío";
            this.botonGenerarEnvio.UseVisualStyleBackColor = true;
            this.botonGenerarEnvio.Click += new System.EventHandler(this.botonGenerarEnvio_Click);
            // 
            // botonGenerarDocumento
            // 
            this.botonGenerarDocumento.Location = new System.Drawing.Point(6, 48);
            this.botonGenerarDocumento.Name = "botonGenerarDocumento";
            this.botonGenerarDocumento.Size = new System.Drawing.Size(151, 23);
            this.botonGenerarDocumento.TabIndex = 1;
            this.botonGenerarDocumento.Text = "Generar Documento";
            this.botonGenerarDocumento.UseVisualStyleBackColor = true;
            this.botonGenerarDocumento.Click += new System.EventHandler(this.botonGenerarDocumento_Click);
            // 
            // botonIngresarTimbraje
            // 
            this.botonIngresarTimbraje.Location = new System.Drawing.Point(6, 19);
            this.botonIngresarTimbraje.Name = "botonIngresarTimbraje";
            this.botonIngresarTimbraje.Size = new System.Drawing.Size(151, 23);
            this.botonIngresarTimbraje.TabIndex = 0;
            this.botonIngresarTimbraje.Text = "Ingresar Timbraje CAF";
            this.botonIngresarTimbraje.UseVisualStyleBackColor = true;
            this.botonIngresarTimbraje.Click += new System.EventHandler(this.botonIngresarTimbraje_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ambiente:";
            // 
            // botonMuestraImpresa
            // 
            this.botonMuestraImpresa.Location = new System.Drawing.Point(6, 222);
            this.botonMuestraImpresa.Name = "botonMuestraImpresa";
            this.botonMuestraImpresa.Size = new System.Drawing.Size(151, 23);
            this.botonMuestraImpresa.TabIndex = 19;
            this.botonMuestraImpresa.Text = "Muestra Impresa";
            this.botonMuestraImpresa.UseVisualStyleBackColor = true;
            this.botonMuestraImpresa.Click += new System.EventHandler(this.botonMuestraImpresa_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.radioProduccion);
            this.Controls.Add(this.radioCertificacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button botonTimbre;
        private System.Windows.Forms.Button botonAceptacion;
        private System.Windows.Forms.Button botonSimulacion;
        private System.Windows.Forms.Button botonConsultarEstadoDTE;
        private System.Windows.Forms.RadioButton radioProduccion;
        private System.Windows.Forms.RadioButton radioCertificacion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button botonGenerarEnvioBoleta;
        private System.Windows.Forms.Button botonRebajaDocumento;
        private System.Windows.Forms.Button botonAnularDocumento;
        private System.Windows.Forms.Button botonGenerarRCOF;
        private System.Windows.Forms.Button botonGenerarBoleta;
        private System.Windows.Forms.Button botonLibroBoletas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonEnviarSii;
        private System.Windows.Forms.Button botonGenerarEnvio;
        private System.Windows.Forms.Button botonGenerarDocumento;
        private System.Windows.Forms.Button botonIngresarTimbraje;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button botonValidador;
        private System.Windows.Forms.Button botonSetPruebas;
        private System.Windows.Forms.Button botonIntercambio;
        private System.Windows.Forms.Button botonCesion;
        private System.Windows.Forms.Button botonSetExportacion;
        private System.Windows.Forms.Button botonSetExportacion2;
        private System.Windows.Forms.Button botonGetCertificados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonLibroGuias;
        private System.Windows.Forms.Button botonMuestraImpresa;
    }
}

