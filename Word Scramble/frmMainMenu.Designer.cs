
namespace Word_Scramble
{
    partial class frmMainMenu
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
            this.btnWordScramble = new System.Windows.Forms.Button();
            this.btnListEditor = new System.Windows.Forms.Button();
            this.btnListCreator = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWordScramble
            // 
            this.btnWordScramble.Location = new System.Drawing.Point(26, 17);
            this.btnWordScramble.Name = "btnWordScramble";
            this.btnWordScramble.Size = new System.Drawing.Size(163, 25);
            this.btnWordScramble.TabIndex = 0;
            this.btnWordScramble.Text = "Word Scramble";
            this.btnWordScramble.UseVisualStyleBackColor = true;
            this.btnWordScramble.Click += new System.EventHandler(this.btnWordScramble_Click);
            // 
            // btnListEditor
            // 
            this.btnListEditor.Location = new System.Drawing.Point(26, 48);
            this.btnListEditor.Name = "btnListEditor";
            this.btnListEditor.Size = new System.Drawing.Size(163, 25);
            this.btnListEditor.TabIndex = 1;
            this.btnListEditor.Text = "List Editor";
            this.btnListEditor.UseVisualStyleBackColor = true;
            this.btnListEditor.Click += new System.EventHandler(this.btnListEditor_Click);
            // 
            // btnListCreator
            // 
            this.btnListCreator.Location = new System.Drawing.Point(26, 79);
            this.btnListCreator.Name = "btnListCreator";
            this.btnListCreator.Size = new System.Drawing.Size(163, 25);
            this.btnListCreator.TabIndex = 2;
            this.btnListCreator.Text = "List Creator";
            this.btnListCreator.UseVisualStyleBackColor = true;
            this.btnListCreator.Click += new System.EventHandler(this.btnListCreator_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 124);
            this.Controls.Add(this.btnListCreator);
            this.Controls.Add(this.btnListEditor);
            this.Controls.Add(this.btnWordScramble);
            this.Name = "frmMainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWordScramble;
        private System.Windows.Forms.Button btnListEditor;
        private System.Windows.Forms.Button btnListCreator;
    }
}