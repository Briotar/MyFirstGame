using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTracker : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    [SerializeField] private float _offset;

    private void Update()
    {
        transform.position = new Vector3(_plane.transform.position.x, _plane.transform.position.y + _offset, transform.position.z);
    }
}
