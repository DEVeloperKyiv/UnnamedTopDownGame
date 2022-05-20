using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float movingSpeed;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10,
        };

        void Update()
        {
            if(this.playerTransform)
            {
                Vector3 target = new Vector3()
                {
                    x = this.playerTransform.position.x,
                    y = this.playerTransform.position.y,
                    z = this.playerTransform.position.z - 10,
                };
            }

            Vector3 pos = Vector3.Lerp(this.transform.position, target.position, this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}
