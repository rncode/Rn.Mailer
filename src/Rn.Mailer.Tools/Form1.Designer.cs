namespace Rn.Mailer.Tools
{
    partial class Form1
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
            this.btnEncryptionHelper = new System.Windows.Forms.Button();
            this.btnGuidGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEncryptionHelper
            // 
            this.btnEncryptionHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptionHelper.Location = new System.Drawing.Point(12, 12);
            this.btnEncryptionHelper.Name = "btnEncryptionHelper";
            this.btnEncryptionHelper.Size = new System.Drawing.Size(510, 56);
            this.btnEncryptionHelper.TabIndex = 0;
            this.btnEncryptionHelper.Text = "Encryption Helper";
            this.btnEncryptionHelper.UseVisualStyleBackColor = true;
            this.btnEncryptionHelper.Click += new System.EventHandler(this.btnEncryptionHelper_Click);
            // 
            // btnGuidGen
            // 
            this.btnGuidGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuidGen.Location = new System.Drawing.Point(12, 74);
            this.btnGuidGen.Name = "btnGuidGen";
            this.btnGuidGen.Size = new System.Drawing.Size(510, 56);
            this.btnGuidGen.TabIndex = 1;
            this.btnGuidGen.Text = "GUID Generator";
            this.btnGuidGen.UseVisualStyleBackColor = true;
            this.btnGuidGen.Click += new System.EventHandler(this.btnGuidGen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 312);
            this.Controls.Add(this.btnGuidGen);
            this.Controls.Add(this.btnEncryptionHelper);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rn.Mailer Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEncryptionHelper;
        private System.Windows.Forms.Button btnGuidGen;
    }
}

