using L1_1.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1.Print
{
    internal class Printer : IPrint
    {
        public void PrintToFile(string path, ContentDTO content)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(content.UserId);
                sw.WriteLine(content.Id);
                sw.WriteLine(content.Title);
                sw.WriteLine(content.Body);
                sw.WriteLine();
            }
        }
    }
}
