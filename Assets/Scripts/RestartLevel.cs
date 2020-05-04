using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartLevel : MonoBehaviour
{
    private TextMeshProUGUI _levelText;
    private static int _level = 1;
    private static bool _hasShown = false;
    private static float _timer = 0f;
    private float _showTime;

    public static bool isPlayerWin;
    public GameObject WinUI;

    void Start()
    {
        _showTime = 1f;
        
        _levelText = GetComponent<TextMeshProUGUI>();
        _levelText.SetText("Level " + _level);
        _levelText.enabled = true;
        isPlayerWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _showTime && !_hasShown)
        {
            _levelText.enabled = false;
            _hasShown = true;
        }

        if (isPlayerWin)
        {
            WinUI.SetActive(true);
            Time.timeScale = 0f;
            if (Input.anyKey || Input.anyKeyDown)
            {
                PrepareNextLevel();
            }
        }
    }

    public void UpgradeLevel()
    {
        _levelText.SetText("Level " + (++_level));
        _levelText.enabled = true;
        _timer = 0f;

        PlayerScore.Increment += 6;
        BaseHealth.InitialHealth += 5;

        EnemyHolderController.Speed += 0.075f;
        EnemyHolderController.ShotRate -= 0.015f;
    }

    void PrepareNextLevel()
    {
        isPlayerWin = false;
        _hasShown = false;
        WinUI.SetActive(false);
        Time.timeScale = 1f;    
        UpgradeLevel();
        PlayNextLevelGame();
    }

    void PlayNextLevelGame()
    {
        GameOver.isPlayerDead = false;
        SceneManager.LoadScene("MainScene");
    } 

    public static void ResetLevel()
    {
        _hasShown = false;

        _level = 1;
        _timer = 0f;
        PlayerScore.Score = 0f;
        PlayerScore.Increment = 10;
        BaseHealth.InitialHealth = 5f;

        EnemyHolderController.Speed = 0.15f;
        EnemyHolderController.ShotRate = 0.998f;
    }
}
