using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class mobScript : MonoBehaviour
{
    public float health = 10f;
    public float damage = 25;
    public NavMeshAgent agent;
    public float damageSpeed = .5f;
    private Vector3 endLocation = new Vector3(-279f, -23.7f, -.9f);
    bool isAttacking = false;
    goblinAttack gAttack;
    orkAttack oAttack;
    spiderAttack sAttack;
    private float Originalspeed;
    public bool slowed = false;
    public float slowedDuration = 1f;
    public float slowedCountdownRate = 2f;
    // Start is called before the first frame update
    public void doDamage(float num)
    {
        health -= num;
    }
    void Start()
    {
        StartCoroutine(wait());
        Originalspeed = agent.speed;
        gAttack = GetComponent<goblinAttack>();
        agent.SetDestination(endLocation);
    }
    IEnumerator wait()
    {
        isAttacking = true;
        yield return new WaitForSeconds(damageSpeed);
        isAttacking = false;
    }
    public void attack()
    {
        if (!isAttacking)
        {
            if (gameObject.name.Equals("Goblin"))
            {
                gAttack.playAnim();
            }
            if (gameObject.name.Equals("Spider"))
            {
                sAttack.playAnim();
            }
            if (gameObject.name.Equals("Orc"))
            {
                gAttack.playAnim();
            }
            GameManager.gm.attacking(damage);
            print("attacked");
            StartCoroutine(wait());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sticky") && !slowed)
        {
            agent.speed=Originalspeed-=2;
            slowed = true;
            SlowedCountdown();
            slowedDuration = 1f;
        }
    }
    void SlowedCountdown()
    {
        if (slowed)
        {
            slowedDuration -= 1 / slowedCountdownRate * Time.deltaTime;
            if (slowedDuration <= 0)
            {
                slowedDuration = 0f;
                slowed = false;
                agent.speed = Originalspeed;
            }
        }
    }
        // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (agent.remainingDistance < 14 && health>0)
        {

            GameManager.gm.damage = true;
            attack();

        }

    }
}
