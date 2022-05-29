 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{


    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    private Shake shake;
    public GameObject Effect;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                shake.CamShake();
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }  
            Suicide();
        }

    }

    public void Suicide()
    {
        Instantiate(Effect,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
