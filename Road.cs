using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Road{
        private string owner; 
        private static int numRoads;

        public Road(string o){
            owner = o;
            System.Console.WriteLine("New road created");
        }
    }
}