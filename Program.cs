using System;

namespace Leetcode
{
    class MainClass
    {
        public static void Main( string[] args )
        {
            Console.WriteLine("Hello World!");
            TestReverseInterger();

        }

        //No.2
        #region 
        public static void AddTowNumberTestData()
        {
            var test1 = new ListNode(2);
            test1.next = new ListNode(4);
            test1.next.next = new ListNode(3);

            var test2 = new ListNode(5);
            test2.next = new ListNode(6);
            test2.next.next = new ListNode(4);

            var result = AddTowNumbers(test1, test2);
            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
            Console.ReadKey();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public static ListNode AddTowNumbers(ListNode l1, ListNode l2)
        {
            var node1 = l1;
            var node2 = l2;
            var result = new ListNode(0);
            var curr = result;
            int carry = 0;
            while (node1 != null || node2 != null)
            {
                int a = node1 != null ? node1.val : 0;
                int b = node2 != null ? node2.val : 0;
                int total = carry + a + b;
                carry = total / 10;
                curr.next = new ListNode((total % 10));
                curr = curr.next;
                if (node1 != null)
                    node1 = node1.next;
                if (node2 != null)
                    node2 = node2.next;

            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return result.next;
        }

        #endregion

        //No.3
        #region
        public static void LengthOfLongestSubstringTestData()
        {
            //string[] test = new string[4];
            //test[0] = "abcabcbb";
            //test[1] = "bbbbb";
            //test[2] = "pwwkew";
            //test[3] = "c";
            //for (int i = 0; i < test.Length; i++)
            //{
            //    int result = LengthOfLongestSubstring(test[i]);
            //    Console.WriteLine("longest substring is {0}", result);
            //    Console.ReadKey();
            //}
            string test = "dvdfedfjc";
            //string test = "pwwkewe";
            int result = LengthOfLongestSubstring(test);
            Console.WriteLine("longest substring is {0}", result);
            Console.ReadKey();

        }


        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int i = 0, j = 0;
            int maxLen = 0;
            bool[] exists = new bool[256];
            while (j < n)
            {
                if (exists[s[j]])
                {
                    maxLen = Math.Max(maxLen, j - i);
                    while (s[i] != s[j])
                    {
                        exists[s[i]] = false;
                        i++;
                    }
                    i++;
                    j++;
                }
                else
                {
                    exists[s[j]] = true;
                    j++;
                }
            }
            maxLen = Math.Max(maxLen, n - i);
            return maxLen;

        }
        #endregion

        //No.7
        #region Reverse Integer
        public static void TestReverseInterger()
        {
            int result = Reverse(-123);
            Console.Write(result);
            Console.ReadKey();
        }

        public static int Reverse(int x)
        {
            bool IsNegative = x < 0;
            if(IsNegative)
                x = x * -1;
            int result = 0;
            while (x > 0)
            {
                try
                {
                    result = checked(result * 10);
                }
                catch
                {
                    return 0;
                }
                result += x % 10;
                x = x / 10 ;
            }
            return IsNegative ? -result : result;
        }
        #endregion

        //No.9
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int len = (int)Math.Floor(Math.Log10(x)) + 1;
            int first = 0;
            int last = 0;
            int num = 1;

            for (int i = 1; i <= (len / 2); i++)
            {
                first = x / (int)Math.Pow(10, (len - num));
                last = x % 10;
                if (first != last)
                {
                    return false;
                }
                else
                {
                    x = x % (int)Math.Pow(10, (len - num));
                    num++;
                    x = x / 10;
                    num++;
                }
            }
            return true;
        }

        //No.13
        public int RomanToInt(string s)
        {
            int[] symbol = new int[256];
            symbol['I'] = 1;
            symbol['V'] = 5;
            symbol['X'] = 10;
            symbol['L'] = 50;
            symbol['C'] = 100;
            symbol['D'] = 500;
            symbol['M'] = 1000;
            int result = 0;
            int before_num = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (symbol[s[i]] < before_num)
                {
                    result = result - symbol[s[i]];
                }
                else
                {
                    result = result + symbol[s[i]];
                }
                before_num = symbol[s[i]];
            }
            return result;
        }

        //No.14
        public string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            int strs_len = strs.Length;
            if (strs_len > 0)
            {
                int min_strLen = strs[0].Length;
                foreach (var s in strs)
                {
                    if (s.Length < min_strLen)
                    {
                        min_strLen = s.Length;
                    }
                }
                int temp_count = 0;
                for (int i = 0; i < min_strLen; i++)
                {
                    for (int j = 1; j < strs_len; j++)
                    {
                        if (strs[0][i] != strs[j][i])
                        {
                            return result;
                        }

                    }
                    result += strs[0][temp_count];
                    temp_count++;
                }
            }
            return result;
        }

        //No.771
        public int NumJewelsInStones(string J, string S)
        {
            //test
            int num = 0;
            int J_len = J.Length;
            int S_len = S.Length;
            int[] s = new int[256];
            for (int i = 0; i < S_len; i++){
                    s[S[i]]++;
            }

            for (int j = 0; j < J_len; j++)
            {
                if(s[J[j]] != 0){
                    num += s[J[j]];
                }
            }
            return num;
        }

        //No.852
        public static int PeakIndexInMountainArray(int[] A)
        {
            int result = 0;
            for (int i = 0; i < A.Length - 2; i++)
            {
                if (A[i + 1] > A[i])
                {
                    if (A[i + 1] > A[i + 2])
                    {
                        result = i + 1;
                        break;
                    }
                }
            }
            return result;
        }

    }
}
