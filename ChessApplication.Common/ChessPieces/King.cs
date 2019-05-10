using System.Drawing;
using ChessApplication.Common.Enums;

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

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard chessBoard, Point location)
        {
            Point newKingPosition;
            var kingPosition = chessBoard[location].Piece.Color == PieceColor.White
                ? chessBoard.PositionWhiteKing
                : chessBoard.PositionBlackKing;

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition].Available = true;
                chessBoard[kingPosition].Piece.CanMove = true;
            }
        }

        private bool IsMovePossible(Chessboard chessBoard, Point source, Point destination)
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

        private bool IsInCheck(Chessboard chessBoard, Point location)
        {
            var check = false;

            check = IsThreatenedByPawns(chessBoard, location);
            if (check) return check;

            check = IsThreatenedByKing(chessBoard, location);
            if (check) return check;

            check = IsThreatenedByKnights(chessBoard, location);
            if (check) return check;

            check = IsThreatenedByRooks(chessBoard, location);
            if (check) return check;

            check = IsThreatenedByBishops(chessBoard, location);
            if (check) return check;

            check = IsThreatenedByQueen(chessBoard, location);
            if (check) return check;

            return check;
        }
    }
}
