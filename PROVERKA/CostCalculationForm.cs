using PROVERKA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROVERKA
{
    public partial class CostCalculationForm : Form
    {
        private readonly IDBAgent _facade;
        private Client _client;
        private Agent _agent;
        bool _existingClient;
        private InsuranceType _selectedType;
        private Dictionary<Field, string> _fieldValues = new Dictionary<Field, string>();

        public CostCalculationForm(Client client, Agent agent)
        {
            InitializeComponent();
            _client = client;
            _agent = agent;
            _facade = new FacadeDB();
            lblClientInfo.Text = $"{client.FullName} ({client.Phone})";

            CheckClientExistence();
            LoadInsuranceTypes();
            _agent = agent;
        }

        private void CheckClientExistence()
        {
            _existingClient = _facade.ClientCheck(_client.Phone);

            if (_existingClient)
            {
                lblClientStatus.Text = "Клиент уже есть в базе";
                lblClientStatus.ForeColor = Color.Green;
                btnCreateContract.Enabled = true;
                btnAddClient.Visible = false;
            }
            else
            {
                lblClientStatus.Text = "Клиент не найден. Необходимо добавить в базу";
                lblClientStatus.ForeColor = Color.Red;
                btnCreateContract.Enabled = false;
                btnAddClient.Visible = true;
            }
        }

        private void LoadInsuranceTypes()
        {
            comboBoxInsuranceType.DataSource = _facade.LoadingInsuranceTypes();
            comboBoxInsuranceType.DisplayMember = "Name";
        }

        private void comboBoxInsuranceType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _selectedType = (InsuranceType)comboBoxInsuranceType.SelectedItem;
            LoadInsuranceFields();
        }

        private void LoadInsuranceFields()
        {

            flowLayoutPanelFields.Controls.Clear();
            _fieldValues.Clear();

            int insuranceId = _selectedType.IdInsurance.Value;
            // Получаем поля для выбранного типа страхования
            var fields = _facade.LoadingInsuranceFields(insuranceId);

            foreach (var field in fields)
            {
                // Создаем подпись
                var label = new Label
                {
                    Text = field.Name,
                    Width = 200,
                    Margin = new Padding(0, 10, 0, 0)
                };

                // Создаем поле ввода в зависимости от типа
                Control inputControl;

                if (field.Type == "int")
                {
                    //inputControl = new NumericUpDown
                    //{
                    //    Width = 200,
                    //    Tag = field.IdField,
                    //    Minimum = 0,
                    //    Maximum = 1000000
                    //};
                    inputControl = new TextBox
                    {
                        Width = 200,
                        Tag = field.IdField
                    };
                }
                else if (field.Type == "date")
                {
                    inputControl = new DateTimePicker
                    {
                        Width = 200,
                        Tag = field.IdField
                    };
                }
                else // string и другие типы
                {
                    inputControl = new TextBox
                    {
                        Width = 200,
                        Tag = field.IdField
                    };
                }

                // Добавляем элементы на панель
                flowLayoutPanelFields.Controls.Add(label);
                flowLayoutPanelFields.Controls.Add(inputControl);
            }
        }

        //private Dictionary<int, string> GetFieldValues()
        //{
        //    var values = new Dictionary<int, string>();

        //    foreach (Control control in flowLayoutPanelFields.Controls)
        //    {
        //        if (control.Tag is int fieldId && !values.ContainsKey(fieldId)) // Проверяем, нет ли уже такого ключа
        //        {
        //            string value = control switch
        //            {
        //                TextBox txt => txt.Text,
        //                NumericUpDown num => num.Value.ToString(),
        //                ComboBox cmb => cmb.SelectedItem?.ToString(),
        //                _ => string.Empty
        //            };

        //            if (!string.IsNullOrEmpty(value))
        //                values.Add(fieldId, value);
        //        }
        //    }

        //    return values;
        //}

        private Dictionary<int, string> GetFieldValues()
        {
            var values = new Dictionary<int, string>();

            foreach (Control control in flowLayoutPanelFields.Controls)
            {
                if (control.Tag is int fieldId && !values.ContainsKey(fieldId))
                {
                    string value = control switch
                    {
                        TextBox txt => txt.Text,
                        NumericUpDown num => num.Value.ToString(),
                        ComboBox cmb => cmb.SelectedItem?.ToString(),
                        _ => string.Empty
                    };

                    // Проверяем заполненность (например, для ComboBox считаем заполненным, только если выбрано что-то)
                    bool isEmpty = string.IsNullOrEmpty(value);

                    if (isEmpty)
                    {
                        string controlType = control.GetType().Name;
                        throw new ArgumentException($"Поле с ID {fieldId} ({controlType}) не заполнено.");
                    }

                    values.Add(fieldId, value);
                }
            }

            return values;
        }


        private bool ValidateInputs()
        {
            // Проверка заполнения всех полей
            foreach (Control control in flowLayoutPanelFields.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Заполните все поля");
                    return false;
                }
            }
            return true;
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения полей
                var fieldValues = GetFieldValues();
                int insuranceId = _selectedType.IdInsurance.Value;

                //bool allFieldsFilled = fieldValues.Values.All(value => !string.IsNullOrWhiteSpace(value));

                //if (!allFieldsFilled)
                //{
                //    MessageBox.Show("Не все поля заполнены!");
                //    return;
                //}

                //MessageBox.Show($"Окак: {fieldValues.Values[1]}");

                // Получаем выбранный тип страхования
                if (comboBoxInsuranceType.SelectedItem is InsuranceType selectedType)
                {
                    
                    // Рассчитываем стоимость
                    decimal cost = _facade.CalculateInsuranceCost(
                        insuranceId,
                        fieldValues);

                    // Отображаем результат

                    lblCost.Text = cost.ToString();

                    // Рассчитываем комиссию агента (TariffRate - процент от стоимости)
                    decimal tariffrate = selectedType.TariffRate.Value;
                    decimal agentCommission = Math.Round(cost * (tariffrate / 100), 2);


                    lblCommission.Text = agentCommission.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}");
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm(_client, _agent);
            if (addClientForm.ShowDialog() == DialogResult.OK)
            {
                _existingClient = true;
                CheckClientExistence();
            }
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lblCost.Text))
                {
                    MessageBox.Show("Пожалуйста, рассчитайте стоимость перед созданием договора.");
                    return;
                }

                var agentId = _agent.IdAgent;
                var clientId = _facade.GetClient(_client.Phone).IdClient;
                var branchId = _agent.IdBranch;
                int insuranceId = _selectedType.IdInsurance.Value;
                decimal sumInsured = decimal.Parse(lblCost.Text);
                decimal agentPremium = decimal.Parse(lblCommission.Text);

                bool success = _facade.CreateAgreement(sumInsured, agentId, clientId, branchId, insuranceId, agentPremium);
                if (success)
                {
                    _facade.RemoveClientFromQueue(_client.IdClient);
                    MessageBox.Show("Договор успешно создан и клиент удалён из очереди.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании договора: " + ex.Message);
            }
        }
    }
}
