using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scramble
{
    public class ListItem<ItemType>
    {
        //Holds a List of Words and a anme for that list
        // Name of list == DisplayText, List == Value
        public string DisplayText { get; set; }
        public ItemType Value { get; set; }

        public ListItem()
        {

        }

        public ListItem(string displaytext, ItemType value)
        {
            DisplayText = displaytext;
            Value = value;
        }


        public override string ToString()
        {
            return DisplayText.ToString();
        }
    }
}
