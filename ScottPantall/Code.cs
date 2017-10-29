using System;
using System.Collections.Generic;

namespace ScottPantall
{
    /// <summary>
    /// Implement these methods!
    /// Instructions are in the Tests file.
    /// </summary>
    public class Code
    {
        public static bool IsPalindrome(string input)
        {
            // Variables to interate through the string
            int beginning = 0;
            int end = input.Length;

            //Compare characters as variables iterate through half the string
            while(beginning < end)
            {
                if (input[beginning] != input[end - 1])
                    return false;

                beginning++;
                end--;
            }

            //Only reaches this line if input is a palendrome
            return true;
        }

        public static int GetIndexOfFirstCharacterOfSubstring(string inputString, string subString)
        {
            // Found the IndexOf method on MSDN https://msdn.microsoft.com/en-us/library/7cct0x33(v=vs.110).aspx
            return inputString.IndexOf(subString);
        }

        public static int[] ReverseArray(int[] input)
        {
            // Found the Reverse static method on MSDN https://msdn.microsoft.com/en-us/library/d3877932(v=vs.110).aspx
            Array.Reverse(input);
            return input;
        }

        public static int[] FindDuplicates(int[] input)
        {
            throw new NotImplementedException();
        }

        public static Coins MakeChange(decimal money)
        {
            throw new NotImplementedException();
        }
        
        public static bool CanViewAllMovies(Movie[] movies)
        {
            throw new NotImplementedException();
        }

        /// <hint>
        /// You may want to look into using some C# XML parsing libraries for this one. That would be encouraged.
        /// </hint>
        public static IEnumerable<int> GetLogEntryIdsByMessage(string xml, string message)
        {
            throw new NotImplementedException();
        }

        public static int BinarySearchTreeNodeDistance(TreeNode tree, int node1, int node2)
        {
            throw new NotImplementedException();
        }

        public static TreeNode MakeBinarySearchTree(List<int> values)
        {
            throw new NotImplementedException();
        }

        public static TreeNode SearchTree(TreeNode tree, int nodeValue)
        {
            throw new NotImplementedException();
        }

        public static int TotalGameScore(string[] scores, int numScores)
        {
            throw new NotImplementedException();
        }
    }
}
