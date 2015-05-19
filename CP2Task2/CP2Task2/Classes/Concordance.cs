using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2Task2.Classes
{
    class Concordance : ICollection<BaseWord>
    {
        private readonly ICollection<BaseWord> _word = new List<BaseWord>();

        public BaseWord ParseBaseWord(string word)
        {
            return _word.Single(x => x.Word.ToLower().Equals(word.ToLower()));
        }

        public void InsertWord(string word, int line)
        {
            BaseWord baseWord = ParseBaseWord(word);

            if (baseWord != null)
            {
                baseWord.Amount++;
                if (!baseWord.Lines.Contains(line))
                    baseWord.Lines.Add(line);
            }
            else
            {
                baseWord = new BaseWord();
                baseWord.Amount = 1;
                baseWord.Lines.Add(line);
                _word.Add(baseWord);
            } 
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
