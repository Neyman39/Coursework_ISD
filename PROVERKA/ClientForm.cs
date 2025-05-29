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
    public partial class ClientForm : Form
    {
        private readonly int? _clientId;
        private readonly FacadeDB _facade;
        private Form _loginForm;

        public ClientForm(int? clientId, Form loginForm)
        {
            InitializeComponent();
            _clientId = clientId;
            _facade = new FacadeDB();
            _loginForm = loginForm;
            LoadClientData();
        }

        private void LoadClientData()
        {
            try
            {
                var agreementInfo = _facade.GetClientAgreementInfo(_clientId);

                if (agreementInfo != null)
                {
                    lblInsuranceType.Text = agreementInfo.InsuranceTypeName;
                    lblContractDate.Text = agreementInfo.AgreementDate.ToString("dd.MM.yyyy");
                    lblExpiryDate.Text = agreementInfo.AgreementDate.AddYears(1).ToString("dd.MM.yyyy");
                    lblAmount.Text = agreementInfo.SumInsured.ToString();
                    lblBranch.Text = agreementInfo.BranchAddress;
                    lblAgent.Text = agreementInfo.AgentFullName;
                }
                else
                {
                    MessageBox.Show("Договор страхования не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }
    }
}
