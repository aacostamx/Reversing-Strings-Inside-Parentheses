using System;
using System.Linq;

namespace ReversingStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var phrase = string.Empty;
            var result = string.Empty;

            phrase = "foobarbaz";
            //result = "foobarbaz";
            Console.WriteLine("Phrase: " + phrase);
            Console.WriteLine("Resuelt: " + ReverseStringsParentheses(phrase));
            Console.WriteLine();

            phrase = "foo(bar)baz";
            //result = "foorabbaz";
            Console.WriteLine("Phrase: " + phrase);
            Console.WriteLine("Resuelt: " + ReverseStringsParentheses(phrase));
            Console.WriteLine();


            phrase = "foo(bar(baz))blim";
            //result = "foobazrabblim";
            Console.WriteLine("Phrase: " + phrase);
            Console.WriteLine("Resuelt: " + ReverseStringsParentheses(phrase));
            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// Reversing Strings Inside Parentheses.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public static string ReverseStringsParentheses(string phrase)
        {
            var parentheses = 0;
            var parenthesesArray = new int[0];
            parentheses = phrase.Count(c => c == '(');
            parenthesesArray = Enumerable.Range(0, phrase.Length).Where(i => phrase[i] == '(').ToArray();

            while (parentheses > 0)
            {
                var chars = string.Empty;
                var charsReverse = string.Empty;
                var index = parenthesesArray[parentheses - 1] + 1;
                while (phrase[index] != ')')
                {
                    chars += phrase[index];
                    index++;
                }
                charsReverse = ReverseString(chars);
                var aux = phrase.Substring(0, parenthesesArray[parentheses - 1]) + charsReverse + phrase.Substring(parenthesesArray[parentheses - 1] + charsReverse.Length + 2);
                phrase = aux;
                parentheses--;
            }

            return phrase;

        }

        /// <summary>
        /// Reverses the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
