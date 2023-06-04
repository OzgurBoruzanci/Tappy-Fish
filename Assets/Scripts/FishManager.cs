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
    public GameManager gameManager;
    bool _touchedGround;
    public Sprite fishDied;
    public ObstacleSpawner obstacleSpawner;
    SpriteRenderer _sp;
    Animator _animator;
    [SerializeField] AudioSource _swimSound, _pointSound, _hitSound;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _sp= GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveUp();
        MovementLimitation();
        MoveRotation();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver==false)
            {
                gameManager.GameOver();
                GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            EventManager.Scored();
            _pointSound.Play();
        }
        else if (collision.CompareTag("Column") && !GameManager.gameOver)
        {
            gameManager.GameOver();
            GameOver();
        }
    }
    void MoveUp()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            _swimSound.Play();
            if (!GameManager.gameStarted)
            {
                _rb.gravityScale = 2f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
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
        if (!_touchedGround)
        {
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
    }

    void FishDiedEffect()
    {
        _hitSound.Play();
    }

    void GameOver()
    {
        _touchedGround = true;
        _sp.sprite = fishDied;
        _animator.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        FishDiedEffect();
    }
}
