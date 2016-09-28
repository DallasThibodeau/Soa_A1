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
            this.GoButton = new System.Windows.Forms.Button();
            this.ReturnLabel = new System.Windows.Forms.Label();
            this.Argument = new System.Windows.Forms.Label();
            this.argumentBox = new System.Windows.Forms.TextBox();
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
            "Number Conversions"});
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
            "Numbers to Words"});
            this.ddlWebMethod.Location = new System.Drawing.Point(142, 56);
            this.ddlWebMethod.Name = "ddlWebMethod";
            this.ddlWebMethod.Size = new System.Drawing.Size(146, 21);
            this.ddlWebMethod.TabIndex = 3;
            // 
            // GoButton
            // 
            this.GoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoButton.Location = new System.Drawing.Point(195, 145);
            this.GoButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(91, 24);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "Send Request";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // ReturnLabel
            // 
            this.ReturnLabel.AutoSize = true;
            this.ReturnLabel.Location = new System.Drawing.Point(13, 178);
            this.ReturnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ReturnLabel.Name = "ReturnLabel";
            this.ReturnLabel.Size = new System.Drawing.Size(0, 13);
            this.ReturnLabel.TabIndex = 5;
            // 
            // Argument
            // 
            this.Argument.AutoSize = true;
            this.Argument.Location = new System.Drawing.Point(16, 110);
            this.Argument.Name = "Argument";
            this.Argument.Size = new System.Drawing.Size(55, 13);
            this.Argument.TabIndex = 6;
            this.Argument.Text = "Argument:";
            // 
            // argumentBox
            // 
            this.argumentBox.Location = new System.Drawing.Point(142, 106);
            this.argumentBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.argumentBox.Name = "argumentBox";
            this.argumentBox.Size = new System.Drawing.Size(146, 20);
            this.argumentBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 361);
            this.Controls.Add(this.argumentBox);
            this.Controls.Add(this.Argument);
            this.Controls.Add(this.ReturnLabel);
            this.Controls.Add(this.GoButton);
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
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label ReturnLabel;
        private System.Windows.Forms.Label Argument;
        private System.Windows.Forms.TextBox argumentBox;
    }
}

