using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2Task2.Classes
{
    public class Concordance : ICollection<BaseWord>
    {
        // нужно будет сделать сортировку по Первой букве
        private ICollection<BaseWord> _word = new List<BaseWord>();

        public BaseWord ParseBaseWord(string word)
        {
            return _word.Any(x => x.Word.ToLower().Equals(word.ToLower())) ? _word.Where(x => x.Word.ToLower().Equals(word.ToLower())).ToArray()[0] : null;
        }

        public void InsertWord(string word, int line)
        {
            int page = line/Program.LineAmountPerPage + 1; // получаем страницу
            BaseWord baseWord = ParseBaseWord(word);

            if (baseWord != null)
            {
                baseWord.Amount++;
                if (!baseWord.Pages.Contains(page))
                    baseWord.Pages.Add(page);
            }
            else
            {
                baseWord = new BaseWord() {Word = word, Amount = 1, Pages = new ArrayList()};
                baseWord.Pages.Add(page);
                _word.Add(baseWord);
            } 
        }

        protected void Sort(IComparer<BaseWord> comparer)
        {
            var newList = _word.ToList();
            newList.Sort(comparer);
            _word = newList;
        }


        public void SortByAsc()
        {
            Sort(new WordComparerByAsc());
        }

        public void SortByAmount()
        {
            Sort(new WordComparerByAmount());
        }
        #region ICollection<BaseWord>
        public void Add(BaseWord item)
        {
            _word.Add(item);
        }

        public void Clear()
        {
            _word.Clear();
        }

        public bool Contains(BaseWord item)
        {
            return _word.Contains(item);
        }

        public void CopyTo(BaseWord[] array, int arrayIndex)
        {
            _word.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _word.Count(); }
        }

        public bool IsReadOnly
        {
            get { return _word.IsReadOnly; }
        }

        public bool Remove(BaseWord item)
        {
            return _word.Remove(item);
        }

        public IEnumerator<BaseWord> GetEnumerator()
        {
            return _word.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }
        #endregion
    }
}
