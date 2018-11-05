namespace SIMPLEAPI_Demo
{
    partial class IngresarTimbraje
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
            this.textTipoCAF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textRango = new System.Windows.Forms.TextBox();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textTipoCAF
            // 
            this.textTipoCAF.Location = new System.Drawing.Point(66, 86);
            this.textTipoCAF.Name = "textTipoCAF";
            this.textTipoCAF.Size = new System.Drawing.Size(307, 20);
            this.textTipoCAF.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Tipo:";
            // 
            // botonGuardar
            // 
            this.botonGuardar.Image = global::SIMPLEAPI_Demo.Properties.Resources.Guardar_32;
            this.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonGuardar.Location = new System.Drawing.Point(282, 138);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(91, 37);
            this.botonGuardar.TabIndex = 24;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Rango Autorizado:";
            // 
            // textRango
            // 
            this.textRango.Location = new System.Drawing.Point(273, 112);
            this.textRango.Name = "textRango";
            this.textRango.Size = new System.Drawing.Size(100, 20);
            this.textRango.TabIndex = 22;
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(66, 112);
            this.textFecha.Name = "textFecha";
            this.textFecha.Size = new System.Drawing.Size(100, 20);
            this.textFecha.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 64);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lectura";
            // 
            // botonBuscar
            // 
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Image = global::SIMPLEAPI_Demo.Properties.Resources.View;
            this.botonBuscar.Location = new System.Drawing.Point(326, 27);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(29, 20);
            this.botonBuscar.TabIndex = 2;
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(54, 27);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(266, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IngresarTimbraje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 190);
            this.Controls.Add(this.textTipoCAF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textRango);
            this.Controls.Add(this.textFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IngresarTimbraje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Timbraje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTipoCAF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRango;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}