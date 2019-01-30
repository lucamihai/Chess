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
    public class Knight : ChessPiece
    {
        public Knight(int c, PictureBox p, PictureBox pm)
        {
            Color = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            
        }
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            int destinationRow, destinationColumn;

            if (row < 8 && column < 7)
            {
                destinationRow = row + 1;
                destinationColumn = column + 2;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row < 8 && column > 2) 
            {
                destinationRow = row + 1;
                destinationColumn = column - 2;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row < 7 && column < 8) 
            {
                destinationRow = row + 2;
                destinationColumn = column + 1;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row < 7 && column > 1) 
            {
                destinationRow = row + 2;
                destinationColumn = column - 1;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row > 1 && column < 7) 
            {
                destinationRow = row - 1;
                destinationColumn = column + 2;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row > 1 && column > 2) 
            {
                destinationRow = row - 1;
                destinationColumn = column - 2;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row > 2 && column < 8) 
            {
                destinationRow = row - 2;
                destinationColumn = column + 1;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }

            if (row > 2 && column > 1) 
            {
                destinationRow = row - 2;
                destinationColumn = column - 1;

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!TriggersCheck(chessBoard, row, column, destinationRow, destinationColumn))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }
        }
    }
}
