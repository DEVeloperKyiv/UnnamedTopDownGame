using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange;
    public int damage;

    public Animator anim;

    public GameObject Effect;
    public Transform attackPos;
    public LayerMask whatIsEnemy;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
             if(Input.GetMouseButton(1 ))
             {
                 Debug.Log("melee attack");
                 Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                 anim.SetTrigger("MeleeAttack");
                 for (int i = 0; i < enemiesToDamage.Length; i++)
                 {
                     enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                     Instantiate(Effect, transform.position, Quaternion.identity);
                     Debug.Log("enemy hit");
                 }
             }

            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

