using UnityEngine;

[System.Serializable]
public abstract class Item
{
    // Abstract requires unique name per item
    public abstract string GetName();
    
    public virtual void Update(PlayerCurrencies player, int count)
    {
        
    }

    public virtual void OnHit(PlayerCurrencies player, Enemy enemy, int count)
    {
        
    }

    public virtual void OnHeal(PlayerCurrencies player, int count)
    {
        
    }

    public virtual void OnToggleSkill(PlayerCurrencies player)
    {
        
    }
}

public class HealingItem : Item
{
    public override string GetName()
    {
        return "Test Healing Item";
    }

    public override void Update(PlayerCurrencies player, int count)
    {
        player.health += 3 + (2 * count);
    }
}

public class FireDamageItem : Item
{
    public override string GetName()
    {
        return "Test Fire Damage Item";
    }

    public override void OnHit(PlayerCurrencies player, Enemy enemy, int count)
    {
        enemy.health -= 10.0f * count;
    }
}

public class HealingArea : Item
{
    private float _cooldownTime = 10.0f;
    private float internalCooldown;
    private GameObject effect;
    public override string GetName()
    {
        return "Test Healing Area";
    }

    public override void Update(PlayerCurrencies player, int count)
    {
        internalCooldown -= 1;
    }

    public override void OnHeal(PlayerCurrencies player, int count)
    {
        if (internalCooldown > 0)
            return;
        
        if (effect == null)
            effect = (GameObject)Resources.Load("Item Effects/Heal Effect Particle System", typeof(GameObject));

        GameObject HealingArea =
            GameObject.Instantiate(effect, player.transform.position, Quaternion.Euler((Vector3.zero)));

        internalCooldown = _cooldownTime;
    }
}

public class SpeedItem : Item
{
    private bool _isEnabled = false;
    private float boostPercentage = 1.0f;
    
    public override string GetName()
    {
        return "Test Speed Item";
    }

    public override void Update(PlayerCurrencies player, int count)
    {
        player.movementSpeedMultiplier = _isEnabled ? 1.0f + boostPercentage : 1.0f;
    }

    public override void OnToggleSkill(PlayerCurrencies player)
    {
        _isEnabled  = !_isEnabled;
    }
}