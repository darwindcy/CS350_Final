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
            String newLabel = lblUser.Text + Environment.NewLine + Login.currentUser;
            lblUser.Text = newLabel;
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

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)13.0, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}
