using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
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
            posTemp.y += 3 * GameManager.instance.speedHook;
            GetComponent<Transform>().position = posTemp;
            if (posTemp.y >= -GameManager.instance.minY)
            {
                Destroy(this.gameObject);
                GameManager.instance.listTrash.Remove(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("hook"))
        {
            isChoose = true;
        }
    }
}
