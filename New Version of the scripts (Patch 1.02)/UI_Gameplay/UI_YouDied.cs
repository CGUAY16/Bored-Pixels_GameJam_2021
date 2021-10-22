using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_YouDied : MonoBehaviour
{
    // This script will turn on the UI panel when player life reaches 0.
    // Scripts therefore needs to check for player life.

    private void Awake()
    {
        this.gameObject.SetActive(false);
        //add link to event that will activate function once life reaches 0
        PlayerController.UpdateUI += ActivateUI;
    }

    private void OnDestroy()
    {
        PlayerController.UpdateUI -= ActivateUI;
    }

    public static void TryAgain()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name.ToString());
    }

    public static void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneLoader.Scene.MainMenu.ToString());
    }

    public void ActivateUI()
    {
        Time.timeScale = 0; // pause
        this.gameObject.SetActive(true);
        this.enabled = true;
    }

    
}
