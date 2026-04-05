// p2048 - Hello, 2048! (G4)
// #정수론
// 2026.4.5 solved

/*
k를 2^l, 2^(l+1), ... , 2^r의 십진법 표현을 이어붙여서 만든 정수라고 하자.

1. k는 2^r로 나누어 떨어진다.
2. r >= 4일 때, k = 2^r * 홀수의 곱으로 표현된다.
r >= 4일 때, 2^r은 두 자리 이상의 정수가 되고 2^(r-1)과는 최소 두 자리 이상 차이나게 된다.
즉, 2^(r-1)이 있는 부분은 최소 10^2 이상 차이가 나게 되어 2의 지수가 r보다 커지게 된다.
2^l, 2^(l+1) ... 2^(r-1)은 10^k와 곱해져 있는 형태로 k를
k = 2^l * 10^(k_1) + 2^(l+1) * 10^(k_2) + ... 2^r로 나타낼 수 있다.
2^r로 묶으면 2^r ( 2a_1 + 2a_2 + ... + 1)이 되고, 나머지 앞의 항은 모두 짝수인데, 1이 더해져 있으므로,
괄호로 묶인 부분은 반드시 홀수가 된다.
따라서 r이 4 이상인 경우 k는 2로 최대 r번 나누어 떨어진다.
그외 경우에는 r번보다 많이 나누어 떨어질 수 있고, 경우도 10가지 밖에 안되니 직접 구한다.
*/

public class Program
{
    public static int[,] dp = new int[4, 4];
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int t = int.Parse(sr.ReadLine());

        // r <= 3인 케이스에 대해서는 미리 답을 구해둔다.
        string[] s = { "1", "2", "4", "8" };
        for (int ll = 0; ll < 4; ll++)
        {
            for (int rr = ll; rr < 4; rr++)
            {
                string temp = "";
                for (int k = ll; k <= rr; k++)
                {
                    temp += s[k];
                }
                int ret = int.Parse(temp);
                dp[ll, rr] = ExpOfTwo(ret);
            }
        }

        for (int i = 0; i < t; i++)
        {
            int[] range = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int l = range[0], r = range[1];
            sw.WriteLine(FindExponentOfTwo(l, r));
        }
        sw.Flush();
    }
    // 정수 k가 2로 나누어떨어지는 횟수를 구한다.
    public static int ExpOfTwo(int k)
    {
        if (k <= 0) 
        {
            return 0;
        }
        int ret = 0;
        while (k % 2 == 0)
        {
            ret++;
            k /= 2;
        }
        return ret;
    }

    public static long FindExponentOfTwo(int l, int r)
    {
        if (l == r) return l;
        // r >= 4일 때는 수를 2^r * x로 나타냈을 때 x가 반드시 홀수가 된다.
        if (r >= 4) return r;
        return dp[l, r];
    }
}
