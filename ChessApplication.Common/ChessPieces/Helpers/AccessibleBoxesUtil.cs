using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces.Helpers
{
    public static class AccessibleBoxesUtil
    {
        public static void MarkAccessibleBoxesForWest(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (var secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[row, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForEast(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (var secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[row, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouth(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (var secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (secondaryRow == row)
                {
                    continue;
                }

                var boxToInspect = chessBoard[secondaryRow, column];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorth(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (var secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                var boxToInspect = chessBoard[secondaryRow, column];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouthWest(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[secondaryRow, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorthEast(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[secondaryRow, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorthWest(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[secondaryRow, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouthEast(IChessboard chessBoard, Position startPosition)
        {
            var row = startPosition.Row;
            var column = startPosition.Column;

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                {
                    continue;
                }

                var boxToInspect = chessBoard[secondaryRow, secondaryColumn];

                MarkIfAccessible(chessBoard, startPosition, boxToInspect.Position);

                if (boxToInspect.Piece != null)
                {
                    break;
                }
            }
        }

        public static void MarkIfAccessible(IChessboard chessBoard, Position startPosition, Position destinationPosition)
        {
            if (PositionIsOutOfBounds(destinationPosition))
            {
                return;
            }

            if (chessBoard[destinationPosition].Piece == null)
            {
                if (!chessBoard.MoveTriggersCheck(startPosition, destinationPosition))
                {
                    chessBoard[destinationPosition].Available = true;
                    chessBoard[startPosition].Piece.CanMove = true;
                }
            }
            else
            {
                if (chessBoard[destinationPosition].Piece.Color != chessBoard[startPosition].Piece.Color)
                {
                    if (!chessBoard.MoveTriggersCheck(startPosition, destinationPosition))
                    {
                        chessBoard[destinationPosition].Available = true;
                        chessBoard[startPosition].Piece.CanMove = true;
                    }
                }
            }
        }

        private static bool PositionIsOutOfBounds(Position position)
        {
            return position.Row > 8
                   || position.Row < 1
                   || position.Column > 8
                   || position.Column < 1;
        }
    }
}