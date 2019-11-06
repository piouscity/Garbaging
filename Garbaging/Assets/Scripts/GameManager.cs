using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject trashController;
    public GameObject fishController;
    public GameObject waterBallController;
    public GameObject eventSystem;

    public AudioSource scoreSound;

    public int level = 1;

    public float speedHook = 0.02f;
    public float initSpeedHook = 0.02f;
    public float maxHook = 9.1f;

    public float maxX = 10.5f;
    public float minX = 9.5f;
    public float maxY = 3f;
    public float minY = -4.5f;

    public float screenHeight = 9.5f;

    public Text scoreText;
    int score = 0;

    public int endScene = 2;

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
        // Set up level
        level = score / 5 + 1;

        switch (level)
        {
            case 1:
                speedHook = initSpeedHook * 1.2f;
                break;
            case 2:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 2);
                break;
            case 3:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 3);
                break;
            case 4:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 4);
                break;
            case 5:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 5);
                break;
            case 6:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 6);
                break;
            default:
                speedHook = initSpeedHook * Mathf.Pow(1.15f, 7);
                break;
        }
    }

    public void AddScore()
    {
        scoreSound.Play();
        score++;
        scoreText.text = score.ToString();
    }
    public void SetGameOver()
    {
        StaticClass.CrossSceneInformation = scoreText.text;
        eventSystem.GetComponent<UIManager>().LoadSceneWithID(endScene);
    }
}
