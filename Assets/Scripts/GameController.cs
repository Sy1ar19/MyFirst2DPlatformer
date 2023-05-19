using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Fader _fader;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(StartRoutine());
    }

    public void LoseGame()
    {
        StartCoroutine(LoseRoutine());
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator StartRoutine()
    {
        yield return StartCoroutine(_fader.Fade(false));

        _fader.gameObject.SetActive(false);

        Time.timeScale = 1.0f;
    }

    private IEnumerator LoseRoutine()
    {
        Time.timeScale = 0.4f;

        _fader.gameObject.SetActive(true);

        yield return StartCoroutine(_fader.Fade(true));

        StartCoroutine(_fader.StartBlinkRetryButton());
    }
}
