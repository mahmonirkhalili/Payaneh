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
    public partial class FrmChangePassword : Form
    {
        private readonly IUsers _user;
        public FrmChangePassword()
        {
            _user = (IUsers)Program.serviceProvider.GetService(typeof(IUsers));
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
          //  txtuserName.Text = Properties.Settings.Default.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                MessageBox.Show("رمز عبور نمی تواند خالی باشد");
                return;
            }
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("رمز عبور جدید با تکرار آن مطابقت ندارد");
                return;
            }
            if (_user.LoginUser(txtuserName.Text,textBox1.Text)==null)
            {
                MessageBox.Show("رمز عبور قبلی نادرست می باشد");
                return;
            }
            _user.ChangePassword(txtuserName.Text, txtNewPass.Text);
            Close();
        }
    }
}
