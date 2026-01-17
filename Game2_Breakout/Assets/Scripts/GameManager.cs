using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int life = 3;
    public GameObject bricks;
    private int brickCount;

    void Start()
    {
        brickCount = bricks.transform.childCount;
    }
}
