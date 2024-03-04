using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerMovement _followPlayer;

    private SpriteRenderer _flip;
    private int _currentPoint = 0;
    private Vector3 _target;
    private bool _isFollow;

    private void OnEnable()
    {
        _flip = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            _isFollow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            _isFollow = false;
        }
    }

    private void Update()
    {
        Flip();

        if (_isFollow)
        {
            Move(_followPlayer.transform.position);
        }
        else
        {
            PatrolLevel();
        }
    }

    private void PatrolLevel()
    {
        Move(_target);

        if (transform.position == _target)
        {
            _currentPoint++;

            if (_currentPoint > _points.Length - 1)
            {
                _currentPoint = 0;
            }
        }
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        _target = _points[_currentPoint].position;

        if (_currentPoint % _points.Length == 0)
        {
            _flip.flipX = false;
        }
        else
        {
            _flip.flipX = true;
        }
    }
}
