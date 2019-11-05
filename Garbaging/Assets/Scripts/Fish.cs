using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public FishController manager;
    private int direction;
    public float speed = 0.01f;
    public bool isRight = false;

    Vector2 posTemp;


    // Start is called before the first frame update
    void Start()
    {
        posTemp = GetComponent<Transform>().position;
        if (posTemp.x <= -GameManager.instance.minX) {
            isRight = true;
        }

        speed = speed * Mathf.Pow(1.2f, GameManager.instance.level) + (float)(Random.Range(1,3) * 1.0 / 100);

    }
    public int temp = 1;
    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.level >= 3)
        {
            temp += 1;
            System.Random random = new System.Random();
            if (temp % 180 == 0 && random.Next(24) % 15 == 0)
            {
                isRight = !isRight;
            }
        }
        if (isRight)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
        GetComponent<Transform>().position = posTemp;

        if (GetComponent<Transform>().position.x >= GameManager.instance.maxX || GetComponent<Transform>().position.x <= -GameManager.instance.maxX)
        {
            Destroy(this.gameObject);
            manager.RemoveFish(gameObject);
        }
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
}
