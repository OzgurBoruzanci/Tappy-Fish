using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottonLeft;

    private void Awake()
    {
        bottonLeft = Camera.main.ScreenToViewportPoint(new Vector2(0, 0));
    }

    void Start()
    {
        Debug.Log(bottonLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
