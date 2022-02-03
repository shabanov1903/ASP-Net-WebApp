using L1_1.DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L1_1.Print
{
    internal interface IPrint
    {
        public void PrintToFile(string path, ContentDTO content);
    }
}
