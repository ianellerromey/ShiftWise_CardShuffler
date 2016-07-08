using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardDataModel.Lib;

namespace CardShuffler.Lib
{
    class AcesHighComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            var suitVal = (int)x.Suit - (int)y.Suit;
            if (suitVal == 0)
            {
                var rankVal = RankIfAce(x.Rank) - RankIfAce(y.Rank);
                return rankVal;
            }
            else
            {
                return suitVal;
            }
        }

        private int RankIfAce(Card.CardRank rank)
        {
            switch (rank)
            {
                case Card.CardRank.Ace:
                    return (int)Card.CardRank.King + 1;
                default:
                    return (int)rank;
            }
        }
    }
}
