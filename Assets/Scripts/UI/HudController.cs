using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private HudView _hudView;
    [SerializeField] private EndScreenView _endScreenView;
    [SerializeField] private Game _game;
    [SerializeField] private Plane _plane;

    private float _currentTime;
    private int _currentTimeSeconds;
    private int _currentTimeMinuts;
    private int _coinsCount;

    private void OnEnable()
    {
        _game.StartGame += Initialize;
        _plane.CoinCountChanged += ChangeCoinLabel;
        _plane.Dying += ShowEndcreenInfo;
        Initialize();
    }

    private void OnDisable()
    {
        _game.StartGame -= Initialize;
        _plane.CoinCountChanged -= ChangeCoinLabel;
        _plane.Dying -= ShowEndcreenInfo;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        GetTimeMinutsAndSeconds();
        _hudView.ShowTime(_currentTimeMinuts, _currentTimeSeconds);
    }

    private void GetTimeMinutsAndSeconds()
    {
        _currentTimeSeconds = (int)_currentTime;

        if (_currentTimeSeconds >= 60)
        {
            _currentTimeSeconds = 0;
            _currentTime = 0f;
            _currentTimeMinuts++;
        }
    }

    private void Initialize()
    {
        _currentTimeSeconds = 0;
        _currentTimeMinuts = 0;
        _currentTime = 0;
        ChangeCoinLabel(0);
    }

    private void ChangeCoinLabel(int coinCount)
    {
        _coinsCount = coinCount;
        _hudView.ShowCoins(coinCount);
    }

    private void ShowEndcreenInfo()
    {
        _endScreenView.OnEndscreenShow(_coinsCount, _currentTimeMinuts, _currentTimeSeconds);
    }
}
