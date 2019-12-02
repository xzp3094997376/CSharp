using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+ "   mainthead");
            Task<int> task= DoAsync.CalCulate(1, 2);
            Console.WriteLine("122222");
            Console.WriteLine(task.Result);

            Console.ReadLine();
        }
    }

    static class DoAsync
    {
        public static async Task<int> CalCulate(int a,int b)
        {
            int num = await Task.Run(()=>GetNum(a,b));
            return num;
        }
        public static int GetNum(int a,int b )
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+ "  getnum");
            return a + b;
        }
    }
}
