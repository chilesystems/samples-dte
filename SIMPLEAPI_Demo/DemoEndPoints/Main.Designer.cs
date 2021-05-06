
namespace DemoEndPoints
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_enviarRcof = new System.Windows.Forms.Button();
            this.btn_rcofInvalidoTI = new System.Windows.Forms.Button();
            this.btn_rcofInvalido4R = new System.Windows.Forms.Button();
            this.btn_rcofValido = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_dteJson = new System.Windows.Forms.Button();
            this.btn_dteGuiaDespacho = new System.Windows.Forms.Button();
            this.btn_dteBoleta = new System.Windows.Forms.Button();
            this.btn_dteFactura = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_consultarEnvio = new System.Windows.Forms.Button();
            this.btn_EnvioBoleta = new System.Windows.Forms.Button();
            this.btn_envioDte = new System.Windows.Forms.Button();
            this.btn_dteEnvioBoleta = new System.Windows.Forms.Button();
            this.btn_dteGenerarEnvio = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_boleta80mmBase64 = new System.Windows.Forms.Button();
            this.btn_boleta80mmPdf = new System.Windows.Forms.Button();
            this.btn_facturaCartaPdf = new System.Windows.Forms.Button();
            this.btn_facturaCarta64 = new System.Windows.Forms.Button();
            this.btn_boletaCartaBase64 = new System.Windows.Forms.Button();
            this.btn_pdf417Dte = new System.Windows.Forms.Button();
            this.btn_boletaCartaPdf = new System.Windows.Forms.Button();
            this.btn_pdf417Envio = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_jsonPdf = new System.Windows.Forms.Button();
            this.btn_jsonEntrada = new System.Windows.Forms.Button();
            this.btn_jsonEnvio = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_enviarRcof);
            this.groupBox1.Controls.Add(this.btn_rcofInvalidoTI);
            this.groupBox1.Controls.Add(this.btn_rcofInvalido4R);
            this.groupBox1.Controls.Add(this.btn_rcofValido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RCOF";
            // 
            // btn_enviarRcof
            // 
            this.btn_enviarRcof.Location = new System.Drawing.Point(81, 161);
            this.btn_enviarRcof.Name = "btn_enviarRcof";
            this.btn_enviarRcof.Size = new System.Drawing.Size(170, 38);
            this.btn_enviarRcof.TabIndex = 3;
            this.btn_enviarRcof.Text = "Enviar RCOF";
            this.btn_enviarRcof.UseVisualStyleBackColor = true;
            this.btn_enviarRcof.Click += new System.EventHandler(this.btn_enviarRcof_Click);
            // 
            // btn_rcofInvalidoTI
            // 
            this.btn_rcofInvalidoTI.Location = new System.Drawing.Point(47, 117);
            this.btn_rcofInvalidoTI.Name = "btn_rcofInvalidoTI";
            this.btn_rcofInvalidoTI.Size = new System.Drawing.Size(237, 38);
            this.btn_rcofInvalidoTI.TabIndex = 2;
            this.btn_rcofInvalidoTI.Text = "Generar RCOF Invalido Resumen Tipo Invalido";
            this.btn_rcofInvalidoTI.UseVisualStyleBackColor = true;
            this.btn_rcofInvalidoTI.Click += new System.EventHandler(this.btn_rcofInvalidoTI_Click);
            // 
            // btn_rcofInvalido4R
            // 
            this.btn_rcofInvalido4R.Location = new System.Drawing.Point(47, 73);
            this.btn_rcofInvalido4R.Name = "btn_rcofInvalido4R";
            this.btn_rcofInvalido4R.Size = new System.Drawing.Size(237, 38);
            this.btn_rcofInvalido4R.TabIndex = 1;
            this.btn_rcofInvalido4R.Text = "Generar RCOF Invalido 4 Resumenes";
            this.btn_rcofInvalido4R.UseVisualStyleBackColor = true;
            this.btn_rcofInvalido4R.Click += new System.EventHandler(this.btn_rcofInvalido4R_Click);
            // 
            // btn_rcofValido
            // 
            this.btn_rcofValido.Location = new System.Drawing.Point(81, 29);
            this.btn_rcofValido.Name = "btn_rcofValido";
            this.btn_rcofValido.Size = new System.Drawing.Size(170, 38);
            this.btn_rcofValido.TabIndex = 0;
            this.btn_rcofValido.Text = "Generar RCOF Valido";
            this.btn_rcofValido.UseVisualStyleBackColor = true;
            this.btn_rcofValido.Click += new System.EventHandler(this.btn_rcofValido_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_dteJson);
            this.groupBox2.Controls.Add(this.btn_dteGuiaDespacho);
            this.groupBox2.Controls.Add(this.btn_dteBoleta);
            this.groupBox2.Controls.Add(this.btn_dteFactura);
            this.groupBox2.Location = new System.Drawing.Point(12, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 219);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generar DTE";
            // 
            // btn_dteJson
            // 
            this.btn_dteJson.Location = new System.Drawing.Point(81, 164);
            this.btn_dteJson.Name = "btn_dteJson";
            this.btn_dteJson.Size = new System.Drawing.Size(170, 38);
            this.btn_dteJson.TabIndex = 3;
            this.btn_dteJson.Text = "Generar DTE con archivo JSON";
            this.btn_dteJson.UseVisualStyleBackColor = true;
            this.btn_dteJson.Click += new System.EventHandler(this.btn_dteJson_Click);
            // 
            // btn_dteGuiaDespacho
            // 
            this.btn_dteGuiaDespacho.Location = new System.Drawing.Point(81, 120);
            this.btn_dteGuiaDespacho.Name = "btn_dteGuiaDespacho";
            this.btn_dteGuiaDespacho.Size = new System.Drawing.Size(170, 38);
            this.btn_dteGuiaDespacho.TabIndex = 2;
            this.btn_dteGuiaDespacho.Text = "Generar DTE - Guía Despacho";
            this.btn_dteGuiaDespacho.UseVisualStyleBackColor = true;
            this.btn_dteGuiaDespacho.Click += new System.EventHandler(this.btn_dteGuiaDespacho_Click);
            // 
            // btn_dteBoleta
            // 
            this.btn_dteBoleta.Location = new System.Drawing.Point(81, 76);
            this.btn_dteBoleta.Name = "btn_dteBoleta";
            this.btn_dteBoleta.Size = new System.Drawing.Size(170, 38);
            this.btn_dteBoleta.TabIndex = 1;
            this.btn_dteBoleta.Text = "Generar DTE - Boleta";
            this.btn_dteBoleta.UseVisualStyleBackColor = true;
            this.btn_dteBoleta.Click += new System.EventHandler(this.btn_dteBoleta_Click);
            // 
            // btn_dteFactura
            // 
            this.btn_dteFactura.Location = new System.Drawing.Point(81, 32);
            this.btn_dteFactura.Name = "btn_dteFactura";
            this.btn_dteFactura.Size = new System.Drawing.Size(170, 38);
            this.btn_dteFactura.TabIndex = 0;
            this.btn_dteFactura.Text = "Generar DTE - Factura";
            this.btn_dteFactura.UseVisualStyleBackColor = true;
            this.btn_dteFactura.Click += new System.EventHandler(this.btn_dteFactura_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_consultarEnvio);
            this.groupBox3.Controls.Add(this.btn_EnvioBoleta);
            this.groupBox3.Controls.Add(this.btn_envioDte);
            this.groupBox3.Controls.Add(this.btn_dteEnvioBoleta);
            this.groupBox3.Controls.Add(this.btn_dteGenerarEnvio);
            this.groupBox3.Location = new System.Drawing.Point(349, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 256);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Envio DTE";
            // 
            // btn_consultarEnvio
            // 
            this.btn_consultarEnvio.Location = new System.Drawing.Point(98, 203);
            this.btn_consultarEnvio.Name = "btn_consultarEnvio";
            this.btn_consultarEnvio.Size = new System.Drawing.Size(126, 38);
            this.btn_consultarEnvio.TabIndex = 4;
            this.btn_consultarEnvio.Text = "Consultar Estado Envio";
            this.btn_consultarEnvio.UseVisualStyleBackColor = true;
            this.btn_consultarEnvio.Click += new System.EventHandler(this.btn_consultarEnvio_Click);
            // 
            // btn_EnvioBoleta
            // 
            this.btn_EnvioBoleta.Location = new System.Drawing.Point(98, 159);
            this.btn_EnvioBoleta.Name = "btn_EnvioBoleta";
            this.btn_EnvioBoleta.Size = new System.Drawing.Size(126, 38);
            this.btn_EnvioBoleta.TabIndex = 3;
            this.btn_EnvioBoleta.Text = "Enviar Envio Boleta";
            this.btn_EnvioBoleta.UseVisualStyleBackColor = true;
            this.btn_EnvioBoleta.Click += new System.EventHandler(this.btn_EnvioBoleta_Click);
            // 
            // btn_envioDte
            // 
            this.btn_envioDte.Location = new System.Drawing.Point(98, 115);
            this.btn_envioDte.Name = "btn_envioDte";
            this.btn_envioDte.Size = new System.Drawing.Size(126, 38);
            this.btn_envioDte.TabIndex = 2;
            this.btn_envioDte.Text = "Enviar Envio DTE";
            this.btn_envioDte.UseVisualStyleBackColor = true;
            this.btn_envioDte.Click += new System.EventHandler(this.btn_envioDte_Click);
            // 
            // btn_dteEnvioBoleta
            // 
            this.btn_dteEnvioBoleta.Location = new System.Drawing.Point(98, 71);
            this.btn_dteEnvioBoleta.Name = "btn_dteEnvioBoleta";
            this.btn_dteEnvioBoleta.Size = new System.Drawing.Size(126, 38);
            this.btn_dteEnvioBoleta.TabIndex = 1;
            this.btn_dteEnvioBoleta.Text = "Generar Envio Boleta";
            this.btn_dteEnvioBoleta.UseVisualStyleBackColor = true;
            this.btn_dteEnvioBoleta.Click += new System.EventHandler(this.btn_dteEnvioBoleta_Click);
            // 
            // btn_dteGenerarEnvio
            // 
            this.btn_dteGenerarEnvio.Location = new System.Drawing.Point(98, 27);
            this.btn_dteGenerarEnvio.Name = "btn_dteGenerarEnvio";
            this.btn_dteGenerarEnvio.Size = new System.Drawing.Size(126, 38);
            this.btn_dteGenerarEnvio.TabIndex = 0;
            this.btn_dteGenerarEnvio.Text = "Generar Envio";
            this.btn_dteGenerarEnvio.UseVisualStyleBackColor = true;
            this.btn_dteGenerarEnvio.Click += new System.EventHandler(this.btn_dteGenerarEnvio_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_boleta80mmBase64);
            this.groupBox4.Controls.Add(this.btn_boleta80mmPdf);
            this.groupBox4.Controls.Add(this.btn_facturaCartaPdf);
            this.groupBox4.Controls.Add(this.btn_facturaCarta64);
            this.groupBox4.Controls.Add(this.btn_boletaCartaBase64);
            this.groupBox4.Controls.Add(this.btn_pdf417Dte);
            this.groupBox4.Controls.Add(this.btn_boletaCartaPdf);
            this.groupBox4.Controls.Add(this.btn_pdf417Envio);
            this.groupBox4.Location = new System.Drawing.Point(688, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 481);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Impresión";
            // 
            // btn_boleta80mmBase64
            // 
            this.btn_boleta80mmBase64.Location = new System.Drawing.Point(74, 403);
            this.btn_boleta80mmBase64.Name = "btn_boleta80mmBase64";
            this.btn_boleta80mmBase64.Size = new System.Drawing.Size(199, 38);
            this.btn_boleta80mmBase64.TabIndex = 7;
            this.btn_boleta80mmBase64.Text = "Boleta desde un DTE - 80mm - Base64";
            this.btn_boleta80mmBase64.UseVisualStyleBackColor = true;
            this.btn_boleta80mmBase64.Click += new System.EventHandler(this.btn_boleta80mmBase64_Click);
            // 
            // btn_boleta80mmPdf
            // 
            this.btn_boleta80mmPdf.Location = new System.Drawing.Point(74, 359);
            this.btn_boleta80mmPdf.Name = "btn_boleta80mmPdf";
            this.btn_boleta80mmPdf.Size = new System.Drawing.Size(199, 38);
            this.btn_boleta80mmPdf.TabIndex = 6;
            this.btn_boleta80mmPdf.Text = "Boleta desde un DTE - 80mm - PDF";
            this.btn_boleta80mmPdf.UseVisualStyleBackColor = true;
            this.btn_boleta80mmPdf.Click += new System.EventHandler(this.btn_boleta80mmPdf_Click);
            // 
            // btn_facturaCartaPdf
            // 
            this.btn_facturaCartaPdf.Location = new System.Drawing.Point(74, 245);
            this.btn_facturaCartaPdf.Name = "btn_facturaCartaPdf";
            this.btn_facturaCartaPdf.Size = new System.Drawing.Size(199, 38);
            this.btn_facturaCartaPdf.TabIndex = 5;
            this.btn_facturaCartaPdf.Text = "Factura desde un DTE - Carta PDF";
            this.btn_facturaCartaPdf.UseVisualStyleBackColor = true;
            this.btn_facturaCartaPdf.Click += new System.EventHandler(this.btn_facturaCartaPdf_Click);
            // 
            // btn_facturaCarta64
            // 
            this.btn_facturaCarta64.Location = new System.Drawing.Point(74, 289);
            this.btn_facturaCarta64.Name = "btn_facturaCarta64";
            this.btn_facturaCarta64.Size = new System.Drawing.Size(199, 38);
            this.btn_facturaCarta64.TabIndex = 4;
            this.btn_facturaCarta64.Text = "Factura desde un DTE - Carta Base64";
            this.btn_facturaCarta64.UseVisualStyleBackColor = true;
            this.btn_facturaCarta64.Click += new System.EventHandler(this.btn_facturaCarta64_Click);
            // 
            // btn_boletaCartaBase64
            // 
            this.btn_boletaCartaBase64.Location = new System.Drawing.Point(74, 178);
            this.btn_boletaCartaBase64.Name = "btn_boletaCartaBase64";
            this.btn_boletaCartaBase64.Size = new System.Drawing.Size(199, 38);
            this.btn_boletaCartaBase64.TabIndex = 3;
            this.btn_boletaCartaBase64.Text = "Boleta desde un DTE - Carta Base64";
            this.btn_boletaCartaBase64.UseVisualStyleBackColor = true;
            this.btn_boletaCartaBase64.Click += new System.EventHandler(this.btn_boletaCartaBase64_Click);
            // 
            // btn_pdf417Dte
            // 
            this.btn_pdf417Dte.Location = new System.Drawing.Point(74, 26);
            this.btn_pdf417Dte.Name = "btn_pdf417Dte";
            this.btn_pdf417Dte.Size = new System.Drawing.Size(199, 38);
            this.btn_pdf417Dte.TabIndex = 0;
            this.btn_pdf417Dte.Text = "PDF417 desde un DTE";
            this.btn_pdf417Dte.UseVisualStyleBackColor = true;
            this.btn_pdf417Dte.Click += new System.EventHandler(this.btn_pdf417Dte_Click);
            // 
            // btn_boletaCartaPdf
            // 
            this.btn_boletaCartaPdf.Location = new System.Drawing.Point(74, 134);
            this.btn_boletaCartaPdf.Name = "btn_boletaCartaPdf";
            this.btn_boletaCartaPdf.Size = new System.Drawing.Size(199, 38);
            this.btn_boletaCartaPdf.TabIndex = 2;
            this.btn_boletaCartaPdf.Text = "Boleta desde un DTE - Carta PDF";
            this.btn_boletaCartaPdf.UseVisualStyleBackColor = true;
            this.btn_boletaCartaPdf.Click += new System.EventHandler(this.btn_boletaCartaPdf_Click);
            // 
            // btn_pdf417Envio
            // 
            this.btn_pdf417Envio.Location = new System.Drawing.Point(74, 70);
            this.btn_pdf417Envio.Name = "btn_pdf417Envio";
            this.btn_pdf417Envio.Size = new System.Drawing.Size(199, 38);
            this.btn_pdf417Envio.TabIndex = 1;
            this.btn_pdf417Envio.Text = "PDF417 desde un Envio";
            this.btn_pdf417Envio.UseVisualStyleBackColor = true;
            this.btn_pdf417Envio.Click += new System.EventHandler(this.btn_pdf417Envio_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_jsonPdf);
            this.groupBox5.Controls.Add(this.btn_jsonEntrada);
            this.groupBox5.Controls.Add(this.btn_jsonEnvio);
            this.groupBox5.Location = new System.Drawing.Point(349, 274);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(324, 219);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generar JSON";
            // 
            // btn_jsonPdf
            // 
            this.btn_jsonPdf.Location = new System.Drawing.Point(98, 120);
            this.btn_jsonPdf.Name = "btn_jsonPdf";
            this.btn_jsonPdf.Size = new System.Drawing.Size(126, 38);
            this.btn_jsonPdf.TabIndex = 2;
            this.btn_jsonPdf.Text = "Generar Json PDF";
            this.btn_jsonPdf.UseVisualStyleBackColor = true;
            this.btn_jsonPdf.Click += new System.EventHandler(this.btn_jsonPdf_Click);
            // 
            // btn_jsonEntrada
            // 
            this.btn_jsonEntrada.Location = new System.Drawing.Point(98, 76);
            this.btn_jsonEntrada.Name = "btn_jsonEntrada";
            this.btn_jsonEntrada.Size = new System.Drawing.Size(126, 38);
            this.btn_jsonEntrada.TabIndex = 1;
            this.btn_jsonEntrada.Text = "Generar Json Entrada";
            this.btn_jsonEntrada.UseVisualStyleBackColor = true;
            this.btn_jsonEntrada.Click += new System.EventHandler(this.btn_jsonEntrada_Click);
            // 
            // btn_jsonEnvio
            // 
            this.btn_jsonEnvio.Location = new System.Drawing.Point(98, 32);
            this.btn_jsonEnvio.Name = "btn_jsonEnvio";
            this.btn_jsonEnvio.Size = new System.Drawing.Size(126, 38);
            this.btn_jsonEnvio.TabIndex = 0;
            this.btn_jsonEnvio.Text = "Generar Json Envio";
            this.btn_jsonEnvio.UseVisualStyleBackColor = true;
            this.btn_jsonEnvio.Click += new System.EventHandler(this.btn_jsonEnvio_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 512);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_enviarRcof;
        private System.Windows.Forms.Button btn_rcofInvalidoTI;
        private System.Windows.Forms.Button btn_rcofInvalido4R;
        private System.Windows.Forms.Button btn_rcofValido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_dteJson;
        private System.Windows.Forms.Button btn_dteGuiaDespacho;
        private System.Windows.Forms.Button btn_dteBoleta;
        private System.Windows.Forms.Button btn_dteFactura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_consultarEnvio;
        private System.Windows.Forms.Button btn_EnvioBoleta;
        private System.Windows.Forms.Button btn_envioDte;
        private System.Windows.Forms.Button btn_dteEnvioBoleta;
        private System.Windows.Forms.Button btn_dteGenerarEnvio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_boleta80mmBase64;
        private System.Windows.Forms.Button btn_boleta80mmPdf;
        private System.Windows.Forms.Button btn_facturaCartaPdf;
        private System.Windows.Forms.Button btn_facturaCarta64;
        private System.Windows.Forms.Button btn_boletaCartaBase64;
        private System.Windows.Forms.Button btn_boletaCartaPdf;
        private System.Windows.Forms.Button btn_pdf417Envio;
        private System.Windows.Forms.Button btn_pdf417Dte;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_jsonPdf;
        private System.Windows.Forms.Button btn_jsonEntrada;
        private System.Windows.Forms.Button btn_jsonEnvio;
    }
}