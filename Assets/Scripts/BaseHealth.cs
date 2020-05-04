using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public static float InitialHealth = 5f;
    public AudioSource ExplosionSound;

    private float _health;

    void Start()
    {
        _health = InitialHealth;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (_health <= 0f)
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            ExplosionSound.Play();

            Destroy(gameObject);
        }
    }

    public void ReduceHealth()
    {
        _health--;
    }
}
