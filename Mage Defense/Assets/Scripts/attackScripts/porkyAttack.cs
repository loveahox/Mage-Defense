using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porkyAttack : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void playAnim()
    {
        anim.Play("attack1");
    }
}
