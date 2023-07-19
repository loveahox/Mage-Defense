using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpellScript : MonoBehaviour
{
    
    //mobScript mS;
    // Start is called before the first frame update
    void Start()
    {
        
        //mS = FindObjectOfType<mobScript>();
        Destroy(gameObject, 1f);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
