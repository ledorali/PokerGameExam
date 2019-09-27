using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameExam
{
   public static  class GeneratedGame
    {
        public static void PlayAutomatedGame()
        {
            //Create object for the first game
            PlayPokerGame GameOne = new PlayPokerGame();

            //Create object players
            PokerPlayer Rodel = new PokerPlayer("Rodel");
            PokerPlayer Jeryl = new PokerPlayer("Jeryl");
            PokerPlayer Adrian = new PokerPlayer("Adrian");

            //Added players to the first poker game object
            GameOne.AddPlayer(Rodel);
            GameOne.AddPlayer(Adrian);
            GameOne.AddPlayer(Jeryl);

            //Assign cards to the players using poker game object
            GameOne.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Clubs });
            GameOne.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Heart });
            GameOne.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            GameOne.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Heart });
            GameOne.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.King, Suit = SuitCard.Diamond });

            GameOne.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Five, Suit = SuitCard.Clubs });
            GameOne.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Diamond });
            GameOne.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Heart });
            GameOne.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Nine, Suit = SuitCard.Spades });
            GameOne.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Queen, Suit = SuitCard.Spades });

            GameOne.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Two, Suit = SuitCard.Heart });
            GameOne.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Two, Suit = SuitCard.Clubs });
            GameOne.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Five, Suit = SuitCard.Spades });
            GameOne.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Ten, Suit = SuitCard.Clubs });
            GameOne.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Ace, Suit = SuitCard.Heart });

            //Evaluate and get the second winner
            PokerHand firstWinner = GameOne.GetWinner();

            Console.WriteLine("Game one winner is is: {0} using {1}", firstWinner.Name, firstWinner.Category.ToString());

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press any key to proceed for game two");
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();

            //Create object for the first game            
            PlayPokerGame GameTwo = new PlayPokerGame();

            //Used the same object for the player and cleared the cards for the new round
            Rodel.ClearCards();
            Adrian.ClearCards();
            Jeryl.ClearCards();

            //Added players to the second poker game object
            GameTwo.AddPlayer(Rodel);
            GameTwo.AddPlayer(Jeryl);
            GameTwo.AddPlayer(Adrian);

            //Assign cards to the players using poker game object
            GameTwo.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Heart });
            GameTwo.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Six, Suit = SuitCard.Heart });
            GameTwo.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Heart });
            GameTwo.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.Jack, Suit = SuitCard.Heart });
            GameTwo.GivePlayingCards(Rodel, new PlayingCard { Rank = RankType.King, Suit = SuitCard.Heart });

            GameTwo.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Clubs });
            GameTwo.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Diamond });
            GameTwo.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Three, Suit = SuitCard.Spades });
            GameTwo.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Eight, Suit = SuitCard.Clubs });
            GameTwo.GivePlayingCards(Jeryl, new PlayingCard { Rank = RankType.Ten, Suit = SuitCard.Diamond });

            GameTwo.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Two, Suit = SuitCard.Heart });
            GameTwo.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Five, Suit = SuitCard.Clubs });
            GameTwo.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Seven, Suit = SuitCard.Spades });
            GameTwo.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Ten, Suit = SuitCard.Clubs });
            GameTwo.GivePlayingCards(Adrian, new PlayingCard { Rank = RankType.Ace, Suit = SuitCard.Heart }); ;

            //Evaluate and get the second winner
            PokerHand secondWinner = GameTwo.GetWinner();

            Console.WriteLine("Game two winner is: {0} using {1}", secondWinner.Name, secondWinner.Category.ToString());

            Console.ReadKey();

        }
    }
}
