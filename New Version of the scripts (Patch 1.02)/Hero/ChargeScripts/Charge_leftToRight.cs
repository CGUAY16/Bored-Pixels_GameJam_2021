using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_leftToRight : MonoBehaviour
{
    [SerializeField] float chargeSpeed;
    private Animator animator;
    private Rigidbody2D rb;
    public static bool despawningHero;

    private bool moving; //activates the movement script line within fixed Update

    private void Awake()
    {
        moving = false; 
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        HeroController.OnChargeReady += beginChargeAction;
    }

    private void OnDestroy()
    {
        HeroController.OnChargeReady -= beginChargeAction;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.AddForce(new Vector2(Vector2.right.x * chargeSpeed, 0f));
        }
    }

    void beginChargeAction()
    {
        Debug.Log("commenceAction");
        animator.SetBool("isCharging", true);
        
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        moving = true;
        float x = HeroController.currentTotalSceneTime + 5f;
        yield return new WaitUntil(() => (despawningHero == true) || ( (HeroController.currentTotalSceneTime >= x) == true));
        moving = false;
        despawningHero = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Debug.Log("charge Off");
        animator.SetBool("isCharging", false);

        HeroController.chargeTrigger = true;
        HeroController.chargeReadyTime = HeroController.currentTotalSceneTime + HeroController.cd;
        yield return null;
    } 
}
