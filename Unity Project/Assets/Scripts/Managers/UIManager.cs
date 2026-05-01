using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform[] skillSlotSpritePositions;
    
    public GameObject[] skillSlotSprites;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SetSlotSprite(int slot, Items itemType)
    {
        switch (itemType)
        {
            case Items.SpeedItem:
                break;
            case Items.HealingItem:
                break;
            case Items.FireDamageItem:
                break;
            case Items.HealingAreaItem:
                break;
        }
        
    }
}
