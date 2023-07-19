using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueGunnerScript : MonoBehaviour
{

    public GameObject projectile;

    public float shootDelay = 1f;
    public float shootInterval = 2f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnProjectile", shootDelay, shootInterval);
    }

    void SpawnProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
       
    }
}
