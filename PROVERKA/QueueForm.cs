using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROVERKA
{
    public partial class QueueForm : Form
    {
        private readonly FacadeDB _facade;

        public QueueForm()
        {
            InitializeComponent();
            _facade = new FacadeDB();
            LoadQueue();
        }

        private void LoadQueue()
        {
            var queue = _facade.LoadingClientsQueue();
            dataGridViewQueue.DataSource = queue;

            // Настройка отображения DataGridView
            dataGridViewQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewQueue.Columns["id"].Visible = false;
            //dataGridViewQueue.Columns["id_agent"].Visible = false;
            //dataGridViewQueue.Columns["Agent"].Visible = false;
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            var addForm = new AddToQueueForm();
            addForm.ShowDialog();

            // Обновляем очередь после закрытия формы добавления
            LoadQueue();
        }
    }
}
