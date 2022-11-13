using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake() { instance = this; }

    //Sound Effects
    public AudioClip sfx_jump, sfx_token, sfx_death, sfx_attack, sfx_enemydie;

    //Sound Object
    public GameObject soundObject;

    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        { 
            case "jump":
                SoundObjectCreation(sfx_jump);
                break;
            case "token":
                SoundObjectCreation(sfx_token);
                break;
            case "death":
                SoundObjectCreation(sfx_death);
                break;
            case "attack":
                SoundObjectCreation(sfx_attack);
                break;
            case "enemydie":
                SoundObjectCreation(sfx_enemydie);
                break;
            default:
                break;
        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        //Create SoundObject gameobjecy
        GameObject newObject = Instantiate(soundObject, transform);

        //Assign audioclip to its audiosource
        newObject.GetComponent<AudioSource>().clip = clip;

        //Play the audio
        newObject.GetComponent<AudioSource>().Play();

    }
}
