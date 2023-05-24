using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    float _speed;
    int _angle;
    int _maxAngle = 20;
    int _minAngle = -60;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveUp();
        MovementLimitation();
        MoveRotation();


    }

    void MoveUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
    }

    void MovementLimitation()
    {
         float _yPos = Mathf.Clamp(transform.position.y, -6f, 8.25f);
        transform.position = new Vector2(transform.position.x, _yPos);
    }

    void MoveRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (_angle <= _maxAngle)
            {
                _angle += 4;
            }
        }
        else if (_rb.velocity.y < 0)
        {
            if (_angle >= _minAngle)
            {
                _angle -= 2;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
