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
    public class Bishop : ChessPiece
    {
        public Bishop(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 4;
        }

        public override void CheckPossibilities(int row, int column, LocatieTabla[,] loc)
        {
            // Check movement to the south - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (loc[row, column].culoare != loc[secondaryRow, secondaryColumn].culoare && !TriggersCheck(loc, row, column, secondaryRow, secondaryColumn)) 
                {
                    loc[secondaryRow, secondaryColumn].MarkAsAvailable();
                    loc[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (loc[secondaryRow - 1, secondaryColumn - 1] != null)
                {
                    if (loc[secondaryRow - 1, secondaryColumn - 1].culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the north - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (loc[row, column].culoare != loc[secondaryRow, secondaryColumn].culoare && !TriggersCheck(loc, row, column, secondaryRow, secondaryColumn))
                {
                    loc[secondaryRow, secondaryColumn].MarkAsAvailable();
                    loc[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (loc[secondaryRow + 1, secondaryColumn + 1] != null)
                {
                    if (loc[secondaryRow + 1, secondaryColumn + 1].culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the north - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (loc[row, column].culoare != loc[secondaryRow, secondaryColumn].culoare && !TriggersCheck(loc, row, column, secondaryRow, secondaryColumn))
                {
                    loc[secondaryRow, secondaryColumn].MarkAsAvailable();
                    loc[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (loc[secondaryRow + 1, secondaryColumn - 1] != null)
                {
                    if (loc[secondaryRow + 1, secondaryColumn - 1].culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the south - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (loc[row, column].culoare != loc[secondaryRow, secondaryColumn].culoare && !TriggersCheck(loc, row, column, secondaryRow, secondaryColumn))
                {
                    loc[secondaryRow, secondaryColumn].MarkAsAvailable();
                    loc[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (loc[secondaryRow - 1, secondaryColumn + 1] != null)
                {
                    if (loc[secondaryRow - 1, secondaryColumn + 1].culoare != 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
