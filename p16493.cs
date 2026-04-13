// p16493 - 최대 페이지 수 (S2)
// #DP #0-1 배낭 문제
// 2026.4.14 solved (4.13)

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int days = input[0], chapters = input[1];
int[] times = new int[chapters];
int[] pages = new int[chapters];
for (int i = 0; i < chapters; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    times[i] = input[0];
    pages[i] = input[1];
}
int[,] dp = new int[chapters + 1, days + 1];
for (int i = 1; i <= chapters; i++)
{
    for (int j = 1; j <= days; j++)
    {
        // 현재 칸의 날 수 j가 읽는데 소요되는 시간보다 짧음
        if (times[i - 1] > j)
        {
            dp[i, j] = dp[i - 1, j]; // 선택하지 않은 경우만 적용
        }
        else
        {
            // 선택한 경우와 그렇지 않은 경우 중 더 큰 것을 고름
            dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - times[i - 1]] + pages[i - 1]);
        }
    }
}
Console.WriteLine(dp[chapters, days]);
