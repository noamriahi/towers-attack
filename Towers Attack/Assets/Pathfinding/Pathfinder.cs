using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right , Vector2Int.left , Vector2Int.up , Vector2Int.down };
    GridManager gridManger;
    Dictionary<Vector2Int, Node> grid;
    void Awake()
    {
        gridManger = FindObjectOfType<GridManager>();
        if(gridManger != null)
        {
            grid = gridManger.Grid;
        }
    }
    void Start()
    {
        Exploreneighbords();
    }
    void Exploreneighbords()
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
    }

}
