using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int life = 3;
    public GameObject brickPrefab;
    private SpriteRenderer spriteRenderer;
    private Vector2 brickLength;
    public Transform brickContainer;
    private Vector2 startPosition = new Vector2(-8.2f, 4.6f);
    private Vector2 gap = new Vector2(0.1f, 0.1f);

    private int[,] map =
    {
        { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
        { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    public void BrickCollided(Vector2 collisionPosition)
    {
        int x = (int) Math.Ceiling(collisionPosition.y / (brickLength.y + gap.y)) - 6;
        int y = (int) Math.Ceiling(collisionPosition.x / (brickLength.x + gap.x)) + 7;

        map[x, y]--;
    }

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
                    startPosition.x + col * (brickLength.x + gap.x),
                    startPosition.y - row * (brickLength.y + gap.y)
                    );
                
                switch (brickData)
                {
                    case 1:
                        spriteRenderer.color = new Color(255, 255, 255);
                        break;
                    case 2:
                        spriteRenderer.color = new Color(0, 255, 0);
                        break;
                    case 3:
                        spriteRenderer.color = new Color(0, 0, 255);
                        break;
                    case 4:
                        spriteRenderer.color = new Color(255, 0, 255);
                        break;
                    case 5:
                        spriteRenderer.color = new Color(255, 0, 0);
                        break;
                }
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

        brickLength = new Vector2(actualWidth, actualHeight);
        Debug.Log(brickLength);
        
        GenerateMap();
    }
}
