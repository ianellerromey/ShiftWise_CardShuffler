using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffler.Lib
{
    public interface IRandomNumberGenerator
    {
        uint Next(uint maxRange);
    }
}
