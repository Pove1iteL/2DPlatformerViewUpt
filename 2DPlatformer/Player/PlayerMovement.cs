using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string IsMover = "IsMove";
    private const string IsJimp = "IsJump";

    [SerializeField] private float _speed;
    [SerializeField] private int _highJump = 3;

    private Rigidbody2D _move;
    private Animator _animator;
    private SpriteRenderer _flip;
    private float _directionX;
    private Vector2 _jumpForce;

    private void OnEnable()
    {
        _flip = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _move = GetComponent<Rigidbody2D>();
        _jumpForce = new Vector2(_move.velocity.x, _highJump);
    }

    private void Update()
    {
        Move();

        ShowVisual();

        Jumping();
    }

    private void Move()
    {
        _directionX = Input.GetAxisRaw(Horizontal);
        _move.velocity = new Vector2(_directionX * _speed, _move.velocity.y);
    }

    private void ShowVisual()
    {
        if (_directionX > 0f)
        {
            _animator.SetBool(IsMover, true);

            _flip.flipX = false;
        }
        else if (_directionX < 0f)
        {
            _animator.SetBool(IsMover, true);

            _flip.flipX = true;
        }
        else if (_directionX == 0f)
        {
            _animator.SetBool(IsMover, false);
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _move.AddForce(_jumpForce, ForceMode2D.Impulse);
            _animator.SetBool(IsJimp, true);
        }
        else
        {
            _animator.SetBool(IsJimp, false);
        }
    }
}
