using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public AudioSource soundHookMoved;
    public AudioSource soundHookVsGarbage;
    public AudioSource soundHookVsFish;

    public float speedHook = 0.02f;
    public float initSpeedHook = 0.02f;
    public float maxHook = 9.1f;

    bool isMove = true;
    bool isUp = false;
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
                
                if (posTemp.x > -GameManager.instance.screenHeight) { posTemp.x -= speedHook; }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                
                if (posTemp.x < GameManager.instance.screenHeight)
                {
                    posTemp.x += speedHook;
                }
            }
            GetComponent<Transform>().position = posTemp;
        }
        else
        {
            if (!isUp) {
                GetComponent<Rigidbody2D>().isKinematic = false;
                posTemp.y -= 2 * speedHook;
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y <= 0)
                {
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    isUp = true;
                }
            }
            else
            {
                posTemp.y += 3 * speedHook;
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y >= maxHook)
                {
                    isUp = false;
                    isMove = true;
                    GameManager.instance.AddScore();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMove)
                soundHookMoved.Play();
            isMove = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish")) 
        {
            if (!isUp)
            {
                soundHookVsFish.Play();
                GameManager.instance.SetGameOver();
            }
        }

        if (collision.gameObject.CompareTag("Trash"))
        {
            soundHookVsGarbage.Play();
            GetComponent<Rigidbody2D>().isKinematic = true;
            isUp = true;
        }
    }
}
