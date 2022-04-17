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
        WordSet wsSelected = new WordSet();
        WordSet wlSelectedList = new WordSet();

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnWordScramble_Click(object sender, EventArgs e)
        {
            try
            {
                Form frmScrambleSolve = new ScrambleSolve();
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
                ListEditor fListEdit = new ListEditor();
                // Call the method in ListEdit to get the SelectedList from MainMenu
               // fListEdit.SetSelected(wlSelectedList);
                fListEdit.ShowDialog();
                // Get the updated Selected LIst from ListEdit
               // wlSelectedList = fListEdit.SelectedLists;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
