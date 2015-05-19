using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP2Task2.Interfaces;

namespace CP2Task2.Classes
{
    public class BaseWord : IBaseWord
    {
        private char _letter;
        private string _word;


        public char Letter {
            get { return _letter; }
        }

        public string Word
        {
            get { return _word; }
            set
            {
                _word = value.ToLower();
                _letter = value.ToUpper()[0]; // Вносим первую прописную букву
            }
        }

        public int Amount { get; set; }
        public ArrayList Pages { get; set; }
    }
}
