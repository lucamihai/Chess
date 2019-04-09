using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = Color == PieceColor.White ? Properties.Resources.WhiteBishop : Properties.Resources.BlackBishop;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Bishop;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Box[,] chessBoard, Point location, Point kingPosition)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[row, column];

            Box locationToBeInspected;
            Point destination;

            // Check movement to the south - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                destination=new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
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

            // Check movement to the north - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
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

            // Check movement to the north - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
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

            // Check movement to the south - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, location, destination, kingPosition))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
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
