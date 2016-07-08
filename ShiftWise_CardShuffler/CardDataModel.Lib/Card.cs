using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDataModel.Lib
{
    public class Card
    {
        public enum CardSuit
        {
            Spade,
            Heart,
            Diamond,
            Club
        }

        public enum CardRank
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public CardSuit Suit
        {
            get;
            private set;
        }

        public CardRank Rank
        {
            get;
            private set;
        }

        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public Card(Card card)
        {
            Suit = card.Suit;
            Rank = card.Rank;
        }

        public static bool operator ==(Card x, Card y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if ((object)x == null || (object)y == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(Card x, Card y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var card = obj as Card;
            if ((object)card == null)
            {
                return false;
            }

            return Suit == card.Suit && Rank == card.Rank;
        }

        public bool Equals(Card card)
        {
            if ((object)card == null)
            {
                return false;
            }

            return Suit == card.Suit && Rank == card.Rank;
        }

        public override int GetHashCode()
        {
            return (int)Suit ^ (int)Rank;
        }
    }
}
