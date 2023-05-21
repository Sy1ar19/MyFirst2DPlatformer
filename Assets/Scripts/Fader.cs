using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Button _retryButton;

    private const float blinkOffDuration = 0.2f;
    private const float blinkOnDuration = 0.3f;

    private bool _isRestart;
    private float _alpha;
    private CanvasGroup _canvasGroup;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _alpha = 1;
        _retryButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(0.05f);
    }

    public IEnumerator Fade( bool isVisible)
    {
        float step = isVisible ? 0.1f : -0.1f;
        int endValue = isVisible ? 1 : 0;

        while (_alpha != endValue)
        {
            _alpha += step;
            _canvasGroup.alpha = _alpha;

            _alpha = Mathf.Clamp01(_alpha);

            yield return _waitForSeconds;
        }
    }

    public IEnumerator StartBlinkRetryButton()
    {
        _retryButton.gameObject.SetActive(true);
        Image image = _retryButton.GetComponent<Image>();

        while (_isRestart)
        {
            image.enabled = false;

            yield return new WaitForSeconds(blinkOffDuration);

            image.enabled = true;

            yield return new WaitForSeconds(blinkOnDuration);
        }
    }

}
