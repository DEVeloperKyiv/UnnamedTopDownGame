using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float health, maxHealth = 100;
    public float lerpSpeed;


    

    private Rigidbody2D rb;
    public GameObject Bloodsplash; 
    private Vector2 moveVelocity;
    private Animator anim;
    public GameObject GameOver;
    public Shake shake;
    public Image healthBar;

    public AudioSource AudSource;
    public AudioClip hurt;

    bool facingRight = true;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    public Transform center;

    public bool canBeAttacked;
    public bool canMove;

    public bool isDead
    {
        get
        {
            return health == 0;
        }
    }

    void Start()
    {
        canBeAttacked = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        activeMoveSpeed = speed;
        health = maxHealth;
        canMove = true;
    }

    public void dmgPermit(int variable)
    {
        bool temp = Convert.ToBoolean(variable);
        canBeAttacked = temp;
    }
    public void movPermit(int variable)
    {
        bool temp = Convert.ToBoolean(variable);
        canMove = temp;
    }

    void Update()
    {
        HealthBarFiller();
        ColorChanger();

        lerpSpeed = 3f * Time .deltaTime;

        if(isDead == true)
        {
            GameObject.Find("Malyuk").GetComponent<LauncherScript>().enabled = false;
            GameOver.SetActive(true);
        }
        if(isDead == false && canMove == true)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * activeMoveSpeed;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(moveInput.x == 0 && moveInput.y == 0)
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
        if (canBeAttacked) 
        {
            shake.CamShake();
            Instantiate(Bloodsplash, transform.position, Quaternion.identity);
            health -= damage;

            AudSource.PlayOneShot(hurt);
        }


        if(isDead)
        {
            anim.SetTrigger("Death");
        }
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health /  maxHealth));
        healthBar.color = healthColor;
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
   // void GloryKill()
    //{
      //  Collider[] objects = Physics.OverlapSphere(transform.position, 5);

        //foreach (Collider i in objects)
        //{
          //  if (i.tag == "Enemy")
            //{
              //  Enemy enemyScript = i.GetComponent<Enemy>();
                //if(enemyScript.canBeExecuted == true && Input.GetKeyDown(KeyCode.E))
                //{
                  //  anim.SetTrigger("GKill");
                //}

            //}
        //}
    //}
}
