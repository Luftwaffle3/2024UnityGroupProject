using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    public SpellInventory spellInventory;

    private void Awake()
    {
        spellInventory = new SpellInventory(3);
    }
}
