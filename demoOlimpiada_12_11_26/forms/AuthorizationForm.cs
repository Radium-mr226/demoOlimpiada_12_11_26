using demoOlimpiada_12_11_26.Models;
using demoOlimpiada_12_11_26.UserClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoOlimpiada_12_11_26.forms
{
    public partial class AuthorizationForm : Form
    {
        private CompareItem _item;
        private users _user;
        
        public AuthorizationForm(CompareItem item)
        {
            InitializeComponent();
            _item = item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null)
            {
                _user = Program.context.users.FirstOrDefault(u => u.login == textBox1.Text);
                if (_user != null && _user.password == textBox2.Text)
                {
                    label4.Visible = true;
                    maskedTextBox1.Visible = true;
                    button3.Visible = true;
                    MessageBox.Show("Введите номер телефона и подключите тариф");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }

            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted)
            {

                contracts order = new contracts
                {
                    tarif_id = _item.tarifId,
                    user_id = _user.id_user,
                    phone_number = maskedTextBox1.Text,
                    contract_date = DateTime.Today,
                    total_cost = _item.totalCost,
                    extra_min = _item.extraMin,
                    extra_sms = _item.extraSms,
                    extra_gb = _item.extraGb
                };
                Program.context.contracts.Add(order);
                Program.context.SaveChanges();   // после этого у order появляется id_contract

                var tarif = Program.context.tarif.First(t => t.id_tarif == _item.tarifId);

                var values = new Dictionary<string, string>
                {
                    ["id_contract"] = order.id_contract.ToString(),
                    ["contract_date"] = order.contract_date.ToString("dd.MM.yyyy"),
                    ["full_name"] = _user.full_name,
                    ["birthday_date"] = _user.birthday_date.ToString("dd.MM.yyyy"),
                    ["passport_series"] = _user.passport_series,
                    ["passport_number"] = _user.passport_number,
                    ["passport_issued_by"] = _user.passport_issued_by,
                    ["passport_issue_date"] = _user.passport_issue_date.ToString("dd.MM.yyyy"),
                    ["address"] = _user.address,
                    ["phone_number"] = order.phone_number,
                    ["tarif_name"] = tarif.tarif_name,
                    ["total_min"] = _item.totalMin.ToString(),
                    ["total_sms"] = _item.totalSms.ToString(),
                    ["total_gb"] = _item.totalGb.ToString(),
                    ["extra_min"] = _item.extraMin.ToString(),
                    ["extra_sms"] = _item.extraSms.ToString(),
                    ["extra_gb"] = _item.extraGb.ToString(),
                    ["total_cost"] = _item.totalCost.ToString("0.##")
                };

                using (var dlg = new SaveFileDialog { Filter = "Документ Word|*.docx", FileName = $"Договор_{order.id_contract}.docx" })
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string template = Path.Combine(Application.StartupPath, "contract_template.docx");
                        ContractGenerator.Create(template, dlg.FileName, values);
                        MessageBox.Show("Тариф подключён, договор сохранён");
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели не корректный номер телефона");
            }
        }
    }
}
