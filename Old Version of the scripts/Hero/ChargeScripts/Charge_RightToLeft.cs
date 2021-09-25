using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_RightToLeft : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    [SerializeField] float chargeSpeed;
    private bool chargeReady;
    private bool x;


    // Start is called before the first frame update
    void Start()
    {
        x = true;
        chargeReady = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!HeroController.isIdle && x)
        {
            Debug.Log("charge On");
            chargeReady = true;
            x = false;
        }
    }

    private void FixedUpdate()
    {
        if (chargeReady)
        {
            StartCoroutine("Charge");
            chargeReady = false;
            x = true;
        }
    }

    IEnumerator Charge()
    {
        rb.AddForce(new Vector2(Vector2.left.x * chargeSpeed, 0f));
        yield return new WaitForSeconds(7f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Debug.Log("charge Off");
        Debug.Log("idle on");
        HeroController.instance.setIdle(true);

        yield return null;
    }
}
