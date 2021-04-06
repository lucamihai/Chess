using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;

namespace ChessApplication.Network.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ClientServerCommunicationUnitTests
    {
        private NetworkManagerServer server;
        private NetworkManagerClient client;
        
        [TestInitialize]
        public void Setup()
        {
            server = new NetworkManagerServer();
            client = new NetworkManagerClient("127.0.0.1");
        }

        [TestMethod]
        public void TestThatNotifyOfMoveTriggersServerOnMadeMove()
        {
            var received = false;
            var receivedOrigin = new Position();
            var receivedDestination = new Position();
            server.OnMadeMove += (origin, destination) =>
            {
                received = true;
                receivedOrigin = origin;
                receivedDestination = destination;
            };

            var originToSend = new Position(2, 3);
            var destinationToSend = new Position(3, 3);
            client.NotifyOfMove(originToSend, destinationToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(originToSend, receivedOrigin);
            Assert.AreEqual(destinationToSend, receivedDestination);
        }

        [TestMethod]
        public void TestThatChangeUsernameTriggersServerOnChangedUsername()
        {
            var received = false;
            var receivedUsername = string.Empty;
            server.OnChangedUsername += username =>
            {
                received = true;
                receivedUsername = username;
            };

            const string usernameToSend = "CoolUsername62";
            client.ChangeUsername(usernameToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(usernameToSend, receivedUsername);
        }

        [TestMethod]
        public void TestThatChangeColorsTriggersServerOnChangedColors()
        {
            var received = false;
            var receivedColor = PieceColor.Undefined;
            server.OnChangedColor += (color) =>
            {
                received = true;
                receivedColor = color;
            };

            const PieceColor colorToSend = PieceColor.Black;
            client.ChangeColor(colorToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(colorToSend, receivedColor);
        }

        [TestMethod]
        public void TestThatRequestNewGameTriggersServerOnRequestedNewGame()
        {
            var received = false;
            server.OnRequestedNewGame += () => received = true;

            client.RequestNewGame();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatIssueNewGameTriggersServerOnIssuedNewGame()
        {
            var received = false;
            server.OnIssuedNewGame += () => received = true;

            client.IssueNewGame();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatBeginRetakeSelectionTriggersServerOnBegunRetakeSelection()
        {
            var received = false;
            server.OnBegunRetakeSelection += () => received = true;

            client.BeginRetakeSelection();
            Thread.Sleep(1000);

            Assert.IsTrue(received);
        }

        [TestMethod]
        public void TestThatNotifyOfRetakeSelectionTriggersServerOnMadeRetakeSelection()
        {
            var received = false;
            var receivedPosition = new Position();
            var receivedChessPieceType = "Rook";
            var receivedChessPieceColor = "Undefined";
            server.OnMadeRetakeSelection += (selectionPosition, chessPieceType, chessPieceColor) =>
            {
                received = true;
                receivedPosition = selectionPosition;
                receivedChessPieceType = chessPieceType;
                receivedChessPieceColor = chessPieceColor;
            };

            var selectionPositionToSend = new Position(2, 3);
            var chessPieceToSend = new Rook(PieceColor.Undefined);
            client.NotifyOfRetakeSelection(selectionPositionToSend, chessPieceToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(selectionPositionToSend, receivedPosition);
            Assert.AreEqual(chessPieceToSend.GetType().Name, receivedChessPieceType);
            Assert.AreEqual(chessPieceToSend.Color.ToString(), receivedChessPieceColor);
        }

        [TestMethod]
        public void TestThatSendChatMessageTriggersServerOnChatMessage()
        {
            var received = false;
            var receivedChatMessage = string.Empty;
            server.OnChatMessage += chatMessage =>
            {
                received = true;
                receivedChatMessage = chatMessage;
            };

            const string chatMessageToSend = "Hello world";
            client.SendChatMessage(chatMessageToSend);
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
