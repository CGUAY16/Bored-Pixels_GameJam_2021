using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePointSetup_XAxis : MonoBehaviour
{
    [SerializeField] PlayerController playerRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(this.transform.position.x, playerRef.transform.position.y);
    }
}
