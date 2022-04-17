using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scramble
{
    class WordSet
    {
        // This contains a WordSet (list of Words) and the name of that WordSet.

        public string strListName { get; set; }
        public List<Word> lstWordList { get; set; } = new List<Word>();

        // Constructors
        public WordSet()
        {
            strListName = " ";
        }

        public WordSet(string Name)
        {
            strListName = Name;
        }

        public WordSet(List<Word> WordList)
        {
            lstWordList = WordList;
        }

        public WordSet(string Name, List<Word> WordList)
        {
            strListName = Name;
            lstWordList = WordList;
        }

        // Methods

        public void AddWords(ListItem<List<Word>> listItem)
        {
            lstWordList.AddRange(listItem.Value);
        }

        public void AddWords(string listname, ListItem<List<Word>> listItem)
        {
            strListName = listname;
            
        }

    }
}
