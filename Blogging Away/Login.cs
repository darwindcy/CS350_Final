using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogging_Away
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Invalid Username or password");
            }
            if(txtUsername.Text == txtPassword.Text)
            {
              
                Home newHome = new Home();
                
                newHome.Show();
            } 
                else
            {
                MessageBox.Show("Username or Password Incorrect");
            }
        }
    }
}
