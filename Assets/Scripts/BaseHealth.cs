using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
	public float health = 5f;
   
    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
        	Destroy(gameObject);
        }
    }
}
