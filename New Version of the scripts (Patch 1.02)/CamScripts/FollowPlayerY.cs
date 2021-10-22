using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    [SerializeField] PlayerController playerRef;
    private float OriginalCamPosX;
    private float OriginalCamPosZ;

    // Start is called before the first frame update
    void Start()
    {
        OriginalCamPosX = transform.position.x;
        OriginalCamPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(OriginalCamPosX, playerRef.transform.position.y, OriginalCamPosZ);
    }
}
