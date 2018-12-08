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
                this.tabPage2.Name = "tabPage" + (tab + 1);
                new_tab.Size = new System.Drawing.Size(1424, 1044);
                this.tabPage2.TabIndex = tab;
                new_tab.UseVisualStyleBackColor = true;
                tabs.Add(new_tab);
                this.tabControl1.Controls.Add(new_tab);
            }

            tabs[tab].Text = title;
        }
        public Form1()
        {
            InitializeComponent();
            tabs.Add(this.tabPage1);
            tabs.Add(this.tabPage2);
        }
    }
}
