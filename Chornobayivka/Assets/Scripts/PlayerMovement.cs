using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float health;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    public GameObject GameOver;
    public Shake shake;

    bool facingRight = true;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    public bool isDead
    {
        get
        {
            return health == 0;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        activeMoveSpeed = speed;
    }

    void Update()
    {
        if(isDead == true)
        {
            GameObject.Find("Malyuk").GetComponent<LauncherScript>().enabled = false;
            GameOver.SetActive(true);
        }
        if(isDead == false)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * activeMoveSpeed;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(moveInput.x == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }

            if(moveInput.x < 0 && facingRight)
            {
                Flip();
            }
            else if(moveInput.x > 0 && !facingRight)
            {
                Flip();
            }

            if(health < 0)
            {
                Debug.Log("Player lost HP");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter < 0)
                {
                    activeMoveSpeed = speed;
                    dashCoolCounter = dashCooldown;
                }
            }
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }else
        {
            enabled = false;
        }
    }

    public void TakeDamage(int damage)
    {
        shake.CamShake();
        health -= damage;

        if(isDead)
        {
            anim.SetTrigger("Death");
        }
    }

    void Flip()
    {
        facingRight = !facingRight; 
        transform.Rotate(0f, 180f, 0f); 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
