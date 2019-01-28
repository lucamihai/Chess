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
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            {
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
            }
        }
    }
}
