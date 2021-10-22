using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticStick : MonoBehaviour
{
    [SerializeField] Transform camFocusPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camFocusPoint.position.x, camFocusPoint.position.y, transform.position.z);
    }
}
