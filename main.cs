using System;

namespace CatanTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CATAN TEST 1.0 STARTED ! XDDD");
            Board b = new Board(); 
            System.Console.WriteLine("printing board");
            //b.printBoard(); 
            b.assignNeighbors(); 
        }
    }
}
