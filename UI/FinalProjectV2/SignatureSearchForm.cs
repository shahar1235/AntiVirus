using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FinalProjectV2
{
    public partial class SignatureSearchForm : Form
    {
        public SignatureSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string path_of_search = textBox1.Text;// take the path from the textbox
            // update the path in the pathes file cause the python algoritm needs it
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
            {
                file.WriteLine(path_of_search);
            }

            Process a =Process.Start("C:\\Users\\Laptop\\Desktop\\MileStones\\MileStone2\\searchForSignatureAlgoritm.py");// run the algoritm
            a.WaitForExit();

            //ReadOnlyAttribute the report of the python algoritm
            string soloutions = System.IO.File.ReadAllText(@"C:\\Users\\Laptop\\Desktop\\MileStones\\MileStone2\\reportSignatureSearch.txt");

            //organize the pelet for the posting
            string[] soloutions_for_gui = soloutions.Split(',');
            
            for (int i = 0; i < soloutions_for_gui.Length; i++)
            {
                
                if (i != soloutions_for_gui.Length - 1 && i != soloutions_for_gui.Length - 2)
                    listBox1.Items.Add(soloutions_for_gui[i]);
                else
                {
                    if (i == soloutions_for_gui.Length - 1)
                        label3.Text = soloutions_for_gui[i];
                    else
                        if (i == soloutions_for_gui.Length - 2)
                            label2.Text = soloutions_for_gui[i];
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox1.Text = TextPath;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignatureSearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
