namespace Rn.Mailer.Tools.Forms
{
    partial class GuidGen
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_numGuids = new System.Windows.Forms.ComboBox();
            this.cb_uppercase = new System.Windows.Forms.CheckBox();
            this.cb_noDashes = new System.Windows.Forms.CheckBox();
            this.cb_singleLine = new System.Windows.Forms.CheckBox();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.btn_genGuids = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# of GUIDS:";
            // 
            // cb_numGuids
            // 
            this.cb_numGuids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_numGuids.FormattingEnabled = true;
            this.cb_numGuids.Location = new System.Drawing.Point(84, 19);
            this.cb_numGuids.Name = "cb_numGuids";
            this.cb_numGuids.Size = new System.Drawing.Size(532, 21);
            this.cb_numGuids.TabIndex = 6;
            // 
            // cb_uppercase
            // 
            this.cb_uppercase.AutoSize = true;
            this.cb_uppercase.Location = new System.Drawing.Point(84, 46);
            this.cb_uppercase.Name = "cb_uppercase";
            this.cb_uppercase.Size = new System.Drawing.Size(113, 17);
            this.cb_uppercase.TabIndex = 7;
            this.cb_uppercase.Text = "ALL UPPERCASE";
            this.cb_uppercase.UseVisualStyleBackColor = true;
            // 
            // cb_noDashes
            // 
            this.cb_noDashes.AutoSize = true;
            this.cb_noDashes.Location = new System.Drawing.Point(84, 69);
            this.cb_noDashes.Name = "cb_noDashes";
            this.cb_noDashes.Size = new System.Drawing.Size(117, 17);
            this.cb_noDashes.TabIndex = 8;
            this.cb_noDashes.Text = "Remove Dashes (-)";
            this.cb_noDashes.UseVisualStyleBackColor = true;
            // 
            // cb_singleLine
            // 
            this.cb_singleLine.AutoSize = true;
            this.cb_singleLine.Location = new System.Drawing.Point(84, 92);
            this.cb_singleLine.Name = "cb_singleLine";
            this.cb_singleLine.Size = new System.Drawing.Size(137, 17);
            this.cb_singleLine.TabIndex = 9;
            this.cb_singleLine.Text = "Join all GUIDS together";
            this.cb_singleLine.UseVisualStyleBackColor = true;
            // 
            // rtb_output
            // 
            this.rtb_output.Location = new System.Drawing.Point(15, 115);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(601, 157);
            this.rtb_output.TabIndex = 10;
            this.rtb_output.Text = "";
            // 
            // btn_genGuids
            // 
            this.btn_genGuids.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_genGuids.ForeColor = System.Drawing.Color.Green;
            this.btn_genGuids.Location = new System.Drawing.Point(15, 278);
            this.btn_genGuids.Name = "btn_genGuids";
            this.btn_genGuids.Size = new System.Drawing.Size(601, 57);
            this.btn_genGuids.TabIndex = 11;
            this.btn_genGuids.Text = "Generate GUID(s)";
            this.btn_genGuids.UseVisualStyleBackColor = true;
            this.btn_genGuids.Click += new System.EventHandler(this.btn_genGuids_Click);
            // 
            // GuidGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 347);
            this.Controls.Add(this.btn_genGuids);
            this.Controls.Add(this.rtb_output);
            this.Controls.Add(this.cb_singleLine);
            this.Controls.Add(this.cb_noDashes);
            this.Controls.Add(this.cb_uppercase);
            this.Controls.Add(this.cb_numGuids);
            this.Controls.Add(this.label1);
            this.Name = "GuidGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUID Generator";
            this.Load += new System.EventHandler(this.GuidGen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_numGuids;
        private System.Windows.Forms.CheckBox cb_uppercase;
        private System.Windows.Forms.CheckBox cb_noDashes;
        private System.Windows.Forms.CheckBox cb_singleLine;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.Button btn_genGuids;
    }
}