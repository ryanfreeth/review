using System;
using static System.Console;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            void Print() => list.Traverse(n => WriteLine(n));
            list.Append(1);
            var two = list.Append(2);
            list.Append(3);
            Print();
            WriteLine("Inserting 5...");
            list.InsertAt(two, 5);
            Print();
            WriteLine("Removing 2...");
            list.Remove(two);
            Print();
        }
    }
}
