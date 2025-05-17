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
    public partial class AddToQueueForm : Form
    {
        private readonly FacadeDB _facade;

        public AddToQueueForm()
        {
            InitializeComponent();
            _facade = new FacadeDB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputCheck())
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля правильно.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем строку с данными клиента
            string clientData = $"{txtFullName.Text}|{txtPhone.Text}";

            if (_facade.QueueCheck(clientData))
            {
                if (_facade.SaveQueue(clientData))
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
            else
            {
                MessageBox.Show("Такой клиент уже есть в очереди.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InputCheck()
        {
            bool isValid = true;

            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                txtFullName.BackColor = Color.LightPink;
                isValid = false;
            }
            else
            {
                txtFullName.BackColor = SystemColors.Window;
            }

            // Проверка телефона (простая проверка)
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length < 10)
            {
                txtPhone.BackColor = Color.LightPink;
                isValid = false;
            }
            else
            {
                txtPhone.BackColor = SystemColors.Window;
            }

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
