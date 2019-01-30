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
    public class Pawn : ChessPiece
    {
        public Pawn(int c, PictureBox p, PictureBox pm)
        {
            Color = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
        }
        
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            Box locationToBeInspected;
            // White pawn
            if (Color == 1)
            {
                if (chessBoard[row + 1, column] != null && chessBoard[row + 1, column].Piece == null)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column) )
                    {
                        chessBoard[row + 1, column].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }
                }

                if (row < 8 && column < 8 && chessBoard[row + 1, column + 1].Piece != null && chessBoard[row + 1, column + 1].Piece.Color == 2)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column + 1) )
                    {
                        chessBoard[row + 1, column + 1].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }
                }

                if (row < 8 && column > 1 && chessBoard[row + 1, column - 1].Piece != null && chessBoard[row + 1, column - 1].Piece.Color == 2)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column - 1) )
                    {
                        chessBoard[row + 1, column - 1].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }
                }

                // Check if pawn can make 2 steps forward
                if (row == 2 && chessBoard[row + 2, column] != null )
                {
                    if (chessBoard[row + 2, column].Piece == null && chessBoard[row + 1, column].Piece == null)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row + 2, column))
                        {
                            chessBoard[row + 2, column].MarkAsAvailable();
                            chessBoard[row, column].poateFaceMiscari = true;
                        }
                    }
                }
            }

            // Black pawn
            if (Color == 2)
            {
                if (chessBoard[row - 1, column] != null && chessBoard[row - 1, column].Piece == null)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column) )
                    {
                        chessBoard[row - 1, column].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }                   
                }

                if (row > 1 && column < 8 && chessBoard[row - 1, column + 1].Piece != null && chessBoard[row - 1, column + 1].Piece.Color == 1)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column + 1) )
                    {
                        chessBoard[row - 1, column + 1].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }
                }

                if (row > 1 && column > 1 && chessBoard[row - 1, column - 1].Piece != null && chessBoard[row - 1, column - 1].Piece.Color == 1)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column - 1) )
                    {
                        chessBoard[row - 1, column - 1].MarkAsAvailable();
                        chessBoard[row, column].poateFaceMiscari = true;
                    }
                }

                // Check if pawn can make 2 steps forward
                if (row == 7 && chessBoard[row - 2, column] != null)
                {
                    if (chessBoard[row - 2, column].Piece == null && chessBoard[row - 1, column].Piece == null)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row - 2, column))
                        {
                            chessBoard[row - 2, column].MarkAsAvailable();
                            chessBoard[row, column].poateFaceMiscari = true;
                        }
                    }
                }
            }
        }
    }
}
