using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottonLeft;
    public static int gameScore;
    public static bool gameStarted;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject GetReady;
    public GameObject score;
    

    private void Awake()
    {
        bottonLeft = Camera.main.ScreenToViewportPoint(new Vector2(0, 0));
    }

    void Start()
    {
        gameStarted = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }
    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore= score.GetComponent<Score>().GetScore();
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
