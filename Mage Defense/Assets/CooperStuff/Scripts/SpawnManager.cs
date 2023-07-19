using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject goblinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGoblin", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnGoblin()
    {
        Instantiate(goblinPrefab, transform.position, transform.rotation);
    }
}
