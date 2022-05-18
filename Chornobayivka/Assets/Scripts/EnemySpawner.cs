using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float cooldown;
    private float countdown;
    public GameObject babyi_narozhayut;
    private void Start()
    {
        countdown = cooldown;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Instantiate(babyi_narozhayut, transform.position, Quaternion.identity);
            countdown = cooldown;
        }
    }
}
