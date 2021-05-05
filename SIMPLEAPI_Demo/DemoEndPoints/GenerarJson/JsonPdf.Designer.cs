
namespace DemoEndPoints.GenerarJson
{
    partial class JsonPdf
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
            this.txt_jsonPdf = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ejecutivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dp_fechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.txt_numResolucion = new System.Windows.Forms.NumericUpDown();
            this.txt_unidadSii = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numResolucion)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_jsonPdf
            // 
            this.txt_jsonPdf.Location = new System.Drawing.Point(12, 166);
            this.txt_jsonPdf.Multiline = true;
            this.txt_jsonPdf.Name = "txt_jsonPdf";
            this.txt_jsonPdf.Size = new System.Drawing.Size(369, 95);
            this.txt_jsonPdf.TabIndex = 0;
            this.txt_jsonPdf.TextChanged += new System.EventHandler(this.txt_jsonPdf_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ejecutivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dp_fechaResolucion);
            this.groupBox1.Controls.Add(this.txt_numResolucion);
            this.groupBox1.Controls.Add(this.txt_unidadSii);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 148);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txt_ejecutivo
            // 
            this.txt_ejecutivo.Location = new System.Drawing.Point(139, 108);
            this.txt_ejecutivo.Name = "txt_ejecutivo";
            this.txt_ejecutivo.Size = new System.Drawing.Size(100, 20);
            this.txt_ejecutivo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ejecutivo :";
            // 
            // dp_fechaResolucion
            // 
            this.dp_fechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaResolucion.Location = new System.Drawing.Point(139, 80);
            this.dp_fechaResolucion.Name = "dp_fechaResolucion";
            this.dp_fechaResolucion.Size = new System.Drawing.Size(200, 20);
            this.dp_fechaResolucion.TabIndex = 6;
            // 
            // txt_numResolucion
            // 
            this.txt_numResolucion.Location = new System.Drawing.Point(139, 28);
            this.txt_numResolucion.Name = "txt_numResolucion";
            this.txt_numResolucion.Size = new System.Drawing.Size(120, 20);
            this.txt_numResolucion.TabIndex = 5;
            // 
            // txt_unidadSii
            // 
            this.txt_unidadSii.Location = new System.Drawing.Point(139, 54);
            this.txt_unidadSii.Name = "txt_unidadSii";
            this.txt_unidadSii.Size = new System.Drawing.Size(100, 20);
            this.txt_unidadSii.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Resolución :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unidad SII :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Resolución :";
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(214, 279);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(100, 23);
            this.btn_generar.TabIndex = 4;
            this.btn_generar.Text = "Generar Json";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(49, 279);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(102, 23);
            this.btn_limpiar.TabIndex = 5;
            this.btn_limpiar.Text = "Limpiar Datos";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // JsonPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 322);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_jsonPdf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JsonPdf";
            this.Text = "Generador Json PDF";
            this.Load += new System.EventHandler(this.JsonPdf_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numResolucion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_jsonPdf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ejecutivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dp_fechaResolucion;
        private System.Windows.Forms.NumericUpDown txt_numResolucion;
        private System.Windows.Forms.TextBox txt_unidadSii;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_limpiar;
    }
}