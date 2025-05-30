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
        private readonly IDBManager _facade;
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

        private void btnDelAgent_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли какой-то агент в таблице
            if (dataGridViewAgents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите агента для удаления",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Получаем ID выбранного агента
            var selectedRow = dataGridViewAgents.SelectedRows[0];
            int agentId = (int)selectedRow.Cells["IdAgent"].Value;
            string agentName = selectedRow.Cells["FullName"].Value.ToString();

            var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить агента {agentName}?",
                                             "Подтверждение удаления",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (_facade.RemoveAgent(agentId))
                {
                    MessageBox.Show("Агент успешно удален",
                                  "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAgents();
                }
                else
                {
                    MessageBox.Show("Не удалось удалить агента",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
