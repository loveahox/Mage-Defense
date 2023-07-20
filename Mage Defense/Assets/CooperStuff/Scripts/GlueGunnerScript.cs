using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueGunnerScript : MonoBehaviour
{

    public GameObject projectile;

    public float shootDelay = 1f;
    public float shootInterval = 2f;

    public GameObject targetObj;
    public Transform target;

    public bool firing = false;
    public bool alreadyTargeting = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

        target = targetObj.transform;
        
        transform.LookAt(target);

        
       
    }
    void startFiring()
    {
        InvokeRepeating("SpawnProjectile", shootDelay, shootInterval);
    }
    void stopFiring()
    {
        CancelInvoke("SpawnProjectile");
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (!alreadyTargeting)
            {
                targetObj = collision.gameObject;
                if (!firing)
                {
                    startFiring();
                    firing = true;
                }
                alreadyTargeting = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        stopFiring();
        firing = false;
        alreadyTargeting = false;
    }
}
