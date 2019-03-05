using System;
using System.Reflection;

namespace ConsoleApplication1 {

    class Program {
        static void Main(string[] args) {
            var DLL = Assembly.LoadFile(@"C:\BirdWatcher.dll");

            Console.WriteLine(DLL.GetCustomAttributesData());

        }
    }
}
