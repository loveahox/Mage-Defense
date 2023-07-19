using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public bool slowed = false;
    public float slowedDuration = 1f;
    public float slowedCountdownRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        SlowedCountdown();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sticky"))
        {
            moveSpeed = 1f;
            slowed = true;
            slowedDuration = 1f;
        }
    }
    void SlowedCountdown()
    {
        if(slowed)
        {
            slowedDuration -= 1 / slowedCountdownRate * Time.deltaTime;
            if(slowedDuration <=0)
            {
                slowedDuration = 0f;
                slowed = false;
                moveSpeed = 3f;
            }
        }
    }
}
