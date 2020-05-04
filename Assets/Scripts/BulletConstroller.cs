using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConstroller : MonoBehaviour
{
	private Transform _bulletTrans;
    private Rigidbody _bulletRigidBody;
	public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        _bulletTrans = GetComponent<Transform>();
        _bulletRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _bulletTrans.position += Vector3.up * Speed;

        if (_bulletTrans.position.y >= 13.5)
        {   // TODO: fix
            _bulletRigidBody.velocity = Vector3.zero;
            _bulletRigidBody.useGravity = true;
        }
        	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            other.attachedRigidbody.useGravity = true;
            other.GetComponentInParent<EnemyController>().EnemyHealth--;

            // Increases player's score
            PlayerScore.Score += PlayerScore.Increment;
            // Audio.isInvaderKilled = true;
        }
        else if(other.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}
