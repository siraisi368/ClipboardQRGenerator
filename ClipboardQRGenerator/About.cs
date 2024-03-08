using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClipboardQRGenerator
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/siraisi368");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
