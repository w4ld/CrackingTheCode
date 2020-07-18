using System;
using NUnit.Framework;
using CrackingTheCode;

namespace UnitTestCTC
{
   
    public class UnitTest1
    {
        [TestCase(new char[] { 'c', 'c', 'c', 'c' }, new char[] { 'c', '\0', '\0', '\0'})]
        [TestCase(new char[] { 'a', 'f', 'a' }, new char[] { 'a', 'f', '\0'})]
        [TestCase(new char[] { 'a', 'c', 'c', 'd', 'f', 'a' }, new char[] { 'a', 'c', 'd', 'f', '\0', '\0' })]
        public static void RemoveDuplicatesTest(char[] input, char[] expected)
        {
            Assert.AreEqual(CTC.RemoveDuplicates(input), expected);
        }

        [TestCase("aerth\0" , "htrea\0")]
        [TestCase("\0" , "\0")]
        [TestCase("a\0" , "a\0")]
        [TestCase("are\0" , "era\0")]
        public static void ReverseTest(string input, string expected)
        {
            Assert.AreEqual(CTC.Reverse(input), expected);
        }

        public static void AreAnagramsTest()
        {
            Console.WriteLine(AreAnagrams("abcd", "dcba" , true);
            Console.WriteLine(AreAnagrams("abcd", "dca" , false);
            Console.WriteLine(AreAnagrams("abccd", "dcba" , false);
            Console.WriteLine(AreAnagrams("abcd ", "dcba" , false);
        }
    }
}
