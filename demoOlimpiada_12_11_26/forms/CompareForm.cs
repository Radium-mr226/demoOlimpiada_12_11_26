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
    public partial class CompareForm : Form
    {
        public CompareForm()
        {
            InitializeComponent();
        }

        private void CompareForm_Load(object sender, EventArgs e)
        {
            LoadCompare();

        }

        private void LoadCompare()
        {
            int itemCount = CompareStorage.Items.Count;
            if (itemCount == 0)
            {
                MessageBox.Show("Нет тарифов для сравнения");
                this.Close();
                return;
            }
            else if (itemCount == 1)
            {
                MessageBox.Show("Недостаточно тарифов для сравнения");
                this.Close();
                return;
            }
            else if (itemCount >= 2)
            {
                //11-15
                textBox15.Visible = false;
                textBox14.Visible = false;
                textBox13.Visible = false;
                textBox12.Visible = false;
                textBox11.Visible = false;
                button4.Visible = false;
                button7.Visible = false;


                textBox1.Text = CompareStorage.Items[0].tarifName;
                textBox2.Text = CompareStorage.Items[0].totalMin.ToString();
                textBox3.Text = CompareStorage.Items[0].totalSms.ToString();
                textBox4.Text = CompareStorage.Items[0].totalGb.ToString();
                textBox5.Text = CompareStorage.Items[0].totalCost.ToString();

                textBox6.Text = CompareStorage.Items[1].tarifName;
                textBox7.Text = CompareStorage.Items[1].totalMin.ToString();
                textBox8.Text = CompareStorage.Items[1].totalSms.ToString();
                textBox9.Text = CompareStorage.Items[1].totalGb.ToString();
                textBox10.Text = CompareStorage.Items[1].totalCost.ToString();

                if (itemCount >= 3)
                {
                    textBox15.Visible = true;
                    textBox14.Visible = true;
                    textBox13.Visible = true;
                    textBox12.Visible = true;
                    textBox11.Visible = true;
                    button4.Visible = true;
                    button7.Visible = true;
                    textBox11.Text = CompareStorage.Items[2].tarifName;
                    textBox12.Text = CompareStorage.Items[2].totalMin.ToString();
                    textBox13.Text = CompareStorage.Items[2].totalSms.ToString();
                    textBox14.Text = CompareStorage.Items[2].totalGb.ToString();
                    textBox15.Text = CompareStorage.Items[2].totalCost.ToString();
                }
            }
        }
        

        private void button5_Click(object sender, EventArgs e) => RemoveRow(0);
        private void button6_Click(object sender, EventArgs e) => RemoveRow(1);
        private void button7_Click(object sender, EventArgs e) => RemoveRow(2);

        private void RemoveRow(int index)
        {
            if (index < CompareStorage.Items.Count)
                CompareStorage.Items.RemoveAt(index);
            LoadCompare();
        }
        private void button2_Click(object sender, EventArgs e) => addOrder(0);
        private void button3_Click(object sender, EventArgs e) => addOrder(1);
        private void button4_Click(object sender, EventArgs e) => addOrder(2);

        private void addOrder(int index)
        {
            if(index >= CompareStorage.Items.Count) return;
            var item = CompareStorage.Items[index];
            users user;
            var auth = new AuthorizationForm(item);
            auth.ShowDialog();
            

            
        }

    }
}
