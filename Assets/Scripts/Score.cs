using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    int _score = 0;
    int _highScore;

    private void OnEnable()
    {
        EventManager.Scored += Scored;
    }
    private void OnDisable()
    {
        EventManager.Scored-= Scored;
    }
    void Start()
    {
        scoreText=GetComponent<Text>();
        scoreText.text = _score.ToString() + " ";
        panelScore.text= _score.ToString() + " ";

        _highScore = PlayerPrefs.GetInt("HighScore");
        panelHighScore.text= _highScore.ToString()+ " ";
    }
    void Scored()
    {
        _score++;
        scoreText.text = _score.ToString() + " ";
        panelScore.text= _score.ToString() + " ";

        if (_score>_highScore)
        {
            _highScore=_score;
            panelHighScore.text = _highScore.ToString() + " ";
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
