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

    public AudioSource audioSource; // Reference to the AudioSource component

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
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Play the sound
        }
        profileMenu.SetActive(true);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Play the sound
        }
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
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Play the sound
        }
        profileMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }
    public void BackToMainScreen()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Play the sound
        }
        OpenMainMenu();
    }
}
