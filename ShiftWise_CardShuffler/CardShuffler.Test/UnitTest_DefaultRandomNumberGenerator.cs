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
    public class UnitTest_DefaultRandomNumberGenerator
    {
        CardShuffler.Lib.DefaultRandomNumberGenerator m_rng;

        [TestInitialize]
        public void Initialize()
        {
            m_rng = new CardShuffler.Lib.DefaultRandomNumberGenerator();
        }

        [TestMethod]
        public void VerifyDefaultRandomNumberGenerator_Next()
        {
            for (int i = 0, numberOfPasses = 99999; i < numberOfPasses; ++i)
            {
                var currentPositions = new List<uint>();
                uint similarityCount = 0;
                uint similarityThreshold = Deck.SizeOfDeck / 3;

                for (int x = 0; x < Deck.SizeOfDeck; ++x)
                {
                    currentPositions.Add(m_rng.Next(Deck.SizeOfDeck));
                }

                Assert.IsTrue(currentPositions.Distinct().Count() > similarityThreshold, string.Format("Randomness failed on iteration {0} with a similarity count of {1}.", i, similarityCount));
            }
        }
    }
}
