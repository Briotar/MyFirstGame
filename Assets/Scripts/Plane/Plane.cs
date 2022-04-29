using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Plane : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _coinCount;

    public int CoinCount => _coinCount;

    public event UnityAction Dying;
    public event UnityAction<int> CoinCountChanged;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _coinCount = 0;
        CoinCountChanged?.Invoke(_coinCount);
    }

    private void OnDisable()
    {
        _audioSource.Stop();
    }

    private void CollectCoin()
    {
        _coinCount++;
        CoinCountChanged?.Invoke(_coinCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
            CollectCoin();
    }

    public void OnDying()
    {
        Dying?.Invoke();
        _coinCount = 0;
        gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

}
