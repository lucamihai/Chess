using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_Application.Common.ChessPieces;
using Chess_Application.Common.Enums;

namespace Chess_Application.Common.UserControls
{
    public partial class ChessBoard : UserControl
    {
        private Box A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        private Box H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        private Box C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        private Box E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;

        private Box[,] chessBoard { get; set; }

        private Color BoxColorLight { get; } = Color.Silver;
        private Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);

        private bool _BeginnersMode = true;
        public bool BeginnersMode
        {
            get => _BeginnersMode;
            set
            {
                _BeginnersMode = value;
                UpdateBeginnersModeForChessBoardBoxes();
            }
        }

        public ChessBoard()
        {
            InitializeComponent();
            InitializeBoxes();
            InitializeChessBoard();
        }

        private void InitializeBoxes()
        {
            A1 = new Box("A1", new Rook(PieceColor.White));
            A2 = new Box("A2", new Knight(PieceColor.White));
            A3 = new Box("A3", new Bishop(PieceColor.White));
            A4 = new Box("A4", new Queen(PieceColor.White));
            A5 = new Box("A5", new King(PieceColor.White));
            A6 = new Box("A6", new Bishop(PieceColor.White));
            A7 = new Box("A7", new Knight(PieceColor.White));
            A8 = new Box("A8", new Rook(PieceColor.White));

            B1 = new Box("B1", new Pawn(PieceColor.White));
            B2 = new Box("B2", new Pawn(PieceColor.White));
            B3 = new Box("B3", new Pawn(PieceColor.White));
            B4 = new Box("B4", new Pawn(PieceColor.White));
            B5 = new Box("B5", new Pawn(PieceColor.White));
            B6 = new Box("B6", new Pawn(PieceColor.White));
            B7 = new Box("B7", new Pawn(PieceColor.White));
            B8 = new Box("B8", new Pawn(PieceColor.White));

            G1 = new Box("G1", new Pawn(PieceColor.Black));
            G2 = new Box("G2", new Pawn(PieceColor.Black));
            G3 = new Box("G3", new Pawn(PieceColor.Black));
            G4 = new Box("G4", new Pawn(PieceColor.Black));
            G5 = new Box("G5", new Pawn(PieceColor.Black));
            G6 = new Box("G6", new Pawn(PieceColor.Black));
            G7 = new Box("G7", new Pawn(PieceColor.Black));
            G8 = new Box("G8", new Pawn(PieceColor.Black));

            H1 = new Box("H1", new Rook(PieceColor.Black));
            H2 = new Box("H2", new Knight(PieceColor.Black));
            H3 = new Box("H3", new Bishop(PieceColor.Black));
            H4 = new Box("H4", new King(PieceColor.Black));
            H5 = new Box("H5", new Queen(PieceColor.Black));
            H6 = new Box("H6", new Bishop(PieceColor.Black));
            H7 = new Box("H7", new Knight(PieceColor.Black));
            H8 = new Box("H8", new Rook(PieceColor.Black));

            // ------

            C1 = new Box("C1");
            C2 = new Box("C2");
            C3 = new Box("C3");
            C4 = new Box("C4");
            C5 = new Box("C5");
            C6 = new Box("C6");
            C7 = new Box("C7");
            C8 = new Box("C8");

            D1 = new Box("D1");
            D2 = new Box("D2");
            D3 = new Box("D3");
            D4 = new Box("D4");
            D5 = new Box("D5");
            D6 = new Box("D6");
            D7 = new Box("D7");
            D8 = new Box("D8");

            E1 = new Box("E1");
            E2 = new Box("E2");
            E3 = new Box("E3");
            E4 = new Box("E4");
            E5 = new Box("E5");
            E6 = new Box("E6");
            E7 = new Box("E7");
            E8 = new Box("E8");

            F1 = new Box("F1");
            F2 = new Box("F2");
            F3 = new Box("F3");
            F4 = new Box("F4");
            F5 = new Box("F5");
            F6 = new Box("F6");
            F7 = new Box("F7");
            F8 = new Box("F8");

            // ------

            panelChessBoard.Controls.Clear();

            panelChessBoard.Controls.Add(A1);
            panelChessBoard.Controls.Add(A2);
            panelChessBoard.Controls.Add(A3);
            panelChessBoard.Controls.Add(A4);
            panelChessBoard.Controls.Add(A5);
            panelChessBoard.Controls.Add(A6);
            panelChessBoard.Controls.Add(A7);
            panelChessBoard.Controls.Add(A8);

            panelChessBoard.Controls.Add(B1);
            panelChessBoard.Controls.Add(B2);
            panelChessBoard.Controls.Add(B3);
            panelChessBoard.Controls.Add(B4);
            panelChessBoard.Controls.Add(B5);
            panelChessBoard.Controls.Add(B6);
            panelChessBoard.Controls.Add(B7);
            panelChessBoard.Controls.Add(B8);

            panelChessBoard.Controls.Add(C1);
            panelChessBoard.Controls.Add(C2);
            panelChessBoard.Controls.Add(C3);
            panelChessBoard.Controls.Add(C4);
            panelChessBoard.Controls.Add(C5);
            panelChessBoard.Controls.Add(C6);
            panelChessBoard.Controls.Add(C7);
            panelChessBoard.Controls.Add(C8);

            panelChessBoard.Controls.Add(D1);
            panelChessBoard.Controls.Add(D2);
            panelChessBoard.Controls.Add(D3);
            panelChessBoard.Controls.Add(D4);
            panelChessBoard.Controls.Add(D5);
            panelChessBoard.Controls.Add(D6);
            panelChessBoard.Controls.Add(D7);
            panelChessBoard.Controls.Add(D8);

            panelChessBoard.Controls.Add(E1);
            panelChessBoard.Controls.Add(E2);
            panelChessBoard.Controls.Add(E3);
            panelChessBoard.Controls.Add(E4);
            panelChessBoard.Controls.Add(E5);
            panelChessBoard.Controls.Add(E6);
            panelChessBoard.Controls.Add(E7);
            panelChessBoard.Controls.Add(E8);

            panelChessBoard.Controls.Add(F1);
            panelChessBoard.Controls.Add(F2);
            panelChessBoard.Controls.Add(F3);
            panelChessBoard.Controls.Add(F4);
            panelChessBoard.Controls.Add(F5);
            panelChessBoard.Controls.Add(F6);
            panelChessBoard.Controls.Add(F7);
            panelChessBoard.Controls.Add(F8);

            panelChessBoard.Controls.Add(G1);
            panelChessBoard.Controls.Add(G2);
            panelChessBoard.Controls.Add(G3);
            panelChessBoard.Controls.Add(G4);
            panelChessBoard.Controls.Add(G5);
            panelChessBoard.Controls.Add(G6);
            panelChessBoard.Controls.Add(G7);
            panelChessBoard.Controls.Add(G8);

            panelChessBoard.Controls.Add(H1);
            panelChessBoard.Controls.Add(H2);
            panelChessBoard.Controls.Add(H3);
            panelChessBoard.Controls.Add(H4);
            panelChessBoard.Controls.Add(H5);
            panelChessBoard.Controls.Add(H6);
            panelChessBoard.Controls.Add(H7);
            panelChessBoard.Controls.Add(H8);

            // ------

            H1.Location = new Point(0, 0);
            H2.Location = new Point(64, 0);
            H3.Location = new Point(128, 0);
            H4.Location = new Point(192, 0);
            H5.Location = new Point(256, 0);
            H6.Location = new Point(320, 0);
            H7.Location = new Point(384, 0);
            H8.Location = new Point(448, 0);

            G1.Location = new Point(0, 64);
            G2.Location = new Point(64, 64);
            G3.Location = new Point(128, 64);
            G4.Location = new Point(192, 64);
            G5.Location = new Point(256, 64);
            G6.Location = new Point(320, 64);
            G7.Location = new Point(384, 64);
            G8.Location = new Point(448, 64);

            F1.Location = new Point(0, 128);
            F2.Location = new Point(64, 128);
            F3.Location = new Point(128, 128);
            F4.Location = new Point(192, 128);
            F5.Location = new Point(256, 128);
            F6.Location = new Point(320, 128);
            F7.Location = new Point(384, 128);
            F8.Location = new Point(448, 128);

            E1.Location = new Point(0, 192);
            E2.Location = new Point(64, 192);
            E3.Location = new Point(128, 192);
            E4.Location = new Point(192, 192);
            E5.Location = new Point(256, 192);
            E6.Location = new Point(320, 192);
            E7.Location = new Point(384, 192);
            E8.Location = new Point(448, 192);

            D1.Location = new Point(0, 256);
            D2.Location = new Point(64, 256);
            D3.Location = new Point(128, 256);
            D4.Location = new Point(192, 256);
            D5.Location = new Point(256, 256);
            D6.Location = new Point(320, 256);
            D7.Location = new Point(384, 256);
            D8.Location = new Point(448, 256);

            C1.Location = new Point(0, 320);
            C2.Location = new Point(64, 320);
            C3.Location = new Point(128, 320);
            C4.Location = new Point(192, 320);
            C5.Location = new Point(256, 320);
            C6.Location = new Point(320, 320);
            C7.Location = new Point(384, 320);
            C8.Location = new Point(448, 320);

            B1.Location = new Point(0, 384);
            B2.Location = new Point(64, 384);
            B3.Location = new Point(128, 384);
            B4.Location = new Point(192, 384);
            B5.Location = new Point(256, 384);
            B6.Location = new Point(320, 384);
            B7.Location = new Point(384, 384);
            B8.Location = new Point(448, 384);

            A1.Location = new Point(0, 448);
            A2.Location = new Point(64, 448);
            A3.Location = new Point(128, 448);
            A4.Location = new Point(192, 448);
            A5.Location = new Point(256, 448);
            A6.Location = new Point(320, 448);
            A7.Location = new Point(384, 448);
            A8.Location = new Point(448, 448);
        }

