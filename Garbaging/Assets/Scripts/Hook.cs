﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameManager gameManager;
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
        gameManager = GameManager.instance;
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
                if (posTemp.x > -gameManager.screenHeight) 
                    posTemp.x -= speedHook * Mathf.Pow(1.15f, gameManager.level);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                
                if (posTemp.x < gameManager.screenHeight)
                {
                    posTemp.x += speedHook * Mathf.Pow(1.15f, gameManager.level);
                }
            }
            GetComponent<Transform>().position = posTemp;
        }
        else
        {
            if (!isUp) {
                GetComponent<Rigidbody2D>().isKinematic = false;
                posTemp.y -= 2 * speedHook * Mathf.Pow(1.15f, gameManager.level);
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y <= 0)
                {
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    isUp = true;
                }
            }
            else
            {
                posTemp.y += 3 * speedHook * Mathf.Pow(1.15f, gameManager.level);
                GetComponent<Transform>().position = posTemp;
                if (GetComponent<Transform>().position.y >= maxHook)
                {
                    isUp = false;
                    isMove = true;
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
                gameManager.SetGameOver();
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
