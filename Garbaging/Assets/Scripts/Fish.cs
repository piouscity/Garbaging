using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fish : MonoBehaviour
{

    public float speed_fish_01 = 0.01f;
    public float speed_fish_02 = 0.02f;
    public float speed_fish_03 = 0.03f;
    private int direction;
    float speed;

    Vector2 posTemp;


    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        direction = random.Next(2);

        string fishName = this.gameObject.name;
        if (fishName.Contains("fish_01"))
        {
            speed = speed_fish_01;
        }
        else if (fishName.Contains("fish_02"))
        {
            speed = speed_fish_02;
        }
        else
        {
            speed = speed_fish_03;
        }

        posTemp = GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
        GetComponent<Transform>().position = posTemp;

        if (GetComponent<Transform>().position.x >= 9 || GetComponent<Transform>().position.x <= -9)
        {
            Destroy(this.gameObject);
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
