﻿using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic
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

        public Position PositionWhiteKing { get; set; }
        public Position PositionBlackKing { get; set; }
        public CapturedPieceCollection CapturedPieceCollection { get; set; }

        public PieceColor CurrentTurn { get; set; }

        public bool RetakingIsActive { get; private set; }
        public Position RetakingPosition { get; private set; }

        public ChessboardClassic()
        {
            InitializeBoxCollection();
            CapturedPieceCollection = new CapturedPieceCollection();

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
        public void RetakePiece(Position position, ChessPiece chessPiece)
        {
            var entries = CapturedPieceCollection.GetEntryCount(chessPiece);

            if (entries == 0)
            {
                // TODO: Maybe send notification
                return;
            }

            var box = this[position];
            box.Piece = chessPiece;
            CapturedPieceCollection.DecrementEntry(chessPiece);

            NextTurn();
            RetakingIsActive = false;
        }

        public void NewGame()
        {
            SetChessboardBoxesAsUnavailable();
            CapturedPieceCollection.Clear();

            ClearPieces();
            AddWhitePieces();
            AddBlackPieces();

            CurrentTurn = PieceColor.White;
            PositionWhiteKing = new Position(1, 5);
            PositionBlackKing = new Position(8, 4);
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
            CurrentTurn = CurrentTurn == PieceColor.White
                ? PieceColor.Black
                : PieceColor.White;

            SetChessboardBoxesAsUnavailable();
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

        public void SetChessboardBoxesAsUnavailable()
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
                            SetChessboardBoxesAsUnavailable();

                            return false;
                        }

                        SetChessboardBoxesAsUnavailable();
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

        public bool PieceIsThreatened(Position position)
        {
            return PieceIsThreatenedByPawns(position)
                   || PieceIsThreatenedByKing(position)
                   || PieceIsThreatenedByKnights(position)
                   || PieceIsThreatenedByRooks(position)
                   || PieceIsThreatenedByBishops(position)
                   || PieceIsThreatenedByQueen(position);
        }

        public bool PieceIsThreatenedByPawns(Position position)
        {
            var pieceColor = this[position].Piece.Color;
            var forwardOffset = GetForwardOffsetForColor(pieceColor);
            var opponentColor = pieceColor == PieceColor.White
                ? PieceColor.Black
                : PieceColor.White;

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
            var opponentColor = GetOpponentPieceColor(this[position].Piece.Color);

            return this.ChessPieceExistsInSouthWest<Bishop>(position, opponentColor)
                   || this.ChessPieceExistsInNorthEast<Bishop>(position, opponentColor)
                   || this.ChessPieceExistsInNorthWest<Bishop>(position, opponentColor)
                   || this.ChessPieceExistsInSouthEast<Bishop>(position, opponentColor);
        }
        
        public bool PieceIsThreatenedByRooks(Position position)
        {
            var opponentColor = GetOpponentPieceColor(this[position].Piece.Color);

            return this.ChessPieceExistsInWest<Rook>(position, opponentColor)
                   || this.ChessPieceExistsInEast<Rook>(position, opponentColor)
                   || this.ChessPieceExistsInSouth<Rook>(position, opponentColor)
                   || this.ChessPieceExistsInNorth<Rook>(position, opponentColor);
        }
        
        public bool PieceIsThreatenedByQueen(Position position)
        {
            var opponentColor = GetOpponentPieceColor(this[position].Piece.Color);

            return this.ChessPieceExistsInSouthWest<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInNorthEast<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInNorthWest<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInSouthEast<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInWest<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInEast<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInSouth<Queen>(position, opponentColor)
                   || this.ChessPieceExistsInNorth<Queen>(position, opponentColor);
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
                }
            }
        }

        private void ClearPieces()
        {
            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    boxes[row, column].Piece = null;
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

        private static int GetForwardOffsetForColor(PieceColor pieceColor)
        {
            return pieceColor == PieceColor.White
                ? 1
                : -1;
        }

        private static PieceColor GetOpponentPieceColor(PieceColor pieceColor)
        {
            return pieceColor == PieceColor.White
                ? PieceColor.Black
                : PieceColor.White;
        }
    }
}
