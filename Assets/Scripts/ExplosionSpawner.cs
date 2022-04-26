using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionSpawner : ObjectPool
{
    private AudioSource _audioSourse;

    private void Awake()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    private void SetObject(GameObject spawnedObject, Vector2 spawnPoint)
    {
        spawnedObject.gameObject.SetActive(true);

        Vector3 spawnPosition = new Vector3(spawnPoint.x, spawnPoint.y, 0f);
        spawnedObject.gameObject.transform.position = spawnPosition;

        StartCoroutine(ShutdownParticle(spawnedObject));
    }

    private IEnumerator ShutdownParticle(GameObject spawnedObject)
    {
        yield return new WaitForSeconds(3f);

        spawnedObject.SetActive(false);
    }

    public void SpawnExplosion(Vector2 spawnPoint)
    {
        if (TryGetObject(out GameObject spanedObject))
        {
            _audioSourse.Play();
            SetObject(spanedObject, spawnPoint);
        }
    }

}
