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
            int num = 0;
            int J_len = J.Length;
            int S_len = S.Length;
            for (int i = 0; i < S_len; i++){
                for (int j = 0; j < J_len;j++){
                    if(S[i].Equals(J[j])){
                        num++;
                        break;
                    }
                } 
            }
            return num;
        }
    }
}
