using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanLib
{
    public class Hangman : HangmanInterface
    {
        private readonly string Secret;
        private string Result;
        private long attemptsLeft;

        public Hangman(string secret, long maxAttempts)
        {
            Secret = secret;
            Result = new string('-', secret.Length);
            attemptsLeft = maxAttempts;
        }

        public long RemainingAttempts => attemptsLeft;
        public bool IsResolved => string.Compare(Secret, Result, StringComparison.OrdinalIgnoreCase) == 0;

        public string Guess(char letter)
        {
            if (attemptsLeft > 0)
            {
                attemptsLeft -= 1;
                string testLetter = $"{letter}".ToUpper();
                int index = -1;
                do
                {
                    index += 1;
                    index = Secret.IndexOf(testLetter, index, StringComparison.OrdinalIgnoreCase);
                    if (index > -1)
                    {
                        Result = Result.Insert(index, testLetter);
                        Result = Result.Remove(index + 1, 1);
                    }
                } while (index != -1);
            }
            return Result;
        }
    }
}
