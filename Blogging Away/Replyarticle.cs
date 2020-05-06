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
    public partial class Replyarticle : Form
    {
        static String fileLocation = "../../files/";
        public static String replyParentFile;

        public Replyarticle(String data)
        {
            replyParentFile = data;
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
            String data = "";
            String title = "";
            using (StreamReader readtext = new StreamReader(fileLocation + replyParentFile))
            {
                while (readtext.Peek() >= 0)
                {
                    data = readtext.ReadLine();
                    if (data.Contains("Article Title:")){
                        title = data;
                    }
                }
            }
            title = title.Remove(0, 14);
            txtArticletitle.Text = "Reply: " + title;
        }

        private void btnConfirmPost_Click(object sender, EventArgs e)
        {
            String createdFileName = CreateFileName();
            using (StreamWriter writeFile = new StreamWriter(fileLocation + createdFileName, true))
            {
                writeFile.WriteLine("Replied By:" + txtConfirmusername.Text);
                writeFile.WriteLine("Date: " + txtConfirmdate.Text);
                writeFile.WriteLine("Reply Title: " + txtConfirmtitle.Text);
                writeFile.WriteLine("Reply Detail: " + txtConfirmdetail.Text);
            }
            using (StreamWriter writeFile = File.AppendText(fileLocation + replyParentFile))
            {
                writeFile.WriteLine("Reply files: " + createdFileName);
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
