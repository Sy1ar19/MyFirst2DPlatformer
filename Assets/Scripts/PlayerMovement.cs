using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _isRunning = false;
    private bool _isAttacking = false;
    private bool _isJumping = false;

    public bool IsRunning { get { return _isRunning; } }
    public bool IsGrounded { get { return _isGrounded; } }
    public bool IsAttacking { get { return _isAttacking; } }
    public bool IsJumping { get { return _isJumping; } }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move();
        }
        else
        {
            _isRunning = false;
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
        else
        {
            _isAttacking = false;
        }
    }

    private void Jump()
    {
        _isJumping = true;
        _rigidbody2D.velocity = new Vector2(0, _jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _isGrounded = true;
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_isAttacking == true)
            {
                enemy.Die();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) => _isGrounded = false;

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        _isRunning = true;

        if (direction > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direction < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x + direction * step, transform.position.y), step);
    }

    private void Attack() => _isAttacking = true;
}
