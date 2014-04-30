using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad.NET
{
    public partial class frmMain : Form
    {
        public string currentFileName = "";
        public string currentTitle = "Untitled";
        frmFindReplace findReplaceForm;
        public frmMain()
        {
            InitializeComponent();
            findReplaceForm = new frmFindReplace(this);
            findReplaceForm.Owner = this;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Paste();

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Cut();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Make "delete" work normally when selection length == 0
            if (txtMain.SelectionLength > 0)
            {
                int selStart = txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.Substring(0, txtMain.SelectionStart) + txtMain.Text.Substring(txtMain.SelectionStart + txtMain.SelectionLength);
                txtMain.SelectionStart = selStart;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            txtMain.Font = fontDialog1.Font;
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            updateStatusBar();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
            int selStart = txtMain.SelectionStart;
            txtMain.Text = txtMain.Text.Substring(0, txtMain.SelectionStart) + DateTime.Now.ToString("hh:mm tt dd/mm/yyyy") + txtMain.Text.Substring(txtMain.SelectionStart);
            txtMain.SelectionStart = selStart + 19;

        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmGoToDialog goToDialog = new frmGoToDialog())
            {
                DialogResult res = goToDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    int line = goToDialog.goToLine;
                    if (line < 1 || txtMain.Lines.Length < line)
                        return;

                    txtMain.SelectionStart = txtMain.GetFirstCharIndexFromLine(line - 1);
                    txtMain.SelectionLength = 0;
                    updateStatusBar();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocument();
        }


        private bool checkedForUnsavedWork()
        {
            bool savedWork = false;
            if (currentFileName == "" && txtMain.TextLength == 0)
            {
                // If it's a new, unsaved file with length 0, we ignore it :)
                return true;
            }
            if (txtMain.TextLength > 0 || txtMain.CanUndo)
            {
                // There is text, or it has been edited
                DialogResult res = MessageBox.Show("Do you want to save changes to " + currentTitle + "?", "Notepad.NET", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (currentFileName == "")
                    {
                        // Display "Save As.." dialog                            
                        savedWork = saveFileAs();
                    }
                    else
                    {
                        // save currentFileName
                        savedWork = saveFile();
                    }
                }
                else if (res == DialogResult.No)
                {
                    // Don't want to save 
                    savedWork = true;
                        
                }
                else if (res == DialogResult.Cancel)
                {
                    // Cancel
                    savedWork = false;
                }
                
            }
            return savedWork;
            
        }
        private void newDocument()
        {

            if (checkedForUnsavedWork())
            {
                txtMain.Text = "";
                currentTitle = "Untitled";
                this.Text = currentTitle + " - Notepad.NET";
            }
            /*if (txtMain.TextLength > 0)
            {
                // There is text, and it has been edited
                if (txtMain.CanUndo)
                {
                    DialogResult res = MessageBox.Show("Do you want to save changes to " + currentTitle + "?", "Notepad.NET", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        if (currentFileName == "")
                        {
                            // Display "Save As.." dialog                            
                            saveFileAs();

                            // Clear text
                            if (clearText) txtMain.Text = "";
                        }
                        else
                        {
                            // save currentFileName
                            saveFile();

                            // Clear text
                            if (clearText) txtMain.Text = "";
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        // Don't save + clear text
                        if (clearText) txtMain.Text = "";
                    }
                    //else if (res == DialogResult.Cancel)
                    //{
                    //    // Cancel + do nothing
                    //}
                }
                else
                {
                    if (clearText) txtMain.Text = "";
                }
                currentTitle = "Untitled";
                this.Text = currentTitle + " - Notepad.NET";
            }*/

        }

        private bool saveFile()
        {
            bool savedCorrectly = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(currentFileName))
                {
                    sw.Write(txtMain.Text);
                }
                savedCorrectly = true;
            }
            catch (Exception)
            {
                throw;
            }
            return savedCorrectly;
        }

        private bool saveFileAs()
        {
            bool savedCorrectly = false;
            try
            {
                DialogResult res = saveFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    currentFileName = saveFileDialog1.FileName;
                    using (StreamWriter sw = new StreamWriter(currentFileName))
                    {
                        sw.Write(txtMain.Text);
                    }
                    savedCorrectly = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return savedCorrectly;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //newDocument(clearText: false);
            checkedForUnsavedWork();
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                currentFileName = openFileDialog1.FileName;
                currentTitle = currentFileName.Substring(currentFileName.LastIndexOf('\\')+1);
                this.Text = currentTitle + " - Notepad.NET";
                using (StreamReader sr = new StreamReader(currentFileName))
                {
                    txtMain.Text = sr.ReadToEnd();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFileName == "")
            {
                saveFileAs();
            }
            else
            {
                saveFile();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMain_KeyDown(object sender, KeyEventArgs e)
        {
            updateStatusBar();
        }

        private void updateStatusBar()
        {
            toolStripStatusLabel1.Text = "Ln " + (txtMain.GetLineFromCharIndex(txtMain.SelectionStart) + 1).ToString() + ", Col " + (txtMain.SelectionStart - txtMain.GetFirstCharIndexOfCurrentLine() + 1).ToString();
            
        }

        private void txtMain_KeyUp(object sender, KeyEventArgs e)
        {
            updateStatusBar();
        }

        private void txtMain_MouseDown(object sender, MouseEventArgs e)
        {
            updateStatusBar();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !checkedForUnsavedWork(); // If user clicks cancel, then cancel closing. duh
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Page Setup dialog 
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Print Setup dialog
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Find... dialog
            findReplaceForm.Show();
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement Find Next dialog
            findReplaceForm.findOrReplaceNext();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement replace dialog
            findReplaceForm.Show();
        }


    }
}
