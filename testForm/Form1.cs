using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testForm
{
    public partial class Form1 : Form
    {
        public int gridWidth = 9;
        public int gridHeight = 3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeSudoku();
        }
        public int GetRowByIndex(int index)
        {
            return index / gridWidth;
        }

        public int GetColumnByIndex(int index)
        {
            return index % gridWidth;
        }

        private void MakeSudoku()
        {
            int[] numbersArray = new int[81];
            for(int i = 0; i<numbersArray.Length; i++)
            {
                int row = GetRowByIndex(i);
                int col = GetColumnByIndex(i);

                addButton(i.ToString(), numbersArray[i].ToString(), row, col);
            }

        }

        protected void addButton(string name, string text, int row, int column)
        {
            Button btnNew = new Button();
            btnNew.Name = name + column.ToString() + "_" + row.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * row, 10 + 50 * column);

            Controls.Add(btnNew);
        }
    }
}
