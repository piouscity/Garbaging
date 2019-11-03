using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int level = 1;

    public float speedHook = 0.02f;
    public float init_speedHook = 0.02f;
    public float maxHook = 9.1f;


    public float maxX = 10.5f;
    public float minX = 9.5f;
    public float maxY = 3f;
    public float minY = -4.5f;

    public float screenHeight = 9.5f;

    public List<GameObject> fishList;
    public List<GameObject> listTrash;
    public List<GameObject> listWaterBall;

    public bool gameOver = false;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = false;
            }
        }

        // Set up level
        level = score / 5 + 1;

        switch (level)
        {
            case 1:
                speedHook = init_speedHook * 1.2f;
                break;
            case 2:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 2);
                break;
            case 3:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 3);
                break;
            case 4:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 4);
                break;
            case 5:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 5);
                break;
            case 6:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 6);
                break;
            default:
                speedHook = init_speedHook * Mathf.Pow(1.15f, 7);
                break;
        }

    }
}
