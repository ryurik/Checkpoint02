using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
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
        // анализируемый текст
        public static string FileName = "c:\\test.txt";
        // На экран или в файл
        public static bool ToFile = true;


        static void Main(string[] args)
        {
            Concordance concordance = new Concordance();
            int line = 1;

            if (!File.Exists(FileName))
            {
                Console.WriteLine("Не могу найти файл:{0}",FileName);
                Console.ReadKey();
            }
            FileInfo f = new FileInfo(FileName); // нужно, чтобы текст был в файле C:\Test.txt
            StreamReader s = f.OpenText();
            try
            {
                string readLine = null;
                while ((readLine = s.ReadLine()) != null)
                {
                    // можно ReExp сделать сплит, но 1 - в MSDN ссылается, что это тоже самое, а второе нужно регулярку подобрать Regex.Split(sentence, @"\W")
                    // string[] split = readLine.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
                    string[] split = Regex.Split(readLine, @"\W"); // разбить по словам?
                    foreach (var word in split.Where(word => word.Length > 0))
                    {
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

            concordance.SortByAsc(); // сортируем по словам

            string fileNameOutput = Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName) + "_concordance"), Path.GetExtension(FileName));
            char? currentLetter = null;

            StreamWriter sw = ToFile ? new StreamWriter(fileNameOutput) : null;

            try
            {
                foreach (var w in concordance)
                {
                    if (currentLetter != w.Letter)
                    {
                        if (ToFile && sw != null)
                            sw.WriteLine("\n{0}", w.Letter.ToString().ToUpper());
                        else
                            Console.WriteLine("\n{0}", w.Letter.ToString().ToUpper());

                        currentLetter = w.Letter;
                    }

                    if (ToFile && sw != null)
                        sw.Write("{0}{1}{2} : ", w.Word,
                            new String('.', (30 - w.Word.Length - w.Amount.ToString().Length)), w.Amount);
                    else
                        Console.Write("{0}{1}{2} : ", w.Word,
                            new String('.', (30 - w.Word.Length - w.Amount.ToString().Length)), w.Amount);

                    foreach (var p in w.Pages)
                    {
                        if (ToFile && sw != null)
                            sw.Write("{0} ", p);
                        else
                            Console.Write("{0} ", p);
                    }
                    if (ToFile && sw != null)
                        sw.WriteLine();
                    else
                        Console.WriteLine();
                }
            }
            finally
            {
                sw.Close();
            }
            if (ToFile)
                Console.WriteLine("Результат работы в файле {0}", fileNameOutput);

            Console.ReadKey();
        }

    }
}
