
namespace DemoEndPoints.GenerarJson
{
    partial class JsonEntrada
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
            this.txt_jsonEntrada = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_jsonEntrada
            // 
            this.txt_jsonEntrada.Location = new System.Drawing.Point(126, 78);
            this.txt_jsonEntrada.Multiline = true;
            this.txt_jsonEntrada.Name = "txt_jsonEntrada";
            this.txt_jsonEntrada.Size = new System.Drawing.Size(528, 277);
            this.txt_jsonEntrada.TabIndex = 0;
            // 
            // JsonEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_jsonEntrada);
            this.Name = "JsonEntrada";
            this.Text = "JsonEntrada";
            this.Load += new System.EventHandler(this.JsonEntrada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_jsonEntrada;
    }
}