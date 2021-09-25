using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhatIsTheScene : MonoBehaviour
{
    private static WhatIsTheScene instance = null;
    public static WhatIsTheScene Instance
    {
        get { return instance; }
    }

    private Scene currentScene;
    [SerializeField] AudioClip clipA;

    // Start is called before the first frame update
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        if (instance != null && instance != this)
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }

    // Update is called once per frame
    private void Update()
    {
        Scene newScene = SceneManager.GetActiveScene();
        if (currentScene != newScene)
        {
            currentScene = newScene;
            MusicWontDie.InstanceMusic.changeTrack(clipA);
        }
    }
}
