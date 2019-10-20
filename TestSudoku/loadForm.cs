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
        public bool loadingGameSave;
        public loadForm(SudokuForm SForm, Game g)
        {
            InitializeComponent();
            drawGames(SForm, g);
        }
        private void drawGames(SudokuForm SForm, Game g)
        {
            Panel Original = new Panel();
            Panel GameSave = new Panel();
            Original.Name = "Original";
            GameSave.Name = "GameSave";
            Original.AutoSize = true;
            GameSave.AutoSize = true;
            Original.Click += SelectGame;
            GameSave.Location = new Point((g.gridWidth * 50) + 100, 0);

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
        }
        private void SelectGame(Object sender, EventArgs e)
        {
            Panel thePanel = (Panel)sender;
            if(thePanel.Name == "Original")
            {
                loadingGameSave = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                loadingGameSave = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void labelClick(Object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            Panel Parent = (Panel)theLabel.Parent;
            button1_Click(Parent, EventArgs.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
