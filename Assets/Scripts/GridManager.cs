using UnityEngine;
using UnityEngine.Tilemaps;


public class GridManager : MonoBehaviour
{
    public Tilemap tilemap; 
    public int gridWidth, gridHeight; 
    public Node[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // tilemap origin
        Vector3Int origin = tilemap.cellBounds.min;
        grid = new Node[gridWidth, gridHeight];

        //apply offset, estimated
        float offsetX = -850.0f;
        float offsetY = -520.0f; 

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x + origin.x, y + origin.y, 0);
                TileBase tile = tilemap.GetTile(cellPosition);

                // adjust world pos using offset
                Vector3 worldPosition = tilemap.GetCellCenterWorld(cellPosition);
                worldPosition.x += offsetX;
                worldPosition.y += offsetY;

                grid[x, y] = new Node
                {
                    position = worldPosition, 
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
