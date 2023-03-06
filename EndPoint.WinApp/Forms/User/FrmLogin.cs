
using Domain;
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
    public partial class FrmLogin : Form
    {
        private bool _autentication = false;
        private readonly IUsers _user;
        public bool autentication
        {
            get
            {
                return this._autentication;
            }
        }
        
        public FrmLogin()
        {
            _user =(IUsers) Program.serviceProvider.GetService(typeof(IUsers));
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _autentication = false;
            Close();
        }
        int CountErorr = 0;
       public Users CurrentUser;
        private void button1_Click(object sender, EventArgs e)
        {
           CurrentUser=  _user.LoginUser(textBox1.Text,textBox2.Text);
            if (CurrentUser!= null)
            {
                _autentication = true;
                //Properties.Settings.Default.UserName = textBox1.Text;
                //Properties.Settings.Default.Name = CurrentUser.Name;
                //Properties.Settings.Default.Save();
                                this.Close();
            }
            else
            {
                CountErorr++;
                if (CountErorr == 1)
                    this.BackColor = Color.Yellow;
                if (CountErorr == 2)
                    this.BackColor = Color.Red;

                _autentication = false;
                MessageBox.Show("نام کاربری یا رمز عبور نادرست است");
                if (CountErorr >= 3) Close();

            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           // textBox1.Text = Properties.Settings.Default.UserName;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                SendKeys.Send("{TAB}");
        }
    }
}
