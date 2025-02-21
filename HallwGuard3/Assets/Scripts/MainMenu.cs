using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button mainMenuButton;
    public Button settingsButton;

    public GameObject Credits;
    public GameObject mainMenu;
    public GameObject settingsMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(play);
        creditsButton.onClick.AddListener(credits);
        mainMenuButton.onClick.AddListener(main);
        settingsButton.onClick.AddListener(settings);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void play()
    {
        SceneManager.LoadScene("Level");
    }

    void credits()
    {
        mainMenu.gameObject.SetActive(false);
        Credits.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    void main()
    {
        mainMenu.gameObject.SetActive(true);
        Credits.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    void settings()
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);

    }
}
