using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public int health;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(health <= 0)
        {
           anim.SetTrigger("puff");

            Destroy(gameObject);

            AudioManager.instance.PlaySFX("enemydie");

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage TAKEN");
    }
}
