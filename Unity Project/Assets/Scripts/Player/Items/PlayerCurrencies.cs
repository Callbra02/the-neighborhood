using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCurrencies : MonoBehaviour
{
    private PlayerController playerController;
    
    [SerializeField] private InputActionReference healAction;
    public int health;
    public float attackDamage;
    public float movementSpeedMultiplier = 1;

    public List<ItemList> items = new List<ItemList>();
    
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        StartCoroutine(CallItemUpdate());
    }

    void Update()
    {
        playerController.moveSpeedMultiplier = movementSpeedMultiplier;
        if (healAction.action.WasPressedThisFrame())
        {
            CallItemOnHeal();
        }

        if (PlayerInputManager.instance._skillAction1.action.WasPressedThisFrame())
        {
            CallItemOnToggleSkill();
        }
    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList item in items)
        {
            item.item.Update(this, item.count);
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnHit(Enemy enemy)
    {
        foreach (ItemList item in items)
        {
            item.item.OnHit(this, enemy, item.count);
        }
    }

    public void CallItemOnHeal()
    {
        foreach (ItemList item in items)
        {
            item.item.OnHeal(this, item.count);
        }
    }

    public void CallItemOnToggleSkill()
    {
        foreach (ItemList item in items)
        {
            item.item.OnToggleSkill(this);
        }
    }
}
