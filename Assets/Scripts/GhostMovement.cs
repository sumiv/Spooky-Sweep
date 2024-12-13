using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Pathfinding pathfinding;
    public GridManager gridManager;
    public float speed = 2.0f;

    private List<Node> path;
    private int targetIndex;

    void Update()
    {
        // Pass the grid from GridManager to Pathfinding
        path = pathfinding.FindPath(transform.position, pathfinding.player.position);

        if (path != null && path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    void MoveAlongPath()
    {
        if (targetIndex >= path.Count) return;

        Vector2 targetPosition = path[targetIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if ((Vector2)transform.position == targetPosition)
        {
            targetIndex++;
        }
    }
}
