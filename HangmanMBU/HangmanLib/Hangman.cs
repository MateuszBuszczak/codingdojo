using System;

namespace HangmanLib
{
    public class Hangman : HangmanInterface
    {
        private readonly string Secret;
        private string Result;

        public Hangman(string secret, long maxAttempts)
        {
            Secret = secret;
            Result = new string('-', secret.Length);
            RemainingAttempts = maxAttempts;
        }

        public long RemainingAttempts { get; private set; }
        public bool IsResolved => string.Compare(Secret, Result, StringComparison.OrdinalIgnoreCase) == 0;

        public string Guess(char letter)
        {
            if (RemainingAttempts > 0)
            {
                RemainingAttempts -= 1;
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
