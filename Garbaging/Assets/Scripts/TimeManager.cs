using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject time;
    public GameObject timer;
    private GameObject Timer;
    private List<GameObject> listTime;
    public bool isAddTime = false;

    void CreateTime()
    {
        if (listTime.Count < 3)
        {
            GameObject newtime = Instantiate(
                time,
                new Vector2(
                    GameManager.instance.minX + 1f * listTime.Count + 0.5f,
                    GameManager.instance.maxY - 0.5f
                ),
                Quaternion.identity
            );
            listTime.Add(newtime);
        }
        isAddTime = false;

    }

    public void RemoveTime()
    {
        
        Destroy(listTime[listTime.Count - 1]);
        listTime.Remove(listTime[listTime.Count - 1]);
    }

    void Start()
    {
        
        listTime = new List<GameObject>();
    }

    int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.score > 0)
        {
            if (GameManager.instance.score % 5 == 0)
            {
                if (isAddTime)
                {
                    CreateTime();
                }

            } else
            {
                isAddTime = true;
            }
        }

        if (listTime.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.B) && !GameManager.instance.isFreezing)
            {
                GameManager.instance.setPause(true);
                RemoveTime();
                Timer = Instantiate(
                timer,
                new Vector2(
                    GameManager.instance.minX + 0.5f,
                    GameManager.instance.maxY - 1.5f
                ),
                Quaternion.identity
            );
            }
        }

        if (GameManager.instance.isFreezing && !GameManager.instance.isPause)
        {
            index += 1;
            if (index == 600)
            {
                GameManager.instance.setPause(false);
                Destroy(Timer);
                index = 0;
            }
        }
        
        
    }
}
