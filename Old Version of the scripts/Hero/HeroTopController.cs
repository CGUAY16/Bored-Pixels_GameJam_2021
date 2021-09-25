using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTopController : MonoBehaviour
{
    [SerializeField] PlayerController playerRef;
    [SerializeField] GameObject heroYPosInScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().
            MovePosition(new Vector2(playerRef.transform.position.x, heroYPosInScene.transform.position.y));
    }
}
