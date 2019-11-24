using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameManager gameManager;
    public TrashController manager;
    Vector2 posTemp;
    bool isChoose = false;
    // Start is called before the first frame update
    void Start()
    {
        posTemp = GetComponent<Transform>().position;
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChoose)
        {
            posTemp.y += gameManager.GetPullSpeed();
            GetComponent<Transform>().position = posTemp;
            if (posTemp.y >= GameManager.instance.maxY)
            {
                Destroy(gameObject);
                manager.RemoveTrash(gameObject);
                GameManager.instance.AddScore();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            isChoose = true;
        }
    }
}
