using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField]
    float _speed;
    BoxCollider2D _boxCollider;
    float _groundWidht;
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _groundWidht = _boxCollider.size.x;
    }

    void Update()
    {
        MoveX();
        PositionLoop();

    }

    void MoveX()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
    }
    void PositionLoop()
    {
        if (transform.position.x <= -_groundWidht)
        {
            transform.position = new Vector2(transform.position.x + 2 * _groundWidht, transform.position.y);
        }
    }
}
