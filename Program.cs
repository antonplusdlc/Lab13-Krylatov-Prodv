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

Console.WriteLine();
Console.WriteLine("=== ex.Message ===");

try
{
    int[] numbers = { 1, 2, 3 };
    Console.WriteLine(numbers[10]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Произошла ошибка: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== Несколько catch ===");

Console.Write("Введите делитель: ");
try
{
    int divisor = int.Parse(Console.ReadLine());
    int result = 100 / divisor;
    Console.WriteLine($"Результат: {result}");
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: это не число");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Ошибка: нельзя делить на ноль");
}
catch (Exception ex)
{
    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== finally ===");

try
{
    Console.WriteLine("Пытаемся выполнить операцию...");
    int[] numbers = { 1, 2, 3 };
    Console.WriteLine(numbers[5]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
finally
{
    Console.WriteLine("Этот блок выполнится в любом случае");
}

Console.WriteLine();
Console.WriteLine("=== finally без ошибки ===");

try
{
    Console.WriteLine("Операция без ошибок");
}
finally
{
    Console.WriteLine("И здесь finally тоже сработал");
}

Console.WriteLine();
Console.WriteLine("=== throw ===");

try
{
    double result = CalculateSquareRoot(-5);
    Console.WriteLine(result);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

double CalculateSquareRoot(double number)
{
    if (number < 0)
    {
        throw new ArgumentException("Число не может быть отрицательным");
    }
    return Math.Sqrt(number);
}

Console.WriteLine();
Console.WriteLine("=== Собственное исключение ===");

try
{
    Withdraw(1000, 1500);
}
catch (NegativeBalanceException ex)
{
    Console.WriteLine($"Операция отклонена: {ex.Message}");
}

Withdraw(1000, 400);

void Withdraw(double balance, double amount)
{
    if (amount > balance)
    {
        throw new NegativeBalanceException($"Недостаточно средств: на счёте {balance}, а нужно снять {amount}");
    }
    Console.WriteLine($"Снято {amount}, остаток {balance - amount}");
}

// надёжный калькулятор

bool exit = false;

do
{
    try
    {
        Console.Write("enter first int: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("enter second int: ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("enter operation (+ - * /. e for exit): ");
        string operation = Console.ReadLine();

        switch (operation)
        {
            case "+":
                Console.WriteLine(first + second);
                break;
            case "-":
                Console.WriteLine(first - second);
                break;
            case "*":
                Console.WriteLine(first * second);
                break;
            case "/":
                Console.WriteLine(first / second);
                break;
            case "e":
                exit = true;
                break;
            default:
                throw new UnknownOperationException("Неизвестная операция!");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("not int!");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("делить на 0 незя!");
    }
    catch (UnknownOperationException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception)
    {
        Console.WriteLine("unk error");
    }
    finally
    {
        Console.WriteLine(new string('-', 24));
    }
} while (!exit);

// ## Самостоятельные задания

// 1

int[] a = [1, 2, 3, 4, 5];

try
{
    Console.Write("введи индекс элемента массива: ");
    int da = int.Parse(Console.ReadLine());

    Console.WriteLine(a[da]);
}
catch (FormatException)
{
    Console.WriteLine("not int!");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("выходит за границы!");
}

// 2

void CheckAge(int age)
{
    if (age < 0 || age > 120) throw new ArgumentException("incorrect age!");
}

try
{
    Console.Write("enter age: ");
    int age = int.Parse(Console.ReadLine());
    CheckAge(age);
    Console.WriteLine("ok");
}
catch (FormatException)
{
    Console.WriteLine("not int!");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}

class NegativeBalanceException : Exception
{
    public NegativeBalanceException(string message) : base(message)
    {
    }
}

class UnknownOperationException : Exception
{
    public UnknownOperationException(string msg) : base(msg) {}
}