using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardDataModel.Lib;
using CardShuffler.Lib;

namespace CardShuffler.DevEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var shuffler = new CardShuffler.Lib.CardShuffler(new DefaultRandomNumberGenerator());

            shuffler.Shuffle(deck);
            shuffler.Sort(deck);

            shuffler.Shuffle(deck);
            shuffler.Sort(deck, false);

            shuffler.Shuffle(deck);
        }
    }
}
