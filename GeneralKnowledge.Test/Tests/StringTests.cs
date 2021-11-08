using System;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found

            int size = 15;
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(ch);
            }
            string value = sb.ToString();
            
            while (value.Length > 0)
            {
                Console.Write(value[0] + " = ");
                int cal = 0;
                for (int j = 0; j < value.Length; j++)
                {
                    if (value[0] == value[j])
                    {
                        cal++;
                    }
                }
                Console.WriteLine(cal);
                value = value.Replace(value[0].ToString(), string.Empty);
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b

            if (a.Length != b.Length)
                return false;
            var s1Array = a.ToLower().ToCharArray();
            var s2Array = b.ToLower().ToCharArray();

            Array.Sort(s1Array);
            Array.Sort(s2Array);

            a = new string(s1Array);
            b = new string(s2Array);

            return a == b;
        }
    }
}
