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
        HashSet<String> filesRead = new HashSet<String>();

        public Home()
        {
            InitializeComponent();
            RetrieveData();
            lblAbout.Text = "Bloggin Away - Communication made easy \nBlogging away allows authors post articles and \nallows the followers to reply to the articles";
            String newLabel = lblUser.Text + Environment.NewLine + Login.currentUser;
            lblUser.Text = newLabel;

            if (Login.currentUser != "admin" && Login.currentUser != "author")
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
            string[] fileNames = Directory.GetFiles(folderPath, "*.txt");
            DateTime[] creationTimes = new DateTime[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
                creationTimes[i] = new FileInfo(fileNames[i]).LastWriteTimeUtc;
            Array.Sort(creationTimes, fileNames);
            Array.Reverse(fileNames);
            String Data = "";
            IEnumerable<String> allFiles = Directory.EnumerateFiles(folderPath, "*.txt");

            foreach (String file in fileNames)
            {
                String data = "";
                HashSet<String> replyFiles = new HashSet<String>();

                if (!filesRead.Contains(Path.GetFileName(file)))
                {
                    using (StreamReader readtext = new StreamReader(file))
                    {
                        while (readtext.Peek() >= 0)
                        {
                            String lineread = readtext.ReadLine();
                            if (!lineread.Contains("Reply files: "))
                            {
                                data = data + lineread + Environment.NewLine;
                            }
                            else
                            {
                                lineread = lineread.Remove(0, 13);
                                replyFiles.Add(lineread);
                            }
                        }
                    }
                    Button button = new Button();
                    button.Text = "Reply";

                    data = data.Trim();


                    createDataForScreen(data, Path.GetFileName(file), replyFiles);
                    filesRead.Add(Path.GetFileName(file));
                }
            }
        }
        
        private void createDataForScreen(String data, String filename, HashSet<String> replyFiles)
        {
            ListView listView = new ListView();

            // adding textbox and button to panel
            flowLayoutmessagelist.Controls.Add(listView);
            

            listView.Controls.Add(CreateLabel(data, listView));
            CreateAndAddButton(listView, filename);

            foreach (String rf in replyFiles)
            {
                String filedata = "";

                using (StreamReader readtext = new StreamReader(folderPath + rf))
                {
                    while (readtext.Peek() >= 0)
                    {
                        String lineread = readtext.ReadLine();
                        if (!lineread.Contains("Reply files: "))
                        {
                            filedata = filedata + lineread + Environment.NewLine;
                        }
                    }
                }
                listView.Controls.Add(CreateLabel(filedata, listView));
                filesRead.Add(rf);
            }

            

            listView.Left = listView.Parent.Left + 5;
            listView.Width = listView.Parent.Width - 25;

            int sum = 0;
            int bottom = 0;
            foreach(Control c in listView.Controls)
            {
                sum += c.Height;
                c.BringToFront();
            }
            listView.Height = sum + 25;
            
            // add panel to the flowlayoutpanel
        }
        private void CreateAndAddButton(ListView l, String filename)
        {
            Button button = new Button();
            button.Text = "reply";

            button.Height = 35;
            button.Width = 111;
            button.BackColor = Color.Silver;
            button.Click += new EventHandler(replyButton_click);

            button.Tag = filename;
            int sum = 0;
            foreach (Control c in l.Controls)
            {
                sum += c.Height;
            }
            button.Location = new Point(0, sum + 10);
            l.Controls.Add(button);
        }
        protected void replyButton_click(object sender, EventArgs e)
        {
            String user = Login.currentUser;
            this.Hide();
            Replyarticle replyarticle = new Replyarticle((sender as Button).Tag.ToString());
            //replyarticle.replyParentFile = (sender as Button).Tag.ToString();
            //MessageBox.Show();
            replyarticle.Show();

        }

        private Label CreateLabel(String data, ListView parent)
        {
            Label label = new Label();
            label.Text = data;
            label.AutoSize = true;
            int sum = 0;
            foreach (Control c in parent.Controls)
            {
                sum += c.Height;
            }
            label.Location = new Point(0, sum + 10);

            return label;
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
                _textBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)14.0, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}
