using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;

namespace ChessApplication.GUI.Helpers
{
    // TODO: Consider supporting different chessboards' pieces

    [ExcludeFromCodeCoverage]
    public static class ChessPieceImageProvider
    {
        private static readonly Dictionary<Type, Image> BlackChessPieceImages;
        private static readonly Dictionary<Type, Image> WhiteChessPieceImages;

        static ChessPieceImageProvider()
        {
            BlackChessPieceImages = new Dictionary<Type, Image>
            {
                {typeof(Pawn), Properties.Resources.BlackPawn},
                {typeof(Rook), Properties.Resources.BlackRook},
                {typeof(Knight), Properties.Resources.BlackKnight},
                {typeof(Bishop), Properties.Resources.BlackBishop},
                {typeof(Queen), Properties.Resources.BlackQueen},
                {typeof(King), Properties.Resources.BlackKing},
            };

            WhiteChessPieceImages = new Dictionary<Type, Image>
            {
                {typeof(Pawn), Properties.Resources.WhitePawn},
                {typeof(Rook), Properties.Resources.WhiteRook},
                {typeof(Knight), Properties.Resources.WhiteKnight},
                {typeof(Bishop), Properties.Resources.WhiteBishop},
                {typeof(Queen), Properties.Resources.WhiteQueen},
                {typeof(King), Properties.Resources.WhiteKing},
            };
        }

        public static Image GetImageForChessPiece(ChessPiece chessPiece, Size? size = null)
        {
            var image = GetStandardSizedImageForChessPiece(chessPiece);

            return size == null
                ? image
                : image.ResizeImage(size.Value.Width, size.Value.Height);
        }

        private static Image GetStandardSizedImageForChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                return new Bitmap(64, 64);
            }

            switch (chessPiece.Color)
            {
                case PieceColor.Black:
                {
                    return BlackChessPieceImages.TryGetValue(chessPiece.GetType(), out var image)
                        ? image
                        : new Bitmap(64, 64);
                }

                case PieceColor.White:
                {
                    return WhiteChessPieceImages.TryGetValue(chessPiece.GetType(), out var image)
                        ? image
                        : new Bitmap(64, 64);
                }

                default:
                {
                    return new Bitmap(64, 64);
                }
            }
        }

        private static Bitmap ResizeImage(this Image image, int desiredWidth, int desiredHeight)
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