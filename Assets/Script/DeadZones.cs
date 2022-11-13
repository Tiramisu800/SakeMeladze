using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMP3: MonoBehaviour
{
    AudioSource mp3;

    void Start()
    {
        mp3 = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Sound();
        }
    }

    void Sound()
    {
        mp3.Play();
    }

   
}
