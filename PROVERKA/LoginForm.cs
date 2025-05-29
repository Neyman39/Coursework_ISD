using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using PROVERKA.Models;

namespace PROVERKA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //InitializeDefaultManager();
        }

        public void EnsureInitialUserCreated()
        {
            var db = new INDbContext();

            try
            {
                bool adminExists = db.Users.Count(u => u.Login == "admin") > 0;
                // Проверяем, есть ли уже пользователь с логином "admin"
                if (!adminExists)
                {
                    // Создаём начального пользователя
                    var admin = new Models.User
                    {
                        Id = "2",
                        Login = "admin",
                        Passwd = "admin123" // В реальном приложении пароль нужно хэшировать!
                    };

                    db.Users.Add(admin);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании начального пользователя: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var db = new INDbContext())
            {
                // Проверка менеджера
                var manager = db.Users.FirstOrDefault(m => m.Login == username && m.Passwd == password);
                if (manager != null)
                {
                    AgentsForm managerForm = new AgentsForm();
                    managerForm.Show();
                    this.Hide();
                    return;
                }

                // Проверка агента
                var agent = db.Agents.FirstOrDefault(a => a.Login == username && a.Passwd == password);
                if (agent != null)
                {
                    QueueForm agentForm = new QueueForm(agent);
                    agentForm.Show();
                    this.Hide();
                    return;
                }

                // Проверка клиента
                var client = db.Clients.FirstOrDefault(a => a.Login == username && a.Passwd == password);
                if (client != null)
                {
                    ClientForm clientForm = new ClientForm(client.IdClient, this);
                    clientForm.Show();
                    this.Hide();
                    return;
                }

                MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка входа",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}