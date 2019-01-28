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
    public class Queen : ChessPiece
    {
       
        public Queen(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 5;
        }
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            for (int m = 1; m <= 8; m++)
            {
                for (int n = 1; m <= 8; m++)
                {
                    chessBoard[m, n].MarkAsUnavailable();
                }
            }

            #region Rook behaviour

            // Check movement to the west
            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn - 1] != null && chessBoard[row, secondaryColumn - 1].Piece.culoare == chessBoard[row, column].Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn] != chessBoard[row, column] && !TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                    {
                        chessBoard[row, secondaryColumn].MarkAsAvailable(); chessBoard[row, column].poateFaceMiscari = true;
                    }
                    break;
                }

                if (chessBoard[row, secondaryColumn].Piece.culoare != chessBoard[row, column].Piece.culoare && !TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                {
                    chessBoard[row, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                if (chessBoard[row, secondaryColumn].Piece.culoare != chessBoard[row, column].Piece.culoare && chessBoard[row, secondaryColumn].Piece.culoare != 0)
                {
                    break;
                }
            }

            // Check movement to the east
            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn + 1] != null && chessBoard[row, secondaryColumn + 1].Piece.culoare == chessBoard[row, column].Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn] != chessBoard[row, column] && !TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                    {
                        chessBoard[row, secondaryColumn].MarkAsAvailable(); chessBoard[row, column].poateFaceMiscari = true;
                    }
                    break;
                }

                if (chessBoard[row, secondaryColumn].Piece.culoare != chessBoard[row, column].Piece.culoare && !TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                {
                    chessBoard[row, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                if (chessBoard[row, secondaryColumn].Piece.culoare != chessBoard[row, column].Piece.culoare && chessBoard[row, secondaryColumn].Piece.culoare != 0)
                {
                    break;
                }
            }

            // Check movement to the south
            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow - 1, column] != null && chessBoard[secondaryRow - 1, column].Piece.culoare == chessBoard[row, column].Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column] != chessBoard[row, column] && !TriggersCheck(chessBoard, row, column, secondaryRow, column))
                    {
                        chessBoard[secondaryRow, column].MarkAsAvailable(); chessBoard[row, column].poateFaceMiscari = true;
                    }
                    break;
                }

                if (chessBoard[secondaryRow, column].Piece.culoare != chessBoard[row, column].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, column))
                {
                    chessBoard[secondaryRow, column].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                if (chessBoard[secondaryRow, column].Piece.culoare != chessBoard[row, column].Piece.culoare && chessBoard[secondaryRow, column].Piece.culoare != 0)
                {
                    break;
                }
            }

            // Check movement to the north
            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow + 1, column] != null && chessBoard[secondaryRow + 1, column].Piece.culoare == chessBoard[row, column].Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column] != chessBoard[row, column] && !TriggersCheck(chessBoard, row, column, secondaryRow, column))
                    {
                        chessBoard[secondaryRow, column].MarkAsAvailable(); chessBoard[row, column].poateFaceMiscari = true;
                    }
                    break;
                }
                if (chessBoard[secondaryRow, column].Piece.culoare != chessBoard[row, column].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, column))
                {
                    chessBoard[secondaryRow, column].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                if (chessBoard[secondaryRow, column].Piece.culoare != chessBoard[row, column].Piece.culoare && chessBoard[secondaryRow, column].Piece.culoare != 0)
                {
                    break;
                }
            }

            #endregion

            #region Bishop behaviour

            // Check movement to the south - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[row, column].Piece.culoare != chessBoard[secondaryRow, secondaryColumn].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                {
                    chessBoard[secondaryRow, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (chessBoard[secondaryRow - 1, secondaryColumn - 1] != null)
                {
                    if (chessBoard[secondaryRow - 1, secondaryColumn - 1].Piece.culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the north - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[row, column].Piece.culoare != chessBoard[secondaryRow, secondaryColumn].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                {
                    chessBoard[secondaryRow, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (chessBoard[secondaryRow + 1, secondaryColumn + 1] != null)
                {
                    if (chessBoard[secondaryRow + 1, secondaryColumn + 1].Piece.culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the north - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[row, column].Piece.culoare != chessBoard[secondaryRow, secondaryColumn].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                {
                    chessBoard[secondaryRow, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (chessBoard[secondaryRow + 1, secondaryColumn - 1] != null)
                {
                    if (chessBoard[secondaryRow + 1, secondaryColumn - 1].Piece.culoare != 0)
                    {
                        break;
                    }
                }
            }

            // Check movement to the south - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[row, column].Piece.culoare != chessBoard[secondaryRow, secondaryColumn].Piece.culoare && !TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                {
                    chessBoard[secondaryRow, secondaryColumn].MarkAsAvailable();
                    chessBoard[row, column].poateFaceMiscari = true;
                }

                // If a piece was found
                if (chessBoard[secondaryRow - 1, secondaryColumn + 1] != null)
                {
                    if (chessBoard[secondaryRow - 1, secondaryColumn + 1].Piece.culoare != 0)
                    {
                        break;
                    }
                }
            }

            #endregion
        }
    }
}
