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
    public partial class ListEditor : Form
    {
        /* This form will handle adding, selecting, deleting, and editing lists.
         * It will take lists selected to go into rotation and merge them into one liss which gets sent back to ScrambleSolve.
         */
        // Default lists!
        List<Word> lstDefault = new List<Word>();
        List<Word> lstFarm = new List<Word>();

        // These hold the selected Prompts for other forms.
        WordSet wsAvailable = new WordSet();
        WordSet wsSelected = new WordSet();

        public ListEditor()
        {
            InitializeComponent();
          
        }

        public ListEditor(WordSet wsAvailableTransfer)
        {
            InitializeComponent();

            wsAvailable = wsAvailableTransfer;
        }

        public ListEditor(WordSet wsAvailableTransfer, WordSet wsSelectedTransfer)
        {
            InitializeComponent();

            wsAvailable = wsAvailableTransfer;
            wsSelected = wsSelectedTransfer;
        }

        private void frmListSelector_Load(object sender, EventArgs e)
        {
            int intAvailableLength = wsAvailable.Count();
            int intAvailableIndex = 0;
            int intSelectedLength = wsSelected.Count();
            int intSelectedIndex = 0;


            // add to clbAvailableLists
            while(intAvailableIndex < intAvailableLength)
            {
                clbAvailableLists.Items.Add(wsAvailable.liWordSet[intAvailableIndex], false);
                intAvailableIndex++;
            }

            // add to clbSelectedLists
            while(intSelectedIndex < intSelectedLength)
            {
                clbSelectedLists.Items.Add(wsSelected.liWordSet[intAvailableIndex], false);
                intSelectedIndex++;
            }

            clbAvailableLists.SelectedIndex = -1;
            clbSelectedLists.SelectedIndex = -1;

        }

        private void btnImportList_Click(object sender, EventArgs e)
        {
            try
            {
                // using the code from microsoft's documentation
                var fileContent = string.Empty;
                var filePath = string.Empty;
                
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // this is clearly for Windows file directory, would probably need to do a check for what OS system then a case to open the corresponding file directory for user's os.
                    openFileDialog.InitialDirectory = "c:\\";
                    // creating default filter for which files appear.
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the path of the specified file
                        filePath = openFileDialog.FileName;
                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                // MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
                // Call ImportList here to turn the newly imported a WordList with Words.
                ImportedListHandler(filePath, fileContent);

            }
            catch { }
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                // Move a checked PromptList from Available to Selected.
                // PromptList exists as a ListItem
                if (clbAvailableLists.CheckedItems.Count != 0)
                {
                    int i;
                    // step through the Checked List Box checking for checked items.
                    for (i = 0; i <= (clbAvailableLists.Items.Count-1); i++)
                    {
                        // If Item at index is Checked, transfer it over.
                        if(clbAvailableLists.GetItemChecked(i))
                        {
                            ListItem<List<Word>> currentPromptList = clbAvailableLists.Items[i] as ListItem<List<Word>>;
                            AddToSelected(currentPromptList);
                            wsAvailable.RemoveList(currentPromptList);
                        }
                    }

                    // Removes checked items after transfering.
                    while (clbAvailableLists.CheckedItems.Count > 0)
                    {
                        clbAvailableLists.Items.RemoveAt(clbAvailableLists.CheckedIndices[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Please check a list to move.", "Error");
                }

            }
            catch { }

        }

        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            try
            {
                // Move a checked PromptList from Selected to Available.
                // PromptList exists as a ListItem
                if (clbSelectedLists.CheckedItems.Count != 0)
                {
                    int i;
                    // step through the Checked List Box checking for checked items.
                    for (i = 0; i <= (clbSelectedLists.Items.Count - 1); i++)
                    {
                        // If Item at index is Checked, transfer it over.
                        if (clbSelectedLists.GetItemChecked(i))
                        {
                            ListItem<List<Word>> currentPromptList = clbSelectedLists.Items[i] as ListItem<List<Word>>;
                            AddToAvailable(currentPromptList);
                            wsSelected.RemoveList(currentPromptList);
                        }
                    }
                    // Removes checked items after transfering.
                    while (clbSelectedLists.CheckedItems.Count > 0)
                    {
                        clbSelectedLists.Items.RemoveAt(clbSelectedLists.CheckedIndices[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Please check a list to move.", "Error");
                }

            }
            catch { }
        }

        private void btnCheckAllAvailable_Click(object sender, EventArgs e)
        {
            // check all boxes in lstbxAvailable
            for (int i = 0; i < clbAvailableLists.Items.Count; i++)
            {
                clbAvailableLists.SetItemChecked(i, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // uncheck all boxes in lstbxAvailable
            for (int i = 0; i < clbAvailableLists.Items.Count; i++)
            {
                clbAvailableLists.SetItemChecked(i, false);
            }
        }

        private void btnCheckAllSelected_Click(object sender, EventArgs e)
        {
            // check all boxes in clbSelectedLists
            for (int i = 0; i < clbSelectedLists.Items.Count; i++)
            {
                clbSelectedLists.SetItemChecked(i, true);
            }
        }

        private void btnUncheckAllSelected_Click(object sender, EventArgs e)
        {
            // uncheck all boxes in clbSelectedLists
            for (int i = 0; i < clbSelectedLists.Items.Count; i++)
            {
                clbSelectedLists.SetItemChecked(i, false);
            }
        }

        private void ImportedListHandler(string filePath, string fileContent)
        {
            try
            {
                string strListName = string.Empty;
                List<Word> NewWordList = new List<Word>();
                string strTidyListName = string.Empty;
                int intHintCount;

                // Get name of list from FileName
                strListName = Path.GetFileName(filePath);

                // Turn Contents from File into WordList with Words
                using (StringReader reader = new StringReader(fileContent))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // pull apart the line to seperate Word from Hints.
                        string[] SplitWord = line.Split('|');
                        intHintCount = SplitWord.Length;

                        switch (intHintCount)
                        {
                            case 0:
                                // do nothing
                                break;
                            case 1:
                                Word NewWord = new Word(SplitWord[0]);
                                NewWordList.Add(NewWord);
                                break;
                            case 2:
                                NewWord = new Word(SplitWord[0], SplitWord[1]);
                                NewWordList.Add(NewWord);
                                break;
                            case 3:
                                NewWord = new Word(SplitWord[0], SplitWord[1], SplitWord[2]);
                                NewWordList.Add(NewWord);
                                break;
                            case 4:
                                NewWord = new Word(SplitWord[0], SplitWord[1], SplitWord[2], SplitWord[3]);
                                NewWordList.Add(NewWord);
                                break;
                        }
                    }
                }

                // Tidy up the list name
                string[] SplitTitle = strListName.Split('.');
                strTidyListName = SplitTitle[0];

                ListItem<List<Word>> liNewList = new ListItem<List<Word>>(strTidyListName, NewWordList);

                AddToAvailable(liNewList);

            }
            catch { }
        }

        private void AddToAvailable(ListItem<List<Word>> liNewList)
        {
            // add to the Available WordSet
            wsAvailable.AddList(liNewList);

            // add new wordlist to clbAvailableLists
            clbAvailableLists.BeginUpdate();
            clbAvailableLists.Items.Add(liNewList, false);
            clbAvailableLists.EndUpdate();
        }

        private void AddToSelected(ListItem<List<Word>> liNewList)
        {
            // add to the Selected WordSet
            wsSelected.AddList(liNewList);

            // Add to clbSelectedLists
            clbSelectedLists.BeginUpdate();
            clbSelectedLists.Items.Add(liNewList);
            clbSelectedLists.EndUpdate();
        }

        private void btnReturnToMain_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // for transfering the wordsets back to MainMenu.
        public WordSet GetAvailable()
        {
            return this.wsAvailable;
            
        }

        public WordSet GetSelected()
        {
            return this.wsSelected;
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            ListCreator fListCreator = new ListCreator(wsAvailable);
            fListCreator.ShowDialog();
            wsAvailable = fListCreator.GetAvailable();
        }
    }
}
