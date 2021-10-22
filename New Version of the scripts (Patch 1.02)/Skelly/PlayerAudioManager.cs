using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    // 0 => jumping sfx, 1 => hurt sfx, 
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource audioOutput;

    private void Awake()
    {
        PlayerController.HurtSoundTrigger += HurtMoment;
    }

    private void Start()
    {
        audioOutput.volume = 0.2f;
    }

    private void OnDestroy()
    {
        PlayerController.HurtSoundTrigger -= HurtMoment;
    }

    // Update is called once per frame
    private void Update()
    {
        // if jumping, play jump_sfx
        if(player.GetPlayerJumpingAnimationState()){
            audioOutput.clip = audioClips[0];
            audioOutput.Play();
        }
    }

    private void HurtMoment()
    {
        audioOutput.clip = audioClips[1];
        audioOutput.volume = 0.5f;
        audioOutput.Play();

        audioOutput.volume = 0.2f;

    }

}
