using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    private bool gameIsPaused = false;
    public bool GameIsPaused  { get { return gameIsPaused; } }

    private bool playerIsDead = false;
    public bool PlayerIsDead
    {
        get { return playerIsDead; }
        set { playerIsDead = value;}
    }

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameOverMenuUI;

    private void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(false);

        gameIsPaused = false;
    }

    private void Update()
    {
        if (PlayerIsDead)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerIsDead)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        PlayerIsDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        PlayerIsDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
