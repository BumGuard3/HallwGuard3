using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button mainMenuButton;

    public GameObject Credits;
    public GameObject mainMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(play);
        creditsButton.onClick.AddListener(credits);
        mainMenuButton.onClick.AddListener(main);
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
        mainMenuButton.gameObject.SetActive(false);
    }

}
