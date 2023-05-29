using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject obstacle;
    float _timer;
    public float maxTime;
    float randomY;

    void Start()
    {
        
    }

    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>=maxTime)
        {
            InstantiateObstacle();
            _timer = 0;
        }
        
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle= Instantiate(obstacle);
        randomY = Random.Range(-3.6f, 5.6f);
        newObstacle.transform.position=new Vector2(transform.position.x,randomY);
        //newObstacle.transform.parent = transform;
    }
}
