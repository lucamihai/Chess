using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Helpers
{
    public static class ChessboardChessPieceFinder 
    {
        public static bool ChessPieceExistsInWest<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (var secondaryColumn = position.Column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[position.Row, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInEast<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (var secondaryColumn = position.Column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[position.Row, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInSouth<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (var secondaryRow = position.Row; secondaryRow >= 1; secondaryRow--)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, position.Column];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInNorth<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (var secondaryRow = position.Row; secondaryRow <= 8; secondaryRow++)
            {
                if (secondaryRow == position.Row)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, position.Column];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInSouthWest<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInNorthEast<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInNorthWest<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }

        public static bool ChessPieceExistsInSouthEast<T>(this IChessboard chessboard, Position position, PieceColor pieceColor) where T : ChessPiece
        {
            for (int secondaryRow = position.Row, secondaryColumn = position.Column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == position.Row && secondaryColumn == position.Column)
                {
                    continue;
                }

                var locationToBeInspected = chessboard[secondaryRow, secondaryColumn];
                var containsPiece = Utilities.LocationContainsPiece<T>(locationToBeInspected, pieceColor);

                if (containsPiece)
                {
                    return true;
                }

                if (locationToBeInspected.Piece != null)
                {
                    break;
                }
            }

            return false;
        }
    }
}