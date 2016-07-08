using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDataModel.Lib
{
    public class Deck
    {
        static public uint SizeOfDeck
        {
            get { return 52; }
        }

        public List<Card> Cards
        {
            get;
            private set;
        }

        public Deck()
        {
            var suits = Enum.GetValues(typeof(Card.CardSuit)).Cast<Card.CardSuit>();
            var ranks = Enum.GetValues(typeof(Card.CardRank)).Cast<Card.CardRank>();
            Cards = Enum.GetValues(typeof(Card.CardSuit)).Cast<Card.CardSuit>().Join(ranks, suit => true, rank => true, (x, y) => new Card(x, y)).ToList();
        }

        public Deck(Deck deck)
        {
            Cards = deck.Cards.Select(card => new Card(card)).ToList();
        }
    }
}
