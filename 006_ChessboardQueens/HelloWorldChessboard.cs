using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _006_ChessboardQueens
{
    public partial class HelloWorldChessboard : Form
    {
        public HelloWorldChessboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildChessboard();
        }

        Label[][] boardGrid = new Label[10][]; //chessboard label controls
        Label[] notPlaced = new Label[10]; //home row above chessboard for letters that have not yet been placed
        String[] message = new String[]{ "H", "e", "l", "l", "o", "W", "o", "r", "l", "d" }; //letters to place
        List<Color> gridColors = new List<Color>() { Color.FloralWhite, Color.Tan }; //alternating colors for chessboard grid

        public class VisualizationDataItem
        {
            /// <summary>
            /// list containing the row number to place each piece, beginning with the leftmost column as the first list element
            /// </summary>
            public List<int> PlacedItems { get; set; }

            /// <summary>
            /// list of the columns that have a conflict (two pieces in the same row, or two pieces on the same diagonal
            /// </summary>
            public List<int> ErrorColumns { get; set; }


            public VisualizationDataItem(List<int> placed, List<int> errors)
            {
                PlacedItems = placed;
                ErrorColumns = errors;
            }
        }

        List<VisualizationDataItem> visualizaitonData = new List<VisualizationDataItem>();

        /// <summary>
        /// Dynamically build the notPlaced and boardGrid lables and place on the form
        /// </summary>
        public void BuildChessboard()
        {

            for (int c = 0; c < 10; c++)
            {

                Label newLabel = new Label();
                newLabel.BackColor = System.Drawing.SystemColors.Control;
                newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newLabel.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(50 + 50*c, 95);
                newLabel.Name = "Unplaced_" + c.ToString().PadLeft(2, '0');
                newLabel.AutoSize = false;
                newLabel.Size = new System.Drawing.Size(50, 50);
                newLabel.TabIndex = 3;
                newLabel.Text = message[c];
                newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                newLabel.AutoSize = false;
                notPlaced[c] = newLabel;
                this.Controls.Add(notPlaced[c]);
            }


            for (int r = 0; r < 10; r++)
            {
                boardGrid[r] = new Label[10];
                for (int c = 0; c < 10; c++)
                {
                    Label newLabel = new Label();

                    newLabel.BackColor = gridColors[(r % 2) ^ (c % 2)];
                    newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.Location = new System.Drawing.Point(50 + 50*c, 180+50*r);
                    newLabel.Name = "Board_" + r.ToString().PadLeft(2, '0') + "_" + c.ToString().PadLeft(2,'0');
                    newLabel.AutoSize = false;
                    newLabel.Size = new System.Drawing.Size(50, 50);
                    newLabel.TabIndex = 3;
                    newLabel.Text = "";
                    newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    boardGrid[r][c] = newLabel;
                    this.Controls.Add(boardGrid[r][c]);

                }
            }

            this.Width = 625;
            this.Height = 725;
        }


        private void VisualizeButton_Click(object sender, EventArgs e)
        {
            //reset board
            VisualizeEntry(new VisualizationDataItem(new List<int>(), new List<int>()));

            //generate visualization data
            PlaceQueensOnBoard(10, new List<int>());

            //start timer to display visualization
            visualizationTimer.Start();
        }

        /// <summary>
        /// Add an entry to the list of visualizations to be displayed
        /// </summary>
        /// <param name="placedItems"></param>
        /// <param name="errorColumns"></param>
        public void AddVisualization(List<int> placedItems, List<int> errorColumns)
        {
            visualizaitonData.Add(new VisualizationDataItem(placedItems, errorColumns));
        }

        /// <summary>
        /// Alter the chessboard to display the requested visualization state
        /// </summary>
        /// <param name="data"></param>
        public void VisualizeEntry(VisualizationDataItem data)
        {
            for (int c = 0; c < 10; c++)
            {
                if (c < data.PlacedItems.Count)
                {
                    notPlaced[c].Text = "";
                    for (int r = 0; r < 10; r++)
                    {
                        if (data.PlacedItems[c] == r)
                        {
                            boardGrid[r][c].Text = message[c];
                            if (data.ErrorColumns.Contains(c))
                            {
                                boardGrid[r][c].BackColor = Color.Bisque;
                            }
                            else
                            {
                                boardGrid[r][c].BackColor = gridColors[(r % 2) ^ (c % 2)];
                            }
                        }
                        else
                        {
                            boardGrid[r][c].Text = "";
                            boardGrid[r][c].BackColor = gridColors[(r % 2) ^ (c % 2)];
                        }
                    }
                }
                else
                {
                    notPlaced[c].Text = message[c];
                    for (int r = 0; r < 10; r++)
                    {
                        boardGrid[r][c].Text = "";
                        boardGrid[r][c].BackColor = gridColors[(r % 2) ^ (c % 2)];
                    }
                }
            }

        }

        /// <summary>
        /// Generate a solution to an NxN chessboard to place N queens on the board
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="alreadyPlaced"></param>
        /// <returns></returns>
        public List<List<int>> PlaceQueensOnBoard(int boardSize, List<int> alreadyPlaced)
        {

            List<List<int>> solutions = new List<List<int>>();
            if (alreadyPlaced.Count == boardSize)
            {
                if (IsValidSolution(alreadyPlaced)) solutions.Add(alreadyPlaced);
            }
            else
            { 
                /*
                 * to make this return all possible solutions instead of terminating 
                 * when the first solution is complete, remove "&& solutions.Count == 0"
                 * from the for loop
                 */
                for (int i = 0; i < boardSize && solutions.Count == 0; i++)
                {
                    List<int> errorColumns = new List<int>(); //used for visualization of conflicting cells


                    if (!alreadyPlaced.Contains(i))
                    {
                        //each index position is a column
                        //the value at that index is the row of that queen
                        List<int> nextColumn = new List<int>(alreadyPlaced.ToArray());
                        nextColumn.Add(i);

                        AddVisualization(nextColumn, errorColumns);

                        if (IsValidSolution(nextColumn))
                        {
                            solutions.AddRange(PlaceQueensOnBoard(boardSize, nextColumn));

                        }

                    }
                    else
                    {
                        //this else block is only needed for visualization of the conflicting piece
                        //if this were not a visual application and just need to find
                        //the correct placement of queens, this could be removed.
                        errorColumns.Add(alreadyPlaced.Count);
                        errorColumns.Add(alreadyPlaced.IndexOf(i));

                        List<int> nextColumn = new List<int>(alreadyPlaced.ToArray());
                        nextColumn.Add(i);

                        AddVisualization(nextColumn, errorColumns);
                    }

                }
            }
            return solutions;

        }


        /// <summary>
        /// Test a partial solution for a chess board and determine if there are any pieces that share a diagonal
        /// </summary>
        /// <param name="alreadyPlaced"></param>
        /// <returns></returns>
        /// <remarks>
        /// The design of the PlaceQueensOnBoard algorithm ensures that only one element per row and only one
        /// element per column will be generated.  This function is used to test a solution for queens that share
        /// a diagonal
        /// </remarks>
        public bool IsValidSolution(List<int> alreadyPlaced)
        {
            //loop through all pairs of placed pieces - if any lie on the same diagonal, return false
            for (int i = 0; i < alreadyPlaced.Count - 1; i++)
            {
                for (int j = i + 1; j < alreadyPlaced.Count; j++)
                {
                    //if the horizontal distance between pieces is the same as the vertical distance, then they are on the same diagonal
                    if ((j - i) == Math.Abs(alreadyPlaced[i] - alreadyPlaced[j]))
                    {
                        AddVisualization(alreadyPlaced, new List<int>() { j, i });
                        return false;
                    }
                }
            }
            return true;
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            if (visualizaitonData.Count != 0)
            {
                VisualizeEntry(visualizaitonData[0]);
                visualizaitonData.RemoveAt(0);
            }
            else
            {
                visualizationTimer.Stop();
            }
        }
    }
}
