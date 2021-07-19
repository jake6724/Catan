using System;
using System.Collections.Generic;


namespace CatanTesting
{
    public class Board{
        const int TILE_AMOUNT = 19; 

        private Tile[] boardList = new Tile[TILE_AMOUNT]; 
        
        public Board(){ // Create board array and the 19 tiles in it. Assign biomes and roll numbers to tiles 
            int i = 0;
            int[] biomes = new int[] {1,4,4,4,3,3}; 
            // 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            int[] tokens = new int[] {1,2,2,2,2,2,2,2,2,2,1};
            System.Random random = new Random();
            while(i<TILE_AMOUNT){
                int randBiome = random.Next(0,6); 
                if(biomes[randBiome] > 0){
                    int randRoll = random.Next(11);
                    if(tokens[randRoll] > 0){
                        Tile newTile = new Tile(randBiome,randRoll + 2); 
                        boardList[i] = newTile; 
                        biomes[randBiome]--; 
                        tokens[randRoll]--;
                        i++; 
                    }
                }
            }
        }
        
        public void assignNeighbors(){
            //Creates a matrix that holds info for each tile
            //Each row holds all the tiles adjacent to the tile that corresponds to that row 
            //The order of the tiles in each nested array goes: TL, TR, R, BR, BL, L
            //For example, row 8 col 2 means that Tile 8's right neighbor is Tile 7 
            //-1 means that there is no adjacent tile (e.i. the ocean)  
            // https://docs.google.com/document/d/1dCXnQiFnNOuL8PT5slNLIaF11khN5o4v9yQxWKomoI0/edit?usp=sharing

            int[,] tileNeighbors = 
            {
                {-1,-1,1,12,11,-1}, //0
                {-1,-1,2,13,12,0}, //1
                {-1,-1,-1,3,13,1}, //2
                {2,-1,-1,4,14,13}, //3
                {3,-1,-1,-1,5,14}, //4
                {14,4,-1,-1,6,15}, //5
                {15,5,-1,-1,-1,7}, //6
                {16,15,6,-1,-1,8}, //7
                {9,16,7,-1,-1,-1}, //8
                {10,17,16,8,-1,-1}, //9
                {-1,11,17,9,-1,-1}, //10
                {-1,0,12,17,10,-1}, //11
                {0,1,13,18,17,11}, //12
                {1,2,3,14,18,12}, //13
                {13,3,4,5,15,8}, //14
                {18,14,5,6,7,16}, //15
                {17,18,15,7,8,9}, //16
                {11,12,18,16,9,10}, //17
                {12,13,14,15,16,17} //18
            };
            
            //iterates through tileNeighbors array created above, 1 row at a time
            //if value is -1, add null to temp array, otherwise add Tile of given ID
                    //ex. if tileNeighbors[i,j] == 4, then add boardList[4] to temp
            //once inner loop is complete, temp is populated with a row of tiles and/or NULLs
            //sets tile neighbors to temp array
            for(int i=0;i<19;i++){
                Tile[] temp = new Tile[6];
                for(int j=0;j<6;j++){
                    if(tileNeighbors[i,j] == -1){
                        temp[j] = null;
                    }
                    else{
                        temp[j] = boardList[tileNeighbors[i,j]];
                    }
                }
                boardList[i].setNeighbors(temp);
            }
            for(int i=0;i<19;i++){
                System.Console.Write(i + ": ");
                boardList[i].printNeighbors();
            }
            
            
            
        }
        public void printBoard(){
            for(int i=0; i < boardList.Length; i++){
                Tile currentTile = boardList[i];
                
                System.Console.WriteLine("Tile Num: " + i + " Biome: " + currentTile.getBiome() + " Roll num: " + currentTile.getRollNum()); 
                
            } 
        }  

        public Tile[] getBoardList(){
            return boardList; 
        }
        
    }
} 