
namespace DemoEndPoints
{
    partial class EnviarRcof
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
            this.btn_cargarRcof = new System.Windows.Forms.Button();
            this.txt_rcof = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbx_produccionNo = new System.Windows.Forms.CheckBox();
            this.chbx_produccionSi = new System.Windows.Forms.CheckBox();
            this.dp_fechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.txt_rutReceptor = new System.Windows.Forms.TextBox();
            this.txt_rutEmisor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_enviarRcof = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cargarCertificado = new System.Windows.Forms.Button();
            this.txt_passCertificado = new System.Windows.Forms.TextBox();
            this.txt_rutCertificado = new System.Windows.Forms.TextBox();
            this.txt_certificado = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_numResolucion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_cargarRcof);
            this.groupBox1.Controls.Add(this.txt_rcof);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RCOF";
            // 
            // btn_cargarRcof
            // 
            this.btn_cargarRcof.Location = new System.Drawing.Point(265, 24);
            this.btn_cargarRcof.Name = "btn_cargarRcof";
            this.btn_cargarRcof.Size = new System.Drawing.Size(48, 25);
            this.btn_cargarRcof.TabIndex = 9;
            this.btn_cargarRcof.Text = "Cargar";
            this.btn_cargarRcof.UseVisualStyleBackColor = true;
            this.btn_cargarRcof.Click += new System.EventHandler(this.btn_cargarRcof_Click);
            // 
            // txt_rcof
            // 
            this.txt_rcof.Location = new System.Drawing.Point(150, 27);
            this.txt_rcof.Name = "txt_rcof";
            this.txt_rcof.Size = new System.Drawing.Size(100, 20);
            this.txt_rcof.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selecciona un RCOF ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_numResolucion);
            this.groupBox2.Controls.Add(this.chbx_produccionNo);
            this.groupBox2.Controls.Add(this.chbx_produccionSi);
            this.groupBox2.Controls.Add(this.dp_fechaResolucion);
            this.groupBox2.Controls.Add(this.txt_rutReceptor);
            this.groupBox2.Controls.Add(this.txt_rutEmisor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // chbx_produccionNo
            // 
            this.chbx_produccionNo.AutoSize = true;
            this.chbx_produccionNo.Location = new System.Drawing.Point(205, 133);
            this.chbx_produccionNo.Name = "chbx_produccionNo";
            this.chbx_produccionNo.Size = new System.Drawing.Size(40, 17);
            this.chbx_produccionNo.TabIndex = 11;
            this.chbx_produccionNo.Text = "No";
            this.chbx_produccionNo.UseVisualStyleBackColor = true;
            this.chbx_produccionNo.CheckedChanged += new System.EventHandler(this.chbx_produccionNo_CheckedChanged);
            // 
            // chbx_produccionSi
            // 
            this.chbx_produccionSi.AutoSize = true;
            this.chbx_produccionSi.Checked = true;
            this.chbx_produccionSi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_produccionSi.Location = new System.Drawing.Point(153, 133);
            this.chbx_produccionSi.Name = "chbx_produccionSi";
            this.chbx_produccionSi.Size = new System.Drawing.Size(35, 17);
            this.chbx_produccionSi.TabIndex = 10;
            this.chbx_produccionSi.Text = "Si";
            this.chbx_produccionSi.UseVisualStyleBackColor = true;
            this.chbx_produccionSi.CheckedChanged += new System.EventHandler(this.chbx_produccionSi_CheckedChanged);
            // 
            // dp_fechaResolucion
            // 
            this.dp_fechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaResolucion.Location = new System.Drawing.Point(153, 103);
            this.dp_fechaResolucion.Name = "dp_fechaResolucion";
            this.dp_fechaResolucion.Size = new System.Drawing.Size(100, 20);
            this.dp_fechaResolucion.TabIndex = 8;
            // 
            // txt_rutReceptor
            // 
            this.txt_rutReceptor.Location = new System.Drawing.Point(153, 49);
            this.txt_rutReceptor.Name = "txt_rutReceptor";
            this.txt_rutReceptor.Size = new System.Drawing.Size(100, 20);
            this.txt_rutReceptor.TabIndex = 6;
            // 
            // txt_rutEmisor
            // 
            this.txt_rutEmisor.Location = new System.Drawing.Point(153, 21);
            this.txt_rutEmisor.Name = "txt_rutEmisor";
            this.txt_rutEmisor.Size = new System.Drawing.Size(100, 20);
            this.txt_rutEmisor.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "¿Producción? ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fecha Resolución ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numero Resolución ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Rut Receptor ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rut Emisor ";
            // 
            // btn_enviarRcof
            // 
            this.btn_enviarRcof.Location = new System.Drawing.Point(139, 442);
            this.btn_enviarRcof.Name = "btn_enviarRcof";
            this.btn_enviarRcof.Size = new System.Drawing.Size(75, 23);
            this.btn_enviarRcof.TabIndex = 6;
            this.btn_enviarRcof.Text = "Enviar";
            this.btn_enviarRcof.UseVisualStyleBackColor = true;
            this.btn_enviarRcof.Click += new System.EventHandler(this.btn_enviarRcof_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_cargarCertificado);
            this.groupBox3.Controls.Add(this.txt_passCertificado);
            this.groupBox3.Controls.Add(this.txt_rutCertificado);
            this.groupBox3.Controls.Add(this.txt_certificado);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 141);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Certificado Digital";
            // 
            // btn_cargarCertificado
            // 
            this.btn_cargarCertificado.Location = new System.Drawing.Point(265, 84);
            this.btn_cargarCertificado.Name = "btn_cargarCertificado";
            this.btn_cargarCertificado.Size = new System.Drawing.Size(48, 25);
            this.btn_cargarCertificado.TabIndex = 6;
            this.btn_cargarCertificado.Text = "Cargar";
            this.btn_cargarCertificado.UseVisualStyleBackColor = true;
            // 
            // txt_passCertificado
            // 
            this.txt_passCertificado.Location = new System.Drawing.Point(150, 57);
            this.txt_passCertificado.Name = "txt_passCertificado";
            this.txt_passCertificado.Size = new System.Drawing.Size(100, 20);
            this.txt_passCertificado.TabIndex = 5;
            // 
            // txt_rutCertificado
            // 
            this.txt_rutCertificado.Location = new System.Drawing.Point(150, 29);
            this.txt_rutCertificado.Name = "txt_rutCertificado";
            this.txt_rutCertificado.Size = new System.Drawing.Size(100, 20);
            this.txt_rutCertificado.TabIndex = 4;
            // 
            // txt_certificado
            // 
            this.txt_certificado.Location = new System.Drawing.Point(150, 87);
            this.txt_certificado.Name = "txt_certificado";
            this.txt_certificado.Size = new System.Drawing.Size(100, 20);
            this.txt_certificado.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Contraseña ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Rut ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Selecciona un Certificado ";
            // 
            // txt_numResolucion
            // 
            this.txt_numResolucion.Location = new System.Drawing.Point(153, 77);
            this.txt_numResolucion.Name = "txt_numResolucion";
            this.txt_numResolucion.Size = new System.Drawing.Size(44, 20);
            this.txt_numResolucion.TabIndex = 29;
            // 
            // EnviarRcof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 484);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_enviarRcof);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnviarRcof";
            this.Text = "Enviar RCOF";
            this.Load += new System.EventHandler(this.EnviarRcof_Load);
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
        private System.Windows.Forms.Button btn_cargarRcof;
        private System.Windows.Forms.TextBox txt_rcof;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dp_fechaResolucion;
        private System.Windows.Forms.TextBox txt_rutReceptor;
        private System.Windows.Forms.TextBox txt_rutEmisor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_enviarRcof;
        private System.Windows.Forms.CheckBox chbx_produccionNo;
        private System.Windows.Forms.CheckBox chbx_produccionSi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cargarCertificado;
        private System.Windows.Forms.TextBox txt_passCertificado;
        private System.Windows.Forms.TextBox txt_rutCertificado;
        private System.Windows.Forms.TextBox txt_certificado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_numResolucion;
    }
}