using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WinLoseMenus : MonoBehaviour
{
    public void ResetLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the Game");
    }


}
