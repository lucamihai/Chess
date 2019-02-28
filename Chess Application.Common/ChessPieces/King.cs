using System.Drawing;
using Chess_Application.Common.Enums;
using Chess_Application.Common.UserControls;

namespace Chess_Application.Common.ChessPieces
{
    public class King : ChessPiece
    {
        public King(PieceColor pieceColor)
        {
            Color = pieceColor;

            if (pieceColor == PieceColor.White)
            {
                Image = Properties.Resources.WhiteKing;
            }
            else
            {
                Image = Properties.Resources.BlackKing;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(Box[,] chessBoard, Point location, Point kingPosition)
        {
            Point newKingPosition;

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].Available = true;
                chessBoard[kingPosition.X, kingPosition.Y].Piece.CanMove = true;
            }
        }

        private bool IsMovePossible(Box[,] chessBoard, Point source, Point destination)
        {
            if (chessBoard[source.X, source.Y] == null || chessBoard[destination.X, destination.Y] == null)
            {
                return false;
            }

            var isPossible = false;;
            var locationKingSource = chessBoard[source.X, source.Y];
            var locationKingDestination = chessBoard[destination.X, destination.Y];
            
            if (locationKingDestination.Piece != null)
            {
                if (locationKingDestination.Piece.Color != locationKingSource.Piece.Color)
                {
                    // Pretend the king was moved to the destination
                    var chessPieceBackup = chessBoard[destination.X, destination.Y].Piece;
                    chessBoard[destination.X, destination.Y].Piece = chessBoard[source.X, source.Y].Piece;
                    chessBoard[source.X, source.Y].Piece = null;

                    if (!IsInCheck(chessBoard, destination.X, destination.Y))
                    {
                        isPossible = true;
                    }

                    // Restore states of the king and of the destination
                    chessBoard[source.X, source.Y].Piece = chessBoard[destination.X, destination.Y].Piece;
                    chessBoard[destination.X, destination.Y].Piece = chessPieceBackup;
                }
            }
            else
            {
                // Pretend the king was moved to the destination
                chessBoard[destination.X, destination.Y].Piece = chessBoard[source.X, source.Y].Piece;
                chessBoard[source.X, source.Y].Piece = null;

                if (!IsInCheck(chessBoard, destination.X, destination.Y))
                {
                    isPossible = true;
                }

                // Restore states of the king and of the destination
                chessBoard[source.X, source.Y].Piece = chessBoard[destination.X, destination.Y].Piece;
                chessBoard[destination.X, destination.Y].Piece = null;
            }

            return isPossible;
        }

        private bool IsInCheck(Box[,] chessBoard, int row, int column)
        {
            var check = false;

            check = IsThreatenedByPawns(chessBoard, row, column);
            if (check) return check;

            check = IsThreatenedByKing(chessBoard, row, column);
            if (check) return check;

            check = IsThreatenedByKnights(chessBoard, row, column);
            if (check) return check;

            check = IsThreatenedByRooks(chessBoard, row, column);
            if (check) return check;

            check = IsThreatenedByBishops(chessBoard, row, column);
            if (check) return check;

            check = IsThreatenedByQueen(chessBoard, row, column);
            if (check) return check;

            return check;
        }
    }
}
