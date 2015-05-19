using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CP2Task2.Classes;

namespace CP2Task2
{
    class Program
    {
        // разделители
        public static char[] SplitChars = {' ', ',', '.', ':', '\t', '\\', '"', '-', '!', '@', '?', '*','(', ')', '[', ']', '{', '}', '|', '/', '+','_', '&', ';', '='};
        // кол-во строк на странице
        public static int LineAmountPerPage = 5;


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
                    // можно ReExp сделать сплит, но 1 - в MSDN ссылается, что это тоже самое, а второе нужно регулярку подобрать Regex.Split(sentence, @"\W")
                    // string[] split = readLine.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
                    string[] split = Regex.Split(readLine, @"\W"); // разбить по словам?
                    foreach (var word in split)
                    {
                        if (word.Length > 0)
                            concordance.InsertWord(word, line);        
                    }
                    //Console.WriteLine(readLine);
                    line++;
                }
                
            }
            finally
            {
                s.Close();
            }

            foreach (var w in concordance)
            {
                Console.Write("{0}{1}{2} : ", w.Word, new String('.', (30 - w.Word.Length - w.Amount.ToString().Length)), w.Amount);
                foreach (var p in w.Pages)
                {
                    Console.Write("{0} ", p);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
