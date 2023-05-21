using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Player _player;

    private static readonly int RunParamHash = Animator.StringToHash("Run");
    private static readonly int JumpParamHash = Animator.StringToHash("Jump");
    private static readonly int AttackParamHash = Animator.StringToHash("Attack");
    private static readonly int DieParamHash = Animator.StringToHash("Die");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetBool(RunParamHash, _playerMovement.IsRunning);
        _animator.SetBool(JumpParamHash, _playerMovement.IsGrounded == false && _playerMovement.IsJumping == true);
        _animator.SetBool(AttackParamHash, _playerMovement.IsAttacking);

        if (_player.IsDead)
        {
            _animator.SetBool(RunParamHash, false);
            _animator.SetBool(DieParamHash, true);
        }
    }
}
