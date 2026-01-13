using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public GameObject pauseMenu;
    public GameObject skillMenu;
    public GameObject journalMenu;

    public GameObject corruptionBar;

    public Player player;

    public List<SlotsUI> slots = new List<SlotsUI>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !pauseMenu.activeSelf && !skillMenu.activeSelf && !journalMenu.activeSelf)
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            corruptionBar.SetActive(true);
            inventoryPanel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
            Setup();
        }
        else
        {
            corruptionBar.SetActive(false);
            inventoryPanel.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

}