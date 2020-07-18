using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace CrackingTheCode
{
    partial class CTC
    {
        #region 1.1
        //1.1 Implement an algorithm to determine if a string has all unique characters.What if you
        //can not use additional data structures?
        public static bool IsUnique(string str)
        {
            //fast and has a quick way to check uniqueness
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (chars.ContainsKey(c))   //if char in dictionary --> char not unique
                    return false;
                else
                    chars.Add(c, 0);    //char not in dict, add it
            }
            return true;
        }

        public static bool IsUniqueNoDS(string str) //no additional DS constraint
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                        return false;
                }
            }
            return true;
        }

        public static void UniqueTesting()
        {
            Console.WriteLine(IsUnique("asdfgh")==true);
            Console.WriteLine(IsUniqueNoDS("asdfgh")==true);
            Console.WriteLine(IsUnique("a") == true);
            Console.WriteLine(IsUniqueNoDS("a") == true);
            Console.WriteLine(IsUnique("") == true);
            Console.WriteLine(IsUniqueNoDS("") == true);
            Console.WriteLine(IsUnique("asqweirdfgh") == true);
            Console.WriteLine(IsUniqueNoDS("asqweirdfgh") == true);
            Console.WriteLine(IsUnique("aaa") == false);
            Console.WriteLine(IsUniqueNoDS("aaa") == false);
            Console.WriteLine(IsUnique("afwa") == false);
            Console.WriteLine(IsUniqueNoDS("afwa") == false);
        }
        #endregion
        #region 1.2

        //1.2 Write code to reverse a C-Style String. (C-String means that “abcd” is represented as
        //five characters, including the null character.)
        public static void ReverseTest()
        {
            Console.WriteLine(Reverse("aerth\0") == "htrea\0");
            Console.WriteLine(Reverse("\0") == "\0");
            Console.WriteLine(Reverse("a\0") == "a\0");
            Console.WriteLine(Reverse("are\0") == "era\0");
        }
        public static string Reverse(string str)
        {
            //C-like strings that end with \0 
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (str[i] != '\0') 
                sb.Insert(0, str[i++]); //insert all characters at head of SB
            sb.Append('\0');
            return sb.ToString();
        }
        #endregion
        #region 1.3

        //1.3 Design an algorithm and write code to remove the duplicate characters in a string
        //without using any additional buffer.NOTE: One or two additional variables are fine.
        //An extra copy of the array is not.
        //FOLLOW UP
        //Write the test cases for this method.
        public static void RemoveDuplicatesTest()
        {
           // Console.WriteLine(RemoveDuplicates(new char[]{'a','b','c','d'}));
            Console.WriteLine(RemoveDuplicates(new char[]{'c','c','c','c'}));
            Console.WriteLine(RemoveDuplicates(new char[]{'a','c','c','d','f'}));
            Console.WriteLine(RemoveDuplicates(new char[]{'a','c','c','d','f','a'}));
            Console.WriteLine(RemoveDuplicates(new char[]{ 'a', 'f', 'a' }));
            Console.WriteLine(RemoveDuplicates(new char[]{}));
        }

        //this would be easiest to write in C.
        public static char[] RemoveDuplicates(char[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i+1; j < str.Length; j++) //for duplicates 
                {
                    if(str[j]!='\0' && str[i] == str[j]) 
                    {
                        ShiftOne(ref str, j);
                        if (j == str.Length)
                            break;
                        j--;
                    }               
                }
            }
            return str;
        }
        public static void ShiftOne(ref char[] str, int index)
        {
            for (int i = index + 1; i < str.Length; i++)
                str[i - 1] = str[i];
            str[^1] = '\0';         
        }
        
        #endregion
        #region 1.4
        //1.4 Write a method to decide if two strings are anagrams or not.
        public static bool AreAnagrams(string str1, string str2)
        {
            //true anagrams have to have same length
            if (str2.Length != str1.Length)
                return false;
            char[] str1a = str1.ToCharArray();
            char[] str2a = str2.ToCharArray();
            //sort and compare
            Array.Sort(str1a);
            Array.Sort(str2a);
            for (int i = 0; i < str1.Length; i++)
                if (str1a[i] != str2a[i])
                    return false;
            return true;
            
        }
        public static void AreAnagramsTest()
        {
            Console.WriteLine(AreAnagrams("abcd","dcba")==true);
            Console.WriteLine(AreAnagrams("abcd","dca")==false);
            Console.WriteLine(AreAnagrams("abccd","dcba")==false);
            Console.WriteLine(AreAnagrams("abcd ","dcba")==false);
        }
        #endregion
        #region 1.5
        //1.5 Write a method to replace all spaces in a string with ‘%20’.
        public static string ReplaceSpaces(string str, string newchars)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
                if (c != ' ')
                    sb.Append(c);
                else
                    sb.Append(newchars);
            return sb.ToString();
        }
        public static string ReplaceSpaces2(string str, string oldchars, string newchars)
        {
            return str.Replace(oldchars, newchars);
        }
       
        public static void ReplaceStringTesting()
        {
            Console.WriteLine(ReplaceSpaces("Hello world!","%20")=="Hello%20world!");
            Console.WriteLine(ReplaceSpaces2("Hello world!"," ","%20")=="Hello%20world!");
            Console.WriteLine(ReplaceSpaces("    ","%20")== "%20%20%20%20");
            Console.WriteLine(ReplaceSpaces2("    "," ","%20")== "%20%20%20%20");
            Console.WriteLine(ReplaceSpaces("", "%20") == "");
            Console.WriteLine(ReplaceSpaces2("", " ", "%20") == "");
            Console.WriteLine(ReplaceSpaces("qwertyuiop", "%20") == "qwertyuiop");
            Console.WriteLine(ReplaceSpaces2("qwertyuiop", " ", "%20") == "qwertyuiop");
        }
        #endregion
        #region 1.6
        //1.6 Given an image represented by an NxN matrix, where each pixel in the image is 4
        //bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
        public struct Pixel
        {
            byte b0;
            byte b1;
            byte b2;
            byte b3;
        }
        /// <summary>
        /// return rotated 90 degrees left
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int[,] RotateMatrix(int[,] matrix, int N)
        {
            //rotating a matrix
            //  1 2 3       3 6 9       0,0 0,1 0,2             0,2 1,2 2,2
            //  4 5 6   ->  2 5 8       1,0 1,1 1,2     ->      0,1 1,1 2,1
            //  7 8 9       1 4 7       2,0 2,1 2,2             0,0 1,0 2,0
            int[,] rotated = new int[N,N];
            for(int i=0, k=N-1; i < N; i++,k--)
            {
                for(int j=0; j<N; j++)
                {
                    rotated[i, j] = matrix[j, k]; //sets to proper shifted index row to column
                }
            }
            return rotated;
        }
        /// <summary>
        /// rotate in place 90 degrees left
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int[,] RotateMatrixIP(int[,] matrix, int N)
        {
            //rotating a matrix
            //  1 2 3       3 6 9       0,0 0,1 0,2             0,2 1,2 2,2
            //  4 5 6   ->  2 5 8       1,0 1,1 1,2     ->      0,1 1,1 2,1
            //  7 8 9       1 4 7       2,0 2,1 2,2             0,0 1,0 2,0
            //to do this in place we rotate around the edge then shift in and rotate.

            int[,] rotated = new int[N, N];
            for (int i = 0, k = N - 1; i < N; i++, k--)
            {
                for (int j = 0; j < N; j++)
                {
                    rotated[i, j] = matrix[j, k];
                }
            }
            return rotated;
        }
        public static void RotateMatrixTest()
        {
            int[,] test = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] test2 = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] result = RotateMatrix(test, 3);
            int[,] result2 = RotateMatrix(test2, 4);
            Console.WriteLine("3x3");
            PrintMatrix(test, 3);
            Console.WriteLine();
            PrintMatrix(result, 3);
            Console.WriteLine("\n4x4");
            PrintMatrix(test2, 4);
            Console.WriteLine();
            PrintMatrix(result2, 4);

        }
        public static void PrintMatrix(int [,] matrix, int N)
        {
            for(int i=0; i<N; i++)
            {
                for(int j=0; j < N; j++) {
                    Console.Write(matrix[i,j].ToString("D2")+" ");
                }
                Console.WriteLine();
            }
        }
        #endregion

    }
}


//_________________________________________________________________pg 99
//________________________________________________________________pg 100
//________________________________________________________________pg 101
//1.7 Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
//column is set to 0.
//________________________________________________________________pg 102
//1.8 Assume you have a method isSubstring which checks if one word is a substring of
//another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using
//only one call to isSubstring(i.e., “waterbottle” is a rotation of “erbottlewat”).