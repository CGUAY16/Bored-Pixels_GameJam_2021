using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatforms : MonoBehaviour
{
    float startLocation;
    public float speed = 3f;
    public bool moveRight = true;
    public float amountToMove;

    void Start()
    {
        startLocation = transform.position.x;
    }

    void Update()
    {
        if (transform.position.x < startLocation - amountToMove)
        {
            moveRight = true;
        }
        if (transform.position.x > startLocation + amountToMove)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
