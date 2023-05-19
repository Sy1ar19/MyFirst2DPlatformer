using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed;

    private int _currentIndex;
    private Vector2 _currentPoint;
    private bool _isRunning;
    private bool _isDead;

    public bool IsRunning { get { return _isRunning; } }

    private void Start()
    {
        _currentPoint = _points[0].position;
        _isRunning = true;

        ChooseDirection();
    }

    private void Update()
    {
        if (_isDead) { return; }
        Run();
    }

    private void ChooseNextPoint()
    {
        _currentIndex = ++_currentIndex < _points.Count ? _currentIndex : 0;
        _currentPoint = _points[_currentIndex].position;

        ChooseDirection();
    }

    private void ChooseDirection()
    {
        GetComponent<SpriteRenderer>().flipX = _currentPoint.x < transform.position.x;
    }

    private void Run()
    {
        if (_isRunning)
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _currentPoint, step);

            if (Vector3.Distance(transform.position, _currentPoint) < 0.3f)
            {
                ChooseNextPoint();
            }
        }
    }
}
