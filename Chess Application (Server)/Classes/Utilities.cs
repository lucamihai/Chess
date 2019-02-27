using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_Application.Enums;
using Chess_Application.UserControls;

namespace Chess_Application.Classes
{
    static class Utilities
    {
        public static string GetReversedString(string stringToBeReversed)
        {
            char[] stringCharacters = stringToBeReversed.ToCharArray();
            Array.Reverse(stringCharacters);
            return new string(stringCharacters);
        }

        public static bool LocationContainsPiece<TYPE>(Box location, PieceColor color = 0) where TYPE : ChessPiece
        {
            if (location != null)
            {
                ChessPiece piece = location.Piece;
                if (piece != null)
                {
                    if (piece is TYPE)
                    {
                        if (piece.Color == color || color == 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
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
