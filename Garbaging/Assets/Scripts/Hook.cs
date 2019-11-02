using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    bool isLeft = true;
    bool isMove = true;
    float speed;
    float distance;
    float temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.02f;
        distance = 7.93f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Vector2 posTemp = GetComponent<Transform>().position;

            if (isLeft)
            {
                posTemp.x -= speed;
                temp += speed;
                if (temp > distance)
                {
                    isLeft = false;
                    temp = 0;
                    distance *= 2;
                }
            }
            else
            {
                posTemp.x += speed;
                temp += speed;
                if (temp > distance)
                {
                    isLeft = true;
                    temp = 0;
                }
            }
            GetComponent<Transform>().position = posTemp;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = !isMove;
        }
    }
}
