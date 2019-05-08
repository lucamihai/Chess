using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common
{
    public class Chessboard
    {
        private Box[,] Boxes;

        public Box this[Point point] => Boxes[point.X, point.Y];
        public Box this[int row, int column] => Boxes[row, column];

        //private Point _PositionWhiteKing = new Point(1, 5);
        //public Point PositionWhiteKing => new Point(_PositionWhiteKing.X, _PositionWhiteKing.Y);

        //private Point _PositionBlackKing = new Point(8, 4);
        //public Point PositionBlackKing => new Point(_PositionBlackKing.X, _PositionBlackKing.Y);

        public Point PositionWhiteKing { get; set; } = new Point(1, 5);
        public Point PositionBlackKing { get; set; } = new Point(8, 4);

        private bool _BeginnersMode = true;
        public bool BeginnersMode
        {
            get => _BeginnersMode;
            set
            {
                _BeginnersMode = value;

                for (int row = 1; row <= 8; row++)
                {
                    for (int column = 1; column <= 8; column++)
                    {
                        Boxes[row, column].BeginnersMode = BeginnersMode;
                    }
                }
            }
        }

        public Chessboard()
        {
            Boxes = new Box[10, 10];

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    var boxName = GenerateBoxNameBasedOnRowAndColumn(row, column);
                    var boxLocation = GenerateBoxLocationBasedOnRowAndColumn(row, column);

                    Boxes[row, column] = new Box(boxName);
                    Boxes[row, column].Location = boxLocation;
                    Boxes[row, column].BeginnersMode = true;
                }
            }

            AddWhitePieces();
            AddBlackPieces();
        }

        private string GenerateBoxNameBasedOnRowAndColumn(int row, int column)
        {
            char rowLetter = (char)('A' + row - 1);
            return $"{rowLetter}{column}";
        }

        private Point GenerateBoxLocationBasedOnRowAndColumn(int row, int column)
        {
            return new Point
            {
                X = (column - 1) * 64,
                Y = (8 - row) * 64
            };
        }

        private void AddWhitePieces()
        {
            Boxes[1, 1].Piece = new Rook(PieceColor.White);
            Boxes[1, 2].Piece = new Knight(PieceColor.White);
            Boxes[1, 3].Piece = new Bishop(PieceColor.White);
            Boxes[1, 4].Piece = new Queen(PieceColor.White);
            Boxes[1, 5].Piece = new King(PieceColor.White);
            Boxes[1, 6].Piece = new Bishop(PieceColor.White);
            Boxes[1, 7].Piece = new Knight(PieceColor.White);
            Boxes[1, 8].Piece = new Rook(PieceColor.White);

            for (int column = 1; column < 9; column++)
            {
                Boxes[2, column].Piece = new Pawn(PieceColor.White);
            }
        }

        private void AddBlackPieces()
        {
            Boxes[8, 1].Piece = new Rook(PieceColor.Black);
            Boxes[8, 2].Piece = new Knight(PieceColor.Black);
            Boxes[8, 3].Piece = new Bishop(PieceColor.Black);
            Boxes[8, 4].Piece = new King(PieceColor.Black);
            Boxes[8, 5].Piece = new Queen(PieceColor.Black);
            Boxes[8, 6].Piece = new Bishop(PieceColor.Black);
            Boxes[8, 7].Piece = new Knight(PieceColor.Black);
            Boxes[8, 8].Piece = new Rook(PieceColor.Black);

            for (int column = 1; column < 9; column++)
            {
                Boxes[7, column].Piece = new Pawn(PieceColor.Black);
            }
        }

        public void ResetChessBoardBoxesColors()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        Boxes[row, column].BoxBackgroundColor = Constants.BoxColorDark;
                    }
                    else
                    {
                        Boxes[row, column].BoxBackgroundColor = Constants.BoxColorLight;
                    }
                }
            }
        }

        public void SetChessBoardBoxesAsUnavailable()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    Boxes[row, column].Available = false;
                }
            }
        }

        public bool IsCheckmateForProvidedColor(PieceColor providedColor)
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    if (Boxes[row, column].Piece != null && Boxes[row, column].Piece.Color == providedColor)
                    {
                        var location = new Point(row, column);
                        var kingPosition = providedColor == PieceColor.White ? PositionWhiteKing : PositionBlackKing;
                        Boxes[row, column].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(this, location, kingPosition);

                        if (Boxes[row, column].Piece.CanMove)
                        {
                            ResetChessBoardBoxesColors();
                            Boxes[row, column].Piece.CanMove = false;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

    }
}
