using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //refrence to music clips
    public Music[] musics;

    private string currentMusicID;

    public AudioClip fireballClip;
    public AudioClip iceSpikesClip;
    public AudioClip earthquakeClip;
    public AudioClip blackHoleClip;

    public ParticleSystem explosionParticle;
    public ParticleSystem blackHoleParticle;
    public ParticleSystem iceSpicePatricle;
    public ParticleSystem earthquakeParticle;

    private AudioSource audioSource;

    private void Awake()
    {
        //create audiosource
        foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
        }
    }

    public void ChangeMusic(string newMusicID)
    {

        //stop current music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.source.Stop();
                break;
            }


        }

        //change currentmusicID

        currentMusicID = newMusicID;

        //play new music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.source.Play();
                break;
            }


        }


    }



    //vfx
    public void fireballVFX()
    { 
    explosionParticle.Play();
    }


    void Start()
    {
        ChangeMusic("Main");
        audioSource = GetComponent<AudioSource>();

    }

    public void fireballSFX()
    {
        audioSource.PlayOneShot(fireballClip, 1f);
    }

    public void iceSpiceSFX()
    {
        audioSource.PlayOneShot(iceSpikesClip , 1f);
    }
    public void earthquakeSFX()
    {
        audioSource.PlayOneShot(earthquakeClip , 1f);
    }
    public void blackholeSFX()
    {
        audioSource.PlayOneShot(blackHoleClip , 1f);
    }

}