using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpellScript : MonoBehaviour
{
    public float damage=25;
    mobScript mS;
    // Start is called before the first frame update
    void Start()
    {
        mS = FindObjectOfType<mobScript>();
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            mS.doDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
