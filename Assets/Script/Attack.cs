using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator attackAnim;
    public float attackRange;
    public int damage;

    public AudioClip attackSound;
    public AudioSource audioSource;

    private void Start()
    {
        attackAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {//you can attack //Attack on F
            if (Input.GetKey(KeyCode.F))
            {
                AudioManager.instance.PlaySFX("attack");

                attackAnim.SetTrigger("attack");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    //public void OnAttack()
    //{
    //    if (timeBtwAttack <= 0)
    //    {//you can attack 
    //        AudioManager.instance.PlaySFX("attack");

    //        attackAnim.SetTrigger("attack");

    //        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
    //        for (int i = 0; i < enemiesToDamage.Length; i++)
    //        {
    //            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
    //        }

    //        timeBtwAttack = startTimeBtwAttack;
    //    }

    //    else
    //    {
    //        timeBtwAttack -= Time.deltaTime;
    //    }

    //}

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        
    }

}
