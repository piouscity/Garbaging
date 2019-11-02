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

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 posTemp = GetComponent<Transform>().position;
        if (direction == 1)
        {
            posTemp.x += speed;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            posTemp.x -= speed;
        }
        GetComponent<Transform>().position = posTemp;
    }
}
