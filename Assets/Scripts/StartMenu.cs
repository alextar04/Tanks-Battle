using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OpenCreateGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenJoinGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenRecords()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
