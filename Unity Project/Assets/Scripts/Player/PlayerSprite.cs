using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite _forwardSprite;
    [SerializeField] private Sprite _backwardSprite;
    [SerializeField] private Sprite _sideSprite;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;

    private bool isLookingUp, isLookingDown, isLookingLeft, isLookingRight;
    private Vector2 _input;
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _spriteRenderer.sprite = _forwardSprite;
    }

    void Update()
    {
        _input = _playerController._input;

        if (_input == Vector2.zero)
            return;
        
        if (_input.x > 0)
        {
            _spriteRenderer.flipX = false;
            _spriteRenderer.sprite = _sideSprite;
        }

        if (_input.x < 0)
        {
            _spriteRenderer.flipX = true;
            _spriteRenderer.sprite = _sideSprite;
        }
        
        if (_input.y > 0)
        {
            _spriteRenderer.flipX = false;
            _spriteRenderer.sprite = _backwardSprite;
        }

        if (_input.y < 0)
        {
            _spriteRenderer.flipX = false;
            _spriteRenderer.sprite = _forwardSprite;
        }
    }
}
