using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using PokerGameExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameExam.Tests
{
    [TestClass()]
    public class UnitTestGameProper
    {
        [TestMethod()]
        public void TestIsDuplicateCard()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();
            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Diamond });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Diamond });

            //Act
            try
            {
                PokerHand pokerHand = PokerFirstGame.GetWinner();
            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "Duplicate card(s) found");
                return;
            }

            Assert.Fail("No exception was thrown.");

        }
        [TestMethod]
        public void TestIsDuplicatePlayer()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Batman = new PokerPlayer("Batman");
            PokerPlayer Robin = new PokerPlayer("Batman");

            //Act
            try
            {
                PokerFirstGame.AddPlayer(Batman);
                PokerFirstGame.AddPlayer(Robin);
            }
            catch (Exception ex)
            {
                //Assert            
                StringAssert.Contains(ex.Message.ToString(), "Player name already exists");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }


    }
}