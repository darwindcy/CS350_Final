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
    public partial class Createarticle : Form
    {
        static String fileLocation = "../../files/";
        public Createarticle()
        {
            InitializeComponent();
            setData();
            panelConfirm.Hide();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            SetConfirmData();
            panelConfirm.Show();
        }

        private void SetConfirmData()
        {
            txtConfirmusername.Text = txtUsername.Text;
            txtConfirmtitle.Text = txtArticletitle.Text;
            txtConfirmdetail.Text = txtArticledetail.Text;
            txtConfirmdate.Text = txtDate.Text;
        }

        private void setData()
        {
            txtUsername.Text = Login.currentUser;
            txtDate.Text = DateTime.Now.Date.ToString();
        }

        private void btnConfirmPost_Click(object sender, EventArgs e)
        {
            using (StreamWriter writeFile = new StreamWriter(fileLocation + CreateFileName(), true))
            {
                writeFile.WriteLine("Posted By:" + txtConfirmusername.Text);
                writeFile.WriteLine("Date: " + txtConfirmdate.Text);
                writeFile.WriteLine("Article Title: " + txtConfirmtitle.Text);
                writeFile.WriteLine("Article Detail: " + txtConfirmdetail.Text);
            }
            this.Close();
            Home newhome = new Home();
            newhome.Show();
        }

        private String CreateFileName()
        {
            
            String dateNow = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss");
            return dateNow + ".txt";
        }

        private void panelConfirm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
