using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2Task2.Classes;

namespace CP2Task2
{
    class Program
    {
        // разделители
        public static char[] SplitChars = {' ', ',', '.', ':', '\t'};
        // кол-во строк на странице
        public static int LineAmountPerPage = 80;


        static void Main(string[] args)
        {
            Concordance concordance = new Concordance();
            int line = 1;
            FileInfo f = new FileInfo("c:\\test.txt");
            StreamReader s = f.OpenText();
            try
            {
                string readLine = null;
                while ((readLine = s.ReadLine()) != null)
                {
                    string[] split = readLine.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in split)
                    {
                        concordance.InsertWord(word, line);        
                    }
                    Console.WriteLine(readLine);
                    line++;
                }
                
            }
            finally
            {
                s.Close();
            }
            Console.ReadKey();
        }
    }
}
