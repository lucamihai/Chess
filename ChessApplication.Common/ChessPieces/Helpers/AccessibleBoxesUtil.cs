using System.Collections.Generic;
using System.Drawing;
using ChessApplication.Common.Interfaces;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces.Helpers
{
    public static class AccessibleBoxesUtil
    {
        public static void MarkAccessibleBoxesForWest(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[location.X, location.Y];

            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[row, secondaryColumn];
                var destination = new Point(row, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForEast(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[location.X, location.Y];

            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[row, secondaryColumn];
                var destination = new Point(row, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouth(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[location.X, location.Y];

            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, column];
                var destination = new Point(secondaryRow, column);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorth(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[location.X, location.Y];

            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, column];
                var destination = new Point(secondaryRow, column);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouthWest(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                var destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorthEast(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                var destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForNorthWest(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                var destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }

        public static void MarkAccessibleBoxesForSouthEast(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;
            var startLocation = chessBoard[row, column];

            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                var locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];
                var destination = new Point(secondaryRow, secondaryColumn);

                if (locationToBeInspected.Piece == null)
                {
                    if (!chessBoard.MoveTriggersCheck(location, destination))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!chessBoard.MoveTriggersCheck(location, destination))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }
        }
    }
}