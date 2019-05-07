using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhiteRook : Properties.Resources.BlackRook;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Rook;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard chessBoard, Point location, Point kingPosition)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[location.X, location.Y];

            Box locationToBeInspected;
            Point destination;

            // Check movement to the west
            for (int secondaryColumn = location.Y; secondaryColumn >= 1; secondaryColumn--)
            {
                if (secondaryColumn == location.Y)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                destination = new Point(row, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the east
            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                destination = new Point(row, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the south
            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                destination=new Point(secondaryRow, column);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the north
            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                destination = new Point(secondaryRow, column);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }
    }
}
