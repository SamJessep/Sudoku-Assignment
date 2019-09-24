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
    public partial class SudokuForm : Form
    {
        GameController controller;
        private int SelectedVal;
        public void SetController(GameController theController)
        {
            controller = theController;
        }
        public SudokuForm()
        {
            InitializeComponent();
        }

        public void MakeSudoku(Game game)
        {
            drawGrid(game);
            DrawControlls(game.numberOfSquares);
            int H = menuStrip1.Height + 80 + (50 * (game.gridHeight + 2));  
            int W = 40 + (50 * (game.gridWidth+1));
            setWindowSize(W, H);
        }

        private void setWindowSize(int w,int h)
        {
            Width = w;
            Height = h;
        }

        public void drawGrid(Game game)
        {
            int[] numbersArray = game.ToArray();
            for (int i = 0; i < numbersArray.Length; i++)
            {
                int row = game.GetRowByIndex(i);
                int col = game.GetColumnByIndex(i);

                addButton(i.ToString(), numbersArray[i].ToString(), row, col, i);
            }
        }

        public void DrawControlls(int n)
        {
            for(int i = 0; i<=n; i++)
            {
                addButton("inputBtn_" + i, i==0?"":i.ToString(), n+1, i, i);
            }
        }

        protected void addButton(string name, string text, int row, int column, int index)
        {
            
            int x = 10 + 50 * column;
            int y = menuStrip1.Height+10 + 50 * row ;
            Button btnNew = new Button();
            btnNew.Name = row+"_"+column;
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(x,y);
            btnNew.Click += GridButton_clicked;
            Controls.Add(btnNew);
        }

        private void GridButton_clicked(object sender, EventArgs e)
        {
            Button BtnClicked = (Button)sender;
            string btnText = BtnClicked.Text;
            if (BtnClicked.Name.Contains("inputBtn_"))
            {
                SelectedVal = int.Parse(btnText);
            }
            else
            {
                BtnClicked.Text = SelectedVal.ToString();
               /* string[] ColRow = BtnClicked.Name.Split('_');
                int cellIndex = controller.game.GetByRow(int.Parse(ColRow[0]), int.Parse(ColRow[1]));
                controller.game.SetCell(SelectedVal, cellIndex);*/
            }
        }

    }
}
