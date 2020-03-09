using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public GameObject bullet;
    public Text winText;
    public float shotRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5f || enemy.position.x > 10.5f)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > shotRate)
            {
                Instantiate(bullet, enemy.position, enemy.rotation);
            }

            if (enemy.position.y <= -4f)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0f;
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
        }
    }
}
