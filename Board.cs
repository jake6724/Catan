using System;
using System.Collections.Generic;


namespace CatanTesting
{
    public class Board{
        const int TILE_AMOUNT = 19; 

        private Tile[] boardList = new Tile[TILE_AMOUNT]; 
        
        public Board(){
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
        
        public void printBoard(){
            //System.Console.WriteLine(boardDict.Count);
            for(int i=0; i < boardList.Length; i++){
                Tile currentTile = boardList[i];
                
                System.Console.WriteLine("Tile Num: " + i + " Biome: " + currentTile.getBiome() + " Roll num: " + currentTile.getRollNum()); 
                
            } 
                
        }
        
    }
} 