using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public WaterBallController manager;
    Vector2 posTemp;
    bool isAccident = false;
    // Start is called before the first frame update
    void Start()
    {
        posTemp = GetComponent<Transform>().position;
    }
    int temp = 1;
    // Update is called once per frame
    void Update()
    {
        if (!isAccident)
        {
            posTemp.y += 0.02f;
            if(posTemp.y >= -GameManager.instance.minY + 1.0f) {
                Destroy(gameObject);
                manager.RemoveWaterBall(gameObject);
            }
            GetComponent<Transform>().position = posTemp;
        } else 
        {
            temp += 1;
            if (temp == 10)
            {
                Destroy(gameObject);
                manager.RemoveWaterBall(gameObject);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetTrigger("Accident");
        isAccident = true;

    }
}
