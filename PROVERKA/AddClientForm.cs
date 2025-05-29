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
    public partial class AddClientForm : Form
    {
        private readonly FacadeDB _facade;
        private Agent _agent;
        private Client _client;

        public AddClientForm(Client client, Agent agent)
        {
            InitializeComponent();
            _agent = agent;
            _client = client;
            _facade = new FacadeDB();
            txtFullName.Text = _client.FullName;
            txtPhone.Text = _client.Phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string clientData = $"{txtFullName.Text}|{txtPhone.Text}|{1}|{txtLogin.Text}|{txtPassword}";
            if (_facade.CreateClientAccount(clientData))
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
    }
}
