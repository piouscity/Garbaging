using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
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

        speed = speed * (float)(1 + GameManager.instance.level * 2.0 / 10) + (float)(Random.Range(1,3) * 1.0 / 100);

    }

    // Update is called once per frame
    void Update()
    {
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
            GameManager.instance.fishList.Remove(this.gameObject);
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
