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
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequestResponse = new System.Windows.Forms.TextBox();
            this.XMLGridView = new System.Windows.Forms.DataGridView();
            this.gpbParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMLGridView)).BeginInit();
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
            this.ddlWebService.Location = new System.Drawing.Point(189, 16);
            this.ddlWebService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlWebService.Name = "ddlWebService";
            this.ddlWebService.Size = new System.Drawing.Size(232, 24);
            this.ddlWebService.TabIndex = 1;
            this.ddlWebService.SelectedIndexChanged += new System.EventHandler(this.ddlWebService_SelectedIndexChanged);
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
            this.ddlWebMethod.Location = new System.Drawing.Point(189, 69);
            this.ddlWebMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlWebMethod.Name = "ddlWebMethod";
            this.ddlWebMethod.Size = new System.Drawing.Size(232, 24);
            this.ddlWebMethod.TabIndex = 3;
            this.ddlWebMethod.SelectedIndexChanged += new System.EventHandler(this.ddlWebMethod_SelectedIndexChanged);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendRequest.Location = new System.Drawing.Point(301, 139);
            this.btnSendRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(121, 30);
            this.btnSendRequest.TabIndex = 4;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // ReturnLabel
            // 
            this.ReturnLabel.AutoSize = true;
            this.ReturnLabel.Location = new System.Drawing.Point(17, 219);
            this.ReturnLabel.Name = "ReturnLabel";
            this.ReturnLabel.Size = new System.Drawing.Size(0, 17);
            this.ReturnLabel.TabIndex = 5;
            // 
            // gpbParameters
            // 
            this.gpbParameters.Controls.Add(this.dgvParameters);
            this.gpbParameters.Location = new System.Drawing.Point(453, 15);
            this.gpbParameters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbParameters.Name = "gpbParameters";
            this.gpbParameters.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbParameters.Size = new System.Drawing.Size(627, 197);
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
            this.dgvParameters.Location = new System.Drawing.Point(13, 26);
            this.dgvParameters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new System.Drawing.Size(593, 154);
            this.dgvParameters.TabIndex = 0;
            this.dgvParameters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameters_CellValueChanged);
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
            // txtRequestResponse
            // 
            this.txtRequestResponse.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequestResponse.Location = new System.Drawing.Point(13, 220);
            this.txtRequestResponse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRequestResponse.Multiline = true;
            this.txtRequestResponse.Name = "txtRequestResponse";
            this.txtRequestResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestResponse.Size = new System.Drawing.Size(516, 320);
            this.txtRequestResponse.TabIndex = 9;
            // 
            // XMLGridView
            // 
            this.XMLGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XMLGridView.Location = new System.Drawing.Point(537, 220);
            this.XMLGridView.Name = "XMLGridView";
            this.XMLGridView.RowTemplate.Height = 24;
            this.XMLGridView.Size = new System.Drawing.Size(534, 320);
            this.XMLGridView.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 567);
            this.Controls.Add(this.XMLGridView);
            this.Controls.Add(this.txtRequestResponse);
            this.Controls.Add(this.gpbParameters);
            this.Controls.Add(this.ReturnLabel);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.ddlWebMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlWebService);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "SOA A1 - William Boldt and Dallas Thibodeau";
            this.gpbParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMLGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView XMLGridView;
    }
}

