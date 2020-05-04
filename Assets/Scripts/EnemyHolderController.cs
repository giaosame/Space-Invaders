using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHolderController : MonoBehaviour
{
    public GameObject Bullet;

    private Transform EnemyHolder;
    public static float Speed = 0.15f;
    public static float ShotRate = 0.998f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        EnemyHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {}

    void MoveEnemy()
    {
        EnemyHolder.position += Vector3.right * Speed;
        foreach (Transform enemy in EnemyHolder)
        {
            if (enemy.position.x < -10.5f || enemy.position.x > 10.5f)
            {
                Speed = -Speed;
                EnemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > ShotRate)
            {
                Instantiate(Bullet, enemy.position, Quaternion.identity);
            }
        }

        if (EnemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (EnemyHolder.childCount == 0)
        {
            RestartLevel.isPlayerWin = true;
        }
    }
}
