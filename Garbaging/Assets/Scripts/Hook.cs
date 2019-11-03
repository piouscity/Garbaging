using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{ 
    bool isMove = true;
    bool isUp = false;
    float distance;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        GetComponent<Rigidbody2D>().fixedAngle = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posTemp = GetComponent<Transform>().position;
        if (isMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                
                if (posTemp.x > -GameManager.instance.screenHeight) { posTemp.x -= GameManager.instance.speedHook; }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                
                if (posTemp.x < GameManager.instance.screenHeight)
                {
                    posTemp.x += GameManager.instance.speedHook;
                }
            }
            GetComponent<Transform>().position = posTemp;
        }
        else
        {
            if (!isUp) {
                GetComponent<Rigidbody2D>().isKinematic = false;
                posTemp.y -= 2 * GameManager.instance.speedHook;
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y <= 0)
                {
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    isUp = true;
                }
            }
            else
            {
                posTemp.y += 3 * GameManager.instance.speedHook;
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y >= GameManager.instance.maxHook)
                {
                    isUp = false;
                    isMove = true;
                    GameManager.instance.AddScore();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = false;
        }

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("fish")) {
            if (!isUp)
            {
                GameManager.instance.SetGameOver();
            }
        }

        if (collision.gameObject.name.Contains("trash"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            isUp = true;
        }
    }
}
