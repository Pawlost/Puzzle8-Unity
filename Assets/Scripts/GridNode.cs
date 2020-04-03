using System;
public class GridNode{    
    private int[][] grid;
    private int layer;

    public int posX {get; private set;}
    public int posY {get; private set;}

    private GridNode prevGrid;

    public GridNode(int posX, int posY, int layer, int[][] grid) {        
        this.posX = posX;
        this.posY = posY;
        this.layer = layer + 1;
        this.grid = grid;
    }

    
    public GridNode(int posX, int posY, GridNode prevGrid) {        
        this.posX = posX;
        this.posY = posY;
        this.prevGrid = prevGrid;
        this.layer = prevGrid.layer + 1;

        this.grid = (int[][]) prevGrid.grid.Clone();
        grid[prevGrid.posX][prevGrid.posY] = grid[posX][posY];
        grid[posX][posY] = 0;
    }

    public bool Equals(GridNode node)
    {
        for(int x = 0; x < grid.Length; x++){
            for(int y = 0; y < grid[x].Length; y++ ){
                if (grid[x][y] != node.grid[x][y]){
                    return false;
                }
            }
        }

        return true;
    }

    public GridNode GetPrevNode(){
        return prevGrid;
    }
}