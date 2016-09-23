namespace SOA_A1
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlWebService = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlWebMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the Web Service:";
            // 
            // ddlWebService
            // 
            this.ddlWebService.FormattingEnabled = true;
            this.ddlWebService.Items.AddRange(new object[] {
            "Test 1",
            "Last test"});
            this.ddlWebService.Location = new System.Drawing.Point(142, 13);
            this.ddlWebService.Name = "ddlWebService";
            this.ddlWebService.Size = new System.Drawing.Size(146, 21);
            this.ddlWebService.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the Method:";
            // 
            // ddlWebMethod
            // 
            this.ddlWebMethod.FormattingEnabled = true;
            this.ddlWebMethod.Items.AddRange(new object[] {
            "Method 1",
            "Method 2"});
            this.ddlWebMethod.Location = new System.Drawing.Point(142, 56);
            this.ddlWebMethod.Name = "ddlWebMethod";
            this.ddlWebMethod.Size = new System.Drawing.Size(146, 21);
            this.ddlWebMethod.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 281);
            this.Controls.Add(this.ddlWebMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlWebService);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SOA A1 - William Boldt and Dallas Thibodeau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlWebService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlWebMethod;
    }
}

