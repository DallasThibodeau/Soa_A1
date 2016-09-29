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
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.ReturnLabel = new System.Windows.Forms.Label();
            this.gpbParameters = new System.Windows.Forms.GroupBox();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.txtRequestResponse = new System.Windows.Forms.TextBox();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
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
            this.ddlWebService.Location = new System.Drawing.Point(142, 13);
            this.ddlWebService.Name = "ddlWebService";
            this.ddlWebService.Size = new System.Drawing.Size(175, 21);
            this.ddlWebService.TabIndex = 1;
            this.ddlWebService.SelectedIndexChanged += new System.EventHandler(this.ddlWebService_SelectedIndexChanged);
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
            this.ddlWebMethod.Location = new System.Drawing.Point(142, 56);
            this.ddlWebMethod.Name = "ddlWebMethod";
            this.ddlWebMethod.Size = new System.Drawing.Size(175, 21);
            this.ddlWebMethod.TabIndex = 3;
            this.ddlWebMethod.SelectedIndexChanged += new System.EventHandler(this.ddlWebMethod_SelectedIndexChanged);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendRequest.Location = new System.Drawing.Point(226, 113);
            this.btnSendRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(91, 24);
            this.btnSendRequest.TabIndex = 4;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
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
            // gpbParameters
            // 
            this.gpbParameters.Controls.Add(this.dgvParameters);
            this.gpbParameters.Location = new System.Drawing.Point(340, 12);
            this.gpbParameters.Name = "gpbParameters";
            this.gpbParameters.Size = new System.Drawing.Size(470, 160);
            this.gpbParameters.TabIndex = 8;
            this.gpbParameters.TabStop = false;
            this.gpbParameters.Text = "Parameters";
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterName,
            this.ParameterValue,
            this.DataType,
            this.Required});
            this.dgvParameters.Location = new System.Drawing.Point(10, 21);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new System.Drawing.Size(445, 125);
            this.dgvParameters.TabIndex = 0;
            this.dgvParameters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameters_CellValueChanged);
            // 
            // txtRequestResponse
            // 
            this.txtRequestResponse.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequestResponse.Location = new System.Drawing.Point(10, 179);
            this.txtRequestResponse.Multiline = true;
            this.txtRequestResponse.Name = "txtRequestResponse";
            this.txtRequestResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestResponse.Size = new System.Drawing.Size(800, 261);
            this.txtRequestResponse.TabIndex = 9;
            // 
            // ParameterName
            // 
            this.ParameterName.HeaderText = "Parameter Name";
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.ReadOnly = true;
            // 
            // ParameterValue
            // 
            this.ParameterValue.HeaderText = "Value";
            this.ParameterValue.Name = "ParameterValue";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Data Type";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            // 
            // Required
            // 
            this.Required.HeaderText = "Required";
            this.Required.Name = "Required";
            this.Required.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.txtRequestResponse);
            this.Controls.Add(this.gpbParameters);
            this.Controls.Add(this.ReturnLabel);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.ddlWebMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlWebService);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SOA A1 - William Boldt and Dallas Thibodeau";
            this.gpbParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlWebService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlWebMethod;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.Label ReturnLabel;
        private System.Windows.Forms.GroupBox gpbParameters;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.TextBox txtRequestResponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Required;
    }
}

