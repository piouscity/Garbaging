using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterball;


    void createWaterBall()
    {
        GameManager.instance.listWaterBall.Add((GameObject)Instantiate(waterball, new Vector2(Random.Range(-GameManager.instance.screenHeight, GameManager.instance.screenHeight), GameManager.instance.minY - 0.5f), Quaternion.identity));

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.Random random = new System.Random();

        if (random.Next(200) % 200 == 0)
        {
            createWaterBall();
        }
    }
}
