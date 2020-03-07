namespace SIMPLEAPI_Demo
{
    partial class MuestraImpresa
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.botonCargarDTE = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FacturaElectronicaPlantilla1 = new SIMPLEAPI_Demo.Reports.FacturaElectronicaPlantilla();
            this.radioCedible = new System.Windows.Forms.RadioButton();
            this.radioOriginal = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualización Impresa";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 16);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(861, 465);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // botonCargarDTE
            // 
            this.botonCargarDTE.Location = new System.Drawing.Point(804, 12);
            this.botonCargarDTE.Name = "botonCargarDTE";
            this.botonCargarDTE.Size = new System.Drawing.Size(75, 23);
            this.botonCargarDTE.TabIndex = 4;
            this.botonCargarDTE.Text = "Cargar DTE";
            this.botonCargarDTE.UseVisualStyleBackColor = true;
            this.botonCargarDTE.Click += new System.EventHandler(this.botonCargarDTE_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioCedible
            // 
            this.radioCedible.AutoSize = true;
            this.radioCedible.Location = new System.Drawing.Point(738, 15);
            this.radioCedible.Name = "radioCedible";
            this.radioCedible.Size = new System.Drawing.Size(60, 17);
            this.radioCedible.TabIndex = 6;
            this.radioCedible.TabStop = true;
            this.radioCedible.Text = "Cedible";
            this.radioCedible.UseVisualStyleBackColor = true;
            // 
            // radioOriginal
            // 
            this.radioOriginal.AutoSize = true;
            this.radioOriginal.Checked = true;
            this.radioOriginal.Location = new System.Drawing.Point(672, 15);
            this.radioOriginal.Name = "radioOriginal";
            this.radioOriginal.Size = new System.Drawing.Size(60, 17);
            this.radioOriginal.TabIndex = 5;
            this.radioOriginal.TabStop = true;
            this.radioOriginal.Text = "Original";
            this.radioOriginal.UseVisualStyleBackColor = true;
            // 
            // MuestraImpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 537);
            this.Controls.Add(this.radioCedible);
            this.Controls.Add(this.radioOriginal);
            this.Controls.Add(this.botonCargarDTE);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MuestraImpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MuestraImpresa";
            this.Load += new System.EventHandler(this.MuestraImpresa_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button botonCargarDTE;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Reports.FacturaElectronicaPlantilla FacturaElectronicaPlantilla1;
        private Reports.FacturaElectronicaPlantillaCedible FacturaElectronicaPlantillaCedible1;
        private System.Windows.Forms.RadioButton radioCedible;
        private System.Windows.Forms.RadioButton radioOriginal;
    }
}