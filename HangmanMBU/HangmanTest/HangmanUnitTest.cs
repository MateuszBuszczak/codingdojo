using System;
using HangmanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace HangmanTest
{
    [TestClass]
    public class HangmanUnitTest
    {
        [TestCase("Developer", new char[] {  }, new string[] {  }, 6, false)]
        [TestCase("Developer", new char[] { 'A' }, new string[] { "---------", }, 6, false)]
        [TestCase("Developer",
                   new char[] { 'A', 'E', 'I', 'O', 'U', 'R', 'N', 'S', 'T', 'L', 'P', 'D', 'V' },
                   new string[] { "---------", "-E-E---E-", "-E-E---E-", "-E-E-O-E-", "-E-E-O-E-", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-ELO-ER", "-E-ELOPER", "DE-ELOPER", "DEVELOPER" },
                   13, 
                   true)]
        [TestCase("Developer",
                   new char[] { 'A', 'E', 'I', 'O', 'U', 'R', 'N', 'S', 'T', 'L', 'P', 'D', 'V' },
                   new string[] { "---------", "-E-E---E-", "-E-E---E-", "-E-E-O-E-", "-E-E-O-E-", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-ELO-ER", "-E-ELOPER", "DE-ELOPER", "DE-ELOPER" },
                   12,
                   false)]
        public void TestHangman(string secret, char[] letters, string[] results, long maxAttempts, bool IsResolved)
        {
            HangmanInterface hangman = null;
            
            Assert.DoesNotThrow(() => hangman = new Hangman(secret, maxAttempts));
            
            for (var index = 0; index < letters.Length; index+=1)            
            {
                var result = hangman.Guess(letters[index]);
                Assert.That(result.ToUpper(), Is.EqualTo(results[index].ToUpper()), $"wrong result for: {letters[index]}, get: {result} expected: {results[index]}");
            }
            Assert.That(hangman.IsResolved, Is.EqualTo(IsResolved), $"wrong result for IsResolved, get: {IsResolved} expected: {hangman.IsResolved}");
        }
    }
}
