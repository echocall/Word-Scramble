using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scramble
{
    class WordSet
    {
        // This class contains a List of ListItems to act as containers for the list of Available Lists and the list of Selected Lists.
        // This is the class I struggled with defining the most.

        public List<ListItem<List<Word>>> liWordSet { get; set; } = new List<ListItem<List<Word>>>();

        // Constructors
        public WordSet()
        {
            
        }

        public WordSet(string Name, List<Word> WordList)
        {
            ListItem<List<Word>> liNewList = new ListItem<List<Word>>(Name, WordList);
        }

        // Methods
        public void AddList(ListItem<List<Word>> listItem)
        {
            liWordSet.Add(listItem);
        }

        public void AddWords(string listname, List<Word> listWords)
        {
            ListItem<List<Word>> NewList = new ListItem<List<Word>>(listname, listWords);
            liWordSet.Add(NewList);
        }

        public void RemoveList(string strListNameToRemove)
        {
            int intIndexForRemoval = -1;
            int intIndex = 0;
            bool blnExists = new bool();

            blnExists = Exists(strListNameToRemove);

            if (blnExists == true)
            {
                for (intIndex = 0; intIndex != intIndexForRemoval; intIndex++)
                {
                    if (liWordSet[intIndex].DisplayText == strListNameToRemove)
                    {
                        intIndexForRemoval = intIndex;
                        break;
                    }
                }

                liWordSet.RemoveAt(intIndexForRemoval);
            }
            else
            {
                // do nothing.
            }

        }

        public void RemoveList(ListItem<List<Word>> liListToRemove)
        {
            string strListName = liListToRemove.DisplayText;

            RemoveList(strListName);
        }

        public bool Exists(string strStringName)
        {
            bool blnExists = new bool();
            int intIndex = 0;
            int intLength = liWordSet.Count;

            for (intIndex = 0; intIndex < intLength ; intIndex++)
            {
                if (liWordSet[intIndex].DisplayText == strStringName)
                {
                    blnExists = true;
                }
                else
                {
                    blnExists = false;
                }
            }
            return blnExists;
        }

        public int Count()
        {
            int intCount = 0;
            intCount = liWordSet.Count();
            return intCount;
        }


    }
}
