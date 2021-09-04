using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinateCoordinates;

    Node startNode;
    Node destinateNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached;

    Vector2Int[] directions = { Vector2Int.right , Vector2Int.left , Vector2Int.up , Vector2Int.down };
    GridManager gridManger;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int,Node>();

    void Awake()
    {
        gridManger = FindObjectOfType<GridManager>();
        if(gridManger != null)
        {
            grid = gridManger.Grid;
        }
        startNode =new Node(startCoordinates , true);
        destinateNode = new Node(destinateCoordinates , true);
    }
    void Start()
    {
        BreadthFirstSearch();
    }
    void ExploreNeighbords()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            
            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

            }
        }
        foreach (Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }
    void BreadthFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue(); 
            currentSearchNode.isExplored = true;
            ExploreNeighbords();
            if(currentSearchNode.coordinates == destinateCoordinates)
            {
                isRunning=false;
            }
        }
    }
}
