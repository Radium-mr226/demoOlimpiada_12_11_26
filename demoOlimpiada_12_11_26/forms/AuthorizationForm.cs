using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demoOlimpiada_12_11_26.Models;

namespace demoOlimpiada_12_11_26.forms
{
    public partial class AuthorizationForm : Form
    {
        public users CurrentUser { get; private set; }
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null)
            {
                var user = Program.context.users.FirstOrDefault(u => u.login == textBox1.Text);
                if (user != null && user.password == textBox2.Text)
                {
                    CurrentUser = user;
                    this.DialogResult = DialogResult.OK;
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

        
    }
}
