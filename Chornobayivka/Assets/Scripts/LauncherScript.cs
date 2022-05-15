using System.Collections;
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

    void Start()
    {

    }

    // Update is called once per frame
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
            }
        }
        else
        {
            timeBtwShots -=Time.deltaTime;
        }
        if(mousePos.x<transform.position.x && facingRight)
        {
            Flip();
        }
        else if(mousePos.x>transform.position.x && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight; 
        transform.Rotate(0f, 180f, 0f); 
    }
}
