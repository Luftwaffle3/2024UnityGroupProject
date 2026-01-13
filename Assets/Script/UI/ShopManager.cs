using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public int coins = 300;
    public Upgrade[] upgrades;

    public Text ctext;
    public Text coinText;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    public PlayerHealth player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void Start()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);

            upgrade.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();
                }
                else if (child.gameObject.name == "Cost") 
                {
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.cost.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.name;
                }
                else if(child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }
            }

            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuyItem(upgrade);
            });

        }
    }

    public void BuyItem (Upgrade upgrade)
    {
        if (coins >= upgrade.cost)
        {
            coins -= upgrade.cost;
            upgrade.quantity++;
            upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();

            GameObject newPrefab = Instantiate(upgrade.prefab, player.transform.position, Quaternion.identity);
            Destroy(newPrefab, 5f); // Optional: Destroy the prefab after 5 seconds

            ApplyUpgrade(upgrade);
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch(upgrade.name) 
        {
            case "Health": 
                int healAmount = 20;
                FindObjectOfType<PlayerHealth>().Heal(healAmount);
                break;
            case "Mana":
                int amount = 5;
                FindObjectOfType<PlayerMana>().IncreaseMana(amount);
                break;

        }
    }


    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    private void OnGUI()
    {
        ctext.text = "Coins: " + coins.ToString();
        coinText.text = "Coins: " + coins.ToString();
    }

    public void UpdateCoinText()
    {
        ctext.text = "Coins: " + coins.ToString();
        coinText.text = "Coins: " + coins.ToString();
    }

}

[System.Serializable]
public class Upgrade
{
    public string name;
    public int cost;
    public Sprite image;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
    public GameObject prefab;
}