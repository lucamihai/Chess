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



namespace Chess_Application
{
    public class King : ChessPiece
    {
        public King(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 6;
        }

        public override void CheckPossibilities(int i, int j, LocatieTabla[,] chessBoard)
        {
            Point kingPosition;

            if (MainForm.randMutare == 1)
            {
                kingPosition = MainForm.pozitieRegeAlb;
            }
            else
            {
                kingPosition = MainForm.pozitieRegeNegru;
            }
             
            Point newKingPosition;
            int kingColor = chessBoard[kingPosition.X, kingPosition.Y].culoare;

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            chessBoard[kingPosition.X, kingPosition.Y].culoare = kingColor;
        }


        /// <summary>
        /// Returns a boolean value representing wether the king can move from source to destination without putting himself in a check.
        /// </summary>
        /// <param name="chessBoard">The chessboard</param>
        /// <param name="source">Current position of the king</param>
        /// <param name="destination">The position of where the king would be moved</param>
        /// <returns>True if the move can be made, false otherwise.</returns>
        public bool IsMovePossible(LocatieTabla[,] chessBoard, Point source, Point destination)
        {
            if (chessBoard[source.X, source.Y] == null || chessBoard[destination.X, destination.Y] == null)
            {
                return false;
            }

            bool isPossible = false;

            // Remember the colors of the king and of the destination
            int kingColor = chessBoard[source.X, source.Y].culoare;
            int destinationColor = chessBoard[destination.X, destination.Y].culoare;


            // Pretend the king was moved to the destination
            chessBoard[source.X, source.Y].culoare = 0;
            chessBoard[source.X, source.Y].tipPiesa = 0;
            chessBoard[destination.X, destination.Y].culoare = kingColor;

            if (!IsInCheck(chessBoard, destination.X, destination.Y))
            {
                isPossible = (destinationColor != kingColor);
            }

            // Restore states of the king and of the destination
            chessBoard[source.X, source.Y].culoare = kingColor;
            chessBoard[source.X, source.Y].tipPiesa = 6;
            chessBoard[destination.X, destination.Y].culoare = destinationColor;


            return isPossible;
        }

        public bool IsInCheck(LocatieTabla[,] chessBoard, int row, int column)
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

        bool IsThreatenedByPawns(LocatieTabla[,] chessBoard, int row, int column)
        {
            if (culoare == 1)
            {
                if (chessBoard[row + 1, column - 1] != null)
                {
                    if (chessBoard[row + 1, column - 1].culoare == 2 && chessBoard[row + 1, column - 1].tipPiesa == 1)
                    {
                        return true;
                    }
                }

                if (chessBoard[row + 1, column + 1] != null)
                {
                    if (chessBoard[row + 1, column + 1].culoare == 2 && chessBoard[row + 1, column + 1].tipPiesa == 1)
                    {
                        return true;
                    }
                }
            }

            if (culoare == 2)
            {
                if (chessBoard[row - 1, column - 1] != null)
                {
                    if (chessBoard[row - 1, column - 1].culoare == 1 && chessBoard[row - 1, column - 1].tipPiesa == 1)
                    {
                        return true;
                    }
                }

                if (chessBoard[row - 1, column + 1] != null)
                {
                    if (chessBoard[row - 1, column + 1].culoare == 1 && chessBoard[row - 1, column + 1].tipPiesa == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        bool IsThreatenedByKing(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla kingCell = chessBoard[row, column];

            if (chessBoard[row + 1, column - 1] != null)
            {
                if (chessBoard[row + 1, column - 1].culoare != kingCell.culoare && chessBoard[row + 1, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row + 1, column + 1] != null)
            {
                if (chessBoard[row + 1, column + 1].culoare != kingCell.culoare && chessBoard[row + 1, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row + 1, column] != null)
            {
                if (chessBoard[row + 1, column].culoare != kingCell.culoare && chessBoard[row + 1, column].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row, column - 1] != null)
            {
                if (chessBoard[row, column - 1].culoare != kingCell.culoare && chessBoard[row, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row, column + 1] != null)
            {
                if (chessBoard[row, column + 1].culoare != kingCell.culoare && chessBoard[row, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column - 1] != null)
            {
                if (chessBoard[row - 1, column - 1].culoare != kingCell.culoare && chessBoard[row - 1, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column] != null)
            {
                if (chessBoard[row - 1, column].culoare != kingCell.culoare && chessBoard[row - 1, column].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column + 1] != null)
            {
                if (chessBoard[row - 1, column + 1].culoare != kingCell.culoare && chessBoard[row - 1, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            return false;
        }

        bool IsThreatenedByKnights(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla kingCell = chessBoard[row, column];

            if (row < 8 && column < 7)
            {
                if (chessBoard[row + 1, column + 2].culoare != kingCell.culoare && chessBoard[row + 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 8 && column > 2)
            {
                if (chessBoard[row + 1, column - 2].culoare != kingCell.culoare && chessBoard[row + 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row < 7 && column < 8)
            {
                if (chessBoard[row + 2, column + 1].culoare != kingCell.culoare && chessBoard[row + 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 7 && column > 1)
            {
                if (chessBoard[row + 2, column - 1].culoare != kingCell.culoare && chessBoard[row + 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row > 1 && column < 7)
            {
                if (chessBoard[row - 1, column + 2].culoare != kingCell.culoare && chessBoard[row - 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 1 && column > 2)
            {
                if (chessBoard[row - 1, column - 2].culoare != kingCell.culoare && chessBoard[row - 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----             
            if (row > 2 && column < 8)
            {
                if (chessBoard[row - 2, column + 1].culoare != kingCell.culoare && chessBoard[row - 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 2 && column > 1)
            {
                if (chessBoard[row - 2, column - 1].culoare != kingCell.culoare && chessBoard[row - 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            return false;
        }

        bool IsThreatenedByBishops(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla kingCell = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != kingCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != kingCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != kingCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != kingCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != kingCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != kingCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != kingCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != kingCell)
                {
                    break;
                }
            }

            return false;
        }

        bool IsThreatenedByRooks(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla kingCell = chessBoard[row, column];

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn].culoare != kingCell.culoare)
                {
                    if (chessBoard[row, secondaryColumn].tipPiesa == 2)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[row, secondaryColumn].tipPiesa != 2 && chessBoard[row, secondaryColumn].tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[row, secondaryColumn] != kingCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn].culoare != kingCell.culoare)
                {
                    if (chessBoard[row, secondaryColumn].tipPiesa == 2)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[row, secondaryColumn].tipPiesa != 2 && chessBoard[row, secondaryColumn].tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[row, secondaryColumn] != kingCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow, column].culoare != kingCell.culoare)
                {
                    if (chessBoard[secondaryRow, column].tipPiesa == 2)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[secondaryRow, column].tipPiesa != 2 && chessBoard[secondaryRow, column].tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[secondaryRow, column] != kingCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow, column].culoare != kingCell.culoare)
                {
                    if (chessBoard[secondaryRow, column].tipPiesa == 2)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[secondaryRow, column].tipPiesa != 2 && chessBoard[secondaryRow, column].tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[secondaryRow, column] != kingCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            return false;
        }

        bool IsThreatenedByQueen(LocatieTabla[,] chessBoard, int row, int column)
        {
            // TO-DO

            return false;
        }

    }
}
