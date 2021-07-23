using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Plot{
        static int totalPlots; 
        private string owner;
        private Tile parentTile1;
        private Tile parentTile2; 
        private Tile parentTile3; 
        private string plotType;
        private int ID;
        
        public Plot(string o){
            owner = o; 
            ID = totalPlots + 1; 
            totalPlots++; 
            System.Console.WriteLine("New plot created");
            plotType = "s"; 
        }
        public string getPlotType(){
            return plotType;
        }
        public string getOwner(){
            return owner;
        }
        public void setPlotType(string t){
            plotType = t;
        }
    }
}