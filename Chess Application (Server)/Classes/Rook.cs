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
    public class Rook : ChessPiece
    {
        public Rook(PieceColor c)
        {
            Color = c;

            if (c == PieceColor.White)
            {
                Image = Chess_Application.Properties.Resources.WhiteRook;
            }
            else
            {
                Image = Chess_Application.Properties.Resources.BlackRook;
            }
        }
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            Box locationToBeInspected;
            Box startLocation = chessBoard[row, column];

            // Check movement to the west
            for (int secondaryColumn = column; secondaryColumn >= 1; secondaryColumn--)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the east
            for (int secondaryColumn = column; secondaryColumn <= 8; secondaryColumn++)
            {
                if (secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[row, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the south
            for (int secondaryRow = row; secondaryRow >= 1; secondaryRow--)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];

                if (locationToBeInspected.Piece == null)
                {
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the north
            for (int secondaryRow = row; secondaryRow <= 8; secondaryRow++)
            {
                if (secondaryRow == row)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, column];

                if (locationToBeInspected.Piece == null)
                {
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
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
