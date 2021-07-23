using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Road{
        private string owner; 
        private Tile parentTile1; 
        private Tile parentTile2; 
        private int ID; 
        private static int totalRoads;

        public Road(string o, Tile t){
            owner = o;
            parentTile1 = t; 
            System.Console.WriteLine("New road created");
            ID = totalRoads + 1;
            totalRoads++; 
        }
        public void addParentTile(Tile t){
            parentTile2 = t; 
        }
    }
}