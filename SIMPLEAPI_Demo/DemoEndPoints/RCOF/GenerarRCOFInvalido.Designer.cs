
namespace DemoEndPoints.RCOF
{
    partial class GenerarRCOFInvalido
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
            this.btn_generar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_eliminarResumen = new System.Windows.Forms.Button();
            this.grid_resumen = new System.Windows.Forms.DataGridView();
            this.btn_agregarAnulados = new System.Windows.Forms.Button();
            this.btn_agregarUtilizados = new System.Windows.Forms.Button();
            this.grid_anulados = new System.Windows.Forms.DataGridView();
            this.btn_agregarDetalles = new System.Windows.Forms.Button();
            this.txt_anuladosFinal = new System.Windows.Forms.NumericUpDown();
            this.txt_anuladosInicial = new System.Windows.Forms.NumericUpDown();
            this.lbl_rangoAF = new System.Windows.Forms.Label();
            this.lbl_rangoAI = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.grid_utilizados = new System.Windows.Forms.DataGridView();
            this.txt_utilizadosFinal = new System.Windows.Forms.NumericUpDown();
            this.txt_utilizadosInicial = new System.Windows.Forms.NumericUpDown();
            this.lbl_rangoUF = new System.Windows.Forms.Label();
            this.lbl_rangoUI = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_cargarCertificado = new System.Windows.Forms.Button();
            this.txt_passCertificado = new System.Windows.Forms.TextBox();
            this.txt_rutCertificado = new System.Windows.Forms.TextBox();
            this.txt_certificado = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dp_tmstFirma = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_numSecEnvio = new System.Windows.Forms.TextBox();
            this.txt_numResol = new System.Windows.Forms.TextBox();
            this.dp_fechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dp_fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dp_fechaResol = new System.Windows.Forms.DateTimePicker();
            this.txt_rutEnvia = new System.Windows.Forms.TextBox();
            this.txt_rutEmisor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_foliosAnulados = new System.Windows.Forms.TextBox();
            this.txt_foliosEmitidos = new System.Windows.Forms.TextBox();
            this.txt_foliosUtilizados = new System.Windows.Forms.TextBox();
            this.txt_mntTotal = new System.Windows.Forms.TextBox();
            this.txt_mntExento = new System.Windows.Forms.TextBox();
            this.txt_tasaIva = new System.Windows.Forms.TextBox();
            this.txt_mntIva = new System.Windows.Forms.TextBox();
            this.txt_mntNeto = new System.Windows.Forms.TextBox();
            this.txt_tipoDoc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_resumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_anulados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_anuladosFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_anuladosInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_utilizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_utilizadosFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_utilizadosInicial)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(499, 549);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(75, 23);
            this.btn_generar.TabIndex = 7;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_foliosAnulados);
            this.groupBox2.Controls.Add(this.txt_foliosEmitidos);
            this.groupBox2.Controls.Add(this.txt_foliosUtilizados);
            this.groupBox2.Controls.Add(this.txt_mntTotal);
            this.groupBox2.Controls.Add(this.txt_mntExento);
            this.groupBox2.Controls.Add(this.txt_tasaIva);
            this.groupBox2.Controls.Add(this.txt_mntIva);
            this.groupBox2.Controls.Add(this.txt_mntNeto);
            this.groupBox2.Controls.Add(this.txt_tipoDoc);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_eliminarResumen);
            this.groupBox2.Controls.Add(this.grid_resumen);
            this.groupBox2.Controls.Add(this.btn_agregarAnulados);
            this.groupBox2.Controls.Add(this.btn_agregarUtilizados);
            this.groupBox2.Controls.Add(this.grid_anulados);
            this.groupBox2.Controls.Add(this.btn_agregarDetalles);
            this.groupBox2.Controls.Add(this.txt_anuladosFinal);
            this.groupBox2.Controls.Add(this.txt_anuladosInicial);
            this.groupBox2.Controls.Add(this.lbl_rangoAF);
            this.groupBox2.Controls.Add(this.lbl_rangoAI);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.grid_utilizados);
            this.groupBox2.Controls.Add(this.txt_utilizadosFinal);
            this.groupBox2.Controls.Add(this.txt_utilizadosInicial);
            this.groupBox2.Controls.Add(this.lbl_rangoUF);
            this.groupBox2.Controls.Add(this.lbl_rangoUI);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1055, 384);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen";
            // 
            // btn_eliminarResumen
            // 
            this.btn_eliminarResumen.Location = new System.Drawing.Point(955, 339);
            this.btn_eliminarResumen.Name = "btn_eliminarResumen";
            this.btn_eliminarResumen.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminarResumen.TabIndex = 34;
            this.btn_eliminarResumen.Text = "Eliminar";
            this.btn_eliminarResumen.UseVisualStyleBackColor = true;
            this.btn_eliminarResumen.Click += new System.EventHandler(this.btn_eliminarResumen_Click);
            // 
            // grid_resumen
            // 
            this.grid_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_resumen.Location = new System.Drawing.Point(6, 254);
            this.grid_resumen.Name = "grid_resumen";
            this.grid_resumen.Size = new System.Drawing.Size(943, 126);
            this.grid_resumen.TabIndex = 33;
            this.grid_resumen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_resumen_CellClick);
            this.grid_resumen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_resumen_CellContentClick);
            // 
            // btn_agregarAnulados
            // 
            this.btn_agregarAnulados.Location = new System.Drawing.Point(618, 212);
            this.btn_agregarAnulados.Name = "btn_agregarAnulados";
            this.btn_agregarAnulados.Size = new System.Drawing.Size(75, 23);
            this.btn_agregarAnulados.TabIndex = 32;
            this.btn_agregarAnulados.Text = "Agregar";
            this.btn_agregarAnulados.UseVisualStyleBackColor = true;
            this.btn_agregarAnulados.Click += new System.EventHandler(this.btn_agregarAnulados_Click);
            // 
            // btn_agregarUtilizados
            // 
            this.btn_agregarUtilizados.Location = new System.Drawing.Point(102, 213);
            this.btn_agregarUtilizados.Name = "btn_agregarUtilizados";
            this.btn_agregarUtilizados.Size = new System.Drawing.Size(75, 23);
            this.btn_agregarUtilizados.TabIndex = 31;
            this.btn_agregarUtilizados.Text = "Agregar";
            this.btn_agregarUtilizados.UseVisualStyleBackColor = true;
            this.btn_agregarUtilizados.Click += new System.EventHandler(this.btn_agregarUtilizados_Click);
            // 
            // grid_anulados
            // 
            this.grid_anulados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_anulados.Location = new System.Drawing.Point(764, 132);
            this.grid_anulados.Name = "grid_anulados";
            this.grid_anulados.Size = new System.Drawing.Size(244, 104);
            this.grid_anulados.TabIndex = 30;
            // 
            // btn_agregarDetalles
            // 
            this.btn_agregarDetalles.Location = new System.Drawing.Point(955, 290);
            this.btn_agregarDetalles.Name = "btn_agregarDetalles";
            this.btn_agregarDetalles.Size = new System.Drawing.Size(75, 23);
            this.btn_agregarDetalles.TabIndex = 17;
            this.btn_agregarDetalles.Text = "Agregar";
            this.btn_agregarDetalles.UseVisualStyleBackColor = true;
            this.btn_agregarDetalles.Click += new System.EventHandler(this.btn_agregarDetalles_Click);
            // 
            // txt_anuladosFinal
            // 
            this.txt_anuladosFinal.Location = new System.Drawing.Point(604, 183);
            this.txt_anuladosFinal.Name = "txt_anuladosFinal";
            this.txt_anuladosFinal.Size = new System.Drawing.Size(120, 20);
            this.txt_anuladosFinal.TabIndex = 29;
            // 
            // txt_anuladosInicial
            // 
            this.txt_anuladosInicial.Location = new System.Drawing.Point(604, 157);
            this.txt_anuladosInicial.Name = "txt_anuladosInicial";
            this.txt_anuladosInicial.Size = new System.Drawing.Size(120, 20);
            this.txt_anuladosInicial.TabIndex = 28;
            // 
            // lbl_rangoAF
            // 
            this.lbl_rangoAF.AutoSize = true;
            this.lbl_rangoAF.Location = new System.Drawing.Point(553, 185);
            this.lbl_rangoAF.Name = "lbl_rangoAF";
            this.lbl_rangoAF.Size = new System.Drawing.Size(35, 13);
            this.lbl_rangoAF.TabIndex = 27;
            this.lbl_rangoAF.Text = "Final :";
            // 
            // lbl_rangoAI
            // 
            this.lbl_rangoAI.AutoSize = true;
            this.lbl_rangoAI.Location = new System.Drawing.Point(548, 159);
            this.lbl_rangoAI.Name = "lbl_rangoAI";
            this.lbl_rangoAI.Size = new System.Drawing.Size(40, 13);
            this.lbl_rangoAI.TabIndex = 26;
            this.lbl_rangoAI.Text = "Inicial :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(545, 132);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 13);
            this.label25.TabIndex = 25;
            this.label25.Text = "Rangos Anulados";
            // 
            // grid_utilizados
            // 
            this.grid_utilizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_utilizados.Location = new System.Drawing.Point(255, 132);
            this.grid_utilizados.Name = "grid_utilizados";
            this.grid_utilizados.Size = new System.Drawing.Size(244, 104);
            this.grid_utilizados.TabIndex = 24;
            // 
            // txt_utilizadosFinal
            // 
            this.txt_utilizadosFinal.Location = new System.Drawing.Point(78, 183);
            this.txt_utilizadosFinal.Name = "txt_utilizadosFinal";
            this.txt_utilizadosFinal.Size = new System.Drawing.Size(120, 20);
            this.txt_utilizadosFinal.TabIndex = 23;
            // 
            // txt_utilizadosInicial
            // 
            this.txt_utilizadosInicial.Location = new System.Drawing.Point(78, 157);
            this.txt_utilizadosInicial.Name = "txt_utilizadosInicial";
            this.txt_utilizadosInicial.Size = new System.Drawing.Size(120, 20);
            this.txt_utilizadosInicial.TabIndex = 22;
            // 
            // lbl_rangoUF
            // 
            this.lbl_rangoUF.AutoSize = true;
            this.lbl_rangoUF.Location = new System.Drawing.Point(36, 185);
            this.lbl_rangoUF.Name = "lbl_rangoUF";
            this.lbl_rangoUF.Size = new System.Drawing.Size(35, 13);
            this.lbl_rangoUF.TabIndex = 21;
            this.lbl_rangoUF.Text = "Final :";
            // 
            // lbl_rangoUI
            // 
            this.lbl_rangoUI.AutoSize = true;
            this.lbl_rangoUI.Location = new System.Drawing.Point(31, 159);
            this.lbl_rangoUI.Name = "lbl_rangoUI";
            this.lbl_rangoUI.Size = new System.Drawing.Size(40, 13);
            this.lbl_rangoUI.TabIndex = 20;
            this.lbl_rangoUI.Text = "Inicial :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Rangos Utilizados";
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
            this.groupBox3.Location = new System.Drawing.Point(661, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 141);
            this.groupBox3.TabIndex = 8;
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(287, 107);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = "Tmst Firma Env ";
            // 
            // dp_tmstFirma
            // 
            this.dp_tmstFirma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_tmstFirma.Location = new System.Drawing.Point(376, 104);
            this.dp_tmstFirma.Name = "dp_tmstFirma";
            this.dp_tmstFirma.Size = new System.Drawing.Size(100, 20);
            this.dp_tmstFirma.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_numSecEnvio);
            this.groupBox1.Controls.Add(this.txt_numResol);
            this.groupBox1.Controls.Add(this.dp_fechaFinal);
            this.groupBox1.Controls.Add(this.dp_fechaInicio);
            this.groupBox1.Controls.Add(this.dp_fechaResol);
            this.groupBox1.Controls.Add(this.txt_rutEnvia);
            this.groupBox1.Controls.Add(this.txt_rutEmisor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dp_tmstFirma);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 141);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caratula";
            // 
            // txt_numSecEnvio
            // 
            this.txt_numSecEnvio.Location = new System.Drawing.Point(376, 78);
            this.txt_numSecEnvio.Name = "txt_numSecEnvio";
            this.txt_numSecEnvio.Size = new System.Drawing.Size(44, 20);
            this.txt_numSecEnvio.TabIndex = 29;
            this.txt_numSecEnvio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_numResol
            // 
            this.txt_numResol.Location = new System.Drawing.Point(152, 104);
            this.txt_numResol.Name = "txt_numResol";
            this.txt_numResol.Size = new System.Drawing.Size(44, 20);
            this.txt_numResol.TabIndex = 28;
            this.txt_numResol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // dp_fechaFinal
            // 
            this.dp_fechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaFinal.Location = new System.Drawing.Point(376, 52);
            this.dp_fechaFinal.Name = "dp_fechaFinal";
            this.dp_fechaFinal.Size = new System.Drawing.Size(100, 20);
            this.dp_fechaFinal.TabIndex = 27;
            // 
            // dp_fechaInicio
            // 
            this.dp_fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaInicio.Location = new System.Drawing.Point(376, 26);
            this.dp_fechaInicio.Name = "dp_fechaInicio";
            this.dp_fechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dp_fechaInicio.TabIndex = 26;
            // 
            // dp_fechaResol
            // 
            this.dp_fechaResol.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_fechaResol.Location = new System.Drawing.Point(152, 78);
            this.dp_fechaResol.Name = "dp_fechaResol";
            this.dp_fechaResol.Size = new System.Drawing.Size(100, 20);
            this.dp_fechaResol.TabIndex = 25;
            // 
            // txt_rutEnvia
            // 
            this.txt_rutEnvia.Location = new System.Drawing.Point(152, 52);
            this.txt_rutEnvia.Name = "txt_rutEnvia";
            this.txt_rutEnvia.Size = new System.Drawing.Size(100, 20);
            this.txt_rutEnvia.TabIndex = 24;
            // 
            // txt_rutEmisor
            // 
            this.txt_rutEmisor.Location = new System.Drawing.Point(152, 26);
            this.txt_rutEmisor.Name = "txt_rutEmisor";
            this.txt_rutEmisor.Size = new System.Drawing.Size(100, 20);
            this.txt_rutEmisor.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Sec Envio ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fecha Final ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha de Inicio ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Numero de Resolución ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha de Resolución";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Rut Envia ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rut Emisor ";
            // 
            // txt_foliosAnulados
            // 
            this.txt_foliosAnulados.Location = new System.Drawing.Point(592, 82);
            this.txt_foliosAnulados.Name = "txt_foliosAnulados";
            this.txt_foliosAnulados.Size = new System.Drawing.Size(100, 20);
            this.txt_foliosAnulados.TabIndex = 52;
            this.txt_foliosAnulados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_foliosEmitidos
            // 
            this.txt_foliosEmitidos.Location = new System.Drawing.Point(592, 56);
            this.txt_foliosEmitidos.Name = "txt_foliosEmitidos";
            this.txt_foliosEmitidos.Size = new System.Drawing.Size(100, 20);
            this.txt_foliosEmitidos.TabIndex = 51;
            this.txt_foliosEmitidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_foliosUtilizados
            // 
            this.txt_foliosUtilizados.Location = new System.Drawing.Point(592, 30);
            this.txt_foliosUtilizados.Name = "txt_foliosUtilizados";
            this.txt_foliosUtilizados.Size = new System.Drawing.Size(100, 20);
            this.txt_foliosUtilizados.TabIndex = 50;
            this.txt_foliosUtilizados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_mntTotal
            // 
            this.txt_mntTotal.Location = new System.Drawing.Point(361, 82);
            this.txt_mntTotal.Name = "txt_mntTotal";
            this.txt_mntTotal.Size = new System.Drawing.Size(100, 20);
            this.txt_mntTotal.TabIndex = 49;
            this.txt_mntTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_mntExento
            // 
            this.txt_mntExento.Location = new System.Drawing.Point(361, 56);
            this.txt_mntExento.Name = "txt_mntExento";
            this.txt_mntExento.Size = new System.Drawing.Size(100, 20);
            this.txt_mntExento.TabIndex = 48;
            this.txt_mntExento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_tasaIva
            // 
            this.txt_tasaIva.Location = new System.Drawing.Point(361, 30);
            this.txt_tasaIva.Name = "txt_tasaIva";
            this.txt_tasaIva.Size = new System.Drawing.Size(100, 20);
            this.txt_tasaIva.TabIndex = 47;
            this.txt_tasaIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_mntIva
            // 
            this.txt_mntIva.Location = new System.Drawing.Point(152, 82);
            this.txt_mntIva.Name = "txt_mntIva";
            this.txt_mntIva.Size = new System.Drawing.Size(100, 20);
            this.txt_mntIva.TabIndex = 46;
            this.txt_mntIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_mntNeto
            // 
            this.txt_mntNeto.Location = new System.Drawing.Point(152, 56);
            this.txt_mntNeto.Name = "txt_mntNeto";
            this.txt_mntNeto.Size = new System.Drawing.Size(100, 20);
            this.txt_mntNeto.TabIndex = 45;
            this.txt_mntNeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txt_tipoDoc
            // 
            this.txt_tipoDoc.Location = new System.Drawing.Point(152, 30);
            this.txt_tipoDoc.Name = "txt_tipoDoc";
            this.txt_tipoDoc.Size = new System.Drawing.Size(100, 20);
            this.txt_tipoDoc.TabIndex = 44;
            this.txt_tipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Mnt IVA ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(492, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Folios Utilizados ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(493, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Folios Anulados ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(492, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Folios Emitidos ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(287, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Mnt Total ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Mnt Exento ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Tasa IVA ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Mnt Neto ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Tipo de Documento ";
            // 
            // GenerarRCOFInvalido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 581);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarRCOFInvalido";
            this.Text = "Generar RCOF Invalido";
            this.Load += new System.EventHandler(this.GenerarRCOFInvalido_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_resumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_anulados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_anuladosFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_anuladosInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_utilizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_utilizadosFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_utilizadosInicial)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_utilizados;
        private System.Windows.Forms.NumericUpDown txt_utilizadosFinal;
        private System.Windows.Forms.NumericUpDown txt_utilizadosInicial;
        private System.Windows.Forms.Label lbl_rangoUF;
        private System.Windows.Forms.Label lbl_rangoUI;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_agregarDetalles;
        private System.Windows.Forms.Button btn_agregarAnulados;
        private System.Windows.Forms.Button btn_agregarUtilizados;
        private System.Windows.Forms.DataGridView grid_anulados;
        private System.Windows.Forms.NumericUpDown txt_anuladosFinal;
        private System.Windows.Forms.NumericUpDown txt_anuladosInicial;
        private System.Windows.Forms.Label lbl_rangoAF;
        private System.Windows.Forms.Label lbl_rangoAI;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView grid_resumen;
        private System.Windows.Forms.Button btn_eliminarResumen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_cargarCertificado;
        private System.Windows.Forms.TextBox txt_passCertificado;
        private System.Windows.Forms.TextBox txt_rutCertificado;
        private System.Windows.Forms.TextBox txt_certificado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dp_tmstFirma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_numSecEnvio;
        private System.Windows.Forms.TextBox txt_numResol;
        private System.Windows.Forms.DateTimePicker dp_fechaFinal;
        private System.Windows.Forms.DateTimePicker dp_fechaInicio;
        private System.Windows.Forms.DateTimePicker dp_fechaResol;
        private System.Windows.Forms.TextBox txt_rutEnvia;
        private System.Windows.Forms.TextBox txt_rutEmisor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_foliosAnulados;
        private System.Windows.Forms.TextBox txt_foliosEmitidos;
        private System.Windows.Forms.TextBox txt_foliosUtilizados;
        private System.Windows.Forms.TextBox txt_mntTotal;
        private System.Windows.Forms.TextBox txt_mntExento;
        private System.Windows.Forms.TextBox txt_tasaIva;
        private System.Windows.Forms.TextBox txt_mntIva;
        private System.Windows.Forms.TextBox txt_mntNeto;
        private System.Windows.Forms.TextBox txt_tipoDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}