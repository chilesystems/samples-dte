
namespace DemoEndPoints.GenerarJson
{
    partial class JsonEnvio
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
            this.txt_jsonEnvio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_jsonEnvio
            // 
            this.txt_jsonEnvio.Location = new System.Drawing.Point(69, 39);
            this.txt_jsonEnvio.Multiline = true;
            this.txt_jsonEnvio.Name = "txt_jsonEnvio";
            this.txt_jsonEnvio.Size = new System.Drawing.Size(666, 360);
            this.txt_jsonEnvio.TabIndex = 0;
            // 
            // JsonEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_jsonEnvio);
            this.Name = "JsonEnvio";
            this.Text = "JsonEnvio";
            this.Load += new System.EventHandler(this.JsonEnvio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_jsonEnvio;
    }
}