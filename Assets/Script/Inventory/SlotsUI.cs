using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotsUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    private Inventory.Slot currentSlot;

    public void SetItem(Inventory.Slot slot)
    {
        currentSlot = slot;
        if (slot != null) 
        { 
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        currentSlot = null;
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

    public void OnItemClick()
    {
        if (currentSlot != null)
        {
            // Add a switch statement for different item types
            switch (currentSlot.type)
            {
                case CollectableType.Potion:
                    ConsumePotion(currentSlot, 10, "health");
                    break;
                case CollectableType.ManaPotion:
                    ConsumePotion(currentSlot, 5, "mana");
                    break;
                case CollectableType.CorruptPotion:
                    ConsumePotion(currentSlot, 10, "corruption");
                    break;
                case CollectableType.PurePotion:
                    ConsumePotion(currentSlot, -10, "corruption");
                    break;
                case CollectableType.MoneyBag:
                    AddCoins(30);
                    currentSlot.count--; // Decrease the count of the consumed money bag
                    if (currentSlot.count == 0) SetEmpty(); // Set the slot as empty if the count is zero
                    else quantityText.text = currentSlot.count.ToString(); // Update the quantity text
                    break;
            }
        }
    }

    private void ConsumePotion(Inventory.Slot slot, int amount, string effectType)
    {
        // Apply the appropriate logic based on the effect type
        switch (effectType)
        {
            case "health":
                FindObjectOfType<PlayerHealth>().Heal(amount);
                break;
            case "mana":
                FindObjectOfType<PlayerMana>().IncreaseMana(amount);
                break;
            case "corruption":
                FindObjectOfType<PlayerCorruption>().AdjustCorruption(amount);
                break;
            default:
                Debug.Log("Invalid potion type");
                break;
        }

        // Decrease the count of the consumed potion
        slot.count--;

        // If the count becomes zero, set the slot as empty
        if (slot.count == 0)
        {
            SetEmpty();
        }
        else
        {
            // Update the quantity text if the count is greater than zero
            quantityText.text = slot.count.ToString();
        }
    }

    private void AddCoins(int amount)
    {
        ShopManager.instance.coins += amount;
        ShopManager.instance.UpdateCoinText();
    }


}