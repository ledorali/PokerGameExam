using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Tests
{
    [TestClass()]
    public class UnitTestPokerHand
    {
        [TestMethod()]
        public void TestCategoryIsHighCard()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();
            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Ace, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.King, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Queen, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Diamond });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Diamond });


            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.HighCard);

        }

        [TestMethod()]
        public void TestIsCategoryFlush()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.King, Suit = SuitCard.Spades });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.Flush);
        }
        [TestMethod]
        public void TestIsCategoryThreeOfAKind()
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

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.ThreeOfaKind);
        }

        [TestMethod]
        public void TestIsCategoryOnePair()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Five, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Diamond });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Queen, Suit = SuitCard.Spades });



            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.OnePair);
        }

        [TestMethod]
        public void TestIsCategoryTwoPair()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Diamond });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Queen, Suit = SuitCard.Spades });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.TwoPair);
        }
        [TestMethod]
        public void TestIsCategoryFullHouse()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);
            

            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Diamond });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.FullHouse);

        }
        [TestMethod]
        public void TestIsStraight()
        {
            //Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);


            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Ten, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Spades });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Diamond });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.Straight);
        }
        [TestMethod]
        public void TestCategoryIsStraightFlush()
        {
            // Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);


            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Five, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Four, Suit = SuitCard.Clubs });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.StraightFlush);
        }
        [TestMethod]
        public void TestCategoryIsFourOfAKind()
        {
            // Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);


            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Clubs });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Diamond });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.FourOfAKind);

        }
        [TestMethod]
        public void TestCategoryIsRoyalFlush()
        {
            // Arrange
            PlayPokerGame PokerFirstGame = new PlayPokerGame();

            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerFirstGame.AddPlayer(Rodel);


            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Ace, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.King, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Queen, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Heart });
            PokerFirstGame.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Ten, Suit = SuitCard.Heart });

            //Act
            PokerHand pokerHand = Rodel.GetPokerHand();

            //Assert
            Assert.AreEqual(pokerHand.Category, HandCategory.RoyalFlush);
        }
        
    }
  

}

