using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;

namespace ChessApplication.Network.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ServerClientCommunicationUnitTests
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
        [Ignore]
        public void TestThatChangeColorsTriggersClientOnChangedColors()
        {
            throw new NotImplementedException("Will implement after event arguments are reworked");

            //var received = false;
            //var receivedOrigin = string.Empty;
            //var receivedDestination = string.Empty;
            //client.OnChangedColors += (origin, destination) =>
            //{
            //    received = true;
            //    receivedOrigin = origin;
            //    receivedDestination = destination;
            //};

            //var originToSend = new Position(2, 3);
            //var destinationToSend = new Position(3, 3);
            //server.ChangeColors(originToSend, destinationToSend);
            //Thread.Sleep(1000);

            //Assert.IsTrue(received);
            //Assert.AreEqual(originToSend, receivedOrigin);
            //Assert.AreEqual(destinationToSend, receivedDestination);
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
            Type receivedChessPieceType = null;
            var receivedChessPieceColor = PieceColor.Undefined;
            client.OnMadeRetakeSelection += (selectionPosition, chessPieceType, chessPieceColor) =>
            {
                received = true;
                receivedPosition = selectionPosition;
                receivedChessPieceType = chessPieceType;
                receivedChessPieceColor = chessPieceColor;
            };

            var selectionPositionToSend = new Position(2, 3);
            var chessPieceToSend = new Rook(PieceColor.Black);
            server.NotifyOfRetakeSelection(selectionPositionToSend, chessPieceToSend);
            Thread.Sleep(1000);

            Assert.IsTrue(received);
            Assert.AreEqual(selectionPositionToSend, receivedPosition);
            Assert.AreEqual(chessPieceToSend.GetType(), receivedChessPieceType);
            Assert.AreEqual(chessPieceToSend.Color, receivedChessPieceColor);
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
