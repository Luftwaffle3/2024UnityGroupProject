using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellInventory
{
    [System.Serializable]
    public class SpellSlot
    {
        public SpellType stype;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public SpellSlot()
        {
            stype = SpellType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Spell spell)
        {
            this.stype = spell.stype;
            this.icon = spell.icon;
            count++;
        }
    }

    public List<SpellSlot> slots = new List<SpellSlot>();

    public SpellInventory(int numSpellSlots)
    {
        for (int i = 0; i < numSpellSlots; i++) 
        { 
            SpellSlot slot = new SpellSlot();
            slots.Add(slot);
        }
    }
    
    public void Add(Spell spell)
    {
        foreach (SpellSlot slot in slots)
        {
            if (slot.stype == spell.stype && slot.CanAddItem())
            {
                slot.AddItem(spell);
                return;
            }
        }

        foreach (SpellSlot slot in slots)
        {
            if (slot.stype == SpellType.NONE)
            {
                slot.AddItem(spell) ;
                return;
            }
        }
    }
}
