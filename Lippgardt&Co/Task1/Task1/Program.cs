using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start to cook breakfest");

            var taskFryEggs = FryEggsAsync();
            var taskFryBreadSleis= FryBreadSliseAsync();
            CutMushroom();
            FryMushroom();

            while ((!taskFryBreadSleis.IsCompleted) || (!taskFryEggs.IsCompleted))
            {
                
            }
            Console.WriteLine("Breakfest ready");
        }

        static async Task FryBreadSliseAsync()
        {
            await Task.Run(() => FryBreadSlise());
        }

        static async Task FryEggsAsync()
        {
            await Task.Run(() => FryEggs());
        }

        static void FryEggs()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Eggs have fry");
        }

        static void FryBreadSlise()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Bread has fried");
        }

        static  void FryMushroom()
        {
            Console.WriteLine("Musroom has fried");
        }
        static  void CutMushroom()
        {
            Console.WriteLine("Musroom has cut");
        }
    }
}
