using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _creditsMenu;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _creditsMenuFirst;

    private void Start()
    {
        _mainMenu.SetActive(true);
        _creditsMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        _mainMenu.SetActive(true);
        _creditsMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    public void CreditsButton()
    {
        _creditsMenu.SetActive(true);
        _mainMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_creditsMenuFirst);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
