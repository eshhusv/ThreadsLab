using System.Diagnostics;

internal class Program
{
    static void SecondThread(int[] numsArr)
    {
        Thread.CurrentThread.Name = "SecondThread";
        Console.WriteLine(Thread.CurrentThread.Name + " has started working");
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        int num1 = numsArr[0];
        int num2 = numsArr[1];
        int num3 = numsArr[2];
        int min = num1;
        foreach (int num in numsArr)
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


        Console.WriteLine(Thread.CurrentThread.Name + $": GCD {num1}, {num2} и {num3}: " + nod);
        Console.WriteLine(Thread.CurrentThread.Name + "Stopwatch: " + sw.ElapsedTicks.ToString());
        Console.WriteLine(Thread.CurrentThread.Name + " has ended working");
    }

    private static void Main(string[] args)
    {
        Console.Write("Type first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Type second number: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Type third number: ");
        int num3 = int.Parse(Console.ReadLine());
        int[] numsArr = {num1, num2, num3};
        ParameterizedThreadStart secondThread = new ParameterizedThreadStart(SecondThread);
        Thread thread = new Thread(secondThread);   
        Thread.CurrentThread.Name = "MainThread";
        thread.Start(numsArr);

        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        int[] nums = { num1, num2, num3 };
        int min = num1;
        foreach (int num in nums)
        {
            if (min > num) min = num;
        }

        int nod;

        if (num1 > 0 & num2 > 0 & num3 > 0) nod = 1;
        else nod = 0;

        for (int i = 1; i < min + 1; i++)
        {
            if (num1 % i == 0 & num2 % i == 0 & num3 % i == 0) nod = i;
        }
        sw.Stop();

        Console.WriteLine(Thread.CurrentThread.Name + $"GCD {num1}, {num2} и {num3}: " + nod);
        Console.WriteLine(Thread.CurrentThread.Name + "Stopwatch: " + sw.ElapsedTicks.ToString());
        Console.WriteLine(Thread.CurrentThread.Name + " has ended working");
    }
}