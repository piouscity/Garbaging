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
    public GameObject timeController;
    public GameObject eventSystem;
    public AudioSource scoreSound;
    public GameObject PauseScene;
    public const int TARGET_OF_LEVEL = 5;
    public int level = 1;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public Text scoreText;
    public int score = 0;
    public int endScene = 2;
    public bool isFreezing = false;
    public bool isPause = false;
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
        PauseScene.SetActive(false);
        Camera camera = Camera.main;
        Vector2 ldCorner = camera.ViewportToWorldPoint(new Vector3(0, 0f, camera.nearClipPlane));
        Vector2 ruCorner = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.nearClipPlane));
        minX = ldCorner.x;
        minY = ldCorner.y;
        maxX = ruCorner.x;
        maxY = ruCorner.y;
        hookController.GetComponent<Hook>().SetBorder();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            PauseScene.SetActive(isPause);
        }
    }

    public float GetPullSpeed()
    {
        return hookController.GetComponent<Hook>().GetPullSpeed();
    }

    public void setPause(bool pause)
    {
        isFreezing = pause;
    }

    public void AddScore()
    {
        scoreSound.Play();
        score++;
        scoreText.text = score.ToString();
        if (score % TARGET_OF_LEVEL == 0)
        {
            ++level;
            hookController.GetComponent<Hook>().UpdateLevel(level);
            fishController.GetComponent<FishController>().UpdateLevel(level);
            trashController.GetComponent<TrashController>().UpdateLevel(level);
        }
    }

    public int GetLevel()
    {
        return level;
    }
    public void SetGameOver()
    {
        StaticClass.CrossSceneInformation = scoreText.text;
        eventSystem.GetComponent<UIManager>().LoadSceneWithID(endScene);
    }
}
