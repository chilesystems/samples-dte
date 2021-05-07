
namespace DemoEndPoints.Impresion
{
    partial class Formato80
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
            this.txt_ejecutivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dp_fechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.txt_unidadSii = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_archivo = new System.Windows.Forms.Button();
            this.txt_archivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.txt_numResolucion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_numResolucion);
            this.groupBox1.Controls.Add(this.txt_ejecutivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dp_fechaResolucion);
            this.groupBox1.Controls.Add(this.txt_unidadSii);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 149);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txt_ejecutivo
            // 
            this.txt_ejecutivo.Location = new System.Drawing.Point(146, 105);
            this.txt_ejecutivo.Name = "txt_ejecutivo";
            this.txt_ejecutivo.Size = new System.Drawing.Size(100, 20);
            this.txt_ejecutivo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ejecutivo ";
            // 
            // dp_fechaResolucion
            // 
            this.dp_fechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaResolucion.Location = new System.Drawing.Point(146, 79);
            this.dp_fechaResolucion.Name = "dp_fechaResolucion";
            this.dp_fechaResolucion.Size = new System.Drawing.Size(100, 20);
            this.dp_fechaResolucion.TabIndex = 6;
            // 
            // txt_unidadSii
            // 
            this.txt_unidadSii.Location = new System.Drawing.Point(146, 53);
            this.txt_unidadSii.Name = "txt_unidadSii";
            this.txt_unidadSii.Size = new System.Drawing.Size(100, 20);
            this.txt_unidadSii.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Resolución ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unidad SII ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Resolución ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_archivo);
            this.groupBox2.Controls.Add(this.txt_archivo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 73);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivo";
            // 
            // btn_archivo
            // 
            this.btn_archivo.Location = new System.Drawing.Point(252, 23);
            this.btn_archivo.Name = "btn_archivo";
            this.btn_archivo.Size = new System.Drawing.Size(75, 23);
            this.btn_archivo.TabIndex = 2;
            this.btn_archivo.Text = "Cargar";
            this.btn_archivo.UseVisualStyleBackColor = true;
            this.btn_archivo.Click += new System.EventHandler(this.btn_archivo_Click);
            // 
            // txt_archivo
            // 
            this.txt_archivo.Location = new System.Drawing.Point(146, 25);
            this.txt_archivo.Name = "txt_archivo";
            this.txt_archivo.Size = new System.Drawing.Size(100, 20);
            this.txt_archivo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Selecciona el dte boleta ";
            // 
            // btn_enviar
            // 
            this.btn_enviar.Location = new System.Drawing.Point(167, 246);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(75, 23);
            this.btn_enviar.TabIndex = 11;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // txt_numResolucion
            // 
            this.txt_numResolucion.Location = new System.Drawing.Point(146, 27);
            this.txt_numResolucion.MaxLength = 9;
            this.txt_numResolucion.Name = "txt_numResolucion";
            this.txt_numResolucion.Size = new System.Drawing.Size(100, 20);
            this.txt_numResolucion.TabIndex = 10;
            this.txt_numResolucion.Text = "0";
            this.txt_numResolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // Formato80
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 281);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Formato80";
            this.Text = "Formato 80mm";
            this.Load += new System.EventHandler(this.Formato80_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ejecutivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dp_fechaResolucion;
        private System.Windows.Forms.TextBox txt_unidadSii;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_archivo;
        private System.Windows.Forms.TextBox txt_archivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.TextBox txt_numResolucion;
    }
}