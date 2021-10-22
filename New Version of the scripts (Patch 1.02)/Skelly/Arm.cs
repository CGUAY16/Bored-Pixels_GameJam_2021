using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool hit;

    private bool IsArmHookedInWall = false;
    private Collider2D armWallChecker;
    private Transform skellyShoulderPos;

    [SerializeField] LayerMask interableLayerMask;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        armWallChecker = Physics2D.OverlapCircle(this.gameObject.transform.position, 0.2f, interableLayerMask);
        skellyShoulderPos = this.gameObject.transform;
    }

    private void Update()
    {

        //despawns arm and lets player throw his arm again.
        if (Input.GetKeyDown(KeyCode.E))
        {
            ArmThrowBehavior.armObjectCount = 1;
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && armWallChecker != null)
        {
            IsArmHookedInWall = true;
            FixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        armWallChecker = Physics2D.OverlapArea(
            new Vector2(this.gameObject.transform.position.x - 0.25f, this.gameObject.transform.position.y + 0.25f),
            new Vector2(this.gameObject.transform.position.x + 0.25f, this.gameObject.transform.position.y - 0.25f),
            interableLayerMask);

        if (hit == false)
        {
            float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (IsArmHookedInWall)
        {
            hit = true;
            rb2d.velocity = Vector2.zero;
            rb2d.isKinematic = true;
        }

    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.Draw(this.gameObject.transform.position, 0.1f);
    }

}
