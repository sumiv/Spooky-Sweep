using UnityEngine;
using UnityEngine.Tilemaps;


public class GridManager : MonoBehaviour
{
    public Tilemap tilemap; // Assign your Tilemap in the Inspector
    public int gridWidth, gridHeight; // Set based on your maze size
    public Node[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Vector3Int origin = tilemap.cellBounds.min; // Get the origin of the Tilemap
        grid = new Node[gridWidth, gridHeight];

        // Manually apply an estimated offset (adjust as needed)
        float offsetX = -850.0f; // Tilemap's bottom-left X position in world space
        float offsetY = -520.0f; // Tilemap's bottom-left Y position in world space

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x + origin.x, y + origin.y, 0); // Add Tilemap origin offset
                TileBase tile = tilemap.GetTile(cellPosition);

                // Adjust the world position of each grid node using the estimated offset
                Vector3 worldPosition = tilemap.GetCellCenterWorld(cellPosition);
                worldPosition.x += offsetX;
                worldPosition.y += offsetY;

                grid[x, y] = new Node
                {
                    position = worldPosition, // Apply adjusted position
                    isWalkable = tile == null || tilemap.GetColliderType(cellPosition) == Tile.ColliderType.None
                };
            }
        }
    }

    void OnDrawGizmos()
    {
        if (grid == null) return;

        foreach (Node node in grid)
        {
            Gizmos.color = node.isWalkable ? Color.green : Color.red;
            Gizmos.DrawWireCube(node.position, Vector3.one * 0.5f);
        }
    }

}
