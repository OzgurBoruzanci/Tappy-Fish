using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottonLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;

    private void Awake()
    {
        bottonLeft = Camera.main.ScreenToViewportPoint(new Vector2(0, 0));
    }

    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
