using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static event Action OnPlayerDeath;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float fallThresholdY = -1f;

    public Animator animator;

    public static PlayerHealth Instance;

    private int damageReduction = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < fallThresholdY)
        {
            TakeDamage(currentHealth = 0); // Set currentHealth to 0
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hit");

        int finalDamage = Mathf.Max(damage - damageReduction, 0);

        currentHealth -= finalDamage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            animator.SetTrigger("Death");
            Debug.Log("Your Dead");
            OnPlayerDeath?.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void IncreaseDamageReduction(int amount)
    {
        damageReduction += amount;
    }

}
