using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float level = 1;
    public float speedHook = 0.04f;
    public float maxHook = 9.1f;
    public float maxX = 10.5f;
    public float minX = 9.5f;
    public float maxY = 3f;
    public float minY = -4.5f;
    public float screenHeight = 8.5f;
    public List<GameObject> fishList;
    public List<GameObject> listTrash;

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
        level = score / 10 + 1;

    }
}
