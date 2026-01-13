using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    public GameObject skillMenu;
    public GameObject pauseMenu; 
    public GameObject inventoryMenu;
    public GameObject journalMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && !pauseMenu.activeSelf && !inventoryMenu.activeSelf && !journalMenu.activeSelf)
        {
            if (!skillMenu.activeSelf)
            {
                Time.timeScale = 0f;
                skillMenu.SetActive(true);
                Cursor.visible = true;

            }
            else
            {
                Time.timeScale = 1f;
                skillMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
