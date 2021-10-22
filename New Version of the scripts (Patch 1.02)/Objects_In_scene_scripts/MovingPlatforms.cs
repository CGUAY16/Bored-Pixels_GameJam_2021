using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    float startLocation;
    public float speed = 3f;
    public bool moveUp = true;
    public float amountToMove;

    void Start()
    {
        startLocation = transform.position.y;
    }

    void Update()
    {
        if (transform.position.y < startLocation - amountToMove)
        {
            moveUp = true;
        }
        if (transform.position.y > startLocation + amountToMove)
        {
            moveUp = false;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
