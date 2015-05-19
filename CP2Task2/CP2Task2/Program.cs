using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2Task2
{
    class Program
    {
        public static Char[] splitChars = {' ', ',', '.', ':', '\t'};
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo("c:\\test.txt");
            StreamReader s = f.OpenText();
            try
            {
                string readLine = null;
                while ((readLine = s.ReadLine()) != null)
                {
                    string[] split = readLine.Split(splitChars,StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(readLine);
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
