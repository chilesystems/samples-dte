
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
            this.SuspendLayout();
            // 
            // txt_jsonPdf
            // 
            this.txt_jsonPdf.Location = new System.Drawing.Point(118, 78);
            this.txt_jsonPdf.Multiline = true;
            this.txt_jsonPdf.Name = "txt_jsonPdf";
            this.txt_jsonPdf.Size = new System.Drawing.Size(566, 279);
            this.txt_jsonPdf.TabIndex = 0;
            // 
            // JsonPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_jsonPdf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JsonPdf";
            this.Text = "Generador Json PDF";
            this.Load += new System.EventHandler(this.JsonPdf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_jsonPdf;
    }
}