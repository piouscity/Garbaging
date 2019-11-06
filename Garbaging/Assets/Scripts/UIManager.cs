using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadSceneWithID(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
