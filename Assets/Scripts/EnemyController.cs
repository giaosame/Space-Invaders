using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool _shot = false;
    private Rigidbody _enemyRigidBody;

    public Material ShootMaterial;
    public GameObject ExplosionEffect;
    public AudioSource ExplosionSound;
    public int EnemyHealth = 2;

    void Start()
    {
        _enemyRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public bool IsShot()
    {
        return _shot;
    }

    void Update()
    {
        if (!_shot)
        {
            if (gameObject.transform.position.y <= -4f)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0f;
            }

            if (_enemyRigidBody.useGravity)
            {
                _shot = true;
                ChangeMaterial();
                gameObject.transform.parent = null;
                //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }

        if (_shot)
        {
            if (gameObject.transform.position.y <= -3f)
            {
                PlayerScore.Score += (PlayerScore.Increment / 2);
                Destroy(gameObject);
            }
        }

        if (!_enemyRigidBody.velocity.Equals(Vector3.zero))
        {
            _enemyRigidBody.useGravity = true;
        }

        if (EnemyHealth == 0)
        {
            ExplosionEffect.transform.localScale = Vector3.one * 0.5f;
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            ExplosionSound.Play();
            Destroy(gameObject);
        }
            
    }

    void ChangeMaterial()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = ShootMaterial;
        }
    }
}
