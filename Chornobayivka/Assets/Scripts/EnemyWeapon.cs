using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Rigidbody2D rb;
    public GameObject projectile;
    public Transform shotPoint;
    public Transform player;
    private Transform target;
    public GameObject gunSprite;
    public float b_speed = 50f;
    SpriteRenderer _renderer;
    public bool facing_right;
    

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        rb = this.GetComponent<Rigidbody2D>();
        _renderer = gunSprite.GetComponent<SpriteRenderer>();
        projectile = GameObject.FindGameObjectWithTag("EnemyBullet");
    }

    private void Update()
    {
        if(timeBtwShots <= 0)
        {
            //spawning a bullet and setting it as a variable
            GameObject bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            //getting its rigidbody
            Rigidbody2D bullet_rg = bullet.GetComponent<Rigidbody2D>();
            //getting the direction
            Vector3 b_direction = player.position - transform.position;
            float b_angle = Mathf.Atan2(b_direction.y, b_direction.x) * Mathf.Rad2Deg;
            //setting the direction
            bullet_rg.rotation = b_angle;
            //launching the bullet
            bullet_rg.AddForce(transform.right * b_speed, ForceMode2D.Impulse);


            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }


        //old method
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; ;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * Time.deltaTime);
        if(rotation.z > -0.7f&& rotation.z <0.7f)
        {

            _renderer.flipX = false;
        }
        if(rotation.z < -0.7f)
        {

            _renderer.flipX = true;
        }
        if (rotation.z > 0.7f)
        {

            _renderer.flipX = true;
        }
        // Debug.Log(rotation);
    }
}
