using System;
using System.Collections.Generic;
using System.Linq;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common
{
    public class CapturedPieceCollection
    {
        private readonly Dictionary<PieceColor, Dictionary<Type, int>> capturedPiecesCount;

        public CapturedPieceCollection()
        {
            capturedPiecesCount = new Dictionary<PieceColor, Dictionary<Type, int>>();
        }

        public void AddEntry<T>(PieceColor pieceColor) where T : ChessPiece, new()
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(pieceColor);
            var type = typeof(T);
            var chessPiece = new T();
            var chessPieceType = chessPiece.GetType();

            if (dictionaryForColor.ContainsKey(chessPieceType))
            {
                dictionaryForColor[chessPieceType]++;
            }

            dictionaryForColor.Add(chessPieceType, 1);
        }

        public void AddEntry<T>(T piece) where T : ChessPiece
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(piece.Color);
            var chessPieceType = piece.GetType();

            if (dictionaryForColor.ContainsKey(chessPieceType))
            {
                dictionaryForColor[chessPieceType]++;
            }
            else
            {
                dictionaryForColor.Add(chessPieceType, 1);
            }
        }

        public int GetEntryCount<T>(PieceColor pieceColor) where T : ChessPiece, new()
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(pieceColor);
            var chessPiece = new T();
            var chessPieceType = chessPiece.GetType();

            return dictionaryForColor.TryGetValue(chessPieceType, out var count)
                ? count
                : 0;
        }

        public int GetEntryCount<T>(T piece) where T : ChessPiece
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(piece.Color);

            return dictionaryForColor.TryGetValue(piece.GetType(), out var count)
                ? count
                : 0;
        }

        public void DecrementEntry<T>(PieceColor pieceColor) where T : ChessPiece, new()
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(pieceColor);
            var chessPieceType = typeof(T);

            if (dictionaryForColor.ContainsKey(chessPieceType))
            {
                dictionaryForColor[chessPieceType]--;
            }
        }

        public void DecrementEntry<T>(T piece) where T : ChessPiece
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(piece.Color);
            var chessPieceType = piece.GetType();

            if (dictionaryForColor.ContainsKey(chessPieceType))
            {
                dictionaryForColor[chessPieceType]--;
            }
        }

        public int GetCountTotalCapturedPieces(PieceColor pieceColor, params Type[] typesToExclude)
        {
            var dictionaryForColor = GetOrCreateDictionaryForColor(pieceColor);

            return dictionaryForColor
                .Where(x => !typesToExclude.Contains(x.Key))
                .Sum(x => x.Value);
        }

        public void Clear()
        {
            capturedPiecesCount.Clear();
        }

        private Dictionary<Type, int> GetOrCreateDictionaryForColor(PieceColor pieceColor)
        {
            if (capturedPiecesCount.TryGetValue(pieceColor, out var dictionaryForColor))
            {
                return dictionaryForColor;
            }

            var newDictionaryForColor = new Dictionary<Type, int>();
            capturedPiecesCount.Add(pieceColor, newDictionaryForColor);

            return newDictionaryForColor;
        }
    }
}