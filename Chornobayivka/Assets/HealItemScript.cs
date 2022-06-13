using UnityEngine;

public class HealItemScript : MonoBehaviour
{
    public int healAMT;
    private AudioSource source;
    private SpriteRenderer _renderer;
    public AudioClip onContact;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");

            PlayerMovement pScript = collision.gameObject.GetComponent<PlayerMovement>();
            if (pScript.maxHealth - pScript.health < healAMT)
            {
                pScript.health = pScript.maxHealth;
                _renderer.enabled = false;
                source.PlayOneShot(onContact);
                Destroy(gameObject,1f);
            }
            else
            {
                pScript.health += healAMT;
                _renderer.enabled = false;
                source.PlayOneShot(onContact);
                Destroy(gameObject,1f);
            }
        }
    }
}
