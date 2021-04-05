using System;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.Chessboards
{
    public class ChessboardClassic : IChessboard
    {
        private Box[,] boxes;
        
        public Box this[Position position] => position.IsOutOfBounds() ? null : boxes[position.Row, position.Column];

        public Box this[int row, int column]
        {
            get
            {
                if (row < 1 || row > 8)
                {
                    return null;
                }

                if (column < 1 || column > 8)
                {
                    return null;
                }

                return boxes[row, column];
            }
        }

        public Position PositionWhiteKing { get; set; } = new Position(1, 5);
        public Position PositionBlackKing { get; set; } = new Position(8, 4);
        public CapturedPieceCollection CapturedPieceCollection { get; set; }

        public Turn CurrentTurn { get; set; } = Turn.White;

        private bool beginnersMode = true;
        public bool BeginnersMode
        {
            get => beginnersMode;
            set
            {
                beginnersMode = value;

                for (var row = 1; row <= 8; row++)
                {
                    for (var column = 1; column <= 8; column++)
                    {
                        boxes[row, column].BeginnersMode = BeginnersMode;
                    }
                }
            }
        }

        public bool RetakingIsActive { get; private set; }

        // TODO: Maybe make this nullable and remove RetakingIsActive?
        public Position RetakingPosition { get; private set; } = new Position();


        public ChessboardClassic()
        {
            NewGame();
        }

        public void Move(Position origin, Position destination)
        {
            var originBox = this[origin];
            var destinationBox = this[destination];

            if (destinationBox.Piece != null)
            {
                CapturedPieceCollection.AddEntry(destinationBox.Piece);
            }
            
            destinationBox.Piece = originBox.Piece;
            originBox.Piece = null;

            if (destinationBox.Piece is King)
            {
                UpdateKingPosition(destinationBox);
            }

            BeginPieceRecapturingIfPawnReachedTheEnd(destinationBox);

            if (!RetakingIsActive)
            {
                NextTurn();
            }

            // TODO: Maybe Handle history here
        }

        // TODO: Refactor arguments
        public void RetakePiece(Position position, Type pieceType, PieceColor pieceColor)
        {
            var piece = (ChessPiece)Activator.CreateInstance(pieceType);

            if (piece == null)
            {
                return;
            }

            piece.Color = pieceColor;
            var entries = CapturedPieceCollection.GetEntry(piece);

            if (entries == 0)
            {
                // TODO: Maybe send notification
                return;
            }

            var box = this[position];
            box.Piece = piece;
            CapturedPieceCollection.DecrementEntry(piece);

            NextTurn();
            RetakingIsActive = false;
        }

        public void NewGame()
        {
            InitializeBoxCollection();
            AddWhitePieces();
            AddBlackPieces();
            InitializeCapturedPieceCollection();
        }

        // TODO: Refactor
        private void BeginPieceRecapturingIfPawnReachedTheEnd(Box destinationBox)
        {
            if (destinationBox.Position.Row == 8 && destinationBox.Piece is Pawn && destinationBox.Piece.Color == PieceColor.White)
            {
                if (CapturedPieceCollection.GetCountTotalCapturedPieces(PieceColor.White, typesToExclude: typeof(Pawn)) > 0)
                {
                    RetakingIsActive = true;
                    RetakingPosition = destinationBox.Position;
                }
            }
            else if (destinationBox.Position.Row == 1 && destinationBox.Piece is Pawn && destinationBox.Piece.Color == PieceColor.Black)
            {
                if (CapturedPieceCollection.GetCountTotalCapturedPieces(PieceColor.Black, typesToExclude: typeof(Pawn)) > 0)
                {
                    RetakingIsActive = true;
                    RetakingPosition = destinationBox.Position;
                }
            }
        }

        private void NextTurn()
        {
            CurrentTurn = CurrentTurn == Turn.White
                ? Turn.Black
                : Turn.White;

            SetChessBoardBoxesAsUnavailable();
        }

        private void UpdateKingPosition(Box destination)
        {
            if (destination.Piece.Color == PieceColor.White)
            {
                PositionWhiteKing = destination.Position;
            }

            if (destination.Piece.Color == PieceColor.Black)
            {
                PositionBlackKing = destination.Position;
            }
        }

        public void SetChessBoardBoxesAsUnavailable()
        {
            for (var row = 1; row <= 8; row++)
            {
                for (var column = 1; column <= 8; column++)
                {
                    boxes[row, column].Available = false;
                }
            }
        }

        public bool IsCheckmateForProvidedColor(PieceColor providedColor)
        {
            for (var row = 1; row <= 8; row++)
            {
                for (var column = 1; column <= 8; column++)
                {
                    if (boxes[row, column].Piece != null && boxes[row, column].Piece.Color == providedColor)
                    {
                        var location = new Position(row, column);
                        boxes[row, column].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(this, location);

                        if (boxes[row, column].Piece.CanMove)
                        {
                            boxes[row, column].Piece.CanMove = false;

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
            return PieceIsThreatenedByPawns(location)
                   || PieceIsThreatenedByKing(location)
                   || PieceIsThreatenedByKnights(location)
                   || PieceIsThreatenedByRooks(location)
                   || PieceIsThreatenedByBishops(location)
                   || PieceIsThreatenedByQueen(location);
        }

        public bool PieceIsThreatenedByPawns(Position position)
        {
            var pieceColor = this[position].Piece.Color;
            var forwardOffset = GetForwardOffsetForColor(pieceColor);
            var opponentColor = pieceColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            return Utilities.LocationContainsPiece<Pawn>(this[position.Row + forwardOffset, position.Column - 1], opponentColor)
                || Utilities.LocationContainsPiece<Pawn>(this[position.Row + forwardOffset, position.Column + 1], opponentColor);
        }

        public bool PieceIsThreatenedByKing(Position position)
        {
            var pieceColor = this[position].Piece.Color;
            var opponentColor = pieceColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            return Utilities.LocationContainsPiece<King>(this[position.Row + 1, position.Column - 1], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row + 1, position.Column + 1], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row + 1, position.Column], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row, position.Column - 1], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row, position.Column + 1], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row - 1, position.Column - 1], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row - 1, position.Column], opponentColor)
                || Utilities.LocationContainsPiece<King>(this[position.Row - 1, position.Column + 1], opponentColor);
        }

        public bool PieceIsThreatenedByKnights(Position position)
        {
            var pieceColor = this[position].Piece.Color;
            var opponentColor = pieceColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            return Utilities.LocationContainsPiece<Knight>(this[position.Row + 1, position.Column + 2], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row + 1, position.Column - 2], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row + 2, position.Column + 1], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row + 2, position.Column - 1], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row - 1, position.Column + 2], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row - 1, position.Column - 2], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row - 2, position.Column + 1], opponentColor)
                   || Utilities.LocationContainsPiece<Knight>(this[position.Row - 2, position.Column - 1], opponentColor);
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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
            for (var secondaryColumn = position.Column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

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
            for (var secondaryColumn = position.Column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

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
            for (var secondaryRow = position.Row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

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
            for (var secondaryRow = position.Row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
                {
                    continue;
                }

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
            for (var secondaryColumn = position.Column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

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
            for (var secondaryColumn = position.Column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

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
            for (var secondaryRow = position.Row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

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
            for (var secondaryRow = position.Row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

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

        private void InitializeBoxCollection()
        {
            boxes = new Box[10, 10];

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    var position = new Position(row, column);

                    boxes[row, column] = new Box(position);
                    boxes[row, column].BeginnersMode = true;
                }
            }
        }

        private void AddWhitePieces()
        {
            boxes[1, 1].Piece = new Rook(PieceColor.White);
            boxes[1, 2].Piece = new Knight(PieceColor.White);
            boxes[1, 3].Piece = new Bishop(PieceColor.White);
            boxes[1, 4].Piece = new Queen(PieceColor.White);
            boxes[1, 5].Piece = new King(PieceColor.White);
            boxes[1, 6].Piece = new Bishop(PieceColor.White);
            boxes[1, 7].Piece = new Knight(PieceColor.White);
            boxes[1, 8].Piece = new Rook(PieceColor.White);

            for (var column = 1; column < 9; column++)
            {
                boxes[2, column].Piece = new Pawn(PieceColor.White);
            }
        }

        private void AddBlackPieces()
        {
            boxes[8, 1].Piece = new Rook(PieceColor.Black);
            boxes[8, 2].Piece = new Knight(PieceColor.Black);
            boxes[8, 3].Piece = new Bishop(PieceColor.Black);
            boxes[8, 4].Piece = new King(PieceColor.Black);
            boxes[8, 5].Piece = new Queen(PieceColor.Black);
            boxes[8, 6].Piece = new Bishop(PieceColor.Black);
            boxes[8, 7].Piece = new Knight(PieceColor.Black);
            boxes[8, 8].Piece = new Rook(PieceColor.Black);

            for (var column = 1; column < 9; column++)
            {
                boxes[7, column].Piece = new Pawn(PieceColor.Black);
            }
        }

        private void InitializeCapturedPieceCollection()
        {
            CapturedPieceCollection = new CapturedPieceCollection();

            CapturedPieceCollection.AddEntry<Rook>(PieceColor.White);
            CapturedPieceCollection.AddEntry<Knight>(PieceColor.White);
            CapturedPieceCollection.AddEntry<Bishop>(PieceColor.White);
            CapturedPieceCollection.AddEntry<Queen>(PieceColor.White);

            CapturedPieceCollection.AddEntry<Rook>(PieceColor.Black);
            CapturedPieceCollection.AddEntry<Knight>(PieceColor.Black);
            CapturedPieceCollection.AddEntry<Bishop>(PieceColor.Black);
            CapturedPieceCollection.AddEntry<Queen>(PieceColor.Black);
        }

        private int GetForwardOffsetForColor(PieceColor pieceColor)
        {
            switch (pieceColor)
            {
                case PieceColor.White:
                    return 1;
                case PieceColor.Black:
                    return -1;
                default:
                    return 100;
            }
        }
    }
}
