using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : Mover
{
    [SerializeField] protected float _planeSpeed;
    [SerializeField] protected float _planeRotationSpeed;

    protected override void Start()
    {
        base.Start();

        _speed = _planeSpeed;
        _rotationSpeed = _planeRotationSpeed;
    }
}
