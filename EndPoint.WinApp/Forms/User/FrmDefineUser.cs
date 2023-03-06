using Common;
using IApplication.Interfaces;
using IApplication.Services.UsersServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndPoint.WinApp.Forms.User
{
    public partial class FrmDefineUser : Form
    {
        private readonly IUsers _user;
        public FrmDefineUser()
        {
            _user = (IUsers)Program.serviceProvider.GetService(typeof(IUsers));
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (!Validation.CheckValidationMelliCode(textBox1.Text))
                    textBox1.BackColor = Color.Pink;
                else
                {
                    textBox1.BackColor = Color.LemonChiffon;
                  var u=  _user.SelectUser(textBox1.Text);
                    if (u!=null)
                    {
                        textBox2.Text = u.Name;
                        textBox3.Text = u.Family;

                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validation.CheckValidationMelliCode(textBox1.Text))
            { MessageBox.Show("کد ملی صحیح نمی باشد"); return; }

            if (txtpass.Text != txtrepass.Text) { MessageBox.Show("مقادیر رمز عبور یکسان نمی باشد"); return; }
            if (txtpass.Text.Length == 0) { MessageBox.Show("رمز عبور را وارد نمایید"); return; }
            _user.CreateUser(textBox1.Text,textBox2.Text,textBox3.Text,txtpass.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
