namespace MailerTools.Tools
{
    partial class PasswordEncrypter
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
            this.encryptButton = new System.Windows.Forms.Button();
            this.passIn = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passOut = new System.Windows.Forms.RichTextBox();
            this.rtbEncKey = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(102, 318);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(471, 55);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // passIn
            // 
            this.passIn.Location = new System.Drawing.Point(102, 12);
            this.passIn.Name = "passIn";
            this.passIn.Size = new System.Drawing.Size(471, 96);
            this.passIn.TabIndex = 2;
            this.passIn.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
            // 
            // passOut
            // 
            this.passOut.Location = new System.Drawing.Point(102, 216);
            this.passOut.Name = "passOut";
            this.passOut.Size = new System.Drawing.Size(471, 96);
            this.passOut.TabIndex = 5;
            this.passOut.Text = "";
            // 
            // rtbEncKey
            // 
            this.rtbEncKey.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.rtbEncKey.Location = new System.Drawing.Point(102, 114);
            this.rtbEncKey.Name = "rtbEncKey";
            this.rtbEncKey.Size = new System.Drawing.Size(471, 96);
            this.rtbEncKey.TabIndex = 6;
            this.rtbEncKey.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key";
            // 
            // PasswordEncrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbEncKey);
            this.Controls.Add(this.passOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passIn);
            this.Controls.Add(this.encryptButton);
            this.Name = "PasswordEncrypter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Encrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.RichTextBox passIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox passOut;
        private System.Windows.Forms.RichTextBox rtbEncKey;
        private System.Windows.Forms.Label label3;
    }
}