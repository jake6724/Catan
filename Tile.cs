using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Tile
    {
        private string biome;
        private string resource;
        private int rollNum;
        private char[] roads;
        private char[] plots;
        private Tile[] neighbors;   // TL, TR, R, BR, BL, L
    
        //creates tile with biome and roll number        
        public Tile(int biomeID, int rn){
            neighbors = new Tile[6];
            roads = new char[]{'-','-','-','-','-','-'};
            plots = new char[]{'-','-','-','-','-','-'};
            rollNum = rn;
            if(biomeID == 0){
                biome = "Desert";
                resource = "";
            }
            else if(biomeID == 1){
                biome = "Field";
                resource = "Wheat";
            }
            else if(biomeID == 2){
                biome = "Forest";
                resource = "Wood";
            }
            else if(biomeID == 3){
                biome = "Pasture";
                resource = "Wool";
            }
            else if(biomeID == 4){
                biome = "Mountain";
                resource = "Stone";
            }
            else if(biomeID == 5){
                biome = "Hills";
                resource = "Brick";
            }
            else{
                biome = "BIOME ERROR";
                resource = "BIOME ERROR";
            }
        }
        
        //buys a plot of land on a tile vertex
        public void buyPlot(char player,int index){
            plots[index] = player;
        }
        //buys a road on a tile edge
        public void buyRoad(char player,int index){
            roads[index] = player;
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
        //gets array of roads on tile edges
        public char[] getRoads(){
            return roads;
        }
        //gets array of plots on tile verticies
        public char[] getPlots(){
            return plots;
        }
        public void setNeighbors(Tile[] n){
            neighbors = n;
        }
    }
}