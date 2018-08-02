using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectV2
{
    public partial class virusMessageBox : Form
    {
        public virusMessageBox()
        {
            InitializeComponent();
        }
        static virusMessageBox MsgBox; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string messageText)
        {
            MsgBox = new virusMessageBox();
            MsgBox.label1.Text = messageText;
            MsgBox.ShowDialog();
            return result;
        }
        private void virusMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            MsgBox.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MsgBox.Close();
        }
    }
}
