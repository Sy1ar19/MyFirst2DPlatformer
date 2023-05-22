using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Fader _fader;
    [SerializeField] private PauseMenu _pauseMenu;

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
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
