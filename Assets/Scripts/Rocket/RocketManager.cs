using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : ObjectManager
{
    [SerializeField] private ExplosionSpawner _explosionSpawner;

    private int _currentRocketCount;

    protected override void Start()
    {
        base.Start();

        _currentRocketCount = 0;
    }

    protected override void SetObject(GameObject rocketObject)
    {
        var rocket = rocketObject.GetComponent<Rocket>();
        rocket.Init(_plane, _explosionSpawner);
        base.SetObject(rocketObject);
    }
}
