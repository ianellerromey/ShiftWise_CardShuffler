using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardDataModel.Lib;

namespace CardShuffler.Lib
{
    class AcesLowComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            var suitVal = (int)x.Suit - (int)y.Suit;
            if (suitVal == 0)
            {
                var rankVal = (int)x.Rank - (int)y.Rank;
                return rankVal;
            }
            else
            {
                return suitVal;
            }
        }
    }
}
