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
        public Hangman(string secret) 
        {
            Secret = secret;
            Result = new string('-', secret.Length);
        }

        public string Guess(char letter)
        {
            string testLetter = $"{letter}";
            int index = -1;
            do
            {
                index += 1;
                index = Secret.IndexOf(testLetter, index, StringComparison.OrdinalIgnoreCase);
                if(index > -1 )
                {
                    Result = Result.Insert(index, testLetter);
                    Result = Result.Remove(index + 1, 1);
                }                
            } while (index != -1);

            return Result;
        }
    }
}
