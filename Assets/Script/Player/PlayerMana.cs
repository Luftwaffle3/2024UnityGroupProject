using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 50;
    public int currentMana;
    public ManaBar manaBar;

    public static PlayerMana Instance;

    void Start()
    {
        Instance = this;
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
        manaBar.SetMana(currentMana);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    // Function to decrease mana
    public void DecreaseMana(int amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        manaBar.SetMana(currentMana);
    }

    public void IncreaseMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
        manaBar.SetMana(currentMana);
    }

    public void IncreaseMaxMana(int amount)
    {
        maxMana += amount;
        manaBar.SetMaxMana(maxMana);
    }
}
