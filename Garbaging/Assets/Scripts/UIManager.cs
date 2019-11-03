using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static void LoadSceneWithID(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }
    public static void ExitGame()
    {
        Application.Quit();
    }
}
