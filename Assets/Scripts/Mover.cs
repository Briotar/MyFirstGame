using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Mover : MonoBehaviour
{
    protected float _speed;
    protected float _rotationSpeed;
    protected float _rotation;
    protected float _currentRotation;

    protected Vector2 _direction;
    protected Rigidbody2D _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _direction = Vector2.up;
        _rotation = 0;
        _currentRotation = 0;
    }

    protected virtual void Update()
    {
        _rigidbody.velocity = _direction * _speed;
        _rigidbody.rotation = _rotation;
    }

    protected void CalculateRotationAngle()
    {
        _currentRotation = Mathf.Acos(_direction.y) * Mathf.Rad2Deg;

        if (_direction.x > 0)
            _currentRotation = -_currentRotation;

        _rotation = Mathf.Lerp(_rotation, _currentRotation, _rotationSpeed * Time.deltaTime);
        _rotation = _currentRotation;
    }

    public void AdjustmentDirection(Vector2 newDirection)
    {
        _direction = (Vector2.Lerp(_direction, (_direction + newDirection), _rotationSpeed * Time.deltaTime)).normalized;
        CalculateRotationAngle();
    }
}
