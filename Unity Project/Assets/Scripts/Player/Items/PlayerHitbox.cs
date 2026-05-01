using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public PlayerCurrencies playerCurrencies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.health -= playerCurrencies.attackDamage;
            playerCurrencies.CallItemOnHit(enemy);
        }
    }
}
