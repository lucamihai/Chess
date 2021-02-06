using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class King : ChessPiece
    {
        public King(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = Color == PieceColor.White ? Properties.Resources.WhiteKing : Properties.Resources.BlackKing;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.King;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            var kingPosition = chessBoard[position].Piece.Color == PieceColor.White
                ? chessBoard.PositionWhiteKing
                : chessBoard.PositionBlackKing;

            var positionNorth = new Position(kingPosition.Row, kingPosition.Column + 1);
            var positionSouth = new Position(kingPosition.Row, kingPosition.Column - 1);
            var positionWest = new Position(kingPosition.Row - 1, kingPosition.Column);
            var positionEast = new Position(kingPosition.Row + 1, kingPosition.Column);
            
            var positionNorthWest = new Position(kingPosition.Row - 1, kingPosition.Column + 1);
            var positionNorthEast = new Position(kingPosition.Row + 1, kingPosition.Column + 1);
            var positionSouthWest = new Position(kingPosition.Row - 1, kingPosition.Column - 1);
            var positionSouthEast = new Position(kingPosition.Row + 1, kingPosition.Column - 1);

            MarkPositionIfAllowed(chessBoard, kingPosition, positionNorth);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionSouth);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionWest);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionEast);

            MarkPositionIfAllowed(chessBoard, kingPosition, positionNorthWest);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionNorthEast);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionSouthWest);
            MarkPositionIfAllowed(chessBoard, kingPosition, positionSouthEast);
        }

        private void MarkPositionIfAllowed(IChessboard chessBoard, Position kingPosition, Position newKingPosition)
        {
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }
        }

        private bool IsMovePossible(IChessboard chessBoard, Position source, Position destination)
        {
            if (chessBoard[source] == null || chessBoard[destination] == null)
            {
                return false;
            }

            var isPossible = false;
            var locationKingSource = chessBoard[source];
            var locationKingDestination = chessBoard[destination];
            
            if (locationKingDestination.Piece != null)
            {
                if (locationKingDestination.Piece.Color != locationKingSource.Piece.Color)
                {
                    // Pretend the king was moved to the destination
                    var chessPieceBackup = chessBoard[destination].Piece;
                    chessBoard[destination].Piece = chessBoard[source].Piece;
                    chessBoard[source].Piece = null;

                    if (!IsInCheck(chessBoard, destination))
                    {
                        isPossible = true;
                    }

                    // Restore states of the king and of the destination
                    chessBoard[source].Piece = chessBoard[destination].Piece;
                    chessBoard[destination].Piece = chessPieceBackup;
                }
            }
            else
            {
                // Pretend the king was moved to the destination
                chessBoard[destination].Piece = chessBoard[source].Piece;
                chessBoard[source].Piece = null;

                if (!IsInCheck(chessBoard, destination))
                {
                    isPossible = true;
                }

                // Restore states of the king and of the destination
                chessBoard[source].Piece = chessBoard[destination].Piece;
                chessBoard[destination].Piece = null;
            }

            return isPossible;
        }

        private bool IsInCheck(IChessboard chessBoard, Position location)
        {
            return chessBoard.PieceIsThreatened(location);
        }
    }
}
