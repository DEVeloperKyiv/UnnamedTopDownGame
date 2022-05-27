using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform shotPoint;
    private GameObject playerGO;
    private Transform player;
    public GameObject gunSprite;
    public float b_speed = 50f;
    SpriteRenderer _renderer;
    public bool facing_right;

    public AudioSource AudSource;
    public AudioClip Gunshot;


    void Start()
    {

        //finding gameobject with tag "Player" so that ak would rotate
        playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.transform;




        timeBtwShots = startTimeBtwShots;
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

            AudSource.PlayOneShot(Gunshot);

            timeBtwShots = startTimeBtwShots+Random.Range(-0.1f,0.2f);
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
