using demoOlimpiada_12_11_26.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoOlimpiada_12_11_26.forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadTarifs();
        }

        private void LoadTarifs()
        {
            // Базовый тариф
            var basesT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Базовый");
            textBox1.Text = basesT.min_quantity.ToString();
            textBox2.Text = basesT.sms_quantity.ToString();
            textBox3.Text = basesT.gb_quantity.ToString();
            var minService = Program.context.min_services.FirstOrDefault(p => p.id_min_service == basesT.min_service_id);
            textBox18.Text = minService?.add_min_cost.ToString();
            var smsService = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == basesT.sms_service_id);
            textBox17.Text = smsService?.add_sms_cost.ToString();
            var gbService = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == basesT.gb_service_id);
            textBox16.Text = gbService?.add_gb_cost.ToString();

            textBox21.Text = (basesT.cost).ToString();

            // Оптимальный тариф
            var optimalT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Оптимальный");
            textBox6.Text = optimalT.min_quantity.ToString();
            textBox5.Text = optimalT.sms_quantity.ToString();
            textBox4.Text = optimalT.gb_quantity.ToString();
            var minService2 = Program.context.min_services.FirstOrDefault(p => p.id_min_service == optimalT.min_service_id);
            textBox15.Text = minService2?.add_min_cost.ToString();
            var smsService2 = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == optimalT.sms_service_id);
            textBox14.Text = smsService2?.add_sms_cost.ToString();
            var gbService2 = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == optimalT.gb_service_id);
            textBox13.Text = gbService2?.add_gb_cost.ToString();

            textBox20.Text = (optimalT.cost).ToString();

            // Премиум тариф
            var premiumT = Program.context.tarif.FirstOrDefault(p => p.tarif_name == "Премиум");
            textBox9.Text = premiumT.min_quantity.ToString();
            textBox8.Text = premiumT.sms_quantity.ToString();
            textBox7.Text = premiumT.gb_quantity.ToString();
            var minService3 = Program.context.min_services.FirstOrDefault(p => p.id_min_service == premiumT.min_service_id);
            textBox12.Text = minService3?.add_min_cost.ToString();
            var smsService3 = Program.context.sms_services.FirstOrDefault(p => p.id_sms_service == premiumT.sms_service_id);
            textBox11.Text = smsService3?.add_sms_cost.ToString();
            var gbService3 = Program.context.gb_services.FirstOrDefault(p => p.id_gb_service == premiumT.gb_service_id);
            textBox10.Text = gbService3?.add_gb_cost.ToString();

            textBox19.Text = (premiumT.cost).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcForm calcForm = new CalcForm();
            calcForm.ShowDialog();
        }
    }
}
