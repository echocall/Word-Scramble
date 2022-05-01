using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scramble
{
    public class Word
    {
        // This stores an individual word and its hints as a Word.

        // auto implmented properties
        public string strWord { get; set; }

        // hints are being turned into a list of strings for flexibility.
        public List<string> lstHints { get; set; } = new List<string>();

        // Constructors
        public Word()
        {
            strWord = " ";
        }

        public Word(string original)
        {
            strWord = original;
        }

        public Word(string original, string hint1)
        {
            strWord = original;
            lstHints.Add(hint1);
        }

        public Word(string original, string hint1, string hint2)
        {
            strWord = original;
            lstHints.Add(hint1);
            lstHints.Add(hint2);
        }

        public Word(string original, string hint1, string hint2, string hint3)
        {
            strWord = original;
            lstHints.Add(hint1);
            lstHints.Add(hint2);
            lstHints.Add(hint3);
        }

        public int Length()
        {
            return strWord.Length;
        }

        public int HintCount()
        {
            int intHintCount = 0;
            if(lstHints.Count > 0)
            {
                intHintCount = lstHints.Count;
            }
            return intHintCount;
        }

        public bool HintsExist()
        {
            bool blnHintsExist = false;
            if(lstHints.Count > 0)
            {
                blnHintsExist = true;
            }

            return blnHintsExist;
        }
    }
}
