using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Notepad.NET
{
    public partial class frmFindReplace : Form
    {
        private frmMain _frmMain;
        private int currentIndex = -1;
        private int startingIndex = 0;
        private string searchText, preparedSearchText, replaceText, preparedReplaceText;
        private Match _match;
        private bool searchBegun = false;
        private RegexOptions regexOptions = RegexOptions.None;
        private string contents;
        private bool replacedLastMatch, firstReplace = true;
        private int replaceCount = 0;
        private int startSelectedIndex, lengthSelected;
        
         

        public frmFindReplace(frmMain mainForm)
        {
            InitializeComponent();
            _frmMain = mainForm;
        }

        private void frmFindReplace_Load(object sender, EventArgs e)
        {
            cmbFindMethod.SelectedIndex = 1;
        }

        private void frmFindReplace_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmFindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            findOrReplaceNext();
        }

        public void findOrReplaceNext(bool replace = false)
        {
            if ((searchBegun && (currentIndex + startingIndex) != _frmMain.txtMain.SelectionStart) 
                || (replace && searchBegun && (currentIndex + startingIndex) != _frmMain.txtMain.SelectionStart)
                || (replace && replacedLastMatch))
            {
                searchBegun = false;
                regexOptions = RegexOptions.None;
                
            }

            if (!searchBegun)
            {
                startingIndex = _frmMain.txtMain.SelectionStart;
                contents = _frmMain.txtMain.Text;
                searchBegun = true;
                regexOptions = RegexOptions.None;
                if (!chkMatchCase.Checked)
                {
                    regexOptions = regexOptions | RegexOptions.IgnoreCase;
                }
                if (chkMatchWholeWord.Checked)
                {
                    preparedSearchText = "\\b" + preparedSearchText + "\\b";
                }

                if (cmbFindMethod.SelectedIndex == 0 && _frmMain.txtMain.SelectionLength > 0)
                {
                    // Selected text                    

                    if (replace)
                    {
                        if (firstReplace)
                        {
                            // lets remember the selected text
                            startSelectedIndex = _frmMain.txtMain.SelectionStart;
                            lengthSelected = _frmMain.txtMain.SelectionLength;
                            contents = contents.Substring(startSelectedIndex, _frmMain.txtMain.SelectionLength);
                        }
                        else
                        {
                            // now to adjust the "input" of our replace function.. moving the caret forward
                            // TODO: Fix this >.<
                            if (replacedLastMatch)
                            {
                                contents = contents.Substring(startSelectedIndex + currentIndex + replaceText.Length, lengthSelected - currentIndex - searchText.Length);
                            }
                            else
                            {
                                contents = contents.Substring(startSelectedIndex + currentIndex, lengthSelected - searchText.Length);
                            }
                            replacedLastMatch = false;
                        }
                    }
                    else
                    {
                        contents = contents.Substring(startingIndex, _frmMain.txtMain.SelectionLength);
                    }
                    
                }
                else
                {
                    // Current document  
                    contents = contents.Substring(startingIndex);
                }
                
                _match = Regex.Match(contents, preparedSearchText, regexOptions);
                
            }
            else
            {
                _match = _match.NextMatch();
            }
            currentIndex = _match.Index;
            if (currentIndex > -1 && _match.Success)
            {
                _frmMain.txtMain.Select(currentIndex + startingIndex, _match.Length);
                _frmMain.txtMain.Focus();
                _frmMain.txtMain.ScrollToCaret();
                if (replace)
                {
                    firstReplace = false;
                    if (chkPromptOnReplace.Checked)
                    {
                        DialogResult res = MessageBox.Show("Replace this occurence of '" + replaceText + "'?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            Regex rgx = new Regex(preparedSearchText, regexOptions);
                            string resultText = rgx.Replace(contents, preparedReplaceText, 1, currentIndex);
                            _frmMain.txtMain.Text = _frmMain.txtMain.Text.Substring(0, startingIndex) + resultText + _frmMain.txtMain.Text.Substring(startingIndex + contents.Length);
                            replacedLastMatch = true;
                            _frmMain.txtMain.Select(currentIndex + startingIndex, preparedReplaceText.Length);
                            _frmMain.txtMain.Focus();
                            _frmMain.txtMain.ScrollToCaret();
                            
                            findOrReplaceNext(true);
                        }
                        else if (res == DialogResult.No)
                        {
                            // Skip to next occurence
                            replacedLastMatch = false;
                            findOrReplaceNext(true);
                        }
                        /*else if (res == DialogResult.Cancel)
                        {
                            // Stop replacing + do nothing
                        }*/
                    }
                    else
                    {
                        Regex rgx = new Regex(preparedSearchText, regexOptions);
                        string resultText = rgx.Replace(contents, preparedReplaceText, 1, currentIndex);
                        replacedLastMatch = true;
                        _frmMain.txtMain.Text = _frmMain.txtMain.Text.Substring(0, startingIndex) + resultText + _frmMain.txtMain.Text.Substring(startingIndex + contents.Length);

                        _frmMain.txtMain.Select(currentIndex + startingIndex, preparedReplaceText.Length);
                        _frmMain.txtMain.Focus();
                        _frmMain.txtMain.ScrollToCaret();
                    }
                }
                
                //startingIndex = currentIndex + _match.Length;
            }
            else
            {
                if (chkWrapAround.Checked)
                {
                    currentIndex = startingIndex = 0;
                    searchBegun = false;
                }
                else
                {
                    searchBegun = false;
                    MessageBox.Show("Can't find the text '" + searchText + "'", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                firstReplace = true;
                _frmMain.txtMain.SelectionStart = 0;
                _frmMain.txtMain.SelectionLength = 0;
                currentIndex = startingIndex = 0;
            }
        }

        public void replaceAll()
        {
            Regex rgx = new Regex(preparedSearchText, regexOptions);
            regexOptions = RegexOptions.None;
            startingIndex = _frmMain.txtMain.SelectionStart;
            string contentsReplace = _frmMain.txtMain.Text;

            if (!chkMatchCase.Checked)
            {
                regexOptions = regexOptions | RegexOptions.IgnoreCase;
            }
            if (chkMatchWholeWord.Checked)
            {
                preparedSearchText = "\\b" + preparedSearchText + "\\b";
            }

            if (cmbFindMethod.SelectedIndex == 0 && _frmMain.txtMain.SelectionLength > 0)
            {
                // Selected text
                contentsReplace = contentsReplace.Substring(startingIndex, _frmMain.txtMain.SelectionLength);
            }
            else
            {
                // Current document  
                contentsReplace = contentsReplace.Substring(startingIndex);
            }

            if (chkWrapAround.Checked)
            {
                replaceCount = (_frmMain.txtMain.Text.Length - _frmMain.txtMain.Text.Replace(preparedSearchText, string.Empty).Length) / preparedSearchText.Length;
                
                string resultText = rgx.Replace(_frmMain.txtMain.Text, preparedReplaceText);
                _frmMain.txtMain.Text = resultText;
           
            }
            else
            {
                replaceCount = (contentsReplace.Length - contentsReplace.Replace(preparedSearchText, string.Empty).Length) / preparedSearchText.Length;

                string resultText = rgx.Replace(contentsReplace, preparedReplaceText);
                replacedLastMatch = true;
                _frmMain.txtMain.Text = _frmMain.txtMain.Text.Substring(0, startingIndex) + resultText + _frmMain.txtMain.Text.Substring(startingIndex + contentsReplace.Length);
            }
            MessageBox.Show(replaceCount.ToString() + " occurence" + (replaceCount == 1 ? "s" : "") + " were replaced.", "Replace All", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _frmMain.txtMain.SelectionStart = _frmMain.txtMain.Text.Length;
            _frmMain.txtMain.SelectionLength = 0;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            updateSearchText();
        }

        private void updateSearchText(bool resetIndex = true)
        {            
            if (resetIndex)
            {
                currentIndex = startingIndex = 0;
            }
            else
            {
                currentIndex = startingIndex = _frmMain.txtMain.SelectionStart;
            }            
            searchText = preparedSearchText = txtFind.Text;
            searchBegun = false;
            regexOptions = RegexOptions.None;
        }

        private void txtFind_Leave(object sender, EventArgs e)
        {
            updateSearchText();
        }

        private void chkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            updateSearchText(resetIndex: false);
        }

        private void chkMatchWholeWord_CheckedChanged(object sender, EventArgs e)
        {
            updateSearchText(resetIndex: false);
        }

        private void chkWrapAround_CheckedChanged(object sender, EventArgs e)
        {
            updateSearchText(resetIndex: false);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            findOrReplaceNext(true);
        }


        private void txtReplace_TextChanged(object sender, EventArgs e)
        {
            updateReplaceText();
        }

        private void updateReplaceText()
        {
            replaceText = preparedReplaceText = txtReplace.Text;
            searchBegun = false;
        }

        private void txtReplace_Leave(object sender, EventArgs e)
        {
            updateReplaceText();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (chkPromptOnReplace.Checked)
            {
                findOrReplaceNext(true); 
            }
            else
            {
                replaceAll();
            }
        }        
    }
}
