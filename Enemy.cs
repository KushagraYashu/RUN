using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public float timeBtwShots;
    private float startTimeBtwShots = 5f ;
    public Transform player;
    public Transform spawnPt;
    public GameObject spawnedBullet;

    public float range;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnedBullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < range )
        {
            if(timeBtwShots <= 0)
            {
                Instantiate(bullet, spawnPt.transform.position, Quaternion.Euler(-89.98f, 0f, 0f));
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }


    }
}
