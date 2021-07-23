using System;
using System.Collections.Generic;

namespace CatanTesting
{
    public class Tile
    {
        private string biome;
        private string resource;
        private int rollNum;
        private Road[] edges; 
        private Plot[] vertices; 
        private Tile[] neighbors;   // TL, TR, R, BR, BL, L
    
        //creates tile with biome and roll number        
        public Tile(int biomeID, int rn){
            neighbors = new Tile[6];
            vertices = new Plot[6];
            edges = new Road[6];  
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
        }
        
        //places a road on a tile edge
        public void placeRoad(string owner, int edgeNum){
            if(edges[edgeNum] != null){
                System.Console.WriteLine("Road already exists here!");
                return;
            }
            
            Road newRoad = new Road(owner, this); 
            edges[edgeNum] = newRoad; 
            addRoadToNeighbor(edgeNum, owner, newRoad); //adds road to correct neighborEdge 
        }

        public void addRoadToNeighbor(int edgeNum, string owner, Road newRoad){
            Tile adjTile = neighbors[edgeNum]; 
            newRoad.addParentTile(adjTile); 
            //if neighbor is not a tile(ocean), return
            if(adjTile == null){
                return;
            }

            Road[] adjEdges = adjTile.getEdges();
            
            if(edgeNum <= 2){
                adjEdges[edgeNum + 3] = newRoad; 
            }
            else if(edgeNum >= 3){
                adjEdges[edgeNum - 3] = newRoad;
            }         
        }

        public void placeSettlement(string owner, int vertexNum){
            //put a settlement on the correct vertex of the selected tile
            //update vertices for 2 adjacent tiles, pointing to the new plot object 
            if(vertices[vertexNum] != null){
                System.Console.WriteLine("Plot already exists here!");
                return; 
            }
            Plot newPlot = new Plot(owner); 
            vertices[vertexNum] = newPlot;
            addSettlementToNeighbors(vertexNum, owner, newPlot); 
        }

        public void addSettlementToNeighbors(int vertexNum, string owner, Plot newPlot){ 
            Tile adjTile1 = null; 
            Tile adjTile2 = null; 
            /*
            Check if the adjacent tile is null, if so create the tile based on neighbors array
            Formula is targetVertices = (vertexNum - 1 , vertexNum)
            Unless the vertexNum = 0 then the formula is targetVertices = (5, vertexNum)
            targetVertices is the index that will be taken in neighbors, ex. neighbors[targetVertex]
            */ 
            if(vertexNum != 0){
                if(neighbors[vertexNum -1] != null){
                    adjTile1 = neighbors[vertexNum - 1];
                }
                if(neighbors[vertexNum] != null){
                    adjTile2 = neighbors[vertexNum];      
                }    
            }
            else{
                if(neighbors[5] != null){
                    adjTile1 = neighbors[5];
                }
                if(neighbors[vertexNum] != null){
                    adjTile2 = neighbors[vertexNum];      
                }    
            }
            
            if(vertexNum % 2 == 0){    // if vertex num even 
                int n = vertexNum;
                
                //points vertex of adjTile1 to newPlot
                //if index is 4, wrap next plot location around to 0
                //otherwise increment by 2 ex. 0 -> 2
                if(adjTile1 != null){
                    if(n == 4){
                        n = 0;     
                        adjTile1.getVertices()[n] = newPlot; 
                    }
                    else{
                        n += 2;
                        adjTile1.getVertices()[n] = newPlot;
                    }
                }
                //points vertex of adjTile2 to newPlot
                if(adjTile2 != null){
                    if(n == 4){
                        n = 0;     
                        adjTile2.getVertices()[n] = newPlot; 
                    }
                    else{
                        n += 2;
                        adjTile2.getVertices()[n] = newPlot;
                    }
                }
            }
            else{
                int n = vertexNum;

                //points vertex of adjTile1 to newPlot
                //if index is 5, wrap next plot location around to 1
                //otherwise increment by 2 ex. 1 -> 3
                if(adjTile1 != null){
                    if(n == 5){
                        n = 1;     
                        adjTile1.getVertices()[n] = newPlot; 
                    }
                    else{
                        n += 2;
                        adjTile1.getVertices()[n] = newPlot;
                    }
                }
                //points vertex of adjTile2 to newPlot
                if(adjTile2 != null){
                    if(n == 5){
                        n = 1;     
                        adjTile2.getVertices()[n] = newPlot; 
                    }
                    else{
                        n += 2;
                        adjTile2.getVertices()[n] = newPlot;
                    }
                }
            }
        }
        

        //check if a settlement exists there
        //check if owner is the same 
        public void placeCity(string owner, int vertexNum){
            if(vertices[vertexNum] == null){
                System.Console.WriteLine("You must place a settlement here first!");
                return;
            }     
            if(vertices[vertexNum].getOwner() != owner){
                System.Console.WriteLine("You don't own this settlement!");
                return;
            }
            if(vertices[vertexNum].getPlotType() == "c"){
                System.Console.WriteLine("You already have a city here!");
                return;
            }

            vertices[vertexNum].setPlotType("c"); 
            System.Console.WriteLine("Upgraded settlement to city!");
        }
    

        // Print functions 
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
        
        //getters and setters 
        //gets tile biome
        public string getBiome(){
            return biome;
        }
        //gets tile roll number
        public int getRollNum(){
            return rollNum;
        }
        //sets array of neighbor Tiles
        public void setNeighbors(Tile[] n){
            neighbors = n;
        }
        //returns edges (Roads) of a tile
        public Road[] getEdges(){
            return edges; 
        }
        public Plot[] getVertices(){
            return vertices; 
        }
    }
}