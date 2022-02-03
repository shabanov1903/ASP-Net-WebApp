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
        // Открытие файлового потока по указанному пути и записть блока content
        public void PrintToFile(string path, ContentDTO content)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(content.userId);
                sw.WriteLine(content.id);
                sw.WriteLine(content.title);
                sw.WriteLine(content.body);
                sw.WriteLine();
            }
        }
    }
}
