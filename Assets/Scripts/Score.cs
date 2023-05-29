using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    int _score = 0;

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
    }
    void Scored()
    {
        _score++;
        scoreText.text = _score.ToString() + " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
