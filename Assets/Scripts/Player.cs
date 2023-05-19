using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameController _gameController;

    private int _coinAmmount;
    private bool _isDead = false;

    public bool IsDead { get { return _isDead; } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
            CollectCoin();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Spikes>())
        {
            Die();
        }
    }

    private void CollectCoin()
    {
        _coinAmmount++;
        _text.text = _coinAmmount.ToString();
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;

        _gameController.LoseGame();
    }
}
