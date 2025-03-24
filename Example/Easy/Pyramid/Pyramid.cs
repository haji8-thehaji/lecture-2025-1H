
for (int i = 0; i < 5; i++)
{
// 별 찍기
for (int j = 0; j < i; j++)
{
Console.Write("");
}
// 빈공간
for (int j = i; j < 5; j++)
{
Console.Write(" ");
}
// 빈공간
for (int j = i; j < 5; j++)
{
Console.Write(" ");
}
// 별 찍기
for (int j = 0; j < i; j++)
{
Console.Write("");
}
Console.WriteLine(i);
}
