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
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the Web Service:";
            // 
            // ddlWebService
            // 
            this.ddlWebService.FormattingEnabled = true;
            this.ddlWebService.Items.AddRange(new object[] {
            "Number Conversions"});
            this.ddlWebService.Location = new System.Drawing.Point(189, 16);
            this.ddlWebService.Margin = new System.Windows.Forms.Padding(4);
            this.ddlWebService.Name = "ddlWebService";
            this.ddlWebService.Size = new System.Drawing.Size(193, 24);
            this.ddlWebService.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the Method:";
            // 
            // ddlWebMethod
            // 
            this.ddlWebMethod.FormattingEnabled = true;
            this.ddlWebMethod.Items.AddRange(new object[] {
            "Numbers to Words"});
            this.ddlWebMethod.Location = new System.Drawing.Point(189, 69);
            this.ddlWebMethod.Margin = new System.Windows.Forms.Padding(4);
            this.ddlWebMethod.Name = "ddlWebMethod";
            this.ddlWebMethod.Size = new System.Drawing.Size(193, 24);
            this.ddlWebMethod.TabIndex = 3;
            // 
            // GoButton
            // 
            this.GoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoButton.Location = new System.Drawing.Point(307, 178);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 23);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // ReturnLabel
            // 
            this.ReturnLabel.AutoSize = true;
            this.ReturnLabel.Location = new System.Drawing.Point(17, 219);
            this.ReturnLabel.Name = "ReturnLabel";
            this.ReturnLabel.Size = new System.Drawing.Size(0, 17);
            this.ReturnLabel.TabIndex = 5;
            // 
            // Argument
            // 
            this.Argument.AutoSize = true;
            this.Argument.Location = new System.Drawing.Point(21, 136);
            this.Argument.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Argument.Name = "Argument";
            this.Argument.Size = new System.Drawing.Size(73, 17);
            this.Argument.TabIndex = 6;
            this.Argument.Text = "Argument:";
            // 
            // argumentBox
            // 
            this.argumentBox.Location = new System.Drawing.Point(189, 130);
            this.argumentBox.Name = "argumentBox";
            this.argumentBox.Size = new System.Drawing.Size(193, 22);
            this.argumentBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 346);
            this.Controls.Add(this.argumentBox);
            this.Controls.Add(this.Argument);
            this.Controls.Add(this.ReturnLabel);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ddlWebMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlWebService);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
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

