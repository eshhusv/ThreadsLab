using System.Diagnostics;

internal class Program
{
    static void SecondThread()
    {
        Console.Write("Введите первое число: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Введите третье число: ");
        int num3 = int.Parse(Console.ReadLine());

        Console.WriteLine(Thread.CurrentThread.Name + " начал работу");

        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        int[] nums = { num1, num2, num3 };
        int min = num1;
        foreach (int num in nums)
        {
            if (min > num) min = num;
        }

        int nod;

        if(num1 > 0 & num2 > 0 & num3 > 0 ) nod = 1;
        else nod = 0;

        for(int i = 1; i < min + 1; i++)
        {
            if (num1 % i == 0 & num2 % i  == 0 & num3 % i == 0) nod = i;
        }
        sw.Stop();

        Console.WriteLine(Thread.CurrentThread.Name + " закончил работу");

        Console.WriteLine($"НОД чисел {num1}, {num2} и {num3}: " + nod);
        Console.WriteLine("Stopwatch: " + sw.ElapsedTicks.ToString());

    }

    private static void Main(string[] args)
    {
        ThreadStart secondThread = new ThreadStart(SecondThread);
        Thread thread = new Thread(secondThread);
        thread.Start();
    }
}