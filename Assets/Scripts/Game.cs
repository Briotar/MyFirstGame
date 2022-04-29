using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    [SerializeField] private MenuController _menuController;

    public event UnityAction EndedGame;
    public event UnityAction StartedGame;

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
        EndedGame?.Invoke();
    }

    private void StartingGame()
    {
        Time.timeScale = 1;
        StartedGame?.Invoke();

        _plane.gameObject.SetActive(true);
        _plane.PlaySound();
    }
}
