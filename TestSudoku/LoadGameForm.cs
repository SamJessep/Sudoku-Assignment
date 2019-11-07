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
    public partial class LoadGameForm : Form
    {
        private const int boxWidth = 50;
        public bool loadingGameSave;
        public LoadGameForm(SudokuGameForm SForm, Game g)
        {
            InitializeComponent();
            DrawGames(SForm, g);
        }

        private void SetFormSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
        private Panel MakePanel(int x, int y, Size s, string labelText, string panelName)
        {
            Label GameLabel = new Label
            {
                Text = labelText,
                Dock = DockStyle.Bottom,
                Font = new Font("Segoe UI Symbol", 12)
            };
            Panel P = new Panel();
            P.Controls.Add(GameLabel);
            P.Name = panelName;
            P.Size = s;
            P.Click += SelectGame;
            P.MouseEnter += SudokuGameHover;
            P.Location = new Point(x, y);
            return P;
        }

        private void DrawGames(SudokuGameForm SForm, Game g)
        {
            Font LabelFont = new Font("Segoe UI Symbol", 12);
            Size s = new Size(g.gridWidth * boxWidth, g.gridWidth * boxWidth + boxWidth);
            Panel Original = MakePanel(10,10,s,"Original", "Original");
            Panel GameSave = MakePanel((Original.Width) + boxWidth, 10,s, "Game Save", "GameSave");
            int col, row;
            Label OG, GS;

            for (int c = 0; c<g.originalNumbersArray.Length; c++)
            {
                col = g.GetColumnByIndex(c);
                row = g.GetRowByIndex(c);
                OG = SForm.AddLabel(
                    "Original" + c,
                    g.originalNumbersArray[c] == 0 ? "" : g.originalNumbersArray[c].ToString(),
                    row,
                    col
                    );
                GS = SForm.AddLabel(
                    "GameSave" + c,
                    g.numbersArray[c] == 0 ? "" : g.numbersArray[c].ToString(),
                    row,
                    col
                    );
                OG.Click += SudokuCellLabel_Clicked;
                GS.Click += SudokuCellLabel_Clicked;
                OG.MouseEnter += SudokuCellLabel_Hover;
                GS.MouseEnter += SudokuCellLabel_Hover;
                GameSave.Controls.Add(GS);
                Original.Controls.Add(OG);
            }
            Controls.Add(Original);
            Controls.Add(GameSave);
            SetFormSize(20+Original.Width + GameSave.Width + boxWidth, (g.gridWidth+2) * boxWidth + CancelBtn.Height+10);
        }
        private void SelectGame(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SudokuGameHover(Object sender, EventArgs e)
        {
            Panel P = (Panel)sender;
            loadingGameSave = P.Name == "GameSave";
            Controls["Original"].BackColor = loadingGameSave ? Color.LightGoldenrodYellow : Color.Brown;
            Controls["GameSave"].BackColor = loadingGameSave ? Color.Brown : Color.LightGoldenrodYellow;
            //P.BackColor = Color.Brown;
        }

        private void SudokuCellLabel_Hover(Object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            Panel Parent = (Panel)theLabel.Parent;
            SudokuGameHover(Parent, EventArgs.Empty);
        }

        private void SudokuCellLabel_Clicked(Object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            Panel Parent = (Panel)theLabel.Parent;
            SelectGame(Parent, EventArgs.Empty);
        }
        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
