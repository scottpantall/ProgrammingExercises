using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

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
            // I will come back around and create a solution that shows work
            return inputString.IndexOf(subString);
        }

        public static int[] ReverseArray(int[] input)
        {
            // Found the Reverse static method on MSDN https://msdn.microsoft.com/en-us/library/d3877932(v=vs.110).aspx
            // I will come back around and create a solution that shows work
            Array.Reverse(input);
            return input;
        }

        public static int[] FindDuplicates(int[] input)
        {
            /*
            int[] duplicates = new int[input.Length/2];
            int duplicateAmount = 0;

            for(int i = 0; i < input.Length; i++)
            {
                for(int j = i + 1; j < input.Length; j++)
                {
                    if(input[j] == input[i])
                    {
                        duplicates[duplicateAmount] = input[j];
                        duplicateAmount++;
                    }
                }
            }

            //Array.Resize<int>(ref duplicates, duplicateAmount - 1);
            return duplicates;
            */
            int duplicatesSize = 0;
            int[] duplicates = new int[duplicatesSize];
            

            foreach (int num in input)
            {
                if(Array.IndexOf(input, num) != Array.LastIndexOf(input, num))
                {
                    if(Array.IndexOf(duplicates, num) == -1)
                    {
                        duplicatesSize++;
                        Array.Resize<int>(ref duplicates, duplicatesSize);
                        duplicates[duplicatesSize - 1] = num;
                    }
                    
                }
            }

            return duplicates;
        }

        public static Coins MakeChange(decimal money)
        {
            Coins change = new Coins();

            while(money != 0)
            { 
                if (money > 25)
                {
                    change.Quarters = (int)(money / 25);
                    money %= 25;
                } else if (money > 10)
                {
                    change.Dimes = (int)(money / 10);
                    money %= 10;
                } else if (money > 5)
                {
                    change.Nickels = (int)(money / 5);
                    money %= 5;
                } else
                {
                    change.Pennies = (int)(money);
                    money = 0;
                }
            }
            return change;
        }
        
        public static bool CanViewAllMovies(Movie[] movies)
        {
            /* First Try...
            Movie prevMovie = movies[0];
            
            for(int i = 1; i < movies.Length; i++)
            {
                if (prevMovie.End < movies[i].Start)
                    return false;
                prevMovie = movies[i];
            }
            */

            // Second try...
            int currentMovie = 1;

            while (currentMovie < movies.Length)
            {
                if (DateTime.Compare(movies[currentMovie - 1].End, movies[currentMovie].Start) > 0)
                    return false;
                currentMovie++;
            }

            return true;
        }

        /// <hint>
        /// You may want to look into using some C# XML parsing libraries for this one. That would be encouraged.
        /// </hint>
        public static IEnumerable<int> GetLogEntryIdsByMessage(string xml, string message)
        {
            // Used this as a guide https://msdn.microsoft.com/fr-fr/library/cc189056(v=vs.95).aspx
            // Decided on return type using this https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections#BKMK_Collections
            // Also used this https://www.dotnetperls.com/xmlreader

            Queue<int> messageQueue = new Queue<int>(); // Collection of ID values to return
            int entryID = 0;                            // Variable to hold ID values

            // Create XML reader for string
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                while (reader.Read())
                {
                    // Only reads start elements
                    if(reader.IsStartElement())
                    {
                        // Entry is detected
                        if(reader.Name == "entry")
                        {
                            // Get entry ID value and store it as an integer
                            // Thank you StackOverflow https://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
                            string result = Regex.Match(reader["id"], @"\d+").Value;
                            entryID = Int32.Parse(result);

                            // Read the next tag element that is a message element
                            reader.ReadToFollowing("message");

                            // If the message element's contents are the same as the message variable...
                            // Add the entryID to the messageQueue
                            if (reader.ReadElementContentAsString() == message)
                                messageQueue.Enqueue(entryID);
                        }
                    }
                }
            }

            return messageQueue;
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
