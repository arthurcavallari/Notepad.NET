namespace Notepad.NET
{
    partial class frmGoToDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoToLine = new System.Windows.Forms.TextBox();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line number:";
            // 
            // txtGoToLine
            // 
            this.txtGoToLine.Location = new System.Drawing.Point(15, 25);
            this.txtGoToLine.Name = "txtGoToLine";
            this.txtGoToLine.Size = new System.Drawing.Size(202, 20);
            this.txtGoToLine.TabIndex = 1;
            this.txtGoToLine.Text = "1";
            this.txtGoToLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoToLine_KeyPress);
            this.txtGoToLine.Validating += new System.ComponentModel.CancelEventHandler(this.txtGoToLine_Validating);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Location = new System.Drawing.Point(61, 54);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(75, 23);
            this.btnGoTo.TabIndex = 2;
            this.btnGoTo.Text = "Go To";
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmGoToDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 89);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGoTo);
            this.Controls.Add(this.txtGoToLine);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGoToDialog";
            this.ShowInTaskbar = false;
            this.Text = "Go To Line";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoToLine;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.Button btnCancel;
    }
}