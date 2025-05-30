namespace PROVERKA
{
    partial class AgentsForm
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
            dataGridViewAgents = new DataGridView();
            btnAddAgent = new Button();
            btnDelAgent = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAgents).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAgents
            // 
            dataGridViewAgents.AllowUserToAddRows = false;
            dataGridViewAgents.AllowUserToDeleteRows = false;
            dataGridViewAgents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAgents.Location = new Point(16, 18);
            dataGridViewAgents.Margin = new Padding(4, 5, 4, 5);
            dataGridViewAgents.Name = "dataGridViewAgents";
            dataGridViewAgents.ReadOnly = true;
            dataGridViewAgents.RowHeadersWidth = 51;
            dataGridViewAgents.Size = new Size(1013, 615);
            dataGridViewAgents.TabIndex = 0;
            // 
            // btnAddAgent
            // 
            btnAddAgent.Location = new Point(16, 643);
            btnAddAgent.Margin = new Padding(4, 5, 4, 5);
            btnAddAgent.Name = "btnAddAgent";
            btnAddAgent.Size = new Size(160, 46);
            btnAddAgent.TabIndex = 1;
            btnAddAgent.Text = "Добавить агента";
            btnAddAgent.UseVisualStyleBackColor = true;
            btnAddAgent.Click += btnAddAgent_Click;
            // 
            // btnDelAgent
            // 
            btnDelAgent.Location = new Point(207, 643);
            btnDelAgent.Margin = new Padding(4, 5, 4, 5);
            btnDelAgent.Name = "btnDelAgent";
            btnDelAgent.Size = new Size(160, 46);
            btnDelAgent.TabIndex = 2;
            btnDelAgent.Text = "Уволить агента";
            btnDelAgent.UseVisualStyleBackColor = true;
            btnDelAgent.Click += btnDelAgent_Click;
            // 
            // AgentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 708);
            Controls.Add(btnDelAgent);
            Controls.Add(btnAddAgent);
            Controls.Add(dataGridViewAgents);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AgentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление агентами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAgents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAgents;
        private System.Windows.Forms.Button btnAddAgent;
        private Button btnDelAgent;
    }
}