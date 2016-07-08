using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardDataModel.Lib;

namespace CardShuffler.Lib
{
    public class CardShuffler
    {
        const uint c_walkingIncrement = 3;

        IRandomNumberGenerator m_rng;

        public CardShuffler(IRandomNumberGenerator rng)
        {
            m_rng = rng;
        }

        public void Sort(Deck deck, bool acesHigh = true)
        {
            DeckErrorChecking(deck);

            var cards = deck.Cards;
            if (acesHigh)
            {
                cards.Sort(new AcesHighComparer());
            }
            else
            {
                cards.Sort(new AcesLowComparer());
            }
        }

        public void Shuffle(Deck deck)
        {
            DeckErrorChecking(deck);

            var cards = deck.Cards;

            // we don't want to walk our collection of shuffled cards over and over again to see if we've already added a card
            var alreadyShuffled = new bool[Deck.SizeOfDeck];

            var shuffledCards = new List<Card>(cards);
            for (int i = 0; i < Deck.SizeOfDeck; ++i)
            {
                uint randomNumber = m_rng.Next(Deck.SizeOfDeck);
                
                // if we've already used this number, just walk forward (not by 1) until we find a new number
                // this will be faster than looping through random numbers forever
                while (alreadyShuffled[randomNumber] == true)
                {
                    randomNumber = (randomNumber + c_walkingIncrement) % Deck.SizeOfDeck;
                }

                alreadyShuffled[randomNumber] = true;
                cards[i] = shuffledCards[(int)randomNumber];
            }
        }

        private void DeckErrorChecking(Deck deck)
        {
            if (deck == null)
                throw new ArgumentNullException("deck");

            if (deck.Cards == null)
                throw new ArgumentNullException("cards");

            if (!deck.Cards.Any())
                throw new ArgumentException("Cannot shuffle an empty collection of cards.", "cards");

            if (deck.Cards.Count != Deck.SizeOfDeck)
                throw new ArgumentException(string.Format("Must provide a collection of {0} cards.", Deck.SizeOfDeck), "cards");

            if (deck.Cards.Distinct().Count() != deck.Cards.Count)
                throw new ArgumentException(string.Format("Must provide a collection of {0} unique cards.", Deck.SizeOfDeck), "cards");
        }
    }
}
