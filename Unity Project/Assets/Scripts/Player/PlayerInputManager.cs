using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance { get; private set; }
    
    [Header("Skill Input Actions")]
    public InputActionReference _skillAction1;
    public InputActionReference _skillAction2;
    public InputActionReference _skillAction3;
    public InputActionReference _skillAction4;

    [Header("Player Movement")] 
    public InputActionReference _moveAction;

    public InputActionReference _sprintAction;
    public InputActionReference _dashAction;
    
    private void Awake()
    {
        if (instance != null &&  instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    

    
}
