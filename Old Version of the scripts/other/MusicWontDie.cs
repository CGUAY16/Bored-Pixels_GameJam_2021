using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicWontDie : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    private static MusicWontDie instanceMusic = null;
    public static MusicWontDie InstanceMusic
    {
        get { return instanceMusic; }
    }
    
    

    private void Awake()
    {
        if (instanceMusic != null && instanceMusic != this)
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            instanceMusic = this;
        }
        
        DontDestroyOnLoad(instanceMusic);
    }

    public void changeTrack(AudioClip c)
    {
        audio.clip = c;
        audio.Play();
    }

    
}
