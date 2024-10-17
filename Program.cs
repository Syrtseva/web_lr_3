using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // 1. Работа с классом Thread
        Console.WriteLine("1. Работа с классом Thread");
        Thread thread1 = new Thread(MethodWithThread1);
        Thread thread2 = new Thread(MethodWithThread2);
        thread1.Start();
        thread2.Start();
        thread1.Join();  // Ожидание завершения потока 1
        thread2.Join();  // Ожидание завершения потока 2

        // 2. Работа с Async-Await
        Console.WriteLine("\n2. Работа с Async-Await");
        Task task1 = MethodWithAsync1();
        Task task2 = MethodWithAsync2();
        Task.WaitAll(task1, task2);  // Ожидание завершения асинхронных методов

        Console.WriteLine("\nРабота завершена.");
    }

    // Метод для демонстрации работы с Thread (выполнение в отдельном потоке)
    static void MethodWithThread1()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"[Thread1] Выполняется итерация {i + 1}");
            Thread.Sleep(500);  // Имитация работы
        }
    }

    // Другой метод для работы с Thread
    static void MethodWithThread2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"[Thread2] Выполняется итерация {i + 1}");
            Thread.Sleep(700);  // Имитация работы с другой задержкой
        }
    }

    // Асинхронный метод с использованием async-await
    static async Task MethodWithAsync1()
    {
        Console.WriteLine("MethodWithAsync1 начинается.");
        await Task.Delay(1000);  // Асинхронная пауза, имитация работы
        Console.WriteLine("MethodWithAsync1 завершен.");
    }

    // Еще один асинхронный метод с использованием async-await
    static async Task MethodWithAsync2()
    {
        Console.WriteLine("MethodWithAsync2 начинается.");
        await Task.Delay(1500);  // Асинхронная пауза с другой задержкой
        Console.WriteLine("MethodWithAsync2 завершен.");
    }
}
