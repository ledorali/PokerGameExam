
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameExam
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            List<string> Name = new List<string>();


            PlayPokerGame PokerGameFirst = new PlayPokerGame();

            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine("Please Enter Name of Player Number {0}", i);
                string name = Console.ReadLine();
                Name.Add(name);

            }

            for (int i = 0; i < Name.Count; i++)
            {
                PokerPlayer player = new PokerPlayer(Name[i]);              


                PokerGameFirst.AddPlayer(player);
                Console.WriteLine("");
                Console.WriteLine("Card No {0} for", Name[i]);
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Ranktype: Please Enter Rank Type for  {0} ", Name[i]);
                Console.WriteLine("For Rank Type Please Choose One from the Following List");
                Console.WriteLine("Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten");
                Console.WriteLine("Jack, Queen, King, Ace, None");
                Console.WriteLine("------------------------------------------------------------");
                

                List<int> RankType = new List<int>();
                List<int> SuitsType = new List<int>();

                string valueRank = Console.ReadLine();
                string[] testValueRank = UtilityClass.SplitString(valueRank);


                for (int k = 0; k < testValueRank.Length; k++)
                 UtilityClass.ParseRank(RankType, testValueRank, k);

                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("SuitType: Please Enter Suit Type for: {0}", Name[i]);
                Console.WriteLine("For Suit Type Please Choose One From the Following List");
                Console.WriteLine("Diamond, Heart, Spades, Clubs, None");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("");
                string valueForType = Console.ReadLine();

                string[] SuitTypeValue = UtilityClass.SplitString(valueForType);

               UtilityClass.ParseSuit(SuitsType, SuitTypeValue);

                for (int m = 0; m <  4; m++)
                {
                    int ranktype = RankType[m];
                    int suitType = SuitsType[m];

                    RankType rankForPlayingCard = (RankType)Enum.ToObject(typeof(RankType), ranktype);
                    SuitCard suit = (SuitCard)Enum.ToObject(typeof(SuitCard), suitType);
                    PokerGameFirst.GivePlayingCards(player, new PlayingCard { Rank = rankForPlayingCard, Suit = suit });
                }             
            }
            Console.WriteLine("");
            PokerHand firstWinner = PokerGameFirst.GetWinner();
            Console.WriteLine("Winner for the first game is: {0} using {1}", firstWinner.Name, firstWinner.Category.ToString());
            Console.Read();

        }      

       
    }
}
