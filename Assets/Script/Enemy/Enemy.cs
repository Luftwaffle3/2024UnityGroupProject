using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int curentHealth;

    public LootManager lootManager;

    void Start()
    {
        curentHealth = maxHealth; 
    }
    
    public void TakeDamage(int damage)
    {
        curentHealth -= damage;

        if (curentHealth <= 0 ) 
        {
            Die();
        }
    }

    public void Die() 
    {
        Debug.Log("Enemy died!");
        if (lootManager != null)
        {
            lootManager.SpawnLoot(transform.position);
        }
        Destroy(gameObject);
    }
}
