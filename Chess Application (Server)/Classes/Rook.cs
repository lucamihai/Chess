using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace Chess_Application
{
    public class Rook : ChessPiece
    {
        public Rook(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 2;
        }
        public override void CheckPossibilities(int row, int column, LocatieTabla[,] loc)
        {
            {
                // Check movement to the west
                for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
                {
                    if (loc[row, secondaryColumn - 1] != null && loc[row, secondaryColumn - 1].culoare == loc[row, column].culoare)
                    {
                        if (loc[row, secondaryColumn] != loc[row, column] && !TriggersCheck(loc, row, column, row, secondaryColumn))
                        {
                            loc[row, secondaryColumn].MarkAsAvailable(); loc[row, column].poateFaceMiscari = true;
                        }
                        break;
                    }

                    if (loc[row, secondaryColumn].culoare != loc[row, column].culoare && !TriggersCheck(loc, row, column, row, secondaryColumn))
                    {
                        loc[row, secondaryColumn].MarkAsAvailable();
                        loc[row, column].poateFaceMiscari = true;
                    }

                    if (loc[row, secondaryColumn].culoare != loc[row, column].culoare && loc[row, secondaryColumn].culoare != 0)
                    {
                        break;
                    }
                }

                // Check movement to the east
                for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
                {
                    if (loc[row, secondaryColumn + 1] != null && loc[row, secondaryColumn + 1].culoare == loc[row, column].culoare)
                    {
                        if (loc[row, secondaryColumn] != loc[row, column] && !TriggersCheck(loc, row, column, row, secondaryColumn))
                        {
                            loc[row, secondaryColumn].MarkAsAvailable(); loc[row, column].poateFaceMiscari = true;
                        }
                        break;
                    }

                    if (loc[row, secondaryColumn].culoare != loc[row, column].culoare && !TriggersCheck(loc, row, column, row, secondaryColumn))
                    {
                        loc[row, secondaryColumn].MarkAsAvailable();
                        loc[row, column].poateFaceMiscari = true;
                    }

                    if (loc[row, secondaryColumn].culoare != loc[row, column].culoare && loc[row, secondaryColumn].culoare != 0)
                    {
                        break;
                    }
                }

                // Check movement to the south
                for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
                {
                    if (loc[secondaryRow - 1, column] != null && loc[secondaryRow - 1, column].culoare == loc[row, column].culoare)
                    {
                        if (loc[secondaryRow, column] != loc[row, column] && !TriggersCheck(loc, row, column, secondaryRow, column))
                        {
                            loc[secondaryRow, column].MarkAsAvailable(); loc[row, column].poateFaceMiscari = true;
                        }
                        break;
                    }

                    if (loc[secondaryRow, column].culoare != loc[row, column].culoare && !TriggersCheck(loc, row, column, secondaryRow, column))
                    {
                        loc[secondaryRow, column].MarkAsAvailable();
                        loc[row, column].poateFaceMiscari = true;
                    }

                    if (loc[secondaryRow, column].culoare != loc[row, column].culoare && loc[secondaryRow, column].culoare != 0)
                    {
                        break;
                    }
                }

                // Check movement to the north
                for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
                {
                    if (loc[secondaryRow + 1, column] != null && loc[secondaryRow + 1, column].culoare == loc[row, column].culoare)
                    {
                        if (loc[secondaryRow, column] != loc[row, column] && !TriggersCheck(loc, row, column, secondaryRow, column))
                        {
                            loc[secondaryRow, column].MarkAsAvailable(); loc[row, column].poateFaceMiscari = true;
                        }
                        break;
                    }
                    if (loc[secondaryRow, column].culoare != loc[row, column].culoare && !TriggersCheck(loc, row, column, secondaryRow, column))
                    {
                        loc[secondaryRow, column].MarkAsAvailable();
                        loc[row, column].poateFaceMiscari = true;
                    }

                    if (loc[secondaryRow, column].culoare != loc[row, column].culoare && loc[secondaryRow, column].culoare != 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
