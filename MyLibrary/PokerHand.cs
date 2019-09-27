using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class PokerHand : PokerPlayer
    {
        public Boolean IsRoyalFlush = false;
        public Boolean IsFourOfAKind = false;
        public Boolean IsStraightflush = false;
        public Boolean IsFlush = false;
        public Boolean IsTwoPair = false;
        public Boolean IsPair = false;
        public Boolean IsThreeOfAKind = false;
        public Boolean IsFullHouse = false;
        public Boolean IsStraight = false;
        public SuitCard DominantSuit = SuitCard.None;
        public RankType DominantRank = RankType.None;
        public HandCategory Category;
        public int Score = 0;

        public PokerHand(string name = "")
            : base(name)
        { }

        private void Copy(PokerPlayer player)
        {
            this.Name = player.Name;
            this.CardsOnHand = player.CardsOnHand;
        }

        public void Arrange(PokerPlayer player)
        {
            this.Copy(player);
            if(CheckIsRoyalFlush())
            {
                this.Category = HandCategory.RoyalFlush;
            }
            else if (CheckIsFourOfAKind())
            {
                this.Category = HandCategory.FourOfAKind;
            }
            else if (CheckIsStraightFlush())
            {
                this.Category = HandCategory.StraightFlush;
            }
            else if (CheckIsFullHouse())
            {
                this.Category = HandCategory.FullHouse;
            }
            else if (CheckIsFlush())
            {
                this.Category = HandCategory.Flush;
            }
            else if (CheckIsStraight())
            {
                this.Category = HandCategory.Straight;
            }
            else if (CheckIsThreeOfAKind())
            {
                this.Category = HandCategory.ThreeOfaKind;
            }
            else if (CheckIsTwoPair())
            {
                this.Category = HandCategory.TwoPair;
            }
            else if (CheckIsPair())
            {
                this.Category = HandCategory.OnePair;
            }
            else { this.Category = HandCategory.HighCard; }

            //Get Score to get High Card
            this.Score = this.CardsOnHand.AsEnumerable().Sum(r => (int)r.Rank);
        }

       
        private Boolean CheckIsRoyalFlush()
        {
            var getStraight = from cards in this.CardsOnHand
                              group cards by cards.Rank into cards
                              orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                              select new { Rank = cards.Key, Count = cards.Count() };

            // check if there are aces and kings
            var ace = getStraight.Where(a => a.Rank == RankType.Ace).Any();
            var king = getStraight.Where(k => k.Rank == RankType.King).Any();

            if (CheckIsStraight() && CheckIsFlush() && ace && king)
            {
                this.IsRoyalFlush = true;
                return true;

            }
            else
            {
                return false;
            }

            

        }

        private Boolean CheckIsFullHouse()
        {

            if (CheckIsPair() == true && CheckIsThreeOfAKind() == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private Boolean CheckIsStraightFlush()
        {


            if (CheckIsStraight() == true && CheckIsFlush() == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private Boolean CheckIsStraight()
        {

            var getStraight = from cards in this.CardsOnHand
                              group cards by cards.Rank into cards
                              orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                              select new { Rank = cards.Key, Count = cards.Count() };

            var ordered = getStraight.OrderBy(r => r.Rank).ToArray();
            var straightStart = (int)ordered.First().Rank;
            for (var i = 0; i < ordered.Length; i++)
            {

                if ((int)ordered[i].Rank != straightStart + i)
                {
                    this.IsStraight = false;
                    return false;
                }


            }

            var _rank = getStraight.DefaultIfEmpty().First().Rank;
            this.DominantRank = (RankType)_rank;
            this.IsStraight = true;
            return true;


        }
        private Boolean CheckIsFlush()
        {
            var getFlush = from cards in this.CardsOnHand
                           group cards by cards.Suit into cards
                           orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                           select new { Suit = cards.Key, Count = cards.Count() };


            if (getFlush.Count() == 1)
            {
                var _suit = getFlush.DefaultIfEmpty().First().Suit;

                this.DominantSuit = (SuitCard)_suit;
                this.IsFlush = true;

                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean CheckIsThreeOfAKind()
        {
            var getThreeOfAKind = from cards in this.CardsOnHand
                                  group cards by cards.Rank into cards
                                  where cards.Count() == 3
                                  orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                  select new { Rank = cards.Key, Count = cards.Count() };

            if (getThreeOfAKind.Count() >= 1)
            {
                var _rank = getThreeOfAKind.DefaultIfEmpty().First().Rank;

                this.DominantRank = (RankType)_rank;
                this.IsThreeOfAKind = true;

                return true;
            }
            else
            {
                return false;
            }

        }
        private Boolean CheckIsFourOfAKind()
        {
            var getFourOfAKind = from cards in this.CardsOnHand
                                 group cards by cards.Rank into cards
                                 where cards.Count() == 4
                                 orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                 select new { Rank = cards.Key, Count = cards.Count() };
            if (getFourOfAKind.Count() >= 1)
            {
                var _rank = getFourOfAKind.DefaultIfEmpty().First().Rank;
                this.DominantRank = (RankType)_rank;
                this.IsFourOfAKind = true;
                return true;

            }
            else
            {
                return false;
            }
        }
        private Boolean CheckIsPair()
        {
            //Sort first by Suit to consider in ranking
            var cardsSortedBySuit = this.CardsOnHand.AsEnumerable().OrderBy(s => s.Suit);

            var getPair = from cards in cardsSortedBySuit
                          group cards by cards.Rank into cards
                          where cards.Count() == 2
                          orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                          select new { Rank = cards.Key, Count = cards.Count() };

            if (getPair.Count() >= 1)
            {
                var _rank = getPair.DefaultIfEmpty().First().Rank;

                this.IsPair = true;
                this.DominantRank = (RankType)_rank;

                return true;
            }
            else
            {
                return false;
            }

        }
        private Boolean CheckIsTwoPair()
        {
            //Sort first by Suit to consider in ranking
            var cardsSortedBySuit = this.CardsOnHand.AsEnumerable().OrderBy(s => s.Suit);

            var getTwoPair = from cards in cardsSortedBySuit
                              group cards by cards.Rank into cards
                              where cards.Count() == 2
                              orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                             select new { Rank = cards.Key, Count = cards.Count()};

            if(getTwoPair.Count() >= 2)
            {
                var _rank = getTwoPair.DefaultIfEmpty().First().Rank;
                this.IsTwoPair = true;
                this.DominantRank = (RankType)_rank;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
  }
