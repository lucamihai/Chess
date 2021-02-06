using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.Chessboards
{
    public class ChessboardClassic : IChessboard
    {
        private Box[,] Boxes { get; }

        public Box this[Position point]
        {
            get
            {
                if (point.Row < 0 || point.Row > 10)
                {
                    return null;
                }
                if (point.Column < 0 || point.Column > 10)
                {
                    return null;
                }

                return Boxes[point.Row, point.Column];
            }
        }

        public Box this[int row, int column]
        {
            get
            {
                if (row < 0 || row > 10)
                {
                    return null;
                }
                if (column < 0 || column > 10)
                {
                    return null;
                }

                return Boxes[row, column];
            }
        }

        public Position PositionWhiteKing { get; set; } = new Position(1, 5);
        public Position PositionBlackKing { get; set; } = new Position(8, 4);

        private bool beginnersMode = true;
        public bool BeginnersMode
        {
            get => beginnersMode;
            set
            {
                beginnersMode = value;

                for (int row = 1; row <= 8; row++)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        Boxes[row, column].BeginnersMode = BeginnersMode;
                    }
                }
            }
        }

        public ChessboardClassic()
        {
            Boxes = new Box[10, 10];

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    var boxName = GenerateBoxNameBasedOnRowAndColumn(row, column);
                    var boxLocation = GenerateBoxLocationBasedOnRowAndColumn(row, column);

                    Boxes[row, column] = new Box(boxName);
                    Boxes[row, column].Location = boxLocation;
                    Boxes[row, column].BeginnersMode = true;
                }
            }

            AddWhitePieces();
            AddBlackPieces();
        }

        public void ResetChessBoardBoxesColors()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        Boxes[row, column].BoxBackgroundColor = Constants.BoxColorDark;
                    }
                    else
                    {
                        Boxes[row, column].BoxBackgroundColor = Constants.BoxColorLight;
                    }
                }
            }
        }

        public void SetChessBoardBoxesAsUnavailable()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    Boxes[row, column].Available = false;
                }
            }
        }

        public bool IsCheckmateForProvidedColor(PieceColor providedColor)
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    if (Boxes[row, column].Piece != null && Boxes[row, column].Piece.Color == providedColor)
                    {
                        var location = new Position(row, column);
                        Boxes[row, column].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(this, location);

                        if (Boxes[row, column].Piece.CanMove)
                        {
                            ResetChessBoardBoxesColors();
                            Boxes[row, column].Piece.CanMove = false;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool MoveTriggersCheck(Position origin, Position destination)
        {
            // Back up origin and destination data
            var originChessPiece = this[origin].Piece;
            var destinationChessPiece = this[destination].Piece;

            // Pretend the move was made
            this[origin].Piece = null;
            this[destination].Piece = originChessPiece;

            var kingPosition = originChessPiece.Color == PieceColor.White
                ? PositionWhiteKing
                : PositionBlackKing;
            var triggersCheck = PieceIsThreatened(kingPosition);

            // Restore origin and destination
            this[origin].Piece = originChessPiece;
            this[destination].Piece = destinationChessPiece;

            return triggersCheck;
        }

        public bool PieceIsThreatened(Position location)
        {
            var isThreatened = false;

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByPawns(location);

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByKing(location);

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByKnights(location);

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByRooks(location);

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByBishops(location);

            if (!isThreatened)
                isThreatened = PieceIsThreatenedByQueen(location);

            return isThreatened;
        }

        public bool PieceIsThreatenedByPawns(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;

            if (currentLocation.Piece.Color == PieceColor.White)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(this[position.Row + 1, position.Column - 1], PieceColor.Black);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(this[position.Row + 1, position.Column + 1], PieceColor.Black);
            }

            if (currentLocation.Piece.Color == PieceColor.Black)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(this[position.Row - 1, position.Column - 1], PieceColor.White);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(this[position.Row - 1, position.Column + 1], PieceColor.White);
            }

            return threatened;
        }

        public bool PieceIsThreatenedByKing(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;
            var containsKing = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                locationToBeInspected = this[position.Row + 1, position.Column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row + 1, position.Column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row + 1, position.Column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row, position.Column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row, position.Column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row - 1, position.Column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row - 1, position.Column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = this[position.Row - 1, position.Column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            return threatened;
        }

        public bool PieceIsThreatenedByKnights(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;
            var containsKnight = false;

            Box locationToBeInspected;

            if (!threatened)
            {
                if (position.Row < 8 && position.Column < 7)
                {
                    locationToBeInspected = this[position.Row + 1, position.Column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (position.Row < 8 && position.Column > 2)
                {
                    locationToBeInspected = this[position.Row + 1, position.Column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (position.Row < 7 && position.Column < 8)
                {
                    locationToBeInspected = this[position.Row + 2, position.Column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (position.Row < 7 && position.Column > 1)
                {
                    locationToBeInspected = this[position.Row + 2, position.Column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (position.Row > 1 && position.Column < 7)
                {
                    locationToBeInspected = this[position.Row - 1, position.Column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (position.Row > 1 && position.Column > 2)
                {
                    locationToBeInspected = this[position.Row - 1, position.Column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //----- 

            if (!threatened)
            {
                if (position.Row > 2 && position.Column < 8)
                {
                    locationToBeInspected = this[position.Row - 2, position.Column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (position.Row > 2 && position.Column > 1)
                {
                    locationToBeInspected = this[position.Row - 2, position.Column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            return threatened;
        }

        public bool PieceIsThreatenedByBishops(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;
            var containsBishop = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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

        public bool PieceIsThreatenedByRooks(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;
            var containsRook = false;

            Box locationToBeInspected;

            // West
            for (int secondaryColumn = position.Column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[position.Row, secondaryColumn];
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
            for (int secondaryColumn = position.Column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[position.Row, secondaryColumn];
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
            for (int secondaryRow = position.Row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == position.Row)
                    continue;

                locationToBeInspected = this[secondaryRow, position.Column];
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
            for (int secondaryRow = position.Row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == position.Row)
                    continue;

                locationToBeInspected = this[secondaryRow, position.Column];
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

        public bool PieceIsThreatenedByQueen(Position position)
        {
            var currentLocation = this[position];
            var threatened = false;
            var containsQueen = false;

            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[secondaryRow, secondaryColumn];
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
            for (int secondaryColumn = position.Column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[position.Row, secondaryColumn];
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
            for (int secondaryColumn = position.Column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == position.Column)
                    continue;

                locationToBeInspected = this[position.Row, secondaryColumn];
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
            for (int secondaryRow = position.Row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == position.Row)
                    continue;

                locationToBeInspected = this[secondaryRow, position.Column];
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
            for (int secondaryRow = position.Row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == position.Row)
                    continue;

                locationToBeInspected = this[secondaryRow, position.Column];
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

        private static string GenerateBoxNameBasedOnRowAndColumn(int row, int column)
        {
            var rowLetter = (char)('A' + row - 1);

            return $"{rowLetter}{column}";
        }

        private static Point GenerateBoxLocationBasedOnRowAndColumn(int row, int column)
        {
            return new Point
            {
                X = (column - 1) * 64,
                Y = (8 - row) * 64
            };
        }

        private void AddWhitePieces()
        {
            Boxes[1, 1].Piece = new Rook(PieceColor.White);
            Boxes[1, 2].Piece = new Knight(PieceColor.White);
            Boxes[1, 3].Piece = new Bishop(PieceColor.White);
            Boxes[1, 4].Piece = new Queen(PieceColor.White);
            Boxes[1, 5].Piece = new King(PieceColor.White);
            Boxes[1, 6].Piece = new Bishop(PieceColor.White);
            Boxes[1, 7].Piece = new Knight(PieceColor.White);
            Boxes[1, 8].Piece = new Rook(PieceColor.White);

            for (int column = 1; column < 9; column++)
            {
                Boxes[2, column].Piece = new Pawn(PieceColor.White);
            }
        }

        private void AddBlackPieces()
        {
            Boxes[8, 1].Piece = new Rook(PieceColor.Black);
            Boxes[8, 2].Piece = new Knight(PieceColor.Black);
            Boxes[8, 3].Piece = new Bishop(PieceColor.Black);
            Boxes[8, 4].Piece = new King(PieceColor.Black);
            Boxes[8, 5].Piece = new Queen(PieceColor.Black);
            Boxes[8, 6].Piece = new Bishop(PieceColor.Black);
            Boxes[8, 7].Piece = new Knight(PieceColor.Black);
            Boxes[8, 8].Piece = new Rook(PieceColor.Black);

            for (int column = 1; column < 9; column++)
            {
                Boxes[7, column].Piece = new Pawn(PieceColor.Black);
            }
        }

    }
}
