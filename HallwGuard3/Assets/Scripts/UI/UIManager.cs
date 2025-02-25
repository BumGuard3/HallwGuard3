using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    private bool isPaused;

    private void Start()
    {
        _mainMenu.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }

        }
    }

    #region Pause/Unpause functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenPauseMenu();
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        ClosePauseMenu();
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion

    #region Open and Close Pause Menu

    private void OpenPauseMenu()
    {
        _mainMenu.SetActive(true);
    }

    private void ClosePauseMenu()
    {
        _mainMenu.SetActive(false);
    }

    #endregion

    #region Pause Menu Button Functions

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Killswitch hit");
    }

    public void ResumeButton()
    {
        Unpause();
    }

    #endregion
}
