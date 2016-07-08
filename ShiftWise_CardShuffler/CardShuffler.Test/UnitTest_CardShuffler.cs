using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CardDataModel.Lib;
using CardShuffler.Lib;

namespace CardShuffler.Test
{
    [TestClass]
    public class UnitTest_CardShuffler
    {
        Deck m_deck;
        CardShuffler.Lib.CardShuffler m_shuffler;
        CardShuffler.Lib.IRandomNumberGenerator m_rng;
        Action<Deck> m_sortAcesHigh,
                     m_sortAcesLow,
                     m_shuffle;

        [TestInitialize]
        public void Initialize()
        {
            m_deck = new Deck();

            var random = new Random();
            m_rng =
                new CardShuffler.Lib.Fakes.StubIRandomNumberGenerator()
                {
                    NextUInt32 = (maxRange) => { return (uint)random.Next(0, (int)maxRange); }
                };

            m_shuffler = new Lib.CardShuffler(m_rng);

            m_sortAcesHigh = (deck) => { m_shuffler.Sort(deck); };
            m_sortAcesLow = (deck) => { m_shuffler.Sort(deck, false); };
            m_shuffle = (deck) => { m_shuffler.Shuffle(deck); };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySortedAcesHigh_NullArgumentException()
        {
            m_shuffler.Sort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesHigh_EmptyCollectionArgumentException()
        {
            ExecuteForEmptyCollectionArgumentException(m_sortAcesHigh);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesHigh_TooSmallCollectionArgumentException()
        {
            ExecuteForTooSmallCollectionArgumentException(m_sortAcesHigh);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesHigh_DuplicateCollectionArgumentException()
        {
            ExecuteForDuplicateCollectionArgumentException(m_sortAcesHigh);
        }

        [TestMethod]
        public void VerifySortedAcesHigh_Size()
        {
            ExecuteForSize(m_sortAcesHigh);
        }

        [TestMethod]
        public void VerifySortedAcesHigh_Uniqueness()
        {
            ExecuteForUniqueness(m_sortAcesHigh);
        }

        [TestMethod]
        public void VerifySortedAcesHigh_Order()
        {
            m_shuffler.Shuffle(m_deck);
            m_shuffler.Sort(m_deck);

            int i = 0;
            int numPerSuit = Enum.GetValues(typeof(Card.CardRank)).Length;
            foreach (var suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                for (int j = 0; j < numPerSuit; ++j, ++i)
                {
                    Assert.AreEqual(suit, m_deck.Cards[i].Suit, "Suit sorted out of order when using AcesHighComparer.");
                    switch (j)
                    {
                        case 0: Assert.AreEqual(Card.CardRank.Two, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 1: Assert.AreEqual(Card.CardRank.Three, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 2: Assert.AreEqual(Card.CardRank.Four, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 3: Assert.AreEqual(Card.CardRank.Five, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 4: Assert.AreEqual(Card.CardRank.Six, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 5: Assert.AreEqual(Card.CardRank.Seven, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 6: Assert.AreEqual(Card.CardRank.Eight, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 7: Assert.AreEqual(Card.CardRank.Nine, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 8: Assert.AreEqual(Card.CardRank.Ten, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 9: Assert.AreEqual(Card.CardRank.Jack, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 10: Assert.AreEqual(Card.CardRank.Queen, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 11: Assert.AreEqual(Card.CardRank.King, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 12: Assert.AreEqual(Card.CardRank.Ace, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySortedAcesLow_NullArgumentException()
        {
            m_shuffler.Sort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesLow_EmptyCollectionArgumentException()
        {
            ExecuteForEmptyCollectionArgumentException(m_sortAcesLow);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesLow_TooSmallCollectionArgumentException()
        {
            ExecuteForTooSmallCollectionArgumentException(m_sortAcesLow);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifySortedAcesLow_DuplicateCollectionArgumentException()
        {
            ExecuteForDuplicateCollectionArgumentException(m_sortAcesLow);
        }

        [TestMethod]
        public void VerifySortedAcesLow_Size()
        {
            ExecuteForSize(m_sortAcesLow);
        }

        [TestMethod]
        public void VerifySortedAcesLow_Uniqueness()
        {
            ExecuteForUniqueness(m_sortAcesLow);
        }

        [TestMethod]
        public void VerifySortedAcesLow_Order()
        {
            m_shuffler.Shuffle(m_deck);
            m_shuffler.Sort(m_deck, false);

            int i = 0;
            int numPerSuit = Enum.GetValues(typeof(Card.CardRank)).Length;
            foreach (var suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                for (int j = 0; j < numPerSuit; ++j, ++i)
                {
                    Assert.AreEqual(suit, m_deck.Cards[i].Suit, "Suit sorted out of order when using AcesHighComparer.");
                    switch (j)
                    {
                        case 0: Assert.AreEqual(Card.CardRank.Ace, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 1: Assert.AreEqual(Card.CardRank.Two, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 2: Assert.AreEqual(Card.CardRank.Three, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 3: Assert.AreEqual(Card.CardRank.Four, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 4: Assert.AreEqual(Card.CardRank.Five, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 5: Assert.AreEqual(Card.CardRank.Six, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 6: Assert.AreEqual(Card.CardRank.Seven, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 7: Assert.AreEqual(Card.CardRank.Eight, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 8: Assert.AreEqual(Card.CardRank.Nine, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 9: Assert.AreEqual(Card.CardRank.Ten, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 10: Assert.AreEqual(Card.CardRank.Jack, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 11: Assert.AreEqual(Card.CardRank.Queen, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                        case 12: Assert.AreEqual(Card.CardRank.King, m_deck.Cards[i].Rank, "Rank sorted out of order when using AcesHighComparer."); break;
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyShuffled_NullArgumentException()
        {
            m_shuffler.Shuffle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyShuffled_EmptyCollectionArgumentException()
        {
            ExecuteForEmptyCollectionArgumentException(m_shuffle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyShuffled_TooSmallCollectionArgumentException()
        {
            ExecuteForTooSmallCollectionArgumentException(m_shuffle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyShuffled_DuplicateCollectionArgumentException()
        {
            ExecuteForDuplicateCollectionArgumentException(m_shuffle);
        }

        [TestMethod]
        public void VerifyShuffled_Size()
        {
            ExecuteForSize(m_shuffle);
        }

        [TestMethod]
        public void VerifyShuffled_Uniqueness()
        {
            ExecuteForUniqueness(m_shuffle);
        }

        [TestMethod]
        public void VerifyShuffled_Randomness()
        {
            var previousPositions = new Deck(m_deck);

            for (int i = 0, numberOfPasses = 99999; i < numberOfPasses; ++i)
            {
                int similarityCount = 0;
                int similarityThreshold = m_deck.Cards.Count / 2;

                m_shuffler.Shuffle(m_deck);
                for (int x = 0, y = m_deck.Cards.Count(); x < y; ++x)
                {
                    // check similarity
                    if (previousPositions.Cards[x] == m_deck.Cards[x])
                        ++similarityCount;
                }

                Assert.IsTrue(similarityCount < similarityThreshold, string.Format("Randomness failed on iteration {0} with a similarity count of {1}.", i, similarityCount));
                CollectionAssert.AreNotEqual(previousPositions.Cards, m_deck.Cards);
                CollectionAssert.AreEquivalent(previousPositions.Cards, m_deck.Cards);

                previousPositions = new Deck(m_deck);
            }
        }

        private void ExecuteForEmptyCollectionArgumentException(Action<Deck> action)
        {
            m_deck.Cards.Clear();
            action(m_deck);
        }

        private void ExecuteForTooSmallCollectionArgumentException(Action<Deck> action)
        {
            m_deck.Cards.RemoveRange(0, 10);
            action(m_deck);
        }

        private void ExecuteForDuplicateCollectionArgumentException(Action<Deck> action)
        {
            var secondDeck = new Deck();
            m_deck.Cards.AddRange(secondDeck.Cards.Take(20));
            action(m_deck);
        }

        private void ExecuteForSize(Action<Deck> action)
        {
            var countBeforeSorting = m_deck.Cards.Count;
            action(m_deck);
            var countAfterSorting = m_deck.Cards.Count;

            Assert.AreEqual(countBeforeSorting, countAfterSorting);
        }

        private void ExecuteForUniqueness(Action<Deck> action)
        {
            var originalDeck = new Deck(m_deck);
            action(m_deck);

            CollectionAssert.AllItemsAreUnique(m_deck.Cards);
            CollectionAssert.AreEquivalent(m_deck.Cards, originalDeck.Cards);
        }
    }
}
