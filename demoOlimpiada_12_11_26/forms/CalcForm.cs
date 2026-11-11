using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demoOlimpiada_12_11_26.forms
{
    public partial class CalcForm : Form
    {
        private List<Models.tarif> tarifs = new List<Models.tarif>();
        public CalcForm()
        {
            InitializeComponent();
            var tarifs = Program.context.tarif.ToList();

            tarifs.Insert(0, new Models.tarif { id_tarif = 0, tarif_name = "Выберите тариф" });

            TarifsComboBox.DisplayMember = "tarif_name";
            TarifsComboBox.ValueMember = "id_tarif";
            TarifsComboBox.DataSource = tarifs;
            TarifsComboBox.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TarifsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCost();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void calculateCost()
        {
            if (TarifsComboBox.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                textBox7.Text = "";
                button1.Enabled = false;
                return;
            }
            else if (TarifsComboBox.SelectedIndex == 1)
            {
                var basesT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Базовый");
                var minService = Program.context.min_services.FirstOrDefault(p => p.id_min_service == basesT.min_service_id);
                var smsService = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == basesT.sms_service_id);
                var gbService = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == basesT.gb_service_id);
                textBox1.Text = (basesT.min_quantity+ minService.add_min_quan*numericUpDown1.Value).ToString();
                textBox2.Text = (basesT.sms_quantity+ smsService.add_sms_quan*numericUpDown2.Value).ToString();
                textBox3.Text = (basesT.gb_quantity+ gbService.add_gb_quan*numericUpDown3.Value).ToString();

                textBox7.Text = (basesT.cost + minService.add_min_cost * numericUpDown1.Value + smsService.add_sms_cost * numericUpDown2.Value + gbService.add_gb_cost * numericUpDown3.Value).ToString();
                button1.Enabled = true;
            }
            else if (TarifsComboBox.SelectedIndex == 2)
            {
                var optimalT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Оптимальный");
                var minService = Program.context.min_services.FirstOrDefault(p => p.id_min_service == optimalT.min_service_id);
                var smsService = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == optimalT.sms_service_id);
                var gbService = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == optimalT.gb_service_id);
                textBox1.Text = (optimalT.min_quantity+ minService.add_min_quan*numericUpDown1.Value).ToString();
                textBox2.Text = (optimalT.sms_quantity+ smsService.add_sms_quan*numericUpDown2.Value).ToString();
                textBox3.Text = (optimalT.gb_quantity+ gbService.add_gb_quan*numericUpDown3.Value).ToString();

                textBox7.Text = (optimalT.cost + minService.add_min_cost * numericUpDown1.Value + smsService.add_sms_cost * numericUpDown2.Value + gbService.add_gb_cost * numericUpDown3.Value).ToString();
                button1.Enabled = true;
            }
            else
            {
                var premiumT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Премиум");
                var minService = Program.context.min_services.FirstOrDefault(p => p.id_min_service == premiumT.min_service_id);
                var smsService = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == premiumT.sms_service_id);
                var gbService = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == premiumT.gb_service_id);
                textBox1.Text = (premiumT.min_quantity+ minService.add_min_quan*numericUpDown1.Value).ToString();
                textBox2.Text = (premiumT.sms_quantity+ smsService.add_sms_quan*numericUpDown2.Value).ToString();
                textBox3.Text = (premiumT.gb_quantity+ gbService.add_gb_quan*numericUpDown3.Value).ToString();
                textBox7.Text = (premiumT.cost + minService.add_min_cost * numericUpDown1.Value + smsService.add_sms_cost * numericUpDown2.Value + gbService.add_gb_cost * numericUpDown3.Value).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TarifsComboBox.SelectedIndex == 1)
            {
                tarifs.Add(Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Базовый"));
            }
            else if (TarifsComboBox.SelectedIndex == 2)
            {
                tarifs.Add(Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Оптимальный"));
            }
            else if (TarifsComboBox.SelectedIndex == 3)
            {
                tarifs.Add(Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Премиум"));
            }
            var item = BuildItems();
            if (item == null)
            {
                MessageBox.Show("Выберите тариф");
                return;
            }
            CompareStorage.Items.RemoveAll(i=> i.tarifId == item.tarifId);
            CompareStorage.Items.Add(item);
        }

        private CompareItem BuildItems()
        {
            var t = TarifsComboBox.SelectedItem as Models.tarif;

            var minS = Program.context.min_services.FirstOrDefault(p => p.id_min_service == t.min_service_id);
            var smsS = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == t.sms_service_id);
            var gbS = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == t.gb_service_id);

            int extraMin = (int)numericUpDown1.Value;
            int extraSms = (int)numericUpDown2.Value;
            int extraGb = (int)numericUpDown3.Value;

            decimal cost  = t.cost 
                + Math.Ceiling((decimal)extraMin) * minS.add_min_cost
                + Math.Ceiling((decimal)extraSms) * smsS.add_sms_cost
                + Math.Ceiling((decimal)extraGb) * gbS.add_gb_cost;
            return new CompareItem
            {
                tarifId = t.id_tarif,
                tarifName = t.tarif_name,
                extraMin = extraMin*minS.add_min_quan,
                extraSms = extraSms*smsS.add_sms_quan,
                extraGb = extraGb*gbS.add_gb_quan,
                totalMin = t.min_quantity + extraMin*minS.add_min_quan,
                totalSms = t.sms_quantity + extraSms*smsS.add_sms_quan,
                totalGb = t.gb_quantity + extraGb*gbS.add_gb_quan,
                totalCost = cost
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompareForm compareForm = new CompareForm();
            compareForm.ShowDialog();
        }
    }
}
