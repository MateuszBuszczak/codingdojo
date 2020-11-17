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
        [TestCase("Developer", new char[] {  }, new string[] {  })]
        [TestCase("Developer", new char[] { 'A' }, new string[] { "---------", })]
        [TestCase("Developer",
                   new char[] { 'A', 'E', 'I', 'O', 'U', 'R', 'N', 'S', 'T', 'L', 'P', 'D', 'V' },
                   new string[] { "---------", "-E-E---E-", "-E-E---E-", "-E-E-O-E-", "-E-E-O-E-", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-E-O-ER", "-E-ELO-ER", "-E-ELOPER", "DE-ELOPER", "DEVELOPER" })]
        public void TestMethod1(string secret, char[] letters, string[] results)
        {
            HangmanInterface hangman = null;
            
            Assert.DoesNotThrow(() => hangman = new Hangman(secret));
            
            for (var index = 0; index < letters.Length; index+=1)            
            {
                var result = hangman.Guess(letters[index]);
                Assert.That(result, Is.EqualTo(results[index]), $"wrong result for: {letters[index]}, get: {result} expected: {results[index]}");
            }
        }
    }
}
