using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZones : MonoBehaviour
{
    AudioSource deadmp3;

    void Start()
    {
        deadmp3 = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DeadZoneSound();

            Destroy(other.gameObject);
        }
    }

    void DeadZoneSound()
    {
        deadmp3.Play();
    }

   
}
