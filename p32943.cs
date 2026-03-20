// p32943 - 자리 신청 (S5)
// #정렬 #시뮬레이션
// 2026.3.21 solved (3.20)

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int x = input[0], c = input[1], k = input[2];

List<(int, int, int)> log = new(); // 로그를 담는 리스트
for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    int t = input[0], s = input[1], n = input[2]; // 시간, 좌석 번호, 학번
    log.Add((t, s, n));
}
// 시간을 기준으로 오름차순 정렬
log.Sort((x, y) => x.Item1.CompareTo(y.Item1));

int[] allocate = new int[x + 1]; // i번 학생이 배정받은 좌석, 배정된 좌석이 없으면 0
bool[] IsAllocated = new bool[c + 1]; // i번 좌석은 배정을 받았는가?
foreach (var l in log)
{
    int seat = l.Item2, ID = l.Item3;
    if (IsAllocated[seat]) continue; // 이미 배정받은 좌석을 고른 신청은 무시
    // 기존에 신청한 학생이 자리를 바꿈
    else if (allocate[ID] != 0)
    {
        IsAllocated[allocate[ID]] = false;
    }
    // 자리 할당
    allocate[ID] = seat;
    IsAllocated[seat] = true;
}

// 좌석을 배정 받은 경우 출력
for (int i = 1; i <= x; i++)
{
    if (allocate[i] != 0)
        Console.WriteLine($"{i} {allocate[i]}");
}
