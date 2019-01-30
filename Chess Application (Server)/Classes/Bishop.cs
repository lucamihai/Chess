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
    public class Bishop : ChessPiece
    {
        public Bishop(int c, PictureBox p, PictureBox pm)
        {
            Color = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
        }

        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            Box startLocation = chessBoard[row, column];
            Box locationToBeInspected;

            // Check movement to the south - west
            for (int secondaryRow = row, secondaryColumn = column; secondaryRow >= 1 && secondaryColumn >= 1; secondaryRow--, secondaryColumn--)
            {
                if (secondaryRow == row && secondaryColumn == column)
                    continue;

                locationToBeInspected = chessBoard[secondaryRow, secondaryColumn];

                if (locationToBeInspected.Piece == null)
                {
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                    if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                    {
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }

                if (locationToBeInspected.Piece != null)
                {
                    if (locationToBeInspected.Piece.Color != startLocation.Piece.Color)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
                        }
                    }

                    break;
                }
            }
        }
    }
}
