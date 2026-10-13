Console.WriteLine("=== try-catch: FormatException ===");

try
{
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"Вы ввели: {number}");
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: введено не число!");
}

Console.WriteLine("Программа продолжает работу как ни в чём не бывало");