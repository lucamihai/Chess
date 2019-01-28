using System.Drawing;
using System.Windows.Forms;
using Chess_Application.Classes;


namespace Chess_Application
{
    public class ChessPiece
    {
        public int culoare = 0;     // 1 - white, 2 - black;
        public int tipPiesa = 0;    // 0 - none, 1 - pawn, 2 - rook, 3 - knight, 4 - bishop, 5 - queen, 6 - king;

        public PictureBox imaginePiesa;
        public PictureBox imagineMicaPiesa;

        public ChessPiece()
        {
            imagineMicaPiesa = new PictureBox();
            imagineMicaPiesa.Image = new Bitmap(25, 25);
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
        public virtual void CheckPossibilities(int row, int column, Box[,] chessBoard)
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
        public bool TriggersCheck(Box[,] chessBoard, int origRow, int origColumn, int destinationRow, int destinationColumn)
        {
            if (chessBoard[origRow, origColumn].Piece.tipPiesa != Constants.PIECE_TYPE_KING)
            {
                Point kingPosition;
                if (MainForm.randMutare == Constants.TURN_WHITE)
                {
                    kingPosition = MainForm.pozitieRegeAlb;
                }
                else
                {
                    kingPosition = MainForm.pozitieRegeNegru;
                }


                // Back up origin and destination data
                int tempOrigColor = chessBoard[origRow, origColumn].Piece.culoare;
                int tempOrigPiece = chessBoard[origRow, origColumn].Piece.tipPiesa;
                int tempDestColor = chessBoard[destinationRow, destinationColumn].Piece.culoare;
                int tempDestPiece = chessBoard[destinationRow, destinationColumn].Piece.tipPiesa;

                // Pretend the move was made
                chessBoard[origRow, origColumn].Piece.culoare = Constants.PIECE_COLOR_NONE;
                chessBoard[origRow, origColumn].Piece.tipPiesa = Constants.PIECE_TYPE_NONE;
                chessBoard[destinationRow, destinationColumn].Piece.culoare = tempOrigColor;
                chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempOrigPiece;

                bool triggersCheck = false;

                triggersCheck = IsThreatenedByPawns(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByKing(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByKnights(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByRooks(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByBishops(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                triggersCheck = IsThreatenedByQueen(chessBoard, kingPosition.X, kingPosition.Y);
                if (triggersCheck)
                {
                    chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                    chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                    chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                    chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;

                    return true;
                }

                chessBoard[origRow, origColumn].Piece.culoare = tempOrigColor;
                chessBoard[origRow, origColumn].Piece.tipPiesa = tempOrigPiece;
                chessBoard[destinationRow, destinationColumn].Piece.culoare = tempDestColor;
                chessBoard[destinationRow, destinationColumn].Piece.tipPiesa = tempDestPiece;
            }

            return false;
        }

        protected bool IsThreatenedByPawns(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            if (pieceCell.Piece.culoare == Constants.PIECE_COLOR_WHITE)
            {
                if (chessBoard[row + 1, column - 1] != null)
                {
                    if (chessBoard[row + 1, column - 1].Piece.culoare == Constants.PIECE_COLOR_BLACK)
                    {
                        if (chessBoard[row + 1, column - 1].Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                        {
                            return true;
                        }
                    }
                }

                if (chessBoard[row + 1, column + 1] != null)
                {
                    if (chessBoard[row + 1, column + 1].Piece.culoare == Constants.PIECE_COLOR_BLACK)
                    {
                        if (chessBoard[row + 1, column + 1].Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                        {
                            return true;
                        }
                    }
                }
            }

            if (pieceCell.Piece.culoare == Constants.PIECE_COLOR_BLACK)
            {
                if (chessBoard[row - 1, column - 1] != null)
                {
                    if (chessBoard[row - 1, column - 1].Piece.culoare == Constants.PIECE_COLOR_WHITE)
                    {
                        if (chessBoard[row - 1, column - 1].Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                        {
                            return true;
                        }
                    }
                }

                if (chessBoard[row - 1, column + 1] != null)
                {
                    if (chessBoard[row - 1, column + 1].Piece.culoare == Constants.PIECE_COLOR_WHITE)
                    {
                        if (chessBoard[row - 1, column + 1].Piece.tipPiesa == Constants.PIECE_TYPE_PAWN)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected bool IsThreatenedByKing(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            if (chessBoard[row + 1, column - 1] != null)
            {
                if (chessBoard[row + 1, column - 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row + 1, column - 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row + 1, column + 1] != null)
            {
                if (chessBoard[row + 1, column + 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row + 1, column + 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row + 1, column] != null)
            {
                if (chessBoard[row + 1, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row + 1, column].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row, column - 1] != null)
            {
                if (chessBoard[row, column - 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, column - 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row, column + 1] != null)
            {
                if (chessBoard[row, column + 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, column + 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row - 1, column - 1] != null)
            {
                if (chessBoard[row - 1, column - 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row - 1, column - 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row - 1, column] != null)
            {
                if (chessBoard[row - 1, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row - 1, column].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            if (chessBoard[row - 1, column + 1] != null)
            {
                if (chessBoard[row - 1, column + 1].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row - 1, column + 1].Piece.tipPiesa == Constants.PIECE_TYPE_KING)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected bool IsThreatenedByKnights(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            if (row < 8 && column < 7)
            {
                if (chessBoard[row + 1, column + 2].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row + 1, column + 2].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 8 && column > 2)
            {
                if (chessBoard[row + 1, column - 2].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row + 1, column - 2].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row < 7 && column < 8)
            {
                if (chessBoard[row + 2, column + 1].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row + 2, column + 1].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row < 7 && column > 1)
            {
                if (chessBoard[row + 2, column - 1].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row + 2, column - 1].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----
            if (row > 1 && column < 7)
            {
                if (chessBoard[row - 1, column + 2].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row - 1, column + 2].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 1 && column > 2)
            {
                if (chessBoard[row - 1, column - 2].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row - 1, column - 2].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            //-----             
            if (row > 2 && column < 8)
            {
                if (chessBoard[row - 2, column + 1].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row - 2, column + 1].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            if (row > 2 && column > 1)
            {
                if (chessBoard[row - 2, column - 1].Piece.culoare != pieceCell.Piece.culoare && chessBoard[row - 2, column - 1].Piece.tipPiesa == 3)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsThreatenedByBishops(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 4)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            return false;
        }

        protected bool IsThreatenedByRooks(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa == Constants.PIECE_TYPE_ROOK)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the piece
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa != 2 && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color was found, further rooks can't threaten the piece
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa == Constants.PIECE_TYPE_ROOK)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the piece
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa != 2 && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color was found, further rooks can't threaten the piece
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa == Constants.PIECE_TYPE_ROOK)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the piece
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa != 2 && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color was found, further rooks can't threaten the piece
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa == Constants.PIECE_TYPE_ROOK)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the piece
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa != 2 && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color was found, further rooks can't threaten the piece
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            return false;
        }

        protected bool IsThreatenedByQueen(Box[,] chessBoard, int row, int column)
        {
            Box pieceCell = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare && chessBoard[secondaryRow, secondaryColumn].Piece.tipPiesa == 5)
                {
                    return true;
                }

                if (chessBoard[secondaryRow, secondaryColumn].Piece.culoare != 0 && chessBoard[secondaryRow, secondaryColumn] != pieceCell)
                {
                    break;
                }
            }

            // -----

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (chessBoard[row, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa == 5)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa != 2 && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (chessBoard[row, secondaryColumn].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa == 5)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[row, secondaryColumn].Piece.tipPiesa != 2 && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[row, secondaryColumn] != pieceCell && chessBoard[row, secondaryColumn].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (chessBoard[secondaryRow, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa == 5)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa != 2 && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (chessBoard[secondaryRow, column].Piece.culoare != pieceCell.Piece.culoare)
                {
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa == 5)
                    {
                        return true;
                    }

                    // If other piece was found, further rooks can't threaten the king
                    if (chessBoard[secondaryRow, column].Piece.tipPiesa != 2 && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                    {
                        break;
                    }
                }

                // If a piece of the same color as the king's was found, further rooks can't threaten the king
                else if (chessBoard[secondaryRow, column] != pieceCell && chessBoard[secondaryRow, column].Piece.tipPiesa != 0)
                {
                    break;
                }
            }

            return false;
        }

    }
}

