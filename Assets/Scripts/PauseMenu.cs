using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused = false;
    public GameObject PausedMenuUI;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused)
            {
                ResumeGame();
            }
            else
            {
                _paused = true;
                PausedMenuUI.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        _paused = false;
        PausedMenuUI.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;    
    }

    public void BackToStart()
    {
        RestartLevel.ResetLevel();
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void RestartGame()
    {
        RestartLevel.ResetLevel();
        PlayerScore.Score = 0;
        GameOver.isPlayerDead = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainScene");
    }
}
