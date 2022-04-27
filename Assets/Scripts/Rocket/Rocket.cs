using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RocketMover))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleTrack;

    private ExplosionSpawner _explosionSpawner;

    private RocketMover _rocketMover;
    private SpriteRenderer _sprite;
    private Collider2D _collider;

    private void Awake()
    {
        _rocketMover = GetComponent<RocketMover>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
            if (collision.gameObject.TryGetComponent<Plane>(out Plane player))
            {
                player.OnDying();
                Death();
            }
            else
            {
                Death();
            }
    }
    
    private void Death()
    {
        _explosionSpawner.SpawnExplosion(transform.position);
        _collider.enabled = false;
        _sprite.enabled = false;
        _particleTrack.Stop();
        StartCoroutine(DeathCorotine());
    }

    private IEnumerator DeathCorotine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
    }
    
    public void Init(Plane target, ExplosionSpawner explosionSpawner)
    {
        _explosionSpawner = explosionSpawner;
        _rocketMover.Init(target);
        _sprite.enabled = true;
        _collider.enabled = true;
    }
}
