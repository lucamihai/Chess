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
    public class ChessPiece
    {
        public int culoare = 1;     // 1 - white, 2 - black;
        public int tipPiesa = 0;    // 0 - none, 1 - pawn, 2 - rook, 3 - knight, 4 - bishop, 5 - queen, 6 - king;

        public PictureBox imaginePiesa;
        public PictureBox imagineMicaPiesa;

        public ChessPiece()
        {

        }

        public ChessPiece(int color, int type, PictureBox pct)
        {
            culoare = color;
            tipPiesa = type;
            imaginePiesa = pct;
        }

        /// <summary>
        /// Determines where the piece can move. If boxes where the piece could be moved are found, will mark them as available with MarkAsAvailable().
        /// </summary>
        /// <param name="row">Row of the piece</param>
        /// <param name="column">Column of the piece</param>
        /// <param name="chessBoard">Chess board (Boxes matrix)</param>
        public virtual void CheckPossibilities(int row, int column, LocatieTabla[,] chessBoard)
        {

        }

        
        /// <summary>
        /// Determines if a move made from origin to destination would trigger a check.
        /// </summary>
        /// <param name="chessBoard">The chessboard</param>
        /// <param name="origRow">Row of the origin</param>
        /// <param name="origColumn">Column of the origin</param>
        /// <param name="destinationRow">Row of the destination</param>
        /// <param name="destinationColumn">Column of the destination</param>
        /// <returns></returns>
        public bool TriggersCheck(LocatieTabla[,] chessBoard, int origRow, int origColumn, int destinationRow, int destinationColumn)
        {
            if (chessBoard[origRow, origColumn].tipPiesa != 6)
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


                // Back up origin and destination data
                int tempOrigColor = chessBoard[origRow, origColumn].culoare;
                int tempOrigPiece = chessBoard[origRow, origColumn].tipPiesa;
                int tempDestColor = chessBoard[destinationRow, destinationColumn].culoare;
                int tempDestPiece = chessBoard[destinationRow, destinationColumn].tipPiesa;

                // Pretend the move was made
                chessBoard[origRow, origColumn].culoare = 0;
                chessBoard[origRow, origColumn].tipPiesa = 0;
                chessBoard[destinationRow, destinationColumn].culoare = tempOrigColor;
                chessBoard[destinationRow, destinationColumn].tipPiesa = tempOrigPiece;

                bool triggersCheck = false;

                triggersCheck = IsThreatenedByPawns(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByKing(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByKnights(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByRooks(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByBishops(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByQueen(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;

                    return true;
                }

                chessBoard[origRow, origColumn].culoare = tempOrigColor;
                chessBoard[origRow, origColumn].tipPiesa = tempOrigPiece;
                chessBoard[destinationRow, destinationColumn].culoare = tempDestColor;
                chessBoard[destinationRow, destinationColumn].tipPiesa = tempDestPiece;
            }

            return false;
        }

        protected bool IsThreatenedByPawns(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            if (pieceCell.culoare == 1)
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

            if (pieceCell.culoare == 2)
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

        protected bool IsThreatenedByKing(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            if (chessBoard[row + 1, column - 1] != null)
            {
                if (chessBoard[row + 1, column - 1].culoare != pieceCell.culoare && chessBoard[row + 1, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row + 1, column + 1] != null)
            {
                if (chessBoard[row + 1, column + 1].culoare != pieceCell.culoare && chessBoard[row + 1, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row + 1, column] != null)
            {
                if (chessBoard[row + 1, column].culoare != pieceCell.culoare && chessBoard[row + 1, column].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row, column - 1] != null)
            {
                if (chessBoard[row, column - 1].culoare != pieceCell.culoare && chessBoard[row, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row, column + 1] != null)
            {
                if (chessBoard[row, column + 1].culoare != pieceCell.culoare && chessBoard[row, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column - 1] != null)
            {
                if (chessBoard[row - 1, column - 1].culoare != pieceCell.culoare && chessBoard[row - 1, column - 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column] != null)
            {
                if (chessBoard[row - 1, column].culoare != pieceCell.culoare && chessBoard[row - 1, column].tipPiesa == 6)
                {
                    return true;
                }
            }

            if (chessBoard[row - 1, column + 1] != null)
            {
                if (chessBoard[row - 1, column + 1].culoare != pieceCell.culoare && chessBoard[row - 1, column + 1].tipPiesa == 6)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsThreatenedByKnights(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            if (row < 8 && column < 7)
            {
                if (chessBoard[row + 1, column + 2].culoare != pieceCell.culoare && chessBoard[row + 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 8 && column > 2)
            {
                if (chessBoard[row + 1, column - 2].culoare != pieceCell.culoare && chessBoard[row + 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row < 7 && column < 8)
            {
                if (chessBoard[row + 2, column + 1].culoare != pieceCell.culoare && chessBoard[row + 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 7 && column > 1)
            {
                if (chessBoard[row + 2, column - 1].culoare != pieceCell.culoare && chessBoard[row + 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row > 1 && column < 7)
            {
                if (chessBoard[row - 1, column + 2].culoare != pieceCell.culoare && chessBoard[row - 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 1 && column > 2)
            {
                if (chessBoard[row - 1, column - 2].culoare != pieceCell.culoare && chessBoard[row - 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----             
            if (row > 2 && column < 8)
            {
                if (chessBoard[row - 2, column + 1].culoare != pieceCell.culoare && chessBoard[row - 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 2 && column > 1)
            {
                if (chessBoard[row - 2, column - 1].culoare != pieceCell.culoare && chessBoard[row - 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsThreatenedByBishops(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            return false;
        }

        protected bool IsThreatenedByRooks(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn].culoare != pieceCell.culoare)
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
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn].culoare != pieceCell.culoare)
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
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow, column].culoare != pieceCell.culoare)
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
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow, column].culoare != pieceCell.culoare)
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
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            return false;
        }

        protected bool IsThreatenedByQueen(LocatieTabla[,] chessBoard, int row, int column)
        {
            LocatieTabla pieceCell = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].culoare != pieceCell.culoare && chessBoard[secondaryRow, secondaryColumn].tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            // -----

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn].culoare != pieceCell.culoare)
                {
                    if (chessBoard[row, secondaryColumn].tipPiesa == 5)
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
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn].culoare != pieceCell.culoare)
                {
                    if (chessBoard[row, secondaryColumn].tipPiesa == 5)
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
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow, column].culoare != pieceCell.culoare)
                {
                    if (chessBoard[secondaryRow, column].tipPiesa == 5)
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
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow, column].culoare != pieceCell.culoare)
                {
                    if (chessBoard[secondaryRow, column].tipPiesa == 5)
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
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].tipPiesa != 0)
                {
                    break;
                }
            }

            return false;
        }

    }
}

