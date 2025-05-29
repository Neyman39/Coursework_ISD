using PROVERKA.Models;
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
        private readonly IDBAgent _facade;

        public QueueForm(IDBAgent facade)
        {
            InitializeComponent();
            _facade = facade;
            LoadQueue();
        }

        private void LoadQueue()
        {
            var queue = _facade.LoadingClientsQueue();
            dataGridViewQueue.DataSource = queue;


            dataGridViewQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewQueue.Columns["id"].Visible = false;
            //dataGridViewQueue.Columns["id_agent"].Visible = false;
            //dataGridViewQueue.Columns["Agent"].Visible = false;
            AddButtonColumn();
        }

        private void AddButtonColumn()
        {
            // ���������, ��� �� ��� ������� � ��������
            if (dataGridViewQueue.Columns.Contains("SelectButtonColumn"))
                return;

            var buttonColumn = new DataGridViewButtonColumn
            {
                Name = "SelectButtonColumn",
                HeaderText = "��������",
                Text = "�������",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dataGridViewQueue.Columns.Add(buttonColumn);
        }

        private void DataGridViewQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ���������, ��� ������ �� ������ (� �� �� ��������� ��� ������ ������)
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewQueue.Columns["SelectButtonColumn"].Index)
            {
                // �������� ���������� ������
                DataGridViewRow selectedRow = dataGridViewQueue.Rows[e.RowIndex];

                // ������� ������ ������� �� ������ ������
                Client selectedClient = new Client
                {
                    IdClient = Convert.ToInt32(selectedRow.Cells["IdClient"].Value),
                    FullName = selectedRow.Cells["FullName"].Value.ToString(),
                    Phone = selectedRow.Cells["Phone"].Value.ToString()
                };

                // ��������� ����� ������� ��������� � �������� �������
                CostCalculationForm costCalculationForm = new CostCalculationForm(selectedClient);
                costCalculationForm.ShowDialog();

                // ��������� ������� ����� �������� ����� �������
                LoadQueue();
            }
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            var addForm = new AddToQueueForm();
            addForm.ShowDialog();


            LoadQueue();
        }

        private void dataGridViewQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ���������, ��� ������ �� ������ (� �� �� ��������� ��� ������ ������)
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewQueue.Columns["SelectButtonColumn"].Index)
            {
                // �������� ���������� ������
                DataGridViewRow selectedRow = dataGridViewQueue.Rows[e.RowIndex];

                // ������� ������ ������� �� ������ ������
                Client selectedClient = new Client
                {
                    IdClient = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                    FullName = selectedRow.Cells["FullName"].Value.ToString(),
                    Phone = selectedRow.Cells["Phone"].Value.ToString()
                };

                // ��������� ����� ������� ��������� � �������� �������
                CostCalculationForm costCalculationForm = new CostCalculationForm(selectedClient);
                costCalculationForm.ShowDialog();

                // ��������� ������� ����� �������� ����� �������
                LoadQueue();
            }
        }
    }
}
