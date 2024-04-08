using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void startGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
