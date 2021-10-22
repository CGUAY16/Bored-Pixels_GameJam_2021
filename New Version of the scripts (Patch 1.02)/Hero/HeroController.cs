using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] PlayerController playerRef;
    [SerializeField] GameObject heroXPosInScene;
    [SerializeField] Collider2D despawnCol;

    private AudioSource aS;
    private Animator animator;

    public static float cd = 10f;
    public static float chargeReadyTime;
    public static bool chargeTrigger;
    public static float initialTimeBeforeSceneCreation; // time value before hero is created, used to update currentscene time.
    public static float currentTotalSceneTime;

    bool chargeSetupReady() => currentTotalSceneTime > chargeReadyTime;

    // EVENTS SETUP
    public delegate void chargeInfo();
    public static event chargeInfo OnChargeReady;

    private void Awake()
    {
        aS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initialTimeBeforeSceneCreation = Time.time;
        currentTotalSceneTime = Time.time - initialTimeBeforeSceneCreation;
        Debug.Log(Time.time);
        chargeTrigger = true;
        chargeReadyTime = 0;
        chargeReadyTime += cd;
    }

    // Update is called once per frame
    void Update()
    {
        currentTotalSceneTime = Time.time - initialTimeBeforeSceneCreation;

        if (chargeSetupReady() && chargeTrigger)
        {
            chargeTrigger = false;
            Debug.Log("Ready");
            aS.Play();

            // Calling the event manager to invoke subscribed events
            if(OnChargeReady != null)
            {
                OnChargeReady();
            }
        }
    }

    void FixedUpdate()
    {
        // when isCharging is true, then hero is charging and this transform line cannot activate during this.
        // when false, then follow player y value.
        if(!animator.GetBool("isCharging"))
        { 
            transform.position = new Vector2(heroXPosInScene.transform.position.x, playerRef.transform.position.y); 
        }
    }

    
}
