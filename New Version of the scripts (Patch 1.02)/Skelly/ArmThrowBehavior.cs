using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmThrowBehavior : MonoBehaviour
{
    [SerializeField] GameObject armProjectile;
    [SerializeField] Transform instantiatePoint;
    [SerializeField] float force;

    private Animator animator;
    private Vector2 mousePosition;
    private Vector2 directionOfProjectile;
    public static int armObjectCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("isArmGone", false);
        armObjectCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionOfProjectile = mousePosition - new Vector2(transform.position.x,transform.position.y);

        if (Input.GetKeyDown(KeyCode.Mouse0) && !animator.GetBool("isArmGone") && armObjectCount == 1)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping Blend Tree"))
            {
                animator.SetBool("isArmGone", false);
            }
            else
            {
                animator.SetBool("isArmGone", true);
            }
        }
    }

    // Event in throw animation is triggering this function.
    public void ThrowArm()
    {
        armObjectCount = 0;
        GameObject newProjectile = Instantiate(armProjectile, instantiatePoint.position, instantiatePoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = directionOfProjectile * force;
        animator.SetBool("isArmGone", false);
    }
}
