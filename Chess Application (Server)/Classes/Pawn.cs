using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Chess_Application.Classes;
using Chess_Application.Enums;

namespace Chess_Application
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor c)
        {
            Color = c;

            if (c == PieceColor.White)
            {
                Image = Chess_Application.Properties.Resources.WhitePawn;
            }
            else
            {
                Image = Chess_Application.Properties.Resources.BlackPawn;
            }
        }
        
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            Box locationToBeInspected;
            // White pawn
            if (Color == PieceColor.White)
            {
                if (chessBoard[row + 1, column] != null && chessBoard[row + 1, column].Piece == null)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column) )
                    {
                        chessBoard[row + 1, column].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                if (row < 8 && column < 8 && chessBoard[row + 1, column + 1].Piece != null && chessBoard[row + 1, column + 1].Piece.Color == PieceColor.Black)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column + 1) )
                    {
                        chessBoard[row + 1, column + 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                if (row < 8 && column > 1 && chessBoard[row + 1, column - 1].Piece != null && chessBoard[row + 1, column - 1].Piece.Color == PieceColor.Black)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row + 1, column - 1) )
                    {
                        chessBoard[row + 1, column - 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                // Check if pawn can make 2 steps forward
                if (row == 2 && chessBoard[row + 2, column] != null )
                {
                    if (chessBoard[row + 2, column].Piece == null && chessBoard[row + 1, column].Piece == null)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row + 2, column))
                        {
                            chessBoard[row + 2, column].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
            }

            // Black pawn
            if (Color == PieceColor.Black)
            {
                if (chessBoard[row - 1, column] != null && chessBoard[row - 1, column].Piece == null)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column) )
                    {
                        chessBoard[row - 1, column].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }                   
                }

                if (row > 1 && column < 8 && chessBoard[row - 1, column + 1].Piece != null && chessBoard[row - 1, column + 1].Piece.Color == PieceColor.White)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column + 1) )
                    {
                        chessBoard[row - 1, column + 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                if (row > 1 && column > 1 && chessBoard[row - 1, column - 1].Piece != null && chessBoard[row - 1, column - 1].Piece.Color == PieceColor.White)
                {
                    if ( !TriggersCheck(chessBoard, row, column, row - 1, column - 1) )
                    {
                        chessBoard[row - 1, column - 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                // Check if pawn can make 2 steps forward
                if (row == 7 && chessBoard[row - 2, column] != null)
                {
                    if (chessBoard[row - 2, column].Piece == null && chessBoard[row - 1, column].Piece == null)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row - 2, column))
                        {
                            chessBoard[row - 2, column].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
            }
        }
    }
}
