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
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor pieceColor)
        {
            Color = pieceColor;

            if (pieceColor == PieceColor.White)
            {
                Image = Chess_Application.Properties.Resources.WhiteBishop;
            }
            else
            {
                Image = Chess_Application.Properties.Resources.BlackBishop;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(int row, int column, Box[,] chessBoard)
        {
            var startLocation = chessBoard[row, column];
            Box locationToBeInspected;

            // Check movement to the south - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the north - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn <= 8; secondaryRow++, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the north - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow <= 8 && secondaryColumn >= 1; secondaryRow++, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.Available = true;
                            startLocation.Piece.CanMove = true;
                        }
                    }

                    break;
                }
            }

            // Check movement to the south - east
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn <= 8; secondaryRow--, secondaryColumn++)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.Available = true;
                        startLocation.Piece.CanMove = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!WillMoveTriggerCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
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
