using System;

class CommandLineCalculator
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("사용법: CommandLineCalculator <숫자1> <연산자> <숫자2>");
            return;
        }

        uint num1, num2;

        if (!uint.TryParse(args[0], out num1) || !uint.TryParse(args[2], out num2))
        {
            Console.WriteLine("숫자 형식이 잘못되었습니다.");
            return;
        }

        string op = args[1];
        try
        {
            switch (op)
            {
                case "+":
                    Console.WriteLine($"덧셈 결과: {num1 + num2}");
                    break;
                case "-":
                    Console.WriteLine($"뺄셈 결과: {num1 - num2}");
                    break;
                case "*":
                    Console.WriteLine($"곱셈 결과: {num1 * num2}");
                    break;
                case "/":
                    Console.WriteLine($"나눗셈 결과: {num1 / num2}");
                    break;
                default:
                    Console.WriteLine("지원하지 않는 연산자입니다.");
                    break;
            }
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("표현할 수 없는 값입니다.");
        }
        finally
        {
            Console.WriteLine("종료합니다.");
        }
    }
}
