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
    

    public partial class controlForm : Form
    {
        public bool listViewFlag = false;
        public ListBox listBoxThreats = new ListBox();
        
        public controlForm()
        {
            Thread thread1 = new System.Threading.Thread(new System.Threading.ThreadStart(updateListBox));
            thread1.Start();

            InitializeComponent();
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newSignature = textBox1.Text;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Signature_DB.txt", true))
            {
                file.WriteLine(newSignature);
            }
            textBox1.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void updateListBox()
        {
            bool checkIfNumber;
            int example;
            while (true)
            {
                try
                {
                    string soloutionHeuristic = System.IO.File.ReadAllText(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\report_virus.txt");
                    if (soloutionHeuristic != "")
                    {
                        if (ListBox.NoMatches == listBox1.FindStringExact(soloutionHeuristic))
                        {
                            listView1.Items.Add(soloutionHeuristic);
                            if (soloutionHeuristic.Contains("New virus"))
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.Red;
                            else
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.Green;

                        }

                    }
                    System.IO.File.WriteAllText(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\report_virus.txt", string.Empty);

                }
                catch
                { }

                try
                {
                    string soloutionHeuristic = System.IO.File.ReadAllText(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\reportSignatureSearch.txt");

                    string[] soloutions_for_listBox = soloutionHeuristic.Split(',');
                    for (int i = 0; i < soloutions_for_listBox.Length; i++)
                    {
                        checkIfNumber = int.TryParse(soloutions_for_listBox[i], out example);
                        if (soloutions_for_listBox[i] != "" && !checkIfNumber)
                        {
                            string newVirusStr = string.Format("New virus, location: \"{0}\" Based on the signature DB", soloutions_for_listBox[i]);
                            if (ListBox.NoMatches == listBox1.FindStringExact(newVirusStr))
                            {
                                listView1.Items.Add(newVirusStr);
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.Red;
                                
                            }

                        }
                    }


                    System.IO.File.WriteAllText(@"C:\Users\Laptop\Desktop\MileStones\MileStone2\reportSignatureSearch.txt", string.Empty);
                }
                catch
                { }

                System.Threading.Thread.Sleep(5000);

            }


        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
               
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Gray, e.Bounds, StringFormat.GenericDefault);
                //e.ForeColor = Color.Gray;
                
            }
            else 
                if (e.ForeColor != Color.Gray)               
            {
                
                ListBox temp = (ListBox)sender;
                string entry = temp.Items[e.Index].ToString();


                if (entry.Contains("New virus"))
                {
                    e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Red, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Green, e.Bounds, StringFormat.GenericDefault);

                }

                
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            int index = listView1.FocusedItem.Index;
            listView1.Items[index].BackColor = Color.Gray;
            
            if(listViewFlag)
            {
                listView1.Items[index].Selected = false;
                listViewFlag = false;
                return;
            }
            try
            {

                string virusSelected = listView1.Items[index].Text;
                listView1.Items[index].Selected = false;
                listViewFlag = true;
                if (virusSelected.Contains("New virus"))
                {
                    string pathVirus = virusSelected.Split('"')[1];
                    string dtVirus = (File.GetLastWriteTime(pathVirus)).ToString();
                    FileInfo virusInfo = new FileInfo(pathVirus);

                    string messageText = string.Format("The system found a malware  in \"{0}\"\n Date created: {1}\n Date modifited:{2}\nSize:{3}b\n do you want us to treat this virus?", pathVirus, virusInfo.CreationTime, virusInfo.LastWriteTime, virusInfo.Length);
                    DialogResult dialogResult = virusMessageBox.Show(messageText);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(@"" + pathVirus);
                    }
                    
                    //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            catch
            { }
        }
    }
}
