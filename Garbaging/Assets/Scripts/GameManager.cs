using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float speed_fish_01 = 0.01f;
    public float speed_fish_02 = 0.02f;
    public float speed_fish_03 = 0.03f;
    public float maxX = 14.0f;
    public float minX = 12.0f;
    public float maxY = 3f;
    public float minY = -4.5f;
    public List<GameObject> fishList;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float speed_of_fish(int type) {

        float plus_speed = 0.0f;
        if (score <= 10) {
            plus_speed = 0.0f;
        } else if (score <= 20)
        {
            plus_speed = 0.02f;
        }
        else if (score <= 30)
        {
            plus_speed = 0.04f;
        }
        else if (score <= 40)
        {
            plus_speed = 0.05f;
        }

        switch (type)
        {
            case 1:
                return speed_fish_01 + plus_speed;
            case 2:
                return speed_fish_02 + plus_speed;
            case 3:
                return speed_fish_03 + plus_speed;
            default:
                return speed_fish_01 + plus_speed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
