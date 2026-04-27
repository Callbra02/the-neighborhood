using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;
    
    [SerializeField] public InputActionReference _moveAction;
    [SerializeField] public InputActionReference _sprintAction;
    [SerializeField] public InputActionReference _jumpAction;

    public float moveSpeed = 1.75f;
    public float sprintSpeed = 3.0f;
    public float jumpHeight = 5f;
    public LayerMask groundLayer;

    private float _currentSpeed;
    private Vector2 _movement;
    private Vector2 _input;
    private bool _isSprinting;
    private bool _isGrounded;
    private bool _doJump = false;
    public bool fastFall = false;
    public float fastFallGravity = 3.0f;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        
        _sprintAction.action.started += ctx => _isSprinting = true;
        _sprintAction.action.canceled += ctx => _isSprinting = false;
    }

    void Update()
    {
        _currentSpeed = _isSprinting ? sprintSpeed : moveSpeed;
        
        _isGrounded = GroundCheck();
        HandleInput();
    }

    private void HandleInput()
    {  
        _input = _moveAction.action.ReadValue<Vector2>();
        
        if (_jumpAction.action.WasPressedThisFrame() && _isGrounded)
        {
            _doJump = true;
        }
    }

    private void FixedUpdate()
    {
        HandleFastFall();
        HandleMovement();
        HandleJump();
    }

    private bool GroundCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, _collider.size.y * 0.6f, groundLayer))
        {
            return true;
        }

        return false;
    }

    private void HandleFastFall()
    {
        if (fastFall && _rigidbody2D.linearVelocity.y < 0)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _rigidbody2D.linearVelocity.y - (fastFallGravity * Time.fixedDeltaTime));
        }

    }

    private void HandleMovement()
    {
        if (_input != Vector2.zero)
            _input.Normalize();
        
        _movement = _input * (_currentSpeed * 75.0f) * Time.fixedDeltaTime;
        _movement.y = _rigidbody2D.linearVelocity.y;
        
        _rigidbody2D.linearVelocity = _movement;
    }
    
    private void HandleJump()
    {
        if (!_doJump)
            return;
        
        _rigidbody2D.AddForce(Vector2.up * jumpHeight,  ForceMode2D.Impulse);
        _doJump = false;
    }
    
}
