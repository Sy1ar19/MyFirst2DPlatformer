using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(EnemyMovement))]
public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (_enemyMovement.IsRunning)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }
}
