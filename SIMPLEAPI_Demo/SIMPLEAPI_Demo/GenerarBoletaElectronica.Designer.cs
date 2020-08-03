namespace SIMPLEAPI_Demo
{
    partial class GenerarBoletaElectronica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numericFolio = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.botonGenerar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkUnidad = new System.Windows.Forms.CheckBox();
            this.numericPrecio = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.botonAgregarLinea = new System.Windows.Forms.Button();
            this.checkAfecto = new System.Windows.Forms.CheckBox();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridResultados = new System.Windows.Forms.DataGridView();
            this.gridNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCantidadProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAfecto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.umedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.numericCasoPrueba = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericFolio)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCasoPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // numericFolio
            // 
            this.numericFolio.Location = new System.Drawing.Point(196, 9);
            this.numericFolio.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericFolio.Name = "numericFolio";
            this.numericFolio.Size = new System.Drawing.Size(45, 20);
            this.numericFolio.TabIndex = 13;
            this.numericFolio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Folio:";
            // 
            // botonGenerar
            // 
            this.botonGenerar.Image = global::SIMPLEAPI_Demo.Properties.Resources.Guardar_32;
            this.botonGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonGenerar.Location = new System.Drawing.Point(469, 273);
            this.botonGenerar.Name = "botonGenerar";
            this.botonGenerar.Size = new System.Drawing.Size(120, 38);
            this.botonGenerar.TabIndex = 11;
            this.botonGenerar.Text = "Generar boleta";
            this.botonGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonGenerar.UseVisualStyleBackColor = true;
            this.botonGenerar.Click += new System.EventHandler(this.botonGenerar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkUnidad);
            this.groupBox2.Controls.Add(this.numericPrecio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.botonAgregarLinea);
            this.groupBox2.Controls.Add(this.checkAfecto);
            this.groupBox2.Controls.Add(this.numericCantidad);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 59);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo Producto";
            // 
            // checkUnidad
            // 
            this.checkUnidad.AutoSize = true;
            this.checkUnidad.Location = new System.Drawing.Point(462, 27);
            this.checkUnidad.Name = "checkUnidad";
            this.checkUnidad.Size = new System.Drawing.Size(60, 17);
            this.checkUnidad.TabIndex = 16;
            this.checkUnidad.Text = "Unidad";
            this.checkUnidad.UseVisualStyleBackColor = true;
            // 
            // numericPrecio
            // 
            this.numericPrecio.Location = new System.Drawing.Point(338, 26);
            this.numericPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericPrecio.Name = "numericPrecio";
            this.numericPrecio.Size = new System.Drawing.Size(55, 20);
            this.numericPrecio.TabIndex = 9;
            this.numericPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio:";
            // 
            // botonAgregarLinea
            // 
            this.botonAgregarLinea.Location = new System.Drawing.Point(532, 19);
            this.botonAgregarLinea.Name = "botonAgregarLinea";
            this.botonAgregarLinea.Size = new System.Drawing.Size(39, 30);
            this.botonAgregarLinea.TabIndex = 15;
            this.botonAgregarLinea.Text = " + ";
            this.botonAgregarLinea.UseVisualStyleBackColor = true;
            this.botonAgregarLinea.Click += new System.EventHandler(this.botonAgregarLinea_Click);
            // 
            // checkAfecto
            // 
            this.checkAfecto.AutoSize = true;
            this.checkAfecto.Checked = true;
            this.checkAfecto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAfecto.Location = new System.Drawing.Point(399, 27);
            this.checkAfecto.Name = "checkAfecto";
            this.checkAfecto.Size = new System.Drawing.Size(57, 17);
            this.checkAfecto.TabIndex = 12;
            this.checkAfecto.Text = "Afecto";
            this.checkAfecto.UseVisualStyleBackColor = true;
            // 
            // numericCantidad
            // 
            this.numericCantidad.DecimalPlaces = 1;
            this.numericCantidad.Location = new System.Drawing.Point(242, 25);
            this.numericCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(45, 20);
            this.numericCantidad.TabIndex = 5;
            this.numericCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(59, 25);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(119, 20);
            this.textNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridResultados);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 170);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // gridResultados
            // 
            this.gridResultados.AllowUserToAddRows = false;
            this.gridResultados.AllowUserToDeleteRows = false;
            this.gridResultados.AllowUserToResizeColumns = false;
            this.gridResultados.AllowUserToResizeRows = false;
            this.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridNombreProducto,
            this.gridCantidadProducto,
            this.gridPrecio,
            this.gridTotal,
            this.gridAfecto,
            this.umedida,
            this.gridEliminar});
            this.gridResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResultados.Location = new System.Drawing.Point(3, 16);
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.ReadOnly = true;
            this.gridResultados.RowHeadersWidth = 25;
            this.gridResultados.Size = new System.Drawing.Size(571, 151);
            this.gridResultados.TabIndex = 0;
            this.gridResultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResultados_CellClick);
            // 
            // gridNombreProducto
            // 
            this.gridNombreProducto.DataPropertyName = "Nombre";
            this.gridNombreProducto.HeaderText = "Nombre";
            this.gridNombreProducto.Name = "gridNombreProducto";
            this.gridNombreProducto.ReadOnly = true;
            this.gridNombreProducto.Width = 200;
            // 
            // gridCantidadProducto
            // 
            this.gridCantidadProducto.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Format = "N1";
            this.gridCantidadProducto.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridCantidadProducto.HeaderText = "Cantidad";
            this.gridCantidadProducto.Name = "gridCantidadProducto";
            this.gridCantidadProducto.ReadOnly = true;
            this.gridCantidadProducto.Width = 55;
            // 
            // gridPrecio
            // 
            this.gridPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle2.Format = "N0";
            this.gridPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPrecio.HeaderText = "Precio";
            this.gridPrecio.Name = "gridPrecio";
            this.gridPrecio.ReadOnly = true;
            this.gridPrecio.Width = 65;
            // 
            // gridTotal
            // 
            this.gridTotal.DataPropertyName = "Total";
            dataGridViewCellStyle3.Format = "N0";
            this.gridTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridTotal.HeaderText = "Total";
            this.gridTotal.Name = "gridTotal";
            this.gridTotal.ReadOnly = true;
            this.gridTotal.Width = 70;
            // 
            // gridAfecto
            // 
            this.gridAfecto.DataPropertyName = "Afecto";
            this.gridAfecto.HeaderText = "Afecto";
            this.gridAfecto.Name = "gridAfecto";
            this.gridAfecto.ReadOnly = true;
            this.gridAfecto.Width = 45;
            // 
            // umedida
            // 
            this.umedida.DataPropertyName = "UnidadMedida";
            this.umedida.HeaderText = "Unidad";
            this.umedida.Name = "umedida";
            this.umedida.ReadOnly = true;
            this.umedida.Width = 45;
            // 
            // gridEliminar
            // 
            this.gridEliminar.HeaderText = "Elim.";
            this.gridEliminar.Name = "gridEliminar";
            this.gridEliminar.ReadOnly = true;
            this.gridEliminar.Width = 40;
            // 
            // numericCasoPrueba
            // 
            this.numericCasoPrueba.Location = new System.Drawing.Point(107, 9);
            this.numericCasoPrueba.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericCasoPrueba.Name = "numericCasoPrueba";
            this.numericCasoPrueba.Size = new System.Drawing.Size(45, 20);
            this.numericCasoPrueba.TabIndex = 8;
            this.numericCasoPrueba.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Caso de prueba:";
            // 
            // GenerarBoletaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 316);
            this.Controls.Add(this.numericFolio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botonGenerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericCasoPrueba);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "GenerarBoletaElectronica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.GenerarBoletaElectronica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericFolio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCasoPrueba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericFolio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button botonGenerar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkUnidad;
        private System.Windows.Forms.NumericUpDown numericPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botonAgregarLinea;
        private System.Windows.Forms.CheckBox checkAfecto;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCantidadProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridAfecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn umedida;
        private System.Windows.Forms.DataGridViewImageColumn gridEliminar;
        private System.Windows.Forms.NumericUpDown numericCasoPrueba;
        private System.Windows.Forms.Label label1;
    }
}