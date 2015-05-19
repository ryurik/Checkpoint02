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
        public char Letter { get; set; }
        public string Word { get; set; }
        public int Amount { get; set; }
        public ArrayList Pages { get; set; }
    }
}
