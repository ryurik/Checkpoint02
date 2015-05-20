using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2Task2.Classes
{
    public class WordComparerByAsc : IComparer<BaseWord>
    {
        public int Compare(BaseWord x, BaseWord y)
        {
            if (x == null || y == null) return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            return (x.Word == y.Word) ? 0 : String.Compare(x.Word, y.Word, StringComparison.Ordinal);
        }
    }

    public class WordComparerByAmount : IComparer<BaseWord>
    {
        public int Compare(BaseWord x, BaseWord y)
        {
            if (x == null || y == null) return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            return (x.Amount == y.Amount) ? 0 : x.Amount > y.Amount ? 1 : -1;
        }
    }
}
