using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInventory_UI : MonoBehaviour
{
    public PlayerSpell player;

    public List<SpellSlot_UI> slots = new List<SpellSlot_UI> ();


    // Update is called once per frame
    void Update()
    {
        SpellSetUp();
    }

    void SpellSetUp()
    {
        if(slots.Count == player.spellInventory.slots.Count) 
        { 
            for(int i = 0; i < slots.Count; i++) 
            {
                if (player.spellInventory.slots[i].stype != SpellType.NONE)
                {
                    slots[i].SetSpell(player.spellInventory.slots[i]);

                }
                else
                {
                    slots[i].SetSpellEmpty();
                }
            }
        }
    }

}
