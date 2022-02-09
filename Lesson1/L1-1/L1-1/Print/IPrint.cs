using L1_1.DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace L1_1.Print
{
    internal interface IPrint
    {
        /// <summary>
        /// Этот метод позволяет распечатать объект класса ContentDTO в файл
        /// </summary>
        /// <param name="path">Путь для печати</param>
        /// <param name="content">Объект для печати</param>
        public void PrintToFile(string path, ContentDTO content);
    }
}
