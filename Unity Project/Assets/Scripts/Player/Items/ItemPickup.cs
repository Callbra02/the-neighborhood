using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Items itemDrop;
    
    void Start()
    {
        item = AssignItem(itemDrop);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCurrencies player = collision.GetComponent<PlayerCurrencies>();
            AddItem(player);
            Destroy(this.gameObject);
        }
    }

    public void AddItem(PlayerCurrencies player)
    {
        foreach (ItemList i in player.items)
        {
            if (i.name == item.GetName())
            {
                i.count += 1;
                return;
            }
        }
        
        player.items.Add(new ItemList(item, item.GetName(), 1));
    }

    public Item AssignItem(Items itemToAssign)
    {
        switch (itemToAssign)
        {
            case  Items.HealingAreaItem:
                return new HealingArea();
            case Items.FireDamageItem:
                return new FireDamageItem();
            case Items.HealingItem:
                return new HealingItem();
            case Items.SpeedItem:
                return new SpeedItem();
            default:
                return new HealingItem();
        }
        
    }
}

public enum Items
{
    HealingItem,
    FireDamageItem,
    HealingAreaItem,
    SpeedItem
}
