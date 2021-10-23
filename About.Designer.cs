namespace Text_Editor_Assignment_2
{
    partial class About
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
            this.content = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.aboutTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.AutoSize = true;
            this.content.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.ForeColor = System.Drawing.SystemColors.Highlight;
            this.content.Location = new System.Drawing.Point(206, 54);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(309, 32);
            this.content.TabIndex = 18;
            this.content.Text = "Magic Text Editor Inc.";
            // 
            // Ok
            // 
            this.Ok.BackColor = System.Drawing.SystemColors.Highlight;
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Ok.Location = new System.Drawing.Point(281, 330);
            this.Ok.Name = "Ok";
            this.Ok.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Ok.Size = new System.Drawing.Size(134, 41);
            this.Ok.TabIndex = 19;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = false;
            this.Ok.Click += new System.EventHandler(this.Login_Click_1);
            // 
            // aboutTextBox
            // 
            this.aboutTextBox.Location = new System.Drawing.Point(212, 143);
            this.aboutTextBox.Multiline = true;
            this.aboutTextBox.Name = "aboutTextBox";
            this.aboutTextBox.ReadOnly = true;
            this.aboutTextBox.Size = new System.Drawing.Size(286, 132);
            this.aboutTextBox.TabIndex = 20;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutTextBox);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.content);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label content;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TextBox aboutTextBox;
    }
}