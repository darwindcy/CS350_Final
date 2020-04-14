using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogging_Away
{
    public partial class Home : Form
    {
        static String folderPath = "../../files/";
        public Home()
        {
            InitializeComponent();
            RetrieveData();
            if (Login.currentUser != "admin" )
                btnCreateNew.Visible = false;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            String user = Login.currentUser; 
            
            this.Hide();
            Createarticle createarticle = new Createarticle();
            createarticle.Show();

        }

        private void RetrieveData()
        {
            String Data = "";
            foreach (String file in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                using (StreamReader readtext = new StreamReader(file))
                {
                    while (readtext.Peek() >=0)
                    {
                        AddToScreen(readtext.ReadLine() + Environment.NewLine);
                    }
                }
                AddToScreen("----------------------------------------" + Environment.NewLine);
            }
        }
        private void AddToScreen(String data)
        {
            txtScreen.Text += data;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login newLogin = new Login();
            newLogin.Show();
        }
    }
}
