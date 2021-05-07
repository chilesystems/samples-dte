
namespace DemoEndPoints.GenerarJson
{
    partial class JsonEnvio
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
            this.txt_jsonEnvio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Produccion = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.lbl_numResol = new System.Windows.Forms.Label();
            this.lbl_rutRecep = new System.Windows.Forms.Label();
            this.lbl_rutEmisor = new System.Windows.Forms.Label();
            this.lbl_passCert = new System.Windows.Forms.Label();
            this.lbl_rutCert = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_jsonEnvio
            // 
            this.txt_jsonEnvio.Location = new System.Drawing.Point(12, 184);
            this.txt_jsonEnvio.Multiline = true;
            this.txt_jsonEnvio.Name = "txt_jsonEnvio";
            this.txt_jsonEnvio.Size = new System.Drawing.Size(627, 147);
            this.txt_jsonEnvio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rut Certificado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña Certificado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rut Emisor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Produccion);
            this.groupBox1.Controls.Add(this.lbl_fecha);
            this.groupBox1.Controls.Add(this.lbl_numResol);
            this.groupBox1.Controls.Add(this.lbl_rutRecep);
            this.groupBox1.Controls.Add(this.lbl_rutEmisor);
            this.groupBox1.Controls.Add(this.lbl_passCert);
            this.groupBox1.Controls.Add(this.lbl_rutCert);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 154);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // lbl_Produccion
            // 
            this.lbl_Produccion.AutoSize = true;
            this.lbl_Produccion.Location = new System.Drawing.Point(417, 91);
            this.lbl_Produccion.Name = "lbl_Produccion";
            this.lbl_Produccion.Size = new System.Drawing.Size(60, 13);
            this.lbl_Produccion.TabIndex = 14;
            this.lbl_Produccion.Text = "produccion";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Location = new System.Drawing.Point(417, 63);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(34, 13);
            this.lbl_fecha.TabIndex = 13;
            this.lbl_fecha.Text = "fecha";
            // 
            // lbl_numResol
            // 
            this.lbl_numResol.AutoSize = true;
            this.lbl_numResol.Location = new System.Drawing.Point(417, 36);
            this.lbl_numResol.Name = "lbl_numResol";
            this.lbl_numResol.Size = new System.Drawing.Size(93, 13);
            this.lbl_numResol.TabIndex = 12;
            this.lbl_numResol.Text = "numero resolucion";
            // 
            // lbl_rutRecep
            // 
            this.lbl_rutRecep.AutoSize = true;
            this.lbl_rutRecep.Location = new System.Drawing.Point(182, 119);
            this.lbl_rutRecep.Name = "lbl_rutRecep";
            this.lbl_rutRecep.Size = new System.Drawing.Size(61, 13);
            this.lbl_rutRecep.TabIndex = 11;
            this.lbl_rutRecep.Text = "rut receptor";
            // 
            // lbl_rutEmisor
            // 
            this.lbl_rutEmisor.AutoSize = true;
            this.lbl_rutEmisor.Location = new System.Drawing.Point(182, 91);
            this.lbl_rutEmisor.Name = "lbl_rutEmisor";
            this.lbl_rutEmisor.Size = new System.Drawing.Size(52, 13);
            this.lbl_rutEmisor.TabIndex = 10;
            this.lbl_rutEmisor.Text = "rut emisor";
            // 
            // lbl_passCert
            // 
            this.lbl_passCert.AutoSize = true;
            this.lbl_passCert.Location = new System.Drawing.Point(182, 63);
            this.lbl_passCert.Name = "lbl_passCert";
            this.lbl_passCert.Size = new System.Drawing.Size(112, 13);
            this.lbl_passCert.TabIndex = 9;
            this.lbl_passCert.Text = "contraseña certificado";
            // 
            // lbl_rutCert
            // 
            this.lbl_rutCert.AutoSize = true;
            this.lbl_rutCert.Location = new System.Drawing.Point(182, 36);
            this.lbl_rutCert.Name = "lbl_rutCert";
            this.lbl_rutCert.Size = new System.Drawing.Size(71, 13);
            this.lbl_rutCert.TabIndex = 8;
            this.lbl_rutCert.Text = "rut certificado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Producción";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha Resolución";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Numero Resolución";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rut Receptor";
            // 
            // JsonEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_jsonEnvio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JsonEnvio";
            this.Text = "Generador Json Envio";
            this.Load += new System.EventHandler(this.JsonEnvio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_jsonEnvio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Produccion;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label lbl_numResol;
        private System.Windows.Forms.Label lbl_rutRecep;
        private System.Windows.Forms.Label lbl_rutEmisor;
        private System.Windows.Forms.Label lbl_passCert;
        private System.Windows.Forms.Label lbl_rutCert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}