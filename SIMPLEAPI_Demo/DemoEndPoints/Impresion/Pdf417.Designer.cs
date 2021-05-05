
namespace DemoEndPoints.Impresion
{
    partial class Pdf417
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
            this.btn_enviar = new System.Windows.Forms.Button();
            this.btn_cargar = new System.Windows.Forms.Button();
            this.txt_archivo = new System.Windows.Forms.TextBox();
            this.lbl_archivo = new System.Windows.Forms.Label();
            this.img = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_enviar);
            this.groupBox1.Controls.Add(this.btn_cargar);
            this.groupBox1.Controls.Add(this.txt_archivo);
            this.groupBox1.Controls.Add(this.lbl_archivo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo";
            // 
            // btn_enviar
            // 
            this.btn_enviar.Location = new System.Drawing.Point(133, 73);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(75, 23);
            this.btn_enviar.TabIndex = 3;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // btn_cargar
            // 
            this.btn_cargar.Location = new System.Drawing.Point(245, 27);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_cargar.TabIndex = 2;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.UseVisualStyleBackColor = true;
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // txt_archivo
            // 
            this.txt_archivo.Location = new System.Drawing.Point(133, 28);
            this.txt_archivo.Name = "txt_archivo";
            this.txt_archivo.Size = new System.Drawing.Size(100, 20);
            this.txt_archivo.TabIndex = 1;
            // 
            // lbl_archivo
            // 
            this.lbl_archivo.AutoSize = true;
            this.lbl_archivo.Location = new System.Drawing.Point(34, 31);
            this.lbl_archivo.Name = "lbl_archivo";
            this.lbl_archivo.Size = new System.Drawing.Size(95, 13);
            this.lbl_archivo.TabIndex = 0;
            this.lbl_archivo.Text = "Selecciona el dte :";
            // 
            // img
            // 
            this.img.Location = new System.Drawing.Point(416, 13);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(376, 120);
            this.img.TabIndex = 1;
            this.img.TabStop = false;
            // 
            // Pdf417
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 158);
            this.Controls.Add(this.img);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pdf417";
            this.Load += new System.EventHandler(this.Pdf417_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.Button btn_cargar;
        private System.Windows.Forms.TextBox txt_archivo;
        private System.Windows.Forms.Label lbl_archivo;
        private System.Windows.Forms.PictureBox img;
    }
}