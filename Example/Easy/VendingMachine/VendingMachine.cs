

const int PAY_HOT_CHOCO = 2500;
const int PAY_HOT_MILK = 500;
const int PAY_WARTER = 1000;
const int PAY_COFFEE = 500;
uint in_money = 0;

while (true)
{
    printVending();
    insertMoney();
    printInCash(in_money);
    selectDrink();
    printInCash(in_money);
}
void insertMoney()
{
    
    // 1.  금액 투입
    Console.WriteLine("금액을 투입하여 주세요");
    Console.WriteLine("카드 or 현금");
    Console.WriteLine("카드       : 0");
    Console.WriteLine("현금 10    : 1");
    Console.WriteLine("현금 50    : 2");
    Console.WriteLine("현금 100   : 3");
    Console.WriteLine("현금 500   : 4");
    Console.WriteLine("현금 1000  : 5");
    int choice_pay = int.Parse(Console.ReadLine());
    //int choice_pay = int.Parse((char)Console.Read());

    switch (choice_pay)
    {
        case (int)PAY_INPUT.WON_10:
            in_money = in_money + 10;
            break;
        case (int)PAY_INPUT.WON_50:
            in_money = in_money + 50;
            break;
        case (int)PAY_INPUT.WON_100:
            in_money = in_money + 100;
            break;
        case (int)PAY_INPUT.WON_500:
            in_money = in_money + 500;
            break;
        case (int)PAY_INPUT.WON_1000:
            in_money = in_money + 1000;
            break;
    }
}
void printVending()
{
}
void selectDrink(){
    // 3. 음료 고르기
    Console.WriteLine("음료를 고르세요");
    Console.WriteLine("코코아 2500원    : 1");
    Console.WriteLine("우유 500원       : 2");
    Console.WriteLine("물 1000원        : 3");
    Console.WriteLine("커피 500원       : 4"); ;
    Console.WriteLine("동전 반환 / 구매 취소 : 0");
    Console.WriteLine("추가 금액 투입   : 9");
    int choice_drink = int.Parse(Console.ReadLine());
    Console.WriteLine(choice_drink);
    bool success = false;
    switch (choice_drink)
    {
        case 9:
            //추가 금액 투입
            break;
        case 0:
        // 동전 반환 구매 취소
        case (int)DRINK.HOT_CHOCO:
            if (in_money > PAY_HOT_CHOCO)
            {
                in_money = in_money - PAY_HOT_CHOCO;
                success = true;
                Console.WriteLine("핫초코가 나왔습니다.");
            }
            break;
        case (int)DRINK.HOT_MILK:
            if (in_money > PAY_HOT_MILK)
            {
                in_money = in_money - PAY_HOT_MILK;
                success = true;
                Console.WriteLine("우유가 나왔습니다.");
            }
            break;
        case (int)DRINK.WARTER:
            if (in_money > PAY_WARTER)
            {
                in_money = in_money - PAY_WARTER;
                success = true;
                Console.WriteLine("물이 나왔습니다.");
            }
            break;
        case (int)DRINK.COFFEE:
            if (in_money > PAY_COFFEE)
            {
                in_money = in_money - PAY_COFFEE;
                success = true;
                Console.WriteLine("커피가 나왔습니다.");
            }
            break;
    }

}
void printInCash(uint in_money)
{

    // 2. 금액 표시
    Console.WriteLine($"잔액 : {in_money}");
}

enum PAY_INPUT
{
    CARD = 0,
    WON_10 = 1,
    WON_50 = 2,
    WON_100 = 3,
    WON_500 = 4,
    WON_1000 = 5
}
enum PAY_RETURN
{
    WON_10 = 10,
    WON_50 = 50,
    WON_100 = 100,
    WON_500 = 500,
    WON_1000 = 1000
}
enum DRINK
{
    HOT_CHOCO = 1,
    HOT_MILK,
    WARTER,
    COFFEE
}
