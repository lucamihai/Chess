using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public class ChessPiece
    {
        public PieceColor Color { get; protected set; } 

        public bool CanMove { get; set; } = false;

        private Image _Image;
        public Image Image
        {
            get => _Image;
            set
            {
                _Image = value;

                if (_Image != null)
                {
                    ImageSmall = Utilities.ResizeImage(_Image, 32, 32);
                }
            }
        }

        public virtual string Abbreviation { get; }

        public Image ImageSmall { get; protected set; }

        public virtual void CheckPossibilitiesForProvidedLocationAndMarkThem(Box[,] chessBoard, Point location, Point kingPosition) { }

        protected bool WillMoveTriggerCheck(Box[,] chessBoard, Point origin, Point destination, Point kingPosition)
        {
            // Back up origin and destination data
            var originChessPiece = chessBoard[origin.X, origin.Y].Piece;
            var destinationChessPiece = chessBoard[destination.X, destination.Y].Piece;

            // Pretend the move was made
            chessBoard[origin.X, origin.Y].Piece = null;
            chessBoard[destination.X, destination.Y].Piece = originChessPiece;

            var triggersCheck = false;

            if (!triggersCheck)
                triggersCheck = IsThreatenedByPawns(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKing(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKnights(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByRooks(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByBishops(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByQueen(chessBoard, kingPosition.X, kingPosition.Y);


            chessBoard[origin.X, origin.Y].Piece = originChessPiece;
            chessBoard[destination.X, destination.Y].Piece = destinationChessPiece;

            return triggersCheck;
        }

        protected bool IsThreatenedByPawns(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;

            if (currentLocation.Piece.Color == PieceColor.White)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row + 1, column - 1], PieceColor.Black);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row + 1, column + 1], PieceColor.Black);
            }

            if (currentLocation.Piece.Color == PieceColor.Black)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row - 1, column - 1], PieceColor.White);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row - 1, column + 1], PieceColor.White);
            }

            return threatened;
        }

        protected bool IsThreatenedByKing(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;
            var containsKing = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }
            
            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            return threatened;
        }

        protected bool IsThreatenedByKnights(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;
            var containsKnight = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                if (row < 8 && column < 7)
                {
                    locationToBeInspected = chessBoard[row + 1, column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row < 8 && column > 2)
                {
                    locationToBeInspected = chessBoard[row + 1, column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (row < 7 && column < 8)
                {
                    locationToBeInspected = chessBoard[row + 2, column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row < 7 && column > 1)
                {
                    locationToBeInspected = chessBoard[row + 2, column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (row > 1 && column < 7)
                {
                    locationToBeInspected = chessBoard[row - 1, column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row > 1 && column > 2)
                {
                    locationToBeInspected = chessBoard[row - 1, column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //----- 

            if (!threatened)
            {
                if (row > 2 && column < 8)
                {
                    locationToBeInspected = chessBoard[row - 2, column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row > 2 && column > 1)
                {
                    locationToBeInspected = chessBoard[row - 2, column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            return threatened;
        }

        protected bool IsThreatenedByBishops(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;
            var containsBishop = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsBishop = Utilities.LocationContainsPiece<Bishop>(locationToBeInspected);
                threatened = (containsBishop && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsBishop && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsBishop && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsBishop = Utilities.LocationContainsPiece<Bishop>(locationToBeInspected);
                threatened = (containsBishop && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsBishop && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsBishop && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsBishop = Utilities.LocationContainsPiece<Bishop>(locationToBeInspected);
                threatened = (containsBishop && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsBishop && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsBishop && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // South - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsBishop = Utilities.LocationContainsPiece<Bishop>(locationToBeInspected);
                threatened = (containsBishop && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsBishop && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsBishop && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return threatened;
        }

        protected bool IsThreatenedByRooks(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;
            var containsRook = false;

            Box locationToBeInspected;

            // West
            for (int secondaryColumn = column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                containsRook = Utilities.LocationContainsPiece<Rook>(locationToBeInspected);
                threatened = (containsRook && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsRook && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsRook && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // East
            for (int secondaryColumn = column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                containsRook = Utilities.LocationContainsPiece<Rook>(locationToBeInspected);
                threatened = (containsRook && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsRook && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsRook && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // South
            for (int secondaryRow = row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                containsRook = Utilities.LocationContainsPiece<Rook>(locationToBeInspected);
                threatened = (containsRook && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsRook && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsRook && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North
            for (int secondaryRow = row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                containsRook = Utilities.LocationContainsPiece<Rook>(locationToBeInspected);
                threatened = (containsRook && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsRook && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsRook && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return threatened;
        }

        protected bool IsThreatenedByQueen(Box[,] chessBoard, int row, int column)
        {
            var currentLocation = chessBoard[row, column];
            var threatened = false;
            var containsQueen = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // South - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // West
            for (int secondaryColumn = column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // East
            for (int secondaryColumn = column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // South
            for (int secondaryRow = row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            // North
            for (int secondaryRow = row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
                containsQueen = Utilities.LocationContainsPiece<Queen>(locationToBeInspected);
                threatened = (containsQueen && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);

                if (containsQueen && locationToBeInspected.Piece.Color == currentLocation.Piece.Color)
                {
                    break;
                }

                if (!containsQueen && locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return threatened;
        }
    }
}

