using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    public void MainMenu()
    {
        _gameController.ToMainMenu();
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        _gameController.Resume();
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        _gameController.Restart();
    }
}
