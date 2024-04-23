using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject profileMenu;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    public GameObject shopMenu;

    void Start()
    {
        OpenMainMenu();
        Time.timeScale = 1f;
    }
    //public void Play()
    //{
    //    // Start the game by loading the main screen
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    Debug.Log("Hiii");
    //}

    public void OpenProfileMenu()
    {
        profileMenu.SetActive(true);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        profileMenu.SetActive(false);
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        profileMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }

    public void OpenShopMenu()
    {
        profileMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }
    public void BackToMainScreen()
    {
        profileMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
    }
}
