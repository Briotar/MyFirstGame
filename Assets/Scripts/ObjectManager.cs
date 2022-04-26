using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : ObjectPool
{
    [SerializeField] protected Plane _plane;
    [SerializeField] protected List<GameObject> _spawnPoints;
    [SerializeField] protected Game _game;
    [SerializeField] protected float _timeSpawnNewObject;

    protected void OnEnable()
    {
        _game.StartGame += RestartGame;
    }

    protected void OnDisable()
    {
        _game.StartGame -= RestartGame;
    }

    protected virtual void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _timeSpawnNewObject)
        {
            if (TryGetObject(out GameObject spanedObject))
            {
                _timeAfterLastSpawn = 0;

                SetObject(spanedObject);
            }
        }
    }

    protected virtual void SetObject(GameObject spawnedObject)
    {
        spawnedObject.gameObject.SetActive(true);

        int numberSpawnPoint = Random.Range(0, _spawnPoints.Count);
        Vector3 spawnPosition = new Vector3(_spawnPoints[numberSpawnPoint].transform.position.x, _spawnPoints[numberSpawnPoint].transform.position.y, 0f);
        spawnedObject.gameObject.transform.position = spawnPosition;
    }

    protected void RestartGame()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            _pool[i].gameObject.SetActive(false);
        }

        _timeAfterLastSpawn = 0;
    }
}
