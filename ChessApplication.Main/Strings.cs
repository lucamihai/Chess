namespace ChessApplication.Main
{
    public static class Strings
    {
        public static string UserRequestsNewGame => "{0} wishes a new game. If you agree, go to File -> New game";
        public static string UserBeginsSelection => "{0} must retake a piece from Spoils o' war\r\n";
        public static string ChatMessage => "{0}: {1}\r\n";
        public static string NewGameHasBegun => "A new game has begun\r\n";

        public static string WhitesTurn => "White's turn";
        public static string BlacksTurn => "Black's turn";

        public static string CheckmateWhite => "Checkmate! Black has won!";
        public static string CheckmateBlack => "Checkmate! White has won!";
    }
}
