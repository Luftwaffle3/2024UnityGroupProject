using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public SpellType stype;
    public Sprite icon; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSpell playerSpell = collision.GetComponent<PlayerSpell>();

        if(playerSpell)
        {
            playerSpell.spellInventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum SpellType
{
    NONE, FIREBALL
}