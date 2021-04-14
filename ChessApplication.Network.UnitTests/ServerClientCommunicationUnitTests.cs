using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using KellermanSoftware.CompareNetObjects;

namespace ChessApplication.Network.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ServerClientCommunicationUnitTests
    {
        private NetworkManagerServer server;
        private NetworkManagerClient client;
        private CompareLogic compareLogic;
        
        [TestInitialize]
        public void Setup()
        {
            server = new NetworkManagerServer();
            client = new NetworkManagerClient("127.0.0.1");

            compareLogic = new CompareLogic();
        }

        [TestMethod]
        public void TestThatNotifyOfMoveTriggersClientOnMadeMove()
        {
            var received = false;
            var receivedOrigin = new Position();
            var receivedDestination = new Position();
            client.OnMadeMove += (origin, destination) =>
            {
                received = true;
                receivedOrigin = origin;
                receivedDestination = destination;
            };

            var originToSend = new Position(2, 3);
            var destinationToSend = new Position(3, 3);
            server.NotifyOfMove(originToSend, destinationToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(originToSend, receivedOrigin);
            Assert.AreEqual(destinationToSend, receivedDestination);
        }

        [TestMethod]
        public void TestThatChangeUsernameTriggersClientOnChangedUsername()
        {
            var received = false;
            var receivedUsername = string.Empty;
            client.OnChangedUsername += username =>
            {
                received = true;
                receivedUsername = username;
            };

            const string usernameToSend = "CoolUsername62";
            server.ChangeUsername(usernameToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(usernameToSend, receivedUsername);
        }

        [TestMethod]
        public void TestThatChangeColorsTriggersClientOnChangedColors()
        {
            var received = false;
            var receivedColor = PieceColor.Undefined;
            client.OnChangedColor += (color) =>
            {
                received = true;
                receivedColor = color;
            };

            const PieceColor colorToSend = PieceColor.Black;
            server.ChangeColor(colorToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(colorToSend, receivedColor);
        }

        [TestMethod]
        public void TestThatRequestNewGameTriggersClientOnRequestedNewGame()
        {
            var received = false;
            client.OnRequestedNewGame += () => received = true;

            server.RequestNewGame();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatIssueNewGameTriggersClientOnIssuedNewGame()
        {
            var received = false;
            client.OnIssuedNewGame += () => received = true;

            server.IssueNewGame();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatBeginRetakeSelectionTriggersClientOnBegunRetakeSelection()
        {
            var received = false;
            client.OnBegunRetakeSelection += () => received = true;

            server.BeginRetakeSelection();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatNotifyOfRetakeSelectionTriggersClientOnMadeRetakeSelection()
        {
            var received = false;
            var receivedPosition = new Position();
            ChessPiece receivedChessPiece = new Rook(PieceColor.Undefined);
            client.OnMadeRetakeSelection += (selectionPosition, chessPiece) =>
            {
                received = true;
                receivedPosition = selectionPosition;
                receivedChessPiece = chessPiece;
            };

            var selectionPositionToSend = new Position(2, 3);
            var chessPieceToSend = new Rook(PieceColor.Black);
            server.NotifyOfRetakeSelection(selectionPositionToSend, chessPieceToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(selectionPositionToSend, receivedPosition);
            Assert.IsTrue(compareLogic.Compare(chessPieceToSend, receivedChessPiece).AreEqual);
        }

        [TestMethod]
        public void TestThatSendChatMessageTriggersClientOnChatMessage()
        {
            var received = false;
            var receivedChatMessage = string.Empty;
            client.OnChatMessage += chatMessage =>
            {
                received = true;
                receivedChatMessage = chatMessage;
            };

            const string chatMessageToSend = "Hello world";
            server.SendChatMessage(chatMessageToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(chatMessageToSend, receivedChatMessage);
        }

        [TestCleanup]
        public void Cleanup()
        {
            client.Stop();
            server.Stop();

            client.Dispose();
            server.Dispose();
        }
    }
}
