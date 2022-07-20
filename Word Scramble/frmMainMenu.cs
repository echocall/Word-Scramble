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
    public partial class frmMainMenu : Form
    {
        WordSet wsAvailable = new WordSet();
        WordSet wsSelected = new WordSet();

        List<Word> lstDefault = new List<Word>();
        List<Word> lstFarm = new List<Word>();

        public frmMainMenu()
        {
            // first start up generates the Default and Farm lists and adds them to wsAvailable
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

            wsAvailable.AddWords("Default", lstDefault);
            wsAvailable.AddWords("Farm", lstFarm);
        }

        public frmMainMenu(WordSet wsAvailableTransfer, WordSet wsSelectedTransfer)
        {
            // for passing information from ListEditor maybe
            InitializeComponent();

            wsAvailable = wsAvailableTransfer;
            wsSelected = wsSelectedTransfer;
        }

        private void btnWordScramble_Click(object sender, EventArgs e)
        {
            try
            {
                Form frmScrambleSolve = new ScrambleSolve(wsSelected);
                frmScrambleSolve.ShowDialog();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnListEditor_Click(object sender, EventArgs e)
        {
            try
            {
                ListEditor fListEdit = new ListEditor(wsAvailable, wsSelected);
                // Call the method in ListEdit to get the SelectedList from MainMenu
                fListEdit.ShowDialog();
                // Get the updated WordSets from ListEdit
                wsAvailable = fListEdit.GetAvailable();
                wsSelected = fListEdit.GetSelected();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnListCreator_Click(object sender, EventArgs e)
        {
            try
            {
                ListCreator fListCreator = new ListCreator(wsAvailable);
                fListCreator.ShowDialog();
                wsAvailable = fListCreator.GetAvailable();
                // Get the updated WordSets from ListEdit
                wsAvailable = fListCreator.GetAvailable();
                wsSelected = fListCreator.GetSelected();
            }
            catch (Exception es)
            {

            }
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
