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

        string strScrambledWord;
        Word wordOriginal;

        int intHintCount = 0;
        int intHintsUsed = 0;
        int intHintsRemaining = 0;

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
            if (wsSelectedTransfer.ListCount() > 0)
            {
                InitializeComponent();
                wsSelected = wsSelectedTransfer;
            }
            else
            {
                MessageBox.Show("No word lists have been selected. Please go to List Editor to select word lists to use.", "Error", MessageBoxButtons.OK);

                // disable all buttons except for btnMainMenuReturn.
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Name != "btnMainMenuRetturn")
                        {
                            c.Enabled = false;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartScramble_Click(object sender, EventArgs e)
        {
            try
            {
                // This will randomly pick a word from the word list then send it through the scrambler.

                int intListCount = 0;
                int intRandomIndex = 0;

                // clear previous information that may be there.
                intHintCount = 0;
                intHintsRemaining = 0;
                intHintsUsed = 0;
                txtHint1.Text = "";
                txtHint2.Text = "";
                txtHint3.Text = "";
                lblRemainingHints.Text = "";
                lblHintCount.Text = "";

                // check how long wordset is.
                intListCount = wsSelected.ListCount();
                if (intListCount > 1)
                {
                    // if wordset contains more than one word list, randomly select a wordlist to get word from.
                    intRandomIndex = random.Next(0, intListCount);
                    wordOriginal = GetWord(wsSelected.liWordSet[intRandomIndex]);

                    if (wordOriginal.Length() > 0)
                    {
                        strScrambledWord = Scrambler(wordOriginal.strWord, wordOriginal.Length());
                        lblScrambledWord.Text = strScrambledWord;
                    }
                    else
                    {
                        MessageBox.Show("The word selected had no characters.  Word selected was at index " + intSelectedWordIndex.ToString() + " of list lstWordsToScramble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (intListCount == 1)
                {
                    // if wordset only contains one wordlist, use that.
                    wordOriginal = GetWord(wsSelected.liWordSet[0]);

                    if(wordOriginal.Length() > 0)
                    {
                        strScrambledWord = Scrambler(wordOriginal.strWord, wordOriginal.Length());
                        lblScrambledWord.Text = strScrambledWord;
                    }
                    else
                    {
                        MessageBox.Show("The word selected had no characters.  Word selected was at index " + intSelectedWordIndex.ToString() + " of list lstWordsToScramble", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("There are no words in the word list. Please add words to the word list before trying to scramble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtAnswer.Text == wordOriginal.strWord)
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

        private void btnGetHint_Click(object sender, EventArgs e)
        {
            try
            {
                if (intHintsRemaining > 0)
                {
                    switch (intHintsUsed)
                    {
                        case 0:
                            txtHint1.Text = wordOriginal.lstHints[intHintsUsed];
                            intHintsUsed++;
                            intHintsRemaining--;
                            lblRemainingHints.Text = intHintsRemaining.ToString();
                            break;
                        case 1:
                            txtHint2.Text = wordOriginal.lstHints[intHintsUsed];
                            intHintsUsed++;
                            intHintsRemaining--;
                            lblRemainingHints.Text = intHintsRemaining.ToString();
                            break;
                        case 2:
                            txtHint3.Text = wordOriginal.lstHints[intHintsUsed];
                            intHintsUsed++;
                            intHintsRemaining--;
                            lblRemainingHints.Text = intHintsRemaining.ToString();
                            break;
                        case 3:
                            intHintsRemaining = 0;
                            lblRemainingHints.Text = intHintsRemaining.ToString();
                            MessageBox.Show("No other hints exist for this Word.", "Error", MessageBoxButtons.OK);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("No other hints exist for this Word.", "Error", MessageBoxButtons.OK);
                    btnGetHint.Enabled = false;
                }
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

        private Word GetWord(ListItem<List<Word>> wordlist)
        {
            // pulls a single word out of a ListItem
            Word wordSelected;
            int intIndex = 0;

            // Pick a random word from the List
            intIndex = random.Next(0, wordlist.Value.Count);

            wordSelected = wordlist.Value[intIndex];

            // hint information
            HintCheck(wordSelected);

            return wordSelected;
        }

        private void HintCheck(Word wordOriginal)
        {
            if(wordOriginal.HintsExist() == true)
            {
                intHintCount = wordOriginal.HintCount();
                lblHintCount.Text = intHintCount.ToString();
                intHintsRemaining = intHintCount - intHintsUsed;
                lblRemainingHints.Text = intHintsRemaining.ToString();
            }
            else
            {
                lblHintCount.Text = "0";
                lblRemainingHints.Text = "0";
                btnGetHint.Enabled = false;
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
    }
}
