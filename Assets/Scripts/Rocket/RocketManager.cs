using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : ObjectManager
{
    [SerializeField] private ExplosionSpawner _explosionSpawner;

    protected override void SetObject(GameObject rocketObject)
    {
        var rocket = rocketObject.GetComponent<Rocket>();
        rocket.Init(_plane, _explosionSpawner);
        base.SetObject(rocketObject);
    }
}
