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
    public partial class AddAgentForm : Form
    {
        private readonly FacadeDB _facade;
        public AddAgentForm()
        {
            InitializeComponent();
            _facade = new FacadeDB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string agentData = $"{txtFullName.Text}|{txtAddress.Text}|{txtPhone.Text}|{txtSalary.Text}|{txtExperience.Text}|{txtLogin.Text}|{txtPassword.Text}";
            if (_facade.SaveAgent(agentData))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении данных. Проверьте подключение к базе.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
