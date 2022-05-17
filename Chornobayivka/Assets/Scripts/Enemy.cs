using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;

    bool facingRight = true;

    public float stoppingDistance;
    public float retreatDistance;

    // private float timeBtwShots;
    // public float startTimeBtwShots;

    // public GameObject projectile;
    public GameObject Effect;
    public GameObject Bloodsplash; 
    public GameObject Corpse;
    public Transform player;
    private Transform target;
    private Animator anim;

    private void Start()
    {
        // timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            anim.SetBool("isRunning", false);
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }

        // if(timeBtwShots <= 0)
        // {
        //     Instantiate(projectile, transform.position, Quaternion.identity);
        //     timeBtwShots = startTimeBtwShots;
        // } else
        // {
        //     timeBtwShots -= Time.deltaTime;
        // }

        // if(transform.position.x == 0)
        // {
            
        // }
        // else
        // {
        //     anim.SetBool("isRunning", true);
        // }

        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(Bloodsplash, transform.position, Quaternion.identity);
        Instantiate(Corpse, transform.position, Quaternion.identity);
        Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Flip()
    {
        facingRight = !facingRight; 
        transform.Rotate(0f, 180f, 0f); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }



    // public int health;
    // public float speed;

    // private void Update()
    // {
    //     transform.Translate(Vector2.left * speed * Time.deltaTime);
    // }

}
