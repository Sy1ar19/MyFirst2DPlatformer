using System.Collections;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _coinSpawnerPosition;
    [SerializeField] private float _repeatRate;

    private WaitForSeconds _wait;
    private int _randomSpawnPoint;
    private float colliderRange = 0.2f;
    private void Start()
    {
        _wait = new WaitForSeconds(_repeatRate);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return _wait;

            _randomSpawnPoint = Random.Range(0, _coinSpawnerPosition.Length);
            Transform spawnPoint = _coinSpawnerPosition[_randomSpawnPoint];

            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, colliderRange);
            bool coinExists = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Coin coin))
                {
                    coinExists = true;
                    break;
                }
            }

            if (!coinExists)
            {
                Instantiate(_coin, _coinSpawnerPosition[_randomSpawnPoint].position, Quaternion.identity);
            }
        }
    }
}
