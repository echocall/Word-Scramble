﻿
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
            this.clbAvailableLists = new System.Windows.Forms.CheckedListBox();
            this.btnAddNewList = new System.Windows.Forms.Button();
            this.clbListsInUse = new System.Windows.Forms.CheckedListBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnRemoveList = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbAvailableLists
            // 
            this.clbAvailableLists.AccessibleDescription = "Shows all the lists that can be added to the list the prompts will be chosen from" +
    ".";
            this.clbAvailableLists.AccessibleName = "Available Lists list box";
            this.clbAvailableLists.FormattingEnabled = true;
            this.clbAvailableLists.Location = new System.Drawing.Point(12, 12);
            this.clbAvailableLists.Name = "clbAvailableLists";
            this.clbAvailableLists.Size = new System.Drawing.Size(193, 184);
            this.clbAvailableLists.TabIndex = 0;
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.AccessibleDescription = "Allows the user to search their computer for a text file containing a list.";
            this.btnAddNewList.AccessibleName = "Add List From Text";
            this.btnAddNewList.Location = new System.Drawing.Point(14, 205);
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Size = new System.Drawing.Size(71, 40);
            this.btnAddNewList.TabIndex = 2;
            this.btnAddNewList.Text = "Add List From Text File";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnAddNewList_Click);
            // 
            // clbListsInUse
            // 
            this.clbListsInUse.AccessibleDescription = "Shows the lists that have been selected to show up in the word scramble.";
            this.clbListsInUse.AccessibleName = "Lits in use selected list box.";
            this.clbListsInUse.FormattingEnabled = true;
            this.clbListsInUse.Location = new System.Drawing.Point(306, 12);
            this.clbListsInUse.Name = "clbListsInUse";
            this.clbListsInUse.Size = new System.Drawing.Size(193, 184);
            this.clbListsInUse.TabIndex = 3;
            // 
            // btnAddList
            // 
            this.btnAddList.AccessibleDescription = "Adds the list to the Chosen lists list.";
            this.btnAddList.AccessibleName = "Select List";
            this.btnAddList.Location = new System.Drawing.Point(211, 43);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(89, 25);
            this.btnAddList.TabIndex = 4;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            // 
            // btnRemoveList
            // 
            this.btnRemoveList.AccessibleDescription = "Removes a selected list from the Lists in Use list box.";
            this.btnRemoveList.AccessibleName = "Remove List";
            this.btnRemoveList.Location = new System.Drawing.Point(211, 74);
            this.btnRemoveList.Name = "btnRemoveList";
            this.btnRemoveList.Size = new System.Drawing.Size(89, 25);
            this.btnRemoveList.TabIndex = 5;
            this.btnRemoveList.Text = "Remove List";
            this.btnRemoveList.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(211, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ListEditor
            // 
            this.AccessibleDescription = "Allows user to select which lists they want to have words show up in the scramble" +
    "r.";
            this.AccessibleName = "List manager screen.";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 319);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnRemoveList);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.clbListsInUse);
            this.Controls.Add(this.btnAddNewList);
            this.Controls.Add(this.clbAvailableLists);
            this.Name = "ListEditor";
            this.Text = "Select Lists to Include";
            this.Load += new System.EventHandler(this.frmListSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbAvailableLists;
        private System.Windows.Forms.Button btnAddNewList;
        private System.Windows.Forms.CheckedListBox clbListsInUse;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnRemoveList;
        private System.Windows.Forms.Button button3;
    }
}