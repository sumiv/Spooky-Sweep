using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform player; // The target
    public Transform ghost; // The AI
    public GridManager gridManager; // Reference to GridManager

    public List<Node> FindPath(Vector2 startPos, Vector2 targetPos)
    {
        Node[,] grid = gridManager.grid;
        Node startNode = GetNodeFromPosition(startPos, grid);
        Node targetNode = GetNodeFromPosition(targetPos, grid);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FCost < currentNode.FCost ||
                    (openSet[i].FCost == currentNode.FCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbor in GetNeighbors(currentNode, grid))
            {
                if (!neighbor.isWalkable || closedSet.Contains(neighbor))
                    continue;

                float newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null; // No path found
    }

    Node GetNodeFromPosition(Vector2 position, Node[,] grid)
    {
        int x = Mathf.Clamp(Mathf.RoundToInt(position.x), 0, grid.GetLength(0) - 1);
        int y = Mathf.Clamp(Mathf.RoundToInt(position.y), 0, grid.GetLength(1) - 1);
        return grid[x, y];
    }


    List<Node> GetNeighbors(Node node, Node[,] grid)
    {
        List<Node> neighbors = new List<Node>();
        // Add logic for neighbors (up, down, left, right)
        return neighbors;
    }

    float GetDistance(Node a, Node b)
    {
        int dstX = Mathf.Abs(Mathf.RoundToInt(a.position.x) - Mathf.RoundToInt(b.position.x));
        int dstY = Mathf.Abs(Mathf.RoundToInt(a.position.y) - Mathf.RoundToInt(b.position.y));
        return dstX + dstY;
    }

    List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }
}
