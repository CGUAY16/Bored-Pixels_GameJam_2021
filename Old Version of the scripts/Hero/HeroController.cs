using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public static HeroController instance;

    [SerializeField] PlayerController playerRef;
    [SerializeField] GameObject heroXPosInScene;
    private AudioSource aS;

    float cd = 5f;
    float chargeReadyTime;
    public static bool isIdle;

    public void setIdle(bool value)
    {
        isIdle = value;
    }

    bool chargeSetupReady() => Time.time > chargeReadyTime;

    // Start is called before the first frame update
    void Start()
    {
        chargeReadyTime += 5f;
        aS = GetComponent<AudioSource>();
        instance = this;
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(chargeSetupReady())
        {
            chargeReadyTime = Time.time + cd;
            Debug.Log("idle off");
            isIdle = false;
            aS.Play();
        }
    }

    private void FixedUpdate()
    {
        if (isIdle)
        {
            this.GetComponent<Rigidbody2D>().
                MovePosition(new Vector2(heroXPosInScene.transform.position.x, playerRef.transform.position.y));
        }

        
            
    }
}
