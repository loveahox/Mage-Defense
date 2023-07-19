using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class mobScript : MonoBehaviour
{
    public float health = 10f;
    public float damage = 25;
    public NavMeshAgent agent;
    public float damageSpeed=.5f;
    private Vector3 endLocation= new Vector3(-264f, -23.4f, -.9f);
    bool isAttacking = false;
    goblinAttack gAttack;
    porkyAttack pAttack;
    spiderAttack sAttack;
    // Start is called before the first frame update
    void Start()
    {
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
            if(gameObject.name.Equals("Goblin"))
            {
                gAttack.playAnim();
            }
            if (gameObject.name.Equals("Spider"))
            {
                sAttack.playAnim();
            }
            if (gameObject.name.Equals("Porky"))
            {
                pAttack.playAnim();
            }
            GameManager.gm.attacking(damage);
            StartCoroutine(wait());
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
        if(agent.remainingDistance<1)
        {
            attack();
        }
    }
}
