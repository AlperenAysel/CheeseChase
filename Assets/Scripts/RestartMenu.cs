using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
   public void RestartMain()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartAI()
    {
        SceneManager.LoadScene(2);
    }
    public void RestartVersus()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
