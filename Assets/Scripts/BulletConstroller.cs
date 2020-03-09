using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConstroller : MonoBehaviour
{
	private Transform bullet;
	public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
        	Destroy (gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            
            // Increases player's score
            PlayerScore.playerScore += 10;
            // Audio.isInvaderKilled = true;
        }
        else if(other.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}
