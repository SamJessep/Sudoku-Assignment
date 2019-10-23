using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sudoku
{
    partial class SudokuForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Open = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SudokuMaker = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Open
            // 
            this.Open.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.Open.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Open.BackColor = System.Drawing.SystemColors.Menu;
            this.Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Open.Location = new System.Drawing.Point(4, 5);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(100, 40);
            this.Open.TabIndex = 2;
            this.Open.Tag = "Load/Save";
            this.Open.Text = "Load";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveBtn.Location = new System.Drawing.Point(109, 5);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(100, 40);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Tag = "Load/Save";
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Visible = false;
            this.SaveBtn.Click += new System.EventHandler(this.saveButton_click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.AutoSize = true;
            this.MenuPanel.Controls.Add(this.ResetBtn);
            this.MenuPanel.Controls.Add(this.SudokuMaker);
            this.MenuPanel.Controls.Add(this.Check);
            this.MenuPanel.Controls.Add(this.SaveBtn);
            this.MenuPanel.Controls.Add(this.Open);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(788, 51);
            this.MenuPanel.TabIndex = 4;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResetBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResetBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.ResetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ResetBtn.Location = new System.Drawing.Point(319, 5);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(100, 40);
            this.ResetBtn.TabIndex = 6;
            this.ResetBtn.Tag = "Load/Save";
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SudokuMaker
            // 
            this.SudokuMaker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SudokuMaker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SudokuMaker.BackColor = System.Drawing.SystemColors.Menu;
            this.SudokuMaker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SudokuMaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SudokuMaker.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SudokuMaker.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SudokuMaker.Location = new System.Drawing.Point(424, 5);
            this.SudokuMaker.Name = "SudokuMaker";
            this.SudokuMaker.Size = new System.Drawing.Size(145, 40);
            this.SudokuMaker.TabIndex = 5;
            this.SudokuMaker.Tag = "Load/Save";
            this.SudokuMaker.Text = "Sudoku Maker";
            this.SudokuMaker.UseVisualStyleBackColor = false;
            this.SudokuMaker.Click += new System.EventHandler(this.SudokuMaker_Click);
            // 
            // Check
            // 
            this.Check.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Check.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Check.BackColor = System.Drawing.SystemColors.Menu;
            this.Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Check.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Check.Location = new System.Drawing.Point(214, 5);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(100, 40);
            this.Check.TabIndex = 3;
            this.Check.Tag = "Load/Save";
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = false;
            this.Check.Visible = false;
            this.Check.Click += new System.EventHandler(this.checkBtnClicked);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuPanel);
            this.Name = "SudokuForm";
            this.Text = "Sudoku";
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button Open;
        private Button SaveBtn;
        private Panel MenuPanel;
        private Button SudokuMaker;
        private Button ResetBtn;
        private Button Check;
    }
}