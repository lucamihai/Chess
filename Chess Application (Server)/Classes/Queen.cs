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
    public class Queen : ChessPiece
    {
       
        public Queen(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 5;
        }
        public override void CheckPossibilities(int row, int column, Box[,] chessBoard)
        {
            for (int m = 1; m <= 8; m++)
            {
                for (int n = 1; m <= 8; m++)
                {
                    chessBoard[m, n].MarkAsUnavailable();
                }
            }

            Box locationToBeInspected;
            Box startLocation = chessBoard[row, column];

            #region Rook behaviour

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
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
                    {
                        if (!TriggersCheck(chessBoard, row, column, row, secondaryColumn))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
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
                        locationToBeInspected.MarkAsAvailable();
                        startLocation.poateFaceMiscari = true;
                    }
                }
                else
                {
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
                    {
                        if (!TriggersCheck(chessBoard, row, column, secondaryRow, column))
                        {
                            locationToBeInspected.MarkAsAvailable();
                            startLocation.poateFaceMiscari = true;
                        }
                    }

                    break;
                }
            }

            #endregion

            #region Bishop behaviour

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
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
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
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
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
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
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
                    if (locationToBeInspected.Piece.culoare != startLocation.Piece.culoare)
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

            #endregion
        }
    }
}
