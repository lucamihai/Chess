using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public abstract class ChessPiece
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

        public abstract string Abbreviation { get; }

        public Image ImageSmall { get; protected set; }

        public abstract void CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard chessBoard, Point location, Point kingPosition);

        protected bool WillMoveTriggerCheck(Chessboard chessBoard, Point origin, Point destination, Point kingPosition)
        {
            // Back up origin and destination data
            var originChessPiece = chessBoard[origin].Piece;
            var destinationChessPiece = chessBoard[destination].Piece;

            // Pretend the move was made
            chessBoard[origin].Piece = null;
            chessBoard[destination].Piece = originChessPiece;

            var triggersCheck = false;

            if (!triggersCheck)
                triggersCheck = IsThreatenedByPawns(chessBoard, kingPosition);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKing(chessBoard, kingPosition);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKnights(chessBoard, kingPosition);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByRooks(chessBoard, kingPosition);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByBishops(chessBoard, kingPosition);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByQueen(chessBoard, kingPosition);


            chessBoard[origin].Piece = originChessPiece;
            chessBoard[destination].Piece = destinationChessPiece;

            return triggersCheck;
        }

        protected bool IsThreatenedByPawns(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;

            if (currentLocation.Piece.Color == PieceColor.White)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[location.X + 1, location.Y - 1], PieceColor.Black);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[location.X + 1, location.Y + 1], PieceColor.Black);
            }

            if (currentLocation.Piece.Color == PieceColor.Black)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[location.X - 1, location.Y - 1], PieceColor.White);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[location.X - 1, location.Y + 1], PieceColor.White);
            }

            return threatened;
        }

        protected bool IsThreatenedByKing(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;
            var containsKing = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X + 1, location.Y - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X + 1, location.Y + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }
            
            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X + 1, location.Y];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X, location.Y - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X, location.Y + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X - 1, location.Y - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X - 1, location.Y];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[location.X - 1, location.Y + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            return threatened;
        }

        protected bool IsThreatenedByKnights(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;
            var containsKnight = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                if (location.X < 8 && location.Y < 7)
                {
                    locationToBeInspected = chessBoard[location.X + 1, location.Y + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (location.X < 8 && location.Y > 2)
                {
                    locationToBeInspected = chessBoard[location.X + 1, location.Y - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (location.X < 7 && location.Y < 8)
                {
                    locationToBeInspected = chessBoard[location.X + 2, location.Y + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (location.X < 7 && location.Y > 1)
                {
                    locationToBeInspected = chessBoard[location.X + 2, location.Y - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (location.X > 1 && location.Y < 7)
                {
                    locationToBeInspected = chessBoard[location.X - 1, location.Y + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (location.X > 1 && location.Y > 2)
                {
                    locationToBeInspected = chessBoard[location.X - 1, location.Y - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //----- 

            if (!threatened)
            {
                if (location.X > 2 && location.Y < 8)
                {
                    locationToBeInspected = chessBoard[location.X - 2, location.Y + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (location.X > 2 && location.Y > 1)
                {
                    locationToBeInspected = chessBoard[location.X - 2, location.Y - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            return threatened;
        }

        protected bool IsThreatenedByBishops(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;
            var containsBishop = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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

        protected bool IsThreatenedByRooks(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;
            var containsRook = false;

            Box locationToBeInspected;

            // West
            for (int secondaryColumn = location.Y; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == location.Y)
                    continue;

                locationToBeInspected = chessBoard[location.X, secondaryColumn];
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
            for (int secondaryColumn = location.Y; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == location.Y)
                    continue;

                locationToBeInspected = chessBoard[location.X, secondaryColumn];
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
            for (int secondaryRow = location.X; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == location.X)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, location.Y];
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
            for (int secondaryRow = location.X; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == location.X)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, location.Y];
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

        protected bool IsThreatenedByQueen(Chessboard chessBoard, Point location)
        {
            var currentLocation = chessBoard[location];
            var threatened = false;
            var containsQueen = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryRow = location.X, secondaryColumn = location.Y; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == location.X && secondaryColumn == location.Y)
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
            for (int secondaryColumn = location.Y; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == location.Y)
                    continue;

                locationToBeInspected = chessBoard[location.X, secondaryColumn];
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
            for (int secondaryColumn = location.Y; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == location.Y)
                    continue;

                locationToBeInspected = chessBoard[location.X, secondaryColumn];
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
            for (int secondaryRow = location.X; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == location.X)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, location.Y];
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
            for (int secondaryRow = location.X; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == location.X)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, location.Y];
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

