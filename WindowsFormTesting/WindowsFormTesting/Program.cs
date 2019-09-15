using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Form1 : System.Windows.Forms.Form
{
    private Panel buttonPanel = new Panel();
    private DataGridView songsDataGridView = new DataGridView();
    private Button addNewRowButton = new Button();
    private Button deleteRowButton = new Button();



    public Form1()
    {
        this.Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        SetupLayout();
        SetupDataGridView();
        PopulateDataGridView();
    }

    private void songsDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        if (e != null)
        {
            if (this.songsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
            {
                if (e.Value != null)
                {
                    try
                    {
                        e.Value = DateTime.Parse(e.Value.ToString())
                            .ToLongDateString();
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                    }
                }
            }
        }
    }

    private void addNewRowButton_Click(object sender, EventArgs e)
    {
        this.songsDataGridView.Rows.Add();
    }

    private void deleteRowButton_Click(object sender, EventArgs e)
    {
        if (this.songsDataGridView.SelectedRows.Count > 0 &&
            this.songsDataGridView.SelectedRows[0].Index !=
            this.songsDataGridView.Rows.Count - 1)
        {
            this.songsDataGridView.Rows.RemoveAt(
                this.songsDataGridView.SelectedRows[0].Index);
        }
    }

    private void SetupLayout()
    {
        this.Size = new Size(600, 500);

        addNewRowButton.Text = "Add Row";
        addNewRowButton.Location = new Point(10, 10);
        addNewRowButton.Click += new EventHandler(addNewRowButton_Click);

        deleteRowButton.Text = "Delete Row";
        deleteRowButton.Location = new Point(100, 10);
        deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

        buttonPanel.Controls.Add(addNewRowButton);
        buttonPanel.Controls.Add(deleteRowButton);
        buttonPanel.Height = 50;
        buttonPanel.Dock = DockStyle.Bottom;

        this.Controls.Add(this.buttonPanel);
    }

    private void SetupDataGridView()
    {
        this.Controls.Add(songsDataGridView);

        // No. of columns
        songsDataGridView.ColumnCount = 9;

        songsDataGridView.Name = "songsDataGridView";
        songsDataGridView.Location = new Point(8, 8);
        songsDataGridView.Size = new Size(500, 250);


        //Trying to get grid to stay same size
        songsDataGridView.AllowUserToOrderColumns = false;
        songsDataGridView.RowHeadersVisible = false;
        songsDataGridView.AllowUserToResizeColumns = false;
        songsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        songsDataGridView.AllowUserToResizeRows = false;
        songsDataGridView.AllowUserToAddRows = false;
        songsDataGridView.RowHeadersVisible = false;
        songsDataGridView.ColumnHeadersVisible = false;
        //Making columns not sortable

        for ( var i = 0; i < 9; i++)
        {
            songsDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
       

        songsDataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        songsDataGridView.MultiSelect = false;
        songsDataGridView.Dock = DockStyle.Fill;

        songsDataGridView.CellFormatting += new
            DataGridViewCellFormattingEventHandler(
            songsDataGridView_CellFormatting);
    }
    


    private void PopulateDataGridView()
    {

        int squareHeight = 3;
        int squareWidth = 3;
        int gridWidth = squareWidth * squareHeight;
        int gridHeight = squareHeight * squareWidth;


        int[] numbersArray = { 7, 3, 5, 6, 1, 4, 8, 9, 2, 8, 4, 2, 9, 7, 3, 5, 6, 1, 9, 6, 1, 2, 8, 5, 3, 7, 4, 2, 8, 6, 3, 4, 9, 1, 5, 7, 4, 1, 3, 8, 5, 7, 9, 2, 6, 5, 7, 9, 1, 2, 6, 4, 3, 8, 1, 5, 7, 4, 9, 2, 6, 8, 3, 6, 9, 4, 7, 3, 8, 2, 1, 5, 3, 2, 8, 5, 6, 1, 7, 4, 9 };

        int splitSize = numbersArray.Length / gridHeight;
        int[,] splitArray = new int[gridHeight, splitSize];
        int currentIndex = 0;

        for (var i = 0; i < gridHeight; i++)
        {
            int[] currentArray = new int[splitSize];
            for (var x = 0; x < splitSize; x++)
            {
                currentArray[x] = numbersArray[currentIndex];
                currentIndex++;
            }
            for ( var a = 0; a < splitSize; a++ )
            {
                splitArray[i, a] = currentArray[a];
            }
        }


        for (var i = 0; i < gridHeight; i++)
        {
            string[] row = new string[splitSize];
            for (var x = 0; x < splitSize; x++)
            {
                row[x] = splitArray[i, x].ToString();
            } 
            songsDataGridView.Rows.Add(row);
        }


        /*string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
        string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
        string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
        string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
        string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
        string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
        string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" }; */

        /*
        songsDataGridView.Rows.Add(row0);
        songsDataGridView.Rows.Add(row1);
        songsDataGridView.Rows.Add(row2);
        songsDataGridView.Rows.Add(row3);
        songsDataGridView.Rows.Add(row4);
        songsDataGridView.Rows.Add(row5);
        songsDataGridView.Rows.Add(row6);

        songsDataGridView.Columns[0].DisplayIndex = 3;
        songsDataGridView.Columns[1].DisplayIndex = 4;
        songsDataGridView.Columns[2].DisplayIndex = 0;
        songsDataGridView.Columns[3].DisplayIndex = 1;
        songsDataGridView.Columns[4].DisplayIndex = 2;
        */
    }


    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}