﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    bool facingRight = true;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public AudioSource _AudioSource;
    public AudioClip GunShot;

    public GameObject spriteGO;
    private SpriteRenderer spriteRender;

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
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                timeBtwShots = startTimeBtwShots;

                _AudioSource.PlayOneShot(GunShot);
                // CinemachineShake.Instance.ShakeCamera();
            }
        }
        else
        {
            timeBtwShots -=Time.deltaTime;
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


}
