// p14651 - 걷다보니 신천역 삼 (Large) (S1)
// #DP
// 2026.3.23 solved

/*
0으로 시작하지 않는 0, 1, 2만 이루어진 n자리 정수의 개수를 세는 문제
n이 작을 때 개수가 0, 2, 6, 18로 나왔다.
n=2를 기준으로 3배씩 늘어나는 것으로 추측했는데
n=10 일 때 13122 = 2 * 3^8이어서 예상이 맞았음을 알았다.
*/

long n = long.Parse(Console.ReadLine());
long p = 1_000_000_009;

switch (n)
{
    case 1:
        Console.WriteLine(0);
        break;
    case 2:
        Console.WriteLine(2);
        break;
    default:
        long ret = 2;
        for (int i = 3; i <= n; i++)
        {
            ret *= 3;
            ret %= p;
        }
        Console.WriteLine(ret);
        break;
}
