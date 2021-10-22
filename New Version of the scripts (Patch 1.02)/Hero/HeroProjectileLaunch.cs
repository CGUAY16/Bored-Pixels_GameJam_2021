using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectileLaunch : MonoBehaviour
{

    [SerializeField] Projectile p;
    [SerializeField] Transform pSpawnPoint;

    [SerializeField] float timeInBetweenSpawns = 5.0f;
    private float nextSpawnTime;

    bool spawnReady() => Time.time >= nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnReady())
        {
            nextSpawnTime = Time.time + timeInBetweenSpawns;
            Instantiate(p, pSpawnPoint.position, pSpawnPoint.rotation);
        }
    }
}
