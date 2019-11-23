using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public TrashController manager;
    Vector2 posTemp;
    bool isChoose = false;
    // Start is called before the first frame update
    void Start()
    {
        posTemp = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChoose)
        {
            posTemp.y += 3 * GameManager.instance.hookController.GetComponent<Hook>().speedHook * Mathf.Pow(1.15f, GameManager.instance.level);
            GetComponent<Transform>().position = posTemp;
            if (posTemp.y >= -GameManager.instance.minY)
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
