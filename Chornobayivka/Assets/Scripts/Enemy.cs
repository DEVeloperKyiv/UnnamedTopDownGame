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

    private float dazedTime;
    public float stratDazedTime;

    // private float timeBtwShots;
    // public float startTimeBtwShots;

    // public GameObject projectile;
    public GameObject Effect;
    public GameObject[] Bloodsplash; 
    public GameObject[] Corpses;
    private GameObject _playerGO;
    private Transform player;
    private Transform target;
    private Animator anim;
    public AudioSource AudSource;
    public AudioClip hurt;
    public float execDazeTime = 6;

    public bool canBeExecuted;

    public GameObject cam;

    private void Start()
    {
        // timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
        // player = GameObject.FindGameObjectWithTag("Player");
        _playerGO = GameObject.FindGameObjectWithTag("Player");
        player = _playerGO.transform;
        canBeExecuted = false;
    }

    private void Update()
    {
        _Move();
        if(health <= 0)
        {
            Death();
        }
      //  if(health <= 5)
     //   {

       //     canBeExecuted = true;  
       // }
       // if(canBeExecuted=true && Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, player.position) < 5)
     //   {
       //     Death();
       // }
    }

    public void Death()
    {
        Instantiate(Effect, transform.position, Quaternion.identity);
        int randomIndex1 = Random.Range(0, Corpses.Length);
        int randomIndex2 = Random.Range(0, Bloodsplash.Length);
        Instantiate(Bloodsplash[randomIndex2], transform.position, Quaternion.identity);
        Instantiate(Corpses[randomIndex1], transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        dazedTime = stratDazedTime;
        AudSource.PlayOneShot(hurt);
    }

    public void _Move()
    {
        if (canBeExecuted == false)
        {
            if (dazedTime <= 0)
            {
                speed = 7;
            }
            else
            {
                speed = 0;
                dazedTime -= Time.deltaTime;
            }
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
                anim.SetBool("isRunning", false);
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
        }
        
    }


}
