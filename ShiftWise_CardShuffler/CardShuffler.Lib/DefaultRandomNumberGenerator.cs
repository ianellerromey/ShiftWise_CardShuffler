using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffler.Lib
{
    public class DefaultRandomNumberGenerator : IRandomNumberGenerator
    {
        static readonly RNGCryptoServiceProvider s_rng = new RNGCryptoServiceProvider();

        public uint Next(uint maxRange)
        {
            byte[] bytes = new byte[4];

            s_rng.GetBytes(bytes);

            return BitConverter.ToUInt32(bytes, 0) % maxRange;
        }
    }
}