        private void InitializeChessBoard()
        {
            chessBoard = new Box[10, 10];

            chessBoard[1, 1] = A1;
            chessBoard[1, 2] = A2;
            chessBoard[1, 3] = A3;
            chessBoard[1, 4] = A4;
            chessBoard[1, 5] = A5;
            chessBoard[1, 6] = A6;
            chessBoard[1, 7] = A7;
            chessBoard[1, 8] = A8;

            chessBoard[2, 1] = B1;
            chessBoard[2, 2] = B2;
            chessBoard[2, 3] = B3;
            chessBoard[2, 4] = B4;
            chessBoard[2, 5] = B5;
            chessBoard[2, 6] = B6;
            chessBoard[2, 7] = B7;
            chessBoard[2, 8] = B8;

            chessBoard[3, 1] = C1;
            chessBoard[3, 2] = C2;
            chessBoard[3, 3] = C3;
            chessBoard[3, 4] = C4;
            chessBoard[3, 5] = C5;
            chessBoard[3, 6] = C6;
            chessBoard[3, 7] = C7;
            chessBoard[3, 8] = C8;

            chessBoard[4, 1] = D1;
            chessBoard[4, 2] = D2;
            chessBoard[4, 3] = D3;
            chessBoard[4, 4] = D4;
            chessBoard[4, 5] = D5;
            chessBoard[4, 6] = D6;
            chessBoard[4, 7] = D7;
            chessBoard[4, 8] = D8;

            chessBoard[5, 1] = E1;
            chessBoard[5, 2] = E2;
            chessBoard[5, 3] = E3;
            chessBoard[5, 4] = E4;
            chessBoard[5, 5] = E5;
            chessBoard[5, 6] = E6;
            chessBoard[5, 7] = E7;
            chessBoard[5, 8] = E8;

            chessBoard[6, 1] = F1;
            chessBoard[6, 2] = F2;
            chessBoard[6, 3] = F3;
            chessBoard[6, 4] = F4;
            chessBoard[6, 5] = F5;
            chessBoard[6, 6] = F6;
            chessBoard[6, 7] = F7;
            chessBoard[6, 8] = F8;

            chessBoard[7, 1] = G1;
            chessBoard[7, 2] = G2;
            chessBoard[7, 3] = G3;
            chessBoard[7, 4] = G4;
            chessBoard[7, 5] = G5;
            chessBoard[7, 6] = G6;
            chessBoard[7, 7] = G7;
            chessBoard[7, 8] = G8;

            chessBoard[8, 1] = H1;
            chessBoard[8, 2] = H2;
            chessBoard[8, 3] = H3;
            chessBoard[8, 4] = H4;
            chessBoard[8, 5] = H5;
            chessBoard[8, 6] = H6;
            chessBoard[8, 7] = H7;
            chessBoard[8, 8] = H8;

            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; row <= 8; row++)
                {
                    chessBoard[row, column].BeginnersMode = BeginnersMode;
                }
            }
        }

        private void UpdateBeginnersModeForChessBoardBoxes()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int column = 1; column <= 8; column++)
                {
                    chessBoard[row, column].BeginnersMode = BeginnersMode;
                }
            }
        }

        private void ResetChessBoardBoxesColors()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        chessBoard[row, column].BoxBackgroundColor = BoxColorDark;
                    }
                    else
                    {
                        chessBoard[row, column].BoxBackgroundColor = BoxColorLight;
                    }
                }
            }
        }
    }
}
