using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    Rigidbody2D rb;
    float delayFall = 2f;
    public GameObject newPlatform;
    Transform startLocation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //startLocation = transform.position;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            Invoke("Drop", delayFall);
            Destroy(gameObject, 4f);
            //Instantiate(newPlatform);
        }
    }
    void Drop()
    {
        rb.isKinematic = false;
    }
}
