
namespace Word_Scramble
{
    partial class ListEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImportList = new System.Windows.Forms.Button();
            this.clbSelectedLists = new System.Windows.Forms.CheckedListBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnDeselectList = new System.Windows.Forms.Button();
            this.lblAvailableLists = new System.Windows.Forms.Label();
            this.lblSelectedLists = new System.Windows.Forms.Label();
            this.btnCheckAllAvailable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUncheckAllSelected = new System.Windows.Forms.Button();
            this.btnCheckAllSelected = new System.Windows.Forms.Button();
            this.btnReturnToMain = new System.Windows.Forms.Button();
            this.clbAvailableLists = new System.Windows.Forms.CheckedListBox();
            this.btnCreateList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportList
            // 
            this.btnImportList.AccessibleDescription = "Allows the user to search their computer for a text file containing a list.";
            this.btnImportList.AccessibleName = "Add List From Text";
            this.btnImportList.Location = new System.Drawing.Point(14, 273);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Size = new System.Drawing.Size(83, 34);
            this.btnImportList.TabIndex = 2;
            this.btnImportList.Text = "Import List";
            this.btnImportList.UseVisualStyleBackColor = true;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
            // 
            // clbSelectedLists
            // 
            this.clbSelectedLists.AccessibleDescription = "Shows the lists that have been selected to show up in the word scramble.";
            this.clbSelectedLists.AccessibleName = "Lits in use selected list box.";
            this.clbSelectedLists.FormattingEnabled = true;
            this.clbSelectedLists.Location = new System.Drawing.Point(306, 31);
            this.clbSelectedLists.Name = "clbSelectedLists";
            this.clbSelectedLists.Size = new System.Drawing.Size(193, 184);
            this.clbSelectedLists.TabIndex = 3;
            // 
            // btnAddList
            // 
            this.btnAddList.AccessibleDescription = "Adds the list to the Chosen lists list.";
            this.btnAddList.AccessibleName = "Select List";
            this.btnAddList.Location = new System.Drawing.Point(211, 62);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(89, 25);
            this.btnAddList.TabIndex = 4;
            this.btnAddList.Text = "Add";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnDeselectList
            // 
            this.btnDeselectList.AccessibleDescription = "Removes a selected list from the Lists in Use list box.";
            this.btnDeselectList.AccessibleName = "Deselect List";
            this.btnDeselectList.Location = new System.Drawing.Point(211, 93);
            this.btnDeselectList.Name = "btnDeselectList";
            this.btnDeselectList.Size = new System.Drawing.Size(89, 25);
            this.btnDeselectList.TabIndex = 5;
            this.btnDeselectList.Text = "Remove";
            this.btnDeselectList.UseVisualStyleBackColor = true;
            this.btnDeselectList.Click += new System.EventHandler(this.btnRemoveList_Click);
            // 
            // lblAvailableLists
            // 
            this.lblAvailableLists.AccessibleName = "Available Lists";
            this.lblAvailableLists.AutoSize = true;
            this.lblAvailableLists.Location = new System.Drawing.Point(11, 13);
            this.lblAvailableLists.Name = "lblAvailableLists";
            this.lblAvailableLists.Size = new System.Drawing.Size(74, 13);
            this.lblAvailableLists.TabIndex = 7;
            this.lblAvailableLists.Text = "Available Lists";
            // 
            // lblSelectedLists
            // 
            this.lblSelectedLists.AutoSize = true;
            this.lblSelectedLists.Location = new System.Drawing.Point(303, 13);
            this.lblSelectedLists.Name = "lblSelectedLists";
            this.lblSelectedLists.Size = new System.Drawing.Size(73, 13);
            this.lblSelectedLists.TabIndex = 8;
            this.lblSelectedLists.Text = "Selected Lists";
            // 
            // btnCheckAllAvailable
            // 
            this.btnCheckAllAvailable.AccessibleDescription = "Allows user to check all checkboxes in Available Lists.";
            this.btnCheckAllAvailable.AccessibleName = "Check All Available";
            this.btnCheckAllAvailable.Location = new System.Drawing.Point(14, 221);
            this.btnCheckAllAvailable.Name = "btnCheckAllAvailable";
            this.btnCheckAllAvailable.Size = new System.Drawing.Size(83, 34);
            this.btnCheckAllAvailable.TabIndex = 9;
            this.btnCheckAllAvailable.Text = "Check All Lists";
            this.btnCheckAllAvailable.UseVisualStyleBackColor = true;
            this.btnCheckAllAvailable.Click += new System.EventHandler(this.btnCheckAllAvailable_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "Allows user to uncheck all checkboxes in Available Lists.";
            this.button1.AccessibleName = "Uncheck All Available";
            this.button1.Location = new System.Drawing.Point(113, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Uncheck All Lists";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUncheckAllSelected
            // 
            this.btnUncheckAllSelected.AccessibleDescription = "Allows user to uncheck all checkboxes in Selected Lists.";
            this.btnUncheckAllSelected.AccessibleName = "Uncheck All Selected";
            this.btnUncheckAllSelected.Location = new System.Drawing.Point(405, 221);
            this.btnUncheckAllSelected.Name = "btnUncheckAllSelected";
            this.btnUncheckAllSelected.Size = new System.Drawing.Size(83, 34);
            this.btnUncheckAllSelected.TabIndex = 12;
            this.btnUncheckAllSelected.Text = "Uncheck All Lists";
            this.btnUncheckAllSelected.UseVisualStyleBackColor = true;
            this.btnUncheckAllSelected.Click += new System.EventHandler(this.btnUncheckAllSelected_Click);
            // 
            // btnCheckAllSelected
            // 
            this.btnCheckAllSelected.AccessibleDescription = "Allows user to check all checkboxes in Selected Lists.";
            this.btnCheckAllSelected.AccessibleName = "Check All Selected";
            this.btnCheckAllSelected.Location = new System.Drawing.Point(306, 221);
            this.btnCheckAllSelected.Name = "btnCheckAllSelected";
            this.btnCheckAllSelected.Size = new System.Drawing.Size(83, 34);
            this.btnCheckAllSelected.TabIndex = 11;
            this.btnCheckAllSelected.Text = "Check All Lists";
            this.btnCheckAllSelected.UseVisualStyleBackColor = true;
            this.btnCheckAllSelected.Click += new System.EventHandler(this.btnCheckAllSelected_Click);
            // 
            // btnReturnToMain
            // 
            this.btnReturnToMain.Location = new System.Drawing.Point(211, 273);
            this.btnReturnToMain.Name = "btnReturnToMain";
            this.btnReturnToMain.Size = new System.Drawing.Size(89, 34);
            this.btnReturnToMain.TabIndex = 13;
            this.btnReturnToMain.Text = "Return to Main Menu";
            this.btnReturnToMain.UseVisualStyleBackColor = true;
            this.btnReturnToMain.Click += new System.EventHandler(this.btnReturnToMain_Click);
            // 
            // clbAvailableLists
            // 
            this.clbAvailableLists.AccessibleDescription = "Shows all the lists that can be added to the list the prompts will be chosen from" +
    ".";
            this.clbAvailableLists.AccessibleName = "Available Lists list box";
            this.clbAvailableLists.FormattingEnabled = true;
            this.clbAvailableLists.Location = new System.Drawing.Point(12, 31);
            this.clbAvailableLists.Name = "clbAvailableLists";
            this.clbAvailableLists.Size = new System.Drawing.Size(193, 184);
            this.clbAvailableLists.TabIndex = 0;
            // 
            // btnCreateList
            // 
            this.btnCreateList.Location = new System.Drawing.Point(113, 273);
            this.btnCreateList.Name = "btnCreateList";
            this.btnCreateList.Size = new System.Drawing.Size(83, 34);
            this.btnCreateList.TabIndex = 14;
            this.btnCreateList.Text = "Create New List";
            this.btnCreateList.UseVisualStyleBackColor = true;
            this.btnCreateList.Click += new System.EventHandler(this.btnCreateList_Click);
            // 
            // ListEditor
            // 
            this.AccessibleDescription = "Allows user to select which lists they want to have words show up in the scramble" +
    "r.";
            this.AccessibleName = "List manager screen.";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 319);
            this.Controls.Add(this.btnCreateList);
            this.Controls.Add(this.btnReturnToMain);
            this.Controls.Add(this.btnUncheckAllSelected);
            this.Controls.Add(this.btnCheckAllSelected);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCheckAllAvailable);
            this.Controls.Add(this.lblSelectedLists);
            this.Controls.Add(this.lblAvailableLists);
            this.Controls.Add(this.btnDeselectList);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.clbSelectedLists);
            this.Controls.Add(this.btnImportList);
            this.Controls.Add(this.clbAvailableLists);
            this.Name = "ListEditor";
            this.Text = "Select Lists to Include";
            this.Load += new System.EventHandler(this.frmListSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImportList;
        private System.Windows.Forms.CheckedListBox clbSelectedLists;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnDeselectList;
        private System.Windows.Forms.Label lblAvailableLists;
        private System.Windows.Forms.Label lblSelectedLists;
        private System.Windows.Forms.Button btnCheckAllAvailable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUncheckAllSelected;
        private System.Windows.Forms.Button btnCheckAllSelected;
        private System.Windows.Forms.Button btnReturnToMain;
        private System.Windows.Forms.CheckedListBox clbAvailableLists;
        private System.Windows.Forms.Button btnCreateList;
    }
}