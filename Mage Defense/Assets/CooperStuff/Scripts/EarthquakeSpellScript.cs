using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSpellScript : MonoBehaviour
{
    mobScript mS;
    public float damage=10;
    // Start is called before the first frame update
    void Start()
    {
        mS = FindObjectOfType<mobScript>();
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            mS.doDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
