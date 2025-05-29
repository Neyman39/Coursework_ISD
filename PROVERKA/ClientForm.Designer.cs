namespace PROVERKA
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInsuranceTypeTitle = new System.Windows.Forms.Label();
            this.lblInsuranceType = new System.Windows.Forms.Label();
            this.lblContractDateTitle = new System.Windows.Forms.Label();
            this.lblContractDate = new System.Windows.Forms.Label();
            this.lblExpiryDateTitle = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblAmountTitle = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBranchTitle = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblAgentTitle = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(218, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ваш договор страхования";

            // lblInsuranceTypeTitle
            this.lblInsuranceTypeTitle.AutoSize = true;
            this.lblInsuranceTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblInsuranceTypeTitle.Location = new System.Drawing.Point(20, 60);
            this.lblInsuranceTypeTitle.Name = "lblInsuranceTypeTitle";
            this.lblInsuranceTypeTitle.Size = new System.Drawing.Size(148, 17);
            this.lblInsuranceTypeTitle.TabIndex = 1;
            this.lblInsuranceTypeTitle.Text = "Тип страхования:";

            // lblInsuranceType
            this.lblInsuranceType.AutoSize = true;
            this.lblInsuranceType.Location = new System.Drawing.Point(180, 62);
            this.lblInsuranceType.Name = "lblInsuranceType";
            this.lblInsuranceType.Size = new System.Drawing.Size(35, 13);
            this.lblInsuranceType.TabIndex = 2;
            this.lblInsuranceType.Text = "label1";

            // lblContractDateTitle
            this.lblContractDateTitle.AutoSize = true;
            this.lblContractDateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblContractDateTitle.Location = new System.Drawing.Point(20, 90);
            this.lblContractDateTitle.Name = "lblContractDateTitle";
            this.lblContractDateTitle.Size = new System.Drawing.Size(130, 17);
            this.lblContractDateTitle.TabIndex = 3;
            this.lblContractDateTitle.Text = "Дата оформления:";

            // lblContractDate
            this.lblContractDate.AutoSize = true;
            this.lblContractDate.Location = new System.Drawing.Point(180, 92);
            this.lblContractDate.Name = "lblContractDate";
            this.lblContractDate.Size = new System.Drawing.Size(35, 13);
            this.lblContractDate.TabIndex = 4;
            this.lblContractDate.Text = "label2";

            // lblExpiryDateTitle
            this.lblExpiryDateTitle.AutoSize = true;
            this.lblExpiryDateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpiryDateTitle.Location = new System.Drawing.Point(20, 120);
            this.lblExpiryDateTitle.Name = "lblExpiryDateTitle";
            this.lblExpiryDateTitle.Size = new System.Drawing.Size(123, 17);
            this.lblExpiryDateTitle.TabIndex = 5;
            this.lblExpiryDateTitle.Text = "Действует до:";

            // lblExpiryDate
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(180, 122);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(35, 13);
            this.lblExpiryDate.TabIndex = 6;
            this.lblExpiryDate.Text = "label3";

            // lblAmountTitle
            this.lblAmountTitle.AutoSize = true;
            this.lblAmountTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmountTitle.Location = new System.Drawing.Point(20, 150);
            this.lblAmountTitle.Name = "lblAmountTitle";
            this.lblAmountTitle.Size = new System.Drawing.Size(156, 17);
            this.lblAmountTitle.TabIndex = 7;
            this.lblAmountTitle.Text = "Страховая сумма:";

            // lblAmount
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(180, 152);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(35, 13);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "label4";

            // lblBranchTitle
            this.lblBranchTitle.AutoSize = true;
            this.lblBranchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblBranchTitle.Location = new System.Drawing.Point(20, 180);
            this.lblBranchTitle.Name = "lblBranchTitle";
            this.lblBranchTitle.Size = new System.Drawing.Size(67, 17);
            this.lblBranchTitle.TabIndex = 9;
            this.lblBranchTitle.Text = "Филиал:";

            // lblBranch
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(180, 182);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(35, 13);
            this.lblBranch.TabIndex = 10;
            this.lblBranch.Text = "label5";

            // lblAgentTitle
            this.lblAgentTitle.AutoSize = true;
            this.lblAgentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAgentTitle.Location = new System.Drawing.Point(20, 210);
            this.lblAgentTitle.Name = "lblAgentTitle";
            this.lblAgentTitle.Size = new System.Drawing.Size(60, 17);
            this.lblAgentTitle.TabIndex = 11;
            this.lblAgentTitle.Text = "Агент:";

            // lblAgent
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(180, 212);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(35, 13);
            this.lblAgent.TabIndex = 12;
            this.lblAgent.Text = "label6";

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(150, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.lblAgentTitle);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBranchTitle);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblAmountTitle);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.lblExpiryDateTitle);
            this.Controls.Add(this.lblContractDate);
            this.Controls.Add(this.lblContractDateTitle);
            this.Controls.Add(this.lblInsuranceType);
            this.Controls.Add(this.lblInsuranceTypeTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о договоре";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInsuranceTypeTitle;
        private System.Windows.Forms.Label lblInsuranceType;
        private System.Windows.Forms.Label lblContractDateTitle;
        private System.Windows.Forms.Label lblContractDate;
        private System.Windows.Forms.Label lblExpiryDateTitle;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBranchTitle;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblAgentTitle;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Button btnClose;
    }
}