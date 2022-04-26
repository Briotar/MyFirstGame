using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMover : Mover
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minRotationSpeed;
    [SerializeField] private float _maxRotationSpeed;

    private Plane _target;

    protected override void Start()
    {
        base.Start();

        _speed = Random.Range(_minSpeed, _maxSpeed);
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
    }

    protected override void Update()
    {
        CalculateDirectionToPlane();

        base.Update();
    }

    private void CalculateDirectionToPlane()
    {
        Vector2 newDirection = new Vector2(_target.transform.position.x - transform.position.x, _target.transform.position.y - transform.position.y);
        AdjustmentDirection(newDirection);
    }

    public void Init(Plane target)
    {
        _target = target;
    }
}
