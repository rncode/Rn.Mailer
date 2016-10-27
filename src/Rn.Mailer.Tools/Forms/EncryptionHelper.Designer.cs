namespace Rn.Mailer.Tools.Forms
{
    partial class EncryptionHelper
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
            this.rtb_salt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_pass = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_input = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_encoded = new System.Windows.Forms.RichTextBox();
            this.btn_encode = new System.Windows.Forms.Button();
            this.btn_decode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_salt
            // 
            this.rtb_salt.Location = new System.Drawing.Point(123, 12);
            this.rtb_salt.Name = "rtb_salt";
            this.rtb_salt.Size = new System.Drawing.Size(453, 57);
            this.rtb_salt.TabIndex = 0;
            this.rtb_salt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Salt:";
            // 
            // rtb_pass
            // 
            this.rtb_pass.Location = new System.Drawing.Point(123, 75);
            this.rtb_pass.Name = "rtb_pass";
            this.rtb_pass.Size = new System.Drawing.Size(453, 57);
            this.rtb_pass.TabIndex = 4;
            this.rtb_pass.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Pass:";
            // 
            // rtb_input
            // 
            this.rtb_input.Location = new System.Drawing.Point(123, 138);
            this.rtb_input.Name = "rtb_input";
            this.rtb_input.Size = new System.Drawing.Size(453, 79);
            this.rtb_input.TabIndex = 6;
            this.rtb_input.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Encoded:";
            // 
            // rtb_encoded
            // 
            this.rtb_encoded.Location = new System.Drawing.Point(123, 223);
            this.rtb_encoded.Name = "rtb_encoded";
            this.rtb_encoded.Size = new System.Drawing.Size(453, 79);
            this.rtb_encoded.TabIndex = 10;
            this.rtb_encoded.Text = "";
            // 
            // btn_encode
            // 
            this.btn_encode.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_encode.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_encode.Location = new System.Drawing.Point(123, 308);
            this.btn_encode.Name = "btn_encode";
            this.btn_encode.Size = new System.Drawing.Size(221, 64);
            this.btn_encode.TabIndex = 11;
            this.btn_encode.Text = "Encode";
            this.btn_encode.UseVisualStyleBackColor = true;
            this.btn_encode.Click += new System.EventHandler(this.btn_encode_Click);
            // 
            // btn_decode
            // 
            this.btn_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decode.ForeColor = System.Drawing.Color.Red;
            this.btn_decode.Location = new System.Drawing.Point(355, 308);
            this.btn_decode.Name = "btn_decode";
            this.btn_decode.Size = new System.Drawing.Size(221, 64);
            this.btn_decode.TabIndex = 12;
            this.btn_decode.Text = "Decode";
            this.btn_decode.UseVisualStyleBackColor = true;
            this.btn_decode.Click += new System.EventHandler(this.btn_decode_Click);
            // 
            // EncryptionHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 384);
            this.Controls.Add(this.btn_decode);
            this.Controls.Add(this.btn_encode);
            this.Controls.Add(this.rtb_encoded);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtb_pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_salt);
            this.Name = "EncryptionHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rn.Mailer Encryption Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_salt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_encoded;
        private System.Windows.Forms.Button btn_encode;
        private System.Windows.Forms.Button btn_decode;
    }
}