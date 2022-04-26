using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _background;

    public UnityAction RestartButtonClick;

    private void OnEnable()
    {
        _game.EndGame += ShowEndScreen;
    }

    private void OnDisable()
    {
        _game.EndGame -= ShowEndScreen;
    }

    private void ShowEndScreen()
    {
        _endGameScreen.SetActive(true);
        _background.SetActive(true);
    }

    private void ShutdownUI(GameObject screenToShutdown)
    {
        RestartButtonClick?.Invoke();
        _background.SetActive(false);
        screenToShutdown.SetActive(false);
    }

    public void OnRestartButton()
    {
        ShutdownUI(_endGameScreen);
    }
    public void OnStartButton()
    {
        ShutdownUI(_startScreen);
    }
}
