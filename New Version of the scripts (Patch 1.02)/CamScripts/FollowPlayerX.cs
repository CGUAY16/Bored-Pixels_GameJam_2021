using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] PlayerController playerRef;
    private float OriginalCamPosY;
    private float OriginalCamPosZ;

    // Start is called before the first frame update
    void Start()
    {
        OriginalCamPosY = transform.position.y;
        OriginalCamPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerRef.transform.position.x, OriginalCamPosY, OriginalCamPosZ);
    }
}
