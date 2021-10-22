using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDespawnBehavior : MonoBehaviour
{
    [SerializeField] HeroController hc;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(this.transform.position.x, hc.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            Charge_leftToRight.despawningHero = true;
        }
    }
}
