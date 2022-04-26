using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Word_Scramble
{
    public partial class ScrambleSolve : Form
    {
        // The WordSet of selected words.
        WordSet wsSelected = new WordSet();

        Random random = new Random();
        String strOriginalWord = "";

        // allows us to access the index in the selected list
        int intSelectedWordIndex = 0;

        public ScrambleSolve()
        {
            InitializeComponent();
            MessageBox.Show("No word lists have been selected. Please go to List Editor to select word lists to use.", "Error", MessageBoxButtons.OK);
            
            // disable all buttons except for btnMainMenuReturn.
            foreach(Control c in this.Controls)
            {
                if(c is Button)
                {
                    if (c.Name != "btnMainMenuRetturn")
                    {
                        c.Enabled = false;
                    }
                }
            }

        }

        public ScrambleSolve(WordSet wsSelectedTransfer)
        {
            InitializeComponent();
            wsSelected = wsSelectedTransfer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartScramble_Click(object sender, EventArgs e)
        {
            try
            {
                // This will randomly pick a word from the word list then send it through the scrambler.
                String strScrambledWord = "";
                int intWordListLength = 0;


                // Check how long the list is.
                for (int i = 0; i < lstSelectedLists.Count; i++)
                {
                    intWordListLength = i;
                }

                if (intWordListLength <= 0)
                {
                    MessageBox.Show("There are no words in the word list. Please add words to the word list before trying to scramble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Pick a random word from the List
                    intSelectedWordIndex = random.Next(-1, intWordListLength);

                    strOriginalWord = lstSelectedLists[intSelectedWordIndex].strWord;

                    // Check string length
                    if (strOriginalWord.Length > 0)
                    {
                        // Get scrambled version of word
                        strScrambledWord = Scrambler(strOriginalWord, strOriginalWord.Length);

                        // Change the label text for the scrambled word to the scrambled word.
                        lblScrambledWord.Text = strScrambledWord;

                    }
                    else
                    {
                        MessageBox.Show("The word selected had no characters.  Word selected was at index " + intSelectedWordIndex.ToString() + " of list lstWordsToScramble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnswer.Text == strOriginalWord)
                {
                    MessageBox.Show("Success! You unscrambled the word correctly.", "Success", MessageBoxButtons.OK);
                    lblScrambledWord.Text = "";
                    txtAnswer.Text = "";
                    // add counter for correct answers here.
                    // Maybe something for tries?
                    // Would need class level variable.
                }
                else
                {
                    MessageBox.Show("Incorrect. That is not the word. Please try again.", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private String Scrambler(String strOriginalWord, int intWordLength)
        {
            String strScrambledWord = " ";
            try
            {
                // Takes in a word, uses Random class to shuffle the word, then passes the shuffled word out.
                // Code comes from a comment by user nan on stackoverflow with minor edit.
                // edits include: changing a var out for a char. 
                char chrSwap = ' ';
                char[] chrScramble;
                int intCharacterCount = intWordLength;
                int intScrambleIndex = 0;
                int intShuffleCount = 200;

                // Converts string to character array for easier manipulation.
                chrScramble = strOriginalWord.ToCharArray(0, intWordLength);

                // Shuffle the word multiple times.
                while (intShuffleCount > 1)
                {
                    intShuffleCount--;
                    intCharacterCount = intWordLength;
                    while (intCharacterCount > 1)
                    {
                        // We move backwards through the original word.
                        intCharacterCount--;
                        // grabbing the index of the first character to shuffle.
                        intScrambleIndex = random.Next(intCharacterCount + 1);
                        // grabbing the first character to shuffle
                        chrSwap = chrScramble[intScrambleIndex];
                        // Shuffle! We replace the character that we saved off into chrSwap with the one from from where chrSwap will go
                        chrScramble[intScrambleIndex] = chrScramble[intCharacterCount];
                        // putting chrSwap back into the array.
                        chrScramble[intCharacterCount] = chrSwap;
                    }
                }

                // Return the Scrambled word as a String.
               strScrambledWord = new string(chrScramble);
            }
            catch (Exception es) 
            {
                MessageBox.Show(es.Message);
            }

            return strScrambledWord;

        }

        private void btnGetHint_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }


        private void btnMainMenuReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
