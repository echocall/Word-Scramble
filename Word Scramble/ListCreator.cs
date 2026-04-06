using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Word_Scramble
{
    public partial class ListCreator : Form
    {
        string strListName = "";

        WordSet wsAvailable = new WordSet();
        WordSet wsSelected = new WordSet();

        List<Word> NewWordList = new List<Word>();
        ListItem<List<Word>> liNewList = new ListItem<List<Word>>();

        public ListCreator()
        {
            InitializeComponent();
        }

        public ListCreator(WordSet wsAvailableTransfer)
        {
            InitializeComponent();
            wsAvailable = wsAvailableTransfer;
        }

        private void ListCreator_Load(object sender, EventArgs e)
        {

        }

        // for transfering the wordset back to MainMenu.
        public WordSet GetAvailable()
        {
            return this.wsAvailable;
        }

        // for transfering the wordset back to MainMenu.
        public WordSet GetSelected()
        {
            return this.wsSelected;
        }
    }
}
