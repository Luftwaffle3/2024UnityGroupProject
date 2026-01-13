using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int value;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(5, 20);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.coins += value;
            Destroy(gameObject);
        }
    }   
}