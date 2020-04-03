using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nodes;

public class Root : MonoBehaviour
{
    private GridNode final;
    private Queue<GridNode> checkNodes;
    private Queue<GridNode> newNodes;

    public Metrix inputMatrix;
    public Metrix outputMatrix;
    public GameObject content;
    private List<GridNode> results;
    public Button stepButton;

    // Start is called before the first frame update
    void Start()
    {
        checkNodes = new Queue<GridNode>();
        newNodes = new Queue<GridNode>();
        results = new List<GridNode>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkNodes.Count > 0 || newNodes.Count > 0){
            if(checkNodes.Count == 0){
                checkNodes = newNodes;
                newNodes = new Queue<GridNode>();
            }

            GridNode node = checkNodes.Dequeue();
            if(node.Equals(final)){
                results.Clear();
                results.Add(node);
                while (node.GetPrevNode() != null) {
                    results.Add(node);
                    node = node.GetPrevNode();
                } 

                checkNodes = new Queue<GridNode>();
                newNodes = new Queue<GridNode>();

                results.Reverse();

                ShowResults();
            } else{
                Debug.Log(node.ToString());
                FindNodes(node, newNodes);
            }            
        }
    }

    private void ShowResults(){
        for(int i = 0; i < results.Count; i++){
            Button button = Instantiate(stepButton) as Button;
            button.transform.SetParent(content.transform);
            button.transform.localPosition.Set(0, 0, 0);
            button.GetComponentInChildren<Text>().text = "Step: " + i;
            button.onClick.AddListener(() => {inputMatrix.ShowGrid(results[i].grid);});
        }
    }

    private static void FindNodes(GridNode prevNode, Queue<GridNode> queue){
        if(prevNode.posX - 1 >= 0){
            queue.Enqueue(new GridNode(prevNode.posX - 1, prevNode.posY, prevNode));
        }
        
        if(prevNode.posX + 1 <= 2){
            queue.Enqueue(new GridNode(prevNode.posX + 1, prevNode.posY, prevNode));
        }

        if(prevNode.posY - 1 >= 0){
            queue.Enqueue(new GridNode(prevNode.posX, prevNode.posY - 1, prevNode));
        }
        
        if(prevNode.posY + 1 <= 2){
            queue.Enqueue(new GridNode(prevNode.posY, prevNode.posY + 1, prevNode));
        }
    }

    public void Stop(){
        checkNodes = new Queue<GridNode>();
        newNodes = new Queue<GridNode>();
    }

    public void BruteForce(){
        final = GetGridFromMatrix(outputMatrix);
        newNodes.Enqueue(GetGridFromMatrix(inputMatrix));
    }

    public void Heuristics(){}

    private GridNode GetGridFromMatrix(Metrix metrix){
        int[,]  grid =  metrix.MakeGrid();
        for(int x = 0; x < 3; x++){
            for(int y = 0; y < 3; y++){
                if(grid[x, y] == 0){
                    return new GridNode(x, y, grid);
                }
            }
        }

        return null;
    }
}
