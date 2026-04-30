using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _sprintAction;
    
    [SerializeField] private float _moveSpeed = 1.75f;
    [SerializeField] private float _sprintSpeed = 3.0f;

   
    private Vector2 _wishMovement;
    public Vector2 _input { get; private set; }
    private bool _isSprinting;
    private float _currentSpeed;
    private float _implicitSpeedMultiplier = 75.0f;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        
        _sprintAction.action.started += ctx => _isSprinting = true;
        _sprintAction.action.canceled += ctx => _isSprinting = false;
    }

    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        _currentSpeed = _isSprinting ? _sprintSpeed : _moveSpeed;
        
        _input = _moveAction.action.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        if (_input != Vector2.zero)
            _input.Normalize();

        _wishMovement = _input * (_currentSpeed * _implicitSpeedMultiplier * Time.fixedDeltaTime);
        
        _rigidbody.linearVelocity = _wishMovement;
    }
}
