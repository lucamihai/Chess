using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common
{
    public static class Utilities
    { 
        public static bool LocationContainsPiece<TYPE>(Box location, PieceColor color = PieceColor.Undefined) where TYPE : ChessPiece
        {
            if (location != null)
            {
                var piece = location.Piece;
                if (piece != null)
                {
                    if (piece is TYPE)
                    {
                        if (piece.Color == color || color == PieceColor.Undefined)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void RetakeCapturedPiece(CapturedPieceBox capturedPieceBox, Box destination)
        {
            var capturedPieceColor = capturedPieceBox.ChessPiece.Color;
            var retakingWasSuccessful = false;

            if (capturedPieceBox.ChessPiece is Rook)
            {
                destination.Piece = new Rook(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Knight)
            {
                destination.Piece = new Knight(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Bishop)
            {
                destination.Piece = new Bishop(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Queen)
            {
                destination.Piece = new Queen(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (retakingWasSuccessful)
            {
                capturedPieceBox.Count--;
            }
        }

        public static Bitmap ResizeImage(Image image, int desiredWidth, int desiredHeight)
        {
            var destRect = new Rectangle(0, 0, desiredWidth, desiredHeight);
            var destImage = new Bitmap(desiredWidth, desiredHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
