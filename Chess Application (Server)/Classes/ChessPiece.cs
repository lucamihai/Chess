using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class ChessPiece
    {
        public int culoare = 1;     // 1 - white, 2 - black;
        public int tipPiesa = 0;    // 0 - none, 1 - pawn, 2 - rook, 3 - knight, 4 - bishop, 5 - queen, 6 - king;

        public PictureBox imaginePiesa;
        public PictureBox imagineMicaPiesa;

        public ChessPiece()
        {

        }

        public ChessPiece(int color, int type, PictureBox pct)
        {
            culoare = color;
            tipPiesa = type;
            imaginePiesa = pct;
        }

        /// <summary>
        /// Determines where the piece can move. If boxes where the piece could be moved are found, will mark them as available with MarkAsAvailable().
        /// </summary>
        /// <param name="row">Row of the piece</param>
        /// <param name="column">Column of the piece</param>
        /// <param name="chessBoard">Chess board (Boxes matrix)</param>
        public virtual void CheckPossibilities(int row, int column, LocatieTabla[,] chessBoard)
        {

        }


        /// <summary>
        /// Returns a boolean value representing wether the king can move from source to destination without putting himself in a check.
        /// </summary>
        /// <param name="chessBoard">The chessboard</param>
        /// <param name="source">Current position of the king</param>
        /// <param name="destination">The position of where the king would be moved</param>
        /// <returns>True if the move can be made, false otherwise.</returns>
        public bool IsMovePossible(LocatieTabla[,] chessBoard, Point source, Point destination)
        {
            int kingColor = chessBoard[source.X, source.Y].culoare;
            bool isPossible = false;

            if (chessBoard[destination.X, destination.Y] != null)
            {
                chessBoard[destination.X, destination.Y].culoare = 0;
                chessBoard[destination.X, destination.Y].culoare = kingColor;

                if (!IsInCheck(chessBoard, destination.X, destination.Y))
                {
                    chessBoard[destination.X, destination.Y].culoare = kingColor;

                    if (chessBoard[destination.X, destination.Y].culoare != kingColor)
                    {
                        isPossible = true;
                    }
                }
                chessBoard[source.X, source.Y].culoare = kingColor;
                chessBoard[destination.X, destination.Y].culoare = 1;
            }

            return isPossible;
        }

        public void SahDinRege(LocatieTabla[,] chessBoard)
        {
            Point kingPosition = MainForm.pozitieRegeAlb;
            Point newKingPosition;
            int kingColor = chessBoard[kingPosition.X, kingPosition.Y].culoare;

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X + 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y - 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            newKingPosition = new Point(kingPosition.X - 1, kingPosition.Y + 1);
            if (IsMovePossible(chessBoard, kingPosition, newKingPosition))
            {
                chessBoard[newKingPosition.X, newKingPosition.Y].MarkAsAvailable();
                chessBoard[kingPosition.X, kingPosition.Y].poateFaceMiscari = true;
            }

            chessBoard[kingPosition.X, kingPosition.Y].culoare = kingColor;
        }

        public bool IsInCheck(LocatieTabla[,] chessBoard, int row, int column)
        {
            if (chessBoard[row, column].culoare == 1)
            {
                if (chessBoard[row + 1, column - 1] != null)
                {
                    if (chessBoard[row + 1, column - 1].culoare == 2 && (chessBoard[row + 1, column - 1].tipPiesa == 1 || chessBoard[row + 1, column - 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                if (chessBoard[row + 1, column + 1] != null)
                {
                    if (chessBoard[row + 1, column + 1].culoare == 2 && (chessBoard[row + 1, column + 1].tipPiesa == 1 || chessBoard[row + 1, column + 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                //========== rege ========
                if (chessBoard[row + 1, column] != null)
                {
                    if (chessBoard[row + 1, column].culoare == 2 && chessBoard[row + 1, column].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row, column - 1] != null)
                {
                    if (chessBoard[row, column - 1].culoare == 2 && chessBoard[row, column - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row, column + 1] != null)
                {
                    if (chessBoard[row, column + 1].culoare == 2 && chessBoard[row, column + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row - 1, column - 1] != null)
                {
                    if (chessBoard[row - 1, column - 1].culoare == 2 && chessBoard[row - 1, column - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row - 1, column] != null)
                {
                    if (chessBoard[row - 1, column].culoare == 2 && chessBoard[row - 1, column].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row - 1, column + 1] != null)
                {
                    if (chessBoard[row - 1, column + 1].culoare == 2 && chessBoard[row - 1, column + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                //========== cal ========
                if ((row < 8 && column < 7) && chessBoard[row + 1, column + 2].culoare == 2 && chessBoard[row + 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((row < 8 && column > 2) && chessBoard[row + 1, column - 2].culoare == 2 && chessBoard[row + 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((row < 7 && column < 8) && chessBoard[row + 2, column + 1].culoare == 2 && chessBoard[row + 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((row < 7 && column > 1) && chessBoard[row + 2, column - 1].culoare == 2 && chessBoard[row + 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((row > 1 && column < 7) && chessBoard[row - 1, column + 2].culoare == 2 && chessBoard[row - 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((row > 1 && column > 2) && chessBoard[row - 1, column - 2].culoare == 2 && chessBoard[row - 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----             
                if ((row > 2 && column < 8) && chessBoard[row - 2, column + 1].culoare == 2 && chessBoard[row - 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((row > 2 && column > 1) && chessBoard[row - 2, column - 1].culoare == 2 && chessBoard[row - 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
                //========== tura / regina ========
                int ct1 = 0;
                int ct2 = 0;
                int ct3 = 0;
                int ct4 = 0;
                Console.WriteLine("----------------------------------------------------");
                for (int k = column; k >= 1; k--)
                {
                    ct1++;
                    Console.WriteLine("Pe linia " + row + ", coloana" + k + " se afla tipPiesa = " + chessBoard[row, k].tipPiesa + " de culoare " + chessBoard[row, k].culoare);
                    if (chessBoard[row, k].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[row, k].tipPiesa == 2 || chessBoard[row, k].tipPiesa == 5) && chessBoard[row, k].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in stanga");
                            return true;
                        }
                    }
                    if (chessBoard[row, k].culoare == chessBoard[row, column].culoare && chessBoard[row, k] != chessBoard[row, column]) break;
                    if ((chessBoard[row, k].culoare == 2) && chessBoard[row, k].tipPiesa != 2 && chessBoard[row, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = column; k <= 8; k++)
                {
                    ct2++;
                    Console.WriteLine("Pe linia " + row + ", coloana" + k + " se afla tipPiesa = " + chessBoard[row, k].tipPiesa + " de culoare " + chessBoard[row, k].culoare);
                    if (chessBoard[row, k].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[row, k].tipPiesa == 2 || chessBoard[row, k].tipPiesa == 5) && chessBoard[row, k].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in dreapta");
                            return true;
                        }
                    }
                    if (chessBoard[row, k].culoare == chessBoard[row, column].culoare && chessBoard[row, k] != chessBoard[row, column]) break;
                    if ((chessBoard[row, k].culoare == 2) && chessBoard[row, k].tipPiesa != 2 && chessBoard[row, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = row; k >= 1; k--)
                {
                    ct3++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + column + " se afla tipPiesa = " + chessBoard[k, column].tipPiesa + " de culoare " + chessBoard[k, column].culoare);
                    if (chessBoard[k, column].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[k, column].tipPiesa == 2 || chessBoard[k, column].tipPiesa == 5) && chessBoard[k, column].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in jos");
                            return true;
                        }
                    }
                    if (chessBoard[k, column].culoare == chessBoard[row, column].culoare && chessBoard[k, column] != chessBoard[row, column]) break;
                    if ((chessBoard[k, column].culoare == 2) && chessBoard[k, column].tipPiesa != 2 && chessBoard[k, column].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = row; k <= 8; k++)
                {
                    ct4++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + column + " se afla tipPiesa = " + chessBoard[k, column].tipPiesa + " de culoare " + chessBoard[k, column].culoare);
                    if (chessBoard[k, column].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[k, column].tipPiesa == 2 || chessBoard[k, column].tipPiesa == 5) && chessBoard[k, column].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in sus");
                            return true;
                        }
                    }
                    if (chessBoard[k, column].culoare == chessBoard[row, column].culoare && chessBoard[k, column] != chessBoard[row, column]) break;
                    if ((chessBoard[k, column].culoare == 2) && chessBoard[k, column].tipPiesa != 2 && chessBoard[k, column].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                //========== nebun / regina ========
                for (int l = row, c = column; l >= 1 && c >= 1; l--, c--)
                {
                    if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4)) 
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga jos");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l <= 8 && c <= 8; l++, c++)
                {
                    if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta sus");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l <= 8 && c >= 1; l++, c--)
                {
                    if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga sus");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l >= 1 && c <= 8; l--, c++)
                {
                    if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta jos");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                return false;
            }
            else
            {
                //========== pion / rege ========
                if (chessBoard[row - 1, column - 1] != null)
                {
                    if (chessBoard[row - 1, column - 1].culoare == 1 && (chessBoard[row - 1, column - 1].tipPiesa == 1 || chessBoard[row - 1, column - 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                if (chessBoard[row - 1, column + 1] != null)
                {
                    if (chessBoard[row - 1, column + 1].culoare == 1 && (chessBoard[row - 1, column + 1].tipPiesa == 1 || chessBoard[row - 1, column + 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                //========== rege ========
                if (chessBoard[row + 1, column] != null)
                {
                    if (chessBoard[row + 1, column].culoare == 1 && chessBoard[row + 1, column].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row, column - 1] != null)
                {
                    if (chessBoard[row, column - 1].culoare == 1 && chessBoard[row, column - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row, column + 1] != null)
                {
                    if (chessBoard[row, column + 1].culoare == 1 && chessBoard[row, column + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row + 1, column - 1] != null)
                {
                    if (chessBoard[row - 1, column - 1].culoare == 1 && chessBoard[row - 1, column - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row - 1, column] != null)
                {
                    if (chessBoard[row - 1, column].culoare == 1 && chessBoard[row - 1, column].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (chessBoard[row + 1, column + 1] != null)
                {
                    if (chessBoard[row - 1, column + 1].culoare == 1 && chessBoard[row - 1, column + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                //========== cal ========
                if ((row < 8 && column < 7) && chessBoard[row + 1, column + 2].culoare == 1 && chessBoard[row + 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((row < 8 && column > 2) && chessBoard[row + 1, column - 2].culoare == 1 && chessBoard[row + 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((row < 7 && column < 8) && chessBoard[row + 2, column + 1].culoare == 1 && chessBoard[row + 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((row < 7 && column > 1) && chessBoard[row + 2, column - 1].culoare == 1 && chessBoard[row + 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((row > 1 && column < 7) && chessBoard[row - 1, column + 2].culoare == 1 && chessBoard[row - 1, column + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((row > 1 && column > 2) && chessBoard[row - 1, column - 2].culoare == 1 && chessBoard[row - 1, column - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----             
                if ((row > 2 && column < 8) && chessBoard[row - 2, column + 1].culoare == 1 && chessBoard[row - 2, column + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((row > 2 && column > 1) && chessBoard[row - 2, column - 1].culoare == 1 && chessBoard[row - 2, column - 1].tipPiesa == 3)
                {
                    return true;
                }
                //========== tura / regina ========
                int ct1 = 0;
                int ct2 = 0;
                int ct3 = 0;
                int ct4 = 0;
                Console.WriteLine("----------------------------------------------------");
                for (int k = column; k >= 1; k--)
                {
                    ct1++;
                    Console.WriteLine("Pe linia " + row + ", coloana" + k + " se afla tipPiesa = " + chessBoard[row, k].tipPiesa + " de culoare " + chessBoard[row, k].culoare);
                    if (chessBoard[row, k].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[row, k].tipPiesa == 2 || chessBoard[row, k].tipPiesa == 5) && chessBoard[row, k].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in stanga");
                            return true;
                        }
                    }
                    if (chessBoard[row, k].culoare == chessBoard[row, column].culoare && chessBoard[row, k] != chessBoard[row, column]) break;
                    if ((chessBoard[row, k].culoare == 1) && chessBoard[row, k].tipPiesa != 2 && chessBoard[row, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = column; k <= 8; k++)
                {
                    ct2++;
                    Console.WriteLine("Pe linia " + row + ", coloana" + k + " se afla tipPiesa = " + chessBoard[row, k].tipPiesa + " de culoare " + chessBoard[row, k].culoare);
                    if (chessBoard[row, k].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[row, k].tipPiesa == 2 || chessBoard[row, k].tipPiesa == 5) && chessBoard[row, k].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in dreapta");
                            return true;
                        }
                    }
                    if (chessBoard[row, k].culoare == chessBoard[row, column].culoare && chessBoard[row, k] != chessBoard[row, column]) break;
                    if ((chessBoard[row, k].culoare == 1) && chessBoard[row, k].tipPiesa != 2 && chessBoard[row, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = row; k >= 1; k--)
                {
                    ct3++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + column + " se afla tipPiesa = " + chessBoard[k, column].tipPiesa + " de culoare " + chessBoard[k, column].culoare);
                    if (chessBoard[k, column].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[k, column].tipPiesa == 2 || chessBoard[k, column].tipPiesa == 5) && chessBoard[k, column].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in jos");
                            return true;
                        }
                    }
                    if (chessBoard[k, column].culoare == chessBoard[row, column].culoare && chessBoard[k, column] != chessBoard[row, column]) break;
                    if ((chessBoard[k, column].culoare == 1) && chessBoard[k, column].tipPiesa != 2 && chessBoard[k, column].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = row; k <= 8; k++)
                {
                    ct4++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + column + " se afla tipPiesa = " + chessBoard[k, column].tipPiesa + " de culoare " + chessBoard[k, column].culoare);
                    if (chessBoard[k, column].culoare != chessBoard[row, column].culoare)
                    {
                        if ((chessBoard[k, column].tipPiesa == 2 || chessBoard[k, column].tipPiesa == 5) && chessBoard[k, column].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in sus");
                            return true;
                        }
                    }
                    if (chessBoard[k, column].culoare == chessBoard[row, column].culoare && chessBoard[k, column] != chessBoard[row, column]) break;
                    if ((chessBoard[k, column].culoare == 1) && chessBoard[k, column].tipPiesa != 2 && chessBoard[k, column].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                //========== nebun / regina ========
                for (int l = row, c = column; l >= 1 && c >= 1; l--, c--)
                {
                    if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga jos");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l <= 8 && c <= 8; l++, c++)
                {
                    if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta sus");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l <= 8 && c >= 1; l++, c--)
                {
                    if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga sus");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                for (int l = row, c = column; l >= 1 && c <= 8; l--, c++)
                {
                    if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta jos");
                        return true;
                    }
                    if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[row, column]) break;
                }
                return false;
            }
        }

        public bool IsInCheck(LocatieTabla[,] chessBoard, int orig1, int orig2, int curent1, int curent2)
        {
            if (chessBoard[orig1, orig2].tipPiesa != 6)
            {
                if (MainForm.randMutare == 1)
                {
                    int i = MainForm.pozitieRegeAlb.X;//linia rege
                    int j = MainForm.pozitieRegeAlb.Y;//coloana rege
                    Console.WriteLine("Pozititie rege: " + i + " " + j);
                    int tempCuloareOrig = chessBoard[orig1, orig2].culoare;
                    int tempCuloareCurent = chessBoard[curent1, curent2].culoare;
                    chessBoard[orig1, orig2].culoare = 0;
                    chessBoard[curent1, curent2].culoare = 1;
                    //========== pion / rege ========
                    if (chessBoard[i + 1, j - 1] != null)
                    {
                        if (chessBoard[i + 1, j - 1].culoare == 2 && (chessBoard[i + 1, j - 1].tipPiesa == 1 || chessBoard[i + 1, j - 1].tipPiesa == 6))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i + 1, j + 1] != null)
                    {
                        if (chessBoard[i + 1, j + 1].culoare == 2 && (chessBoard[i + 1, j + 1].tipPiesa == 1 || chessBoard[i + 1, j + 1].tipPiesa == 6))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== rege ========
                    if (chessBoard[i + 1, j] != null)
                    {
                        if (chessBoard[i + 1, j].culoare == 2 && chessBoard[i + 1, j].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i, j - 1] != null)
                    {
                        if (chessBoard[i, j - 1].culoare == 2 && chessBoard[i, j - 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i, j + 1] != null)
                    {
                        if (chessBoard[i, j + 1].culoare == 2 && chessBoard[i, j + 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i - 1, j - 1] != null)
                    {
                        if (chessBoard[i - 1, j - 1].culoare == 2 && chessBoard[i - 1, j - 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i - 1, j] != null)
                    {
                        if (chessBoard[i - 1, j].culoare == 2 && chessBoard[i - 1, j].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i - 1, j + 1] != null)
                    {
                        if (chessBoard[i - 1, j + 1].culoare == 2 && chessBoard[i - 1, j + 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== cal ========
                    if ((i < 8 && j < 7) && chessBoard[i + 1, j + 2].culoare == 2 && chessBoard[i + 1, j + 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 8 && j > 2) && chessBoard[i + 1, j - 2].culoare == 2 && chessBoard[i + 1, j - 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i < 7 && j < 8) && chessBoard[i + 2, j + 1].culoare == 2 && chessBoard[i + 2, j + 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 7 && j > 1) && chessBoard[i + 2, j - 1].culoare == 2 && chessBoard[i + 2, j - 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i > 1 && j < 7) && chessBoard[i - 1, j + 2].culoare == 2 && chessBoard[i - 1, j + 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 1 && j > 2) && chessBoard[i - 1, j - 2].culoare == 2 && chessBoard[i - 1, j - 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----             
                    if ((i > 2 && j < 8) && chessBoard[i - 2, j + 1].culoare == 2 && chessBoard[i - 2, j + 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 2 && j > 1) && chessBoard[i - 2, j - 1].culoare == 2 && chessBoard[i - 2, j - 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //========== tura / regina ========
                    int ct1 = 0;
                    int ct2 = 0;
                    int ct3 = 0;
                    int ct4 = 0;
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k >= 1; k--)
                    {
                        ct1++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + chessBoard[i, k].tipPiesa + " de culoare " + chessBoard[i, k].culoare);
                        if (chessBoard[i, k].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[i, k].tipPiesa == 2 || chessBoard[i, k].tipPiesa == 5) && chessBoard[i, k].culoare == 2)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in stanga");
                                return true;
                            }
                        }
                        if (chessBoard[i, k].culoare == chessBoard[i, j].culoare && chessBoard[i, k] != chessBoard[i, j]) break;
                        if ((chessBoard[i, k].culoare == 2) && chessBoard[i, k].tipPiesa != 2 && chessBoard[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k <= 8; k++)
                    {
                        ct2++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + chessBoard[i, k].tipPiesa + " de culoare " + chessBoard[i, k].culoare);
                        if (chessBoard[i, k].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[i, k].tipPiesa == 2 || chessBoard[i, k].tipPiesa == 5) && chessBoard[i, k].culoare == 2)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in dreapta");
                                return true;
                            }
                        }
                        if (chessBoard[i, k].culoare == chessBoard[i, j].culoare && chessBoard[i, k] != chessBoard[i, j]) break;
                        if ((chessBoard[i, k].culoare == 2) && chessBoard[i, k].tipPiesa != 2 && chessBoard[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k >= 1; k--)
                    {
                        ct3++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + chessBoard[k, j].tipPiesa + " de culoare " + chessBoard[k, j].culoare);
                        if (chessBoard[k, j].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[k, j].tipPiesa == 2 || chessBoard[k, j].tipPiesa == 5) && chessBoard[k, j].culoare == 2)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in jos");
                                return true;
                            }
                        }
                        if (chessBoard[k, j].culoare == chessBoard[i, j].culoare && chessBoard[k, j] != chessBoard[i, j]) break;
                        if ((chessBoard[k, j].culoare == 2) && chessBoard[k, j].tipPiesa != 2 && chessBoard[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k <= 8; k++)
                    {
                        ct4++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + chessBoard[k, j].tipPiesa + " de culoare " + chessBoard[k, j].culoare);
                        if (chessBoard[k, j].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[k, j].tipPiesa == 2 || chessBoard[k, j].tipPiesa == 5) && chessBoard[k, j].culoare == 2)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in sus");
                                return true;
                            }
                        }
                        if (chessBoard[k, j].culoare == chessBoard[i, j].culoare && chessBoard[k, j] != chessBoard[i, j]) break;
                        if ((chessBoard[k, j].culoare == 2) && chessBoard[k, j].tipPiesa != 2 && chessBoard[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                    //========== nebun / regina ========
                    for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                    {
                        if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga jos");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                    {
                        if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta sus");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                    {
                        if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4)) 
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga sus de la pozitia "+l+" "+c);
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                    {
                        if (chessBoard[l, c].culoare == 2 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta jos");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    Console.WriteLine("pe pozitia 3,5 se exista: " + chessBoard[3, 5].tipPiesa + " de culoarea: " + chessBoard[3, 5].culoare);
                    chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                    chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                    return false;
                }
                else
                {
                    Console.WriteLine("TBD");
                    int i = MainForm.pozitieRegeNegru.X;
                    int j = MainForm.pozitieRegeNegru.Y;
                    Console.WriteLine("Pozititie rege: " + i + " " + j);
                    int tempCuloareOrig = chessBoard[orig1, orig2].culoare;
                    int tempCuloareCurent = chessBoard[curent1, curent2].culoare;
                    chessBoard[orig1, orig2].culoare = 0;
                    chessBoard[curent1, curent2].culoare = 1;
                    //========== pion / rege ========
                    if (chessBoard[i - 1, j - 1] != null)
                    {
                        if (chessBoard[i - 1, j - 1].culoare == 1 && (chessBoard[i - 1, j - 1].tipPiesa == 1 || chessBoard[i - 1, j - 1].tipPiesa == 6))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i - 1, j + 1] != null)
                    {
                        if (chessBoard[i - 1, j + 1].culoare == 1 && (chessBoard[i - 1, j + 1].tipPiesa == 1 || chessBoard[i - 1, j + 1].tipPiesa == 6))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== rege ========
                    if (chessBoard[i + 1, j] != null)
                    {
                        if (chessBoard[i + 1, j].culoare == 1 && chessBoard[i + 1, j].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i, j - 1] != null)
                    {
                        if (chessBoard[i, j - 1].culoare == 1 && chessBoard[i, j - 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i, j + 1] != null)
                    {
                        if (chessBoard[i, j + 1].culoare == 1 && chessBoard[i, j + 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i + 1, j - 1] != null)
                    {
                        if (chessBoard[i - 1, j - 1].culoare == 1 && chessBoard[i - 1, j - 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i - 1, j] != null)
                    {
                        if (chessBoard[i - 1, j].culoare == 1 && chessBoard[i - 1, j].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (chessBoard[i + 1, j + 1] != null)
                    {
                        if (chessBoard[i - 1, j + 1].culoare == 1 && chessBoard[i - 1, j + 1].tipPiesa == 6)
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== cal ========
                    if ((i < 8 && j < 7) && chessBoard[i + 1, j + 2].culoare == 1 && chessBoard[i + 1, j + 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 8 && j > 2) && chessBoard[i + 1, j - 2].culoare == 1 && chessBoard[i + 1, j - 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i < 7 && j < 8) && chessBoard[i + 2, j + 1].culoare == 1 && chessBoard[i + 2, j + 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 7 && j > 1) && chessBoard[i + 2, j - 1].culoare == 1 && chessBoard[i + 2, j - 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i > 1 && j < 7) && chessBoard[i - 1, j + 2].culoare == 1 && chessBoard[i - 1, j + 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 1 && j > 2) && chessBoard[i - 1, j - 2].culoare == 1 && chessBoard[i - 1, j - 2].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----             
                    if ((i > 2 && j < 8) && chessBoard[i - 2, j + 1].culoare == 1 && chessBoard[i - 2, j + 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 2 && j > 1) && chessBoard[i - 2, j - 1].culoare == 1 && chessBoard[i - 2, j - 1].tipPiesa == 3)
                    {
                        chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                        chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //========== tura / regina ========
                    int ct1 = 0;
                    int ct2 = 0;
                    int ct3 = 0;
                    int ct4 = 0;
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k >= 1; k--)
                    {
                        ct1++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + chessBoard[i, k].tipPiesa + " de culoare " + chessBoard[i, k].culoare);
                        if (chessBoard[i, k].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[i, k].tipPiesa == 2 || chessBoard[i, k].tipPiesa == 5) && chessBoard[i, k].culoare == 1)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in stanga");
                                return true;
                            }
                        }
                        if (chessBoard[i, k].culoare == chessBoard[i, j].culoare && chessBoard[i, k] != chessBoard[i, j]) break;
                        if ((chessBoard[i, k].culoare == 1) && chessBoard[i, k].tipPiesa != 2 && chessBoard[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k <= 8; k++)
                    {
                        ct2++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + chessBoard[i, k].tipPiesa + " de culoare " + chessBoard[i, k].culoare);
                        if (chessBoard[i, k].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[i, k].tipPiesa == 2 || chessBoard[i, k].tipPiesa == 5) && chessBoard[i, k].culoare == 1)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in dreapta");
                                return true;
                            }
                        }
                        if (chessBoard[i, k].culoare == chessBoard[i, j].culoare && chessBoard[i, k] != chessBoard[i, j]) break;
                        if ((chessBoard[i, k].culoare == 1) && chessBoard[i, k].tipPiesa != 2 && chessBoard[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k >= 1; k--)
                    {
                        ct3++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + chessBoard[k, j].tipPiesa + " de culoare " + chessBoard[k, j].culoare);
                        if (chessBoard[k, j].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[k, j].tipPiesa == 2 || chessBoard[k, j].tipPiesa == 5) && chessBoard[k, j].culoare == 1)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in jos");
                                return true;
                            }
                        }
                        if (chessBoard[k, j].culoare == chessBoard[i, j].culoare && chessBoard[k, j] != chessBoard[i, j]) break;
                        if ((chessBoard[k, j].culoare == 1) && chessBoard[k, j].tipPiesa != 2 && chessBoard[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k <= 8; k++)
                    {
                        ct4++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + chessBoard[k, j].tipPiesa + " de culoare " + chessBoard[k, j].culoare);
                        if (chessBoard[k, j].culoare != chessBoard[i, j].culoare)
                        {
                            if ((chessBoard[k, j].tipPiesa == 2 || chessBoard[k, j].tipPiesa == 5) && chessBoard[k, j].culoare == 1)
                            {
                                chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                                chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in sus");
                                return true;
                            }
                        }
                        if (chessBoard[k, j].culoare == chessBoard[i, j].culoare && chessBoard[k, j] != chessBoard[i, j]) break;
                        if ((chessBoard[k, j].culoare == 1) && chessBoard[k, j].tipPiesa != 2 && chessBoard[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                    //========== nebun / regina ========
                    for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                    {
                        if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4)) 
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga jos");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                    {
                        if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta sus");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                    {
                        if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga sus");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                    {
                        if (chessBoard[l, c].culoare == 1 && (chessBoard[l, c].tipPiesa == 5 || chessBoard[l, c].tipPiesa == 4))
                        {
                            chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                            chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta jos");
                            return true;
                        }
                        if (chessBoard[l, c].culoare != 0 && chessBoard[l, c] != chessBoard[i, j]) break;
                    }
                    //Console.WriteLine("pe pozitia 3,5 se exista: " + loc[3, 5].tipPiesa + " de culoarea: " + loc[3, 5].culoare);
                    chessBoard[orig1, orig2].culoare = tempCuloareOrig;
                    chessBoard[curent1, curent2].culoare = tempCuloareCurent;
                    return false;
                }
            }
            return false;
        }

    }
}

