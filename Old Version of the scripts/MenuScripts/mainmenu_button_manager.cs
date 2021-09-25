using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu_button_manager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuItems;
    [SerializeField] Button playB;
    [SerializeField] Button settingsB;
    [SerializeField] Button creditsB;
    [SerializeField] Button quitB;

    private void Awake()
    {
        playB.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneLoader.Scene.Level1.ToString());
    }

    public void PlayCredits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
