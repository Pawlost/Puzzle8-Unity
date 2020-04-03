using UnityEngine;
using UnityEngine.UI;

public class Metrix : MonoBehaviour{
    public InputField cell;
    public InputField cell1;
    public InputField cell2;
    public InputField cell3;
    public InputField cell4;
    public InputField cell5;
    public InputField cell6;
    public InputField cell7;
    public InputField cell8;
    
   public int[,] MakeGrid()
    {
        int[,] grid = new int[3,3];

        grid[0, 0] = int.Parse(cell.text);
        grid[0, 1] = int.Parse(cell3.text);
        grid[0, 2] = int.Parse(cell6.text);

        grid[1, 0] = int.Parse(cell1.text);
        grid[1, 1] = int.Parse(cell4.text);
        grid[1, 2] = int.Parse(cell7.text);

        grid[2, 0] = int.Parse(cell2.text);
        grid[2, 1] = int.Parse(cell5.text);
        grid[2, 2] = int.Parse(cell8.text);

        return grid;
    }

    public void ShowGrid(int[,] grid){
        cell.text = grid[0, 0].ToString();
        cell1.text = grid[1, 0].ToString();
        cell2.text = grid[2, 0].ToString();
        cell3.text = grid[0, 1].ToString();
        cell4.text = grid[1, 1].ToString();
        cell5.text = grid[2, 1].ToString();
        cell6.text = grid[0, 2].ToString();
        cell7.text = grid[1, 2].ToString();
        cell8.text = grid[2, 2].ToString();
    }
}