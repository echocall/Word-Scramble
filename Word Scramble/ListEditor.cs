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
         * It will take lists selected to go into rotation and merge them into one lisT which gets sent back to ScrambleSolve.
         */

        // Default lists!
        List<Word> lstDefault = new List<Word>();
        List<Word> lstFarm = new List<Word>();

        public ListEditor()
        {
            InitializeComponent();

            // DefaultList stuff
            Word Moon = new Word("Moon", "Orbits the Earth");
            Word Soon = new Word("Soon", "In or after a short time.", "If its followed by (TM) you know its not happening anytime ____.");
            Word Loom = new Word("Loom", "An apparatus for making fabric by weaving yarn or thread.", "Weaver and their ____.");
            Word Craft = new Word("Craft", "The act of creating something.");
            Word Mine = new Word("Mine", "Digging in the ground for resources such as coal.", "It's not yours its ____.");
            Word Town = new Word("Town", "Larger than a village, smaller than a city.", "Just a small ____ girl Livin' in a lonely world");
            Word Cute = new Word("Cute", "attractive in a pretty or endearing way.", "As ____ as a kitten.");

            // Add prompts
            lstDefault.Add(Moon);
            lstDefault.Add(Soon);
            lstDefault.Add(Loom);
            lstDefault.Add(Craft);
            lstDefault.Add(Mine);
            lstDefault.Add(Town);
            lstDefault.Add(Cute);

            // FarmList stuff
            Word Barn = new Word("Barn", "A large building for animal housing or storage.");
            Word Coop = new Word("Coop", "A small building for housing poultry.", "When built freestanding, often has a method of closing it to keep predators from getting in.");
            Word Pasture = new Word("Pasture", "Outdoor pen with grass", "Land for grazing animals.");
            Word Stall = new Word("Stall", "An individual compartment for an animal in a stable or barn.");
            Word Hay = new Word("Hay", "Animal feed made from dried grass.", "Comes in bales.");
            Word Corn = new Word("Corn", "Grows on a stalk, commonly depicted as yellow.", "Starred in the horror movie Children of the ____");
            Word Cow = new Word("Cow", "Bovine that can be raised for milk or meat or both.", "Moo");
            Word Chicken = new Word("Chicken", "Poultry raised for meat or eggs.", "Known for being Kentucky Fried.", "Cluck");
            Word Sheep = new Word("Sheep", "Ovine raised for wool, meat, milk, or some combination of all three.", "Has lambs, needs to be sheared.", "Baa");
            Word Horse = new Word("Horse", "Equine raised for running or working.", "Neigh");

            // Add prompts
            lstFarm.Add(Barn);
            lstFarm.Add(Coop);
            lstFarm.Add(Pasture);
            lstFarm.Add(Stall);
            lstFarm.Add(Hay);
            lstFarm.Add(Corn);
            lstFarm.Add(Cow);
            lstFarm.Add(Chicken);
            lstFarm.Add(Sheep);
            lstFarm.Add(Horse);
        }
        // TODO: Check if we should change to auto-find other new lists in the WordList file save location and add them here too.
        private void frmListSelector_Load(object sender, EventArgs e)
        {
            // Load the box.
            lstbxAvailableLists.Items.Add(new ListItem<List<Word>>("Default", lstDefault), true);
            lstbxAvailableLists.Items.Add(new ListItem<List<Word>>("Farm", lstFarm), false);
            lstbxAvailableLists.SelectedIndex = -1;
        }
        
        // TODO: Currently AddNewList doesn't work, it should open a dialog for adding a new list.
        private void btnAddNewList_Click(object sender, EventArgs e)
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
                // Call ImportList information here to turn the newly imported file a WordList with Words.
                ImportList(filePath, fileContent);

            }
            catch { }
        }

        // Gets the file path and content from the file dialog, turns the content into a WordList with Words, and adds the new list to the available lists.
        private void ImportList(string filePath, string fileContent)
        {
            try
            {
                string strListName = string.Empty;
                List<Word> NewWordList = new List<Word>();
                string strTidyListName = string.Empty;

                // Get name of list from FileName
                strListName = Path.GetFileName(filePath);

                // Turn Contents from File into WordList with Words
                using (StringReader reader = new StringReader(fileContent))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        // pull apart the line to seperate Word from Hints.
                        // thank you documentation and google for pointing me at said documentation.
                        string[] SplitWord = line.Split('|');

                        // This works for a word with a Single hint, need to refine later.
                        Word NewWord = new Word(SplitWord[0], SplitWord[1]);

                        // Add the new word to the NewList
                        NewWordList.Add(NewWord);
                    }
                }


                // Tidy up the list name
                string[] SplitTitle = strListName.Split('.');
                strTidyListName = SplitTitle[0];

                // add new wordlist to the checked list box of available lists
                lstbxAvailableLists.BeginUpdate();
                lstbxAvailableLists.Items.Add(new ListItem<List<Word>>(strTidyListName, NewWordList), false);
                lstbxAvailableLists.EndUpdate();

            }
            catch { }
        }

        // Moves a checked PromptList from Available to Selected.
        private void btnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                // Move a checked PromptList from Available to Selected.
                // PromptList exists as a ListItem
                if (lstbxAvailableLists.CheckedItems.Count != 0)
                {
                    // Get the checked items as a List Item
                    // loop through to transfer all the checked Lists.

                    // index for stepping through initial list.
                    int i;
                    // step through the Checked List Box checking for checked items.
                    for (i = 0; i <= (lstbxAvailableLists.Items.Count-1); i++)
                    {
                        // If Item at index is Checked, transfer it over.
                        if(lstbxAvailableLists.GetItemChecked(i))
                        {
                            ListItem<List<Word>> currentPromptList = lstbxAvailableLists.Items[i] as ListItem<List<Word>>;
                            clbSelectedLists.BeginUpdate();
                            clbSelectedLists.Items.Add(currentPromptList);
                            clbSelectedLists.EndUpdate();

                            // Add PromptList to Selected WordList
                            Globals.wlSelected.lstWordList.Add(currentPromptList.Value);
                        }
                    }

                    // Removes checked items after transfering.
                    // So much simpler than my plan of using a list.
                    while (lstbxAvailableLists.CheckedItems.Count > 0)
                    {
                        lstbxAvailableLists.Items.RemoveAt(lstbxAvailableLists.CheckedIndices[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Please check a list to move.", "Error");
                }

            }
            catch { }

        }

        //Removed a checked PromptList from Selected to Available.
        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            try
            {
                // Move a checked PromptList from Selected to Available.
                // PromptList exists as a ListItem
                if (clbSelectedLists.CheckedItems.Count != 0)
                {
                    // Get the checked items as a List Item
                    // loop through to transfer all the checked Lists.
                    int i;
                    // ListItem<List<Word>> currentPromptList = clbSelectedLists.SelectedItem as ListItem<List<Word>>;
                    // step through the Checked List Box checking for checked items.
                    for (i = 0; i <= (clbSelectedLists.Items.Count - 1); i++)
                    {
                        // If Item at index is Checked, transfer it over.
                        if (clbSelectedLists.GetItemChecked(i))
                        {
                            ListItem<List<Word>> currentPromptList = clbSelectedLists.Items[i] as ListItem<List<Word>>;
                            // Add WordList to list of available wordlists.
                            lstbxAvailableLists.BeginUpdate();
                            lstbxAvailableLists.Items.Add(currentPromptList);
                            lstbxAvailableLists.EndUpdate();

                            // Remove PromptList to Selected WordList
                            Globals.wlSelected.lstWordList.Remove(currentPromptList.Value);
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

        // Checks all the boxes in lstbxAvailableLists.
        private void btnCheckAllAvailable_Click(object sender, EventArgs e)
        {
            // check all boxes in lstbxAvailable
            for (int i = 0; i < lstbxAvailableLists.Items.Count; i++)
            {
                lstbxAvailableLists.SetItemChecked(i, true);
            }
        }

        // TODO: Rename this and its associated button on the form.
        // Unchecks all the boxes in lstbxAvailableLists.
        private void button1_Click(object sender, EventArgs e)
        {
            // uncheck all boxes in lstbxAvailable
            for (int i = 0; i < lstbxAvailableLists.Items.Count; i++)
            {
                lstbxAvailableLists.SetItemChecked(i, false);
            }
        }

        // Checks all the boxes in lstbxSelectedLists.
        private void btnCheckAllSelected_Click(object sender, EventArgs e)
        {
            // check all boxes in clbSelectedLists
            for (int i = 0; i < clbSelectedLists.Items.Count; i++)
            {
                clbSelectedLists.SetItemChecked(i, true);
            }
        }

        // Unchecks all the boxes in lstbxSelectedLists.
        private void btnUncheckAllSelected_Click(object sender, EventArgs e)
        {
            // uncheck all boxes in clbSelectedLists
            for (int i = 0; i < clbSelectedLists.Items.Count; i++)
            {
                clbSelectedLists.SetItemChecked(i, false);
            }
        }
    }
}
