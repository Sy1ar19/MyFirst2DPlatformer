using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemyMovement;
    private static readonly int RunParamHash = Animator.StringToHash("Run");

    private bool _isRunning;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();

        _enemyMovement.OnRunningStateChanged += UpdateRunningState;
    }

    private void OnDestroy()
    {
        _enemyMovement.OnRunningStateChanged -= UpdateRunningState;
    }

    private void UpdateRunningState(bool isRunning)
    {
        _isRunning = isRunning;
        _animator.SetBool(RunParamHash, _isRunning);
    }
}
