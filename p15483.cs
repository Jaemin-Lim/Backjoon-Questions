// p15483 - 최소 편집 (G3)
// #DP #최소 편집 거리
// 2026.4.13 solved (4.12)

string x = Console.ReadLine();
string y = Console.ReadLine();
int xLen = x.Length;
int yLen = y.Length;

int[,] dp = new int[xLen + 1, yLen + 1];

// base
for (int i = 0; i <= xLen; i++)
{
    dp[i, 0] = i;
}
for (int i = 0; i <= yLen; i++)
{
    dp[0, i] = i;
}

// dp
for (int i = 1; i <= xLen; i++)
{
    for (int j = 1; j <= yLen; j++)
    {
        // addition
        int add = dp[i, j - 1] + 1;
        // replace
        int rep = dp[i - 1, j - 1] + (x[i - 1] == y[j - 1] ? 0 : 1);
        // delection
        int del = dp[i - 1, j] + 1;
        // find minimum of these three terms
        dp[i, j] = Math.Min(add, Math.Min(rep, del));
    }
}
Console.WriteLine(dp[xLen, yLen]);
