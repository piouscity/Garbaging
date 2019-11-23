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
    public GameObject hookController;
    public GameObject eventSystem;

    public AudioSource scoreSound;

    public int level = 1;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

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
        Camera camera = Camera.main;
        Vector2 ldCorner = camera.ViewportToWorldPoint(new Vector3(0, 0f, camera.nearClipPlane));
        Vector2 ruCorner = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.nearClipPlane));
        minX = ldCorner.x;
        minY = ldCorner.y;
        maxX = ruCorner.x;
        maxY = ruCorner.y;
    }
    // Update is called once per frame
    void Update()
    {
        // Set up level
        level = score / 5 + 1;
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
