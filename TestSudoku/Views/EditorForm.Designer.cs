namespace Sudoku
{
    partial class EditorForm
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
            this.Size = new System.Windows.Forms.GroupBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.SquareWidth = new System.Windows.Forms.NumericUpDown();
            this.SquareHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Other = new System.Windows.Forms.GroupBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TargetTime = new System.Windows.Forms.NumericUpDown();
            this.Export = new System.Windows.Forms.Button();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.TemplateArea = new System.Windows.Forms.Panel();
            this.LoadFile = new System.Windows.Forms.Button();
            this.Size.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SquareWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SquareHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Other.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetTime)).BeginInit();
            this.SuspendLayout();
            // 
            // Size
            // 
            this.Size.Controls.Add(this.WidthLabel);
            this.Size.Controls.Add(this.HeightLabel);
            this.Size.Controls.Add(this.SquareWidth);
            this.Size.Controls.Add(this.SquareHeight);
            this.Size.Location = new System.Drawing.Point(12, 12);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(459, 57);
            this.Size.TabIndex = 0;
            this.Size.TabStop = false;
            this.Size.Text = "Size";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(6, 21);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(69, 13);
            this.WidthLabel.TabIndex = 3;
            this.WidthLabel.Text = "Square width";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(229, 21);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(73, 13);
            this.HeightLabel.TabIndex = 1;
            this.HeightLabel.Text = "Square height";
            // 
            // SquareWidth
            // 
            this.SquareWidth.Location = new System.Drawing.Point(79, 19);
            this.SquareWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SquareWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SquareWidth.Name = "SquareWidth";
            this.SquareWidth.Size = new System.Drawing.Size(120, 20);
            this.SquareWidth.TabIndex = 2;
            this.SquareWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // SquareHeight
            // 
            this.SquareHeight.Location = new System.Drawing.Point(308, 19);
            this.SquareHeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SquareHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SquareHeight.Name = "SquareHeight";
            this.SquareHeight.Size = new System.Drawing.Size(120, 20);
            this.SquareHeight.TabIndex = 0;
            this.SquareHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Other);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Settings";
            // 
            // Other
            // 
            this.Other.Controls.Add(this.TimeLabel);
            this.Other.Controls.Add(this.TargetTime);
            this.Other.Location = new System.Drawing.Point(488, 12);
            this.Other.Name = "Other";
            this.Other.Size = new System.Drawing.Size(260, 57);
            this.Other.TabIndex = 2;
            this.Other.TabStop = false;
            this.Other.Text = "Other";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(6, 21);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(107, 13);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "Seconds to complete";
            // 
            // TargetTime
            // 
            this.TargetTime.Location = new System.Drawing.Point(124, 19);
            this.TargetTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.TargetTime.Name = "TargetTime";
            this.TargetTime.Size = new System.Drawing.Size(120, 20);
            this.TargetTime.TabIndex = 2;
            this.TargetTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // Export
            // 
            this.Export.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Export.Enabled = false;
            this.Export.Location = new System.Drawing.Point(0, 590);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(813, 23);
            this.Export.TabIndex = 2;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GenerateBtn.Location = new System.Drawing.Point(0, 567);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(813, 23);
            this.GenerateBtn.TabIndex = 3;
            this.GenerateBtn.Text = "Generate Template";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // TemplateArea
            // 
            this.TemplateArea.AutoScroll = true;
            this.TemplateArea.AutoSize = true;
            this.TemplateArea.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.TemplateArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateArea.Location = new System.Drawing.Point(0, 78);
            this.TemplateArea.Name = "TemplateArea";
            this.TemplateArea.Size = new System.Drawing.Size(813, 489);
            this.TemplateArea.TabIndex = 5;
            // 
            // LoadFile
            // 
            this.LoadFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadFile.Location = new System.Drawing.Point(0, 544);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(813, 23);
            this.LoadFile.TabIndex = 6;
            this.LoadFile.Text = "Load Template";
            this.LoadFile.UseVisualStyleBackColor = true;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(813, 613);
            this.Controls.Add(this.LoadFile);
            this.Controls.Add(this.TemplateArea);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditorForm";
            this.Text = "SudokuMaker";
            this.Size.ResumeLayout(false);
            this.Size.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SquareWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SquareHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.Other.ResumeLayout(false);
            this.Other.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Size;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown SquareWidth;
        private System.Windows.Forms.NumericUpDown SquareHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Other;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.NumericUpDown TargetTime;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Panel TemplateArea;
        private System.Windows.Forms.Button LoadFile;
    }
}