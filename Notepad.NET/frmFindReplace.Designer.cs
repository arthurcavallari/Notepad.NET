namespace Notepad.NET
{
    partial class frmFindReplace
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
            this.btnFindAll = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFindMethod = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWrapAround = new System.Windows.Forms.CheckBox();
            this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkPromptOnReplace = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(354, 63);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(131, 23);
            this.btnFindAll.TabIndex = 8;
            this.btnFindAll.Text = "Find A&ll";
            this.btnFindAll.UseVisualStyleBackColor = true;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(354, 34);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(131, 23);
            this.btnFindNext.TabIndex = 7;
            this.btnFindNext.Text = "&Find Next";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(68, 36);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFind.Size = new System.Drawing.Size(280, 50);
            this.txtFind.TabIndex = 6;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.Leave += new System.EventHandler(this.txtFind_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Find:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(68, 92);
            this.txtReplace.Multiline = true;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReplace.Size = new System.Drawing.Size(280, 50);
            this.txtReplace.TabIndex = 10;
            this.txtReplace.TextChanged += new System.EventHandler(this.txtReplace_TextChanged);
            this.txtReplace.Leave += new System.EventHandler(this.txtReplace_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Replace:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(354, 119);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(131, 23);
            this.btnReplaceAll.TabIndex = 12;
            this.btnReplaceAll.Text = "Replace &All";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(354, 90);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(131, 23);
            this.btnReplace.TabIndex = 11;
            this.btnReplace.Text = "&Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Find In:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbFindMethod
            // 
            this.cmbFindMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindMethod.FormattingEnabled = true;
            this.cmbFindMethod.Items.AddRange(new object[] {
            "Selected Text",
            "Current Document",
            "Open Documents"});
            this.cmbFindMethod.Location = new System.Drawing.Point(68, 9);
            this.cmbFindMethod.Name = "cmbFindMethod";
            this.cmbFindMethod.Size = new System.Drawing.Size(169, 21);
            this.cmbFindMethod.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPromptOnReplace);
            this.groupBox1.Controls.Add(this.chkWrapAround);
            this.groupBox1.Controls.Add(this.chkMatchWholeWord);
            this.groupBox1.Controls.Add(this.chkMatchCase);
            this.groupBox1.Location = new System.Drawing.Point(9, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 87);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find and Replace Settings";
            // 
            // chkWrapAround
            // 
            this.chkWrapAround.AutoSize = true;
            this.chkWrapAround.Location = new System.Drawing.Point(6, 65);
            this.chkWrapAround.Name = "chkWrapAround";
            this.chkWrapAround.Size = new System.Drawing.Size(88, 17);
            this.chkWrapAround.TabIndex = 2;
            this.chkWrapAround.Text = "Wra&p around";
            this.chkWrapAround.UseVisualStyleBackColor = true;
            this.chkWrapAround.CheckedChanged += new System.EventHandler(this.chkWrapAround_CheckedChanged);
            // 
            // chkMatchWholeWord
            // 
            this.chkMatchWholeWord.AutoSize = true;
            this.chkMatchWholeWord.Location = new System.Drawing.Point(6, 19);
            this.chkMatchWholeWord.Name = "chkMatchWholeWord";
            this.chkMatchWholeWord.Size = new System.Drawing.Size(135, 17);
            this.chkMatchWholeWord.TabIndex = 1;
            this.chkMatchWholeWord.Text = "Match &whole word only";
            this.chkMatchWholeWord.UseVisualStyleBackColor = true;
            this.chkMatchWholeWord.CheckedChanged += new System.EventHandler(this.chkMatchWholeWord_CheckedChanged);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(6, 42);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
            this.chkMatchCase.TabIndex = 0;
            this.chkMatchCase.Text = "Match &case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            this.chkMatchCase.CheckedChanged += new System.EventHandler(this.chkMatchCase_CheckedChanged);
            // 
            // chkPromptOnReplace
            // 
            this.chkPromptOnReplace.AutoSize = true;
            this.chkPromptOnReplace.Location = new System.Drawing.Point(147, 19);
            this.chkPromptOnReplace.Name = "chkPromptOnReplace";
            this.chkPromptOnReplace.Size = new System.Drawing.Size(112, 17);
            this.chkPromptOnReplace.TabIndex = 3;
            this.chkPromptOnReplace.Text = "&Prompt on replace";
            this.chkPromptOnReplace.UseVisualStyleBackColor = true;
            // 
            // frmFindReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 240);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbFindMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindAll);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFindReplace";
            this.ShowInTaskbar = false;
            this.Text = "Find and Replace";
            this.Activated += new System.EventHandler(this.frmFindReplace_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindReplace_FormClosing);
            this.Load += new System.EventHandler(this.frmFindReplace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindAll;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFindMethod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkWrapAround;
        private System.Windows.Forms.CheckBox chkMatchWholeWord;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkPromptOnReplace;
    }
}