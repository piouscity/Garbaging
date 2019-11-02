using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fish : MonoBehaviour
{

    
    private int direction;
    float speed;

    Vector2 posTemp;


    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        direction = random.Next(1,10);

        string fishName = this.gameObject.name;
        if (fishName.Contains("fish_01"))
        {
            speed = GameManager.instance.speed_of_fish(1);
        }
        else if (fishName.Contains("fish_02"))
        {
            speed = GameManager.instance.speed_of_fish(2);
        }
        else
        {
            speed = GameManager.instance.speed_of_fish(3);
        }

        posTemp = GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        if (direction % 2 == 1)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
        GetComponent<Transform>().position = posTemp;

        if (GetComponent<Transform>().position.x >= 15 || GetComponent<Transform>().position.x <= -15)
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
