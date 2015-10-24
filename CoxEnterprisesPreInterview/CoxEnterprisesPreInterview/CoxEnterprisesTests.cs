using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace CoxEnterprisesPreInterview
{
    [TestClass]
    public class CoxEnterprisesTests
    {
        [TestMethod]
        public void CanIDoTheTask()
        {
            string word = "Automotive..Thing";

            word = WordTransformer.WordTransformer.TransformString(word);
        
            Assert.AreEqual("A6e..T3g", word);
        }

        [TestMethod]
        public void CanIDetectDelimeters()
        {
            Regex notAlphaCharacter = new Regex(@"(\d|\s]|\W)");

            Assert.IsTrue(notAlphaCharacter.IsMatch("."));
        }

        [TestMethod]
        public void CanITransformAWord()
        {
            string word = "Bike";

            if(word.Length == 0)
            {
                Assert.IsTrue(true);
                return;
            }

            string transformedWord = word[0].ToString();
            string remainingWord = word.Remove(0, 1);

            if(remainingWord.Length == 0)
            {
                Assert.AreEqual(transformedWord, word);
                return;
            }

            List<char> buffer = new List<char>();
            if (remainingWord.Length > 1)
            {           
                for (int i = 0; i < remainingWord.Length - 1; i++)
                {
                    buffer.Add(remainingWord[i]);
                }
            }

            transformedWord += buffer.Distinct().Count();

            transformedWord += remainingWord[remainingWord.Length - 1];

            Assert.AreEqual("B2e", transformedWord);
        }
    }
}