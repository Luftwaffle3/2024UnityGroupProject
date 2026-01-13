using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopUIButton : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject skillMenu;
    public GameObject journalMenu;

    public void SkillTreeButton()
    {
        skillMenu.SetActive(true);
        journalMenu.SetActive(false);
        inventoryMenu.SetActive(false);
    }

    public void InventoryButton()
    {
        skillMenu.SetActive(false);
        journalMenu.SetActive(false);
        inventoryMenu.SetActive(true);
    }

    public void JournalButton()
    {
        skillMenu.SetActive(false);
        journalMenu.SetActive(true);
        inventoryMenu.SetActive(false);
    }
}
