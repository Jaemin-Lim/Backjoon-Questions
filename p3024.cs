// p3024 - 마라톤 틱택토 (S3)
// #문자열 #구현
// 2026.3.19 solved

int line = int.Parse(Console.ReadLine());

List<string> board = new();
for (int i = 0; i < line; i++)
{
    board.Add(Console.ReadLine());
}

// 가로 행 검사
foreach (string l in board)
{
    char c = DetermineWinner(l);
    if (c != '.')
    {
        Console.WriteLine(c);
        return;
    }
}

// 세로 행 검사
for (int i = 0; i < line; i++)
{
    string cur = "";
    for (int j = 0; j < line; j++)
    {
        cur += board[j][i];
    }
    char c = DetermineWinner(cur);
    if (c != '.')
    {
        Console.WriteLine(c);
        return;
    }
}

List<(int, int)> startPos = new();
// 대각선 검사
for (int i = 0; i < line; i++)
{
    // 맨 윗 줄
    startPos.Add((0, i));
    if (i != 0)
    {
        // 왼쪽과 오른쪽 줄
        startPos.Add((i, 0));
        startPos.Add((i, line - 1));
    }
}

// 시작 위치를 기점으로 /, \ 방향으로 보드의 끝까지 이동해서 문자열을 만들고,
// 그 문자열에서 연속된 3개의 문자가 있는지 확인한다.
foreach (var pos in startPos)
{
    char c = DetermineWinner(Diagonal(pos.Item1, pos.Item2, 1, -1, board));
    if (c != '.')
    {
        Console.WriteLine(c);
        return;
    }
    c = DetermineWinner(Diagonal(pos.Item1, pos.Item2, 1, 1, board));
    if (c != '.')
    {
        Console.WriteLine(c);
        return;
    }
}

Console.WriteLine("ongoing");


// 해당 문자열에서 연속된 3개 문자가 있는지 판정
char DetermineWinner(string line)
{
    int seq = 0;
    char prev = '.';
    foreach (char c in line)
    {
        if (c == '.') seq = 0;
        // 같은 문자면 시퀸스 길이에 누적
        else if (c == prev) seq++;
        // 문자 바뀜
        else seq = 1;
        // '.'이 아닌 문자가 3개 연속 되면 승리
        if (seq == 3)
        {
            return c;
        }
        prev = c;
    }
    return '.';
}

// 해당 위치를 기준으로 dy, dx 방향으로 진행하며 대각선에 있는 문자를 조합
string Diagonal(int sy, int sx, int dy, int dx, List<string> board)
{
    string ret = "";
    while (ValidPos(sy, sx, board.Count))
    {
        ret += board[sy][sx];
        sy += dy;
        sx += dx;
    }
    return ret;
}

// n x n 리스트의 유효 인덱스인지 파악
bool ValidPos(int y, int x, int n)
{
    return y >= 0 && x >= 0 && y < n && x < n;
}
