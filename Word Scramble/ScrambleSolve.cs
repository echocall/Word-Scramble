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
        // List made up of selected Lists
        // what was I doing here? Change later
        // 2026 note: Could replace 'list of lists' with a list of dictionaries. Will need to ajust how this is called elsewhere to match.
        List<Word> lstSelectedLists = new List<Word>();

        Random random = new Random();
        String strOriginalWord = "";

        // allows us to access the index in the selected list
        int intSelectedWordIndex = 0;

        public ScrambleSolve()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Randomly picks a word from the word list to send it through the scrambler.
        // TODO: Possibly add a check so if a word 'scrambles' into correct configuration it will scramble again.
        private void btnStartScramble_Click(object sender, EventArgs e)
        {
            try
            {
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

        // Checks if the player's guess is correct.
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


        // Takes in a word, uses Random class to shuffle the word, then passes the shuffled word out.
        // Code comes from a comment by user nan on stackoverflow with minor edit.
        // edits include: changing a var out for a char. 
        private String Scrambler(String strOriginalWord, int intWordLength)
        {
            String strScrambledWord = " ";
            try
            {
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

        // TODO: Implement showing one of the hints.
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

        // Opens the List Editor form on button click.
        private void btnListEditor_Click(object sender, EventArgs e)
        {
            try
            {
                Form fListEdit = new ListEditor();
                fListEdit.ShowDialog();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
