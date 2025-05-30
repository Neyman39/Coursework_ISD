﻿namespace PROVERKA
{
    partial class CostCalculationForm
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
            lblClientInfo = new Label();
            comboBoxInsuranceType = new ComboBox();
            lblInsuranceType = new Label();
            flowLayoutPanelFields = new FlowLayoutPanel();
            btnCalculate = new Button();
            btnCancel = new Button();
            lblCost = new TextBox();
            lblCommission = new TextBox();
            lblClientStatus = new Label();
            btnCreateContract = new Button();
            btnAddClient = new Button();
            SuspendLayout();
            // 
            // lblClientInfo
            // 
            lblClientInfo.AutoSize = true;
            lblClientInfo.Font = new Font("Microsoft Sans Serif", 10F);
            lblClientInfo.Location = new Point(20, 25);
            lblClientInfo.Name = "lblClientInfo";
            lblClientInfo.Size = new Size(132, 20);
            lblClientInfo.TabIndex = 0;
            lblClientInfo.Text = "Клиент: {ФИО}";
            // 
            // comboBoxInsuranceType
            // 
            comboBoxInsuranceType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInsuranceType.FormattingEnabled = true;
            comboBoxInsuranceType.Location = new Point(200, 96);
            comboBoxInsuranceType.Margin = new Padding(3, 4, 3, 4);
            comboBoxInsuranceType.Name = "comboBoxInsuranceType";
            comboBoxInsuranceType.Size = new Size(300, 28);
            comboBoxInsuranceType.TabIndex = 1;
            comboBoxInsuranceType.SelectedIndexChanged += comboBoxInsuranceType_SelectedIndexChanged_1;
            // 
            // lblInsuranceType
            // 
            lblInsuranceType.AutoSize = true;
            lblInsuranceType.Location = new Point(20, 100);
            lblInsuranceType.Name = "lblInsuranceType";
            lblInsuranceType.Size = new Size(130, 20);
            lblInsuranceType.TabIndex = 2;
            lblInsuranceType.Text = "Тип страхования:";
            // 
            // flowLayoutPanelFields
            // 
            flowLayoutPanelFields.AutoScroll = true;
            flowLayoutPanelFields.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelFields.Location = new Point(20, 139);
            flowLayoutPanelFields.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelFields.Name = "flowLayoutPanelFields";
            flowLayoutPanelFields.Size = new Size(480, 224);
            flowLayoutPanelFields.TabIndex = 3;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(320, 438);
            btnCalculate.Margin = new Padding(3, 4, 3, 4);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(180, 38);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Рассчитать стоимость";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(20, 438);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 38);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblCost
            // 
            lblCost.Location = new Point(20, 388);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(125, 27);
            lblCost.TabIndex = 6;
            // 
            // lblCommission
            // 
            lblCommission.Location = new Point(320, 388);
            lblCommission.Name = "lblCommission";
            lblCommission.Size = new Size(125, 27);
            lblCommission.TabIndex = 7;
            // 
            // lblClientStatus
            // 
            lblClientStatus.AutoSize = true;
            lblClientStatus.Location = new Point(20, 61);
            lblClientStatus.Name = "lblClientStatus";
            lblClientStatus.Size = new Size(50, 20);
            lblClientStatus.TabIndex = 8;
            lblClientStatus.Text = "label1";
            // 
            // btnCreateContract
            // 
            btnCreateContract.Location = new Point(550, 223);
            btnCreateContract.Margin = new Padding(3, 4, 3, 4);
            btnCreateContract.Name = "btnCreateContract";
            btnCreateContract.Size = new Size(180, 38);
            btnCreateContract.TabIndex = 9;
            btnCreateContract.Text = "Оформить договор";
            btnCreateContract.UseVisualStyleBackColor = true;
            btnCreateContract.Click += btnCreateContract_Click;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(550, 325);
            btnAddClient.Margin = new Padding(3, 4, 3, 4);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(180, 38);
            btnAddClient.TabIndex = 10;
            btnAddClient.Text = "Добавить клиента";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // CostCalculationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 500);
            Controls.Add(btnAddClient);
            Controls.Add(btnCreateContract);
            Controls.Add(lblClientStatus);
            Controls.Add(lblCommission);
            Controls.Add(lblCost);
            Controls.Add(btnCancel);
            Controls.Add(btnCalculate);
            Controls.Add(flowLayoutPanelFields);
            Controls.Add(lblInsuranceType);
            Controls.Add(comboBoxInsuranceType);
            Controls.Add(lblClientInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CostCalculationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Расчет стоимости страхования";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblClientInfo;
        private System.Windows.Forms.ComboBox comboBoxInsuranceType;
        private System.Windows.Forms.Label lblInsuranceType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFields;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnCancel;
        private TextBox lblCost;
        private TextBox lblCommission;
        private Label lblClientStatus;
        private Button btnCreateContract;
        private Button btnAddClient;
    }
}