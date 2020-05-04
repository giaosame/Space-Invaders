using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{
    private float timer = 0.0f;
    private float waitTime = 0.8f;
    private TextMeshProUGUI _gameOverText;

    public AudioSource ExplosionSound;
    public static bool isPlayerDead;


    // Start is called before the first frame update
    void Start()
    {
        isPlayerDead = false;
        _gameOverText = GetComponent<TextMeshProUGUI>();
        _gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            if (timer.Equals(0f))
            {
                ExplosionSound.Play();
            }

            // Wait for a second
            timer += Time.deltaTime; 
            if (timer > waitTime && !_gameOverText.enabled)
            {
                _gameOverText.enabled = true;
            }

            if (timer > (int)(waitTime * 3f))
            {
                RestartLevel.ResetLevel();
                SceneManager.LoadScene("StartScene");
            }
        }
    }
}
