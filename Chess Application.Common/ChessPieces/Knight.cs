using System.Drawing;
using Chess_Application.Common.Enums;
using Chess_Application.Common.UserControls;

namespace Chess_Application.Common.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight(PieceColor pieceColor)
        {
            Color = pieceColor;

            if (pieceColor == PieceColor.White)
            {
                Image = Properties.Resources.WhiteKnight;
            }
            else
            {
                Image = Properties.Resources.BlackKnight;
            }
        }
        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Box[,] chessBoard, Point location, Point kingPosition)
        {
            var row = location.X;
            var column = location.Y;

            int destinationRow, destinationColumn;
            Point destination;

            if (row < 8 && column < 7)
            {
                destinationRow = row + 1;
                destinationColumn = column + 2;
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                destination = new Point(destinationRow, destinationColumn);

                if (chessBoard[destinationRow, destinationColumn].Piece != null)
                {
                    if (chessBoard[destinationRow, destinationColumn].Piece.Color != chessBoard[row, column].Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            chessBoard[destinationRow, destinationColumn].Available = true;
                            chessBoard[row, column].Piece.CanMove = true;
                        }
                    }
                }
                else
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        chessBoard[destinationRow, destinationColumn].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }
            }
        }
    }
}
