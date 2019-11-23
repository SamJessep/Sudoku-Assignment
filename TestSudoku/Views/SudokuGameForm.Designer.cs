using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sudoku
{
    partial class SudokuGameForm
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
            this.SudokuMaker = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.GameHUD = new System.Windows.Forms.Panel();
            this.Highscore = new System.Windows.Forms.Label();
            this.HintBtn = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.GameHUD.SuspendLayout();
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
            this.Open.Location = new System.Drawing.Point(154, 6);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(100, 40);
            this.Open.TabIndex = 2;
            this.Open.Tag = "Load/Save";
            this.Open.Text = "Load";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.OpenBtn_Clicked);
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
            this.SaveBtn.Location = new System.Drawing.Point(3, 6);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(79, 40);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Tag = "Load/Save";
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Clicked);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.SudokuMaker);
            this.MenuPanel.Controls.Add(this.Open);
            this.MenuPanel.Location = new System.Drawing.Point(2, 3);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(263, 57);
            this.MenuPanel.TabIndex = 4;
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
            this.SudokuMaker.Location = new System.Drawing.Point(3, 6);
            this.SudokuMaker.Name = "SudokuMaker";
            this.SudokuMaker.Size = new System.Drawing.Size(145, 40);
            this.SudokuMaker.TabIndex = 5;
            this.SudokuMaker.Tag = "Load/Save";
            this.SudokuMaker.Text = "Sudoku Maker";
            this.SudokuMaker.UseVisualStyleBackColor = false;
            this.SudokuMaker.Click += new System.EventHandler(this.EditorBtn_Clicked);
            // 
            // GameTimer
            // 
            this.GameTimer.AutoSize = true;
            this.GameTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTimer.Location = new System.Drawing.Point(285, 14);
            this.GameTimer.Name = "GameTimer";
            this.GameTimer.Size = new System.Drawing.Size(108, 24);
            this.GameTimer.TabIndex = 7;
            this.GameTimer.Text = "Time: 00:00";
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
            this.ResetBtn.Location = new System.Drawing.Point(88, 6);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(73, 40);
            this.ResetBtn.TabIndex = 6;
            this.ResetBtn.Tag = "Load/Save";
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Clicked);
            // 
            // GameHUD
            // 
            this.GameHUD.Controls.Add(this.HintBtn);
            this.GameHUD.Controls.Add(this.ResetBtn);
            this.GameHUD.Controls.Add(this.Highscore);
            this.GameHUD.Controls.Add(this.GameTimer);
            this.GameHUD.Controls.Add(this.SaveBtn);
            this.GameHUD.Location = new System.Drawing.Point(271, 3);
            this.GameHUD.Name = "GameHUD";
            this.GameHUD.Size = new System.Drawing.Size(551, 49);
            this.GameHUD.TabIndex = 5;
            this.GameHUD.Visible = false;
            // 
            // Highscore
            // 
            this.Highscore.AutoSize = true;
            this.Highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highscore.Location = new System.Drawing.Point(399, 14);
            this.Highscore.Name = "Highscore";
            this.Highscore.Size = new System.Drawing.Size(117, 24);
            this.Highscore.TabIndex = 7;
            this.Highscore.Text = "Highscore: 0";
            // 
            // HintBtn
            // 
            this.HintBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HintBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HintBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.HintBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HintBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HintBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HintBtn.Location = new System.Drawing.Point(167, 6);
            this.HintBtn.Name = "HintBtn";
            this.HintBtn.Size = new System.Drawing.Size(86, 40);
            this.HintBtn.TabIndex = 8;
            this.HintBtn.Tag = "Load/Save";
            this.HintBtn.Text = "Hint";
            this.HintBtn.UseVisualStyleBackColor = false;
            this.HintBtn.Click += new System.EventHandler(this.HintBtn_Click);
            // 
            // SudokuGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(799, 235);
            this.Controls.Add(this.GameHUD);
            this.Controls.Add(this.MenuPanel);
            this.Name = "SudokuGameForm";
            this.Text = "Sudoku";
            this.MenuPanel.ResumeLayout(false);
            this.GameHUD.ResumeLayout(false);
            this.GameHUD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button Open;
        private Button SaveBtn;
        private Panel MenuPanel;
        private Button SudokuMaker;
        private Button ResetBtn;
        private Label GameTimer;
        private Panel GameHUD;
        private Label Highscore;
        private Button HintBtn;
    }
}