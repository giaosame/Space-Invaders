using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerShip1;
    public GameObject PlayerShip2;

    void Start()
    {
        if (StartMenu.GetPlayerShipType() == 1)
        {
            Instantiate(PlayerShip1, PlayerShip1.transform.position, PlayerShip1.transform.rotation);
        }
        else
        {
            Instantiate(PlayerShip2, PlayerShip2.transform.position, PlayerShip2.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
