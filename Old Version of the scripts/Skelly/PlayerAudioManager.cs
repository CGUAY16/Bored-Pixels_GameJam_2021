using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    // 0 => jumping sfx, 1 => hurt sfx, 
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource audioOutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if jumping, play jump_sfx
        if(player.GetPlayerJumpingAnimationState()){
            audioOutput.clip = audioClips[0];
            audioOutput.Play();
        }
    }


}
