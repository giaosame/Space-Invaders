using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private static int _playerShipType = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame1()
    {
        _playerShipType = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayGame2()
    {
        _playerShipType = 2;
        SceneManager.LoadScene("MainScene");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    public static int GetPlayerShipType()
    {
        return _playerShipType;
    }
}
