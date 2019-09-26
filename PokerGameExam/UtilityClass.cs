using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameExam
{
    public abstract class UtilityClass
    {
        public static void ParseSuit(List<int> SuitsType, string[] SuitTypeS)
        {
            for (int l = 0; l < SuitTypeS.Length; l++)
            {
                int suitType = 0;

                switch (SuitTypeS[l])
                {
                    case "Diamond":
                        suitType = 0;
                        break;
                    case "Heart":
                        suitType = 1;
                        break;
                    case "Spades":
                        suitType = 2;
                        break;
                    case "Clubs":
                        suitType = 3;
                        break;
                    case "None":
                        suitType = 0;
                        break;

                }

                SuitsType.Add(suitType);

            }
        }

        public static void ParseRank(List<int> RankType, string[] testValueRank, int k)
        {
            int rankType = 0;
            switch (testValueRank[k])
            {
                case "Two":
                    rankType = 2;
                    break;
                case "Three":
                    rankType = 3;
                    break;
                case "Four":
                    rankType = 4;
                    break;
                case "Five":
                    rankType = 5;
                    break;
                case "Six":
                    rankType = 6;
                    break;
                case "Seven":
                    rankType = 7;
                    break;
                case "Eight":
                    rankType = 8;
                    break;
                case "Nine":
                    rankType = 9;
                    break;
                case "Ten":
                    rankType = 10;
                    break;
                case "Jack":
                    rankType = 11;
                    break;
                case "Queen":
                    rankType = 12;
                    break;
                case "King":
                    rankType = 13;
                    break;
                case "Ace":
                    rankType = 14;
                    break;
                case "None":
                    rankType = 0;
                    break;

            }

            RankType.Add(rankType);
        }
        public static string[] SplitString(string valueRank)
        {
            string[] testValueRank = valueRank.Split(',');

            for (int j = 0; j < testValueRank.Length; j++)
            {
                testValueRank[j] = testValueRank[j].Trim();            }

            return testValueRank;
        }

    }
}
