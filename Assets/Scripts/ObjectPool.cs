using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected int _objectCount;
    [SerializeField] protected GameObject _template;

    protected List<GameObject> _pool;

    protected float _timeAfterLastSpawn;

    protected virtual void Start()
    {
        _pool = new List<GameObject>();
        _timeAfterLastSpawn = 0;

        for (int i = 0; i < _objectCount; i++)
        {
            Initialize();
        }
    }

    protected void Initialize()
    {
        GameObject spawnedObject = Instantiate(_template);
        spawnedObject.gameObject.SetActive(false);

        _pool.Add(spawnedObject);
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);        

        return result != null;
    }
}
