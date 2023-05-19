using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_playerMovement.IsRunning)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        if (_playerMovement.IsGrounded == false && _playerMovement.IsJumping == true)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }

        if (_playerMovement.IsAttacking)
        {
            _animator.SetBool("Attack", true);
        }
        else
        {
            _animator.SetBool("Attack", false);
        }

        if(_player.IsDead == true) 
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Die", true);
        }
    }
}
