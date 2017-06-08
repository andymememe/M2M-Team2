namespace SimulateSensor
{
    partial class UrlForm
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
            System.Windows.Forms.Label label1;
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_yes = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 12);
            label1.TabIndex = 0;
            label1.Text = "New Url : ";
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(71, 31);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(271, 22);
            this.textBox_url.TabIndex = 1;
            // 
            // button_yes
            // 
            this.button_yes.Location = new System.Drawing.Point(267, 68);
            this.button_yes.Name = "button_yes";
            this.button_yes.Size = new System.Drawing.Size(75, 23);
            this.button_yes.TabIndex = 2;
            this.button_yes.Text = "Yes";
            this.button_yes.UseVisualStyleBackColor = true;
            // 
            // button_no
            // 
            this.button_no.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_no.Location = new System.Drawing.Point(186, 68);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(75, 23);
            this.button_no.TabIndex = 3;
            this.button_no.Text = "No";
            this.button_no.UseVisualStyleBackColor = true;
            // 
            // UrlForm
            // 
            this.AcceptButton = this.button_yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_no;
            this.ClientSize = new System.Drawing.Size(354, 103);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_yes);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlForm";
            this.Text = "Modify Url";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button button_yes;
        private System.Windows.Forms.Button button_no;
    }
}