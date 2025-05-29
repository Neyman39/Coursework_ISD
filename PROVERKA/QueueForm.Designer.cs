namespace PROVERKA
{
    partial class QueueForm
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

        private void InitializeComponent()
        {
            dataGridViewQueue = new DataGridView();
            btnAddToQueue = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewQueue
            // 
            dataGridViewQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQueue.Location = new Point(16, 18);
            dataGridViewQueue.Margin = new Padding(4, 5, 4, 5);
            dataGridViewQueue.Name = "dataGridViewQueue";
            dataGridViewQueue.RowHeadersWidth = 51;
            dataGridViewQueue.Size = new Size(1013, 615);
            dataGridViewQueue.TabIndex = 0;
            dataGridViewQueue.CellContentClick += dataGridViewQueue_CellContentClick;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.Location = new Point(16, 643);
            btnAddToQueue.Margin = new Padding(4, 5, 4, 5);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(160, 46);
            btnAddToQueue.TabIndex = 1;
            btnAddToQueue.Text = "Добавить в очередь";
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Click += btnAddToQueue_Click;
            // 
            // QueueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 709);
            Controls.Add(btnAddToQueue);
            Controls.Add(dataGridViewQueue);
            Margin = new Padding(4, 5, 4, 5);
            Name = "QueueForm";
            Text = "Очередь клиентов";
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewQueue;
        private System.Windows.Forms.Button btnAddToQueue;
    }
}
