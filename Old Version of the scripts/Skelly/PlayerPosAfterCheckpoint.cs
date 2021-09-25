using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosAfterCheckpoint : MonoBehaviour
{
    private CheckpointSystem checkpointSystem;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSystem = GameObject.FindGameObjectWithTag("CHCKPNTSYS").GetComponent<CheckpointSystem>();
        transform.position = checkpointSystem.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update()
    {
        // if Player dies, reload scene. Set this up here.
    }
}
