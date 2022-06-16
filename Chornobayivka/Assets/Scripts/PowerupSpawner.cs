using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public float Cooldown;
    private float countdown;
    private int index;

    private void Start()
    {
        countdown = Cooldown;
    }
    private void Update()
    {
        countdown -= Time.deltaTime;
        index = Random.Range(0, powerups.Length);
        if (countdown <= 0)
        {
            Instantiate(powerups[index], new Vector3(Random.Range(-43, 49), Random.Range(-22, 23), 0), Quaternion.identity);
            countdown = Cooldown;
        }
        
    }
}
