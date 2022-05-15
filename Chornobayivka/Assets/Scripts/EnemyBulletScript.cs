using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public int damage;
    public GameObject player;
    PlayerMovement damageScript;
    void Start()
    {
        damageScript = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            damageScript.TakeDamage(damage);

            Suicide();
        }
    }

    void Suicide()
    {
        Destroy(gameObject);
    }
}
