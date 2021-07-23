using System;

namespace CatanTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CATAN TEST 1.0 STARTED ! XDDD");
            Board b = new Board(); 
            
            Player p = new Player("Fart noise", b); 

            // p.placeRoad(18, 0); 
            // p.placePlot(18, 0); 
            p.placeSettlement(17, 2);
            p.placeCity(17,2);
            stressTest(p); 
            // p.placePlot(0,0); 
            // p.placeRoad(0,0); 
            b.printBoard(); 
        }

        public static void stressTest(Player p){
            int stressTestNum = 100;
            for(int i=0;i<stressTestNum;i++){
                System.Random random = new Random();
                int itemToPlace = random.Next(0,3);
                if(itemToPlace == 0){
                    int randTile = random.Next(0,19);
                    int randLocation = random.Next(0,6);
                    p.placeRoad(randTile,randLocation);
                }
                else if(itemToPlace == 2){
                    int randTile = random.Next(0,19);
                    int randLocation = random.Next(0,6);
                    p.placeSettlement(randTile,randLocation);
                }
                else{
                    int randTile = random.Next(0,19);
                    int randLocation = random.Next(0,6);
                    p.placeCity(randTile,randLocation);
                }
            }
        }
    }
}
