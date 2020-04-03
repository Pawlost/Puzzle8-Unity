using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private GridNode start;
    private GridNode final;
    private Queue<GridNode> checkNodes;
    private Queue<GridNode> newNodes;
    private List<GridNode> results;

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
        if(checkNodes.Count > 0 && newNodes.Count > 0){
            if(checkNodes.Count == 0){
                checkNodes = newNodes;
                newNodes = new Queue<GridNode>();
            }

            GridNode node = checkNodes.Dequeue();
            if(node.Equals(final)){
                do {
                    results.Add(node);
                    node = node.GetPrevNode();
                } while (node.GetPrevNode() != null);

                checkNodes = new Queue<GridNode>();
                newNodes = new Queue<GridNode>();
            } else{
                FindNodes(node, newNodes);
            }            
        }
    }

    private static void FindNodes(GridNode prevNode, Queue<GridNode> queue){
        if(prevNode.posX - 1 >= 0){
            queue.Enqueue(new GridNode(prevNode.posX - 1, prevNode.posY, prevNode));
        }else if(prevNode.posX + 1 <= 2){
            queue.Enqueue(new GridNode(prevNode.posX + 1, prevNode.posY, prevNode));
        }

        if(prevNode.posY - 1 >= 0){
            queue.Enqueue(new GridNode(prevNode.posX, prevNode.posY - 1, prevNode));
        }else if(prevNode.posY + 1 <= 2){
            queue.Enqueue(new GridNode(prevNode.posY, prevNode.posY + 1, prevNode));
        }
    }

    public void Stop(){

    }

    public void BruteForce(){
        Queue<GridNode> localNodes  = new Queue<GridNode>();

    }

    public void Heuristics(){}
}
