using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentTestClass concurrent = new ConcurrentTestClass();
            concurrent.RunTests();
            Console.Read();
        }

        public class ConcurrentTestClass
        {

            public async void RunTests()
            {
                Console.WriteLine("Executes each async request in order");
                await AllAwaits();
                Console.WriteLine();

                Console.WriteLine("Executes each async request concurrently");
                await TaskWhenAll();
                Console.WriteLine();

                Console.WriteLine("Executes each async request concurrently but doesn't wait for them to finish before continuing");
                await ParallelTasks();
            }

            private async Task AllAwaits()
            {
                Console.WriteLine("Starting All Awaits Tests");
                Stopwatch stopwatch = Stopwatch.StartNew();
                await TaskOne();
                await TaskTwo();
                await TaskThree();
                await TaskFour();
                await TaskFive();
                stopwatch.Stop();
                Console.WriteLine("All Awaits Test Completed: " + stopwatch.ElapsedMilliseconds);
            }

            private async Task TaskWhenAll()
            {
                Console.WriteLine("Starting Task When All Tests");
                Stopwatch stopwatch = Stopwatch.StartNew();
                List<Task> tasks = new List<Task>()
                {
                    TaskOne(),
                    TaskTwo(),
                    TaskThree(),
                    TaskFour(),
                    TaskFive()
                };
                await Task.WhenAll(tasks);
                stopwatch.Stop();
                Console.WriteLine("Task When All Test Completed: " + stopwatch.ElapsedMilliseconds);
            }

            private async Task ParallelTasks()
            {
                Console.WriteLine("Starting Parallel Tasks Tests");
                Stopwatch stopwatch = Stopwatch.StartNew();
                List<Func<Task>> tasks = new List<Func<Task>>()
                {
                    TaskOne,
                    TaskTwo,
                    TaskThree,
                    TaskFour,
                    TaskFive
                };

                Parallel.ForEach(tasks, async (task) => await task());

                stopwatch.Stop();
                Console.WriteLine("Task Parallel Tasks Test Completed: " + stopwatch.ElapsedMilliseconds);
            }

            private async Task TaskOne()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("TaskOne Complete");
                });
            }
            private async Task TaskTwo()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("TaskTwo Complete");
                });
            }
            private async Task TaskThree()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("TaskThree Complete");
                });
            }
            private async Task TaskFour()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("TaskFour Complete");
                });
            }
            private async Task TaskFive()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("TaskFive Complete");
                });
            }
        }
    }
}
