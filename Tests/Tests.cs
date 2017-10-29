using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScottPantall;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Let's find out if a string is a palindrome (spelled the same way backwards and forwards)
        /// IsPalindrome should return true if the input string is a palindrome, false otherwise.
        /// </summary>
        [TestMethod]
        public void String_IsPalindrome()
        {
            var palindrome = "racecar";
            var notPalindrome = "something else";
            var anotherPalindrome = "tattarrattat";
            var r1 = Code.IsPalindrome(palindrome);
            r1.Should().BeTrue();
            var r2 = Code.IsPalindrome(notPalindrome);
            r2.Should().BeFalse();
            var r3 = Code.IsPalindrome(anotherPalindrome);
            r3.Should().BeTrue();
        }

        /// <summary>
        /// Let's find out if a string contains another string, and at what position the other string starts.
        /// GetIndexOfFirstCharacterOfSubstring takes a string and a candidate substring.
        /// If the candidate exists in the first string, GetIndexOfFirstCharacterOfSubstring should return the position of the first character of the substring
        /// Otherwise, it should return -1
        /// </summary>
        [TestMethod]
        public void String_FindSubstring()
        {
            var inputString = "myLongFavoriteString";
            var sub = "vorite";
            var result = Code.GetIndexOfFirstCharacterOfSubstring(inputString, sub);
            result.Should().Be(8);
            var sub2 = "iteX";
            result = Code.GetIndexOfFirstCharacterOfSubstring(inputString, sub2);
            result.Should().Be(-1);
            var sub3 = "z";
            result = Code.GetIndexOfFirstCharacterOfSubstring(inputString, sub3);
            result.Should().Be(-1);
            var sub4 = "Strin";
            result = Code.GetIndexOfFirstCharacterOfSubstring(inputString, sub4);
            result.Should().Be(14);
            var sub5 = "Strix";
            result = Code.GetIndexOfFirstCharacterOfSubstring(inputString, sub5);
            result.Should().Be(-1);
        }

        /// <summary>
        /// Let's reverse an array.
        /// So, the values at the beginning should become the values at the end, and vice-versa.
        /// Try to reverse the array IN PLACE.
        /// This means don't allocate another array! Change the order of the array "in place", using the array provided, without allocating any extra memory.
        /// </summary>
        [TestMethod]
        public void Array_ReverseInPlace()
        {
            var input = new[] { 1, 2, 4, 7, 8, 9, 24 };
            var result = Code.ReverseArray(input);
            result[0].Should().Be(24);
            result[input.Length - 1].Should().Be(1);
            result[1].Should().Be(9);
            result[input.Length - 2].Should().Be(2);
            result[2].Should().Be(8);
            result[input.Length - 3].Should().Be(4);
            result[3].Should().Be(7);
            result[input.Length - 4].Should().Be(7);
        }

        /// <summary>
        /// Let's find out if an array has any duplicated values in it, and what the duplicates are.
        /// FindDuplicates takes an array, and should return another array that contains the duplicates in the first array.
        /// </summary>
        [TestMethod]
        public void Array_FindAllDuplicates()
        {
            var input = new[] { 1, 2, 3, 24, 24, 65, 8001, 6, 3, 24 };
            var results = Code.FindDuplicates(input);
            results.Should().BeEquivalentTo(new[] { 3, 24 });
        }

        /// <summary>
        /// Let's make some change. But we want to use as few coins as possible!
        /// MakeChange takes in a dollar amount (expressed in pennies, e.g $1.78 = 178).
        /// It should return a Coins object that makes change using the fewest possible coins.
        /// </summary>
        [TestMethod]
        public void MakeChange()
        {
            var result = Code.MakeChange(100);

            result.Quarters.Should().Be(4);

            result = Code.MakeChange(37);
            result.Quarters.Should().Be(1);
            result.Dimes.Should().Be(1);
            result.Pennies.Should().Be(2);

            result = Code.MakeChange(9);
            result.Nickels.Should().Be(1);
            result.Pennies.Should().Be(4);
        }

        /// <summary>
        /// Let's watch some movies at the theater.
        /// Of course, we want to know if we can see all of the movies without having to skip any of the parts!
        /// CanViewAllMovies takes a list of movies, which tell us their start and end dates and times.
        /// It should return true if we can watch all of the movies without having to miss anything (e.g if the start and end dates of two movies don't overlap)
        /// Otherwise, it should return false.
        /// (A movie that starts at the exact moment another movie ends is OK. We can switch screens very quickly.)
        /// </summary>
        [TestMethod]
        public void Movies_CanViewAll()
        {
            var format = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;

            Movie[] movies = new Movie[]
            {
            new Movie(DateTime.Parse("1/1/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/1/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format))
            };
            Code.CanViewAllMovies(movies).Should().BeTrue();

            movies = new Movie[]
            {
            new Movie(DateTime.Parse("1/1/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/1/2015 21:30", format), DateTime.Parse("1/1/2015 23:20", format)),
            new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format))
            };
            Code.CanViewAllMovies(movies).Should().BeFalse();

            movies = new Movie[]
            {
            new Movie(DateTime.Parse("1/1/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/1/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/2/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/2/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/2/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/3/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/3/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/3/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/4/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/4/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/4/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/5/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/5/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/5/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/6/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/6/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/6/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
            new Movie(DateTime.Parse("1/7/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
            new Movie(DateTime.Parse("1/7/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
            new Movie(DateTime.Parse("1/7/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format))
            };
            Code.CanViewAllMovies(movies).Should().BeTrue();
        }

        /// <summary>
        /// Let's parse some log files.
        /// Suppose we have log data in the following XML format, with entry records that have an "id" attribute, and message records that contain some information.
        /// I want to know the ID attributes of all the entries with "Application ended" log messages.
        /// </summary>
        [TestMethod]
        public void ParseLogEntries()
        {
            var xml =
        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
        "<log>\n" +
        "    <entry id=\"1\">\n" +
        "        <message>Application started</message>\n" +
        "    </entry>\n" +
        "    <entry id=\"2\">\n" +
        "        <message>Application ended</message>\n" +
        "    </entry>\n" +
        "    <entry id=\"3\">\n" +
        "        <message>Application started</message>\n" +
        "    </entry>\n" +
        "    <entry id=\"4\">\n" +
        "        <message>Application errored!</message>\n" +
        "    </entry>\n" +
        "    <entry id=\"5\">\n" +
        "        <message>Application ended</message>\n" +
        "    </entry>\n" +
        "</log>";

            var result = Code.GetLogEntryIdsByMessage(xml, "Application ended");
            result.Count().Should().Be(2);
            result.Should().Contain(2);
            result.Should().Contain(5);
        }

        /// <summary>
        /// Let's make a binary search tree.
        /// Binary search trees are special trees that obey the following rules as they are built:
        /// If a new node's value is LESS THAN the value of its parent, it goes on the left.
        /// If a new node's value is GREATER THAN the value of its parent, it goes on the right.
        /// MakeBinarySearchTree should take in a list of numbers and construct a binary search tree from them
        /// For the input below, I have (poorly) drawn the tree that should result.
        ///                 5
        ///            /        \                
        ///           3          6
        ///         /  \
        ///        1    4
        ///        \
        ///         2
        /// </summary>
        [TestMethod]
        public void MakeATree()
        {
            var values = new List<int> { 5, 6, 3, 1, 2, 4 };
            var tree = Code.MakeBinarySearchTree(values);
            tree.Value.Should().Be(5);
            tree.Left.Value.Should().Be(3);
            tree.Right.Value.Should().Be(6);
            tree.Right.Right.Should().BeNull();
            tree.Right.Left.Should().BeNull();
            tree.Left.Left.Value.Should().Be(1);
            tree.Left.Right.Value.Should().Be(4);
            tree.Left.Left.Left.Should().BeNull();
            tree.Left.Left.Right.Value.Should().Be(2);
        }

        /// <summary>
        /// Let's search a binary search tree. It's in the name, right?
        /// SearchTree takes a tree and a desired node value. It should return a tree node if one with the desired value exists in the tree, otherwise null.
        /// </summary>
        [TestMethod]
        public void SearchTree()
        {
            var tree = Code.MakeBinarySearchTree(new List<int> { 5, 6, 3, 1, 2, 4, 9 });
            var result = Code.SearchTree(tree, 3);
            result.Should().NotBeNull();
            result.Value.Should().Be(3);

            result = Code.SearchTree(tree, 9);
            result.Should().NotBeNull();
            result.Value.Should().Be(9);

            result = Code.SearchTree(tree, 8007);
            result.Should().BeNull();
        }

        /// <summary>
        /// Let's figure out how far apart two nodes in a tree are.
        /// BinarySearchTreeNodeDistance should return the number of edges in between the two nodes, or -1 if the distance is incalculable (for example, if one of the nodes doesn't exist in the tree)
        /// </summary>
        [TestMethod]
        public void TreeNodeDistance()
        {
            var tree = Code.MakeBinarySearchTree(new List<int> { 5, 6, 3, 1, 2, 4 });
            var node1 = 2;
            var node2 = 4;
            var result = Code.BinarySearchTreeNodeDistance(tree, node1, node2);
            result.Should().Be(3);

            tree = Code.MakeBinarySearchTree(new List<int> { 9, 7, 5, 3, 1 });
            node1 = 7;
            node2 = 20;
            result = Code.BinarySearchTreeNodeDistance(tree, node1, node2);
            result.Should().Be(-1);
        }

        /// <summary>
        /// Let's play a game.
        /// You throw a number of balls at targets. The targets have a numerical value, and there are three special values.
        /// X is worth double the previous throw. Example: 10 X is worth 30, since 10 + (10 * 2)
        /// + is worth the sum of the previous two throws. Example: 5 7 + is worth 24, since 5 + 7 + (5 + 7)
        /// Z zeroes out the value of the previous throw! Example: 5 8 Z is worth 5, since 5 + 8 + (-8)
        /// TotalGameScore should calculate the total score of a player's sequence of throws.
        /// Special values can act on each-other. For example, 5 7 + X is worth 48, since 5 + 7 + (5 + 7) + (12 * 2)
        /// Z values and their negated value are ignored for the purposes of other special values. 
        ///     Example: 2 5 Z X is worth 6, since 2 + 5 + (-5) + (2 * 2)
        ///     Notice how 5 and Z are not considered by X, so X acts on 2.
        /// </summary>
        [TestMethod]
        public void ScoreGame()
        {
            var input = new[] { "1", "3", "5" };
            var result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(9);

            input = new[] { "2", "X", "18" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(24);

            input = new[] { "8", "2", "+", "18" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(38);

            input = new[] { "46", "2", "+", "18" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(114);

            input = new[] { "5", "-2", "4", "Z", "X", "9", "+", "+" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(27);

            input = new[] { "111", "4", "Z", "18" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(129);

            input = new[] { "5", "-2", "4", "Z", "X", "9", "+", "+" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(27);

            input = new[] { "1", "2", "+", "Z" };
            result = Code.TotalGameScore(input, input.Length);
            result.Should().Be(3);
        }
    }
}
