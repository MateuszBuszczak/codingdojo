using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanLib
{
    public interface HangmanInterface
    {
        string Guess(char letter);

        bool IsResolved { get; }

        long RemainingAttempts { get; }

    }
}
