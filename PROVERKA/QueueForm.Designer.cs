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
            this.dataGridViewQueue = new System.Windows.Forms.DataGridView();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).BeginInit();
            this.SuspendLayout();

            // dataGridViewQueue
            this.dataGridViewQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueue.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewQueue.Name = "dataGridViewQueue";
            this.dataGridViewQueue.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewQueue.TabIndex = 0;

            // btnAddToQueue
            this.btnAddToQueue.Location = new System.Drawing.Point(12, 418);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(120, 30);
            this.btnAddToQueue.TabIndex = 1;
            this.btnAddToQueue.Text = "Добавить в очередь";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);

            // QueueForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnAddToQueue);
            this.Controls.Add(this.dataGridViewQueue);
            this.Name = "QueueForm";
            this.Text = "Очередь клиентов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueue)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewQueue;
        private System.Windows.Forms.Button btnAddToQueue;
    }
}
