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
    public partial class AgentsForm : Form
    {
        private readonly FacadeDB _facade;
        public AgentsForm()
        {
            InitializeComponent();
            _facade = new FacadeDB();
            LoadAgents();
        }

        private void LoadAgents()
        {
            dataGridViewAgents.DataSource = _facade.LoadingAgents();
            dataGridViewAgents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddAgentForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAgents(); // Обновляем таблицу после добавления
                }
            }
        }
    }
}
