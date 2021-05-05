
namespace DemoEndPoints.GenerarDTE
{
    partial class GenerarDteJson
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
            this.btn_json = new System.Windows.Forms.Button();
            this.txt_json = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_certificado = new System.Windows.Forms.Button();
            this.txt_certificado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_caf = new System.Windows.Forms.Button();
            this.txt_caf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_generar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_json);
            this.groupBox1.Controls.Add(this.txt_json);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JSON";
            // 
            // btn_json
            // 
            this.btn_json.Location = new System.Drawing.Point(284, 27);
            this.btn_json.Name = "btn_json";
            this.btn_json.Size = new System.Drawing.Size(103, 23);
            this.btn_json.TabIndex = 2;
            this.btn_json.Text = "Cargar json";
            this.btn_json.UseVisualStyleBackColor = true;
            this.btn_json.Click += new System.EventHandler(this.btn_json_Click);
            // 
            // txt_json
            // 
            this.txt_json.Location = new System.Drawing.Point(175, 29);
            this.txt_json.Name = "txt_json";
            this.txt_json.Size = new System.Drawing.Size(100, 20);
            this.txt_json.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona un archivo json :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_certificado);
            this.groupBox2.Controls.Add(this.txt_certificado);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Certificado Digital";
            // 
            // btn_certificado
            // 
            this.btn_certificado.Location = new System.Drawing.Point(285, 26);
            this.btn_certificado.Name = "btn_certificado";
            this.btn_certificado.Size = new System.Drawing.Size(102, 23);
            this.btn_certificado.TabIndex = 2;
            this.btn_certificado.Text = "Cargar certificado";
            this.btn_certificado.UseVisualStyleBackColor = true;
            this.btn_certificado.Click += new System.EventHandler(this.btn_certificado_Click);
            // 
            // txt_certificado
            // 
            this.txt_certificado.Location = new System.Drawing.Point(176, 29);
            this.txt_certificado.Name = "txt_certificado";
            this.txt_certificado.Size = new System.Drawing.Size(100, 20);
            this.txt_certificado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selecciona un certificado digital :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_caf);
            this.groupBox3.Controls.Add(this.txt_caf);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 71);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAF";
            // 
            // btn_caf
            // 
            this.btn_caf.Location = new System.Drawing.Point(284, 19);
            this.btn_caf.Name = "btn_caf";
            this.btn_caf.Size = new System.Drawing.Size(103, 23);
            this.btn_caf.TabIndex = 2;
            this.btn_caf.Text = "Cargar caf";
            this.btn_caf.UseVisualStyleBackColor = true;
            this.btn_caf.Click += new System.EventHandler(this.btn_caf_Click);
            // 
            // txt_caf
            // 
            this.txt_caf.Location = new System.Drawing.Point(175, 19);
            this.txt_caf.Name = "txt_caf";
            this.txt_caf.Size = new System.Drawing.Size(100, 20);
            this.txt_caf.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Selecciona un caf :";
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(188, 267);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(100, 23);
            this.btn_generar.TabIndex = 3;
            this.btn_generar.Text = "Generar DTE";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // GenerarDteJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 335);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarDteJson";
            this.Text = "Generar DTE desde Archivos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_json;
        private System.Windows.Forms.TextBox txt_json;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_certificado;
        private System.Windows.Forms.TextBox txt_certificado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_caf;
        private System.Windows.Forms.TextBox txt_caf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_generar;
    }
}