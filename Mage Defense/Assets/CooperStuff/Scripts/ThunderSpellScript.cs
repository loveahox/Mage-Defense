using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpellScript : MonoBehaviour
{
    public float damage=10;
    private bool doneDamage = false;
    //mobScript mS;
    // Start is called before the first frame update
    void Start()
    {
        //mS = FindObjectOfType<mobScript>();
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (!doneDamage)
            {
                collision.gameObject.GetComponent<mobScript>().doDamage(damage);
                doneDamage = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
