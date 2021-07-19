using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Player{
        private string name;
        private static int numPlayers = 0;
        
        public Player(string n){
            name = n;
            numPlayers++; 
        }

        public void placeRoad(int selectedTile, int edgeNum){
            Board b = new Board();
            Tile[] myBoardList = b.getBoardList();
            Tile myTile = myBoardList[selectedTile];
            myTile.placeRoad(name, edgeNum); 

            Road[] myTileEdges = myTile.getEdges(); 
            System.Console.WriteLine("Selected Tile Edges: ");
            for(int i=0; i<myTileEdges.Length; i++){
                System.Console.WriteLine(i + ": " + myTileEdges[i]);
            }
            
        }
    }
}