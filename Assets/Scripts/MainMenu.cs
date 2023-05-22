using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Fader _fader;

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public IEnumerator LoadGame()
    {
        _fader.gameObject.SetActive(true);

        yield return StartCoroutine(_fader.Fade(true));

        SceneManager.LoadScene(1);
    }
}
