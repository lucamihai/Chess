using System.Drawing;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces.Helpers
{
    public static class AccessibleBoxesUtil
    {
        public static void MarkAccessibleBoxesForWest(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForEast(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForSouth(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForNorth(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForSouthWest(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForNorthEast(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForNorthWest(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkAccessibleBoxesForSouthEast(IChessboard chessBoard, Point startPosition)
        {
            var row = startPosition.X;
            var column = startPosition.Y;

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

        public static void MarkIfAccessible(IChessboard chessBoard, Point startPosition, Point destinationPosition)
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

        private static bool PositionIsOutOfBounds(Point position)
        {
            return position.X > 8
                   || position.X < 1
                   || position.Y > 8
                   || position.Y < 1;
        }
    }
}