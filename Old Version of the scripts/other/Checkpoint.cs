using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointSystem checkpointSystem;

    private void Start()
    {
        checkpointSystem = GameObject.FindGameObjectWithTag("CHCKPNTSYS").GetComponent<CheckpointSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkpointSystem.lastCheckpointPos = transform.position;
        }
    }
}
