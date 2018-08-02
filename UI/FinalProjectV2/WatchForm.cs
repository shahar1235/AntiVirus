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
using System.Threading;
using System.IO;


namespace FinalProjectV2
{
    public partial class WatchForm : Form
    {

        textBoxData save = new textBoxData();
        //Thread thread1 = new Thread(run_suspicion_process);
        static int[] savePid = new int[5];

        public WatchForm()
        {           
            InitializeComponent();       
        }

        public static void run_suspicion_process(object numberOfButton)
        {
            
            Process a =Process.Start("C:\\Users\\Laptop\\Desktop\\MileStones\\MileStone2\\watchAction.py");
            //Process a = Process.Start("C:\\Users\\Laptop\\Desktop\\a.py");
            savePid[int.Parse(numberOfButton.ToString())] = a.Id;            

        }
        private void button1_Click(object sender, EventArgs e)
        {     
            if (button1.Text == "Run")
            {
                string path_to_watch = textBox1.Text;

                //Console.WriteLine();
                if (Directory.Exists(path_to_watch))// Check if the path is really correct
                {                  
                    // update the path in the data base
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
                    {
                        file.WriteLine(path_to_watch);
                    }
                    run_suspicion_process(0);// run the algoritm and give him tthe index of text box 1
                    button1.Text = "Cancel";// I change the type of the button to give abillity to close him him
                    label2.Text = "Scanning";
                }
                else// in case the path is uncorrect
                {
                    label2.Text = "Invalid path, please try again!";
                }
           }
           else
                if (button1.Text == "Cancel")
            {
                label2.Text = "";
                int pidOfProcess = savePid[0];
                Process.GetProcessById(pidOfProcess).Kill();
                button1.Text = "Run";//here i supposed to close the program                
            }           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "Run")
            {
                string path_to_watch = textBox2.Text;

                //Console.WriteLine();
                if (Directory.Exists(path_to_watch))// Check if the path is really correct
                {
                    // update the path in the data base
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
                    {
                        file.WriteLine(path_to_watch);
                    }
                    run_suspicion_process(1);// run the algoritm and give him tthe index of text box 1
                    button2.Text = "Cancel";// I change the type of the button to give abillity to close him him
                    label4.Text = "Scanning";
                }
                else// in case the path is uncorrect
                {
                    label4.Text = "Invalid path, please try again!";
                }
            }
            else
                if (button2.Text == "Cancel")
            {
                label4.Text = "";
                int pidOfProcess = savePid[1];
                Process.GetProcessById(pidOfProcess).Kill();
                button2.Text = "Run";//here i supposed to close the program                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Run")
            {
                string path_to_watch = textBox3.Text;

                //Console.WriteLine();
                if (Directory.Exists(path_to_watch))// Check if the path is really correct
                {
                    // update the path in the data base
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
                    {
                        file.WriteLine(path_to_watch);
                    }
                    run_suspicion_process(2);// run the algoritm and give him tthe index of text box 1
                    button4.Text = "Cancel";// I change the type of the button to give abillity to close him him
                    label5.Text = "Scanning";
                }
                else// in case the path is uncorrect
                {
                    label5.Text = "Invalid path, please try again!";
                }
            }
            else
                if (button4.Text == "Cancel")
            {
                label5.Text = "";
                int pidOfProcess = savePid[2];
                Process.GetProcessById(pidOfProcess).Kill();
                button4.Text = "Run";//here i supposed to close the program                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Run")
            {
                string path_to_watch = textBox4.Text;

                //Console.WriteLine();
                if (Directory.Exists(path_to_watch))// Check if the path is really correct
                {
                    // update the path in the data base
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
                    {
                        file.WriteLine(path_to_watch);
                    }
                    run_suspicion_process(3);// run the algoritm and give him tthe index of text box 1
                    button5.Text = "Cancel";// I change the type of the button to give abillity to close him him
                    label6.Text = "Scanning";
                }
                else// in case the path is uncorrect
                {
                    label6.Text = "Invalid path, please try again!";
                }
            }
            else
                if (button5.Text == "Cancel")
            {
                label6.Text = "";
                int pidOfProcess = savePid[3];
                Process.GetProcessById(pidOfProcess).Kill();
                button5.Text = "Run";//here i supposed to close the program                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Run")
            {
                string path_to_watch = textBox5.Text;

                //Console.WriteLine();
                if (Directory.Exists(path_to_watch))// Check if the path is really correct
                {
                    // update the path in the data base
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\pathesOfWatch.txt", true))
                    {
                        file.WriteLine(path_to_watch);
                    }
                    run_suspicion_process(4);// run the algoritm and give him tthe index of text box 1
                    button6.Text = "Cancel";// I change the type of the button to give abillity to close him him
                    label7.Text = "Scanning";
                }
                else// in case the path is uncorrect
                {
                    label7.Text = "Invalid path, please try again!";
                }
            }
            else
                if (button6.Text == "Cancel")
            {
                label7.Text = "";
                int pidOfProcess = savePid[4];
                Process.GetProcessById(pidOfProcess).Kill();
                button6.Text = "Run";//here i supposed to close the program                
            }
        }

        private void WatchForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox1.Text = TextPath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox2.Text = TextPath;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox3.Text = TextPath;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox4.Text = TextPath;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string TextPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TextPath = folderBrowserDialog1.SelectedPath;
            }
            textBox5.Text = TextPath;
        }
    }
}
