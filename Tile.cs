using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Tile
    {
        private string biome;
        private string resource;
        private int rollNum;
        private char[] plots;
        private Road[] edges; 
        private Tile[] neighbors;   // TL, TR, R, BR, BL, L
    
        //creates tile with biome and roll number        
        public Tile(int biomeID, int rn){
            neighbors = new Tile[6];
            plots = new char[]{'-','-','-','-','-','-'};
            rollNum = rn;
            switch(biomeID){
                case 0:
                    biome = "Desert";
                    resource = "";
                    break;
                case 1:
                    biome = "Field";
                    resource = "Wheat";
                    break;
                case 2:
                    biome = "Forest";
                    resource = "Wood";
                    break;
                case 3:
                    biome = "Pasture";
                    resource = "Wool";
                    break;
                case 4:
                    biome = "Mountain";
                    resource = "Stone";
                    break;
                case 5:
                    biome = "Hills";
                    resource = "Brick";
                    break;
                default:
                    biome = "BIOME ERROR";
                    resource = "BIOME ERROR";
                    break;
            }
            edges = new Road[6];  
        }
        
      
        //places a road on a tile edge
        public void placeRoad(string owner, int edgeNum){
            Road newRoad = new Road(owner); 
            edges[edgeNum] = newRoad; 
            addRoadToNeighbor(edgeNum, owner, newRoad); //adds road to correct neighborEdge 
        }

        public void addRoadToNeighbor(int edgeNum, string owner, Road newRoad){
            Tile adjTile = neighbors[edgeNum]; 
            Road[] adjEdges = adjTile.getEdges(); 

            if(edgeNum <= 2){
                adjEdges[edgeNum + 3] = newRoad; 
            }
            else if(edgeNum >= 3){
                adjEdges[edgeNum - 3] = newRoad;
            }         
        }
        
        public void printNeighbors(){
            for(int i=0;i<neighbors.Length;i++){
                if(neighbors[i] != null){
                    Console.Write(neighbors[i].biome + ", ");
                }
                else{
                    System.Console.Write("NULL, ");
                }
        
            }
            System.Console.WriteLine();
        }
        
        //gets tile biome
        public string getBiome(){
            return biome;
        }
        //gets tile roll number
        public int getRollNum(){
            return rollNum;
        }
        //gets array of plots on tile verticies
        public char[] getPlots(){
            return plots;
        }
        //sets array of neighbor Tiles
        public void setNeighbors(Tile[] n){
            neighbors = n;
        }
        //returns edges (Roads) of a tile
        public Road[] getEdges(){
            return edges; 
        }
    }
}