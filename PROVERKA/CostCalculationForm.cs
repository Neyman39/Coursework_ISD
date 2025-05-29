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
    public partial class CostCalculationForm : Form
    {
        private readonly IDBAgent _facade;
        private Client _client;
        private InsuranceType _selectedType;
        private Dictionary<Field, string> _fieldValues = new Dictionary<Field, string>();

        public CostCalculationForm(Client client)
        {
            InitializeComponent();
            _client = client;
            _facade = new FacadeDB();
            lblClientInfo.Text = $"{client.FullName} ({client.Phone})";
            LoadInsuranceTypes();
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
                    inputControl = new NumericUpDown
                    {
                        Width = 200,
                        Tag = field.IdField,
                        Minimum = 0,
                        Maximum = 1000000
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

        // Метод для получения значений полей
        private Dictionary<int, string> GetFieldValues()
        {
            var values = new Dictionary<int, string>();

            foreach (Control control in flowLayoutPanelFields.Controls)
            {
                if (control.Tag is int fieldId && !values.ContainsKey(fieldId)) // Проверяем, нет ли уже такого ключа
                {
                    string value = control switch
                    {
                        TextBox txt => txt.Text,
                        NumericUpDown num => num.Value.ToString(),
                        ComboBox cmb => cmb.SelectedItem?.ToString(),
                        _ => string.Empty
                    };

                    if (!string.IsNullOrEmpty(value))
                        values.Add(fieldId, value);
                }
            }

            return values;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Собираем значения полей
            foreach (Control control in flowLayoutPanelFields.Controls)
            {
                if (control is TextBox textBox && textBox.Tag is Field field)
                {
                    _fieldValues[field] = textBox.Text;
                }
            }

            // Расчет стоимости (упрощенный пример)
            //decimal cost = _selectedType.TariffRate * 1000; // Здесь должна быть ваша логика расчета

            //// Открываем форму подтверждения
            //using (var confirmationForm = new ConfirmationForm(_client, _selectedType, cost, _fieldValues))
            //{
            //    if (confirmationForm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //}
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

                // Получаем выбранный тип страхования
                if (comboBoxInsuranceType.SelectedItem is InsuranceType selectedType)
                {
                    // Рассчитываем стоимость
                    decimal cost = _facade.CalculateInsuranceCost(
                        insuranceId,
                        fieldValues);

                    // Отображаем результат

                    lblCost.Text = cost.ToString("C");

                    // Рассчитываем комиссию агента (TariffRate - процент от стоимости)
                    decimal tariffrate = selectedType.TariffRate.Value;
                    decimal agentCommission = cost * (tariffrate / 100);


                    lblCommission.Text = agentCommission.ToString("C");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}");
            }
        }
    }
}
