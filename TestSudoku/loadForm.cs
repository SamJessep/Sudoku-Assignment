using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class loadForm : Form
    {
        private const int boxWidth = 50;
        public bool loadingGameSave;
        public loadForm(SudokuForm SForm, Game g)
        {
            InitializeComponent();
            DrawGames(SForm, g);
        }

        private void SetFormSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
        private void DrawGames(SudokuForm SForm, Game g)
        {
            Panel Original = new Panel();
            Panel GameSave = new Panel();
            Label OGLabel = new Label
            {
                Text = "Original",
                Dock = DockStyle.Bottom
        };
            Label GSLabel = new Label
            {
                Text = "Game Save",
                Dock = DockStyle.Bottom
            };
            Original.Controls.Add(OGLabel);
            GameSave.Controls.Add(GSLabel);
            Original.Name = "Original";
            GameSave.Name = "GameSave";
            Original.Size = new Size(g.gridWidth * boxWidth, g.gridWidth * boxWidth + boxWidth);
            GameSave.Size = Original.Size;
            GameSave.AutoSize = true;
            Original.Click += SelectGame;
            GameSave.Click += SelectGame;
            Original.BackColor = Color.Green;
            GameSave.BackColor = Color.Red;
            Original.Location = new Point(10, 10);
            GameSave.Location = new Point((Original.Width) + boxWidth, 10);
            int col, row;
            Label OG, GS;

            for (int c = 0; c<g.originalNumbersArray.Length; c++)
            {
                col = g.GetColumnByIndex(c);
                row = g.GetRowByIndex(c);
                OG = SForm.AddLabel(
                    "Original" + c,
                    "Original",
                    g.originalNumbersArray[c] == 0 ? "" : g.originalNumbersArray[c].ToString(),
                    col,
                    row
                    );
                GS = SForm.AddLabel(
                    "GameSave" + c,
                    "GameSave",
                    g.numbersArray[c] == 0 ? "" : g.numbersArray[c].ToString(),
                    col,
                    row
                    );
                OG.Click += labelClick;
                GS.Click += labelClick;
                GameSave.Controls.Add(GS);
                Original.Controls.Add(OG);
            }
            Controls.Add(Original);
            Controls.Add(GameSave);
            SetFormSize(20+Original.Width + GameSave.Width + boxWidth, (g.gridWidth+2) * boxWidth + CancelBtn.Height+10);
        }
        private void SelectGame(Object sender, EventArgs e)
        {
            Panel thePanel = (Panel)sender;
            if(thePanel.Name == "Original")
            {
                loadingGameSave = false;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                loadingGameSave = true;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void labelClick(Object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            Panel Parent = (Panel)theLabel.Parent;
            SelectGame(Parent, EventArgs.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
