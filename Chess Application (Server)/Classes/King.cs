using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Chess_Application.Classes;
using Chess_Application.Enums;
using Chess_Application.UserControls;

namespace Chess_Application
{
    public class King : ChessPiece
    {
        public King(PieceColor c)
        {
            Color = c;

            if (c == PieceColor.White)
            {
                Image = Chess_Application.Properties.Resources.WhiteKing;
            }
            else
            {
                Image = Chess_Application.Properties.Resources.BlackKing;
            }
        }

        public override void CheckPossibilities(int i, int j, Box[,] chessBoard)
        {
            Point kingPosition;

            if (MainForm.currentPlayersTurn == Turn.White)
            {
                kingPosition = MainForm.pozitieRegeAlb;
            }
            else
            {
                kingPosition = MainForm.pozitieRegeNegru;
            }
             
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


        /// <summary>
        /// Returns a boolean value representing wether the king can move from source to destination without putting himself in a check.
        /// </summary>
        /// <param name="chessBoard">The chessboard</param>
        /// <param name="source">Current position of the king</param>
        /// <param name="destination">The position of where the king would be moved</param>
        /// <returns>True if the move can be made, false otherwise.</returns>
        public bool IsMovePossible(Box[,] chessBoard, Point source, Point destination)
        {
            if (chessBoard[source.X, source.Y] == null || chessBoard[destination.X, destination.Y] == null)
            {
                return false;
            }

            bool isPossible = false;;

            Box locationKingSource = chessBoard[source.X, source.Y];
            Box locationKingDestination = chessBoard[destination.X, destination.Y];
            
            if (locationKingDestination.Piece != null)
            {
                if (locationKingDestination.Piece.Color != locationKingSource.Piece.Color)
                {
                    // Pretend the king was moved to the destination
                    ChessPiece chessPieceBackup = chessBoard[destination.X, destination.Y].Piece;
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


        /// <summary>
        /// Returns a boolean value representing wether the king is in check by any piece.
        /// </summary>
        /// <param name="chessBoard">The chessboard</param>
        /// <param name="row">Row of the king's position</param>
        /// <param name="column">Column of the king's position</param>
        /// <returns></returns>
        public bool IsInCheck(Box[,] chessBoard, int row, int column)
        {
            bool check = false;

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
