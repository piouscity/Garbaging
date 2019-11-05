using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterball;
    private List<GameObject> listWaterBall;

    void CreateWaterBall()
    {
        GameObject newWaterBall = Instantiate(
            waterball,
            new Vector2(
                Random.Range(
                    -GameManager.instance.screenHeight, 
                    GameManager.instance.screenHeight
                ),
                GameManager.instance.minY - 0.5f
            ),
            Quaternion.identity
        );
        newWaterBall.GetComponent<WaterBall>().manager = gameObject.GetComponent<WaterBallController>();
        listWaterBall.Add(newWaterBall);
    }

    public void RemoveWaterBall(GameObject waterBall)
    {
        listWaterBall.Remove(waterBall);
    }

    void Start()
    {
        listWaterBall = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        System.Random random = new System.Random();

        if (random.Next(200) % 200 == 0)
        {
            CreateWaterBall();
        }
    }
}
