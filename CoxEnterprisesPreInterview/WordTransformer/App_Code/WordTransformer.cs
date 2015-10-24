using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordTransformer
{
    public class WordTransformer
    {
        enum WordState { Word, NotWord };

        public static string TransformString(string originalString)
        {
            string transformedString = "";
            Regex notAlphaCharacter = new Regex(@"(\d|\s]|\W)");

            bool noDelimetersFound = !notAlphaCharacter.IsMatch(originalString);
            if (noDelimetersFound)
            {
                return TransformWord(originalString.ToList());
            }

            List<char> buffer = new List<char>();
            WordState bufferState = WordState.Word;

            while(originalString.Length > 0)
            {
                char character = originalString[0];

                WordState charState  = notAlphaCharacter.IsMatch(character.ToString()) ? WordState.NotWord : WordState.Word;
                bool stateChange = bufferState != charState;

                if (stateChange)
                {
                    switch (bufferState)
                    {
                        case WordState.Word:
                            transformedString += TransformWord(buffer);
                            bufferState = WordState.NotWord;
                            break;
                        case WordState.NotWord:
                            transformedString += string.Join("", buffer);
                            bufferState = WordState.Word;
                            break;
                        default:
                            break;
                    }

                    buffer.Clear();
                }

                buffer.Add(character);
                originalString = originalString.Remove(0, 1);
            }

            transformedString += bufferState == WordState.Word ? TransformWord(buffer) : string.Join("", buffer);            

            return transformedString;
        }

        private static string TransformWord(List<char> wordBuffer)
        {
            if(wordBuffer.Count() < 1)
            {
                return string.Empty;
            }

            string word = string.Join("", wordBuffer);

            string transformedWord = word[0].ToString();
            string remainingWord = word.Remove(0, 1);

            if (remainingWord.Length < 1)
            {
                return word;
            }

            transformedWord += CountDistinctLetters(remainingWord);

            transformedWord += remainingWord[remainingWord.Length - 1];

            return transformedWord;
        }

        private static string CountDistinctLetters(string remainingWord)
        {
            List<char> buffer = new List<char>();
            if (remainingWord.Length > 1)
            {
                for (int i = 0; i < remainingWord.Length - 1; i++)
                {
                    buffer.Add(remainingWord[i]);
                }
            }

            return buffer.Distinct().Count().ToString();
        }
    } 
}








    