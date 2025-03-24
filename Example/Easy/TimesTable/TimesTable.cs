/*구구단 게임을 시작합니다.
4 * 7 = 28
3 * 2 = 6
7 * 1 = 6
게임 종료 총 20점 획득하였습니다.

구구단 세팅 변경
MAX_NUM = 9
최대 단수를 9단으로 설정하였습니다.*/

using System.Diagnostics;

int MAX_NUM = 9;
long GAME_TIMER = 10;

Random rand = new Random();

int score = 0;
int nowStage = 1;

Stopwatch stopWatch = new Stopwatch();
file_read_rank();
while (true)
{
    Console.WriteLine("STAGE {0}", nowStage);
    int num = rand.Next(2, MAX_NUM);
    int time = rand.Next(1, MAX_NUM);
    Console.Write($"{num} *  {time} = ");

    int userAnswer;
    stopWatch.Restart();
    bool isNumeric = int.TryParse(Console.ReadLine(), out userAnswer);
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;

    if (ts.Seconds < GAME_TIMER && isNumeric && userAnswer == num * time)
    {
        score = score + 10;
        Console.WriteLine("정답입니다.: {0}", ts.Seconds);
        switch (score)
        {
            case (int)STAGE.STAGE1:
            case (int)STAGE.STAGE2:
            case (int)STAGE.STAGE3:
            case (int)STAGE.STAGE4:
                MAX_NUM = MAX_NUM + 3;
                GAME_TIMER = GAME_TIMER - 2;
                nowStage = nowStage + 1;
                break;
            default: break;
        }
    }
    else if (isNumeric && userAnswer == num * time)
    {
        Console.WriteLine($"타임 오버 총 {score}점 획득하였습니다.");
        file_read_rank();
        game_end(nowStage);
        break;
    }
    else
    {
        Console.WriteLine($"게임 종료 총 {score}점 획득하였습니다.");
        file_read_rank();
        game_end(nowStage);
        break;
    }
}
void game_end(int stage)
{
    Console.Write("닉네임을 입력해주세요 : ");
    String name = Console.ReadLine();
    file_write_rank(score, stage, name);
    score = 0;
}
// function
void file_write_rank(int score, int stage, string name)
{
    try
    {
        //Pass the filepath and filename to the StreamWriter Constructor
        StreamWriter sw = new StreamWriter("F:\\doing\\20240328.txt",true);
        //Write a line of text
        sw.WriteLine($"{score} | {stage} | {name}");
        //Close the file
        sw.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Executing finally block.");
    }
}

String[] s = [];
void file_read_rank()
{
    String line;
    try
    {
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader("F:\\doing\\20240328.txt");
        //Read the first line of text
        line = sr.ReadLine();
        //Continue to read until you reach end of file
        while (line != null)
        {
            string[] split_text = line.Split("|");
            if(split_text.Length == 3) { 
                string score = split_text[0];
                string stage = split_text[1]; 
                string name = split_text[2];
                Console.WriteLine(score + " " + stage +" " + name);
            }
            //write the line to console window
            //Console.WriteLine(line);
            //Read the next line
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
        //Console.ReadLine();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Executing finally block.");
    }
}
enum STAGE
{
    STAGE1 = 0, STAGE2 = 20, STAGE3 = 50, STAGE4 = 100
};











