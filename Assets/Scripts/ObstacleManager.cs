using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    float speed;
    //BoxCollider2D _boxCollider;
    float _obstacleWidht;
    void Start()
    {
        //_boxCollider = GetComponent<BoxCollider2D>();
        _obstacleWidht = /*_boxCollider.size.x+*/10;
    }

    void Update()
    {
        MoveX();
        PositionLoop();

    }

    void MoveX()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    void PositionLoop()
    {
        if (transform.position.x < GameManager.bottonLeft.x-_obstacleWidht)
        {
            Destroy(gameObject);
        }
    }
}
