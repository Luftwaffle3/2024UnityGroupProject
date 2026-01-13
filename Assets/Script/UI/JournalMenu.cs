using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMenu : MonoBehaviour
{
    public GameObject journalMenu;
    public GameObject pauseMenu;
    public GameObject inventoryMenu;
    public GameObject skillMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !pauseMenu.activeSelf && !inventoryMenu.activeSelf && !skillMenu.activeSelf)
        {
            if (!journalMenu.activeSelf)
            {
                journalMenu.SetActive(true);
                Cursor.visible = true;

            }
            else
            {
                journalMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
