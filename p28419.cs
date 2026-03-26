// p28419 - 더하기 (S4)
// #애드 혹
// 2026.3.27 solved (3.26)

/*
어떤 배열에서 인접한 3개의 요소를 1씩 증가시키면
홀수 합이 2 짝수합이 1 증가하거나 짝수 합이 1, 홀수 합이 2 증가하게 된다.
즉, 이 연산을 할 때마다 홀수 합과 짝수 합의 차이가 1씩 감소하거나 증가한다.
이 연산으로 홀수 합과 짝수 합이 같아지게 하려면 홀수 합과 짝수 합을 계산하고,
더 작은 쪽이 큰 쪽과 같아질 때까지 해당 합을 더 증가시키는 동작을 계속하면 된다.

단, 길이가 3인 경우에는 홀수 합이 2, 짝수 합이 1 증가하므로,
처음부터 홀수 합이 큰 경우에는 홀수와 짝수의 합을 같게 만들 수 없다.
*/

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int n = int.Parse(sr.ReadLine());
List<int> list = sr.ReadLine().Split().Select(int.Parse).ToList();
long oddSum = 0, evenSum = 0;
for (int i = 0; i < n; i++)
{
    if (i % 2 == 0)
        oddSum += list[i];
    else
        evenSum += list[i];
}
if (n == 3)
{
    if (oddSum > evenSum)
        Console.WriteLine(-1);
    else
        Console.WriteLine(evenSum - oddSum);
}
else
{
    Console.WriteLine(Math.Abs(evenSum - oddSum));
}
