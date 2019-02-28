using System.Drawing;
using Chess_Application.Common.Enums;
using Chess_Application.Common.UserControls;

namespace Chess_Application.Common.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor pieceColor)
        {
            Color = pieceColor;

            if (pieceColor == PieceColor.White)
            {
                Image = Properties.Resources.WhitePawn;
            }
            else
            {
                Image = Properties.Resources.BlackPawn;
            }
        }
        
        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Box[,] chessBoard, Point location, Point kingPosition)
        {
            var row = location.X;
            var column = location.Y;

            Box locationToBeInspected;
            Point destination;
            // White pawn
            if (Color == PieceColor.White)
            {
                locationToBeInspected = chessBoard[row + 1, column];
                destination = new Point(row + 1, column);
                if (locationToBeInspected != null && locationToBeInspected.Piece == null)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        locationToBeInspected.Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                locationToBeInspected = chessBoard[row + 1, column + 1];
                destination = new Point(row + 1, column + 1);
                if (row < 8 && column < 8 && locationToBeInspected.Piece != null && locationToBeInspected.Piece.Color == PieceColor.Black)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        chessBoard[row + 1, column + 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                locationToBeInspected = chessBoard[row + 1, column - 1];
                destination = new Point(row + 1, column - 1);
                if (row < 8 && column > 1 && locationToBeInspected.Piece != null && locationToBeInspected.Piece.Color == PieceColor.Black)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        chessBoard[row + 1, column - 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                        
                    }
                }

                // Check if pawn can make 2 steps forward
                locationToBeInspected = chessBoard[row + 2, column];
                destination = new Point(row + 2, column);
                if (row == 2 && locationToBeInspected != null )
                {
                    if (chessBoard[row + 2, column].Piece == null && chessBoard[row + 1, column].Piece == null)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
                locationToBeInspected = chessBoard[row - 1, column];
                destination = new Point(row - 1, column);
                if (locationToBeInspected != null && locationToBeInspected.Piece == null)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        chessBoard[row - 1, column].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }                   
                }

                locationToBeInspected = chessBoard[row - 1, column + 1];
                destination = new Point(row - 1, column + 1);
                if (row > 1 && column < 8 && locationToBeInspected.Piece != null && locationToBeInspected.Piece.Color == PieceColor.White)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        chessBoard[row - 1, column + 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                locationToBeInspected = chessBoard[row - 1, column - 1];
                destination = new Point(row - 1, column - 1);
                if (row > 1 && column > 1 && locationToBeInspected.Piece != null && locationToBeInspected.Piece.Color == PieceColor.White)
                {
                    if ( !WillMoveTriggerCheck(chessBoard, location, destination, kingPosition) )
                    {
                        chessBoard[row - 1, column - 1].Available = true;
                        chessBoard[row, column].Piece.CanMove = true;
                    }
                }

                // Check if pawn can make 2 steps forward
                locationToBeInspected = chessBoard[row - 1, column];
                destination = new Point(row - 1, column);
                if (row == 7 && chessBoard[row - 2, column] != null)
                {
                    if (chessBoard[row - 2, column].Piece == null && chessBoard[row - 1, column].Piece == null)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
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
