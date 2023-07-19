using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpellScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
