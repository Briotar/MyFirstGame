using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    [SerializeField] private MenuController _menuController;

    public UnityAction EndGame;
    public UnityAction StartGame;

    private void OnEnable()
    {
        _plane.Dying += EndingGame;
        _menuController.RestartButtonClick += StartingGame;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _plane.Dying -= EndingGame;
        _menuController.RestartButtonClick -= StartingGame;
    }

    private void EndingGame()
    {
        EndGame?.Invoke();
    }

    private void StartingGame()
    {
        Time.timeScale = 1;
        StartGame?.Invoke();

        _plane.gameObject.SetActive(true);
        _plane.PlaySound();
    }
}
