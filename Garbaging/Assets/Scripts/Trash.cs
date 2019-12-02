using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameManager gameManager;
    public TrashController manager;
    Vector2 posTemp;
    bool isChoose = false;
    bool isMove = true;
    bool isLeft = true;
    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        posTemp = GetComponent<Transform>().position;
        gameManager = GameManager.instance;
        
        if (random.Next(3) % 3 == 0)
        {
            isLeft = true;
        } else
        {
            isLeft = false;
        }
    }
    float x = 1f;
    // Update is called once per frame

    void Update()
    {
        if (isChoose)
        {
            posTemp.y += gameManager.GetPullSpeed();
            GetComponent<Transform>().position = posTemp;
            if (posTemp.y >= GameManager.instance.maxY)
            {
                
                manager.CreatePlusAni(GetComponent<Transform>().position);
                manager.setHidePlusAni(false);
                manager.RemoveTrash(gameObject);
                Destroy(gameObject);
                GameManager.instance.AddScore();
            }
        }

        

        if (isMove && GameManager.instance.level >= 3 && !GameManager.instance.isFreezing)
        {
           
            if (isLeft)
            {
                posTemp.x += x / 10000 * (GameManager.instance.level - 3);
            } else
            {
                posTemp.x -= x / 10000 * (GameManager.instance.level - 3);
            }
            posTemp.y = posTemp.y + random.Next(2,4) * 1.0f / 200.0f * Mathf.Sin(3.14f + x);
            x += 0.05f;
            GetComponent<Transform>().position = posTemp;
        }
        else { x = 1; }

        if (screenPassed())
        {
            
            Destroy(gameObject);
            manager.RemoveTrash(gameObject);
        }
    }

    bool screenPassed()
    {
        return posTemp.x > gameManager.maxX || posTemp.x < gameManager.minX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            isChoose = true;
            isMove = false;
            posTemp = GetComponent<Transform>().position;
        }
    }
}
