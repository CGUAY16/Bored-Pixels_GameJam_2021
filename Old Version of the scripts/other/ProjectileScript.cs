using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] GameObject armProjectile;
    public Transform instantiatePoint;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 elbowPosition = transform.position;

        Vector2 directionOfProjectile = mousePosition - elbowPosition;
        //transform.right = directionOfProjectile;

        if(Input.GetMouseButtonDown(0))
        {
            GameObject newProjectile = Instantiate(armProjectile, instantiatePoint.position, instantiatePoint.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = directionOfProjectile * force;
        }
    }
}
