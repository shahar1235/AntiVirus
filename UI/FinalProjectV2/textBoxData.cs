using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectV2
{
    class textBoxData
    {
        string[] saveData = new string[4] {"","","",""};
       
        public void update_data(int index, string data)
        {
            index--;
            saveData[index] = data;
        }
        
        public string return_data(int index)
        {
            index--;
            Console.WriteLine(saveData[index]);
            return saveData[index];
        }
    }
}
