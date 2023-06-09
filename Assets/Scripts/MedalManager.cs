using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalManager : MonoBehaviour
{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    int gameScore;
    private void Start()
    {
        img = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        gameScore = GameManager.gameScore;
        if(gameScore>0&& gameScore<=2)
        {
            img.sprite=metalMedal;
        }
        else if (gameScore > 2 && gameScore <= 4)
        {
            img.sprite = bronzeMedal;
        }
        else if (gameScore > 4 && gameScore <= 6)
        {
            img.sprite = silverMedal;
        }
        else if (gameScore > 6)
        {
            img.sprite = goldMedal;
        }
    }
}
