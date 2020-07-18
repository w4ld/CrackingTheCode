using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCode
{
    partial class CTC
    {
        #region 1.2
        public static void ReverseTest()
        {
            Console.WriteLine(Reverse("aerth\0") == "htrea\0");
            Console.WriteLine(Reverse("\0") == "\0");
            Console.WriteLine(Reverse("a\0") == "a\0");
            Console.WriteLine(Reverse("are\0") == "era\0");
        }
        public static string Reverse(string str)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (str[i] != '\0')
                sb.Insert(0, str[i++]);
            sb.Append('\0');
            return sb.ToString();
        }
        #endregion
        #region 1.3
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
                for (int j = i+1; j < str.Length; j++)
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
            str[str.Length - 1] = '\0';         
        }
        
        #endregion
        #region 1.4
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

        #endregion
    }
}
