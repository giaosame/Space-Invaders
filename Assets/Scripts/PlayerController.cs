using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	private Transform player;
	public float speed;
	public float maxBound = 10;
	public float minBound = -10;

    public GameObject ExplosionEffect;
    public GameObject Bullet;
	public Transform BulletSpawnTransform;
    public AudioSource FireSound;
    public float shotRate;

	private float nextShot;

    // Start is called before the first frame update
    void Start()
    {
    	player = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound && h < 0)
        	h = 0;
        else if (player.position.x > maxBound && h > 0)
        	h = 0;

        player.position += Vector3.right * h * speed;
    }

    void Update()
    {
    	if (Input.GetButton("Fire1") && Time.time > nextShot)
    	{
    		nextShot = Time.time + shotRate;
    		Instantiate(Bullet, BulletSpawnTransform.position, Quaternion.identity);
            FireSound.Play();
        }
    }

    public void Destroy()
    {
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        
        GameOver.isPlayerDead = true;
        Destroy(gameObject);
    }
}
