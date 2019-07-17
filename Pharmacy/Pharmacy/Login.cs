using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmacy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string username = txtSurname.Text.Trim();
            string password = txtPassword.Text.Trim();

            if(username!="c" || password != "1")
            {
                MessageBox.Show("Login or Password is faild","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                Pharmacy pharmacy = new Pharmacy(this);
                pharmacy.Show();
            }
        }
    }
}
