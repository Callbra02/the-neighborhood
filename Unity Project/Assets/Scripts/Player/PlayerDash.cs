using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private InputActionReference _dashAction;
    private InputActionReference _moveAction;
    [SerializeField] private float _dashSpeed;
    
    private bool _isDashing = false;
    private bool _doDash;
    private bool _canDash = true;
    private Vector3 _input;
    
    
    void Start()
    {
        _dashAction = PlayerInputManager.instance._dashAction;
        _moveAction = PlayerInputManager.instance._moveAction;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = _moveAction.action.ReadValue<Vector2>();
        _input.Normalize();
        HandleDash();
    }

    void HandleDash()
    {
        if (_dashAction.action.WasPressedThisFrame() && _canDash)
        {
            _doDash = true;
            _canDash = false;
        }
        
        Dash();
    }

    void Dash()
    {
        if (!_doDash)
            return;
        
        _rigidbody.AddForce(Vector2.up * _dashSpeed, ForceMode2D.Impulse);
        _canDash = true;
        _doDash = false;
    }
}
