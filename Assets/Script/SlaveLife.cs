using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlaveLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
 

    public AudioClip Death;
    public AudioSource audioSource;
   


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            SceneManager.LoadScene("LoseScreen");
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        AudioManager.instance.PlaySFX("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  




}
