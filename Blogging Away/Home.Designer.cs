namespace Blogging_Away
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtScreen = new System.Windows.Forms.TextBox();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtScreen);
            this.panel1.Controls.Add(this.btnCreateNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(228, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 580);
            this.panel1.TabIndex = 0;
            // 
            // txtScreen
            // 
            this.txtScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScreen.Location = new System.Drawing.Point(148, 93);
            this.txtScreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtScreen.Multiline = true;
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.ReadOnly = true;
            this.txtScreen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScreen.Size = new System.Drawing.Size(458, 393);
            this.txtScreen.TabIndex = 2;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNew.Location = new System.Drawing.Point(231, 513);
            this.btnCreateNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(280, 48);
            this.btnCreateNew.TabIndex = 1;
            this.btnCreateNew.Text = "Create New Article";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blogging Away";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.TextBox txtScreen;
    }
}