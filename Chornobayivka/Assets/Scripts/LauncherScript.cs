using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    public float shotgunBlastCooldown;
    private float shotgunCountdown;

    bool facingRight = true;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public AudioSource _AudioSource;
    public AudioClip GunShot;

    public GameObject spriteGO;
    private SpriteRenderer spriteRender;

    public float bulletSpeed;

    private void Start()
    {
        spriteRender = spriteGO.GetComponent<SpriteRenderer>();   
    }



    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;



        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (timeBtwShots <=0)
        {
            if (Input.GetMouseButton(0))
            {
                var _bullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                var bulletRG = _bullet.GetComponent<Rigidbody2D>();
                bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                timeBtwShots = startTimeBtwShots;

                _AudioSource.PlayOneShot(GunShot);
                // CinemachineShake.Instance.ShakeCamera();
            }
        }
        else
        {
            timeBtwShots -=Time.deltaTime;
        }
        shotgunCountdown -= Time.deltaTime;
        if(Input.GetMouseButton(1)&& shotgunCountdown <= 0)
        {
            ShotgunBlast();
            shotgunCountdown = shotgunBlastCooldown;
        }



        if (difference.x < 0)
        {
            spriteRender.flipX = true; 
        }
        else
        {
            spriteRender.flipX = false;
        }

    }
    void ShotgunBlast()
    {
        for(int i = 0; i <= 4; i++)
        {
            var _bullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            var _bulletRG = _bullet.GetComponent<Rigidbody2D>();

            switch (i)
            {
                case 0:
                    _bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, -360f, 0f));
                    break;
                case 1:
                    _bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, -180f, 0f));                    
                    break;
                case 2:
                    _bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                    break;
                case 3:
                    _bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, 180f, 0f));
                    break;
                case 4:
                    _bulletRG.AddForce(shotPoint.up * bulletSpeed + new Vector3(0f, 360f, 0f));
                    break;
            }
        }
        timeBtwShots = 1f;
    }


}
