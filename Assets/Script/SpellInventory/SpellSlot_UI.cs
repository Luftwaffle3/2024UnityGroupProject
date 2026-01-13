using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellSlot_UI : MonoBehaviour
{
    public Image itemIcon;

    public void SetSpell(SpellInventory.SpellSlot slot)
    {
        if (slot != null) 
        { 
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
        }
    }

    public void SetSpellEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
    }

}
