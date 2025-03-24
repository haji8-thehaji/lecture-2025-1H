string day = "화요일";
DateTime now = DateTime.Now;
string day1 = now.ToString("dddd");
//string day2 = String.Format("{0:dddd}", now);
// Console.WriteLine(now.ToString("dddd"));
// Console.WriteLine(String.Format("{0:dddd}", now));

switch (day1)
{
    case "월요일":
    case "화요일":
    case "수요일":
    case "목요일":
    case "금요일":
        Console.WriteLine(day1 +": 평일입니다.");
        break;
    case "토요일":
    case "일요일":
        Console.WriteLine(day1 + ": 휴일입니다.");
        break;
}
