using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Player{
        private string name;
        private static int numPlayers = 0;
        private Board catanBoard;
        
        public Player(string n, Board b){
            name = n;
            numPlayers++; 
            catanBoard = b;
        }

        public void placeRoad(int targetTile, int edgeNum){
            Tile selectedTile = catanBoard.getBoardList()[targetTile];
            selectedTile.placeRoad(name, edgeNum); 
        }      

        public void placeSettlement(int targetTile, int vertexNum){
            Tile selectedTile = catanBoard.getBoardList()[targetTile];
            selectedTile.placeSettlement(name, vertexNum); 
        }
        public void placeCity(int targetTile, int vertexNum){
            Tile selectedTile = catanBoard.getBoardList()[targetTile];
            selectedTile.placeCity(name, vertexNum);
        }
    }
}