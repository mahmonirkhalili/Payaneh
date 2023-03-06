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
    public partial class FrmUsers : Form
    {
        IUsers _user;
        public FrmUsers()
        {
            _user = (IUsers)Program.serviceProvider.GetService(typeof(IUsers));
            InitializeComponent();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _user.ListUsers().ToList();
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
