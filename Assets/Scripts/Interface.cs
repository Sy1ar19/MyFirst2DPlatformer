using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    public void Pause()
    {
        _gameController.Pause();
    }
}
