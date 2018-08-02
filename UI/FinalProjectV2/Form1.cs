using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace FinalProjectV2
{
    public partial class Form1 : Form
    {
        public WatchForm a = new WatchForm();
        public SignatureSearchForm b = new SignatureSearchForm();
        public controlForm c = new controlForm();
        public HelpForm d = new HelpForm();
        
        public Form1()
        {

            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            a.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
