namespace Nodes{
public class GridNode {    
    public int[,] grid {get; private set;}
    public int posX {get; private set;}
    public int posY {get; private set;}

    private GridNode prevGrid;

    public GridNode(int posX, int posY, int[,] grid) {        
        this.posX = posX;
        this.posY = posY;
        this.grid = grid;
    }

    
    public GridNode(int posX, int posY, GridNode prevGrid) {        
        this.posX = posX;
        this.posY = posY;
        this.prevGrid = prevGrid;

        this.grid = prevGrid.grid.Clone() as int[,];
        grid[prevGrid.posX, prevGrid.posY] = grid[posX, posY];
        grid[posX, posY] = 0;
    }

    public bool Equals(GridNode node)
    {
        for(int x = 0; x < 3; x++){
            for(int y = 0; y < 3; y++ ){
                if (grid[x, y] != node.grid[x, y]){
                    return false;
                }
            }
        }

        return true;
    }

    public GridNode GetPrevNode(){
        return prevGrid;
    }

    public override string ToString(){
        string s = "";
        for(int y = 0; y < 3; y++){
            for(int x = 0; x < 3; x++){
                s += grid[x, y];
            }
            s += "\n";
        }

        return s;
    } 
}
}