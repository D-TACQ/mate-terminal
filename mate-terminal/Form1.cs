using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace mate_terminal
{
    public partial class Form1 : Form
    {

        List<TabPage> tabs = new List<TabPage>();

        public void addTab(int tab, string title, string cmd)
        {
            if (tab >= tabs.Count())
            {
                TabPage new_tab = new TabPage();

                new_tab.Location = new System.Drawing.Point(10, 48);
                new_tab.Name = "tabPage" + (tab + 1);
                new_tab.Size = new System.Drawing.Size(1424, 1044);
                new_tab.TabIndex = tab;
                new_tab.UseVisualStyleBackColor = true;
                tabs.Add(new_tab);
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
                richTextBox.Location = new System.Drawing.Point(3, 3);
                richTextBox.Name = "richTextBox" + (tab + 1);
                richTextBox.Size = new System.Drawing.Size(1418, 1038);
                richTextBox.TabIndex = tab;
                new_tab.Controls.Add(richTextBox);
                this.tabControl1.Controls.Add(new_tab);
            }
            TabPage tabPage = tabs[tab];
            tabPage.Text = title;
            foreach (Control control in tabPage.Controls)
            {
                Console.WriteLine(control.Name);
                RichTextBox rtb = (RichTextBox)control;
                rtb.Text = "pgmwashere this is " + tabPage.Text;
            }
        }
        public Form1()
        {
            InitializeComponent();
            tabs.Add(this.tabPage1);
            tabs.Add(this.tabPage2);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
