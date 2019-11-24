using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameManager gameManager;
    public FishController manager;
    private int direction;
    public const float BASE_SPEED = 0.01f;
    public const float SPEED_UP = 1.2f;
    public float speed;
    public bool movingRight = false;

    Vector2 posTemp;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        posTemp = GetComponent<Transform>().position;
        if (posTemp.x <= gameManager.minX) {
            movingRight = true;
        }
        float randomAppend = Random.Range(0, 4) * 1f / 100;
        speed = BASE_SPEED + randomAppend;
    }
    public int temp = 1;
    // Update is called once per frame
    void Update()
    {

        if (gameManager.level >= 3)
        {
            temp += 1;
            System.Random random = new System.Random();
            if (temp % 180 == 0 && random.Next(24) % 15 == 0)
            {
                movingRight = !movingRight;
            }
        }
        if (movingRight)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
        GetComponent<Transform>().position = posTemp;
     
        if (screenPassed())
        {
            Destroy(gameObject);
            manager.RemoveFish(gameObject);
        }
    }

    public void UpdateLevel(int level)
    {
        float randomAppend = Random.Range(0, 4) * 1f / 100;
        speed = BASE_SPEED * Mathf.Pow(SPEED_UP, level) + randomAppend;
    }

    void moveLeft()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        posTemp.x -= speed;
    }

    void moveRight()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        posTemp.x += speed;
    }

    bool screenPassed()
    {
        if (movingRight)
            return posTemp.x > gameManager.maxX;
        else
            return posTemp.x < gameManager.minX;
    }
}
