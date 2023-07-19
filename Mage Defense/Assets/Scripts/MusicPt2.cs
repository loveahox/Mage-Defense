using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPt2 : MonoBehaviour
{
    public Music[] musics;
    public AudioSource audioSource; 

     public void mainMusic()
    {
         foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
        }

    }




}
