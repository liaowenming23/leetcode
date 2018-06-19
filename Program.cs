using System;

namespace Leetcode
{
    class MainClass
    {
        public static void Main( string[] args )
        {
            Console.WriteLine("Hello World!");
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
    }
}
