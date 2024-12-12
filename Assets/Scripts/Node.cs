using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 position;
    public bool isWalkable;
    public Node parent;
    public float gCost; // Cost from start
    public float hCost; // Heuristic (distance to goal)
    public float FCost => gCost + hCost;
}

