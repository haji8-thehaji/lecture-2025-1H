// 달 선택 변수
DateTime selectMonth;
//input (날짜) 
//selectMonth = selectDateMonth();
selectMonth = new DateTime(2024, 09, 01);
//달력 출력
string input =" ";
do
{
    if(input== "<")
    {
        selectMonth = selectMonth.AddMonths(-1);
    }
    else if(input == ">")
    {
        selectMonth = selectMonth.AddMonths(1);
    }
    printCalender(selectMonth);
    input = Console.ReadLine();
} while (input == "<" || input == ">");




////////////////////////////////////////////////////////////////////////////////////

void printCalender(DateTime selectDate)
{
    // 선택된 월의 1일을 표시한다.
    DateTime targetMonthFirst = new DateTime(selectDate.Year, selectDate.Month, 1);
    // 선택된 월의 시작 요일을 계산합니다.
    int startDayOfWeek = (int)targetMonthFirst.DayOfWeek;
    if(startDayOfWeek == 0) // 일요일(0)이 시작 요일일때 7로 변환
    {
        startDayOfWeek = 7;
    }
    //Console.WriteLine("startDayOfWeek : "+ selectDate.DayOfWeek);
    // 선택된 월의 총 일수를 가져옵니다.
    int totalDays = DateTime.DaysInMonth(selectDate.Year, selectDate.Month);

    // MM월 달력 제목
    Console.WriteLine("{0,5:D4}년 {1:D2} 월 달력", selectDate.Year, selectDate.Month);
    // 요일 출력 (월요일부터)
    Console.WriteLine(" 월 화 수 목 금 토 일");
    // 날짜 출력 01일~28/30/31일

    for (int i = 1; i < startDayOfWeek; i++)
    {
        Console.Write("   ");
    }
    for (int i = 0 ; i < totalDays; i++)
    {
        Console.Write("{0,3:D2}", i + 1);
        if ((i % 7) == (6 - startDayOfWeek + 1) )
        { 
            Console.WriteLine();
        }
    }
    Console.WriteLine();
    // 달력 이동
    Console.WriteLine("<{0,3:D2}월            {1,3:D2}월>", selectDate.AddMonths(-1).Month, selectDate.AddMonths(1).Month);
}
//input (날짜) 
DateTime selectDateMonth()
{
    DateTime thisDate1 = new DateTime();
    Console.Write("날짜를 고르세요 (YYYY-MM-DD): ");
    String today = Console.ReadLine();
    if (today?.Split("-").Length == 3)
    {
        thisDate1 = new DateTime(
            int.Parse(today.Split("-")[0]),
            int.Parse(today.Split("-")[1]),
            int.Parse(today.Split("-")[2]));
    }
    //Console.WriteLine("selectMonth" + thisDate1);
    return thisDate1;
}
