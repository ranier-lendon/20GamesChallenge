using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int life = 3;
    public GameObject brickPrefab;
    private SpriteRenderer spriteRenderer;
    private Vector2 brickLength;
    public Transform brickContainer;
    private Vector2 startPosition = new Vector2(-8.2f, 4.6f);
    private Vector2 gap = new Vector2(0.55f, -0.55f);

    private int[,] map =
    {
        { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
        { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    void GenerateMap()
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                int brickData = map[row, col];
                
                // Prevents generating cells with 0 value
                if (brickData == 0) continue;
                
                Vector2 pos = new Vector2(
                    startPosition.x + brickLength.x * col * gap.x, 
                    startPosition.y + brickLength.y * 2 * row * gap.y
                    );
                
                Instantiate(brickPrefab, pos, Quaternion.identity, brickContainer);
            }
        }
    }

    void Start()
    {
        BoxCollider2D col = brickPrefab.GetComponent<BoxCollider2D>();
        spriteRenderer = brickPrefab.GetComponent<SpriteRenderer>();

        float actualWidth = col.size.x * brickPrefab.transform.localScale.x;
        float actualHeight = col.size.y * brickPrefab.transform.localScale.y;

        brickLength = new Vector2(actualWidth, actualHeight)*2;
        Debug.Log(brickLength);
        
        GenerateMap();
    }
}
