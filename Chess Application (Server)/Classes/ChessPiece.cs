using System;
using System.Drawing;
using System.Windows.Forms;
using Chess_Application.Classes;
using Chess_Application.Enums;

namespace Chess_Application
{
    public class ChessPiece
    {
        // 1 - white, 2 - black;
        public PieceColor Color { get; protected set; } 

        public bool CanMove { get; set; } = false;

        Image _Image;
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;

                if (_Image != null)
                {
                    ImageSmall = Utilities.ResizeImage(_Image, 32, 32);
                }
            }
        }

        public Image ImageSmall { get; protected set; }


        /// <summary>
        /// Determines where the piece can move. If boxes where the piece could be moved are found, will mark them as available with MarkAsAvailable().
        /// </summary>
        /// <param name="row">Row of the piece</param>
        /// <param name="column">Column of the piece</param>
        /// <param name="chessBoard">Chess board (Boxes matrix)</param>
        public virtual void CheckPossibilities(int row, int column, Box[,] chessBoard){ }

        
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
            Point kingPosition;
            if (MainForm.currentPlayersTurn == Turn.White)
            {
                kingPosition = MainForm.pozitieRegeAlb;
            }
            else
            {
                kingPosition = MainForm.pozitieRegeNegru;
            }


            // Back up origin and destination data
            ChessPiece originChessPiece = chessBoard[origRow, origColumn].Piece;
            ChessPiece destinationChessPiece = chessBoard[destinationRow, destinationColumn].Piece;

            // Pretend the move was made
            chessBoard[origRow, origColumn].Piece = null;
            chessBoard[destinationRow, destinationColumn].Piece = originChessPiece;

            bool triggersCheck = false;

            if (!triggersCheck)
                triggersCheck = IsThreatenedByPawns(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKing(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByKnights(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByRooks(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByBishops(chessBoard, kingPosition.X, kingPosition.Y);

            if (!triggersCheck)
                triggersCheck = IsThreatenedByQueen(chessBoard, kingPosition.X, kingPosition.Y);


            chessBoard[origRow, origColumn].Piece = originChessPiece;
            chessBoard[destinationRow, destinationColumn].Piece = destinationChessPiece;

            return triggersCheck;
        }

        protected bool IsThreatenedByPawns(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            bool threatened = false;

            if (currentLocation.Piece.Color == PieceColor.White)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row + 1, column - 1], PieceColor.Black);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row + 1, column + 1], PieceColor.Black);
            }

            if (currentLocation.Piece.Color == PieceColor.Black)
            {
                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row - 1, column - 1], PieceColor.White);

                if (!threatened)
                    threatened = Utilities.LocationContainsPiece<Pawn>(chessBoard[row - 1, column + 1], PieceColor.White);
            }

            return threatened;
        }

        protected bool IsThreatenedByKing(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            
            bool threatened = false;

            bool containsKing = false;
            Box locationToBeInspected;

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }
            
            if (!threatened)
            {
                locationToBeInspected = chessBoard[row + 1, column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column - 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            if (!threatened)
            {
                locationToBeInspected = chessBoard[row - 1, column + 1];
                containsKing = Utilities.LocationContainsPiece<King>(locationToBeInspected);
                threatened = (containsKing && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
            }

            return threatened;
        }

        protected bool IsThreatenedByKnights(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            bool threatened = false;
            bool containsKnight = false;
            Box locationToBeInspected;

            if (!threatened)
            {
                if (row < 8 && column < 7)
                {
                    locationToBeInspected = chessBoard[row + 1, column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row < 8 && column > 2)
                {
                    locationToBeInspected = chessBoard[row + 1, column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (row < 7 && column < 8)
                {
                    locationToBeInspected = chessBoard[row + 2, column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row < 7 && column > 1)
                {
                    locationToBeInspected = chessBoard[row + 2, column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //-----

            if (!threatened)
            {
                if (row > 1 && column < 7)
                {
                    locationToBeInspected = chessBoard[row - 1, column + 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row > 1 && column > 2)
                {
                    locationToBeInspected = chessBoard[row - 1, column - 2];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            //----- 

            if (!threatened)
            {
                if (row > 2 && column < 8)
                {
                    locationToBeInspected = chessBoard[row - 2, column + 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            if (!threatened)
            {
                if (row > 2 && column > 1)
                {
                    locationToBeInspected = chessBoard[row - 2, column - 1];
                    containsKnight = Utilities.LocationContainsPiece<Knight>(locationToBeInspected);
                    threatened = (containsKnight && locationToBeInspected.Piece.Color != currentLocation.Piece.Color);
                }
            }

            return threatened;
        }

        protected bool IsThreatenedByBishops(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            bool threatened = false;
            bool containsBishop = false;
            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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

        protected bool IsThreatenedByRooks(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            bool threatened = false;
            bool containsRook = false;
            Box locationToBeInspected;

            // West
            for (int secondaryColumn = column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
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
            for (int secondaryColumn = column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
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
            for (int secondaryRow = row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
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
            for (int secondaryRow = row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
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

        protected bool IsThreatenedByQueen(Box[,] chessBoard, int row, int column)
        {
            Box currentLocation = chessBoard[row, column];
            bool threatened = false;
            bool containsQueen = false;
            Box locationToBeInspected;

            // South - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1 && !threatened; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8 && !threatened; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1 && !threatened; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8 && !threatened; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
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
            for (int secondaryColumn = column; secondaryColumn >= 1 && !threatened; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
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
            for (int secondaryColumn = column; secondaryColumn <= 8 && !threatened; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];
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
            for (int secondaryRow = row; secondaryRow >= 1 && !threatened; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
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
            for (int secondaryRow = row; secondaryRow <= 8 && !threatened; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];
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
    }
}

